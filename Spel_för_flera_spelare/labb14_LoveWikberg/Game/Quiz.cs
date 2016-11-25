using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg.UI_s
{
    class GameUI
    {

        ListsAndArrays list = new ListsAndArrays();
        public static int playerTurn = 0;

        public void QuestionMenu(Action easy, Action normal, Action hard, string typeOfQuestion)
        {
            bool loop = true;
            while (loop)
            {
                #region set number of questions
                int numberOfEasyQuestions = 0;
                int numberOfNormalQuestions = 0;
                int numberOfHardQuestions = 0;
                if (typeOfQuestion == "math")
                {
                    numberOfEasyQuestions = NumberOfMathQuestions(1);
                    numberOfNormalQuestions = NumberOfMathQuestions(2);
                    numberOfHardQuestions = NumberOfMathQuestions(3);
                }
                else if (typeOfQuestion == "general")
                {
                    numberOfEasyQuestions = NumberOfKnowledgeQuestions(1);
                    numberOfNormalQuestions = NumberOfKnowledgeQuestions(2);
                    numberOfHardQuestions = NumberOfKnowledgeQuestions(3);
                }
                else if (typeOfQuestion == "language")
                {
                    numberOfEasyQuestions = NumberOfLanguageQuestions(1);
                    numberOfNormalQuestions = NumberOfLanguageQuestions(2);
                    numberOfHardQuestions = NumberOfLanguageQuestions(3);
                }
                else if (typeOfQuestion == "truefalse")
                {
                    numberOfEasyQuestions = NumberOfTrueOrFalseQuestions(1);
                    numberOfNormalQuestions = NumberOfTrueOrFalseQuestions(2);
                    numberOfHardQuestions = NumberOfTrueOrFalseQuestions(3);
                }
                #endregion

                Console.Clear();
                Console.WriteLine("[1] Lätt fråga - 4p - " + numberOfEasyQuestions + " frågor kvar.");
                Console.WriteLine("[2] Medelsvår fråga - 8p - " + numberOfNormalQuestions + " frågor kvar.");
                Console.WriteLine("[3] Svår fråga - 12p - " + numberOfHardQuestions + " frågor kvar.");
                Console.WriteLine("[4] Tillbaka");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        easy();
                        loop = false;
                        break;

                    case ConsoleKey.D2:
                        normal();
                        loop = false;
                        break;

                    case ConsoleKey.D3:
                        hard();
                        loop = false;
                        break;

                    case ConsoleKey.D4:
                        loop = false;
                        break;
                }
            }
        }

        public int NumberOfMathQuestions(int difficultyInput)
        {
            IQuestions[] array = list.questionList.OfType<MathQuestion>().Where
                (math => math.AlternativeOne !=null).ToArray();

            int numberOfQuestions = 0;
            foreach (var math in array)
            {
                if (math.Difficulty == difficultyInput)
                    numberOfQuestions++;
            }

            return numberOfQuestions;
        }

        public int NumberOfKnowledgeQuestions(int difficultyInput)
        {
            IQuestions[] array = list.questionList.OfType<GeneralKnowledgeQuestion>().Where
                (general => general.AlternativeOne != null).ToArray();

            int numberOfQuestions = 0;
            foreach (var general in array)
            {
                if (general.Difficulty == difficultyInput)
                    numberOfQuestions++;
            }

            return numberOfQuestions;
        }

        public int NumberOfLanguageQuestions(int difficultyInput)
        {
            IQuestions[] array = list.questionList.OfType<LanguageQuestion>().Where
                (language => language.AlternativeOne != null).ToArray();

            int numberOfQuestions = 0;
            foreach (var language in array)
            {
                if (language.Difficulty == difficultyInput)
                    numberOfQuestions++;
            }

            return numberOfQuestions;
        }

        public int NumberOfTrueOrFalseQuestions(int difficultyInput)
        {
            IQuestions[] array = list.questionList.OfType<TrueOrFalseQuestion>().Where
                (trueFalse => trueFalse.AlternativeOne != null).ToArray();

            int numberOfQuestions = 0;
            foreach (var trueFalse in array)
            {
                if (trueFalse.Difficulty == difficultyInput)
                    numberOfQuestions++;
            }

            return numberOfQuestions;
        }


        public void MathQuestion(int difficulty)
        {
            Console.Clear();
            IQuestions[] array = list.questionList.OfType<MathQuestion>().Where
                (math => int.Equals(math.Difficulty, difficulty)).ToArray();

            if (array.Length == 0)
            {
                Console.WriteLine("Slut på frågor");
                Console.ReadKey();
            }

            else
            {
                Random random = new Random();
                int randomNumber = random.Next(0, array.Length);
                bool removeQuestion;
                removeQuestion = array[randomNumber].QuestionFuntion();

                if (removeQuestion)
                {
                    if (array[randomNumber].Difficulty == 1)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 4;

                    else if (array[randomNumber].Difficulty == 2)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 8;

                    else if (array[randomNumber].Difficulty == 3)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 12;

                    list.questionList.Remove(array[randomNumber]);
                }

                if (playerTurn == ListsAndArrays.playerArray.Length - 1)
                    playerTurn = 0;
                else
                    playerTurn++;
            }
        }

        public void GeneralKnowledgeQuestion(int difficulty)
        {
            Console.Clear();
            IQuestions[] array = list.questionList.OfType<GeneralKnowledgeQuestion>().Where
                (general => int.Equals(general.Difficulty, difficulty)).ToArray();
            if (array.Length == 0)
            {
                Console.WriteLine("Slut på frågor");
                Console.ReadKey();
            }

            else
            {
                Random random = new Random();
                int randomNumber = random.Next(0, array.Length);
                bool removeQuestion;
                removeQuestion = array[randomNumber].QuestionFuntion();

                if (removeQuestion)
                {
                    if (array[randomNumber].Difficulty == 1)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 4;

                    else if (array[randomNumber].Difficulty == 2)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 8;

                    else if (array[randomNumber].Difficulty == 3)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 12;

                    list.questionList.Remove(array[randomNumber]);
                }
                if (playerTurn == ListsAndArrays.playerArray.Length - 1)
                    playerTurn = 0;
                else
                    playerTurn++;
            }

        }

        public void LanguageQuestion(int difficulty)
        {
            IQuestions[] array = list.questionList.OfType<LanguageQuestion>().Where
                (language => int.Equals(language.Difficulty, difficulty)).ToArray();
            if (array.Length == 0)
            {
                Console.WriteLine("Slut på frågor");
                Console.ReadKey();
            }

            else
            {
                Random random = new Random();
                int randomNumber = random.Next(0, array.Length);
                bool removeQuestion;
                removeQuestion = array[randomNumber].QuestionFuntion();

                if (removeQuestion)
                {
                    if (array[randomNumber].Difficulty == 1)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 4;

                    else if (array[randomNumber].Difficulty == 2)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 8;

                    else if (array[randomNumber].Difficulty == 3)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 12;

                    list.questionList.Remove(array[randomNumber]);
                }
                if (playerTurn == ListsAndArrays.playerArray.Length - 1)
                    playerTurn = 0;
                else
                    playerTurn++;
            }
        }

        public void TrueOrFalseQuestion(int difficulty)
        {
            Console.Clear();
            IQuestions[] array = list.questionList.OfType<TrueOrFalseQuestion>().Where
                (trueFalse => int.Equals(trueFalse.Difficulty, difficulty)).ToArray();

            if (array.Length == 0)
            {
                Console.WriteLine("Slut på frågor");
                Console.ReadKey();
            }

            else
            {
                Random random = new Random();
                int randomNumber = random.Next(0, array.Length);
                bool removeQuestion;
                removeQuestion = array[randomNumber].QuestionFuntion();

                if (removeQuestion)
                {
                    if (array[randomNumber].Difficulty == 1)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 4;

                    else if (array[randomNumber].Difficulty == 2)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 8;

                    else if (array[randomNumber].Difficulty == 3)
                        ListsAndArrays.playerArray[playerTurn].SmartScale += 12;

                    list.questionList.Remove(array[randomNumber]);
                }

                if (playerTurn == ListsAndArrays.playerArray.Length - 1)
                    playerTurn = 0;
                else
                    playerTurn++;
            }
        }
    }
}
