//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Trombetta.Cli.CommandLine.Definitions;

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
      private readonly TokenizerSettings _settings;

      /// <summary>
      /// Initializes a new instance of the <see cref="Tokenizer"/> class with the specified settings.
      /// </summary>
      /// <param name="settings">The settings used to tokenize the command line arguments.</param>
      public Tokenizer(TokenizerSettings settings)
      {
         _settings = settings ?? throw new ArgumentNullException(nameof(settings));
      }

      /// <summary>
      /// Creates one or more <see cref="Token"/> objects depending on the specified argument.
      /// </summary>
      /// <param name="argument">The argument to tokenize.</param>
      /// <returns>A collection of tokens.</returns>
      private IEnumerable<Token> CreateToken(String argument, IEnumerable<Token> definedTokens)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));
         if (definedTokens == null) throw new ArgumentNullException(nameof(definedTokens));
         if (!definedTokens.Any()) throw new ArgumentException(nameof(definedTokens));

         if (StartsWithPrefix(argument))
         {
            var normalizedArgument = RemovePrefix(argument);
            if (HasDelimiter(normalizedArgument))
            {
               var parts = normalizedArgument.Split(_settings.ArgumentDelimiters.ToArray(), 2);
               if (definedTokens.Any(t => t.Value == parts.First()))
               {
                  yield return new Token(parts[0], TokenType.Option);
                  if (parts.Length > 1) yield return new Token(parts[1], TokenType.Argument);
               }
               else
               {
                  yield return new Token(normalizedArgument, TokenType.Argument);
               }
            }
            else yield return new Token(normalizedArgument, TokenType.Option);
         }
         else
         {
            yield return new Token(argument, TokenType.Command);
         }
      }

      /// <summary>
      /// Determines whether the specified argument has an argument delimiter.
      /// </summary>
      /// <param name="argument">The argument to analyze.</param>
      /// <returns><c>true</c> whether the <param cref="argument"/> contains an argument delimiter; otherwise <c>false</c>.</returns>
      private Boolean HasDelimiter(String argument)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         foreach (var delimiter in _settings.ArgumentDelimiters)
         {
            if (argument.Contains(delimiter)) return true;
         }
         return false;
      }

      /// <summary>
      /// Removes the prefix from the specified argument.
      /// </summary>
      /// <param name="argument">The argument to remove prefix from .</param>
      /// <returns></returns>
      private String RemovePrefix(String argument)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

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
      /// Determines whether the specified argument starts with a prefix.
      /// </summary>
      /// <param name="argument">The argument.</param>
      /// <returns><c>true</c> if the <param cref="argument"/> starts with a prefix; otherwise <c>false</c>.</returns>
      private Boolean StartsWithPrefix(String argument)
      {
         if (String.IsNullOrWhiteSpace(argument)) throw new ArgumentNullException(nameof(argument));

         foreach (var prefix in _settings.OptionPrefixes.OrderByDescending(e => e.Length).ToArray())
         {
            if (argument.StartsWith(prefix)) return true;
         }
         return false;
      }

      private IEnumerable<Token> CreateTokens(IDefinition definition)
      {
         if (definition.Type == DefinitionType.Option)
            return definition.Aliases.Select(a => new Token(a, TokenType.Option));
         else if (definition.Type == DefinitionType.Command)
            return new List<Token>() { new Token(definition.Name, TokenType.Command) };
         else return new List<Token>() { new Token(definition.Name, TokenType.Argument) };
      }

      /// <summary>
      /// Tokenizes the command line arguments.
      /// </summary>
      /// <param name="arguments">The command line arguments to tokenize.</param>
      /// <returns></returns>
      public TokenCollection Tokenize(IEnumerable<String> arguments, IEnumerable<IDefinition> definitions)
      {
         if (arguments == null) throw new ArgumentNullException(nameof(arguments));
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));

         return new TokenCollection(
            (from argument in arguments
             from token in CreateToken(argument, definitions.SelectMany(e => CreateTokens(e)))
             select token).ToList()
         );
      }
   }
}