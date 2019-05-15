using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JaunDetect.Backend_Data
{
    public class RandomDataGenerator
    {

        public int[] GetRandomDatapoint(int num, int low, int high)
        {
            Random rand = new Random();

            int[] result = new int[num];

            for (int i = 0; i < num; i++)
            {
                result[i] = rand.Next(low, high);
            }

            return result;
        }

        
    }
}