//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
   public sealed class OptionAttribute : Attribute
   {
      public OptionAttribute(String name, String description)
      {
         if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

         Name = name;
         Description = description;
      }

      public IEnumerable<String> Aliases { get; set; }

      public String Description { get; }

      public Boolean IsRequired { get; set; }

      public String Name { get; }
   }
}