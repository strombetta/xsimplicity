using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;

namespace Trombetta.Cli.Test.CommandLine
{
   public class ParserTest
   {
      [Fact]
      public void ParseOptionSuccessfully()
      {
         var args = new[] { "--option" };
         var options = new[] {
               new FlagDefinition(new[] {"option", "opt", "o"}, "A multi alias option.")
         };
         var result = Parser.Default.Parse(options, args);
         Assert.True(result.Options.Count() == 1);
         Assert.True(result.Options.Single().Name == "option");
      }

      [Fact]
      public void ParseOptionWithArgumentSuccessfully()
      {
         var args = new[] { "--optionWithArgument=argument" };
         var options = new[] {
               new OptionDefinition<String>(new[] {"optionWithArgument"}, "A multi alias option.")
         };
         var result = Parser.Default.Parse(options, args);
         Assert.True(result.Options.Count() == 1);
         Assert.True(result.Options.Single().Name == "optionWithArgument");
         Assert.True(((String)result.Options.Single().Argument) == "argument");
      }

      [Fact]
      public void ParseDefaultOption()
      {
         var args = new[] { "--option" };
         var options = new[] {
               new FlagDefinition(new[] {"option"}, "An option.")
         };
         var result = Parser.Default.Parse(options, args);
         Assert.True(result.Options.Count() == 1);
      }

      [Fact]
      public void OptionCanBeCheckedUsingName()
      {
         //[Option('r', "read", Required = true, HelpText = "Input files to be processed.")]
         //  var options = new[] { new OptionDefinition(new[] { "help", "h" }, "Display this help message.") };
         //  var parserResults = Parser.Default.Parse(options, new[] { "--help" });
         //  foreach (var option in parserResults.Options)
         //  {
         //     Assert.True(option.Key == "help");
         //  }
      }
   }
}
