using System.ComponentModel.DataAnnotations;
using Dima.Core.Enums;

namespace Dima.Core.Requests.Transactions;

public class UpdateTransactionRequest : Request
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Título é requerido")]
    [MaxLength(ErrorMessage = "Título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tipo de transação deve ser válida")]
    [Range(1, 2, ErrorMessage = "O valor deve ser entre 1 e 2")]
    public ETransactionType Type { get; set; }
    
    [Required(ErrorMessage = "Quantidade deve ser informada")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Categoria é requerido")]
    public long CategoryId { get; set; }
    
    [Required(ErrorMessage = "A data deve ser válida")]
    public DateTime PaidOrReceivedAt { get; set; }
}