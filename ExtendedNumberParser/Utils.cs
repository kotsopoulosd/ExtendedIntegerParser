using System.Linq;

namespace ExtendedNumberParser
{
  public class Utils
  {
    public static bool IsThreeIncluded(bool[,] array)
    {
      var arrayAsIntegerThree = new bool[4, 3];
      arrayAsIntegerThree[0, 0] = true;
      arrayAsIntegerThree[0, 1] = true;
      arrayAsIntegerThree[0, 2] = true;

      arrayAsIntegerThree[1, 0] = false;
      arrayAsIntegerThree[1, 1] = true;
      arrayAsIntegerThree[1, 2] = false;

      arrayAsIntegerThree[2, 0] = false;
      arrayAsIntegerThree[2, 1] = true;
      arrayAsIntegerThree[2, 2] = false;

      arrayAsIntegerThree[3, 0] = true;
      arrayAsIntegerThree[3, 1] = true;
      arrayAsIntegerThree[3, 2] = false;
      var equaltoThree =
        array.Rank == arrayAsIntegerThree.Rank &&
        Enumerable.Range(0, array.Rank).All(dimension =>
          array.GetLength(dimension) == arrayAsIntegerThree.GetLength(dimension)) &&
        array.Cast<bool>().SequenceEqual(arrayAsIntegerThree.Cast<bool>());
      return equaltoThree;
    }

    public static bool IsTwoIncluded(bool[,] array)
    {
      var arrayAsIntegerTwo = new bool[4, 3];
      arrayAsIntegerTwo[0, 0] = true;
      arrayAsIntegerTwo[0, 1] = true;
      arrayAsIntegerTwo[0, 2] = true;

      arrayAsIntegerTwo[1, 0] = false;
      arrayAsIntegerTwo[1, 1] = true;
      arrayAsIntegerTwo[1, 2] = true;

      arrayAsIntegerTwo[2, 0] = true;
      arrayAsIntegerTwo[2, 1] = false;
      arrayAsIntegerTwo[2, 2] = false;

      arrayAsIntegerTwo[3, 0] = true;
      arrayAsIntegerTwo[3, 1] = true;
      arrayAsIntegerTwo[3, 2] = true;
      var equaltoTwo =
        array.Rank == arrayAsIntegerTwo.Rank &&
        Enumerable.Range(0, array.Rank).All(dimension =>
          array.GetLength(dimension) == arrayAsIntegerTwo.GetLength(dimension)) &&
        array.Cast<bool>().SequenceEqual(arrayAsIntegerTwo.Cast<bool>());
      return equaltoTwo;
    }

    public static bool IsFourIncluded(bool[,] array)
    {
      var arrayAsIntegerFour = new bool[4, 5];
      arrayAsIntegerFour[0, 0] = true;
      arrayAsIntegerFour[0, 1] = false;
      arrayAsIntegerFour[0, 2] = false;
      arrayAsIntegerFour[0, 3] = false;
      arrayAsIntegerFour[0, 4] = true;

      arrayAsIntegerFour[1, 0] = true;
      arrayAsIntegerFour[1, 1] = true;
      arrayAsIntegerFour[1, 2] = true;
      arrayAsIntegerFour[1, 3] = true;
      arrayAsIntegerFour[1, 4] = true;

      arrayAsIntegerFour[2, 0] = false;
      arrayAsIntegerFour[2, 1] = false;
      arrayAsIntegerFour[2, 2] = false;
      arrayAsIntegerFour[2, 3] = false;
      arrayAsIntegerFour[2, 4] = true;

      arrayAsIntegerFour[3, 0] = false;
      arrayAsIntegerFour[3, 1] = false;
      arrayAsIntegerFour[3, 2] = false;
      arrayAsIntegerFour[3, 3] = false;
      arrayAsIntegerFour[3, 4] = true;
      var equaltoFour =
        array.Rank == arrayAsIntegerFour.Rank &&
        Enumerable.Range(0, array.Rank).All(dimension =>
          array.GetLength(dimension) == arrayAsIntegerFour.GetLength(dimension)) &&
        array.Cast<bool>().SequenceEqual(arrayAsIntegerFour.Cast<bool>());
      return equaltoFour;
    }

    public static bool IsFiveIncluded(bool[,] array)
    {
      var arrayAsIntegerFive = new bool[4, 5];
      arrayAsIntegerFive[0, 0] = true;
      arrayAsIntegerFive[0, 1] = true;
      arrayAsIntegerFive[0, 2] = true;
      arrayAsIntegerFive[0, 3] = true;
      arrayAsIntegerFive[0, 4] = true;

      arrayAsIntegerFive[1, 0] = true;
      arrayAsIntegerFive[1, 1] = true;
      arrayAsIntegerFive[1, 2] = true;
      arrayAsIntegerFive[1, 3] = true;
      arrayAsIntegerFive[1, 4] = false;

      arrayAsIntegerFive[2, 0] = false;
      arrayAsIntegerFive[2, 1] = false;
      arrayAsIntegerFive[2, 2] = false;
      arrayAsIntegerFive[2, 3] = false;
      arrayAsIntegerFive[2, 4] = true;

      arrayAsIntegerFive[3, 0] = true;
      arrayAsIntegerFive[3, 1] = true;
      arrayAsIntegerFive[3, 2] = true;
      arrayAsIntegerFive[3, 3] = true;
      arrayAsIntegerFive[3, 4] = true;
      var equaltoFive =
        array.Rank == arrayAsIntegerFive.Rank &&
        Enumerable.Range(0, array.Rank).All(dimension =>
          array.GetLength(dimension) == arrayAsIntegerFive.GetLength(dimension)) &&
        array.Cast<bool>().SequenceEqual(arrayAsIntegerFive.Cast<bool>());
      return equaltoFive;
    }

    public static bool IsOneIncluded(bool[,] array)
    {
      var arrayAsIntegerOne = new bool[4, 1];
      arrayAsIntegerOne[0, 0] = true;
      arrayAsIntegerOne[1, 0] = true;
      arrayAsIntegerOne[2, 0] = true;
      arrayAsIntegerOne[3, 0] = true;

      var equaltoOne =
        array.Rank == arrayAsIntegerOne.Rank &&
        Enumerable.Range(0, array.Rank).All(dimension =>
          array.GetLength(dimension) == arrayAsIntegerOne.GetLength(dimension)) &&
        array.Cast<bool>().SequenceEqual(arrayAsIntegerOne.Cast<bool>());
      return equaltoOne;
    }
  }
}