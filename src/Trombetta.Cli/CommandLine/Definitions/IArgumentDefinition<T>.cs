//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an argument definition.
   /// </summary>
   public interface IArgumentDefinition<out T> : IArgumentDefinition
   {
      /// <summary>
      /// Gets the collection of values allowed.
      /// </summary>
      /// <value>The collection of values allowed.</value>
      new IEnumerable<T> AllowedValues { get; }

      /// <summary>
      /// Gets the default value of the argument.
      /// </summary>
      /// <returns>The default value of the argument.</returns>
      new T DefaultValue { get; }
   }
}