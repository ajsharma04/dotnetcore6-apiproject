using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Contracts.Models
{
    public class GridCoordinates
    {
        [Range(0, 10, ErrorMessage = "X can only accept values 0 - 10")]
        public int XCoordinate { get; set; }

        [Range(0, 10, ErrorMessage = "Y can only accept values 0 - 10")]
        public int YCoordinate { get; set; }
    }
}
