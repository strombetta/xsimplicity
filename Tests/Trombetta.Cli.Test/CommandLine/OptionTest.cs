using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;

namespace Trombetta.Cli.Test.CommandLine
{
   public class OptionTest
   {
      [Fact]
      public void SuccessfullyCreateOptionWithSingleAlias()
      {
         var option = new Option(new[] { "option" }, "");
         Assert.True(option.Name == "option");
      }

      [Fact]
      public void SuccessfullyCreateOptionWithMultipleAliases()
      {
         var option = new Option(new[] { "option", "o" }, "");
         Assert.True(option.Aliases.Count() == 2);
         Assert.True(option.Name == "option");
      }
   }
}
