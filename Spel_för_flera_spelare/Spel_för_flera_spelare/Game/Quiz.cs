using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using Newtonsoft.Json;

namespace labb14_LoveWikberg.UI_s
{
    class Quiz
    {
        Timer aTimer = new Timer();
        ListsAndArrays list = new ListsAndArrays();
        IQuestions[] numberOfQuestionsArray;
        public static bool TimerEnd;
        int timerTime;

        public Quiz()
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public void QuestionMenu(Action easy, Action normal, Action hard, string typeOfQuestion)
        {
            bool loop = true;
            while (loop)
            {
                #region set number of questions
                int numberOfEasyQuestions = 0;
                int numberOfNormalQuestions = 0;
                int numberOfHardQuestions = 0;
                if (typeOfQuestion == "Matematik")
                {
                    numberOfEasyQuestions = GetNumberOfQuestions(1, typeOfQuestion);
                    numberOfNormalQuestions = GetNumberOfQuestions(2, typeOfQuestion);
                    numberOfHardQuestions = GetNumberOfQuestions(3, typeOfQuestion);
                }
                else if (typeOfQuestion == "Allmänbildning")
                {
                    numberOfEasyQuestions = GetNumberOfQuestions(1, typeOfQuestion);
                    numberOfNormalQuestions = GetNumberOfQuestions(2, typeOfQuestion);
                    numberOfHardQuestions = GetNumberOfQuestions(3, typeOfQuestion);
                }
                else if (typeOfQuestion == "Språk")
                {
                    numberOfEasyQuestions = GetNumberOfQuestions(1, typeOfQuestion);
                    numberOfNormalQuestions = GetNumberOfQuestions(2, typeOfQuestion);
                    numberOfHardQuestions = GetNumberOfQuestions(3, typeOfQuestion);
                }
                else if (typeOfQuestion == "Sant eller falskt")
                {
                    numberOfEasyQuestions = GetNumberOfQuestions(1, typeOfQuestion);
                    numberOfNormalQuestions = GetNumberOfQuestions(2, typeOfQuestion);
                    numberOfHardQuestions = GetNumberOfQuestions(3, typeOfQuestion);
                }
                #endregion

                TimerEnd = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(typeOfQuestion);
                Console.ResetColor();
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

        public void GenerateQuestion(int difficulty, string typeOfQuestion)
        {

            IQuestions[] array = GetArray(difficulty, typeOfQuestion);

            if (array.Length == 0)
            {
                Console.WriteLine("Slut på frågor");
                Console.ReadKey();
            }

            else
            {
                Random random = new Random();
                int randomNumber = random.Next(0, array.Length);
                timerTime = 10 * difficulty; // Set timer

                aTimer.Interval = 1000;
                aTimer.Enabled = true;

                bool question;
                question = array[randomNumber].QuestionFuntion();

                if (question)
                {
                    aTimer.Enabled = false;
                    aTimer.Close();

                    if (array[randomNumber].Difficulty == 1)
                        ListsAndArrays.playerArray[GameClient.playerTurn].SmartScale += 4;

                    else if (array[randomNumber].Difficulty == 2)
                        ListsAndArrays.playerArray[GameClient.playerTurn].SmartScale += 8;

                    else if (array[randomNumber].Difficulty == 3)
                        ListsAndArrays.playerArray[GameClient.playerTurn].SmartScale += 12;

                    #region Save statistics

                    //list.questionList[randomNumber].NumberOfInCorrectAnswers += 5;
                    //var directory = Environment.CurrentDirectory;
                    //var file = String.Format("{0}{1}", directory, "\\data.json");

                    //if (!Directory.Exists(directory))
                    //    Directory.CreateDirectory(directory);

                    //if (!File.Exists(file))
                    //    File.Create(file);

                    //string jsonString = JsonConvert.SerializeObject(ListsAndArrays.listToSaveAndLoad);

                    //File.WriteAllText(file, jsonString);
                    #endregion 
                    // In progress

                    list.questionList.Remove(array[randomNumber]);
                    Console.ReadLine();
                }

                else if (!question)
                {
                    aTimer.Enabled = false;
                    aTimer.Close();

                    #region Save statistics

                    //list.questionList[randomNumber].NumberOfInCorrectAnswers++;
                    //var directory = Environment.CurrentDirectory;
                    //var file = String.Format("{0}{1}", directory, "\\data.json");

                    //if (!Directory.Exists(directory))
                    //    Directory.CreateDirectory(directory);

                    //if (!File.Exists(file))
                    //    File.Create(file);

                    //string jsonString = JsonConvert.SerializeObject(ListsAndArrays.listToSaveAndLoad);

                    //File.WriteAllText(file, jsonString);
                    #endregion
                    // In progress

                    Console.ReadLine();
                }

                if (GameClient.playerTurn == ListsAndArrays.playerArray.Length - 1)
                    GameClient.playerTurn = 0;
                else
                    GameClient.playerTurn++;
            }
        }

        IQuestions[] GetArray(int difficulty, string typeOfQuestion)
        {
            if (typeOfQuestion == "math")
            {
                Console.Clear();
                IQuestions[] array = list.questionList.OfType<MathQuestion>().Where
                    (math => int.Equals(math.Difficulty, difficulty)).ToArray();
                return array;
            }
            else if (typeOfQuestion == "general")
            {
                Console.Clear();
                IQuestions[] array = list.questionList.OfType<GeneralKnowledgeQuestion>().Where
                    (knowledge => int.Equals(knowledge.Difficulty, difficulty)).ToArray();
                return array;
            }
            else if (typeOfQuestion == "language")
            {
                Console.Clear();
                IQuestions[] array = list.questionList.OfType<LanguageQuestion>().Where
                    (language => int.Equals(language.Difficulty, difficulty)).ToArray();
                return array;
            }
            else if (typeOfQuestion == "trueorfalse")
            {
                Console.Clear();
                IQuestions[] array = list.questionList.OfType<TrueOrFalseQuestion>().Where
                    (trueorfalse => int.Equals(trueorfalse.Difficulty, difficulty)).ToArray();
                return array;
            }
            else
                return null;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timerTime--;
            if (timerTime > 0)
                VisualsAndOther.WriteAt("Tid kvar: " + timerTime + "    Svar: ", 0, 10);

            else if (timerTime <= 0)
            {
                Console.Clear();
                Console.WriteLine("Tiden är slut!");
                TimerEnd = true;
                aTimer.Stop();
                aTimer.Close();
            }
        }

        int GetNumberOfQuestions(int difficulty, string typeOfQuestion)
        {
            if (typeOfQuestion == "Matematik")
            {
                numberOfQuestionsArray = list.questionList.OfType<MathQuestion>().Where
                (math => int.Equals(math.Difficulty, difficulty)).ToArray();
            }
            else if (typeOfQuestion == "Allmänbildning")
            {
                numberOfQuestionsArray = list.questionList.OfType<GeneralKnowledgeQuestion>().Where
                (general => int.Equals(general.Difficulty, difficulty)).ToArray();
            }
            else if (typeOfQuestion == "Språk")
            {
                numberOfQuestionsArray = list.questionList.OfType<LanguageQuestion>().Where
                (language => int.Equals(language.Difficulty, difficulty)).ToArray();
            }
            else if (typeOfQuestion == "Sant eller falskt")
            {
                numberOfQuestionsArray = list.questionList.OfType<TrueOrFalseQuestion>().Where
                (trueFalse => int.Equals(trueFalse.Difficulty, difficulty)).ToArray();
            }

            return numberOfQuestionsArray.Length;
        }
    }
}
