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
      private readonly ICollection<IParsable> _items = new List<IParsable>();

      /// <summary>
      /// Initializes a new instance of the <cref="ParserResult"/> class.
      /// </summary>
      internal ParserResult()
      { }

      internal ICollection<IParsable> Items => _items;

      /// <summary>
      /// Gets the collection of arguments.
      /// </summary>
      /// <value></value>
      public IEnumerable<IArgument> Arguments
      {
         get
         {
            return _items.Where(e => e is IArgument).Cast<IArgument>().ToList();
         }
      }

      /// <summary>
      /// Gets the collection of commands.
      /// </summary>
      /// <value></value>
      public IEnumerable<ICommand> Commands
      {
         get { throw new NotImplementedException(); }
      }

      /// <summary>
      /// Gets the collection of options.
      /// </summary>
      /// <value></value>
      public IEnumerable<IOption> Options
      {
         get
         {
            return _items.Where(e => e is IOption).Cast<IOption>().ToList();
         }
      }
   }
}