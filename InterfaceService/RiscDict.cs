using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custodian
{
    class RiscDict
    {


        private static Case[] cases = new Case[20];
        public RiscDict()
        {
            cases[0] = new Case { SubClass = "investment", Class = "bonds", RiscLevel = 2, CompleteClassName = "investment_bonds" };
            cases[1] = new Case { SubClass = "speculation", Class = "bonds", RiscLevel = 4, CompleteClassName = "speculation_bonds" };
            cases[2] = new Case { SubClass = "Credit", Class = "struct", RiscLevel = 2 , CompleteClassName = "Credit_Linked_Notes" };
            cases[3] = new Case { SubClass = "SNGC", Class = "struct", RiscLevel = 3 , CompleteClassName = "SNGC" };
            cases[4] = new Case { SubClass = "SNCC", Class = "struct", RiscLevel = 4 , CompleteClassName = "SNCC" };
            cases[5] = new Case { SubClass = "SNRS", Class = "struct", RiscLevel = 6 , CompleteClassName = "SNRS" };
            cases[6] = new Case { SubClass = "Hi", Class = "share", RiscLevel = 3 , CompleteClassName = "hi_cap_equities" };
            cases[7] = new Case { SubClass = "emerging", Class = "share", RiscLevel = 4, CompleteClassName = "emerging_markets" };
            cases[8] = new Case { SubClass = "mid", Class = "share", RiscLevel = 4, CompleteClassName = "mid_cap_equities" };
            cases[9] = new Case { SubClass = "lo", Class = "share", RiscLevel = 5, CompleteClassName = "lo_cap" };
            cases[10] = new Case { SubClass = "options", Class = "derivatives", RiscLevel = 4, CompleteClassName = "options" };
            cases[11] = new Case { SubClass = "futures", Class = "derivatives", RiscLevel = 5, CompleteClassName = "futures" };
            cases[12] = new Case { SubClass = "leveraged", Class = "funds", RiscLevel = 6, CompleteClassName = "leveraged_ETF" };
            cases[13] = new Case { SubClass = "mutual", Class = "funds", RiscLevel = 3, CompleteClassName = "mutual_funds" };
            cases[14] = new Case { SubClass = "residential", Class = "alternative", RiscLevel = 3, CompleteClassName = "residential_properties" };
            cases[15] = new Case { SubClass = "commercial", Class = "alternative", RiscLevel = 4, CompleteClassName = "commercial_property" };
            cases[16] = new Case { SubClass = "classics", Class = "alternative", RiscLevel = 3, CompleteClassName = "classics_pictures" };
            cases[17] = new Case { SubClass = "modern", Class = "alternative", RiscLevel = 5, CompleteClassName = "modern_pictures" };
            cases[18] = new Case { SubClass = "marks", Class = "alternative", RiscLevel = 4, CompleteClassName = "marks" };
            cases[19] = new Case { SubClass = "wine", Class = "alternative", RiscLevel = 4 , CompleteClassName = "wine" };

        }
        struct Case
        {
            public string Class { get; set;}
            public string SubClass { get; set; }
            public int RiscLevel { get; set; }  
            public string CompleteClassName { get; set; }     
        }
        /// <summary>
        /// Возвращает кортеж из уровня риска и имени класса по подклассу
        /// </summary>
        /// <param name="SubClass"></param>
        /// <returns></returns>
        public Tuple<int,string> IntegerDivide(string SubClass)
        {
            try
            {
                foreach (Case ThisCase in cases)
                {
                    if (SubClass.Contains(ThisCase.SubClass))
                    {
                        return new Tuple<int, string>(ThisCase.RiscLevel, ThisCase.Class);
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
                        if (!currentGood.Contains(cs.CompleteClassName))
                        {
                            GoodNamesList.Add(cs.CompleteClassName);
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
    }  
}
