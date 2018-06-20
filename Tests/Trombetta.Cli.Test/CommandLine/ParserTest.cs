using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;

namespace Trombetta.Cli.Test.CommandLine
{
   public class ParserTest
   {
      [Fact]
      public void SimpleOption()
      {
         var result = new Parser(new Option(new String[] { "option" }, "")).Parse(new String[] { "--option" });
         Assert.True(result.Tokens.Count() == 1);
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
