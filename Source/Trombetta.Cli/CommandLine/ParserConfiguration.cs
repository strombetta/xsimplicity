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
      /// <param name="options"></param>
      /// <param name="argumentDelimiters"></param>
      public ParserConfiguration(IReadOnlyCollection<Option> options, IReadOnlyCollection<Char> argumentDelimiters)
      {
         if(options == null) throw new ArgumentNullException(nameof(options));

         ArgumentDelimiters = argumentDelimiters ?? new[] { ':', '=' };
         Options = options;
      }

      public IReadOnlyCollection<Char> ArgumentDelimiters { get; }
      public IReadOnlyCollection<Option> Options { get; }
   }
}