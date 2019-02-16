//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line argument definition.
   /// </summary>
   public class Argument<T> : IArgument<T>
   {
      /// <summary>
      /// Initializes a new instance of the <see creft="ArgumentDefinition{T}"/> class with the
      /// specified name, and help message.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      public Argument(String name, String helpMessage)
         : this(name, null, default(T), false, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Argument{T}"/> class with the
      /// specified name, help message, and default value.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="defaultValue">The default value of the argument.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      public Argument(String name, T defaultValue, String helpMessage)
         : this(name, null, defaultValue, false, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Argument{T}"/> class with the
      /// specified name, the value indicating whether the argument is required, and  the help message.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="isRequired">A value indicating whether the argument is required.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      public Argument(String name, Boolean isRequired, String helpMessage)
         : this(name, null, default(T), isRequired, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Argument{T}"/> class with the
      /// specified name, the collection of allowed values, the default value, a value indicating
      /// whether the argument is required, and the help message.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="allowedValues">The collection of values allowed.</param>
      /// <param name="defaultValue">The default value of the argument.</param>
      /// <param name="isRequired">A value indicating whether the argument is required.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      public Argument(String name, IEnumerable<T> allowedValues, T defaultValue, Boolean isRequired, String helpMessage)
      {
         if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
         if (allowedValues != null && !allowedValues.Contains(defaultValue)) throw new ArgumentException($"{nameof(allowedValues)} doesn't contains the {nameof(defaultValue)}.");

         AllowedValues = allowedValues;
         DefaultValue = defaultValue;
         HelpMessage = helpMessage;
         IsRequired = isRequired;
         Name = name;
      }

      /// <summary>
      /// Gets the collection of values allowed.
      /// </summary>
      /// <value>The collection of values allowed.</value>
      public IEnumerable<T> AllowedValues { get; }

      /// <summary>
      /// Gets the collection of values allowed.
      /// </summary>
      /// <value>The collection of values allowed.</value>
      IEnumerable IArgument.AllowedValues
      {
         get { return AllowedValues; }
      }

      /// <summary>
      /// Gets the default value of the argument.
      /// </summary>
      /// <returns>The default value of the argument.</returns>
      public T DefaultValue { get; }

      /// <summary>
      /// Gets the default value of the argument.
      /// </summary>
      /// <returns>The default value of the argument.</returns>
      Object IArgument.DefaultValue
      {
         get { return DefaultValue; }
      }

      /// <summary>
      /// Gets the text used as help message of the argument.
      /// </summary>
      /// <returns>The text used as help message of the argument.</returns>
      public String HelpMessage { get; }

      /// <summary>
      /// Gets or sets a value indicating whether the argument is required.
      /// </summary>
      /// <returns><c>true</c> if argument is required; otherwise <c>false</c>.</returns>
      public Boolean IsRequired { get; set; }

      /// <summary>
      /// Gets the name of the argument.
      /// </summary>
      /// <returns>The name of the argument.</returns>
      public String Name { get; }
   }
}