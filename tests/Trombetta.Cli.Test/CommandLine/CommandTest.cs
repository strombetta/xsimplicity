using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Trombetta.Cli.Test.CommandLine
{
   public class CommandTest : IDisposable
   {
      private Command definition;

      public CommandTest()
      {
         definition = new Command(new[] { "commit", "c" },
         new IArgument[] { new Argument<String>("input", "The input parameter") },
         new IOption[] { new Option<String>(new[] { "message", "m" }, true, "The option") },
         "A command");
      }

      [Fact]
      public void CommandHasAlias()
      {
         var expected = new[] { "commit", "c" };
         Assert.Equal(expected, definition.Aliases);
      }

      [Fact]
      public void CommandHasArgument()
      {
         var expected = new Argument<String>("input", "The input parameter");
         var actual = definition.Arguments.Single();
         Assert.True(expected.AllowedValues == actual.AllowedValues);
         Assert.True(expected.DefaultValue == (String)actual.DefaultValue);
         Assert.True(expected.HelpMessage == actual.HelpMessage);
         Assert.True(expected.IsRequired == actual.IsRequired);
         Assert.True(expected.Name == actual.Name);
      }

      [Fact]
      public void CommandHasName()
      {
         var expected = "commit";
         Assert.True(expected == definition.Name);
      }

      [Fact]
      public void CommandHasHelpMessage()
      {
         var expected = "A command";
         Assert.True(expected == definition.HelpMessage);
      }

      [Fact]
      public void CommandHasOption()
      {
         var expected = new Option<String>(new[] { "message", "m" }, true, "The option");
         var actual = definition.Options.Single();
         Assert.Equal(expected.Aliases, actual.Aliases);
         Assert.True(expected.HelpMessage == actual.HelpMessage);
         Assert.True(expected.IsRequired == actual.IsRequired);
         Assert.True(expected.Name == actual.Name);
      }

      public void Dispose()
      { }
   }
}
