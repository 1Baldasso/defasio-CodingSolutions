﻿using CodingSolutions.Domain;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace CodingSolutions.API.Models.Cliente;

public record ClienteUpdateDTO
{
    [FromRoute]
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CPF { get; set; } = null!;
}