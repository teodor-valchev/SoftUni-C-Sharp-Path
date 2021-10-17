using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(params int[] data)
        {
            stones = new List<int>(data);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < stones.Count; index++)
            {
                if (index % 2 == 0)
                {
                    yield return stones[index];
                }
            }

            for (int index = stones.Count - 1; index >= 0; index--)
            {
                if (index % 2 == 1)
                {
                    yield return stones[index];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
