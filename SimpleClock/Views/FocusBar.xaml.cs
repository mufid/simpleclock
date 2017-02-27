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
using System.Windows.Shapes;
using SimpleClock.Gui.Models;

namespace SimpleClock.Gui.Views
{
    /// <summary>
    /// Interaction logic for FocusBar.xaml
    /// </summary>
    public partial class FocusBar : Window
    {
        public FocusBar(Models.Activity activity)
        {
            InitializeComponent();
            this.CurrentActivity = activity;
        }

        public Activity CurrentActivity { get; private set; }

        public bool IsUntitled => string.IsNullOrEmpty(CurrentActivity.Description);

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var storage = new Services.PersistentStorage();
            var focus = new Services.FocusService(storage);

            focus.EndActivity(CurrentActivity);
        }
    }
}
