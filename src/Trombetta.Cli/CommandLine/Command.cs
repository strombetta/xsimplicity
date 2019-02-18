//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line command definition.
   /// </summary>
   public class Command : ICommand
   {
      private readonly HashSet<String> _aliases = new HashSet<String>();

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified name,
      /// and the help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String name, String helpMessage)
         : this(name, null, null, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified collection
      /// of aliases, and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String[] aliases, String helpMessage)
         : this(aliases, null, null, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified name,
      /// the collection of arguments, and the help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="arguments">The collection of arguments.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String name, IEnumerable<IArgument> arguments, String helpMessage)
         : this(name, arguments, null, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified collection
      /// of aliases, the collection of arguments, and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="arguments">The collection of arguments.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String[] aliases, IEnumerable<IArgument> arguments, String helpMessage)
         : this(aliases, arguments, null, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified name,
      /// the collection of options, and the help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="options">The collection of options.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String name, IEnumerable<IOption> options, String helpMessage)
         : this(name, null, options, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified collection
      /// of aliases, the collection of options, and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="options">The collection of options.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String[] aliases, IEnumerable<IOption> options, String helpMessage)
         : this(aliases, null, options, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified name,
      /// the collection of arguments, the collection of options, and the help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="arguments">The collection of arguments.</param>
      /// <param name="options">The collection of options.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String name, IEnumerable<IArgument> arguments, IEnumerable<IOption> options, String helpMessage)
         : this(new[] { name }, arguments, options, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Command"/> class with the specified collection
      /// of aliases, the collection of arguments, the collection of options, and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="arguments">The collection of arguments.</param>
      /// <param name="options">The collection of options.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public Command(String[] aliases, IEnumerable<IArgument> arguments, IEnumerable<IOption> options, String helpMessage)
      {
         if (aliases == null) throw new ArgumentNullException(nameof(aliases));
         if (!aliases.Any()) throw new ArgumentNullException(nameof(aliases));
         if (aliases.Any(String.IsNullOrWhiteSpace)) throw new ArgumentException(nameof(aliases));

         foreach (var alias in aliases)
            _aliases.Add(alias);

         Arguments = arguments;
         HelpMessage = helpMessage;
         Options = options;
         Name = _aliases.OrderBy(a => a.Length).Last();
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
      /// Gets the collection of aliases of the command.
      /// </summary>
      /// <returns>The collection of aliases of the command.</returns>
      public IEnumerable<String> Aliases { get { return _aliases; } }

      /// <summary>
      /// Gets or sets the collection of argument definitions.
      /// </summary>
      /// <value>The collection of argument definitions.</value>
      public IEnumerable<IArgument> Arguments { get; set; }

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
      public IEnumerable<IOption> Options { get; set; }
   }
}