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
   public class Option
   {
      /// <summary>
      /// The collection of parsed arguments.
      /// </summary>
      private IEnumerable<String> _arguments;
      private OptionDefinition _definition;

      internal Option(OptionDefinition definition)
      {
         _definition = definition ?? throw new ArgumentNullException(nameof(definition));
      }

      public IEnumerable<String> Arguments
      {
         get { return _arguments;}
         internal set { _arguments = value;}
      }

      public String Name
      {
         get { return _definition.Name; }
      }

      internal Boolean NeedArgument
      {
         get {return _definition.AcceptArgument; }
      }
   }
}