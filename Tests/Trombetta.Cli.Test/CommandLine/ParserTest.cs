using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;

namespace Trombetta.Cli.Test.CommandLine
{
   public class ParserTest
   {
      [Fact]
      public void ParserCanParseSingleArgument()
      {
         var args = new[] { "input" };
         var options = new[] {
               new ArgumentDefinition<String>("in", "A string argument."),
               new ArgumentDefinition<String>("out", "A string argument."),
               new ArgumentDefinition<String>("error", "A string argument.")
         };

         var current = Parser.Default.Parse(options, args).Arguments.Single();
         Assert.IsType<Argument<String>>(current);
         ///Assert.True(current.)
      }

      [Fact]
      public void ParserCanParseMultipleArguments()
      {
         var args = new[] { "argument1", "arguments2" };
         var options = new[] {
               new ArgumentDefinition<String>("argument1", "A string argument."),
               new ArgumentDefinition<String>("argument2", "A string argument."),
               new ArgumentDefinition<String>("argument3", "A string argument.")
         };

         foreach (var current in Parser.Default.Parse(options, args).Arguments)
         {
            Assert.IsType<Argument<String>>(current);
         }
      }

      // [Fact]
      // public void ParserCanParseSingleCommand()
      // {
      //    var args = new[] { "command"};
      //    var options = new[] {
      //       new CommandDefinition("command", "A command")
      //    };

      //    var current = Parser.Default.Parse(options, args).Commands.Single();
      //    Assert.IsType<Command>(current);
      // }

      [Fact]
      public void ParserCanParseSingleOption()
      {
         var args = new[] { "--option1" };
         var options = new[] {
               new ToggleDefinition(new[] {"option1", "opt1", "o1"}, "A multi alias option."),
               new ToggleDefinition(new[] {"option2", "opt2", "o2"}, "A multi alias option."),
               new ToggleDefinition(new[] {"option3", "opt3", "o3"}, "A multi alias option.")
         };

         var current = Parser.Default.Parse(options, args).Options.Single();
         Assert.IsType<Option<Boolean>>(current);
         Assert.True(current.Name == "option1");
         Assert.True(current.IsCompleted == true);
         Assert.NotNull(current.Argument);
      }

      [Fact]
      public void ParseCanParseMultipleOptions()
      {
         var args = new[] { "--option1", "--option2" };
         var options = new[] {
               new ToggleDefinition(new[] {"option1", "opt1", "o1"}, "A multi alias option."),
               new ToggleDefinition(new[] {"option2", "opt2", "o2"}, "A multi alias option."),
               new ToggleDefinition(new[] {"option3", "opt3", "o3"}, "A multi alias option.")
         };

         foreach (var current in Parser.Default.Parse(options, args).Options)
         {
            Assert.IsType<Option<Boolean>>(current);
            Assert.True(current.IsCompleted == true);
            Assert.NotNull(current.Argument);
         }
      }

      [Fact]
      public void ParseOptionWithArgumentSuccessfully()
      {
         var args = new[] { "--optionWithArgument=argument" };
         var options = new[] {
               new OptionDefinition<String>(new[] {"optionWithArgument"}, "An option that accepts a single string argument.", true)
         };
         var current = Parser.Default.Parse(options, args).Options.Single();
         Assert.IsType<Option<String>>(current);
         Assert.True(current.Name == "optionWithArgument");
         Assert.True(current.IsCompleted == true);
         Assert.NotNull(current.Argument);
         Assert.True(((String)current.Argument) == "argument");
      }

      [Fact]
      public void ParseOptionWithListOfArgumentsSuccessfully()
      {
         var args = new[] { "--optionWithListOfArguments=argument1,argument2" };
         var options = new[] {
               new OptionDefinition<IEnumerable<String>>(new[] {"optionWithListOfArguments"}, "An option that accepts a list of string arguments.", true)
         };
         var current = Parser.Default.Parse(options, args).Options.Single();
         Assert.IsType<Option<IEnumerable<String>>>(current);
         Assert.True(current.Name == "optionWithListOfArguments");
         Assert.True(current.IsCompleted == true);
         Assert.NotNull(current.Argument);
         //Assert.IsType<IEnumerable<String>>(current.Argument);
         Assert.Contains("argument1", (IEnumerable<String>)current.Argument);
         Assert.Contains("argument2", (IEnumerable<String>)current.Argument);
      }
   }
}
