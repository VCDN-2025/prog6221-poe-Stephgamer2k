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
using System.Windows.Shapes;

namespace ST10434082_PROG6221_Part3
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        
        public TaskWindow()
        {
            InitializeComponent();
            
            TaskListView.ItemsSource = TaskManager.AllTasks;
        }


        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            //gets the task linked to the clicked button
            var task = TaskListView.SelectedItem as TaskItem;
            if (task != null)
                TaskManager.AllTasks.Remove(task);

        }

        
    }
}
