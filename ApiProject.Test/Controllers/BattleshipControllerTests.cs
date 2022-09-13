using ApiProject.Contracts.Requests;
using ApiProject.Contracts.Responses;
using ApiProject.Models;
using ApiProject.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ApiProject.Controllers.Test
{

    public class BattleshipControllerTests
    {
        ILogger<BattleshipController>? logger;
        CreateGridRequest? mockRequest;
        IBattleshipService? service;

        [Fact]
        public void CreateGrid_BattleshipControllerTest()
        {
            /// Arrange            
            MockData(out logger, out mockRequest, out service);

            var stub = new BattleshipController(logger, service);

            /// Act
            var result = (OkObjectResult)stub.CreateGrid(mockRequest);

            // /// Assert
            result.StatusCode.Should().Be(200);
            result.Value.As<CreateGridResponse>().GridX.Should().Be(10);
            result.Value.As<CreateGridResponse>().GridY.Should().Be(10);
        }      

        
        private static void MockData(out ILogger<BattleshipController> logger, out CreateGridRequest mockRequest, out IBattleshipService service)
        {
            var mockService = new Mock<IBattleshipService>();
            var mockLogger = new Mock<ILogger<BattleshipController>>();
            logger = mockLogger.Object;
            ;
            mockRequest = new CreateGridRequest(GridX: 10, GridY: 10);
            Guid gridId = new Guid();
            var mockBattlesehip = new BattleshipGrid(gridId, 10, 10);
            var mockresponse = new CreateGridResponse(gridId, 10, 10,"");
            mockService.Setup(_ => _.CreateGrid(mockBattlesehip));
            mockService.Setup(_ => _.GetGridById(gridId));
            service = mockService.Object;
        }
    }
}