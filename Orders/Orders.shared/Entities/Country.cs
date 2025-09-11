﻿using System.ComponentModel.DataAnnotations;

namespace Orders.shared.Entities;

public class Country
{
    public int Id { get; set; }

    [Display(Name = "País")]
    [MaxLength(100, ErrorMessage = "El campo {0} No puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Name { get; set; } = null!;
}