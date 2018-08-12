//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
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
      private T _argument;

      /// <summary>
      /// The definition.
      /// </summary>
      private IOptionDefinition _definition;

      /// <summary>
      /// Initializes a new instance of the <see cref="Option"/> class with the specified
      /// <see cref="OptionDefintion"/> object.
      /// </summary>
      /// <param name="definition"></param>
      internal Option(IOptionDefinition definition)
      {
         _definition = definition ?? throw new ArgumentNullException(nameof(definition));
      }

      internal Option(IOptionDefinition definition, T value)
      {
         _definition = definition ?? throw new ArgumentNullException(nameof(definition));
         _argument = value;
      }

      public Boolean AcceptMoreArguments
      {
         get
         {
            return typeof(T) != typeof(String) && typeof(IEnumerable).IsAssignableFrom(typeof(T));
         }
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

      /// <summary>
      /// Gets the type of argument.
      /// </summary>
      public ArgumentType Type => ArgumentType.Option;
   }
}