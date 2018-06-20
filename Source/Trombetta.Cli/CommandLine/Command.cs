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
   public class Command : Option
   {
      public Command(String name, String helpText)
         : base(new[] { name }, helpText, null)
      { }

      internal override Boolean IsCommand => true;
   }
}