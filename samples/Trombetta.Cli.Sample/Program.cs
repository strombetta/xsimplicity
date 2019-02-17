using System;
using Trombetta.Cli.CommandLine;

namespace Trombetta.Cli.Sample
{
   class Program
   {
      static void Main(string[] args)
      {
         var result = Parser.Default.Parse<Options>(args);
         Console.WriteLine("Hello World!");
      }
   }
}
