//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line argument definition.
   /// </summary>
   public interface IDefinition
   {
      /// <summary>
      /// Gets the text used as help message of the argument.
      /// </summary>
      /// <returns>The text used as help message of the argument.</returns>
      String HelpMessage { get; }

      /// <summary>
      /// Gets the name of the argument.
      /// </summary>
      /// <returns>The name of the argument.</returns>
      String Name { get; }
   }
}