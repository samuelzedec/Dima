using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dima.Core.Requests.Categories;

public class UpdateCategoryRequest : Request
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Título é requerido")]
    [MaxLength(80, ErrorMessage = "Título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Descrição é requerido")]
    [MaxLength(255, ErrorMessage = "Descrição deve conter até 255 Caracteres")]
    public string Description { get; set; } = string.Empty;
}