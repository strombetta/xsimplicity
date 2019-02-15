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
   public class CommandResult : ICommandResult
   {
      /// <summary>
      /// The definition.
      /// </summary>
      private Command _definition;

      public CommandResult(IDefinition definition)
      {
         _definition = (Command)definition;
      }

      public IArgumentResult Argument { get; set; }

      public String Name
      {
         get { return _definition.Name; }
      }
   }
}