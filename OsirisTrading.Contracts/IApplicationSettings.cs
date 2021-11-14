namespace OsirisTrading.Contracts
{
    /// <summary>
    /// The application settings.
    /// </summary>
    public interface IApplicationSettings
    {
        /// <summary>
        /// Gets the vehicles data URL.
        /// </summary>
        /// <value>
        /// The vehicles data URL.
        /// </value>
        string VehiclesDataUrl { get; }
    }
}