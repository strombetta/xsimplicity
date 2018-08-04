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
      /// The argument of the option.
      /// </summary>
      private Argument<T> _argument;

      /// <summary>
      /// The definition.
      /// </summary>
      private OptionDefinition<T> _definition;

      internal Option(OptionDefinition<T> definition)
      {
         _definition = definition ?? throw new ArgumentNullException(nameof(definition));
      }

      IArgument IOption.Argument
      {
         get { return _argument; }
         set { _argument = (Argument<T>)value; }
      }

      public Argument<T> Argument
      {
         get { return _argument; }
         internal set { _argument = value; }
      }

      public IOptionDefinition Definition => _definition;

      /// <summary>
      /// Gets the name of the command line option.
      /// </summary>
      /// <value></value>
      public String Name
      {
         get { return _definition.Name; }
      }

      /// <summary>
      /// Gets a value indicating whether the option is completed.
      /// </summary>
      /// <value></value>
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