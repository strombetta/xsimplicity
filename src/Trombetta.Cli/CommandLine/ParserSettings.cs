//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine.Definitions;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents the settings used to parsing command line arguments.
   /// </summary>
   public sealed class ParserSettings
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ParserSettings"/> class with the specified collection of options.
      /// </summary>
      /// <param name="definitions">The collection of options.</param>
      public ParserSettings(params IDefinition[] definitions)
         : this(definitions, new[] { ':', '=' }, ',', new[] { "-", "--" })
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserSettings"/> class withe the defined options.
      /// </summary>
      /// <param name="definitions">The defined options.</param>
      public ParserSettings(IEnumerable<IDefinition> definitions)
         : this(definitions, new[] { ':', '=' }, ',', new[] { "-", "--" })
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserSettings"/> class withe the defined options.
      /// </summary>
      /// <param name="definitions"></param>
      /// <param name="argumentDelimiters"></param>
      public ParserSettings(IEnumerable<IDefinition> definitions, IEnumerable<Char> argumentDelimiters, Char argumentSeparator, ICollection<String> optionPrefixes)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));

         ArgumentDelimiters = argumentDelimiters;
         ArgumentSeparator = argumentSeparator;
         OptionPrefixes = optionPrefixes;
         Definitions = new List<IDefinition>(definitions);
      }

      /// <summary>
      /// Gets the collection of option prefixes.
      /// </summary>
      /// <returns>The collection of option prefixes.</returns>
      public ICollection<String> OptionPrefixes { get; }

      /// <summary>
      /// Gets the collection of argument delimiters.
      /// </summary>
      /// <returns>The collection of argument delimiters.</returns>
      public IEnumerable<Char> ArgumentDelimiters { get; }

      /// <summary>
      /// Gets the character used as argument separator.
      /// </summary>
      /// <value>The character used as argument separator.</value>
      public Char ArgumentSeparator { get; }

      /// <summary>
      /// Gets the collection of defined options.
      /// </summary>
      /// <returns>The collection of defined options.</returns>
      public ICollection<IDefinition> Definitions { get; }

      public IEnumerable<IOption> OptionDefinitions
      {
         get
         {
            return Definitions.Where(e => e is IOption).Cast<IOption>().ToList();
         }
      }
   }
}