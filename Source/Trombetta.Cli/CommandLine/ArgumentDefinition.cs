//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections.Generic;

namespace Trombetta.Cli.CommandLine
{
  /// <summary>
  /// Represents an option argument definition.
  /// </summary>
  public class ArgumentDefinition
  {
    private readonly Func<OptionDefinition, String> _validate;

    public ArgumentDefinition(Func<OptionDefinition, String> validate)
    {
      _validate = validate ?? throw new ArgumentNullException(nameof(validate));
    }

    public ArgumentDefinition(String name, String description, Func<OptionDefinition, String> validate)
    {
      Description = description;
      Name = name;
      _validate = validate ?? throw new ArgumentNullException(nameof(validate));
    }

    public static ArgumentDefinition NoArgument()
    {
      return null;
    }

    public IEnumerable<String> AllowedValue { get; }

    /// <summary>
    /// Gets the default value of the argument.
    /// </summary>
    /// <returns>The default value of the argument.</returns>
    public String DefaultValue { get; }

    /// <summary>
    /// Gets the description of the argument.
    /// </summary>
    /// <returns>The description of the argument.</returns>
    public String Description { get; }

    /// <summary>
    /// Gets a value indicating whether the argument is required.
    /// </summary>
    /// <returns><c>true</c> if argument is required; otherwise <c>false</c>.</returns>
    public Boolean IsRequired { get; }

    /// <summary>
    /// Gets the name of the argument.
    /// </summary>
    /// <returns>The name of the argument.</returns>
    public String Name { get; }
  }
}