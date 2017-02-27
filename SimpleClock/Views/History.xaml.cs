using SQLite;
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

namespace SimpleClock.Gui.Views
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
            LoadData();
            lvwHistory.ItemsSource = ActivityHistory;
        }

        public int Iteration { get; set; }

        public ObservableCollection<Models.Activity> ActivityHistory;

        public void LoadData()
        {
            var storage = new Services.PersistentStorage();
            var historyFromDb = storage.Db.Table<Models.Activity>().ToArray();
            ActivityHistory = new ObservableCollection<Models.Activity>(historyFromDb);
            storage.Initialize();
            storage.Dispose();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var storage = new Services.PersistentStorage();
            var act = new Models.Activity()
            {
                StartedAt = DateTime.Now,
                Description = $"Super duper {Iteration++}"
            };
            ActivityHistory.Add(act);
            storage.Db.Insert(act);
        }
    }
}
