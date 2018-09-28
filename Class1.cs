using System;
using System.Collections.Generic;
namespace ConsoleApp1
{

    internal public class Wolfram
    {
        private List<Calc> listCalc = new List<Calc>();
        public Wolfram(List<Calc> listCalc)
        {
         
        }
        public Wolfram()
        {
             
        }
        
        public int add(Calc c)
        {
            listCalc.Add(c);
            return 1;
        }
        public List<Calc> GetCalcs()
        {
            return listCalc;
        }
        public void CreateFile()
        {

        }
    }
}
