//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;

namespace Trombetta.Cli.CommandLine
{
   [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
   public sealed class ArgumentAttribute : Attribute
   {
      public ArgumentAttribute(String name, String description)
      {
         if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

         Name = name;
         Description = description;
      }

      public IEnumerable AllowedValues { get; set; }

      public Object DefaultValue { get; set; }

      public String Description { get; }

      public Boolean IsRequired { get; set; }

      public String Name { get; }
   }
}