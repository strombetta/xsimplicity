//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an application option.
   /// </summary>
   public class Option
   {
      /// <summary>
      /// The collection of aliases.
      /// </summary>
      private readonly HashSet<String> _aliases = new HashSet<String>();
      private readonly Argument _argument;

      /// <summary>
      /// Initializes a new instance of the <see cref="Option"/> class with the specified collection of aliases, the text used as help
      /// </summary>
      /// <param name="aliases">A collection of aliases.</param>
      /// <param name="helpText">The text used as help.</param>
      public Option(String[] aliases, String helpText)
      {
         if (aliases == null) throw new ArgumentNullException(nameof(aliases));
         if (!aliases.Any()) throw new ArgumentNullException(nameof(aliases));
         if (aliases.Any(String.IsNullOrWhiteSpace)) throw new ArgumentException(nameof(aliases));

         foreach (var alias in aliases)
            _aliases.Add(alias);

         HelpText = helpText;
      }

      public Argument Argument { get; }

      public String HelpText { get; }

      /// <summary>
      /// Gets the name of the option.
      /// </summary>
      /// <returns>The name of the option.</returns>
      public String Name { get; }
   }
}