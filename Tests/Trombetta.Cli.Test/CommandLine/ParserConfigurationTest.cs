using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
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
         Action action = () => new ParserSettings(
            new FlagDefinition(new[] { "option" }, ""),
            new FlagDefinition(new[] { "option" }, "")
         );
         Assert.Throws<ArgumentException>(action);
      }
   }
}