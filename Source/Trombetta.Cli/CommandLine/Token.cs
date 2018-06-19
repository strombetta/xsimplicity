//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

namespace Trombetta.Cli.CommandLine
{
   internal sealed class Token
   {
      public Token(String value, TokenType type)
      {
         Type = type;
         Value = value;
      }

      public TokenType Type { get; }
      public String Value { get; }
   }
}