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
      public void ParseArgumentSuccessfully()
      {
         var args = new[] { "argument" };
         var options = new[] {
               new ArgumentDefinition<String>("argument", "A multi alias option.")
         };

         var current = Parser.Default.Parse(options, args).Arguments.Single();
         Assert.IsType<Argument<String>>(current);
      }

      [Fact]
      public void ParseOptionSuccessfully()
      {
         var args = new[] { "--option" };
         var options = new[] {
               new ToggleDefinition(new[] {"option", "opt", "o"}, "A multi alias option.")
         };

         var current = Parser.Default.Parse(options, args).Options.Single();
         Assert.IsType<Option<Boolean>>(current);
         Assert.True(current.Name == "option");
         Assert.True(current.IsCompleted == true);
         Assert.NotNull(current.Argument);
      }

      [Fact]
      public void ParseOptionWithArgumentSuccessfully()
      {
         var args = new[] { "--optionWithArgument=argument" };
         var options = new[] {
               new OptionDefinition<String>(new[] {"optionWithArgument"}, "An option that accepts an argument.")
         };
         var current = Parser.Default.Parse(options, args).Options.Single();
         Assert.IsType<Option<String>>(current);
         Assert.True(current.Name == "optionWithArgument");
         Assert.True(current.IsCompleted == true);
         Assert.NotNull(current.Argument);
         Assert.True(((Argument<String>)current.Argument).Value == "argument");
      }

      [Fact]
      public void ParseOptionWithListOfArgumentsSuccessfully()
      {
      //    var args = new[] { "--optionWithListOfArguments=argument1,argument2" };
      //    var options = new[] {
      //          new OptionDefinition<IEnumerable<String>>(new[] {"optionWithListOfArguments"}, "An option that accepts a list of arguments.")
      //    };
      //    var current = Parser.Default.Parse(options, args).Options.Single();
      //    Assert.IsType<Option<IList<String>>>(current);
      //    Assert.True(current.Name == "optionWithListOfArguments");
      //    Assert.True(current.IsCompleted == true);
      //    Assert.NotNull(current.Argument);
      //    Assert.IsType<IEnumerable<String>>(current.Argument);
      //    Assert.Contains("argument1", (IEnumerable<String>)current.Argument);
      //    Assert.Contains("argument2", (IEnumerable<String>)current.Argument);
      }
   }
}
