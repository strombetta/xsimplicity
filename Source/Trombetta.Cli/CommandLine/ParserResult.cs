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

      internal ParserResult(IEnumerable<Option> parsedOptions)
      {
         _options = parsedOptions ?? throw new ArgumentNullException(nameof(parsedOptions));
      }

      public Dictionary<String, OptionDefinition> Options
      {
         get
         {
            return _options.Where(e => !e.OptionDefinition.IsCommand)
                  .Select(e => new KeyValuePair<String, OptionDefinition>(e.OptionDefinition.Name, e.OptionDefinition))
                  .ToDictionary(e => e.Key, e => e.Value);
         }
      }
   }
}