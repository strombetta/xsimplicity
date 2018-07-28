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
   /// Represents a 
   /// </summary>
   public class ParserResult
   {
      private readonly IEnumerable<Option> _options;
      private readonly IEnumerable<Argument> _arguments;

      internal ParserResult(IEnumerable<Argument> arguments, IEnumerable<Option> options)
      {
         _arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
         _options = options ?? throw new ArgumentNullException(nameof(options));
      }

      public IEnumerable<Argument> Arguments
      {
         get { return _arguments; }
      }

      public IEnumerable<Option> Options
      {
         get { return _options; }
      }
   }
}