//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a collection of options.
   /// </summary>
   /// <typeparam name="Option">The type of elements in the collection.</typeparam>
   public class OptionCollection : IReadOnlyCollection<Option>
   {
      private readonly HashSet<Option> options = new HashSet<Option>();

      /// <summary>
      /// Initializes a new instance of the <see cref="OptionCollection"/> class.
      /// </summary>
      protected OptionCollection()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="OptionCollection"/> class with the specified collection of options.
      /// </summary>
      /// <param name="options"></param>
      protected OptionCollection(IReadOnlyCollection<Option> options)
      {
         if (options == null) throw new ArgumentNullException(nameof(options));

         foreach (var option in options)
            Add(option);
      }

      public void Add(Option option)
      {
         options.Add(option);
      }

      public void AddRange(IEnumerable<Option> options)
      {
         if (options == null) throw new ArgumentNullException(nameof(options));

         foreach (var option in options)
            Add(option);
      }

      /// <summary>
      /// Gets the number of options contained in the collection.
      /// </summary
      /// <returns>The number of options in the collection.</returns>
      public Int32 Count => options.Count;

      public IEnumerator<Option> GetEnumerator()
      {
         return ((IReadOnlyCollection<Option>)options).GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return ((IReadOnlyCollection<Option>)options).GetEnumerator();
      }
   }
}