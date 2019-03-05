using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Member> members = new ObservableCollection<Member>();

        string[] types = new string[] { "Full", "Off Peak", "Student" };

        public MainWindow()
        {
            InitializeComponent();
            cbxType.ItemsSource = types;
            lbxMembers.ItemsSource = members;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //read info
            string memberType = cbxType.SelectedValue as string;
            string name = tbxName.Text;
            DateTime joinDate = dpJoinDate.SelectedDate.Value;

            //create object
            Member newMember = new Member() { MemberName = name, MemberType = memberType, Joindate = joinDate };

            Member.NumberOfMembers++;

            //add to collection
            members.Add(newMember);

            tblkNumberOfMembers.Text = Member.NumberOfMembers.ToString();

            ClearScreen();

        }

        private void ClearScreen()
        {
            cbxType.SelectedIndex = -1;
            tbxName.Clear();
            dpJoinDate.ClearValue(DatePicker.SelectedDateProperty);
        }
    }
}
