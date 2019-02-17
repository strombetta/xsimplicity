//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// 
   /// </summary>
   public class OptionResult<T> : IOptionResult
   {
      /// <summary>
      /// The argument of the option.
      /// </summary>
      private T _argument;

      /// <summary>
      /// The definition.
      /// </summary>
      private IOption _definition;

      /// <summary>
      /// Initializes a new instance of the <see cref="Option"/> class with the specified
      /// <see cref="IOptionDefintion"/> object.
      /// </summary>
      /// <param name="definition">The definition</param>
      internal OptionResult(IOption definition)
      {
         _definition = definition ?? throw new ArgumentNullException(nameof(definition));
      }

      internal OptionResult(IOption definition, T value)
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

      Object IOptionResult.Argument
      {
         get { return _argument; }
         set { _argument = (T)value; }
      }

      public T Argument
      {
         get { return _argument; }
         internal set { _argument = value; }
      }

      public IOption Definition => _definition;

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
            if (!_definition.Argument.IsRequired || _argument != null) return true;
            else return false;
         }
      }

      /// <summary>
      /// Gets the type of argument.
      /// </summary>
      // public ParsedObjectType Type => ParsedObjectType.Option;
   }
}