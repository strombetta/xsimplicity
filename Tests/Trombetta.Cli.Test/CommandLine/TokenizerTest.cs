using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;

namespace Trombetta.Cli.Test.CommandLine
{
   public class TokenizerTest
   {
      [Fact]
      public void SimpleOption()
      {
         var configuration = new ParserConfiguration(new Option(new[] {"o"}, ""));
         var result = new Tokenizer(configuration).Tokenize(new[] { "-o" });
      }

      [Fact]
      public void SuccessfullyCreateTokenWithArgument()
      {
         var configuration = new ParserConfiguration(new Option(new[] {"verbosity"}, ""));
         var result = new Tokenizer(configuration).Tokenize(new[] { "--verbose" });
      }

      [Fact]
      public void SimpleCommand()
      {
         var result = new Parser(new Command("command", "")).Parse(new[] { "command" });
         Assert.True(result.Tokens.Count() == 1);
         Assert.True(result.Tokens.First().Value == "command");
         Assert.True(result.Tokens.First().Type == TokenType.Command);
      }
   }
}
