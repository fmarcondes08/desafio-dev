using DesafioDevBackEnd.API.Controllers;
using DesafioDevBackEnd.Application.Dtos;
using DesafioDevBackEnd.Application.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DesafioDevBackEnd.Tests.Controllers
{
    public class TransactionControllerTest
    {
        [Fact]
        public async Task Should_Return_List_Of_StoreOutputDto()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            //Setup mock file using a memory stream
            var content = "2201903010000050200845152540738473****1231231233MARCOS PEREIRAMERCADO DA AVENIDA";
            var fileName = "test.txt";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;
            var listFile = new List<IFormFile>();
            listFile.Add(file);
            
            var outputMock = new List<StoreOutputDto>();
            outputMock.Add(new StoreOutputDto
            {
                CurrentBalance = 10,
                Name = "MERCADO DA AVENIDA",
                Transactions = null     
            });


            var mockService = new Mock<ITransactionApplicationService>();
            mockService
                .SetupAsync(member => member.ImportFile(listFile))
                .Returns(outputMock);

            var mockController = new TransactionController(mockService.Object);
            mockController.ControllerContext = new ControllerContext();
            mockController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = mockController.ControllerContext.HttpContext.Response;

            ////Act
            var result = await mockController.ImportAsync(listFile);

            result.Should().BeOfType<JsonResult>();
            ((JsonResult)result).Value.Should().Be(outputMock);
        }
    }
}
