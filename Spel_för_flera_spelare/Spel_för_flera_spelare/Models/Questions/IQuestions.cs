using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    public interface IQuestions
    {
        string Question { get; set; }
        int Difficulty { get; set; }
        int Answer { get; set; }
        int NumberOfCorrectAnswers { get; set; }
        int NumberOfInCorrectAnswers { get; set; }
        bool QuestionFuntion();

        string AlternativeOne { get; set; }
        string AlternativeTwo { get; set; }
        string AlternativeThree { get; set; }
        string AlternativeFour { get; set; }
        string AlternativeFive { get; set; }
    }
}
