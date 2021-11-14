using OsirisTrading.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OsirisTrading.Infrastructure.ServiceLayer
{
    /// <summary>
    /// The interface for the service layer.
    /// </summary>
    public interface IServiceLayer
    {
        /// <summary>
        /// Selects the vehicles.
        /// </summary>
        /// <returns></returns>
        Task<IList<Vehicle>> SelectVehicles();
    }
}