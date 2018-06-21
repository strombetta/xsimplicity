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
      /// <summary>
      /// The settings.
      /// </summary>
      private readonly TokenizerSettings _settings;

      /// <summary>
      /// Initializes a new instance of the <see cref="Tokenizer"/> class.
      /// </summary>
      public Tokenizer() : this(new TokenizerSettings())
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Tokenizer"/> class with the specified <see cref="ParseConfiguration"/> object.
      /// </summary>
      /// <param name="settings">The configuration used to tokenize.</param>
      public Tokenizer(TokenizerSettings settings)
      {
         if (settings == null) throw new ArgumentNullException(nameof(settings));
         _settings = settings;
      }

      /// <summary>
      /// Creates one or more <see cref="Token"/> objects depending on the specified argument.
      /// </summary>
      /// <param name="argument">The argument to tokenize.</param>
      /// <returns>A collection of tokens.</returns>
      private IEnumerable<Token> CreateToken(String argument)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         if (HasPrefix(argument))
         {
            if (HasDelimiter(argument))
            {
               var parts = argument.Split(_settings.ArgumentDelimiters.ToArray(), 2);
               yield return new Token(RemovePrefix(parts[0]), TokenType.Option);
               yield return new Token(parts[1], TokenType.Argument);
            }
            else yield return new Token(RemovePrefix(argument), TokenType.Option);
         }
         else
         {
            yield return new Token(argument, TokenType.Command);
         }
      }

      private Boolean HasPrefix(String argument)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         foreach (var prefix in _settings.OptionPrefixes.OrderByDescending(e => e.Length).ToArray())
         {
            if (argument.StartsWith(prefix)) return true;
         }
         return false;
      }

      private Boolean HasDelimiter(String argument)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         foreach (var delimiter in _settings.ArgumentDelimiters)
         {
            if (argument.Contains(delimiter)) return true;
         }
         return false;
      }

      private String RemovePrefix(String argument)
      {
         foreach (var delimiter in _settings.OptionPrefixes.OrderByDescending(p => p.Length).ToArray())
         {
            if (argument.StartsWith(delimiter.ToString())){
               return argument.Substring(delimiter.Length);
            }
         }
         return argument;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="arguments"></param>
      /// <returns></returns>
      public TokenCollection Tokenize(IEnumerable<String> arguments)
      {
         if (arguments == null) throw new ArgumentNullException(nameof(arguments));
         return new TokenCollection((from argument in arguments from token in CreateToken(argument) select token).ToList());
      }
   }
}