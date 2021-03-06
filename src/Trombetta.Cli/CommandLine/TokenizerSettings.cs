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
   /// Defines the settings for a Tokenizer.
   /// </summary>
   class TokenizerSettings
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="TokenizerSettings"/> class
      /// with the specified collection of option prefixes, and the specified collection of
      /// argument delimiters.
      /// </summary>
      /// <param name="optionPrefixes">The collection of option prefixes.</param>
      /// <param name="argumentDelimiters">The collection of argument delimiters.</param>
      public TokenizerSettings(IEnumerable<String> optionPrefixes, IEnumerable<Char> argumentDelimiters, Char argumentSeparator)
      {
         if (optionPrefixes == null) throw new ArgumentNullException(nameof(optionPrefixes));
         if (!optionPrefixes.Any()) throw new ArgumentException(nameof(optionPrefixes));
         if (argumentDelimiters == null) throw new ArgumentNullException(nameof(argumentDelimiters));
         if (!argumentDelimiters.Any()) throw new ArgumentException(nameof(argumentDelimiters));

         ArgumentDelimiters = argumentDelimiters;
         ArgumentSeparator = argumentSeparator;
         OptionPrefixes = optionPrefixes;
      }      

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
      /// Gets the collection of option prefixes.
      /// </summary>
      /// <returns>The collection of option prefixes.</returns>
      public IEnumerable<String> OptionPrefixes { get; }
   }
}
