using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class Methods : MonoBehaviour
{
    #region notationMethods
    public static string NotationMethod(double x)
    {
        if (x >= 1000)
        {
            var exponent = Math.Floor(Math.Log10(Math.Abs(x)));
            var mantissa = x / Math.Pow(10, exponent);
            return $"{mantissa:F2}e{exponent:F0}";
        }
        return x.ToString("F2");
    }

    public static string NotationMethodBd(BigDouble x)
    {
        if (x >= 1000)
        {
            var exponent = Floor(Log10(Abs(x)));
            var mantissa = x / Pow(10, exponent);
            return $"{mantissa:F2}e{exponent:F0}";
        }
        return x.ToString("F2");
    }
    #endregion

    #region lists
    public static List<T> CreateList<T>(int capacity) => Enumerable.Repeat(default(T), capacity).ToList();

    public static void UpgradeCheck<T>(List<T> list, int length) where T : new()
    {
        try
        {
            if (list.Count == 0) list = CreateList<T>(length);
            while (list.Count < length) list.Add(new T());
            while (list.Count > length) list.RemoveAt(list.Count-1);
        }
        catch
        {
            Debug.Log("A err has occured");
            list = CreateList<T>(length);
        }
    }

    #endregion
}
