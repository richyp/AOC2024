using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2024 {
    public class Day2 {
        public static void LoadList(string path, out List<List<int>> list) {
            list = [];
            string? line = string.Empty;
            try {
                using StreamReader sr = new StreamReader(path);
                while ((line = sr.ReadLine()) != null) {
                    var splitData = line.Split(" ");
                    list.Add(splitData.Select(x => int.Parse(x)).ToList());
                }
            } catch(Exception e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }

        public static bool IsSafe(List<int> list) {
            var safe = true;
            var decrease = false;
            for(var i = 0; i < list.Count - 1; i++ ) {
                if( Math.Abs(list[i] - list[i+1]) < 1 || Math.Abs(list[i] - list[i+1]) > 3) {
                    safe = false;
                    Console.WriteLine($"Row is not safe ({list[i]} {list[i+1]})");
                    break;
                }
                if( i == 0) {
                    decrease = list[i] > list[i+1];
                } else { 
                    var isDecrease = list[i] > list[i+1];
                    if(isDecrease != decrease) {
                        safe = false;
                        break;
                    }
                }
            }
            return safe;
        }
        public static void Run1(string path) {
            var total = 0;
            List<List<int>> list = [];
            LoadList(path, out list);
            for(var row = 0; row < list.Count; row++) {
                total += IsSafe(list[row]) ? 1 : 0;
            }
            Console.WriteLine(total);
        }

        public static void Run2(string path) {
            var total = 0;
            List<List<int>> list = [];
            LoadList(path, out list);
            for(var row = 0; row < list.Count; row++) {
                var isRowSafe = IsSafe(list[row]);
                if(! isRowSafe) {
                    for(int i = 0; i < list[row].Count; i++) {
                        var newList = new List<int>(list[row]);
                        newList.RemoveAt(i);
                        if(IsSafe(newList)) {
                            isRowSafe = true;
                            break;
                        }
                    }
                }
                total += isRowSafe ? 1 : 0;
            }
            Console.WriteLine(total);
        }
    }
}