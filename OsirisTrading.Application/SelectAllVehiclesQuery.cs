using MediatR;
using OsirisTrading.Domain.Dto;
using System.Collections.Generic;

namespace OsirisTrading.Application
{
    /// <summary>
    /// The select vehicles manager.
    /// </summary>
    /// <seealso cref="MediatR.IRequest&lt;System.Collections.Generic.IList&lt;OsirisTrading.Domain.Dto.Vehicle&gt;&gt;" />
    public class SelectAllVehiclesQuery : IRequest<Vehicle>
    {
    }
}