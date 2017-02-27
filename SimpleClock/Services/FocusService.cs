using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClock.Gui.Services
{
    public class FocusService
    {
        private PersistentStorage _storage;

        public FocusService(PersistentStorage storage)
        {
            _storage = storage;
        }

        public bool IsFocus => RetrieveCurrentActivity() != null;

        public Models.Activity RetrieveCurrentActivity()
        {
            return _storage.Db
                .Table<Models.Activity>()
                .Where(x => x.FinishedAt == null)
                .FirstOrDefault();
        }

        internal void EndActivity(object activity)
        {
            throw new NotImplementedException();
        }
    }
}
