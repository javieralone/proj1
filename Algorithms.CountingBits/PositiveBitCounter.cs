// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
using System.Collections;
using System.Linq;

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            CheckInput(input);
            int positive = 0;
            List<int> result = new List<int>();

            BitArray b = new BitArray(new byte[] { (byte)input });
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            foreach (var item in bits)
                if (item == 1)
                    positive += 1; 

            result.Add(positive);

            for (int i = 0; i < bits.Length; i++)
                if (bits[i] == 1)
                    result.Add(i);
            
            return result;
        }

        private void CheckInput(int input)
        {
            if (input < 0)
                throw new ArgumentException("The number must be higher than -1.");            
        }
    }
}