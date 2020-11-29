using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infojegyzet_Morze
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morseLettersLines = File.ReadAllLines("C:/Users/Glück Gábor/source/repos/Infojegyzet_Morze/Infojegyzet_Morze/morzeabc.txt", Encoding.UTF8);
            List<Morzebetu> morzeBetuList = new List<Morzebetu>();
            

            for (int i = 1; i < morseLettersLines.Length; i++)
            {
                morzeBetuList.Add(new Morzebetu(morseLettersLines[i]));
            }

            harmadikFeladat(morzeBetuList);

            negyedikFeladat(morzeBetuList);


            //otodikfeladat
            string[] quotationsLines = File.ReadAllLines("C:/Users/Glück Gábor/source/repos/Infojegyzet_Morze/Infojegyzet_Morze/morze.txt", Encoding.UTF8);
            List<MorzeIdezet> morzequotationsList = new List<MorzeIdezet>();

            for (int i = 0; i < quotationsLines.Length; i++)
            {
                morzequotationsList.Add(new MorzeIdezet(quotationsLines[i])); 
            }

            //hatodikfeladat
            //string codeToBeConverted = "";
            //Morze2Szoveg(codeToBeConverted, morzeBetuList);


            hetedikFeladat(morzequotationsList, morzeBetuList);

            nyolcadikFeladat(morzequotationsList, morzeBetuList);

            kilencedikFeladat(morzequotationsList, morzeBetuList);

            tizedikFeladat(morzequotationsList, morzeBetuList);

            Console.ReadKey();
        }

        private static void tizedikFeladat(List<MorzeIdezet> morzequotationsList, List<Morzebetu> morzeBetuList)
        {
            //File.Create("C:/Users/Glück Gábor/source/repos/Infojegyzet_Morze/Infojegyzet_Morze/forditas.txt");

            using (StreamWriter sw = new StreamWriter("C:/Users/Glück Gábor/source/repos/Infojegyzet_Morze/Infojegyzet_Morze/forditas.txt", true))
            {
                for (int i = 0; i < morzequotationsList.Count; i++)
                {
                    sw.WriteLine("{0}: {1}", Morze2Szoveg(morzequotationsList[i].szerzo, morzeBetuList), Morze2Szoveg(morzequotationsList[i].idezet, morzeBetuList));
                }
                sw.Close();
            }
        }

        private static void kilencedikFeladat(List<MorzeIdezet> morzequotationsList, List<Morzebetu> morzeBetuList)
        {
            Console.WriteLine();
            Console.Write("9. feladat: ");
            Console.WriteLine("Arisztotelész idézetei: ");

            foreach (var morzequotation in morzequotationsList)
            {
                string authorToBeChecked = Morze2Szoveg(morzequotation.szerzo, morzeBetuList);
                //to be refactored
                if (authorToBeChecked == "ARISZTOTELÉSZ")
                {
                   Console.Write("-");
                   Console.Write(Morze2Szoveg(morzequotation.idezet, morzeBetuList));
                   Console.WriteLine("");
                }
            }
        }

        private static void hetedikFeladat(List<MorzeIdezet> morzequotationsList, List<Morzebetu> morzeBetuList)
        {
            Console.Write("7. feladat: Az első idézet szerzője: ");
            Console.Write(Morze2Szoveg(morzequotationsList[0].szerzo, morzeBetuList));
            Console.WriteLine("");
        }

        private static void nyolcadikFeladat(List<MorzeIdezet> morzequotationsList, List<Morzebetu> morzeBetuList)
        {
            Console.Write("8. feladat: ");
            Console.Write("A leghosszabb idézet szerzője és az idézet: ");

            int longestQuotation = 0;
            string longestQuotationAuthor = "";
            string longestQuotationText = "";            

            for (int i = 0; i < morzequotationsList.Count; i++)
            {
                if (longestQuotation <= morzequotationsList[i].idezet.Length)
                {
                    longestQuotation = morzequotationsList[i].idezet.Length;
                    longestQuotationAuthor = morzequotationsList[i].szerzo;
                    longestQuotationText = morzequotationsList[i].idezet;
                }
            }

            Console.Write(Morze2Szoveg(longestQuotationAuthor, morzeBetuList));
            Console.Write(": ");
            Console.WriteLine(Morze2Szoveg(longestQuotationText, morzeBetuList));
        }

        private static string Morze2Szoveg(string codeToBeConverted, List<Morzebetu> morzeBetuList)
        {
            //Creating storage for cyphered and decyphered text
            string resultText = "";
            List<string> toBeConvertedLettersList = new List<string>();

            //Finding and converting boundaries of decypherable chunks
            //WordSeparator
            codeToBeConverted = codeToBeConverted.Replace("       ", "÷");
            //letterSeparator
            codeToBeConverted = codeToBeConverted.Replace("   ", "¤");

            string[] codeToBeConvertedWordArray = codeToBeConverted.Split("÷");
            List<string> codeToBeConvertedLetterList = new List<string>();

            for (int i = 0; i < codeToBeConvertedWordArray.Length; i++)
            {
                if (i > 0)
                {
                    resultText += " ";
                }
                
                codeToBeConvertedLetterList = codeToBeConvertedWordArray[i].Split('¤').ToList();
                for (int j = 0; j < codeToBeConvertedLetterList.Count; j++)
                {
                    foreach (var morzeBetu in morzeBetuList)
                    {
                        if (morzeBetu.morzekod == codeToBeConvertedLetterList[j])
                        {
                            resultText += morzeBetu.betu.ToString();
                        }
                    }
                }
            }
            
            return resultText;
        }


        private static void negyedikFeladat(List<Morzebetu> morzebetulist)
        {
            Console.Write("4. feladat: ");

            List<string> morzebetuStringList = new List<string>();
            string queriedCharacter;
            int counter = 0;

            foreach (var morzebetu in morzebetulist)
            {
                morzebetuStringList.Add(morzebetu.betu.ToUpper());
            }

            do
            {
                if (counter >= 1)
                {
                    Console.WriteLine("Nem található a kódtárban ilyen karakter!");
                }

                Console.WriteLine("Kérek egy karaktert: ");
                queriedCharacter = Convert.ToString(Console.ReadLine());

                counter++;                
            } while (!morzebetuStringList.Contains(queriedCharacter.ToUpper()));

            string morseCodeOfQueriedCharacter = "";
            morseCodeOfQueriedCharacter = morseDictionary(queriedCharacter, morzebetulist);
            
            Console.WriteLine($"A(z) {queriedCharacter} morzekódja: {morseCodeOfQueriedCharacter}");
        }

        private static string morseDictionary(string queriedCharacter, List<Morzebetu> morzeBetuList)
        {
            string morseCodeOfQueriedCharacter = "";

            foreach (var morzebetu in morzeBetuList)
            {
                if (morzebetu.betu.ToUpper() == Convert.ToString(queriedCharacter.ToUpper()))
                {
                    morseCodeOfQueriedCharacter = morzebetu.morzekod;
                }
            }

            return morseCodeOfQueriedCharacter;
        }

        private static void harmadikFeladat(List<Morzebetu> morzeBetuList)
        {
            Console.Write("3. feladat: ");
            Console.WriteLine($"A morze abc {morzeBetuList.Count} db karakter kódját tartalmazza."); ;
        }
    }
}
