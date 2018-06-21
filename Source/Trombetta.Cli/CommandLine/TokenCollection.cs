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
   public class TokenCollection : IReadOnlyCollection<Token>
   {
      private readonly ICollection<Token> _tokens = new List<Token>();

      public TokenCollection()
      { }

      public TokenCollection(IEnumerable<Token> tokens)
      {
         foreach (var token in tokens)
            _tokens.Add(token);
      }

      public void Add(Token token)
      {
         if (token == null) throw new ArgumentNullException(nameof(token));
         _tokens.Add(token);
      }

      public Token this[String token]
      {
         get
         {
            return _tokens.SingleOrDefault(t => t.Value == token);
         }
      }

      public Int32 Count => _tokens.Count;

      public IEnumerator<Token> GetEnumerator()
      {
         return ((IReadOnlyCollection<Token>)_tokens).GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return ((IReadOnlyCollection<Token>)_tokens).GetEnumerator();
      }
   }
}