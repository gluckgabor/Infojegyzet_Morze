using System;
using System.Collections.Generic;
using System.Text;

namespace Infojegyzet_Morze
{
    class MorzeIdezet
    {
        public string szerzo { get; set; }
        public string idezet { get; set; }

        public MorzeIdezet(string line)
        {
            string[] lineSplitted = line.Split(";");

            szerzo = lineSplitted[0];
            idezet = lineSplitted[1];
        }
    }
}
