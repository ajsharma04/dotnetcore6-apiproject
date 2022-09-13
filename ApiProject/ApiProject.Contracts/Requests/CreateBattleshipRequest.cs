using ApiProject.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiProject.Contracts.Requests;

public record CreateBattleshipRequest (
    [Required(ErrorMessage = "Starting coordinates are Required")]
    GridCoordinates StartCoordinatesXY,

    [Required(ErrorMessage = "Ending coordinates Required")]    
    GridCoordinates EndingCoordinatesXY   
);
    
