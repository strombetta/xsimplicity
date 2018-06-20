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
   /// Represents the configuration used when parsing command line arguments.
   /// </summary>
   public class ParserConfiguration
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="ParserConfiguration"/> class with the specified collection of options.
      /// </summary>
      /// <param name="options">The collection of options.</param>
      public ParserConfiguration(params Option[] options)
         : this(options, new[] { ':', '=' }, new[] { "-", "--" })
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ParserConfiguration"/> class withe the defined options.
      /// </summary>
      /// <param name="options">The defined options.</param>
      public ParserConfiguration(IEnumerable<Option> options)
         : this(options, new[] { ':', '=' }, new[] { "-", "--" })
      { }

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
      /// 
      /// </summary>
      /// <returns></returns>
      public IEnumerable<Option> Options { get; }
   }
}