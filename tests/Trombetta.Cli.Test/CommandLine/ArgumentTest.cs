using System;
using System.Collections.Generic;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;

namespace Trombetta.Cli.Test.CommandLine
{
   public class ArgumentTest : IDisposable
   {
      private Argument<Int32> definition;

      public ArgumentTest()
      {
         definition = new Argument<Int32>("input", new Int32[] { 1, 2, 3, 4 }, 1, false, "A string argument definition");
      }

      [Fact]
      public void ArgumentHasAllowedValues()
      {
         var expected = new Int32[] { 1, 2, 3, 4 };
         Assert.Equal(expected, definition.AllowedValues);
      }

      [Fact]
      public void ArgumentHasDefaultValue()
      {
         var expected = 1;
         Assert.True(expected == definition.DefaultValue);
      }

      [Fact]
      public void ArgumentHasName()
      {
         var expected = "input";
         Assert.True(expected == definition.Name);
      }

      [Fact]
      public void ArgumentHasHelpMessage()
      {
         var expected = "A string argument definition";
         Assert.True(expected == definition.HelpMessage);
      }

      [Fact]
      public void ArgumentDefintionCanBeRequired()
      {
         var expected = false;
         Assert.True(expected == definition.IsRequired);
      }

      public void Dispose()
      { }
   }
}
