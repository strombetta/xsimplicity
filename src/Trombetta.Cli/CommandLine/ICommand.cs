//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an command definition.
   /// </summary>
   public interface ICommand : IDefinition
   {
      ICommandResult CreateCommand();

      /// <summary>
      /// Gets the collection of aliases of the command.
      /// </summary>
      /// <returns>The collection of aliases of the command.</returns>
      IEnumerable<String> Aliases { get; }

      /// <summary>
      /// Gets or sets the collection of arguments.
      /// </summary>
      /// <value>The collection of arguments.</value>
      IEnumerable<IArgument> Arguments { get; set; }

      /// <summary>
      /// Gets the collection of options.
      /// </summary>
      /// <value>The collection of options.</value>
      IEnumerable<IOption> Options { get; set; }
   }
}