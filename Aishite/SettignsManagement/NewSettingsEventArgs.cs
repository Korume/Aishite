using System;

namespace Aishite.SettignsManagement
{
    public class NewSettingsEventArgs : EventArgs
    {
        public Settings Settings { get; }

        public NewSettingsEventArgs(Settings settings)
        {
            Settings = settings;
        }
    }
}
