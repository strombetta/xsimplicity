//
// Copyright (C) Sebastiano Trombetta. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine.Definitions;

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
      public Parser()
        : this(new ParserSettings())
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the spefied collection of <see cref="Toggle"/> objects.
      /// </summary>
      /// <param name="definitions"></param>
      public Parser(params IDefinition[] definitions)
        : this(new ParserSettings(definitions))
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="Parser"/> class with the specified settings.
      /// </summary>
      /// <param name="settings">The settings used to parse the command line arguments.</param>
      public Parser(ParserSettings settings)
      {
         _settings = settings ?? throw new ArgumentNullException(nameof(settings));

         // Configuring the tokenizer.
         var tokenizerSettings = new TokenizerSettings(_settings.OptionPrefixes, _settings.ArgumentDelimiters, _settings.ArgumentSeparator);
         _tokenizer = new Tokenizer(tokenizerSettings);
      }

      public ParserResult Parse<T>(String[] args)
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
      public ParserResult Parse(IEnumerable<IDefinition> definitions, String[] args)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentException(nameof(definitions));

         var result = new ParserResult();
         ICommandResult command = null;
         IOptionResult option = null;
         Object arguments = null;

         var tokens = new Queue<Token>(_tokenizer.Tokenize(args, definitions));
         while (tokens.Any())
         {
            var token = tokens.Dequeue();
            switch (token.Type)
            {
               case TokenType.Argument:
                  var argument = new ArgumentResult<String>(token.Value);
                  if (command == null) result.Items.Add(argument);
                  else command.Argument = argument;
                  break;
               case TokenType.Command:
                  command = ParseCommand(token, definitions);
                  result.Items.Add(command);
                  break;
               case TokenType.EndListOfOptionArguments:
                  option.Argument = arguments;
                  break;
               case TokenType.StartListOfOptionArguments:
                  var innerType = option.Definition.ArgumentDefinition.GetType().GenericTypeArguments[0].GenericTypeArguments[0];
                  var type = typeof(List<>).MakeGenericType(innerType);
                  arguments = Activator.CreateInstance(type);
                  break;
               case TokenType.Option:
                  option = ParseOption(token, definitions);
                  result.Items.Add(option);
                  break;
               case TokenType.OptionArgument:
                  ParseOptionArgument(token, option, (IList)arguments);
                  break;
            }
         }
         return result;
      }

      private IArgumentResult ParseArgument(Token token, IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentNullException(nameof(definitions));
         if (token.Type != TokenType.Argument) throw new ArgumentException(nameof(token));

         if (definitions.Where(e => e is Command && e.Name == token.Value).Any())
            throw new InvalidOperationException();
         else return new ArgumentResult<String>(token.Value);
      }

      private ICommandResult ParseCommand(Token token, IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentNullException(nameof(definitions));
         if (token.Type != TokenType.Command) throw new ArgumentException(nameof(token));

         var definition = definitions.Where(e => e is Command && e.Name == token.Value)
           .Cast<Command>()
           .Single();
         if (definition != null) return definition.CreateCommand();
         else throw new InvalidOperationException();
      }

      private IOptionResult ParseOption(Token token, IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentNullException(nameof(definitions));
         if (token.Type != TokenType.Option) throw new ArgumentException(nameof(token));

         var definition = definitions.Where(e => e is IOption)
            .Cast<IOption>()
            .SingleOrDefault(e => e.Aliases.Any(a => String.Compare(a, token.Value, true) == 0));

         if (definition != null) return definition.CreateOption();
         else throw new InvalidOperationException();
      }

      private void ParseOptionArgument(Token token, IOptionResult option, IList arguments)
      {
         if (token.Type != TokenType.OptionArgument) throw new ArgumentException(nameof(token));
         if (option == null) throw new ArgumentNullException(nameof(option));
         if (option.IsCompleted) throw new ArgumentException(nameof(option));

         if (!option.AcceptMoreArguments)
            option.Argument = token.Value;
         else arguments.Add(token.Value);
      }

      private void Initialize(ParserResult result, IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentException(nameof(definitions));
      }

      private void Validate(ParserResult result, IEnumerable<IDefinition> definitions)
      {
         if (definitions == null) throw new ArgumentNullException(nameof(definitions));
         if (!definitions.Any()) throw new ArgumentException(nameof(definitions));
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
      /// 
      /// </summary>
      /// <value></value>
      private ParserResult Result { get; set; }

      /// <summary>
      /// Gets the settings used to parse the command line arguments.
      /// </summary>
      /// <returns>The settings used to parse the command line arguments.</returns>
      public ParserSettings Settings
      {
         get { return _settings; }
      }

      /// <summary>
      /// Gets the tokenizer used to tokenize the command line arguments.
      /// </summary>
      /// <returns>The tokenizer used to tokenize the command line arguments.</returns>
      internal Tokenizer Tokenizer
      {
         get { return _tokenizer; }
      }
   }
}