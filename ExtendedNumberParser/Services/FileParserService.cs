using System.Collections.Generic;
using System.IO;
using ExtendedNumberParser.Interfaces;

namespace ExtendedNumberParser.Services
{
  public class FileParserService : IFileParserService
  {

    public char[][] FileParserToDimensionalList(string logFilePath)
    {
      var list = new List<string>();
      using (FileStream fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
      {
        using (StreamReader sr = new StreamReader(fs))
        {
          while (sr.Peek() >= 0)
          {
            list.Add(sr.ReadLine());
          }
        }
      }
      char[][] cells = new char[list.Count][];

      for (int i = 0; i < cells.Length; i++)
        cells[i] = list[i].ToCharArray();
      return cells;
    }
  }
}
