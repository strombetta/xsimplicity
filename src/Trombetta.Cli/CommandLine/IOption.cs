//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an option definition.
   /// </summary>
   public interface IOption : IDefinition
   {
      /// <summary>
      /// Gets the collection of aliases of the option.
      /// </summary>
      /// <returns>The collection of aliases of the option.</returns>
      IEnumerable<String> Aliases { get; }

      /// <summary>
      /// Gets the argument definition.
      /// </summary>
      /// <value>The argument definition.</value>
      IArgument ArgumentDefinition { get; }

      /// <summary>
      /// Gets or sets a value indicating whether the option is required.
      /// </summary>
      /// <returns><c>true</c> if the argument is option; otherwise, <c>false</c>.</returns>
      Boolean IsRequired { get; set; }

      IOptionResult CreateOption();
   }
}