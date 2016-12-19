using labb14_LoveWikberg.PropertyClasses;
using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace labb14_LoveWikberg
{
    class ListsAndArrays
    {
        public static Node[] Grid;

        public static Player[] playerArray;

        public List<IQuestions> questionList = new List<IQuestions>
        {
            new MathQuestion { Question = "50 / 0,5 =", Answer = 1, Difficulty = 1, AlternativeOne = "100", AlternativeTwo = "25", AlternativeThree = "2"},
            new MathQuestion { Question = "8 * 7 =", Answer = 2, Difficulty = 1, AlternativeOne = "57", AlternativeTwo = "56", AlternativeThree = "58"},
            new MathQuestion { Question = "(5^2 * 3) / (1,5 * 2) =", Answer = 1, Difficulty = 2, AlternativeOne = "25", AlternativeTwo = "26", AlternativeThree = "24,5", AlternativeFour = "25,5"},
            new MathQuestion { Question = "-3x + 5 * 2x =", Answer = 3, Difficulty = 2, AlternativeOne = "-6x + 5", AlternativeTwo = "−3x + 10x", AlternativeThree = "7x", AlternativeFour = "3x + 10x", AlternativeFive = "-6x + 10x"},
            new MathQuestion { Question = "x = 2 & y = 1\n5x^(2*3) + (5y + 5y)^2 =", Answer = 4, Difficulty = 3, AlternativeOne = "100 100", AlternativeTwo = "10 100", AlternativeThree = "42 000", AlternativeFour = "420", AlternativeFive = "150"},
            new MathQuestion { Question = "Vilket värde har x om 1000x – 100 = 1 + 495x", Answer = 5, Difficulty = 3, AlternativeOne = "0,4", AlternativeTwo = "4,2", AlternativeThree = "0,03", AlternativeFour = "1,5", AlternativeFive = "0,2" },
            new MathQuestion { Question =  "(2000 * 0,2) / 4 =", Answer = 4, Difficulty = 1, AlternativeOne = "1000", AlternativeTwo = "0,05", AlternativeThree = "10,25", AlternativeFour = "100"},
            new MathQuestion { Question = "Vad är x om x^2 - 6x + 8 = 0?", Answer = 1, Difficulty = 2, AlternativeOne = "2 eller 4", AlternativeTwo = "2 eller 6", AlternativeThree = "2 eller 8" },
            new MathQuestion { Question = "(4x^2 * 4x^2) / x^4 =", Answer = 5, Difficulty = 3, AlternativeOne = "8x", AlternativeTwo = "4x^2", AlternativeThree = "16x", AlternativeFour = "8", AlternativeFive = "16" },
            new MathQuestion { Question = "10^6 =", Answer = 2, Difficulty = 1, AlternativeOne = "100000", AlternativeTwo = "1000000", AlternativeThree = "10000000" },
            new MathQuestion { Question = "Hur många procent är 210 av 700?", Answer = 2, Difficulty = 2, AlternativeOne = "25%", AlternativeTwo = "30%", AlternativeThree = "35%", AlternativeFour = "40%"},

            new GeneralKnowledgeQuestion { Question = "Två av de tre största cykelloppen i världen heter Tour de France och Vuelta a Espana. Vad heter det tredje?", Answer = 3, Difficulty = 2, AlternativeOne = "Afoso collina", AlternativeTwo = "Tour d´bicicletta", AlternativeThree = "Giro d´Italia", AlternativeFour = "Es grande rotonda", AlternativeFive = "Asini d´Fresco" },
            new GeneralKnowledgeQuestion { Question = "Vems ansiktsdrag fastnade enligt legenden på Veronicas svetteduk?", Answer = 1, Difficulty = 3, AlternativeOne = "Jesus", AlternativeTwo = "Alexander den store", AlternativeThree = "Moder Teresa", AlternativeFour = "Profeten Muhammed", AlternativeFive = "Julius Caesar" },
            new GeneralKnowledgeQuestion { Question = "Under vilket århundrade levde Anders Celsius?", Answer = 2, Difficulty = 2, AlternativeOne = "1600-talet", AlternativeTwo = "1700-talet", AlternativeThree = "1800-talet" },
            new GeneralKnowledgeQuestion { Question = "Vad är Kreml?", Answer = 5, Difficulty = 1, AlternativeOne = "En rysk kötträtt", AlternativeTwo = "En hatt som bärs av den ryska militären", AlternativeThree = "Statlig propaganda", AlternativeFour = "Det ryska ordet för president", AlternativeFive = "Rysslands maktcentrum" },
            new GeneralKnowledgeQuestion { Question = "Vilket år inträffade Sovjetunionens sammanbrott?", Answer = 3, Difficulty = 1, AlternativeOne = "1993", AlternativeTwo = "1992", AlternativeThree = "1991" },
            new GeneralKnowledgeQuestion { Question = "Vilken allsvensk klubb vann sin första titel någonsin då man 2016 vann mot Malmö FF i Svenska Cupen?", Answer = 1, Difficulty = 2, AlternativeOne = "BK Häcken", AlternativeTwo = "Falkenberg FF", AlternativeThree = "Östersund FK", AlternativeFour = "GIF Sundsvall"},
            new GeneralKnowledgeQuestion { Question = "Vilket land kommer sångaren Rihanna ifrån?", Answer = 5, Difficulty = 2, AlternativeOne = "Jamaica", AlternativeTwo = "Canada", AlternativeThree = "Nicaragua", AlternativeFour = "Trinidad och Tobago", AlternativeFive = "Barbados" },
            new GeneralKnowledgeQuestion { Question = "Vilken stad/ort ligger INTE i Närke?", Answer = 4, Difficulty = 3, AlternativeOne = "Örebro", AlternativeTwo = "Kilsmo", AlternativeThree = "Kumla", AlternativeFour = "Hallstavik", AlternativeFive = "Glanshammar" },
            new GeneralKnowledgeQuestion { Question = "I vilken stad är programledaren Fredrik Skavlan född?", Answer = 1, Difficulty = 3, AlternativeOne = "Oslo", AlternativeTwo = "Bergen", AlternativeThree = "Haugesund", AlternativeFour = "Trondheim", AlternativeFive = "Ålesund" },
            new GeneralKnowledgeQuestion { Question = "Vad heter den fd. argentinska fotbollsspelaren Diego Maradona i mellannamn?", Answer = 3, Difficulty = 2, AlternativeOne = "Adolfo", AlternativeTwo = "Abelardo", AlternativeThree = "Armando" },
            new GeneralKnowledgeQuestion { Question = "Vilket av följande länder gränsar till den Demokratiska republiken Kongo?", Answer = 2, Difficulty = 2, AlternativeOne = "Kamerun", AlternativeTwo = "Sydsudan", AlternativeThree = "Malawi"},
            new GeneralKnowledgeQuestion { Question = "Vilken av följande nötter har högst proteinhalt?", Answer = 4, Difficulty = 2, AlternativeOne = "Mandel", AlternativeTwo = "Hasselnöt", AlternativeThree = "Valnöt", AlternativeFour = "Jordnöt" },
            new GeneralKnowledgeQuestion { Question = "Var ligger Egeiska havet?", Answer = 1, Difficulty = 3, AlternativeOne = "Mellan Grekland och Turkiet", AlternativeTwo = "Mellan Italien och Kroatien", AlternativeThree = "Mellan Tunisien och Libyen", AlternativeFour = "Mellan Spanien och Marocko", AlternativeFive = "Mellan Sardinien och det italienska fastlandet"},
            new GeneralKnowledgeQuestion { Question = "Vilket band släppte 1977 singeln \"Hotel California\"?", Answer = 5, Difficulty = 2, AlternativeOne = "The Rocky Mountain Bighorn Sheep", AlternativeTwo = "The Hawks", AlternativeThree = "The Western Lowland Gorillas", AlternativeFour = "The Manatees", AlternativeFive = "The Eagles"},
            new GeneralKnowledgeQuestion { Question = "Hur många gånger nämns \"Green light\" i bandet The Police låt \"Roxanne\"?", Answer = 1, Difficulty = 2, AlternativeOne = "0", AlternativeTwo = "7", AlternativeThree = "18", AlternativeFour = "34"},
            new GeneralKnowledgeQuestion { Question = "I vilket lag spelar Zlatan Ibrahimovic för närvarande?", Answer = 2, Difficulty = 1, AlternativeOne = "Barcelona", AlternativeTwo = "Manchester United", AlternativeThree = "Paris Saint German (PSG)" },
            new GeneralKnowledgeQuestion { Question = "Hur lång tid tar det för solens ljus att nå jorden?", Answer = 2, AlternativeOne = "8 sekunder", AlternativeTwo = "8 minuter", AlternativeThree = "8 timmar" },

            new LanguageQuestion { Question = "Vad är Permafrost?", Answer = 1, Difficulty = 1, AlternativeOne = "Ständig tjäle", AlternativeTwo = "Klimatförändring", AlternativeThree = "Snöfri vinter", AlternativeFour = "Glaciär i rörelse", AlternativeFive = "Bottenfrusen sjö" },
            new LanguageQuestion { Question = "Vad betyder Manierad?", Answer = 3, Difficulty = 3, AlternativeOne = "Trög", AlternativeTwo = "Modig", AlternativeThree = "Konstlad", AlternativeFour = "Begåvad", AlternativeFive = "Närgången" },
            new LanguageQuestion { Question = "Vad menas med att prata bredvid mun?", Answer = 3, Difficulty = 2, AlternativeOne = "Vilseleda någon", AlternativeTwo = "Ljuga", AlternativeThree = "Försäga sig", AlternativeFour = "Härma", AlternativeFive = "Avbryta någon" },
            new LanguageQuestion { Question = "Vad menas med \"Call for papers\"", Answer = 4, Difficulty = 3, AlternativeOne = "Samla in papper vid provskriving", AlternativeTwo = "Slang för skattedeklaration", AlternativeThree = "Granskning av legitimation", AlternativeFour = "Företagsinbjudan"},
            new LanguageQuestion { Question = "Vad betyder \"Compliance\"", Answer = 2, Difficulty = 1, AlternativeOne = "Medhåll", AlternativeTwo = "Anpassning till norm/regel", AlternativeThree = "Ersätta"},
            new LanguageQuestion { Question = "Vad står den engelska förkortningen \"CRM\" för?", Answer = 3, Difficulty = 2, AlternativeOne = "Costomization of Realtime software and Microdata, ", AlternativeTwo = "Critical Recadency Management", AlternativeThree = "Custumer Relationship Management", AlternativeFour = "Computer Repair & Maintenance" },
            new LanguageQuestion { Question = "Vad kallas tornet i schack på engelska?", Answer = 2, Difficulty = 3, AlternativeOne = "Tower", AlternativeTwo = "Rook", AlternativeThree = "Outpost", AlternativeFour = "Stout", AlternativeFive = "Mound"},
            new LanguageQuestion { Question = "Vilket av följande betyder \"sot\" på engelska?", Answer = 3, Difficulty = 2, AlternativeOne = "Muck", AlternativeTwo = "Squalor", AlternativeThree = "Grime" },
            new LanguageQuestion { Question = "Vad står gamingtermen \"GG\" för?", Answer = 4, Difficulty = 1, AlternativeOne = "Go go", AlternativeTwo = "Good grace", AlternativeThree = "Gang game", AlternativeFour = "Good game", AlternativeFive = "Grand gay"},
            new LanguageQuestion { Question = "Vad betyder det latinska ordet \"insula\"?", Answer = 4, Difficulty = 2, AlternativeOne = "Sko", AlternativeTwo = "Vatten", AlternativeThree = "Krona", AlternativeFour = "Ö"  },
            new LanguageQuestion { Question = "Vilket ord avslutar vanligen talesättet \"Kärt barn har många...\"?", Answer = 1, Difficulty = 1, AlternativeOne = "namn", AlternativeTwo = "smeknamn", AlternativeThree = "efternamn", AlternativeFour = "vänner", AlternativeFive = "" },

            new TrueOrFalseQuestion { Question = "Blekinge ligger i Skåne", Answer = 1, Difficulty = 1, AlternativeOne = "sant", AlternativeTwo = "falskt"},
            new TrueOrFalseQuestion { Question = "Grundaren av företaget Apple heter Steve Chops", Answer = 2, Difficulty = 1, AlternativeOne = "sant", AlternativeTwo = "falskt" },
            new TrueOrFalseQuestion { Question = "Uruguays flagga har en måne i sig", Answer = 2, Difficulty = 2, AlternativeOne = "sant", AlternativeTwo = "falskt" },
            new TrueOrFalseQuestion { Question = "Den kemiska förkortningen för vatten är HO2", Answer = 2, Difficulty = 1, AlternativeOne = "sant", AlternativeTwo = "falskt"},
            new TrueOrFalseQuestion { Question = "Kambodjas huvudstad heter Phnom Penh", Answer = 1, Difficulty = 3, AlternativeOne= "sant", AlternativeTwo = "falskt" },
            new TrueOrFalseQuestion { Question = "Sveriges nuvarande kung är Carl XVI Gustaf", Answer = 1, Difficulty = 2, AlternativeOne = "sant", AlternativeTwo = "falskt" },
            new TrueOrFalseQuestion { Question = "Markoolio är född i Sverige", Answer = 2, Difficulty = 2, AlternativeOne = "sant", AlternativeTwo = "falskt" },
            new TrueOrFalseQuestion { Question = "Dagens nyheters chefredaktör Peter Wolodarski är även allmänt känd som \"Mr Gnesta\"", Answer = 2, Difficulty = 3, AlternativeOne = "sant", AlternativeTwo = "falskt" }

        };

    }
}
