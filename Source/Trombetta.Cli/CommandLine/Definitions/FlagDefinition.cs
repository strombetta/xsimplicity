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
   /// Represents an application option definition.
   /// </summary>
   public class FlagDefinition : OptionDefinition<Boolean>
   {
      /// <summary>
      /// Initializes a new instance of the <see creft="Option"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the option.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public FlagDefinition(String name, String helpMessage)
         : base(name, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="FlagDefinition"/> class with the specified collection of aliases, the text used as help
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpMessage">The help message of the option.</param>
      public FlagDefinition(String[] aliases, String helpMessage)
         : base(aliases, helpMessage)
      { }

      public Boolean IsArgumentRequired => false;
   }
}