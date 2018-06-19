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
   /// Represents the configuration used to parse command line arguments.
   /// </summary>
   public class ParserConfiguration
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ParserConfiguration"/> class withe the defined options.
      /// </summary>
      /// <param name="options">The defined options.</param>
      public ParserConfiguration(IReadOnlyCollection<Option> options)
         : this(options, new[] { ':', '=' }, new[] { "-", "--" })
      {
         if (options == null) throw new ArgumentNullException(nameof(options));
         Options = options;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserConfiguration"/> class withe the defined options.
      /// </summary>
      /// <param name="options"></param>
      /// <param name="argumentDelimiters"></param>
      public ParserConfiguration(IEnumerable<Option> options, IEnumerable<Char> argumentDelimiters, ICollection<String> optionPrefixes)
      {
         if (options == null) throw new ArgumentNullException(nameof(options));

         ArgumentDelimiters = argumentDelimiters;
         OptionPrefixes = optionPrefixes;
         Options = options;
      }

      public ICollection<String> OptionPrefixes { get; }
      public IEnumerable<Char> ArgumentDelimiters { get; }
      public IEnumerable<Option> Options { get; }
   }
}