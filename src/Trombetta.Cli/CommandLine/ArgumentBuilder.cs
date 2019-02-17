//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   public static class ArgumentBuilder
   {
      public static Argument<T> FromAttribute<T>(ArgumentAttribute attribute)
      {
         return new Argument<T>(attribute.Name, (IEnumerable<T>)attribute.AllowedValues,
                                 (T)attribute.DefaultValue, attribute.IsRequired, attribute.Description);
      }
   }
}