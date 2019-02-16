//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an option definition.
   /// </summary>
   public interface IOption<T> : IOption
   {
      /// <summary>
      /// Gets the argument definition.
      /// </summary>
      /// <value>The argument definition.</value>
      new IArgument<T> ArgumentDefinition { get; }
   }
}