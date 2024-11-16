using UnityEngine;

namespace Code.Helpers
{
  public class MathHelper
  {
    public static float RoundDown(float number, int decimalPlaces)
    {
      float power = Mathf.Pow(10, decimalPlaces);
      return Mathf.Floor(number * power) / power;
    }
  }
}