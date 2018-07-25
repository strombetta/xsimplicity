using System;
using System.Linq;
using Trombetta.Cli.CommandLine;
using Xunit;
using Xunit.Abstractions;

namespace Trombetta.Cli.Test.CommandLine
{
   public class TokenizerTest
   {
      [Fact]
      public void TokenizerCanRecognizeArguments()
      {
         // var value = new Tokenizer().Tokenize(new[] {""});
         // var expected = 
   //       var tokens = new Tokenizer().Tokenize(new[] { "a", "b", "c" });
   //       Assert.Equal(3, tokens.Count());
   //       Assert.NotNull(tokens["a"]);
   //       Assert.NotNull(tokens["b"]);
   //       Assert.NotNull(tokens["c"]);
   //       Assert.Equal(TokenType.Argument, tokens["a"].Type);
   //       Assert.Equal(TokenType.Argument, tokens["b"].Type);
   //       Assert.Equal(TokenType.Argument, tokens["c"].Type);
      }

   //    [Fact]
   //    public void TokenizerHasDefaultSettings()
   //    {
   //       var tokens = new Tokenizer().Tokenize(new[] { "-a", "--b" });
   //       Assert.Equal(2, tokens.Count());
   //       Assert.NotNull(tokens["a"]);
   //       Assert.NotNull(tokens["b"]);
   //    }

   //    [Fact]
   //    public void TokenizerHasCustomizedSettings()
   //    {
   //       var customSettings = new ParserSettings(null, new[] { ':', '=' }, new[] { @"\" });
   //       var tokens = new Tokenizer(customSettings).Tokenize(new[] { @"\a", @"\b" });
   //       Assert.Equal(2, tokens.Count());
   //       Assert.NotNull(tokens["a"]);
   //       Assert.NotNull(tokens["b"]);
   //    }

   //    [Fact]
   //    public void TokenizerCanRecognizeOptionWithoutArguments()
   //    {
   //       var tokens = new Tokenizer().Tokenize(new[] { "--option" });
   //       Assert.Single(tokens);
   //       Assert.NotNull(tokens["option"]);
   //       Assert.Equal(TokenType.Option, tokens["option"].Type);
   //    }

   //    [Fact]
   //    public void TokenizerCanRecognizeOptionWithArguments()
   //    {
   //       var tokens = new Tokenizer().Tokenize(new[] { "--option:true" });
   //       Assert.Equal(2, tokens.Count());
   //       Assert.NotNull(tokens["option"]);
   //       Assert.NotNull(tokens["true"]);
   //       Assert.Equal(TokenType.Option, tokens["option"].Type);
   //       Assert.Equal(tokens["true"].Type, TokenType.Argument);
   //    }

   //    [Fact]
   //    public void TokenizerCanRecognizeCommand()
   //    {
   //       var tokens = new Tokenizer().Tokenize(new[] { "command" });
   //       Assert.Single(tokens);
   //       Assert.NotNull(tokens["command"]);
   //       Assert.Equal(tokens["command"].Type, TokenType.Command);
   //    }

   //    [Fact]
   //    public void TokenizerIsCaseSensitive()
   //    {
   //       var tokens = new Tokenizer().Tokenize(new[] { "--option" });
   //       Assert.Single(tokens);
   //       Assert.NotNull(tokens["option"]);
   //       Assert.Null(tokens["Option"]);
   //       Assert.Equal(tokens["option"].Type, TokenType.Option);
   //    }
   }
}
