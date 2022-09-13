using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class BattleshipGrid
    {
        public Guid GridId { get; }

        [Required]
        public int GridXCoordinates { get; }

        [Required]
        public int GridYCoordinates { get; }
     
        public string GridLayout { get; set; }

        public BattleshipGrid(Guid gridId,int gridXCoordinates,int gridYCoordinates, string gridLayout = "")
        {
            GridId = gridId;
            GridXCoordinates = gridXCoordinates;
            GridYCoordinates = gridYCoordinates;
            GridLayout = gridLayout;
        }
    }
}
