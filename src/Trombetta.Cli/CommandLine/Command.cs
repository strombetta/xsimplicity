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
   public class Command : ICommand
   {
      /// <summary>
      /// The definition.
      /// </summary>
      private CommandDefinition _definition;

      public Command(IDefinition definition)
      {
         _definition = (CommandDefinition)definition;
      }

      public IArgument Argument { get; set; }

      public String Name
      {
         get { return _definition.Name; }
      }
   }
}