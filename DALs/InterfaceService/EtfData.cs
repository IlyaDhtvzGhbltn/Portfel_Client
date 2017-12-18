using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.InterfaceService
{
    public class EtfData
    {

        public class ETFContext
        {
            double MxFund { get; set; }
            double MnFond { get; set; }
            List<ETF> CurrentETF { get; set; }

            public ETFContext(string Path_to_EtfDict, int PRI)
            {
                var AllEtfs = DeSerializ(Path_to_EtfDict);
                this.CurrentETF = ETF_PRI(PRI, AllEtfs);
            }

            private List<ETF> ETF_PRI(int PRI, List<ETF>ListFunds)
            {
                List<ETF> PRICorrect = new List<ETF>();
                for (int i = 0; i < ListFunds.Count; i++)
                {
                    if (ListFunds[i].PRI <= PRI)
                        PRICorrect.Add(ListFunds[i]);
                }
                return PRICorrect;
            }

            public ETF MaxFund()
            {
                double statrEtfProf = 0;
                int indexINcollect = 0;
                for (int i = 0; i < CurrentETF.Count; i++)
                {
                    try
                    {
                        if (CurrentETF[i].Perfomance_5Year > statrEtfProf)
                        {
                            indexINcollect = i;
                            statrEtfProf = CurrentETF[i].Perfomance_5Year;
                        }
                    }
                    catch (Exception) { }
                }
                MxFund = CurrentETF[indexINcollect].Perfomance_5Year;
                return CurrentETF[indexINcollect];
            }

            public ETF MinFund()
            {
                double statrEtfProf = 0;
                int indexINcollect = 0;
                for (int i = 0; i < CurrentETF.Count; i++)
                {
                    try
                    {
                        if (CurrentETF[i].Perfomance_5Year < statrEtfProf)
                        {
                            statrEtfProf = CurrentETF[i].Perfomance_5Year;
                            indexINcollect = i;
                        }
                    }
                    catch (Exception) { }
                }
                MnFond = CurrentETF[indexINcollect].Perfomance_5Year;
                return CurrentETF[indexINcollect];
            }

            public ETF MiddleFund()
            {
                double idealMiddle = (this.MxFund - this.MnFond) / 2;
                int index = 0;
                double deviation = 9999999;
                for (int i = 0; i < CurrentETF.Count; i++)
                {
                    try
                    {
                        if (CurrentETF[i].Perfomance_5Year > this.MnFond
                         && CurrentETF[i].Perfomance_5Year < this.MxFund)
                        {
                            deviation = Math.Abs(idealMiddle - CurrentETF[i].Perfomance_5Year);
                            if (deviation < idealMiddle)
                                index = i;
                        }
                    }
                    catch (Exception) { }
                }
                return CurrentETF[index];
            }
        }

        private static List<ETF> DeSerializ(string path)
        {
            List<ETF> etfList = new List<ETF>();
            var EtfResult = File.ReadAllLines(path);
            foreach (var str in EtfResult)
            {
                var smass = str.Split('=');
                etfList.Add(new ETF
                {
                    URI = smass[0],
                    PRI = Convert.ToInt32(smass[1]),
                    Perfomance_1Week = PerzentInterp(smass[2]),
                    Perfomance_1Month = PerzentInterp(smass[3]),
                    Perfomance_3Month = PerzentInterp(smass[4]),
                    Perfomance_1Yearh = PerzentInterp(smass[5]),
                    Perfomance_3Year = PerzentInterp(smass[6]),
                    Perfomance_5Year = PerzentInterp(smass[7]),

                });
            }
            return etfList;
        }

        private static double PerzentInterp(string strpr)
        {
            double result = 0;
            var remove = strpr.Trim('%').Trim('+').Replace('.', ',');

            try
            {
                result = Convert.ToDouble(remove);
            }
            catch (FormatException)
            {
            }
            return result;
        }

        public class ETF
        {
            public string URI { get; set; }
            public int PRI { get; set; }
            public double Perfomance_1Week { get; set; }
            public double Perfomance_1Month { get; set; }
            public double Perfomance_3Month { get; set; }
            public double Perfomance_1Yearh { get; set; }
            public double Perfomance_3Year { get; set; }
            public double Perfomance_5Year { get; set; }

            public double[] PerfPrice => new double[] { Perfomance_1Week, Perfomance_1Month,
                                                        Perfomance_3Month, Perfomance_1Yearh,
                                                        Perfomance_3Year, Perfomance_5Year};
        }
    }
}