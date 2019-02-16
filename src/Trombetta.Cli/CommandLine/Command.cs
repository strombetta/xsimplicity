//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line command definition.
   /// </summary>
   public class Command : ICommand
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the
      /// specified name, and the help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String name, String helpMessage)
         : this(name, null, null, helpMessage)
      { }

      public Command(String name, IEnumerable<IArgument> argumentDefinitions, String helpMessage)
         : this(name, argumentDefinitions, null, helpMessage)
      { }

      public Command(String name, IEnumerable<IOption> optionDefinitions, String helpMessage)
         : this(name, null, optionDefinitions, helpMessage)
      { }

      public Command(String name, IEnumerable<IArgument> argumentDefinitions, IEnumerable<IOption> optionDefinitions, String helpMessage)
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
      public ICommandResult CreateCommand()
      {
         return new CommandResult(this);
      }

      /// <summary>
      /// Gets or sets the collection of argument definitions.
      /// </summary>
      /// <value>The collection of argument definitions.</value>
      public IEnumerable<IArgument> ArgumentDefinitions { get; set; }

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
      public IEnumerable<IOption> OptionDefinitions { get; set; }
   }
}