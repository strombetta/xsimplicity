//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an option definition.
   /// </summary>
   /// <typeparam name="T">The type of the argument.</typeparam>
   public class Option<T> : IOption
   {
      /// <summary>
      /// The collection of aliases.
      /// </summary>
      private readonly HashSet<String> _aliases = new HashSet<String>();

      /// <summary>
      /// Initializes a new instance of the <see creft="OptionDefinition{T}"/> class with the
      /// specified name, and help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String name, String helpMessage)
         : this(new[] { name }, helpMessage, false)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the
      /// specified collection of aliases, and help message.
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String[] aliases, String helpMessage)
         : this(aliases, helpMessage, false)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with 
      /// the specified collection of aliases, the text used as help message.
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String[] aliases, String helpMessage, Boolean isArgumentRequired)
      {
         if (aliases == null) throw new ArgumentNullException(nameof(aliases));
         if (!aliases.Any()) throw new ArgumentNullException(nameof(aliases));
         if (aliases.Any(String.IsNullOrWhiteSpace)) throw new ArgumentException(nameof(aliases));

         foreach (var alias in aliases)
            _aliases.Add(alias);

         ArgumentDefinition = new Argument<T>("_value_", null, default(T), isArgumentRequired, "");
         HelpMessage = helpMessage;
         Name = _aliases.OrderBy(a => a.Length).Last();
      }

      /// <summary>
      /// Creates an <see cref="Option"/> object based on the current definition.
      /// </summary>
      /// <returns>An <see cref="Option"/> object based on the current definition.</returns>
      public virtual IOptionResult CreateOption()
      {
         return new OptionResult<T>(this);
      }

      /// <summary>
      /// Gets the collection of aliases of the option.
      /// </summary>
      /// <returns>The collection of aliases of the option.</returns>
      public IEnumerable<String> Aliases { get { return _aliases; } }

      /// <summary>
      /// Gets the argument definition.
      /// </summary>
      /// <value>The argument definition.</value>
      public IArgument<T> ArgumentDefinition { get; }

      /// <summary>
      /// Gets the argument definition.
      /// </summary>
      /// <value>The argument definition.</value>
      IArgument IOption.Argument
      {
         get { return ArgumentDefinition; }
      }

      /// <summary>
      /// Gets the help message of the option.
      /// </summary>
      /// <returns>The help message of the option.</returns>
      public String HelpMessage { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether the option is required.
      /// </summary>
      /// <returns><c>true</c> if the option is required; otherwise, <c>false</c>.</returns>
      public Boolean IsRequired { get; set; }

      /// <summary>
      /// Gets the name of the option.
      /// </summary>
      /// <returns>The name of the option.</returns>
      public String Name { get; }
   }
}