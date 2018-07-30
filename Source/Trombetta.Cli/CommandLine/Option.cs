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
   /// 
   /// </summary>
   public class Option<T> : IArgument, IOption
   {
      /// <summary>
      /// The collection of parsed arguments.
      /// </summary>
      private T _argument;
      private OptionDefinition<T> _definition;

      internal Option(OptionDefinition<T> definition)
      {
         _definition = definition ?? throw new ArgumentNullException(nameof(definition));
      }

      Object IOption.Argument
      {
         get { return _argument; }
         set { _argument = (T)value; }
      }

      public T Argument
      {
         get { return _argument; }
         internal set { _argument = value; }
      }

      public IOptionDefinition Definition => _definition;
      public String Name
      {
         get { return _definition.Name; }
      }

      public Boolean IsCompleted
      {
         get
         {
            if (!_definition.IsArgumentRequired || _argument != null) return true;
            else return false;
         }
      }

      public ArgumentType Type => ArgumentType.Option;
   }
}