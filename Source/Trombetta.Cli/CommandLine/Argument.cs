//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an option argument.
   /// </summary>
   public class Argument
   {
      public Argument(String name, String description)
      {
         Description = description;
         Name = name;
      }

      public IEnumerable<String> AllowedValue { get; }

      public String DefaultValue { get; }

      /// <summary>
      /// Gets the description of the argument.
      /// </summary>
      /// <returns>The description of the argument.</returns>
      public String Description { get; }

      /// <summary>
      /// Gets the name of the argument.
      /// </summary>
      /// <returns>The name of the argument.</returns>
      public String Name { get; }


      public Boolean IsRequired { get; }
   }
}