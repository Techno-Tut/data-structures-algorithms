using System;

namespace DataStructures_Algorithms
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     LinearSearch();
        // }

        void LinearSearch() {
            string searchKey = Console.ReadLine();
            int[] data = new int[10] {11,22,33,44,55,66,77,88,99,1};
            for(int i = 0; i < data.Length; i++) {
                if(data[i].ToString() == searchKey) {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
