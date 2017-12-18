using Custodian.DALs.InterfaceService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Custodian.Model
{
    class TestHistory : MainVM
    {
        
        public string Name { get; set; }
        public ObservableCollection<HistoryRow> historyTableCollection { get; set; }
        private static string order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
        private DataTable RowsCollection = Storage.datasetKlient.Tables["RiscInfo"];
        int RiskRating = Settings1.Default.CurrentRiscProfil;


        public class HistoryRow
        {
            public string result { get; set; }
            public string Date { get; set; }

        }
        public int CurrRiskProfil
        {
            get
            {
                if (RiskRating != 0)
                {

                    return Settings1.Default.CurrentRiscProfil;
                }
                else return 0;
            }
        }

        public string RiskOrientir
        {
            get
            {
                switch(RiskRating)
                {
                    case 1:
                        return "(Safety Oriented)";
                    case 2:
                        return "(Conservative)";
                    case 3:
                       return "(Moderate)";
                    case 4:
                        return "(Aggressive)";
                    case 5:
                        return "(Very aggressive)";
                    case 6:
                        return "(Specialized Investing)";
                }
                return "Risk test Empty";
            }
        }

        public string RiskPrifillInfo
        {
            get
            {
                switch (RiskRating)
                {
                    case 1:
                        return "Negligible risk of loss and high certainty of being able to obtain a price at which the product can be liquidated daily.";
                    case 2:
                        return "Some risk of loss reasonably high certainty of being able to obtain a price at which the product can be liquidated quickly.";
                    case 3:
                        return "Material risk of loss associated with fairly volatile markets, mitigated by reasonably high certainty of being able to obtain a price at which the product can be liquidated quickly under normal market conditions.";
                    case 4:
                        return "Significant risk of loss associated with higher volatility markets, the possibility of material event risks such as extreme market price changes, greater risk of corporate failure, and erratic liquidity conditions mitigated by reasonable certainty of being able to obtain a price at which the product can be liquidated within a reasonable timeframe under normal market conditions.";
                    case 5:
                        return "Very significant risk of loss associated with strategy and event risks, erratic price and liquidity conditions and/or products with extended redemptions terms.";
                    case 6:
                        return "Subject to high event risk, material Uncertainty on the realizable value of assets and lack of redemption rights, therefore very significant risk of loss  in the event of a forced sale.";
                }
                return "Risk test Empty";
            }

        }

        public TestHistory()
        {
            try
            {
                Name = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][7].ToString() + "  " + Storage.datasetKlient.Tables["ClientInfo"].Rows[0][8].ToString();
                historyTableCollection = new ObservableCollection<HistoryRow>();

                for (int i = 0; i < RowsCollection.Rows.Count; i++)
                {
                    historyTableCollection.Add(new HistoryRow()
                    {
                        Date = RowsCollection.Rows[i][2].ToString(),
                        result = "P" + RowsCollection.Rows[i][1].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
        }


    }
}
