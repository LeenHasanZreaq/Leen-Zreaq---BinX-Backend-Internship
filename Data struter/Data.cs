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
            arrlist();
            linkedlist();
            hashSet();
            treeSet();
        }

        ////////////////////////////////////////
        public static void arrlist()
        {
            List<int> arr = new List<int>();
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);



            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }

            // to conver the list to array 
            int[] x = arr.ToArray();
        }
        ///////////////////////////////////////////////////

        public static void linkedlist()
        {
            //Add elements to the ends
            LinkedList<String> linked = new LinkedList<string>();
            linked.AddLast("Leen");
            linked.AddLast("Hasan");
            linked.AddLast("Zreaq");

            foreach (var item in linked)
            {
                Console.WriteLine(item + "->");
            }

            // insert after the first node 
            LinkedListNode<string> firstNode = linked.First;
            linked.AddAfter(firstNode, "abdalhalem");

            foreach (var item in linked)
            {
                Console.WriteLine(item + "->");
            }

        }

        ///////////////////////////////////////////////////
        public static void hashSet()
        {
            HashSet<string> hashseet = new HashSet<string>();
            hashseet.Add("hi");
            hashseet.Add("hi hi");
            hashseet.Add("hi hi hi");

            foreach (string item in hashseet)
            {
                Console.WriteLine(item);
            }
        }

        ///////////////////////////////////////////////////
        public static void treeSet()
        {
            SortedSet<int> sort = new SortedSet<int>();
            sort.Add(30);
            sort.Add(10);
            sort.Add(20);

            foreach (int num in sort)
            {
                Console.WriteLine(num);
            }

        }
    }
}