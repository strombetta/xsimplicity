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
      /// Initializes a new instance of the <see cref="CommandDefinition" /> class with the specified name.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      public CommandDefinition(String name)
      {
         Name = name;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CommandDefinition"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public CommandDefinition(String name, String helpMessage)
      { 
         HelpMessage = helpMessage;
         Name = name;
      }

      /// <summary>
      /// Creates a <see cref="Command"/> object based on the current definition.
      /// </summary>
      /// <returns>A <see cref="Command"/> object based on the current definition.</returns>
      public Command CreateCommand()
      {
         return new Command(this);
      }

      /// <summary>
      /// Gets the help message of the command.
      /// </summary>
      /// <returns>The help message of the command.</returns>
      public String HelpMessage {get;set;}

      /// <summary>
      /// Gets or sets a value indicating whether the command is required.
      /// </summary>
      /// <returns><c>true</c> if the command is required; otherwise, <c>false</c>.</returns>
      public Boolean IsRequired { get; set; }

      /// <summary>
      /// Gets the name of the definition.
      /// </summary>
      /// <returns>The name of the definition.</returns>
      public String Name { get; set;}

      /// <summary>
      /// Gets the type of definition.
      /// </summary>
      /// <returns><The type of definition./returns>
      public DefinitionType Type => DefinitionType.Command;
   }
}