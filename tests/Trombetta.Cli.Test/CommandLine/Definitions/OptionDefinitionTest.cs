using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine.Definitions
{
   public class OptionDefinitionTest : IDisposable
   {
      private OptionDefinition<String> definition;

      public OptionDefinitionTest()
      {
         definition = new OptionDefinition<String>(new[] { "help", "h", "?" }, "An option definition.");
      }

      [Fact]
      public void OptionDefinitionHasName()
      {
         var expected = "help";
         Assert.True(expected == definition.Name);
      }

      [Fact]
      public void OptionDefinitionCannotHaveEmptyAlias()
      {
         Action action = () => new OptionDefinition<String>(new[] { "" }, "An option definition.");
         Assert.Throws<ArgumentException>(action);
      }

      [Fact]
      public void OptionDefinitionHasMultipleAliases()
      {
         var expected = new[] { "help", "h", "?" };
         Assert.Equal(expected, definition.Aliases);
      }

      [Fact]
      public void ToggleDefinitionAliasesAreCaseSensitive()
      {
         var option = new OptionDefinition<String>(new[] { "option", "o" }, "An option definition.");
         Assert.True(option.Aliases.Count() == 2);
         Assert.True(option.Name == "option");
         Action action = () => Assert.Contains("O", option.Aliases);
         Assert.Throws<ContainsException>(action);
      }

      public void Dispose()
      { }
   }
}
