using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrettySimpleTestTool
{
    internal class Program
    {
        private static bool errors;

        private static void RunCaseTest(Func<bool> testFunc, string message)
        {
            if (testFunc()) return;

            errors = true;
            Console.WriteLine(message);
        }

        private static void RunPerfTest(Action testFunc, double msLimit, string message)
        {
            var sw = new Stopwatch();
            sw.Start();
            testFunc();
            sw.Stop();

            if (msLimit >= sw.ElapsedMilliseconds) return; // it's ok

            errors = true;
            Console.WriteLine(message);
        }

        public static bool Test()
        {
            // example: RunCaseTest(function, "function is failed");
            // example: RunPerfTest(function, 500, "function is failed");

            RunCaseTest(SuffixTreeTest1, "SuffixTreeTest1 is failed");
            RunCaseTest(SuffixTreeTest2, "SuffixTreeTest2 is failed");
            //RunCaseTest(FindAllSubstringsTest, "FindAllSubstringsTest is failed");

            return !errors;
        }

        private static bool SuffixTreeTest1()
        {
            var actual = BuildSuffixArray("abccaacbca");
            var expected = new Tuple<int[], string[]>(
                new[] {9, 4, 0, 5, 7, 1, 8, 3, 6, 2},
                new[]
                {
                    "a",
                    "aacbca",
                    "abccaacbca",
                    "acbca",
                    "bca",
                    "bccaacbca",
                    "ca",
                    "caacbca",
                    "cbca",
                    "ccaacbca"
                }
                );

            errors = true;
            if (expected.Item1.Length == actual.Item1.Length
                && expected.Item2.Length == actual.Item2.Length)
            {
                for (var i = 0; i < expected.Item1.Length; i++)
                    if (expected.Item1[i] != actual.Item1[i]
                        || expected.Item2[i] != actual.Item2[i])
                        return false;
            }
            errors = false;
            return true;
        }

        private static bool SuffixTreeTest2()
        {
            var actual = BuildSuffixArray("aaaaa");
            var expected = new Tuple<int[], string[]>(
                new[] {4, 3, 2, 1, 0},
                new[]
                {
                    "a",
                    "aa",
                    "aaa",
                    "aaaa",
                    "aaaaa"
                }
                );

            errors = true;
            if (expected.Item1.Length == actual.Item1.Length
                && expected.Item2.Length == actual.Item2.Length)
            {
                for (var i = 0; i < expected.Item1.Length; i++)
                    if (expected.Item1[i] != actual.Item1[i]
                        || expected.Item2[i] != actual.Item2[i])
                        return false;
            }
            errors = false;
            return true;
        }

        private static bool FindAllSubstringsTest()
        {
            return false;
        }

        private static void Main(string[] args)
        {
            if (Test())
            {
                // code is executed when all is OK
                Console.WriteLine("OK");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Returns a pair of index array and corresponding sufixes.
        /// </summary>
        /// <remarks>
        /// The index array is buildt from sufix array sorted acsending. Example, {3,2,1} : {"abc","ab","a"}
        /// </remarks>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Tuple<int[], string[]> BuildSuffixArray(string text)
        {
            var size = text.Length;
            var indexes = Enumerable.Range(0, size).ToArray();
            var array = new string[size];
            for (var i = 0; i < size; i++)
                array[i] = text.Substring(i);
            Array.Sort(array, indexes);
            return new Tuple<int[], string[]>(indexes, array);
        }

        public static Tuple<int[], string[]> BuildSuffixArray(string text1, string text2)
        {
            return null;
        }
    }
}