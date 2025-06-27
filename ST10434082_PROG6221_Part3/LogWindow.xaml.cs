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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace ST10434082_PROG6221_Part3
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
            LogListView.ItemsSource = ActivityLogManager.Log;
        }
    }


    public static class ActivityLogManager
    {
        public static ObservableCollection<LogItem> Log { get; } = new ObservableCollection<LogItem>();

        public static void AddLog(string description)
        {
            Log.Insert(0, new LogItem
            {
                Timestamp = DateTime.Now,
                Description = description
            });

            // Limit to 10 latest
            if (Log.Count > 10)
                Log.RemoveAt(Log.Count - 1);
        }
    }
}
