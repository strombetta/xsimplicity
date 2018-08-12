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
   /// Represents an application option definition that can be only true or false.
   /// </summary>
   public sealed class ToggleDefinition : OptionDefinition<Boolean>
   {
      /// <summary>
      /// Initializes a new instance of the <see creft="ToggleDefinition"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public ToggleDefinition(String name, String helpMessage)
         : base(new[] { name }, helpMessage, false)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="ToggleDefinition"/> class with the
      /// specified collection of aliases, and the specified help message.
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public ToggleDefinition(String[] aliases, String helpMessage)
         : base(aliases, helpMessage, false)
      { }

      /// <summary>
      /// Creates an <see cref="Option"/> object based on the current definition.
      /// </summary>
      /// <returns>An <see cref="Option"/> object based on the current definition.</returns>
      public override IOption CreateOption()
      {
         return new Option<Boolean>(this, true);
      }
   }
}