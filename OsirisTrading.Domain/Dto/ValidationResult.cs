using System;
using System.Collections.Generic;
using System.Linq;

namespace OsirisTrading.Domain.Dto
{
    /// <summary>
    /// The validation result
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid => !ValidationMessages.Any();

        /// <summary>
        /// Gets or sets the validation messages.
        /// </summary>
        /// <value>
        /// The validation messages.
        /// </value>
        public IList<string> ValidationMessages { get; set; } = new List<string>();

        /// <summary>
        /// Gets the full validation message.
        /// </summary>
        /// <value>
        /// The full validation message.
        /// </value>
        public string FullValidationMessage =>
            ValidationMessages.Any() ? "Valid" : string.Join(Environment.NewLine, ValidationMessages);
    }

    /// <summary>
    /// The validation result.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidationResult<T> : ValidationResult
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; }
    }
}