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
   internal class ParsedOption
   {
      /// <summary>
      /// The collection of parsed arguments.
      /// </summary>
      private readonly ICollection<String> _arguments;

      /// <summary>
      /// The option associated to the parsed option.
      /// </summary>
      private readonly Option _option;

      /// <summary>
      /// The token associated to the parsed option.
      /// </summary>
      private readonly Token _token;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="option"></param>
      /// <param name="token"></param>
      public ParsedOption(Option option, Token token)
      {
         _arguments = new List<String>();
         _option = option ?? throw new ArgumentNullException(nameof(option));
         _token = token ?? throw new ArgumentNullException(nameof(token));
      }

      public ICollection<String> Arguments
      {
         get { return _arguments; }
      }

      public Object Validate()
      {
         return null;
      }

      public Option Option
      {
         get { return _option; }
      }

      public Token Token
      {
         get { return _token; }
      }
   }
}