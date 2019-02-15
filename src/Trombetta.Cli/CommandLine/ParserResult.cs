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
      public IEnumerable<IArgumentResult> Arguments
      {
         get
         {
            return _items.Where(e => e is IArgumentResult).Cast<IArgumentResult>().ToList();
         }
      }

      /// <summary>
      /// Gets the command.
      /// </summary>
      /// <value></value>
      public ICommandResult Command
      {
         get { return _items.Where(e => e is ICommandResult).Cast<ICommandResult>().SingleOrDefault(); }
      }

      /// <summary>
      /// Gets the collection of options.
      /// </summary>
      /// <value></value>
      public IEnumerable<IOptionResult> Options
      {
         get
         {
            return _items.Where(e => e is IOptionResult).Cast<IOptionResult>().ToList();
         }
      }
   }
}