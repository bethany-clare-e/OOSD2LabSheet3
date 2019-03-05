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

using System.Collections.ObjectModel;

namespace Ex2_Expense
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Expense> expenses = new ObservableCollection<Expense>();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random randomFactory = new Random();


            //create 3 expense objects
            Expense e1 = new Expense("Office", 19.99M, new DateTime(2018, 1, 15));
            Expense e2 = GetRandomExpense(randomFactory);
            Expense e3 = GetRandomExpense(randomFactory);
            Expense e4 = GetRandomExpense(randomFactory);
            Expense e5 = GetRandomExpense(randomFactory);

            //add to collection
            expenses.Add(e1);
            expenses.Add(e2);
            expenses.Add(e3);
            expenses.Add(e4);
            expenses.Add(e5);

            //display on screen
            lbxExpenses.ItemsSource = expenses;

            decimal total = Expense.TotalExpenses;
            tblkTotal.Text = string.Format("{0:C}", total);


        }

        //generate random expense
        private Expense GetRandomExpense(Random randomFactory)
        {
            Random rf = new Random();

            string[] categories = { "Travel", "Office", "Entertainment" };

            int randNumber = randomFactory.Next(0, 3);
            string randomCategory = categories[randNumber];

            decimal randomAmount = (decimal)randomFactory.Next(1, 10001) / 100;

            DateTime randomDate = DateTime.Now.AddDays(-randomFactory.Next(0, 32));

            Expense randomExpense = new Expense(randomCategory, randomAmount, randomDate);

            return randomExpense;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //identify which expense is selected
            Expense selectedExpense = lbxExpenses.SelectedItem as Expense;

            if (selectedExpense != null)
            {
                //remove that expense
                Expense.TotalExpenses -= selectedExpense.Cost;
                expenses.Remove(selectedExpense);

                decimal total = Expense.TotalExpenses;
                tblkTotal.Text = string.Format("{0:C}", total);
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Random randomFactory = new Random();
            Expense exp = GetRandomExpense(randomFactory);
            expenses.Add(exp);

            decimal total = Expense.TotalExpenses;
            tblkTotal.Text = string.Format("{0:C}", total);
        }
    }
}
