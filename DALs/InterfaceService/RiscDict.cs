using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custodian
{
    class RiscDict
    {


        private static Case[] cases = new Case[21];
        public RiscDict()
        {
            cases[0] = new Case { SubClass = "investment", Class = "bonds", RiscLevel = 2, CompleteClassName = "investment_bonds", minCellTV=70, maxCellTV=85, FullClassName = "Bonds", FullSubClassName= "Investment Bonds" };
            cases[1] = new Case { SubClass = "speculation", Class = "bonds", RiscLevel = 4, CompleteClassName = "speculation_bonds", minCellTV=40, maxCellTV=65, FullClassName = "Bonds", FullSubClassName = "Speculation Bonds" };
            cases[2] = new Case { SubClass = "Credit", Class = "struct", RiscLevel = 2 , CompleteClassName = "Credit_Linked_Notes", minCellTV=60, maxCellTV=80, FullClassName = "Structs", FullSubClassName = "Credit Linked Notes" };
            cases[3] = new Case { SubClass = "SNGC", Class = "struct", RiscLevel = 3 , CompleteClassName = "SNGC", minCellTV=30, maxCellTV=70, FullClassName = "Structs", FullSubClassName = "SNGC" };
            cases[4] = new Case { SubClass = "SNCC", Class = "struct", RiscLevel = 4 , CompleteClassName = "SNCC", minCellTV=0, maxCellTV=50 , FullClassName = "Structs", FullSubClassName = "SNCC" };
            cases[5] = new Case { SubClass = "SNRS", Class = "struct", RiscLevel = 6 , CompleteClassName = "SNRS", minCellTV=0, maxCellTV=30, FullClassName = "Structs", FullSubClassName = "SNRS" };
            cases[6] = new Case { SubClass = "hi", Class = "share", RiscLevel = 3 , CompleteClassName = "hi_cap_equities", minCellTV=30, maxCellTV=60, FullClassName = "Shares", FullSubClassName = "Hi Cap Equities" };
            cases[7] = new Case { SubClass = "emerging", Class = "share", RiscLevel = 4, CompleteClassName = "emerging_markets", minCellTV=20, maxCellTV=70, FullClassName = "Shares", FullSubClassName = "Emerging Markets" };
            cases[8] = new Case { SubClass = "mid", Class = "share", RiscLevel = 4, CompleteClassName = "mid_cap_equities", minCellTV=20, maxCellTV=50 , FullClassName = "Shares", FullSubClassName = "Mid Cap Equities" };
            cases[9] = new Case { SubClass = "lo", Class = "share", RiscLevel = 5, CompleteClassName = "lo_cap", minCellTV= 30, maxCellTV = 60, FullClassName = "Shares", FullSubClassName ="Lo cap"};
            cases[10] = new Case { SubClass = "options", Class = "derivatives", RiscLevel = 4, CompleteClassName = "options", minCellTV=50, maxCellTV=60, FullClassName = "Derivatives" , FullSubClassName="Options"};
            cases[11] = new Case { SubClass = "futures", Class = "derivatives", RiscLevel = 5, CompleteClassName = "futures", minCellTV=30, maxCellTV=50, FullClassName = "Derivatives" , FullSubClassName="Futures"};
            cases[12] = new Case { SubClass = "leveraged", Class = "funds", RiscLevel = 6, CompleteClassName = "leveraged_ETF", minCellTV=-1, maxCellTV=-1, FullClassName = "Funds" , FullSubClassName= "Leveraged ETF" };
            cases[13] = new Case { SubClass = "mutual", Class = "funds", RiscLevel = 3, CompleteClassName = "mutual_funds", minCellTV=20, maxCellTV=60, FullClassName = "Funds", FullSubClassName= "Mutual Funds" };
            cases[14] = new Case { SubClass = "residential", Class = "alternative", RiscLevel = 3, CompleteClassName = "residential_properties", minCellTV=30, maxCellTV=70, FullClassName = "Alternative" , FullSubClassName = "Residential Properties" };
            cases[15] = new Case { SubClass = "commercial", Class = "alternative", RiscLevel = 4, CompleteClassName = "commercial_property", minCellTV=50, maxCellTV=70, FullClassName = "Alternative", FullSubClassName= "Commercial Property" };
            cases[16] = new Case { SubClass = "classics", Class = "alternative", RiscLevel = 3, CompleteClassName = "classics_pictures", minCellTV=30, maxCellTV=80, FullClassName = "Alternative", FullSubClassName = "Classics Pictures" };
            cases[17] = new Case { SubClass = "modern", Class = "alternative", RiscLevel = 5, CompleteClassName = "modern_pictures", minCellTV=30, maxCellTV=60, FullClassName = "Alternative", FullSubClassName = "Modern Pictures" };
            cases[18] = new Case { SubClass = "marks", Class = "alternative", RiscLevel = 4, CompleteClassName = "marks", minCellTV=20, maxCellTV =50, FullClassName = "Alternative", FullSubClassName="Marks" };
            cases[19] = new Case { SubClass = "wine", Class = "alternative", RiscLevel = 4 , CompleteClassName = "wine", minCellTV=10, maxCellTV =40, FullClassName = "Alternative", FullSubClassName = "Wine" };
            cases[20] = new Case { SubClass = "cash", Class = "Cash", RiscLevel = 1, CompleteClassName = "Cash_Accounts", minCellTV = 90, maxCellTV = 95, FullClassName = "Cash" , FullSubClassName = "Cash" };
        }
        struct Case
        {
            public string Class { get; set;}
            public string SubClass { get; set; }
            public int RiscLevel { get; set; }  
            public string CompleteClassName { get; set; }     
            public int minCellTV { get; set; }
            public int maxCellTV { get; set; }
            public string FullClassName { get; set; }
            public string FullSubClassName { get; set; }

        }
        /// <summary>
        /// Возвращает кортеж из уровня риска и имени класса по подклассу
        /// </summary>
        /// <param name="PassesSubClass"></param>
        /// <returns></returns>
        public Tuple<int,string> IntegerDivide(string PassesSubClass)
        {
            PassesSubClass = (PassesSubClass == "cash") ? "Cash" : PassesSubClass;
            try
            {
                foreach (Case ThisCase in cases)
                {
                    if (PassesSubClass.Contains(ThisCase.FullSubClassName))
                    {
                        return new Tuple<int, string>(ThisCase.RiscLevel, ThisCase.FullClassName);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
                return null;
            }
        }

        /// <summary>
        /// Возвращает полное имя подкласса по сокращенному имени
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CurlReturnFull(string curlstring)
        {
            string result = string.Empty;
            foreach (Case ThisCase in cases)
            {
                if (curlstring.Contains(ThisCase.SubClass))
                {
                    curlstring = ThisCase.FullSubClassName;
                }
            }
            return curlstring;
        }


        /// <summary>
        /// Возвращает коллекцю строк с полными именами тех активов, чей риск ниже или равен принятому и которые не входят в уже имеющиеся
        /// </summary>
        /// <param name="riscMax"></param>
        /// <returns></returns>
        public List<string> RiscDivide(int riscMax, List<string> currentGood)
        {
            try
            {
                List<string> GoodNamesList = new List<string>();

                foreach (Case cs in cases)
                {
                    if (cs.RiscLevel <= riscMax)
                    {
                        if (!currentGood.Contains(cs.FullSubClassName))
                        {
                            GoodNamesList.Add(cs.FullSubClassName);
                        }
                    }
                }
                return GoodNamesList;
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
            return null;
        }
        public int MiddCELLTV(string activeName)
        {
            foreach (Case CS in cases)
            {
                if (CS.FullSubClassName.Contains(activeName))
                {
                    return (CS.maxCellTV + CS.minCellTV)/2;
                }
            }
            return 0;
        }
      
    }  
}
