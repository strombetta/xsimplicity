using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLines
{
   public class OptionTest : IDisposable
   {
      private Option<String> definition;

      public OptionTest()
      {
         definition = new Option<String>(new[] { "help", "h", "?" },
         new Argument<String>("command", null, "", true, "The help message of the argument"),
         true,
          "An option definition.");
      }

      [Fact]
      public void OptionHasName()
      {
         var expected = "help";
         Assert.True(expected == definition.Name);
      }

      [Fact]
      public void OptionCannotHaveEmptyAlias()
      {
         Action action = () => new Option<String>(new[] { "" }, "An option definition.");
         Assert.Throws<ArgumentException>(action);
      }

      [Fact]
      public void OptionHasMultipleAliases()
      {
         var expected = new[] { "help", "h", "?" };
         Assert.Equal(expected, definition.Aliases);
      }

      [Fact]
      public void OptionAliasesAreCaseSensitive()
      {
         Action action = () => Assert.Contains("H", definition.Aliases);
         Assert.Throws<ContainsException>(action);
      }

      [Fact]
      public void OptionCanBeRequired()
      {
         var expected = true;
         Assert.True(expected == definition.IsRequired);

      }

      public void Dispose()
      { }
   }
}
