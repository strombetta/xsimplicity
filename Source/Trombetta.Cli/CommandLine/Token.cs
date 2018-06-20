//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Reprensents a token.
   /// </summary>
   public sealed class Token
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="Token"/> class with the specified value, and <see cref="TokenType"/> type.
      /// </summary>
      /// <param name="value">The value of the token.</param>
      /// <param name="type">The type of the token.</param>
      public Token(String value, TokenType type)
      {
         Type = type;
         Value = value;
      }

      /// <summary>
      /// Gets the type of the token.
      /// </summary>
      /// <returns>The type of the token.</returns>
      public TokenType Type { get; }

      /// <summary>
      /// Gets the value of the token.
      /// </summary>
      /// <returns>The value of the token.</returns>
      public String Value { get; }
   }
}