using System.Collections.Generic;

namespace OsirisTrading.Domain.Entities
{
    /// <summary>
    /// The vehicle entity
    /// </summary>
    public class VehicleEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>
        /// The uid.
        /// </value>
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the vin.
        /// </summary>
        /// <value>
        /// The vin.
        /// </value>
        public string Vin { get; set; }

        /// <summary>
        /// Gets or sets the make and model.
        /// </summary>
        /// <value>
        /// The make and model.
        /// </value>
        public string MakeAndModel { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the transmission.
        /// </summary>
        /// <value>
        /// The transmission.
        /// </value>
        public string Transmission { get; set; }

        /// <summary>
        /// Gets or sets the type of the drive.
        /// </summary>
        /// <value>
        /// The type of the drive.
        /// </value>
        public string DriveType { get; set; }

        /// <summary>
        /// Gets or sets the type of the fuel.
        /// </summary>
        /// <value>
        /// The type of the fuel.
        /// </value>
        public string FuelType { get; set; }

        /// <summary>
        /// Gets or sets the type of the car.
        /// </summary>
        /// <value>
        /// The type of the car.
        /// </value>
        public string CarType { get; set; }

        /// <summary>
        /// Gets or sets the car options.
        /// </summary>
        /// <value>
        /// The car options.
        /// </value>
        public IList<string> CarOptions { get; set; }

        /// <summary>
        /// Gets or sets the specifications.
        /// </summary>
        /// <value>
        /// The specifications.
        /// </value>
        public IList<string> Specifications { get; set; }

        /// <summary>
        /// Gets or sets the doors.
        /// </summary>
        /// <value>
        /// The doors.
        /// </value>
        public int Doors { get; set; }

        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        /// <value>
        /// The mileage.
        /// </value>
        public int Mileage { get; set; }

        /// <summary>
        /// Gets or sets the kilometrage.
        /// </summary>
        /// <value>
        /// The kilometrage.
        /// </value>
        public int Kilometrage { get; set; }

        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        /// <value>
        /// The license plate.
        /// </value>
        public string LicensePlate { get; set; }
    }
}