//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   public class Option
   {
      private readonly HashSet<String> aliases = new HashSet<String>();
      public Option(String[] aliases, String helpText)
      { }

      public String HelpText { get; }
      public String Name { get; }
   }
}