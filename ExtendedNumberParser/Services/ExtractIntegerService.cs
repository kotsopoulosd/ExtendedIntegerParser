using System;
using System.Collections.Generic;
using System.Linq;
using ExtendedNumberParser.Interfaces;

namespace ExtendedNumberParser.Services
{
  public class ExtractIntegerService : IExtractIntegerService
  {
    public IEnumerable<int> GetIntegersFromList(char[][] twoDList)
    {
      var result = new List<int>();
      var iteratorList = new List<int> {0, 0, 0, 0};
      int maxValue = iteratorList.Max();
      var index = 1;

      // The max iteration that we will perform derived from the numbers of rows on the file
      // first dimension of our array.
      var maxIterations = twoDList.Length / 4;
      while (index <= maxIterations)
      {
        var list = twoDList.Skip((index - 1) * 4).Take(4).ToList();
        // Iterate always to first for lines,based on the current height of the "number".
        // and find where the current "number" ends.
        for (int i = 0; i < 4; i++)
        {
          var lastIndex = GetIndexOfTheDrawingNumber(list[i], maxValue);
          iteratorList[i] = lastIndex;
        }
        var oldMaxValue = maxValue;
        maxValue = iteratorList.Max() + 1;
        AddIntegerToResult(maxValue, oldMaxValue, list, result);
        if (maxValue == list[0].Length)
        {
          index++;
          maxValue = 0;
        }
      }
      return result;
    }

    #region private methods

    /// <summary>
    /// Updates the result based on the new "number" that we get from the list
    /// </summary>
    /// <param name="maxValue">Maximum value of iteration horizontally</param>
    /// <param name="oldMaxValue">The previous maximum value of iteration horizontally</param>
    /// <param name="twoDList">List that contains the current sub array</param>
    /// <param name="result"></param>
    private void AddIntegerToResult(int maxValue, int oldMaxValue, List<char[]> twoDList, List<int> result)
    {
      var realStart = SetRealStartWithoutWhiteSpaces(oldMaxValue, twoDList);

      var array = CreateSubDimArray(maxValue, twoDList, realStart);

      var isOneIncluded = Utils.IsOneIncluded(array);
      var isTwoIncluded = Utils.IsTwoIncluded(array);
      var isThreeIncluded = Utils.IsThreeIncluded(array);
      var isFourIncluded = Utils.IsFourIncluded(array);
      var isFiveIncluded = Utils.IsFiveIncluded(array);

      if (isOneIncluded)
      {
        result.Add(1);
      }

      if (isTwoIncluded)
      {
        result.Add(2);
      }

      if (isThreeIncluded)
      {
        result.Add(3);
      }

      if (isFourIncluded)
      {
        result.Add(4);
      }

      if (isFiveIncluded)
      {
        result.Add(5);
      }
    }

    /// <summary>
    /// Creates the 2-d array that the "number" occupies in the text file 
    /// </summary>
    /// <param name="maxValue">Maximum value of iteration horizontally</param>
    /// <param name="twoDList">List that contains the current sub array</param>
    /// <param name="realStart">The starting index without the whitespaces of the current number</param>
    private bool[,] CreateSubDimArray(int maxValue, List<char[]> twoDList, int realStart)
    {
      bool[,] array = new bool[4, maxValue - realStart];
      for (int i = 0; i < 4; i++)
      {
        int tmpJ = 0;
        for (int j = realStart; j < Math.Min(maxValue, twoDList[i].Length); j++)
        {
          array[i, tmpJ] = twoDList[i][j] != ' ';
          tmpJ++;
        }
      }
      return array;
    }

    /// <summary>
    /// Returns the real start of iteration without the whitespaces.
    /// </summary>
    /// <param name="maxIterator">Maximum value of iteration horizontally</param>
    /// <param name="twoDList">List that contains the current sub array</param>
    private int SetRealStartWithoutWhiteSpaces(int maxIterator, List<char[]> twoDList)
    {
      int realStart = maxIterator;

      for (int i = maxIterator; i < twoDList[0].Length; i++)
      {
        if (twoDList[0][i] == ' ')
        {
          continue;
        }
        realStart = i;
        break;
      }
      return realStart;
    }

    /// <summary>
    /// Returns the last valid index of the column that the "number" ends. 
    /// </summary>
    /// <param name="previousIterator">Maximum value of previous iteration horizontally</param>
    /// <param name="oneDArray">List that contains the current sub 1-d array</param>
    private int GetIndexOfTheDrawingNumber(char[] oneDArray, int previousIterator)
    {
      var tmpArray = CreateBooleanTempArray(oneDArray);

      for (int s = previousIterator; s <= tmpArray.Count - 1; s++)
      {
        if (tmpArray[s])
        {
          if (s.Equals(tmpArray.Count - 1))
          {
            return s;
          }
          if (tmpArray[s] == tmpArray[s + 1])
          {
            continue;
          }
          if (tmpArray[s])
          {
            return s;
          }
          return s + 1;
        }
      }
      return 0;
    }

    private List<bool> CreateBooleanTempArray(char[] oneDArray)
    {
      var tmpArray = new List<bool>(oneDArray.Length);
      foreach (var elem in oneDArray)
      {
        if (elem == ' ')
        {
          tmpArray.Add(false);
        }
        else
        {
          tmpArray.Add(true);
        }
      }
      return tmpArray;
    }

    #endregion

  }
}