using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Trombetta.Cli.CommandLine.Definitions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine.Definitions
{
   public class CommandDefinitionTest : IDisposable
   {
      private CommandDefinition definition;

      public CommandDefinitionTest()
      {
         definition = new CommandDefinition("build",
         new IArgumentDefinition[] { new ArgumentDefinition<String>("input", "The input parameter") },
         new IOptionDefinition[] { },
         "A command");
      }

      [Fact]
      public void CommandDefinitionHasArgument()
      {
         var expected = new ArgumentDefinition<String>("input", "The input parameter");
         var actual = definition.ArgumentDefinitions.Single();
         Assert.True(expected.AllowedValues == actual.AllowedValues);
         Assert.True(expected.DefaultValue == (String)actual.DefaultValue);
         Assert.True(expected.HelpMessage == actual.HelpMessage);
         Assert.True(expected.Name == actual.Name);
         Assert.True(expected.Type == actual.Type);
      }

      [Fact]
      public void CommandDefinitionHasName()
      {
         var expected = "build";
         Assert.True(expected == definition.Name);
      }

      [Fact]
      public void CommandDefinitionHasHelpMessage()
      {
         var expected = "A command";
         Assert.True(expected == definition.HelpMessage);
      }

      public void Dispose()
      { }
   }
}
