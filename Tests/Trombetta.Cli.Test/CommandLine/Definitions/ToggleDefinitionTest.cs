using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine.Definitions
{
   public class ToggleDefinitionTest
   {
      [Fact]
      public void DefinitionHasName()
      {
         var definition = new ToggleDefinition(new[] { "option" }, "");
         Assert.True(definition.Name == "option");
      }

      [Fact]
      public void DefinitionCannotHaveEmptyAlias()
      {
         Action action = () => new ToggleDefinition(new[] { "" }, "");
         Assert.Throws<ArgumentException>(action);
      }

      [Fact]
      public void DefinitionHasMultipleAliases()
      {
         var definition = new ToggleDefinition(new[] { "help", "h", "?" }, "");
         Assert.True(definition.Aliases.Count() == 3);
         Assert.True(definition.Name == "help");
         Assert.Contains("h", definition.Aliases);
         Assert.Contains("?", definition.Aliases);
      }

      [Fact]
      public void OptionAliasesAreCaseSensitive()
      {
         var option = new ToggleDefinition(new[] { "option", "o" }, "");
         Assert.True(option.Aliases.Count() == 2);
         Assert.True(option.Name == "option");
         Action action = () => Assert.Contains("O", option.Aliases);
         Assert.Throws<ContainsException>(action);
      }
   }
}
