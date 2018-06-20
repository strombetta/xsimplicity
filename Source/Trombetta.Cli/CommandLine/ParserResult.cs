//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   public class ParserResult
   {
      private readonly IEnumerable<Token> _tokens;
      
      public ParserResult(IEnumerable<Token> tokens)
      {
         if(tokens == null) throw new ArgumentNullException(nameof(tokens));
         _tokens = tokens;
      }

      public IEnumerable<Token> Tokens => _tokens;
   }
}