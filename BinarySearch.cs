using System;
using System.Linq;

namespace DataStructures_Algorithms
{
    public class BinarySearch
    {
        // static void Main(string[] args)
        // {
        //     int[] data = new int[10] {11,22,33,44,55,66,77,88,99,100};
        //     string searchKey = Console.ReadLine();
            
        //     int key = int.Parse(searchKey);
        //     //SimpleBinarySearch(data, key);
            
        //     var result = RecursiveBinarySearch(data,key);
        //     Console.WriteLine($"Key {key} found : {result}");
        // }

        static void SimpleBinarySearch(int[] data, int key) {
            int left_pointer = 0;
            int right_pointer = data.Length -1;
            
            while(left_pointer < right_pointer) {
                int median = (right_pointer + left_pointer) / 2;

                if(key == data[median]) {
                    Console.WriteLine(median);
                    break;
                }
                else if(key < data[median])
                    right_pointer = median;
                else 
                    left_pointer = median;
            }

        }

        static bool RecursiveBinarySearch(int[] data, int key) {
            if(data.Length == 0)
                return false;
    
            int midpoint = data.Length / 2;
            if(data[midpoint] == key)
                return true;
            else if (data[midpoint] > key) {
                var subarray = data.Take(midpoint - 1).ToArray();
                return RecursiveBinarySearch(subarray, key);
            } else {
                var subarray = data.Skip(midpoint + 1).ToArray();
                return RecursiveBinarySearch(subarray, key);
            }
        }
    }
}
