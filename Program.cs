using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prisoners
{
    class Program
    {
        static void Main(string[] args)
        {
            Attempt1();
        }

        static void Attempt1()
        {
            var start = DateTime.Now;
            int limit = 12;
            double totalCount = Factorial(limit);
            double winners = 0;
            double count = 0;
            // Build a list of all permutations of x people.
            //foreach (var list in AllLists(limit))
            Parallel.ForEach(AllLists(limit), list =>
            {
                count++;
                // Test to see if all loops are x/2 or fewer numbers.
                var maxCycle = MaxCycle(list);
                if ( maxCycle <= limit / 2)
                {
                    winners++;
                    //Console.WriteLine($"{maxCycle}: {string.Join(", ", list)} ***");
                }
                else
                {
                    //Console.WriteLine($"{maxCycle}: {string.Join(", ", list)}");
                }
                //if (count % 1000000 == 0) Console.WriteLine($"{Math.Round(count/totalCount*10000000)/100000}%   Total: {count}   Winners: {winners}   Chance: {(winners / count) * 100}%");
            });
            Console.WriteLine($"Total: {count}");
            Console.WriteLine($"Winners: {winners}");
            Console.WriteLine($"Chance: {(winners / count) * 100}%");
            Console.WriteLine($"Total Time: {(DateTime.Now - start).TotalSeconds}s");
        }

        static int MaxCycle(List<int> list)
        {
            int max = 0;
            var copy = new List<int>(list);
            for(int x = 0; x< copy.Count; x++)
            {
                if (copy[x] > 0)
                {
                    var loopLength = CheckSpot(copy, x);
                    if (loopLength > max) max = loopLength;
                }
            }
            return max;
        }

        static int CheckSpot(List<int> list, int spot)
        {
            if (list[spot] == 0) return 0;
            else
            {
                var newSpot = list[spot]-1;
                list[spot] = 0;
                return CheckSpot(list, newSpot) + 1;

            } 
        }

        static IEnumerable<List<int>> AllLists(int count)
        {
            // Create a master list of all numbers.
            var master = new List<int>();
            // Reverse them so that the numbers come out in order for the sequences.
            for (var x = count; x>0; x--)
            {
                master.Add(x);
            }

            // Recursively return numbers
            foreach (var list in SubList(master))
            {
                yield return list;
            }

        }

        static IEnumerable<List<int>> SubList(List<int> remaining)
        {
            if (remaining.Count == 1)
            {
                yield return new List<int> { remaining[0] };
            }
            for (var pos = 0; pos < remaining.Count; pos++)
                {
                    var copy = new List<int>(remaining);
                var myNum = copy[pos];
                copy.RemoveAt(pos);
                foreach (var list in SubList(copy))
                {
                    list.Add(myNum);
                    yield return list;
                }
            }
            yield break;
        }

        static double Factorial(int x)
        {
            if (x == 0) return 1;
            return Factorial(x - 1) * x;
        }
    }
}
