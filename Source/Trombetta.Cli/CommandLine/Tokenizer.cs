//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
[assembly: InternalsVisibleTo("Trombetta.Cli.Test")]

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line arguments tokenizer.
   /// </summary>
   internal class Tokenizer
   {
      private readonly ParserConfiguration _configuration;
      private static readonly Regex tokenizer = new Regex(@"(""(?<q>[^""]*)"")|(?<q>\S+)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

      /// <summary>
      /// Initializes a new instance of the <see cref="Tokenizer"/> class with the specified <see cref="ParseConfiguration"/> object.
      /// </summary>
      /// <param name="configuration">The configuration used to tokenize.</param>
      public Tokenizer(ParserConfiguration configuration)
      {
         if(configuration == null) throw new ArgumentNullException(nameof(configuration));
         _configuration = configuration;
      }

      private IEnumerable<Token> CreateToken(String argument)
      {
         if(String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         //var availableTokens = _configuration.Options.Select(o => new Token(o.Name, o.IsCommand ? TokenType.Command : TokenType.Option));
         if(HasPrefix(argument))
         {
            if (HasDelimiter(argument))
            {
               var parts = argument.Split(_configuration.ArgumentDelimiters.ToArray(), 2);
               yield return new Token(parts[0], TokenType.Option);
               yield return new Token(parts[1], TokenType.Argument);
            }
            else yield return new Token(argument, TokenType.Option);
         }
         else
         {
            yield return new Token(argument, TokenType.Command);
         }
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

      private String RemovePrefix(String argument)
      {
         return String.Empty;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="arguments"></param>
      /// <returns></returns>
      public IEnumerable<Token> Tokenize(IEnumerable<String> arguments){
         if(arguments == null) throw new ArgumentNullException(nameof(arguments));
         return (from argument in arguments from token in CreateToken(argument) select token).ToList();
      }
   }
}