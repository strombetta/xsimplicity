using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine.Definitions
{
   public class CommandDefinitionTest
   {
      [Fact]
      public void CommandDefinitionHasName()
      {
         var definition = new CommandDefinition("command", "A command definition.");
         Assert.True(definition.Name == "command");
      }

      [Fact]
      public void CommandDefinitionHasHelpMessage()
      {
         var definition = new CommandDefinition("command", "A command definition.");
         Assert.True(definition.HelpMessage == "A command definition.");
      }
   }
}
