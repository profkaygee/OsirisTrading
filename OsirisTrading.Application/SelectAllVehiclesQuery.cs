using MediatR;
using OsirisTrading.Domain.Dto;
using System.Collections.Generic;

namespace OsirisTrading.Application
{
    /// <summary>
    /// The select vehicles manager.
    /// </summary>
    /// <seealso cref="Vehicle" />
    public class SelectAllVehiclesQuery : IRequest<IList<Vehicle>>
    {
    }
}