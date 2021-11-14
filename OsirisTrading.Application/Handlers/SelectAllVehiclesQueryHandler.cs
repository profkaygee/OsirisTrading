using MediatR;
using OsirisTrading.Domain.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OsirisTrading.Infrastructure.ServiceLayer;

namespace OsirisTrading.Application.Handlers
{
    /// <summary>
    /// Select the all vehicles query;
    /// </summary>
    /// <seealso cref="Vehicle" />
    public class SelectAllVehiclesQueryHandler : IRequestHandler<SelectAllVehiclesQuery, IList<Vehicle>>
    {
        private readonly IServiceLayer _serviceLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectAllVehiclesQueryHandler"/> class.
        /// </summary>
        /// <param name="serviceLayer">The service layer.</param>
        public SelectAllVehiclesQueryHandler(IServiceLayer serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public Task<IList<Vehicle>> Handle(SelectAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var result = _serviceLayer.SelectVehicles();
            return result;
        }
    }
}