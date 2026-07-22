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
            linkedHashSet();
            hashMap();
            TreeMap();
            Lambda();
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

        ///////////////////////////////////////////////////
        public static void linkedHashSet()
        {
            List<string> linkedHashSet = new List<string>();
            AddUnique(linkedHashSet, "first");
            AddUnique(linkedHashSet, "secound");
            AddUnique(linkedHashSet, "third");
            AddUnique(linkedHashSet, "first");

            foreach (string item in linkedHashSet)
            {
                Console.WriteLine(item);
            }
        }

        public static void AddUnique(List<string> linkedHashSet, string value)
        {
            if (!linkedHashSet.Contains(value))
            {
                linkedHashSet.Add(value);
            }
        }


        ///////////////////////////////////////////////////
        public static void hashMap()
        {
            Dictionary<string, int> hashMap = new Dictionary<string, int>();
            hashMap["math"] = 85;
            hashMap["Physics"] = 90;
            hashMap["math"] = 95;

            foreach (KeyValuePair<string, int> pair in hashMap)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }


        ///////////////////////////////////////////////////
        public static void TreeMap()
        {
            SortedDictionary<string, int> treemap = new SortedDictionary<string, int>();
            treemap["hi"] = 70;
            treemap["hi1"] = 60;

            foreach (KeyValuePair<string, int> pair in treemap)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }

        }








        // Lambda Expression
        public static void Lambda()
        {
            List<string> names = new List<string>()
            {
                "Alaa",
                "Ahmad",
                "Sara",
                "Omar",
                "Lina"
            };

            var result = names.Where(name => name.StartsWith("A"));
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

        }

    }
}