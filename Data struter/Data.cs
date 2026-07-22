using System;
// Data Structer

namespace Data
{
    class Test
    {
        // arraylist , linkedlist , hashing , set , hashmap , linked hash set , 
        // tree map , linked hash map , 
        public static void Main(string[] args)
        {
            List<int> arr = new List<int>();
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);



            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(x[i] + " ");
            }

            // to conver the list to array 
            int[] x = arr.ToArray();

        }
    }
}