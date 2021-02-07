using System.Collections.Generic;

namespace ExtendedNumberParser.Interfaces
{
  public interface IExtractIntegerService
  {
    IEnumerable<int> GetIntegersFromList(char[][] twoDList);
  }
}