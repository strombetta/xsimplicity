using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine
{
   public class OptionTest
   {
      [Fact]
      public void OptionHasAName()
      {
         var option = new Option(new[] { "option" }, "");
         Assert.True(option.Name == "option");
      }

      [Fact]
      public void OptionIsNotACommand()
      {
         var option = new Option(new[] { "option" }, "");
         Assert.False(option.IsCommand);
      }

      [Fact]
      public void OptionCannotHaveEmptyAlias()
      {
         Action action = () => new Option(new[] { "" }, "");
         Assert.Throws<ArgumentException>(action);
      }

      [Fact]
      public void OptionHasMultipleAliases()
      {
         var option = new Option(new[] { "help", "h", "?" }, "");
         Assert.True(option.Aliases.Count() == 3);
         Assert.True(option.Name == "help");
         Assert.Contains("h", option.Aliases);
         Assert.Contains("?", option.Aliases);
      }

      [Fact]
      public void OptionAliasesAreCaseSensitive()
      {
         var option = new Option(new[] { "option", "o" }, "");
         Assert.True(option.Aliases.Count() == 2);
         Assert.True(option.Name == "option");
         Action action = () => Assert.Contains("O", option.Aliases);
         Assert.Throws<ContainsException>(action);
      }
   }
}
