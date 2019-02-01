//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using Trombetta.Cli.CommandLine.Definitions;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// 
   /// </summary>
   public class Argument<T> : IArgument
   {
      internal Argument(T value)
      {
         Value = value;
      }

      public IDefinition Definition => null;

      public Boolean IsCompleted => true;

      // public ParsedObjectType Type => ParsedObjectType.Argument;

      public T Value { get; }

      object IArgument.Value => throw new NotImplementedException();
   }
}