using System;

namespace Rotation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n < 1 || 100 < n) return;

            var s = Console.ReadLine();
            s = s.Length > n ? s.Substring(0, n) : s;

            var m = int.Parse(Console.ReadLine());
            if (m < 1 || 100 < m) return;

            var rotations = new int[m, 3];
            for (var i = 0; i < m; i++)
            {
                var t = Console.ReadLine().Split(' ');
                var l = int.Parse(t[0]);
                var r = int.Parse(t[1]);
                var k = int.Parse(t[2]);

                var inputValid = 1 <= l && l <= r && r <= n && 1 <= k && k <= 100;

                if (inputValid)
                {
                    rotations[i, 0] = int.Parse(t[0]);
                    rotations[i, 1] = int.Parse(t[1]);
                    rotations[i, 2] = int.Parse(t[2]);
                }
                else
                    return;
            }

            for (var i = 0; i < rotations.Rank; i++)
                s = Rotate(rotations, i, s);

            Console.WriteLine(s);
        }

        private static string Rotate(int[,] rotations, int i, string s)
        {
            var start = rotations[i, 0] - 1;
            var end = rotations[i, 1] - 1;
            if (start == end) return s;

            var times = rotations[i, 2];
            var cutLength = end - start + 1;
            var sub = s.Substring(start, cutLength);
            var mod = times%sub.Length;
            if (mod == 0) return s;

            for (var j = 0; j < mod; j++)
                sub = sub[sub.Length - 1] + sub.Substring(0, sub.Length - 1);
            s = s.Remove(start, cutLength);
            s = s.Insert(start, sub);
            return s;
        }

        public static string Test()
        {
            var s = "abcde";
            var rotations = new int[2, 3];
            rotations[0, 0] = 2;
            rotations[0, 1] = 4;
            rotations[0, 2] = 1;
            rotations[1, 0] = 1;
            rotations[1, 1] = 5;
            rotations[1, 2] = 2;

            for (var i = 0; i < rotations.Rank; i++)
                s = Rotate(rotations, i, s);

            return s;
        }

        public static string Test2()
        {
            var s = "okbfkkvdis";
            var rotations = new int[20, 3];

            rotations[0, 0] = 7;
            rotations[0, 1] = 10;
            rotations[0, 2] = 63;

            rotations[1, 0] = 8;
            rotations[1, 1] = 8;
            rotations[1, 2] = 7;

            rotations[2, 0] = 7;
            rotations[2, 1] = 10;
            rotations[2, 2] = 58;

            rotations[3, 0] = 4;
            rotations[3, 1] = 10;
            rotations[3, 2] = 26;

            rotations[4, 0] = 3;
            rotations[4, 1] = 5;
            rotations[4, 2] = 75;

            rotations[5, 0] = 3;
            rotations[5, 1] = 4;
            rotations[5, 2] = 60;

            rotations[6, 0] = 6;
            rotations[6, 1] = 9;
            rotations[6, 2] = 21;

            rotations[7, 0] = 1;
            rotations[7, 1] = 10;
            rotations[7, 2] = 15;

            rotations[8, 0] = 3;
            rotations[8, 1] = 3;
            rotations[8, 2] = 81;

            rotations[9, 0] = 7;
            rotations[9, 1] = 10;
            rotations[9, 2] = 20;

            rotations[10, 0] = 7;
            rotations[10, 1] = 8;
            rotations[10, 2] = 37;

            rotations[11, 0] = 2;
            rotations[11, 1] = 3;
            rotations[11, 2] = 34;

            rotations[12, 0] = 3;
            rotations[12, 1] = 9;
            rotations[12, 2] = 8;

            rotations[13, 0] = 2;
            rotations[13, 1] = 2;
            rotations[13, 2] = 63;

            rotations[14, 0] = 6;
            rotations[14, 1] = 10;
            rotations[14, 2] = 1;

            rotations[15, 0] = 1;
            rotations[15, 1] = 8;
            rotations[15, 2] = 95;

            rotations[16, 0] = 5;
            rotations[16, 1] = 7;
            rotations[16, 2] = 94;

            rotations[17, 0] = 3;
            rotations[17, 1] = 4;
            rotations[17, 2] = 27;

            rotations[18, 0] = 5;
            rotations[18, 1] = 7;
            rotations[18, 2] = 32;

            rotations[19, 0] = 4;
            rotations[19, 1] = 7;
            rotations[19, 2] = 60;

            for (var i = 0; i < rotations.GetLength(0); i++)
                s = Rotate(rotations, i, s);

            return s;
        }
    }
}