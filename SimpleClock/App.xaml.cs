using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleClock.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var storage = new Services.PersistentStorage();
            var focus = new Services.FocusService(storage);

            if (focus.IsFocus)
            {
                var focusBar = new Views.FocusBar(focus.RetrieveCurrentActivity());
                focusBar.Show();
            }
            else
            {
                var historyWindow = new Views.History();
                historyWindow.Show();
            }
        }
    }
}
