using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class Day3 {
        public static void LoadList(string path, out List<string> list) {
            list = [];
            string? line = string.Empty;
            try {
                using StreamReader sr = new StreamReader(path);
                while ((line = sr.ReadLine()) != null) {
                    list.Add(line);
                }
            } catch(Exception e) {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }

        public static void Run1(string path) {
            List<string> list = [];
            LoadList(path, out list);
            var total = 0;
            var pattern = @"mul\((\d+),(\d+)\)";
            foreach(var item in list) {
                var matches = Regex.Matches(item, pattern);
                foreach(Match match in matches) {
                    var firstIsNumber = int.TryParse( match.Groups[1].Value, out int n1);
                    var secondIsNumber = int.TryParse( match.Groups[2].Value, out int n2);
                    if(firstIsNumber && secondIsNumber) {
                        total += n1 * n2;
                    }
                }
            }

            Console.WriteLine(total);
        }

        public static void Run2(string path) {
            List<string> list = [];
            LoadList(path, out list);
            var input = string.Join("", list);
            var doPattern = new Regex("(?:^|do\\(\\))(.*?)(?=(?:don't\\(\\))|$)", RegexOptions.Singleline);
            var mulPattern = new Regex("mul\\(([0-9]{1,3}),([0-9]{1,3})\\)");

            int total = 0;
            foreach (Match doMatch in doPattern.Matches(input)) {
                foreach(Match mulMatch in mulPattern.Matches(doMatch.Groups[1].Value)) {
                    total += (int.Parse(mulMatch.Groups[1].Value) * int.Parse(mulMatch.Groups[2].Value));
                }
            }
            Console.WriteLine(total);
        }
    }
}