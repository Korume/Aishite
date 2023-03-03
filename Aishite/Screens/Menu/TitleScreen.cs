using System;

namespace Aishite.Screens.Menu
{
    public class TitleScreen : MenuScreen
    {
        public TitleScreen(ScreenManager screenManager) : base(screenManager, false)
        {
            var playGameMenuEntry = new MenuEntry("Play Game");
            var settingsMenuEntry = new MenuEntry("Settings");
            var exitMenuEntry = new MenuEntry("Exit");

            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            settingsMenuEntry.Selected += SettingsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            _menuEntries.Add(playGameMenuEntry);
            _menuEntries.Add(settingsMenuEntry);
            _menuEntries.Add(exitMenuEntry);
        }

        public static TitleScreen Create(ScreenManager screenManager) => new(screenManager);

        private void PlayGameMenuEntrySelected(object? sender, EventArgs e)
        {
            //TODO
        }

        private void SettingsMenuEntrySelected(object? sender, EventArgs e)
        {
            ScreenManager.AddScreen(SettingsMenuScreen.Create(ScreenManager));
        }

        private void OnCancel(object? sender, EventArgs e)
        {
            ScreenManager.Game.Exit();
        }
    }
}
