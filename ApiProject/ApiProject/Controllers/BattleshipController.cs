using ApiProject.Contracts.Requests;
using ApiProject.Contracts.Responses;
using ApiProject.Infrastructure;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Net;

namespace ApiProject.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class BattleshipController : ApiControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBattleshipService _battleshipService;

        public BattleshipController(ILogger<BattleshipController> logger, IBattleshipService battleshipService)
        {
            _logger = logger;
            _battleshipService = battleshipService;
        }

        /// <summary>
        /// This method is used to setup grid
        /// </summary>
        /// <param name="request">it accepts x and y length of grids. These lengths should be same and only equals to 10</param>
        /// <returns></returns>
        /// TODO: Validations missing - lengths, both x and y are equal
        [HttpPost]
        [Route("CreateGrid")]
        public IActionResult CreateGrid(CreateGridRequest request)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Creating grid");

                var battleship = new BattleshipGrid(
                    Guid.NewGuid(),
                    request.GridX,
                    request.GridY);
                var createResponse = _battleshipService.CreateGrid(battleship);

                var response = new CreateGridResponse(
                    battleship.GridId,
                    battleship.GridXCoordinates,
                    battleship.GridYCoordinates,
                    battleship.GridLayout);

                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// This method is used to setup battleship
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// TODO: Validations missing - coordinates should be horizontal or vertical, coordinates should lie in the range of grid
        [HttpPost]
        [Route("CreateBattleship")]
        public IActionResult CreateBattleship(CreateBattleshipRequest request)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Creating battleship");

                var battleship = new Battleship(
                    Guid.NewGuid(),
                    request.StartCoordinatesXY,
                    request.EndingCoordinatesXY);
                var createResponse = _battleshipService.CreateBattleship(battleship);

                var response = new CreateBattleshipResponse(
                    battleship.BattleshipId,
                    battleship.StartingCoordinatesXY,
                    battleship.EndingCoordinatesXY);

                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("LaunchAttack")]
        public IActionResult LaunchAttack(LaunchAttackRequest request)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Creating battleship");

                var attack = new LaunchAttack(
                    Guid.NewGuid(),
                    request.GridX,
                    request.GridY);
                var attackResponse = _battleshipService.LaunchAttack(attack);

                var response = new LaunchAttackResponse(
                    attackResponse);

                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("GetGridbyId")]
        public IActionResult GetGridbyId(Guid gridId)
        {
            var grid = _battleshipService.GetGridById(gridId);

            var response = new CreateGridResponse(
             grid.GridId,
             grid.GridXCoordinates,
             grid.GridYCoordinates,
             grid.GridLayout);

            return Ok(response);
        }
    }
}
