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
            string? line = string.Empty;
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
            list1.Sort();
            list2.Sort();
            var stack1 = new Stack<int>(list1);
            var stack2 = new Stack<int>(list2);
            
            while(stack1.Count > 0) {
                var item1 = stack1.Pop();
                var item2 = stack2.Pop();
                total += Math.Abs(item1 - item2);
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