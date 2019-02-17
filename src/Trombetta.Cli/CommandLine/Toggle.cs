//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;

namespace Trombetta.Cli.CommandLine
{
   /// <summary>
   /// Represents an application option definition that can be only true or false.
   /// </summary>
   public sealed class Toggle : Option<Boolean>
   {
      /// <summary>
      /// Initializes a new instance of the <see creft="Toggle"/> class with the specified name,
      /// and the help message.
      /// </summary>
      /// <param name="name">The name of the toggle.</param>
      /// <param name="helpMessage">The help message of the toggle.</param>
      public Toggle(String name, String helpMessage)
         : base(new[] { name }, false, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Toggle"/> class with the specified collection
      /// of aliases, and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="helpMessage">The help message of the toggle.</param>
      public Toggle(String[] aliases, String helpMessage)
         : this(aliases, false, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Toggle"/> class with the specified name, 
      /// the value indicating whether the toggle is required, and the help message.
      /// </summary>
      /// <param name="name">The name of the toggle.</param>
      /// <param name="isRequired">A value indicating whether the toggle is required.</param>
      /// <param name="helpMessage">The help message of the toggle.</param>
      public Toggle(String name, Boolean isRequired, String helpMessage)
         : base(name, new Argument<Boolean>("_value_", null, true, false, ""), isRequired, helpMessage)
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Toggle"/> class with the specified collection
      /// of aliases, the value indicating whether the toggle is required, and the help message.
      /// </summary>
      /// <param name="aliases">The collection of aliases.</param>
      /// <param name="isRequired">A value indicating whether the toggle is required.</param>
      /// <param name="helpMessage">The help message of the toggle.</param>
      public Toggle(String[] aliases, Boolean isRequired, String helpMessage)
         : base(aliases, new Argument<Boolean>("_value_", null, true, false, ""), isRequired, helpMessage)
      { }

      /// <summary>
      /// Creates an <see cref="Option"/> object based on the current definition.
      /// </summary>
      /// <returns>An <see cref="Option"/> object based on the current definition.</returns>
      public override IOptionResult CreateOption()
      {
         return new OptionResult<Boolean>(this, true);
      }
   }
}