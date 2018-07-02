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
      private readonly IEnumerable<ParsedOption> _parsedOptions;

      internal ParserResult(IEnumerable<ParsedOption> parsedOptions)
      {
         _parsedOptions = parsedOptions ?? throw new ArgumentNullException(nameof(parsedOptions));
      }

      public Dictionary<String, Option> Options
      {
         get
         {
            return _parsedOptions.Where(e => !e.Option.IsCommand)
                  .Select(e => new KeyValuePair<String, Option>(e.Option.Name, e.Option))
                  .ToDictionary(e => e.Key, e => e.Value);
         }
      }
   }
}