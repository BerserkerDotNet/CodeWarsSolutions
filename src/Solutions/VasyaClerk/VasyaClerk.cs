using Solutions.Infrastructure;
using System.Linq;

namespace Solutions.VasyaClerk
{
    /*
        The new "Avengers" movie has just been released! There are a lot of people at the cinema box office standing in a huge line. Each of them has a single 100, 50 or 25 dollars bill. An "Avengers" ticket costs 25 dollars.
        Vasya is currently working as a clerk. He wants to sell a ticket to every single person in this line.
        Can Vasya sell a ticket to each person and give the change if he initially has no money and sells the tickets strictly in the order people follow in the line?
        Return YES, if Vasya can sell a ticket to each person and give the change with the bills he has at hand at that moment. Otherwise return NO.
     */
    public class VasyaClerk : ISolution
    {
        public const string Yes = "YES";
        public const string No = "NO";
        public string DisplayName => "Vasya Clerk";

        public void Execute(IHost host)
        {
            var data = host.Read<string>("Enter numbers 25, 50 or 100, separated by a space:");
            var numbers = data.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = CanSellToAll(numbers);
            host.Show($"Clerk replies: {result}");
        }

        public string CanSellToAll(int[] peopleInLine)
        {
            if (!peopleInLine.Any())
                return No;

            var twentyfiveCount = 0;
            var fiftyCount = 0;
            foreach (var person in peopleInLine)
            {
                if (person == 100)
                {
                    if (fiftyCount > 0 && twentyfiveCount > 0)
                    {
                        fiftyCount--;
                        twentyfiveCount--;
                    }
                    else if (twentyfiveCount >= 3)
                    {
                        twentyfiveCount -= 3;
                    }
                    else
                    {
                        return No;
                    }

                }
                else if (person == 25)
                {
                    twentyfiveCount++;
                }
                else if (person == 50)
                {
                    if (twentyfiveCount > 0)
                    {
                        twentyfiveCount--;
                        fiftyCount++;
                    }
                    else
                    {
                        return No;
                    }
                }
            }

            return Yes;
        }
    }
}
