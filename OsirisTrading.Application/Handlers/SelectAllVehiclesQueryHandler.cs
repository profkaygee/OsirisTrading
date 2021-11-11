using MediatR;
using OsirisTrading.Domain.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace OsirisTrading.Application.Handlers
{
    public class SelectAllVehiclesQueryHandler : IRequestHandler<SelectAllVehiclesQuery, Vehicle>
    {
        public Task<Vehicle> Handle(SelectAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
