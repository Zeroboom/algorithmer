// https://www.acmicpc.net/problem/2798
using System;

namespace blackjack
{
    class Program
    {
        const int MinCardCount = 3;
        const int MaxCardCount = 100;
        const int MinGoalNumber = 10;
        const int MaxGoalNumber = 300000;
        const int CardChoiceChance = 3;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var split = input.Split(' ');

            int cardCount = int.Parse(split[0]);
            int goalNumber = int.Parse(split[1]);

            if (cardCount < MinCardCount || cardCount > MaxCardCount)
                throw new Exception();

            if (goalNumber < MinGoalNumber || goalNumber > MaxGoalNumber)
                throw new Exception();

            int[] arr = new int[cardCount];

            input = Console.ReadLine();
            var numberWords = input.Split(' ');
            for (int i = 0; i < cardCount; ++i)
                arr[i] = int.Parse(numberWords[i]);

            Console.WriteLine(GetResult(goalNumber, arr));
        }

        static int GetResult(int goalNumber, int[] numbers)
        {
            int max = 0;
            int sum = 0;
            int numbersCount = numbers.Length;
            for (int i = 0; i < numbersCount - 2; ++i)
            {
                for (int j = i + 1; j < numbersCount - 1; ++j)
                {
                    for (int k = j + 1; k < numbersCount; ++k)
                    {
                        sum = numbers[i] + numbers[j] + numbers[k];
                        if (sum <= goalNumber && sum > max)
                            max = sum;

                        if (max == goalNumber)
                            return max;
                    }
                }
            }

            return max;
        }
    }
}
