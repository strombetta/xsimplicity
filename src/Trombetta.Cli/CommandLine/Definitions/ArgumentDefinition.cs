//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents a command line argument definition.
   /// </summary>
   public class ArgumentDefinition<T> : IArgumentDefinition
   {
      /// <summary>
      /// Initializes a new instance of the <see creft="ArgumentDefinition{T}"/> class with the
      /// specified name, and help message.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      public ArgumentDefinition(String name, String helpMessage)
         : this(name, helpMessage, default(T))
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ArgumentDefinition{T}"/> class with the
      /// specified name, help message, and default value.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      /// <param name="defaultValue">The default value of the argument.</param>
      public ArgumentDefinition(String name, String helpMessage, T defaultValue)
         : this(name, helpMessage, false)
      {
         DefaultValue = defaultValue;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="ArgumentDefinition{T}"/> class with the
      /// specified name, help message, and value indicating whether the argument is required.
      /// </summary>
      /// <param name="name">The name of the argument.</param>
      /// <param name="helpMessage">The help message of the argument.</param>
      /// <param name="isRequired">A value indicating whether the argument is required.</param>
      public ArgumentDefinition(String name, String helpMessage, Boolean isRequired)
      {
         HelpMessage = helpMessage;
         IsRequired = isRequired;
         Name = name;
      }

      public IEnumerable<T> AllowedValue { get; }

      /// <summary>
      /// Gets the default value of the argument.
      /// </summary>
      /// <returns>The default value of the argument.</returns>
      public T DefaultValue { get; }

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

      /// <summary>
      /// Gets the type of definition.
      /// </summary>
      /// <returns><The type of definition./returns>
      public DefinitionType Type => DefinitionType.Argument;
   }
}