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
   /// Represents a collection of tokens.
   /// </summary>
   /// <typeparam name="Toekn">The type of elements in the collection.</typeparam>
   internal class TokenCollection : ICollection<Token>
   {
      private readonly ICollection<Token> _tokens = new List<Token>();

      

      public bool IsReadOnly => throw new NotImplementedException();

      public TokenCollection(IEnumerable<Token> tokens)
      {
         foreach (var token in tokens)
            Add(token);
      }

      public void Add(Token token)
      {
         if (token == null) throw new ArgumentNullException(nameof(token));
         _tokens.Add(token);
      }

      public void Clear()
      {
         _tokens.Clear();
      }

      public bool Contains(Token item)
      {
         return _tokens.Contains(item);
      }

      public void CopyTo(Token[] array, int arrayIndex)
      {
         _tokens.CopyTo(array, arrayIndex);
      }

      public bool Remove(Token item)
      {
         return _tokens.Remove(item);
      }

      public IEnumerator<Token> GetEnumerator()
      {
         return _tokens.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return _tokens.GetEnumerator();
      }

      public int Count => _tokens.Count;

      public Token this[String token]
      {
         get
         {
            return _tokens.SingleOrDefault(t => t.Value == token);
         }
      }
   }
}