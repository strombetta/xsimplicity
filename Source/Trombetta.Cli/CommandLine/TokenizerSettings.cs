//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents the settings used when tokenizing command line arguments.
   /// </summary>
   public class TokenizerSettings
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="TokenizerSettings"/> class.
      /// </summary>
      public TokenizerSettings()
         : this(new[] { "-", "--" },new[] { ':', '=' })
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="TokenizerSettings"/> class using the specified argument delimeters.
      /// </summary>
      /// <param name="argumentDelimiters">The argument delimiters.</param>
      /// <param name="optionPrefixes">The option prefixes.</param>
      /// <exception><see cref="ArgumentNullException"/></exception>
      public TokenizerSettings(IEnumerable<String> optionPrefixes, IEnumerable<Char> argumentDelimiters)
      {
         ArgumentDelimiters = argumentDelimiters ?? throw new ArgumentNullException(nameof(argumentDelimiters));
         OptionPrefixes = optionPrefixes ?? throw new ArgumentNullException(nameof(argumentDelimiters));
      }

      /// <summary>
      /// Gets the collection of argument delimiters.
      /// </summary>
      /// <returns>The collection of argument delimiters.</returns>
      public IEnumerable<Char> ArgumentDelimiters { get; }

      /// <summary>
      /// Gets the collection of option prefixes.
      /// </summary>
      /// <returns>The collection of option prefixes.</returns>
      public IEnumerable<String> OptionPrefixes { get; }
   }
}