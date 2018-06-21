//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line argument parser.
   /// </summary>
   public class Parser
   {
      /// <summary>
      /// The settings used to parse the command line arguments.
      /// </summary>
      private readonly ParserSettings _settings;

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the spefied collection of <see cref="Option"/> objects.
      /// </summary>
      /// <param name="options"></param>
      public Parser(params Option[] options)
         : this(new ParserSettings(options))
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the specified settings.
      /// </summary>
      /// <param name="settings">The settings used to parse command line arguments.</param>
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
      /// Gets the settings used to parse the command line arguments.
      /// </summary>
      /// <returns>The settings used to parse the command line arguments.</returns>
      public ParserSettings Settings
      {
         get { return _settings; }
      }
   }
}