using System;
using System.Collections.Generic;
using System.Linq;

namespace DialogueChatApp.DialogueTree
{
  public static class Utils
  {
    private static Random _rng = new Random();

    public static T GetRandomFromList<T>(IList<T> list) where T : class
    {
      if (list == null || list.Count == 0)
      {
        return null;
      }

      var n = _rng.Next(0, list.Count);
      return list[n];
    }
  }

  public enum ConditionOperation
  {
    Equals,
    NotEquals,
    LessThan,
    LessThanOrEqual,
    MoreThan,
    MoreThanOrEqual
  }
}
public static class StringListExtensions
{
  public static string ExplodeToString(this List<string> list)
  {
    return string.Join(", ", list);
  }
}

public class StringListComparer : IEqualityComparer<List<string>>
{
  public bool Equals(List<string> x, List<string> y)
  {
    if (x.Count != y.Count)
    {
      return false;
    }

    for (var i = 0; i < x.Count; i++)
    {
      if (!y.Contains(x[i]))
      {
        return false;
      }
    }

    return true;
  }

  public int GetHashCode(List<string> obj)
  {
    return obj.Aggregate(0, (a, y) => a ^ y.GetHashCode());
  }
}
