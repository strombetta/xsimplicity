using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine.Definitions
{
   public class OptionTest : IDisposable
   {
      private Option<String> definition;

      public OptionTest()
      {
         definition = new Option<String>(new[] { "help", "h", "?" }, "An option definition.");
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
         Action action = () => new Option<String>(new[] { "" }, "An option definition.");
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
         Action action = () => Assert.Contains("H", definition.Aliases);
         Assert.Throws<ContainsException>(action);
      }

      public void Dispose()
      { }
   }
}
