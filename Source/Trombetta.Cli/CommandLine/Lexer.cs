//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   internal class Lexer
   {
      private readonly ParserConfiguration _configuration;
      public Lexer(ParserConfiguration configuration)
      {
         if(configuration == null) throw new ArgumentNullException(nameof(configuration));
         _configuration = configuration;
      }

      public IEnumerable<Token> Lex(IEnumerable<String> arguments)
      {
         if(arguments == null) throw new ArgumentNullException(nameof(arguments));

         var argumentDelimiters = _configuration.ArgumentDelimiters;
         return null;
      }
   }
}