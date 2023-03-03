using System;

namespace Aishite.SettignsManagement
{
    public interface ISettingsManager
    {
        event EventHandler<NewSettingsEventArgs>? NewSettings;

        Settings GetSettings();
        void SetSettings(Settings settings);
        void ApplyChanges();
    }
}
