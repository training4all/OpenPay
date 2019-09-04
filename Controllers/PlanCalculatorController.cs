using System;
using Microsoft.AspNetCore.Mvc;

namespace OpenPayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanCalculatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<InstallmentInfo> Get([FromBody] ApiRequest request)        
        {
            if (request.PurchasePrice <= 0)
                return BadRequest("price can not be negative or 0");

            return Ok(InstallmentModel.GetInstallment(request.PurchasePrice, Convert.ToDateTime(request.PurchaseDate)));
        }
    }
}
