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
               new OptionDefinition("single", "A single alias option."),
               new OptionDefinition(new[] {"option", "opt", "o"}, "A multi alias option."),
               new CommandDefinition("command", "A command"),
         };
      var result = Parser.Default.Parse(options, args);
    }

    [Fact]
    public void OptionCanBeCheckedUsingName()
    {
      //[Option('r', "read", Required = true, HelpText = "Input files to be processed.")]
      var options = new[] { new OptionDefinition(new[] { "help", "h" }, "Display this help message.") };
      var parserResults = Parser.Default.Parse(options, new[] { "--help" });
      foreach(var option in parserResults.Options)
      {
        Assert.True(option.Key == "help");
      }
    }
  }
}
