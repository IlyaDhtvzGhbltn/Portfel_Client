using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Custodian.Model
{
    class AdminTaskModel : MainVM
    {
        
        public ObservableCollection<TasksShow> allTasks { get; set; }
        public class TasksShow
        {
            public string numerTask { get; set; }
            public string clientorder { get; set; }
            public string adviser { get; set; }
            public string dataIN { get; set; }
            public string dataout { get; set; }
            public string Status { get; set; }
        }
        public string orderFilter { get { return _orderFilter; } set { _orderFilter = value; } }
        private string _orderFilter;

        public string selectComboboxItem { get; set; }
        public object CurrentRow {get;  set;}

        public void ResetInNew(object sender, EventArgs e)
        {
            allTasks.Clear();
            DataTable table = adminDAL.GetOnlyNewTasks();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                allTasks.Add(new TasksShow()
                {
                    adviser = table.Rows[i][2].ToString(),
                    clientorder = table.Rows[i][1].ToString(),
                    numerTask = table.Rows[i][0].ToString(),
                    dataIN = table.Rows[i][3].ToString(),
                    dataout = table.Rows[i][4].ToString(),
                    Status = table.Rows[i][5].ToString()
                });
            }
        }


        public RelayCommand  TasksFilter
        {
            get
            {
                return new RelayCommand(() =>
                {
                    allTasks.Clear();
                    DataTable table = adminDAL.GetTasks(_orderFilter);
                    for (int i=0; i<table.Rows.Count; i++)
                    {
                        allTasks.Add(new TasksShow()
                        {
                            adviser = table.Rows[i][2].ToString(),
                            clientorder = table.Rows[i][1].ToString(),
                            numerTask = table.Rows[i][0].ToString(),
                            dataIN = table.Rows[i][3].ToString(),
                            dataout = table.Rows[i][4].ToString(),
                            Status = table.Rows[i][5].ToString()
                        });
                    }
                }
                );
            }
        }
        public RelayCommand OllNew
        {
            get
            {
                return new RelayCommand(()=>
                {
                    allTasks.Clear();
                    DataTable table = adminDAL.GetOnlyNewTasks();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        allTasks.Add(new TasksShow()
                        {
                            adviser = table.Rows[i][2].ToString(),
                            clientorder = table.Rows[i][1].ToString(),
                            numerTask = table.Rows[i][0].ToString(),
                            dataIN = table.Rows[i][3].ToString(),
                            dataout = table.Rows[i][4].ToString(),
                            Status = table.Rows[i][5].ToString()
                        });
                    }

                });
            }
        }
        public RelayCommand<object> ChangeStatus
        {
            get
            {
                return new RelayCommand<object>(SetNewStatus);
            }

        }

        private void SetNewStatus(object row)
        {
            TasksShow _currentRow = CurrentRow as TasksShow;
            string order = _currentRow.clientorder.ToString();
            ComboBoxItem selectedStatus = (ComboBoxItem)row;
            if (MessageBox.Show("Are you realy want to Change the status ?", "Custodian", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                adminDAL.updateStatus(order, selectedStatus.Content.ToString());
                allTasks.Clear();
                DataTable table = adminDAL.GetTasks(_orderFilter);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    allTasks.Add(new TasksShow()
                    {
                        adviser = table.Rows[i][2].ToString(),
                        clientorder = table.Rows[i][1].ToString(),
                        numerTask = table.Rows[i][0].ToString(),
                        dataIN = table.Rows[i][3].ToString(),
                        dataout = table.Rows[i][4].ToString(),
                        Status = table.Rows[i][5].ToString()
                    });
                }
            }

        }


        //КОНСТРУКТОР КЛАССА 
        public AdminTaskModel()
        {
            Timer time = new Timer();
            time.Interval = 200;
            time.Tick += new EventHandler(ResetInNew);
            time.Start();


            allTasks = new ObservableCollection<TasksShow>();
            CurrentRow = new DataGridRow();
            DataTable table = adminDAL.GetTasks(null);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                allTasks.Add(new TasksShow()
                { 
                    adviser = table.Rows[i][2].ToString(),
                    clientorder = table.Rows[i][1].ToString(),
                    numerTask = table.Rows[i][0].ToString(),
                    dataIN = table.Rows[i][3].ToString(),
                    dataout = table.Rows[i][4].ToString(),
                    Status = table.Rows[i][5].ToString(),
                });

            }
        }







    }
}
