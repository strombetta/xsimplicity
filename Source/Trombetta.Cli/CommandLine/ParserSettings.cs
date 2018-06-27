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
   /// Represents the settings used to parsing command line arguments.
   /// </summary>
   public sealed class ParserSettings
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ParserSettings"/> class with the specified collection of options.
      /// </summary>
      /// <param name="options">The collection of options.</param>
      public ParserSettings(params Option[] options)
         : this(new OptionCollection(options), new[] { ':', '=' }, new[] { "-", "--" })
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserSettings"/> class withe the defined options.
      /// </summary>
      /// <param name="options">The defined options.</param>
      public ParserSettings(OptionCollection options)
         : this(options, new[] { ':', '=' }, new[] { "-", "--" })
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserSettings"/> class withe the defined options.
      /// </summary>
      /// <param name="options"></param>
      /// <param name="argumentDelimiters"></param>
      public ParserSettings(OptionCollection options, IEnumerable<Char> argumentDelimiters, ICollection<String> optionPrefixes)
      {
         if (options == null) throw new ArgumentNullException(nameof(options));

         ArgumentDelimiters = argumentDelimiters;
         OptionPrefixes = optionPrefixes;
         Options = options;
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
      /// Gets the collection of defined options.
      /// </summary>
      /// <returns>The collection of defined options.</returns>
      public OptionCollection Options { get; }
   }
}