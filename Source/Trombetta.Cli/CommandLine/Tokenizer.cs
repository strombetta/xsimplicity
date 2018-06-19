//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trombetta.Cli.CommandLine
{
   internal class Tokenizer
   {
      private readonly ParserConfiguration _configuration;
      private static readonly Regex tokenizer = new Regex(@"(""(?<q>[^""]*)"")|(?<q>\S+)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

      public Tokenizer(ParserConfiguration configuration)
      {
         if(configuration == null) throw new ArgumentNullException(nameof(configuration));
         _configuration = configuration;
      }

      private IEnumerable<Token> CreateToken(String argument)
      {
         var hasPrefix = HasPrefix(argument);
         return null;
      }

      private Boolean HasPrefix(String argument)
      {
         if(String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         foreach(var prefix in _configuration.OptionPrefixes.OrderBy(e => e.Length).ToArray())
         {
            if(argument.StartsWith(prefix)) return true;
         }
         return false;
      }

      private Boolean HasDelimiter(String argument)
      {
         if(String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         foreach(var delimiter in _configuration.ArgumentDelimiters)
         {
            if(argument.Contains(delimiter)) return true;
         }
         return false;
      }

      public IEnumerable<Token> Tokenize(IEnumerable<String> arguments){
         if(arguments == null) throw new ArgumentNullException(nameof(arguments));
         return (from argument in arguments from token in CreateToken(argument) select token).ToList();
      }
   }
}