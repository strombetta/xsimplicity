//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using Trombetta.Cli.CommandLine.Definitions;

namespace Trombetta.Cli.CommandLine
{
   public interface IOptionResult : IParsable
   {
      Boolean AcceptMoreArguments { get; }
      Object Argument { get; set; }
      IOption Definition { get; }
      Boolean IsCompleted { get; }
      String Name { get; }
   }
}