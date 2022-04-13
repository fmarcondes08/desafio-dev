using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DesafioDevBackEnd.Application.Interfaces;
using DesafioDevBackEnd.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.API.Controllers
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        public ITransactionApplicationService _service { get; set; }
        public TransactionController(ITransactionApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Import file
        /// </summary>
        /// <param name="file">CNAB File</param>
        /// <returns>Data from imported file</returns>
        /// <response code="200">Success</response> 
        /// <response code="500">Returns Internal Server error</response>
        [AllowAnonymous]
        [HttpPatch("Import"), DisableRequestSizeLimit]
        public async Task<IActionResult> ImportAsync(List<IFormFile> file)
        {
            try
            {
                var result = await _service.ImportFile(file);

                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new JsonResult(new { Errors = new string[] { ex.Message } });
            }
        }
    }
}
