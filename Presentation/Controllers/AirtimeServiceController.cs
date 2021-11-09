
using Application.Common.Models;
using Application.Handlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirtimeServiceController : BaseController
    {

        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<NetworkResponse>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Get-All-Airtime/{countryCode}/country")]
        public async Task<IActionResult> GetNetwork([FromRoute] string countryCode)
        {
            var command = new GetAllNetworkCommand { };
            command.CountryId = countryCode;
            var res = await Mediator.Send(command);
            return Ok(res);
        }
   
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<BuyAirtimeResponse>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Buy-Airtime/{countryId}/country")]
        public async Task<IActionResult> BuyAirtime([FromRoute]string countryId, [FromBody] BuyAirtimeCommand command)
        {
            command.CountryId = countryId;
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}