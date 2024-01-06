using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanExam_S00239663
{
    internal class BudgetItem:IComparable<BudgetItem>
    {
        //attributes
        private string name;
        private decimal amount;
        private string type;
        private DateTime date;
        private bool recurring;
        

        //constructors
        public BudgetItem()
        {

        }

        public BudgetItem(string name, decimal amount, DateTime date, bool recurring, string type)
        {
            this.name = name;
            this.amount = amount;
            this.date = date;
            this.recurring = recurring;
            this.type = type;
        }

        //IComparable 
        public int CompareTo(BudgetItem other)
        {
            if (this.date.Day > other.date.Day) return 1;
            else if (this.date.Day < other.date.Day) return -1;
            else return 0;
        }

        //get
        public DateTime Date
        {
            get { return date; }
        }

        public string Name
        {
            get { return name; }
        }

        public decimal Amount
        {
            get { return amount; }
        }

        public string Type
        {
            get { return type; }
        }

        //recurring
        public string IsRecurring(bool recurring)
        {
            if (recurring) return "Recurring";
            else return "One-Off";
        }

        //override to string
        public override string ToString()
        {
            return $"{Date.Day}: {Name} {Amount:c} - {IsRecurring(recurring)}";
        }

    }
}
