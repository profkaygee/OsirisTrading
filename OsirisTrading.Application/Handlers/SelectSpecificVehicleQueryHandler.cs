using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsirisTrading.Domain.Dto;

namespace OsirisTrading.Application.Handlers
{
    /// <summary>
    /// This is the handler for specific vehicles
    /// </summary>
    /// <seealso cref="Vehicle" />
    public class SelectSpecificVehicleQueryHandler : IRequestHandler<SelectSpecificVehicleQuery, Vehicle>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<Vehicle> Handle(SelectSpecificVehicleQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}