using System;
using System.Collections.Generic;
namespace ConsoleApp1
{

    internal class Wolfram
    {
        private List<Calc> listCalc = new List<Calc>();
        public Wolfram(List<Calc> CalcInput)
        {
            NewCalc(); 
        }

        public Wolfram()
        {
            NewCalc(); 
        }

        public int NewCalc()
        {
            Calc c = new Calc();
            listCalc.Add(c);
            return 1;
        }

        public int AddCalc(Calc c)
        {
            listCalc.Add(c);
            return 1;
        }

        public Calc LastCalc()
        {
            if (listCalc.Count > 0)
            {
                return listCalc[listCalc.Count - 1];
            }
            else
            {
                return null;
            }
        }
        
        public Calc NCalc(int n)
        {
            if (n >= 0 && n <= listCalc.Count)
            {
                return listCalc[listCalc.Count - 1 - n];
            }
            else
            {
                return null;
            }
        }
        public List<Calc> GetCalcs()
        {
            return listCalc;
        }
        public String CreateFile()
        {
            String strOut = "Notebook[{";
            for (int i = listCalc.Count -1; i >=  0; i--)
            {
                int n = listCalc.Count-1;
                string Data = "";
                Calc c = NCalc(i);
                if(c.StringWolfram.Count == 1)
                {
                    Data = "\""+ c.StringWolfram[c.StringWolfram.Count - 1] + "\"";
                }
                else
                {

                    Data = "RowBox[{\"" + string.Join("\",\"", c.StringWolfram) + "\"}]";
                }
                strOut += "Cell[CellGroupData[{Cell[BoxData[" + Data + "],\"Input\", ExpressionUUID -> \"" + System.Guid.NewGuid().ToString() + "\",CellLabel -> \"In[" + (n-i).ToString() + "]:= \"],";
                strOut += "Cell[BoxData[\"" + c.GetResult().ToString() + "\", StandartForm],\"Output\", ExpressionUUID -> \"" + System.Guid.NewGuid().ToString() + "\",CellLabel -> \"Out[" + (n-i).ToString() + "]= \"]},Open],ExpressionUUID -> \"" + System.Guid.NewGuid().ToString() + "\"]";
                if(i != 0)
                {
                    strOut += ",";
                }
            }
            strOut += "},StyleDefinitions -> \"Default.nb\",FrontEndVersion -> \"11.3 for Wolfram Cloud 1.47.1(August 9, 2018)\"]";
            return strOut; 
        }
    }
}
