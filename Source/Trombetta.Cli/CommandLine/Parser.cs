//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;

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
      public Parser() : this(new ParserSettings())
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the spefied collection of <see cref="Option"/> objects.
      /// </summary>
      /// <param name="options"></param>
      public Parser(params Option[] options) : this(new ParserSettings(options))
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
      /// <param name="options">A collection of command line arguments.</param>
      /// <param name="args"></param>
      /// <returns></returns>
      public ParserResult Parse(IEnumerable<Option> options, String[] args)
      {
         if (options == null) throw new ArgumentNullException(nameof(options));
         if (!options.Any()) throw new ArgumentException(nameof(options));
         _settings.Options.AddRange(options);

         var parsedOptions = new List<ParsedOption>();

         var tokens = new Queue<Token>(_tokenizer.Tokenize(args, options));
         while (tokens.Any())
         {
            var token = tokens.Dequeue();
            if (token.Type != TokenType.Argument)
            {
               var option = _settings.Options.SingleOrDefault(o => o.HasAlias(token.Value));
               if (option != null)
               {
                  var parsedOption = parsedOptions.LastOrDefault(e => e.Option.HasAlias(token.Value));
                  if (parsedOption == null)
                     parsedOptions.Add(new ParsedOption(option, token));
                  continue;
               }
            }

         }
         return new ParserResult(parsedOptions);
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

      internal Tokenizer Tokenizer
      {
         get { return _tokenizer; }
      }
   }
}