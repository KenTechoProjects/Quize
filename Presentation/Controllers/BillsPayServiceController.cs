
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
    public class BillsPayServiceController : BaseController
    {

        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<CategoryResponse>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("GetCategories/{countryId}/CountryCode")]
        public async Task<IActionResult> GetCategory([FromRoute] string countryId)
        {
            var command = new GetCategoriesCommand { CountryCode=countryId};
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CommitMinifyBillerResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("CommitMinifyBillerRequest")]
        public async Task<IActionResult> CommitMinifyBillerRequest([FromBody] CommitMinifyBillerRequestCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [ProducesResponseType(typeof(NetworkResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Get-Billers/category/{categoryId}/country/{countryId}")]
        public async Task<IActionResult> GetAllBillers([FromRoute] int categoryId, [FromRoute] string countryId)
        {
            var command = new GetBillersCommand { BillerCategoryId = categoryId, CountryId = countryId };
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProductResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Get-Products/{billerId}/biller/{countryId}/country")]
        public async Task<IActionResult> GetProducts([FromRoute] int billerId,[FromRoute] string countryId)
        {
            var command = new GetProductsCommand { BillerId = billerId, CountryId = countryId };
            var res = await Mediator.Send(command);
            return Ok(res);  
        }
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProductFormItemsResponseModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Get-Products-Form-Items/{productId}/product/{countryId}/country")]
        public async Task<IActionResult> GetProductsFormItems([FromRoute] int productId, [FromRoute]string countryId)
        {
            var command = new GetProductFormItemsCommand { ProductId = productId, CountryId = countryId };
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<ValidateBillerResponseModel>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("ValidateBillerRequest/{countryCode}")]
        public async Task<IActionResult> ValidateBillerRequest([FromRoute]string countryCode,[FromBody] ValidateBillerRequestCommand command)
        {
            command.CountryId = countryCode;
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseModel<CommitBillerRequestResponse>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("CommitBillerRequest/{countryCode}")]
        public async Task<IActionResult> CommitBillerRequest([FromRoute]string countryCode, [FromBody] CommitBillerRequestCommand command)
        {
            command.CountryId = countryCode;
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMinifyBIllersResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("GetMinifyBiller")]
        public async Task<IActionResult> GetMinifyBiller([FromBody] GetMinifyBillersCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
       
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMinifyProductResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("GetMinifyProduct")]
        public async Task<IActionResult> GetMinifyProducts([FromBody] GetMinifyProductsCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}