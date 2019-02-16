using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine
{
   public class ParserSettingsTest
   {
      [Fact]
      public void ConfigurationCannotHaveDuplicatedOption()
      {
         // Action action = () => new ParserSettings(
         //    new ToggleDefinition(new[] { "option" }, ""),
         //    new ToggleDefinition(new[] { "option" }, "")
         // );
         // Assert.Throws<ArgumentException>(action);
      }
   }
}