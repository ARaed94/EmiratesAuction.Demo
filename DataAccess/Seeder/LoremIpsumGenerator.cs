using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Seeder
{
    public static class LoremIpsumGenerator
    {
        public static string Generate(int minWords, int maxWords, int minSentences, int maxSentences, int numberOfLines, Language language = Language.English)
        {
            List<string> words = new List<string>();
            switch (language)
            {
                case Language.Arabic:
                    words = new[] { "لوريم", "ايبسوم", "دولار", "سيت", "أميت", "كونسيكتيتور",
                "أدايبا", "يسكينج", "أليايت", "سيت", "ساينت", "لابوريوم", "ديواس",
                "فوليوباتاتيم", "كيواي", "نوستريد", "فينايم", "أليكيوب", "نيسي", "كيولبا" }.ToList();
                    break;
                case Language.English:
                    words = new[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat" }.ToList();
                    break;
                default:
                    break;
            }

            Random random = new Random();
            int numberOfSentences = random.Next(maxSentences - minSentences) + minSentences;
            int numberOfWords = random.Next(maxWords - minWords) + minWords;

            StringBuilder stringBuilder = new StringBuilder();
            for (int lineIndex = 0; lineIndex < numberOfLines; lineIndex++)
            {
                for (int sentenceIndex = 0; sentenceIndex < numberOfSentences; sentenceIndex++)
                {
                    for (int wordIndex = 0; wordIndex < numberOfWords; wordIndex++)
                    {
                        if (wordIndex > 0)
                        {
                            stringBuilder.Append(" ");
                        }
                        string word = words[random.Next(words.Count)];
                        if (wordIndex == 0)
                        {
                            word = word.Substring(0, 1).Trim().ToUpper() + word.Substring(1);
                        }
                        stringBuilder.Append(word);
                    }
                    stringBuilder.Append(". ");
                }
                if (lineIndex < numberOfLines - 1) stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
