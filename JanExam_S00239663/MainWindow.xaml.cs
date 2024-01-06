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
        private void GetData()
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
               AddItem(item);
            }

            Totals();




        }
        //add item
        private void AddItem(BudgetItem item)
        {
            if (item.Type == "income")
                lbIncome.Items.Add(item);
            else lbExpenses.Items.Add(item);
        }

        //totals
        private void Totals()
        {
            decimal income = 0;
            decimal expenses = 0;
            foreach(var item in items) {
                if(item.Type == "income") income += item.Amount;
                else expenses += item.Amount;
            }
            lblIncome.Content = $"{income:c}";
            lblOutgoings.Content = $"{expenses:c}";
            lblBalance.Content = $"{(income - expenses):c}";
        }

        //button on click
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (tbAmount.Text.Trim().Length > 0 && tbName.Text.Trim().Length > 0 && datePick.SelectedDate != null)
            {
                decimal amount = 0;
                if (decimal.TryParse(tbAmount.Text, out amount))
                {
                    string type = "income";
                    if (radioExpense.IsChecked == true) type = "expense";
                    BudgetItem item = new BudgetItem(tbName.Text, amount, (DateTime)datePick.SelectedDate, (bool)checkRecurring.IsChecked, type);
                    items.Add(item);
                    items.Sort();
                    lbIncome.Items.Clear();
                    lbExpenses.Items.Clear();
                    foreach (var i in items)
                    {
                        AddItem(i);
                    }


                    lblError.Content = "Item added successfully";
                    lblError.Background = new SolidColorBrush(Colors.LightGreen);
                }
                else
                {
                    lblError.Content = "Error on input";
                    lblError.Background = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                lblError.Content = "Error on input";
                lblError.Background = new SolidColorBrush(Colors.Red);
            }
        }


    }
}
