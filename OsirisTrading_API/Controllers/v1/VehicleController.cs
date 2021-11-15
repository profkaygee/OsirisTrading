using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OsirisTrading.Application;
using OsirisTrading.Domain.Dto;
using OsirisTrading.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace OsirisTrading_API.Controllers.v1
{
    /// <summary>
    /// The vehicles controller,
    /// </summary>
    /// <seealso cref="BaseApiController" />
    [ApiVersion("1.0")]
    [Route("vehicles")]
    //[Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class VehicleController : BaseApiController
    {
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleController"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache.</param>
        public VehicleController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// This endpoint is the one that gets called when we need to select all vehicles. We currently have
        /// a defualt size of 20 vehicles, but you are allowed to select more or less.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        [EnableCors("AllowAllPolicy")]
        public async Task<IActionResult> SelectAllVehicles(int size = 20)
        {
            if (_memoryCache.TryGetValue(ConstantKeys.VehiclesKey, out IList<Vehicle> vehicles))
            {
                // We want to refresh the cache because the size has changed.
                if (vehicles.Count == size)
                {
                    return Ok(vehicles);
                }
            }

            // Set the cache options here and then add the value to cache.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            vehicles = await Mediator.Send(new SelectAllVehiclesQuery());
            _memoryCache.Set(ConstantKeys.VehiclesKey, vehicles, cacheOptions);
            return Ok(vehicles);
        }

        /// <summary>
        /// This endpoint is the one that gets called when we need to select a specific vehicle. 
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{vehicleId}")]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
        [EnableCors("AllowAllPolicy")]
        public async Task<IActionResult> SelectVehicle(int vehicleId)
        {
            try
            {
                if (!_memoryCache.TryGetValue(ConstantKeys.VehiclesKey, out IList<Vehicle> vehicles))
                {
                    vehicles = await Mediator.Send(new SelectAllVehiclesQuery());
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1));
                    _memoryCache.Set(ConstantKeys.VehiclesKey, vehicles, cacheOptions);
                }

                // Look for the vehicle here and return it.
                var selectedVehicle = vehicles.FirstOrDefault(x => x.Id == vehicleId);

                if (selectedVehicle != null)
                    return Ok(selectedVehicle);

                return NotFound();
            }
            catch (ArgumentException ex)
            {
                var result = new ValidationResult();
                result.ValidationMessages ??= new List<string>();
                result.ValidationMessages.Add(ex.Message);
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Searches the vehicle.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/{phrase}")]
        [ProducesResponseType(typeof(Vehicle), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SearchVehicle(string phrase)
        {
            try
            {
                if (!_memoryCache.TryGetValue(ConstantKeys.VehiclesKey, out IList<Vehicle> vehicles))
                {
                    vehicles = await Mediator.Send(new SelectAllVehiclesQuery());
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1));
                    _memoryCache.Set(ConstantKeys.VehiclesKey, vehicles, cacheOptions);
                }

                // Look for the vehicle here and return it.
                var selectedVehicles = vehicles.Where(x =>
                    !string.IsNullOrWhiteSpace(x.make_and_model) && x.make_and_model.Contains(phrase)).ToList();

                if (selectedVehicles.Any())
                    return Ok(selectedVehicles);

                return NotFound();
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