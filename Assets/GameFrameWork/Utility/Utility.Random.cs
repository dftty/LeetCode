using System;

namespace GameFramework
{
    public static partial class Utility
    {
        public static class Random
        {
            private static System.Random s_Random = new System.Random((int)DateTime.Now.Ticks);

            public static void SetSeed(int seed)
            {
                s_Random = new System.Random(seed);
            }

            public static int GetRandom()
            {
                return s_Random.Next();
            }

            public static int GetRandom(int maxValue)
            {
                return s_Random.Next(maxValue);
            }

            public static int GetRandom(int minValue, int maxValue)
            {
                return s_Random.Next(minValue, maxValue);
            }

            public static double GetRandomDouble()
            {
                return s_Random.NextDouble();
            }

            public static void GetRandomBytes(byte[] buffer)
            {
                s_Random.NextBytes(buffer);
            }
        }
    }
}