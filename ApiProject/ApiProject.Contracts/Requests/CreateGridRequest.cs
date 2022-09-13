using System.ComponentModel.DataAnnotations;

namespace ApiProject.Contracts.Requests;

public record CreateGridRequest(
    [Required(ErrorMessage = "GridX is Required")]
    [Range(10,10, ErrorMessage = "GridX can only accept value 10")]
    int GridX,

    [Required(ErrorMessage = "GridY is Required")]
    [Range(10,10, ErrorMessage = "GridY can only accept value 10")]
    int GridY
);
    
