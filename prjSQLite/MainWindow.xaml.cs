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

using System.Data;

namespace prjSQLite
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtNachname.Clear();
            txtVorname.Clear();
            txtStrasse.Clear();
            txtPLZ.Clear();
            txtOrt.Clear();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DTGrid.ItemsSource == null)
                {
                    DTGrid.ItemsSource = SqlDB.LoadData().DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlDB.AddData(txtVorname.Text, txtNachname.Text, txtStrasse.Text, txtPLZ.Text, txtOrt.Text);
        }

        private void DTGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtID.Text = ((DataRowView)DTGrid.SelectedItem).Row[0].ToString();
            txtVorname.Text = ((DataRowView)DTGrid.SelectedItem).Row[1].ToString();
            txtNachname.Text = ((DataRowView)DTGrid.SelectedItem).Row[2].ToString();
            txtStrasse.Text = ((DataRowView)DTGrid.SelectedItem).Row[3].ToString();
            txtPLZ.Text = ((DataRowView)DTGrid.SelectedItem).Row[4].ToString();
            txtOrt.Text = ((DataRowView)DTGrid.SelectedItem).Row[5].ToString();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlDB.Update(txtID.Text, txtVorname.Text, txtNachname.Text, txtStrasse.Text, txtPLZ.Text, txtOrt.Text);
            DTGrid.ItemsSource = null;
            DTGrid.ItemsSource = SqlDB.LoadData().DefaultView;
        }
    }
}
