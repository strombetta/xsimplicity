//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents a command line command definition.
   /// </summary>
   public class CommandDefinition : ICommandDefinition
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CommandDefinition" /> class with the 
      /// specified name.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      public CommandDefinition(String name)
      {
         Name = name;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="CommandDefinition"/> class with the
      /// specified name, and help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public CommandDefinition(String name, String helpMessage)
      {
         HelpMessage = helpMessage;
         Name = name;
      }

      public CommandDefinition(String name, IArgumentDefinition argument, String helpMessage)
      {
         Argument = argument;
         HelpMessage = helpMessage;
         Name = name;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public ICommand CreateCommand()
      {
         return new Command(this);
      }

      public IArgumentDefinition Argument { get; set; }

      /// <summary>
      /// Gets the help message of the command.
      /// </summary>
      /// <returns>The help message of the command.</returns>
      public String HelpMessage { get; set; }

      /// <summary>
      /// Gets the name of the definition.
      /// </summary>
      /// <returns>The name of the definition.</returns>
      public String Name { get; set; }

      /// <summary>
      /// Gets the type of definition.
      /// </summary>
      /// <returns><The type of definition./returns>
      public DefinitionType Type => DefinitionType.Command;
   }
}