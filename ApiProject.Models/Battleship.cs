using ApiProject.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class Battleship
    {
        public Guid BattleshipId { get; }

        [Required]
        public GridCoordinates StartingCoordinatesXY { get; }

        [Required]
        public GridCoordinates EndingCoordinatesXY { get; }
     

        public Battleship(Guid battleshipId, GridCoordinates startingCoordinatesXY, GridCoordinates endingCoordinatesXY){
            BattleshipId = battleshipId;
            StartingCoordinatesXY = startingCoordinatesXY;
            EndingCoordinatesXY = endingCoordinatesXY;
        }
    }
}
