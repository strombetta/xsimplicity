//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

namespace Trombetta.Cli.CommandLine
{
   public class Command : Option
   {
      public Command(String[] aliases, String helpText) : base(aliases, helpText)
      {}
   }
}