using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;

namespace Trombetta.Cli.Test.CommandLine
{
   public class ParserTest
   {
      [Fact]
      public void ParseOptions()
      {
         var args = new[] { "--option", "-option=argument", "command" };
         var options = new[] {
               new Option("single", "A single alias option."),
               new Option(new[] {"option", "opt", "o"}, "A multi alias option."),
               new Command("command", "A command"),
         };
         var result = Parser.Default.Parse(options, args);
      }

      [Fact]
      public void OptionCanBeCheckedUsingName()
      {
         var result = new Parser(
            new Option(new String[] { "option" }, ""))
            .Parse(new String[] { "--option" });

      }
   }
}
