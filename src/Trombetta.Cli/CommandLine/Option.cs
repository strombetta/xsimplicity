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
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the specified 
      /// name, and the help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String name, String helpMessage)
         : this(new[] { name }, false, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the
      /// specified collection of aliases, and the help message.
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String[] aliases, String helpMessage)
         : this(aliases, false, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the name, 
      /// the value indicating whether the option is required, and the help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="isRequired">The value indicating whether the option is required.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String name, Boolean isRequired, String helpMessage)
         : this(name, new Argument<T>("_value_", null, default(T), true, ""), isRequired, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the specified collection 
      /// of aliases, the value indicating whether the option is required, and the help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="isRequired">The value indicating whether the option is required.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String[] aliases, Boolean isRequired, String helpMessage)
         : this(aliases, new Argument<T>("_value_", null, default(T), true, ""), isRequired, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the specified name, the
      /// argument definition, the value indicating whether the option is required, and the help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="argument">The argument definition.</param>
      /// <param name="isRequired">The value indicating whether the option is required.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String name, IArgument<T> argument, Boolean isRequired, String helpMessage)
         : this(new[] { name }, argument, isRequired, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Option{T}"/> class with the specified collection
      /// of aliases, the argument definition, the value indicating whether the option is required, 
      /// and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="argument">The argument definition.</param>
      /// <param name="isRequired">The value indicating whether the option is required.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public Option(String[] aliases, IArgument<T> argument, Boolean isRequired, String helpMessage)
      {
         if (aliases == null) throw new ArgumentNullException(nameof(aliases));
         if (!aliases.Any()) throw new ArgumentNullException(nameof(aliases));
         if (aliases.Any(String.IsNullOrWhiteSpace)) throw new ArgumentException(nameof(aliases));
         if (argument == null) throw new ArgumentNullException(nameof(argument));

         foreach (var alias in aliases)
            _aliases.Add(alias);

         Argument = argument;
         HelpMessage = helpMessage;
         IsRequired = isRequired;
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
      public IArgument<T> Argument { get; }

      /// <summary>
      /// Gets the argument definition.
      /// </summary>
      /// <value>The argument definition.</value>
      IArgument IOption.Argument
      {
         get { return Argument; }
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