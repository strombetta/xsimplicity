//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an argument definition.
   /// </summary>
   public class ArgumentDefinition<T> : IArgumentDefinition
   {
      public ArgumentDefinition(String name, String description)
         : this(name, description, false)
      { }

      public ArgumentDefinition(String name, String description, T defaultValue)
         : this(name, description, false)
      {
         DefaultValue = defaultValue;
      }

      public ArgumentDefinition(String name, String description, Boolean isRequired)
      {
         Description = description;
         IsRequired = isRequired;
         Name = name;
      }

      IArgument IArgumentDefinition.MapToArgument(Object value)
      {
         return MapToArgument((T)value);
      }

      public IArgument MapToArgument(T value)
      {
         return new Argument<T>(value);
      }

      public IEnumerable<T> AllowedValue { get; }

      /// <summary>
      /// Gets the default value of the argument.
      /// </summary>
      /// <returns>The default value of the argument.</returns>
      public T DefaultValue { get; }

      /// <summary>
      /// Gets the description of the argument.
      /// </summary>
      /// <returns>The description of the argument.</returns>
      public String Description { get; }

      /// <summary>
      /// Gets a value indicating whether the argument is required.
      /// </summary>
      /// <returns><c>true</c> if argument is required; otherwise <c>false</c>.</returns>
      public Boolean IsRequired { get; }

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