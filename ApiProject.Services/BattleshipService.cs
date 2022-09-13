using ApiProject.Contracts.Models;
using ApiProject.Contracts.Requests;
using ApiProject.Models;
using ApiProject.Services.Helpers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public class BattleshipService : IBattleshipService
    {
        private readonly ICacheService _cacheService;

        public BattleshipService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public BattleshipGrid CreateGrid(BattleshipGrid battleshipGrid)
        {
            var cacheData = _cacheService.GetData<BattleshipGrid>("grid");
            if (cacheData != null)
            {
                _cacheService.RemoveData("grid");
            }

            var expirationTime = DateTimeOffset.Now.AddMinutes(30);
            battleshipGrid.GridLayout = DrawGrid(battleshipGrid);
            _cacheService.SetData<BattleshipGrid>("grid", battleshipGrid, expirationTime);
            return battleshipGrid;
        }

        public BattleshipGrid GetGridById(Guid boardId)
        {
            var cacheData = _cacheService.GetData<BattleshipGrid>("grid");
            if (cacheData != null && cacheData.GridId == boardId)
            {
                return cacheData;
            }
            else
            {
                throw new Exception("Grid not found");
            }
        }

        public Battleship CreateBattleship(Battleship battleship)
        {
            if (battleship != null)
            {
                var cacheData = _cacheService.GetData<BattleshipGrid>("grid");
                string[][] grid = cacheData.GridLayout.ToTwoDimentionalArray();

                if (grid != null)
                {
                    for (int i = battleship.StartingCoordinatesXY.XCoordinate - 1 ; i <= battleship.EndingCoordinatesXY.XCoordinate - 1; i++)
                    {
                        for (int j = battleship.StartingCoordinatesXY.YCoordinate - 1; j <= battleship.EndingCoordinatesXY.YCoordinate - 1; j++)
                        {
                            if (grid[i][j].Equals("0"))
                            {
                                grid[i][j] = "1";
                            }
                            else
                            {
                                throw new Exception("There is already a battleship here");
                            }
                        }
                    }

                    cacheData.GridLayout = DrawGrid(grid);
                    var expirationTime = DateTimeOffset.Now.AddMinutes(30);
                    _cacheService.SetData<BattleshipGrid>("grid", cacheData, expirationTime);

                }
                return battleship;
            }
            else
            {
                throw new Exception("Battleship is not set");
            }
        }


        public AttackStatus LaunchAttack(LaunchAttack attack)
        {
            var attackStatus = AttackStatus.NOTSET;

            if (attack != null)
            {
                var cacheData = _cacheService.GetData<BattleshipGrid>("grid");
                var grid = cacheData.GridLayout.ToTwoDimentionalArray();

                if (grid != null)
                {
                    if (grid[attack.GridXCoordinates-1][attack.GridYCoordinates-1] == "1")
                    {
                        grid[attack.GridXCoordinates-1][attack.GridYCoordinates-1] = "X";
                        attackStatus = AttackStatus.HIT;
                    }
                    else
                    {
                        grid[attack.GridXCoordinates-1][attack.GridYCoordinates-1] = "-";
                        attackStatus = AttackStatus.MISS;
                    }

                    cacheData.GridLayout = DrawGrid(grid);
                    var expirationTime = DateTimeOffset.Now.AddMinutes(30);
                    _cacheService.SetData<BattleshipGrid>("grid", cacheData, expirationTime);
                }
            }
            return attackStatus;
        }

        private static string DrawGrid(BattleshipGrid battleshipGrid)
        {
            StringBuilder gridLayout = new();

            if (battleshipGrid != null)
            {
                string[][] grid = new string[battleshipGrid.GridXCoordinates][];
                for (int i = 0; i < grid.Length; i++)
                {
                    grid[i] = new string[battleshipGrid.GridYCoordinates];
                }
                int rowLength = grid.GetLength(0);                

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        grid[i][j] = "0";                            
                        gridLayout.Append(string.Concat(grid[i][j], (j == grid[i].Length - 1) ? (i == j?"":";"):","));
                    }
                }
            }

            return gridLayout.ToString();
        }

        private static string DrawGrid(string[][] grid)
        {
            StringBuilder gridLayout = new();

            int rowLength = grid.GetLength(0);
            
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    gridLayout.Append(string.Concat(grid[i][j], (j == grid[i].Length - 1) ? (i == j ? "" : ";") : ","));
                }                
            }

            return gridLayout.ToString();
        }
    }
}
