using System;
using ExtendedNumberParser.Interfaces;
using ExtendedNumberParser.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExtendedNumberParser
{
  class Program
  {
    private static readonly string LogFilePath = AppDomain.CurrentDomain.BaseDirectory + "numberParser.txt";

    static void Main(string[] args)
    {
      #region Initialization

      var collection = new ServiceCollection();
      collection.AddScoped<IFileParserService, FileParserService>();
      collection.AddScoped<IExtractIntegerService, ExtractIntegerService>();
      IServiceProvider serviceProvider = collection.BuildServiceProvider();
      var fileParser = serviceProvider.GetService<IFileParserService>();
      var integerExtractor = serviceProvider.GetService<IExtractIntegerService>();    
      #endregion

      var twoDList = fileParser.FileParserToDimensionalList(LogFilePath);
      var res = integerExtractor.GetIntegersFromList(twoDList);
      Console.Write("The numbers from the file are: " + string.Join(",", res));
      Console.ReadLine();

      #region Dispose
      ((IDisposable)serviceProvider).Dispose();
      #endregion

    }
  }
}