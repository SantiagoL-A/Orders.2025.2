using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.shared.Interface;

namespace Orders.shared.Entities;

public class City : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Estado")]
    [MaxLength(100, ErrorMessage = "El campo {0} No puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    public string Name { get; set; } = null!;

    public int StateId { get; set; }

    public State? State { get; set; }
}