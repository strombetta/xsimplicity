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
      /// The settings used to tokenize the command line arguments.
      /// </summary>
      private readonly ParserSettings _settings;

      private HashSet<Token> _validTokens;

      /// <summary>
      /// Initializes a new instance of the <see cref="Tokenizer"/> class.
      /// </summary>
      public Tokenizer() : this(new ParserSettings())
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Tokenizer"/> class with the specified <see cref="ParseConfiguration"/> object.
      /// </summary>
      /// <param name="settings">The configuration used to tokenize.</param>
      public Tokenizer(ParserSettings settings)
      {
         _settings = settings ?? throw new ArgumentNullException(nameof(settings));
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
               if (ValidTokens.Any(t => t.Value == parts.First()))
               {
                  yield return new Token(RemovePrefix(parts[0]), TokenType.Option);
                  if (parts.Length > 1) yield return new Token(parts[1], TokenType.Argument);
               }
               else {
                  yield return new Token(argument, TokenType.Argument);
               }
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
            if (argument.StartsWith(delimiter.ToString()))
            {
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
         var tokens = (from argument in arguments from token in CreateToken(argument) select token).ToList();
         return new TokenCollection(tokens);
      }

      private HashSet<Token> ValidTokens
      {
         get
         {
            if (_validTokens == null)
            {
               _validTokens = new HashSet<Token>(_settings.Options.SelectMany(o => o.ValidTokens));
            }
            return _validTokens;
         }
      }
   }
}