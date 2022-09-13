using ApiProject.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Contracts.Responses;

public record CreateBattleshipResponse(

    Guid BattleshipId,


    [Required(ErrorMessage = "Starting coordinates are Required")]
    GridCoordinates StartCoordinatesXY,

    [Required(ErrorMessage = "Ending coordinates Required")]
    [Range(0, 10, ErrorMessage = "GridY can only accept values 0 - 10")]
    GridCoordinates EndingCoordinatesXY   

);
    
