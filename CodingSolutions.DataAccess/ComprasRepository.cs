﻿using CodingSolutions.Domain;
using CodingSolutions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodingSolutions.DataAccess;

internal class ComprasRepository : IComprasRepository
{
    private readonly SolutionDbContext _context;

    public ComprasRepository(SolutionDbContext context)
    {
        _context = context;
    }

    public async Task CarregarSaldoAsync(Guid idCliente, decimal valor)
    {
        var originalCliente = await _context.Clientes.FindAsync(idCliente);
        if (originalCliente == null)
            throw new Exception("Cliente não encontrado");
        var entry = _context.Entry(originalCliente);
        originalCliente.Saldo += valor;
        entry.CurrentValues.SetValues(originalCliente);
        await _context.SaveChangesAsync();
    }

    public async Task ComprarAsync(Guid id, Guid clienteId, int quantidade, CancellationToken ct)
    {
        var produto = await _context.Produtos.FindAsync(id);
        var cliente = await _context.Clientes.FindAsync(clienteId);
        if (produto == null)
            throw new Exception("Produto não encontrado");
        if (cliente == null)
            throw new Exception("Cliente não encontrado");
        if (produto.Preco * quantidade > cliente.Saldo)
            throw new Exception("Saldo insuficiente");
        var entry = _context.Entry(cliente);
        cliente.Saldo -= produto.Preco * quantidade;
        entry.CurrentValues.SetValues(cliente);
        await _context.ProdutosClientes.AddAsync(new ProdutoCliente
        {
            Cliente = cliente,
            Produto = produto,
            Quantidade = quantidade
        }, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<ProdutoCliente>> HistoricoComprasAsync(CancellationToken ct)
    {
        return await _context.ProdutosClientes.Include(x => x.Cliente)
            .Include(x => x.Produto)
            .AsNoTracking()
            .AsSplitQuery()
            .ToListAsync(ct);
    }
}