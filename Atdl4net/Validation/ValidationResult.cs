#region Copyright (c) 2010-2012, Cornerstone Technology Limited. http://atdl4net.org
//
//   This software is released under both commercial and open-source licenses.
//
//   If you received this software under the commercial license, the terms of that license can be found in the
//   Commercial.txt file in the Licenses folder.  If you received this software under the open-source license,
//   the following applies:
//
//      This file is part of Atdl4net.
//
//      Atdl4net is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public 
//      License as published by the Free Software Foundation, either version 2.1 of the License, or (at your option) any later version.
// 
//      Atdl4net is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
//      of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public License for more details.
//
//      You should have received a copy of the GNU Lesser General Public License along with Atdl4net.  If not, see
//      http://www.gnu.org/licenses/.
//
#endregion

using System;
using System.Linq;

namespace Atdl4net.Validation
{
    /// <summary>
    /// Represents the results of a validation operation.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Type of the result.
        /// </summary>
        public enum ResultType
        {
            /// <summary>The result represents a valid value.</summary>
            Valid,

            /// <summary>The result represents a missing mandatory value.</summary>
            Missing,

            /// <summary>The result represents an invalid value.</summary>
            Invalid,

            /// <summary>The result represents a value that does not respect parameter constraints.</summary>
            InvalidConstraint
        }

        private readonly ResultType _validityType;
        private readonly string _errorText;
        private readonly string _contraintText;

        private static readonly ValidationResult _validResult = new ValidationResult();

        /// <summary>
        /// Indicates whether the validation that this ValidationResult corresponds to is valid.
        /// </summary>
        public bool IsValid { get { return _validityType == ResultType.Valid; } }

        /// <summary>
        /// Indicates whether the result that this ValidationResult corresponds to is invalid
        /// because the field was required but not present.
        /// </summary>
        public bool IsMissing { get { return _validityType == ResultType.Missing; } }

        /// <summary>
        /// Gets the error text for this ValidationResult; used when a validation has failed.
        /// </summary>
        public string ErrorText { get { return _errorText; } }

        /// <summary>
        /// Gets the constraint text for this ValidationResult; used when a validation has failed based on some constraint.
        /// </summary>
        public string ConstraintText { get { return _contraintText; } }

        /// <summary>
        /// Gets a static ValidationResult instance that corresponds to a successful validation.
        /// </summary>
        public static ValidationResult ValidResult { get { return _validResult; } }

        /// <summary>
        /// Gets the type of the ValidationResult.
        /// </summary>
        public ResultType Type { get { return _validityType; } }

        /// <summary>
        /// Gets the display value.
        /// </summary>
        public string DisplayValue { get; set; }

        /// <summary>
        /// Initializes a new <see cref="ValidationResult"/> instance with the supplied state,
        /// format string and optional array of arguments.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="format">Format string.</param>
        /// <param name="args">Optional array of arguments to apply to format string.</param>
        public ValidationResult(ResultType resultType, string format, params object[] args)
        {
            _validityType = resultType;
            _errorText = string.Format(format, args);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="constraintText">The constraint text.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public ValidationResult(ResultType resultType, string constraintText, string format, params object[] args)
            : this(resultType, format, args)
        {
            _contraintText = constraintText;
        }

        private ValidationResult()
        {
            _validityType = ResultType.Valid;
        }
    }
}
