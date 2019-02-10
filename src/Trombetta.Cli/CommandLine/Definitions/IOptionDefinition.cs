//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an option definition.
   /// </summary>
   public interface IOptionDefinition : IDefinition
   {
      /// <summary>
      /// Gets or sets a value indicating whether the argument is required.
      /// </summary>
      /// <returns><c>true</c> if the argument is required; otherwise, <c>false</c>.</returns>
      Boolean IsRequired { get; set; }

      IOption CreateOption();

      /// <summary>
      /// Gets the collection of aliases of the option.
      /// </summary>
      /// <returns>The collection of aliases of the option.</returns>
      IEnumerable<String> Aliases { get; }

      /// <summary>
      /// 
      /// </summary>
      /// <value></value>
      Object Argument { get; }

      Type ArgumentType { get; }

      /// <summary>
      /// Gets or sets a value indicating whether the argument is required.
      /// </summary>
      /// <returns><c>true</c> if the argument is required; otherwise, <c>false</c>.</returns>¸
      Boolean IsArgumentRequired { get; set; }
   }
}