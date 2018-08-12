//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine.Definitions;

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an application option definition accept only a value in a set.
   /// </summary>
   public sealed class SwitchDefinition<T> : OptionDefinition<T>
   {
      /// <summary>
      /// Initializes a new instance of the <see creft="SwitchDefinition"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public SwitchDefinition(String name, String helpMessage)
         : base(new[] { name }, helpMessage, true)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="SwitchDefinition"/> class with the 
      /// specified collection of aliases, the text used as help
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public SwitchDefinition(String[] aliases, String helpMessage)
         : base(aliases, helpMessage, true)
      { }
   }
}