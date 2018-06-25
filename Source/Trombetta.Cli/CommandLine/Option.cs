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
   /// Represents an application option.
   /// </summary>
   public class Option
   {
      /// <summary>
      /// The collection of aliases.
      /// </summary>
      private readonly HashSet<String> _aliases = new HashSet<String>();

      /// <summary>
      /// Initializes a new instance of the <see creft="Option"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String name, String helpMessage)
      : this(new[] { name }, helpMessage, null)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option"/> class with the specified collection of aliases, the text used as help
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String[] aliases, String helpMessage, Argument argument = null)
      {
         if (aliases == null) throw new ArgumentNullException(nameof(aliases));
         if (!aliases.Any()) throw new ArgumentNullException(nameof(aliases));
         if (aliases.Any(String.IsNullOrWhiteSpace)) throw new ArgumentException(nameof(aliases));

         foreach (var alias in aliases)
            _aliases.Add(alias);

         Argument = argument;
         Name = _aliases.OrderBy(a => a.Length).Last();
         HelpMessage = helpMessage;
      }

      /// <summary>
      /// Gets the collection of aliases of the option.
      /// </summary>
      /// <returns>The collection of aliases of the option.</returns>
      public IEnumerable<String> Aliases => _aliases.ToArray();

      public Argument Argument { get; }

      /// <summary>
      /// Gets a value indicating whether the option contains the specified alias.
      /// </summary>
      /// <param name="alias">The alias to search.</param>
      /// <returns></returns>
      public Boolean HasAlias(String alias)
      {
         return _aliases.Any(e => e == alias);
      }

      /// <summary>
      /// Gets the help message of the option.
      /// </summary>
      /// <returns>The help message of the option.</returns>
      public String HelpMessage { get; }

      /// <summary>
      /// Gets a value indicating whether the option is a command.
      /// </summary>
      /// <returns><c>true</c> if the option is a command; otherwise, <c>false</c>.</returns>
      internal virtual Boolean IsCommand => false;

      /// <summary>
      /// Gets the name of the option.
      /// </summary>
      /// <returns>The name of the option.</returns>
      public String Name { get; }


      internal HashSet<Token> ValidTokens
      {
         get
         {
            return new HashSet<Token>(_aliases.Select(a => new Token(a, IsCommand ? TokenType.Command : TokenType.Option)));
         }
      }
   }
}