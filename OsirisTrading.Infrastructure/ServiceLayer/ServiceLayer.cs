using Newtonsoft.Json;
using OsirisTrading.Contracts;
using OsirisTrading.Domain.Dto;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OsirisTrading.Infrastructure.ServiceLayer
{
    /// <summary>
    /// The service layer.
    /// </summary>
    /// <seealso cref="IServiceLayer" />
    public class ServiceLayer : IServiceLayer
    {
        private readonly IRestClient _client;
        private readonly IApplicationSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLayer"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="settings">The settings.</param>
        public ServiceLayer(IRestClient client, IApplicationSettings settings)
        {
            _client = client;
            _settings = settings;
        }

        /// <summary>
        /// Selects the vehicles.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IList<Vehicle>> SelectVehicles()
        {
            var url = _settings.VehiclesDataUrl.EndsWith("/") ?
                $"{_settings.VehiclesDataUrl}random_vehicle?size=20" :
                $"{_settings.VehiclesDataUrl}/random_vehicle?size=20";

            var request = new RestRequest(url);
            var response = await _client.ExecuteGetAsync(request);

            return response.IsSuccessful ? JsonConvert.DeserializeObject<IList<Vehicle>>(response.Content) : null;
        }
    }
}