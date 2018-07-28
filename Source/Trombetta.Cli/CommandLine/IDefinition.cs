//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   public interface IDefinition
   {
      /// <summary>
      /// Gets the collection of aliases of the option.
      /// </summary>
      /// <returns>The collection of aliases of the option.</returns>
      IEnumerable<String> Aliases { get; }

      /// <summary>
      /// Gets a value indicating whether the argument is required.
      /// </summary>
      /// <returns><c>true</c> if the argument is required; otherwise, <c>false</c>.</returns>
      Boolean IsRequired { get; }

      /// <summary>
      /// Gets the name of the argument.
      /// </summary>
      /// <returns>The name of the argument.</returns>
      String Name { get; }

      /// <summary>
      /// Gets the type of definition.
      /// </summary>
      /// <returns><The type of definition./returns>
      DefinitionType Type { get; }
   }
}