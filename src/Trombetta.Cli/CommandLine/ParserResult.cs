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
      private readonly IEnumerable<IArgument> _options;
      private readonly IEnumerable<IArgument> _arguments;

      private readonly ICollection<IArgument> _items = new List<IArgument>();

      internal ParserResult()
      { }

      internal ParserResult(IEnumerable<IArgument> arguments, IEnumerable<IArgument> options)
      {
         _arguments = arguments ?? throw new ArgumentNullException(nameof(arguments));
         _options = options ?? throw new ArgumentNullException(nameof(options));
      }

      internal ICollection<IArgument> Items => _items;

      public IEnumerable<IArgument> Arguments
      {
         get
         {
            return _items.Where(e => e.Type == ArgumentType.Argument).Cast<IArgument>().ToList();
         }
      }

      public IEnumerable<IOption> Options
      {
         get
         {
            return _items.Where(e => e.Type == ArgumentType.Option)
                        .Cast<IOption>()
                        .ToList();
         }
      }
   }
}