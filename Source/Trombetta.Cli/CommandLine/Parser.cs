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
  /// Represents a command line arguments parser.
  /// </summary>
  public sealed class Parser
  {
    /// <summary>
    /// The settings used to parse the command line arguments.
    /// </summary>
    private readonly ParserSettings _settings;

    /// <summary>
    /// The tokenizer used to tokenize the command line arguments.
    /// </summary>
    private readonly Tokenizer _tokenizer;

    /// <summary>
    /// The default <see cref="Parser"/> object.
    /// </summary>
    /// <typeparam name="Parser"></typeparam>
    /// <returns>The default <see cref="Parser"/> object.</returns>
    private static readonly Lazy<Parser> _default = new Lazy<Parser>(() => new Parser());

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class.
    /// </summary>
    public Parser() : this(new ParserSettings())
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class with the spefied collection of <see cref="OptionDefinition"/> objects.
    /// </summary>
    /// <param name="options"></param>
    public Parser(params OptionDefinition[] options) : this(new ParserSettings(options))
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class with the specified settings.
    /// </summary>
    /// <param name="settings">The settings used to parse the command line arguments.</param>
    public Parser(ParserSettings settings)
    {
      _settings = settings ?? throw new ArgumentNullException(nameof(settings));

      // Configuring the tokenizer.
      var tokenizerSettings = new TokenizerSettings(_settings.OptionPrefixes, _settings.ArgumentDelimiters);
      _tokenizer = new Tokenizer(tokenizerSettings);
    }



    public ParserResult Parse(String[] args)
    {
      if (args == null) throw new ArgumentNullException(nameof(args));

      throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the command line arguments.
    /// </summary>
    /// <param name="definitions">A collection of command line arguments.</param>
    /// <param name="args"></param>
    /// <returns></returns>
    public ParserResult Parse(IEnumerable<OptionDefinition> definitions, String[] args)
    {
      if (definitions == null) throw new ArgumentNullException(nameof(definitions));
      if (!definitions.Any()) throw new ArgumentException(nameof(definitions));
      _settings.Definitions.AddRange(definitions);

      var options = new List<Option>();

      var tokens = new Queue<Token>(_tokenizer.Tokenize(args, definitions));
      while (tokens.Any())
      {
        var token = tokens.Dequeue();
        if (token.Type != TokenType.Argument)
        {
          var definition = _settings.Definitions.SingleOrDefault(o => o.HasAlias(token.Value));
          if (definition != null)
          {
            var option = options.LastOrDefault(e => e.OptionDefinition.HasAlias(token.Value));
            if (option == null)
              options.Add(new Option(definition, token));
            continue;
          }
        }
      }
      return new ParserResult(options);
    }

    /// <summary>
    /// Gets the default parser.
    /// </summary>
    /// <returns>The default parser.</returns>
    public static Parser Default
    {
      get { return _default.Value; }
    }

    /// <summary>
    /// Gets the settings used to parse the command line arguments.
    /// </summary>
    /// <returns>The settings used to parse the command line arguments.</returns>
    public ParserSettings Settings
    {
      get { return _settings; }
    }

    internal Tokenizer Tokenizer
    {
      get { return _tokenizer; }
    }
  }
}