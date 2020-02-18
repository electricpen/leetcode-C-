using System;

namespace _3_Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testStrings ={ "abcabc", " ", "pwwkew" };
            RenderAssertion(testStrings[0], lengthOfLongestSubstring(testStrings[0]), 3);
            RenderAssertion(testStrings[1], lengthOfLongestSubstring(testStrings[1]), 1);
            RenderAssertion(testStrings[2], lengthOfLongestSubstring(testStrings[2]), 3);
        }

        static int lengthOfLongestSubstring(string s)
        {
            int highestCount = 0;
            int currentCount = 0;
            string longestSubstring = "";

            // for each starting letter
            for (int i = 0; i < s.Length; i++)
            {
                string substring = s[i].ToString();
                // iterate over each subsequent letter until a duplicate is found
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (substring.Contains(s[j]))
                    {
                        currentCount = substring.Length;
                        break;
                    } else
                    {
                        substring += s[j];
                    }
                }
                // count how long the substring was
                currentCount = substring.Length;
                // compare to highest count, if greater replace its value with current count
                if (currentCount > highestCount)
                {
                    highestCount = currentCount;
                    longestSubstring = substring;
                }
            }

            Console.WriteLine($">>> The longest substring for {s} is {longestSubstring} which is {highestCount} letters long <<<");
            return highestCount;
        }

        static void RenderAssertion(string testString, int result, int expected)
        {
            string testResult = "TEST for " + testString + " ";
            testResult += result == expected ? "PASSED" : "FAILED";
            Console.WriteLine($"{testResult}! Expected {expected} and got {result}.");
        }
    }
}
