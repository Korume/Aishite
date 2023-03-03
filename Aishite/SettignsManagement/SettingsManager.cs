using System;

namespace Aishite.SettignsManagement
{
    public class SettingsManager : ISettingsManager
    {
        private const string _currentSettingsKey = "Settings";
        private bool _waitingForChangesApply = false;

        private readonly ISettingsProvider _settingsProvider;
        private readonly IDataStorage _storage;

        public event EventHandler<NewSettingsEventArgs>? NewSettings;

        public SettingsManager(ISettingsProvider settingsProvider, IDataStorage storage)
        {
            _settingsProvider = settingsProvider;
            _storage = storage;
        }

        protected virtual void OnNewSettings(Settings newSettings)
        {
            NewSettings?.Invoke(this, new NewSettingsEventArgs(newSettings));
        }

        public Settings GetSettings()
        {
            var settings = _storage.GetValue<Settings>(_currentSettingsKey);
            if (settings == null)
            {
                settings = _settingsProvider.Get();
                _storage.SetValue(_currentSettingsKey, settings);
            }
            return settings;
        }

        public void SetSettings(Settings newSettings)
        {
            var storedSettings = _storage.GetValue<Settings>(_currentSettingsKey);

            if (newSettings == storedSettings)
            {
                _storage.SetValue(_currentSettingsKey, newSettings);

                _waitingForChangesApply = true;
            }
        }

        public void ApplyChanges()
        {
            if (_waitingForChangesApply)
            {
                var settings = _storage.GetValue<Settings>(_currentSettingsKey)!;

                _settingsProvider.Save(settings);

                OnNewSettings(settings);
            }
        }
    }
}
