//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

namespace Trombetta.Cli.CommandLine.Definitions
{
   /// <summary>
   /// Represents an argument definition.
   /// </summary>
   public interface IArgumentDefinition<out T> : IArgumentDefinition
   {
      new T DefaultValue { get; }
   }
}