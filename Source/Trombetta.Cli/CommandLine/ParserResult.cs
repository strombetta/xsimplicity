//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a 
   /// </summary>
   public class ParserResult
   {
      private readonly IEnumerable<ParsedOption> _parsedOptions;

      internal ParserResult(IEnumerable<ParsedOption> parsedOptions)
      {
         _parsedOptions = parsedOptions ?? throw new ArgumentNullException(nameof(parsedOptions));
      }
   }
}