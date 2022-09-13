using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class LaunchAttack
    {
        public Guid AttackIdId { get; }

        [Required]
        public int GridXCoordinates { get; }

        [Required]
        public int GridYCoordinates { get; }     
        
        public LaunchAttack(Guid attackIdId, int gridXCoordinates,int gridYCoordinates, string gridLayout = "")
        {
            AttackIdId = attackIdId;
            GridXCoordinates = gridXCoordinates;
            GridYCoordinates = gridYCoordinates;           
        }
    }
}
