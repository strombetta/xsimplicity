//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// 
   /// </summary>
   public class Parser
   {
      private readonly ParserConfiguration _configuration;

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the spefied collection of <see cref="Option"/> objects.
      /// </summary>
      /// <param name="options"></param>
      public Parser(params Option[] options)
         : this(new ParserConfiguration(options))
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class.
      /// </summary>
      /// <param name="configuration">The configuration used to parse command line.</param>
      public Parser(ParserConfiguration configuration)
      {
         _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
      }

      public ParserResult Parse(String[] args)
      {
         var tokenizer = new Tokenizer(_configuration);
         var tokens = tokenizer.Tokenize(args);

         return new ParserResult(tokens);
      }
   }
}