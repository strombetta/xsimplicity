//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an application command.
   /// </summary>
   public class CommandDefinition : OptionDefinition
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CommandDefinition"/> class with the
      /// specified name, and the specified help message.
      /// </summary>
      /// <param name="name">The name of the command.</param>
      /// <param name="helpMessage">The help message of the command.</param>
      public CommandDefinition(String name, String helpMessage)
         : base(name, helpMessage)
      { }

      /// <summary>
      /// Gets a value indicating whether the option is a command.
      /// </summary>
      /// <returns><c>true</c> if the option is a command; otherwise, <c>false</c>.</returns>
      internal override Boolean IsCommand => true;
   }
}