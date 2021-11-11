using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OsirisTrading.Domain.Dto
{
    /// <summary>
    /// The vehicle model
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// The vehicle model constructor.
        /// </summary>
        public Vehicle()
        {
            CarOptions = new List<string>();
            Specifications = new List<string>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>
        /// The uid.
        /// </value>
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the vin.
        /// </summary>
        /// <value>
        /// The vin.
        /// </value>
        [JsonPropertyName("vin")]
        public string Vin { get; set; }

        /// <summary>
        /// Gets or sets the make and model.
        /// </summary>
        /// <value>
        /// The make and model.
        /// </value>
        [JsonPropertyName("make_and_model")]
        public string MakeAndModel { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the transmission.
        /// </summary>
        /// <value>
        /// The transmission.
        /// </value>
        [JsonPropertyName("transmission")]
        public string Transmission { get; set; }

        /// <summary>
        /// Gets or sets the type of the drive.
        /// </summary>
        /// <value>
        /// The type of the drive.
        /// </value>
        [JsonPropertyName("drive_type")]
        public string DriveType { get; set; }

        /// <summary>
        /// Gets or sets the type of the fuel.
        /// </summary>
        /// <value>
        /// The type of the fuel.
        /// </value>
        [JsonPropertyName("fuel_type")]
        public string FuelType { get; set; }

        /// <summary>
        /// Gets or sets the type of the car.
        /// </summary>
        /// <value>
        /// The type of the car.
        /// </value>
        [JsonPropertyName("car_type")]
        public string CarType { get; set; }

        /// <summary>
        /// Gets or sets the car options.
        /// </summary>
        /// <value>
        /// The car options.
        /// </value>
        [JsonPropertyName("car_options")]
        public IList<string> CarOptions { get; set; }

        /// <summary>
        /// Gets or sets the specifications.
        /// </summary>
        /// <value>
        /// The specifications.
        /// </value>
        [JsonPropertyName("specs")]
        public IList<string> Specifications { get; set; }

        /// <summary>
        /// Gets or sets the doors.
        /// </summary>
        /// <value>
        /// The doors.
        /// </value>
        [JsonPropertyName("doors")]
        public int Doors { get; set; }

        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        /// <value>
        /// The mileage.
        /// </value>
        [JsonPropertyName("mileage")]
        public int Mileage { get; set; }

        /// <summary>
        /// Gets or sets the kilometrage.
        /// </summary>
        /// <value>
        /// The kilometrage.
        /// </value>
        [JsonPropertyName("kilometrage")]
        public int Kilometrage { get; set; }

        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        /// <value>
        /// The license plate.
        /// </value>
        [JsonPropertyName("license_plate")]
        public string LicensePlate { get; set; }
    }
}