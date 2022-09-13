using System.ComponentModel.DataAnnotations;

namespace ApiProject.Contracts.Requests;

public record LaunchAttackRequest(
    [Required(ErrorMessage = "GridX is Required")]
    [Range(0,10, ErrorMessage = "GridX can only accept values 0 - 10")]
    int GridX,

    [Required(ErrorMessage = "GridY is Required")]
    [Range(0,10, ErrorMessage = "GridY can only accept values 0 - 10")]
    int GridY
);
    
