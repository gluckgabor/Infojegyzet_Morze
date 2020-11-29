using System;
using System.Collections.Generic;
using System.Text;

namespace Infojegyzet_Morze
{
    class Morzebetu
    {

        public string betu { get; set; }
        public string morzekod { get; set; }



        public Morzebetu(string line)
        {
            string[] lineSplitted = line.Split("	");

            betu = lineSplitted[0];
            morzekod = lineSplitted[1];
        }
    }
}
