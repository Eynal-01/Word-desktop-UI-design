using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Path = System.IO.Path;

namespace Word_desktop_UI_design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string path = "";
        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)| *.txt";
            openDialog.FilterIndex = 2;


            if (openDialog.ShowDialog() == true)
            {
                using (var sr = File.OpenText(openDialog.FileName))
                {
                    WordTxtb.Text = sr.ReadToEnd();
                    path = Path.GetFullPath(openDialog.FileName);
                    FilesTxtb.Text = path;
                }
            }
            if (FilesTxtb.Text != null)
            {
                WordTxtb.IsEnabled = true;
                SaveBtn.IsEnabled = true;
                //checkLbl.IsEnabled = true;
                CutBtn.IsEnabled = true;
                CopyBtn.IsEnabled = true;
                PasteBtn.IsEnabled = true;
                SelectAllBtn.IsEnabled = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(path, WordTxtb.Text);
            MessageBox.Show("Text saved");
        }

        private void SelectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            WordTxtb.SelectAll();
            WordTxtb.Focus(); 
        }

        private void CutBtn_Click(object sender, RoutedEventArgs e)
        {
            WordTxtb.Cut();
        }

        private void PasteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WordTxtb.Text != null)
            { 
                WordTxtb.Paste();
            }
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WordTxtb.Text != null)
            {
                WordTxtb.Copy();
            }
        }
        public bool IsClicked { get; set; } = false;

        private void WordTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsClicked == true)
            {
                File.WriteAllText(path, WordTxtb.Text);
            }
        }
        public void CanExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            OpenFileBtn_Click(sender, e);
        }

        private void WordTxtb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {

            }
        }
    }
}
