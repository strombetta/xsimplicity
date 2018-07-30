//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine.Definitions;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line arguments parser.
   /// </summary>
   public sealed class Parser
   {
      /// <summary>
      /// The settings used to parse the command line arguments.
      /// </summary>
      private readonly ParserSettings _settings;

      /// <summary>
      /// The tokenizer used to tokenize the command line arguments.
      /// </summary>
      private readonly Tokenizer _tokenizer;

      /// <summary>
      /// The default <see cref="Parser"/> object.
      /// </summary>
      /// <typeparam name="Parser"></typeparam>
      /// <returns>The default <see cref="Parser"/> object.</returns>
      private static readonly Lazy<Parser> _default = new Lazy<Parser>(() => new Parser());

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class.
      /// </summary>
      public Parser()
        : this(new ParserSettings())
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the spefied collection of <see cref="FlagDefinition"/> objects.
      /// </summary>
      /// <param name="definitions"></param>
      public Parser(params IDefinition[] definitions)
        : this(new ParserSettings(definitions))
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the specified settings.
      /// </summary>
      /// <param name="settings">The settings used to parse the command line arguments.</param>
      public Parser(ParserSettings settings)
      {
         _settings = settings ?? throw new ArgumentNullException(nameof(settings));

         // Configuring the tokenizer.
         var tokenizerSettings = new TokenizerSettings(_settings.OptionPrefixes, _settings.ArgumentDelimiters);
         _tokenizer = new Tokenizer(tokenizerSettings);
      }

      public ParserResult Parse(String[] args)
      {
         if (args == null) throw new ArgumentNullException(nameof(args));

         throw new NotImplementedException();
      }

      /// <summary>
      /// Parses the command line arguments.
      /// </summary>
      /// <param name="definitions">A collection of command line arguments.</param>
      /// <param name="args"></param>
      /// <returns></returns>
      public ParserResult Parse(IEnumerable<IDefinition> definitions, String[] args)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentException(nameof(definitions));

         _settings.Definitions.AddRange(definitions);
         
         var result = new ParserResult();
         var tokens = new Queue<Token>(_tokenizer.Tokenize(args, definitions));
         while (tokens.Any())
         {
            var token = tokens.Dequeue();
            switch (token.Type)
            {
               case TokenType.Argument:
                  if (result.Options.Any() && !result.Options.Last().IsCompleted)
                  {
                     var option = result.Options.Last();
                     option.Argument = token.Value;
                     //result.Items.Add(option.Definition.MapToArgument(token.Value));
                  }
                  else {
                    // var definition = _settings.a
                    // result.Arguments.Add()
                    // arguments.Add(new Argument<String>(token.Value));
                  }
                  break;
               case TokenType.Option:
                  var definition = _settings.OptionDefinitions.Single(e => e.Aliases.Any(a => String.Compare(a, token.Value, true) == 0));
                  if (definition != null)
                  {
                     if (!result.Options.Any() || result.Options.Count(e => e.Name == token.Value) == 0)
                        result.Items.Add(definition.Map());
                     else continue;
                  }
                  break;

            }
         }
         return result;
      }

      private void Initializes(ParserResult result, IEnumerable<IDefinition> definition)
      {
         var def = 0;

      }

      /// <summary>
      /// Gets the default parser.
      /// </summary>
      /// <returns>The default parser.</returns>
      public static Parser Default
      {
         get { return _default.Value; }
      }

      /// <summary>
      /// Gets the settings used to parse the command line arguments.
      /// </summary>
      /// <returns>The settings used to parse the command line arguments.</returns>
      public ParserSettings Settings
      {
         get { return _settings; }
      }

      /// <summary>
      /// Gets the tokenizer used to tokenize the command line arguments.
      /// </summary>
      /// <returns>The tokenizer used to tokenize the command line arguments.</returns>
      internal Tokenizer Tokenizer
      {
         get { return _tokenizer; }
      }
   }
}