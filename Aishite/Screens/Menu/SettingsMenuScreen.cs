using System;
using Aishite.Screens.Menu.SettingsScreens;
using Aishite.SettignsManagement;

namespace Aishite.Screens.Menu
{
    public class SettingsMenuScreen : MenuScreen
    {
        private readonly ISettingsManager _settingsManager;

        public SettingsMenuScreen(ScreenManager screenManager) : base(screenManager, false)
        {
            _settingsManager = screenManager.Game.Services.GetService<ISettingsManager>();

            var gameplayMenuEntry = new MenuEntry("Gameplay");
            var displayMenuEntry = new MenuEntry("Display");
            var audioMenuEntry = new MenuEntry("Audio");
            var accessibilityMenuEntry = new MenuEntry("Accessibility");
            var languageMenuEntry = new MenuEntry("Language");
            var backMenuEntry = new MenuEntry("Back");

            gameplayMenuEntry.Selected += GameplayMenuEntrySelected;
            displayMenuEntry.Selected += DisplayMenuEntrySelected;
            audioMenuEntry.Selected += AudioMenuEntrySelected;
            accessibilityMenuEntry.Selected += AccessibilityMenuEntrySelected;
            languageMenuEntry.Selected += LanguageMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            _menuEntries.AddRange(new[] { gameplayMenuEntry, displayMenuEntry, audioMenuEntry, accessibilityMenuEntry, languageMenuEntry, backMenuEntry});
        }

        public static SettingsMenuScreen Create(ScreenManager screenManager) => new(screenManager);

        private void GameplayMenuEntrySelected(object? sender, EventArgs e)
        {
            //TODO:
        }

        private void AudioMenuEntrySelected(object? sender, EventArgs e)
        {
            //TODO:
        }

        private void DisplayMenuEntrySelected(object? sender, EventArgs e)
        {
            ScreenManager.AddScreen(DisplaySettingsScreen.Create(ScreenManager));
        }

        private void AccessibilityMenuEntrySelected(object? sender, EventArgs e)
        {
            //TODO:
        }

        private void LanguageMenuEntrySelected(object? sender, EventArgs e)
        {
            //TODO:
        }

        private void BackMenuEntrySelected(object? sender, EventArgs e)
        {
            _settingsManager.ApplyChanges();

            ExitScreen();
        }
    }
}
