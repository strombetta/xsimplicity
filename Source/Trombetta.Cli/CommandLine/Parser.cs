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
   public class Parser
   {
      /// <summary>
      /// The settings used to parse the command line arguments.
      /// </summary>
      private readonly ParserSettings _settings;

      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="Parser"></typeparam>
      /// <returns></returns>
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
      }

      public ParserResult Parse(String[] args)
      {
         var tokenizer = new Tokenizer();
         var tokens = tokenizer.Tokenize(args);

         return new ParserResult(tokens);
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

         var tokens = new Tokenizer(_settings).Tokenize(args);
         var t = new Queue<Token>(tokens);
         while(tokens.Any())
         {
            var token = t.Dequeue();
         }
         return new ParserResult(tokens);
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
   }
}