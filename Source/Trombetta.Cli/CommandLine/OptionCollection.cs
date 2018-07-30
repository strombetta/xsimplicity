//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine.Definitions;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a collection of definition.
   /// </summary>
   /// <typeparam name="Option">The type of elements in the collection.</typeparam>
   public class DefinitionCollection : IReadOnlyCollection<IDefinition>
   {
      private readonly HashSet<IDefinition> _definitions = new HashSet<IDefinition>();

      /// <summary>
      /// Initializes a new instance of the <see cref="DefinitionCollection"/> class.
      /// </summary>
      protected DefinitionCollection()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="DefinitionCollection"/> class with the specified collection of options.
      /// </summary>
      /// <param name="definitions"></param>
      public DefinitionCollection(IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));

         foreach (var definition in definitions)
            Add(definition);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="definitions"></param>
      public DefinitionCollection(params IDefinition[] definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         foreach (var option in definitions)
            Add(option);
      }

      public void Add(IDefinition option)
      {
         _definitions.Add(option);
      }

      public void AddRange(IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));

         foreach (var option in definitions)
            Add(option);
      }

      /// <summary>
      /// Gets a value indicating whether the collection contains the specified option.
      /// </summary>
      /// <param name="name"></param>
      /// <returns></returns>
      public Boolean Contains(String name)
      {
         return _definitions.SelectMany(e => e.Aliases).Any(o => o == name);
      }

      /// <summary>
      /// Gets the number of options contained in the collection.
      /// </summary
      /// <returns>The number of options in the collection.</returns>
      public Int32 Count => _definitions.Count;

      public IEnumerator<IDefinition> GetEnumerator()
      {
         return ((IReadOnlyCollection<IDefinition>)_definitions).GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return ((IReadOnlyCollection<IDefinition>)_definitions).GetEnumerator();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public IDefinition this[String value]
      {
         get
         {
            var result = from helper in _definitions
            .SelectMany(o => o.Aliases, (option, aliases) => new { option, aliases })
                         where helper.aliases.Contains(value)
                         select helper.option;
            return result.SingleOrDefault();
         }
      }
   }
}