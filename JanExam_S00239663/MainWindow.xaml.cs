using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JanExam_S00239663
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables
        static List<BudgetItem> items = new List<BudgetItem>();

        //scuffed dates
        static DateTime date5 = new DateTime(2002, 5, 5);
        static DateTime date15 = new DateTime(2002, 5, 15);
        static DateTime date20 = new DateTime(2002, 5, 20);
        static DateTime date25 = new DateTime(2002, 5, 25);
        static DateTime date1 = new DateTime(2002, 5, 1);


        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        //initial data
        public void GetData()
        {
            //create entries
            items.Add(new BudgetItem("Grant", 300, date5, true, "income"));
            items.Add(new BudgetItem("Bonus", 300, date15, false, "income"));
            items.Add(new BudgetItem("Wages", 100, date25, true, "income"));
            items.Add(new BudgetItem("Rent", 400, date1, true, "expense"));
            items.Add(new BudgetItem("Flight", 100, date5, false, "expense"));
            items.Add(new BudgetItem("Netflix", 10, date15, true, "expense"));
            items.Add(new BudgetItem("Spotify", 8, date20, true, "expense"));

            //sort entries
            items.Sort();


            //display entries
            foreach (var item in items)
            {
                if (item.Type == "income")
                    lbIncome.Items.Add(item);
                else lbExpenses.Items.Add(item);
            }




        }

        //button on click
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
