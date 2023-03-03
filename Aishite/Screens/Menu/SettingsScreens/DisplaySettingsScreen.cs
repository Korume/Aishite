using System;
using Microsoft.Xna.Framework;

namespace Aishite.Screens.Menu.SettingsScreens
{
    public class DisplaySettingsScreen : MenuScreen
    {
        public DisplaySettingsScreen(ScreenManager screenManager) : base(screenManager, false)
        {
            var displayModeMenuEntry = new MenuEntry("Display mode");
            var resolutionMenuEntry = new MenuEntry("Resolution");
            var backMenuEntry = new MenuEntry("Back");

            displayModeMenuEntry.Selected += DisplayModeMenuEntrySelected;
            resolutionMenuEntry.Selected += ResolutionMenuEntrySelected;
            backMenuEntry.Selected += BackMenuEntrySelected;

            _menuEntries.AddRange(new[] { displayModeMenuEntry, resolutionMenuEntry, backMenuEntry });
        }

        public static DisplaySettingsScreen Create(ScreenManager screenManager) => new(screenManager);

        private void DisplayModeMenuEntrySelected(object? sender, EventArgs e)
        {
            if (sender is MenuEntry displayMenuEntry)
            {
                var menuSpacing = 20f;
                var initialPositionX = displayMenuEntry.Position.X + displayMenuEntry.GetWidth() + menuSpacing;
                var initialPositionY = displayMenuEntry.Position.Y;
                var initialPosition = new Vector2(initialPositionX, initialPositionY);

                ScreenManager.AddScreen(DisplayModePopupMenuScreen.Create(ScreenManager, initialPosition));
            }
        }

        private void ResolutionMenuEntrySelected(object? sender, EventArgs e)
        {
            if (sender is MenuEntry resolutionMenuEntry)
            {
                var menuSpacing = 20f;
                var initialPositionX = resolutionMenuEntry.Position.X + resolutionMenuEntry.GetWidth() + menuSpacing;
                var initialPositionY = resolutionMenuEntry.Position.Y;
                var initialPosition = new Vector2(initialPositionX, initialPositionY);

                ScreenManager.AddScreen(ResolutionPopupMenuScreen.Create(ScreenManager, initialPosition));
            }
        }

        private void BackMenuEntrySelected(object? sender, EventArgs e)
        {
            ExitScreen();
        }
    }
}
