using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AdventOfCode2024 {
    public class Day1 {
        public static void LoadLists(string path, out List<int> list1, out List<int> list2) {
            list1 = [];
            list2 = [];
            string line = string.Empty;
            try {
                using (StreamReader sr = new StreamReader(path)) {
                    while ((line = sr.ReadLine()) != null) {
                        var splitData = line.Split("   ");
                        list1.Add(int.Parse(splitData[0]));
                        list2.Add(int.Parse(splitData[1]));
                    }
                }
            } catch(Exception e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }

        public static void Run1(string path) {
            var total = 0;
            List<int> list1 = [];
            List<int> list2 = [];
            LoadLists(path, out list1, out list2);
            while(list1.Count > 0 ) {
                var smallest1 = -1;
                var smallestIndex1 = -1;
                var smallest2 = -1;
                var smallestIndex2 = -1;
                for(int i = 0; i < list1.Count; i++) {
                    if(smallest1 == -1 || list1[i] < smallest1) {
                        smallest1 = list1[i];
                        smallestIndex1 = i;
                    }
                    if(smallest2 == -1 || list2[i] < smallest2) {
                        smallest2 = list2[i];
                        smallestIndex2 = i;
                    }
                }
                total += Math.Abs(list1[smallestIndex1] - list2[smallestIndex2]);
                list1.RemoveAt(smallestIndex1);
                list2.RemoveAt(smallestIndex2);
            }
            Console.WriteLine(total);
        }
    
        public static void Run2(string path) {
            var total = 0;
            List<int> list1 = [];
            List<int> list2 = [];
            LoadLists(path, out list1, out list2);
            foreach(var item in list1) {
                var count = list2.Where(x => x == item).Count();
                total += item * count;
            }
            Console.WriteLine(total);
        }
    }
    
}