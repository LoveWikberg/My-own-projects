using labb14_LoveWikberg.UI_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg.Questions
{
    class LanguageQuestion : IQuestions
    {
        public string Question { get; set; }

        public int Difficulty { get; set; }

        public int NumberOfCorrectAnswers { get; set; }

        public int NumberOfInCorrectAnswers { get; set; }

        public bool QuestionFuntion()
        {
            Console.Clear();
            Console.WriteLine(Question + "\n");
            Console.WriteLine("1. " + AlternativeOne);
            Console.WriteLine("2. " + AlternativeTwo);
            Console.WriteLine("3. " + AlternativeThree);
            if (AlternativeFour != null)
                Console.WriteLine("4. " + AlternativeFour);
            if (AlternativeFive != null)
                Console.WriteLine("5. " + AlternativeFive);

            int choice;
            bool success = int.TryParse(Console.ReadLine(), out choice);
            if (choice == Answer && Quiz.TimerEnd != true)
            {
                Console.WriteLine("Rätt!");
                return true;
            }
            else if (choice != Answer && Quiz.TimerEnd != true)
            {
                Console.WriteLine("Fel!");
                return false;
            }
            else
                return false;

        }

        public int Answer { get; set; }

        public string AlternativeOne { get; set; }
        public string AlternativeTwo { get; set; }
        public string AlternativeThree { get; set; }
        public string AlternativeFour { get; set; }
        public string AlternativeFive { get; set; }
    }
}
