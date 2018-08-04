//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an application command.
   /// </summary>
   public class CommandDefinition : IDefinition
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CommandDefinition"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public CommandDefinition(String name, String helpMessage)
      { }

      public IEnumerable<string> Aliases => throw new NotImplementedException();

      public bool IsRequired => throw new NotImplementedException();

      public string Name => throw new NotImplementedException();

      public DefinitionType Type => throw new NotImplementedException();
   }
}