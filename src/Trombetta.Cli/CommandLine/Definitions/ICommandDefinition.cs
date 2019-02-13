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
   public interface ICommandDefinition : IDefinition
   {
      ICommand CreateCommand();

      /// <summary>
      /// Gets or sets the collection of argument definitions.
      /// </summary>
      /// <value>The collection of argument definitions.</value>
      IEnumerable<IArgumentDefinition> ArgumentDefinitions { get; set; }
   }
}