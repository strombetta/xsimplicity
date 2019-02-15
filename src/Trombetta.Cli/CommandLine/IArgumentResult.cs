//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents a command line argument.
   /// </summary>
   public interface IArgumentResult : IParsable
   {
      Object Value { get; }
   }
}