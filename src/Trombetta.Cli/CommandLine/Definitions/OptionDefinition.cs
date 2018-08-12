//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an option definition.
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class OptionDefinition<T> : IOptionDefinition
   {
      /// <summary>
      /// The collection of aliases.
      /// </summary>
      private readonly HashSet<String> _aliases = new HashSet<String>();

      /// <summary>
      /// Initializes a new instance of the <see creft="OptionDefinition{T}"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public OptionDefinition(String name, String helpMessage)
         : this(new[] { name }, helpMessage, false)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="OptionDefinition{T}"/> class with the
      /// specified collection of aliases, and the specified help message.
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public OptionDefinition(String[] aliases, String helpMessage)
         : this(aliases, helpMessage, false)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="OptionDefinition{T}"/> class with 
      /// the specified collection of aliases, the text used as help message.
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public OptionDefinition(String[] aliases, String helpMessage, Boolean isArgumentRequired)
      {
         if (aliases == null) throw new ArgumentNullException(nameof(aliases));
         if (!aliases.Any()) throw new ArgumentNullException(nameof(aliases));
         if (aliases.Any(String.IsNullOrWhiteSpace)) throw new ArgumentException(nameof(aliases));

         foreach (var alias in aliases)
            _aliases.Add(alias);

         HelpMessage = helpMessage;
         IsArgumentRequired = isArgumentRequired;
         Name = _aliases.OrderBy(a => a.Length).Last();
      }

      /// <summary>
      /// Creates an <see cref="Option"/> object based on the current definition.
      /// </summary>
      /// <returns>An <see cref="Option"/> object based on the current definition.</returns>
      public virtual IOption CreateOption()
      {
         return new Option<T>(this);
      }

      /// <summary>
      /// Gets the collection of aliases of the option.
      /// </summary>
      /// <returns>The collection of aliases of the option.</returns>
      public IEnumerable<String> Aliases { get { return _aliases; } }

      /// <summary>
      /// Gets or sets the 
      /// </summary>
      /// <value></value>
      public object Argument { get; set; }

      /// <summary>
      /// Gets the <see cref="System.Type" /> of the option argument.
      /// </summary>
      /// <value></value>
      public Type ArgumentType
      {
         get
         {
            if (typeof(IEnumerable).IsAssignableFrom(typeof(T)))
            {
               return typeof(T).GetGenericArguments()[0];
            }
            else return typeof(T);
         }
      }

      /// <summary>
      /// Gets the help message of the option.
      /// </summary>
      /// <returns>The help message of the option.</returns>
      public String HelpMessage { get; set; }

      /// <summary>
      /// Gets a value indicating whether the argument is required.
      /// </summary>
      /// <returns><c>true</c> if the argument is required; otherwise, <c>false</c>.</returns>¸
      public Boolean IsArgumentRequired { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether the option is required.
      /// </summary>
      /// <returns><c>true</c> if the option is required; otherwise, <c>false</c>.</returns>
      public bool IsRequired { get; set; }

      /// <summary>
      /// Gets the name of the definition.
      /// </summary>
      /// <returns>The name of the definition.</returns>
      public string Name { get; }

      /// <summary>
      /// Gets the type of definition.
      /// </summary>
      /// <returns><The type of definition./returns>
      public DefinitionType Type => DefinitionType.Option;
   }
}