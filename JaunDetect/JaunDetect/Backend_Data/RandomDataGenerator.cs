using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Backend_Data
{
    public class RandomDataGenerator
    {
        private Random _rand = new Random();

        public int[] GetRandomDatapoint(int num, int low, int high)
        {
            int[] result = new int[num];

            for (int i = 0; i < num; i++)
            {
                result[i] = _rand.Next(low, high);
            }

            return result;
        }

        public int GetRandomInt(int low, int high)
        {
            return _rand.Next(low, high);
        }
    }
}