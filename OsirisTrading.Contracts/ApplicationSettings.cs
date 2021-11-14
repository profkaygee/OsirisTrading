using Microsoft.Extensions.Configuration;

namespace OsirisTrading.Contracts
{
    /// <summary>
    /// The application settings.
    /// </summary>
    /// <seealso cref="OsirisTrading.Contracts.IApplicationSettings" />
    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSettings"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ApplicationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the vehicles data URL.
        /// </summary>
        /// <value>
        /// The vehicles data URL.
        /// </value>
        public string VehiclesDataUrl => _configuration["AppSettings:VehiclesDataUrl"];
    }
}