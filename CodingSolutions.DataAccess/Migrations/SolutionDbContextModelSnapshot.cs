﻿// <auto-generated />
using System;
using CodingSolutions.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingSolutions.DataAccess.Migrations
{
    [DbContext(typeof(SolutionDbContext))]
    partial class SolutionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingSolutions.Domain.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Saldo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(10,2)")
                        .HasDefaultValue(500m);

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CodingSolutions.Domain.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CodingSolutions.Domain.ProdutoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosClientes");
                });

            modelBuilder.Entity("CodingSolutions.Domain.ProdutoCliente", b =>
                {
                    b.HasOne("CodingSolutions.Domain.Cliente", "Cliente")
                        .WithMany("ProdutoPorCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingSolutions.Domain.Produto", "Produto")
                        .WithMany("ProdutoPorCliente")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CodingSolutions.Domain.Cliente", b =>
                {
                    b.Navigation("ProdutoPorCliente");
                });

            modelBuilder.Entity("CodingSolutions.Domain.Produto", b =>
                {
                    b.Navigation("ProdutoPorCliente");
                });
#pragma warning restore 612, 618
        }
    }
}
