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
      /// Initializes a new instance of the <see cref="CommandDefinition"/> class with the
      /// specified name, and the help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public CommandDefinition(String name, String helpMessage)
         : this(name, null, null, helpMessage)
      { }

      public CommandDefinition(String name, IEnumerable<IArgumentDefinition> argumentDefinitions, String helpMessage)
         : this(name, argumentDefinitions, null, helpMessage)
      { }

      public CommandDefinition(String name, IEnumerable<IOptionDefinition> optionDefinitions, String helpMessage)
         : this(name, null, optionDefinitions, helpMessage)
      { }

      public CommandDefinition(String name, IEnumerable<IArgumentDefinition> argumentDefinitions, IEnumerable<IOptionDefinition> optionDefinitions, String helpMessage)
      {
         if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

         ArgumentDefinitions = argumentDefinitions;
         HelpMessage = helpMessage;
         Name = name;
         OptionDefinitions = optionDefinitions;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public ICommand CreateCommand()
      {
         return new Command(this);
      }

      /// <summary>
      /// Gets the collection of argument definitions.
      /// </summary>
      /// <value>The collection of argument definitions.</value>
      public IEnumerable<IArgumentDefinition> ArgumentDefinitions { get; set; }

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
      /// Gets the collection of option definitions.
      /// </summary>
      /// <value>The collection of option definitions.</value>
      public IEnumerable<IOptionDefinition> OptionDefinitions { get; set; }
   }
}