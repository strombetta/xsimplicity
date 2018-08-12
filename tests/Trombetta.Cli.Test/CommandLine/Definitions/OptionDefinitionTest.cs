using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine.Definitions
{
   public class OptionDefinitionTest
   {
      [Fact]
      public void OptionDefinitionHasName()
      {
         var definition = new OptionDefinition<String>(new[] { "option" }, "An option definition.");
         Assert.True(definition.Name == "option");
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
         var definition = new OptionDefinition<String>(new[] { "help", "h", "?" }, "An option definition.");
         Assert.True(definition.Aliases.Count() == 3);
         Assert.True(definition.Name == "help");
         Assert.Contains("h", definition.Aliases);
         Assert.Contains("?", definition.Aliases);
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
   }
}
