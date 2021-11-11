using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsirisTrading.Application;
using OsirisTrading.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace OsirisTrading_API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vehicles")]
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class VehicleController : BaseApiController
    {
        /// <summary>
        /// Selects all vehicles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SelectAllVehicles()
        {
            var result = await Mediator.Send(new SelectAllVehiclesQuery());
            return Ok(result);
        }

        /// <summary>
        /// Selects the vehicle.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{vehicleId}")]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectVehicle(int vehicleId)
        {
            try
            {
                var decodedValue = HttpUtility.UrlDecode(vehicleId.ToString());
                var result = await Mediator.Send(new SelectSpecificVehicleQuery(decodedValue));
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                var result = new ValidationResult();
                result.ValidationMessages ??= new List<string>();
                result.ValidationMessages.Add(ex.Message);
                return BadRequest(result);
            }
        }
    }
}