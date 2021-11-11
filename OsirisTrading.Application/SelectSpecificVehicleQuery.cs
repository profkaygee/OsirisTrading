using MediatR;
using OsirisTrading.Domain.Dto;

namespace OsirisTrading.Application
{
    /// <summary>
    /// The Specific Vehicle Query Manager.
    /// </summary>
    /// <seealso cref="MediatR.IRequest&lt;OsirisTrading.Domain.Dto.Vehicle&gt;" />
    public class SelectSpecificVehicleQuery : IRequest<Vehicle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectSpecificVehicleQuery"/> class.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        public SelectSpecificVehicleQuery(string vehicleId)
        {
            VehicleId = vehicleId;
        }

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>
        /// The vehicle identifier.
        /// </value>
        public string VehicleId { get; set; }
    }
}