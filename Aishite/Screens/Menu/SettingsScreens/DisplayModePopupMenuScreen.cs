using System;
using Aishite.SettignsManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aishite.Screens.Menu.SettingsScreens
{
    public class DisplayModePopupMenuScreen : MenuScreen
    {
        private readonly ISettingsManager _settingsManager;
        private readonly Vector2 _initialPosition;
        private readonly Vector2 _backgroundPadding = new(10, 10);
        private Vector2 _backgroundSize;
        private readonly Texture2D _background;

        public DisplayModePopupMenuScreen(ScreenManager screenManager, Vector2 initialPosition) : base(screenManager, true)
        {
            _background = new Texture2D(ScreenManager.GraphicsDevice, 1, 1);
            _background.SetData(new Color[] { Color.White });

            _settingsManager = screenManager.Game.Services.GetService<ISettingsManager>();
            _initialPosition = initialPosition;

            var fullscreenMenuEntry = new MenuEntry("Fullscreen");
            var windowedMenuEntry = new MenuEntry("Windowed");

            fullscreenMenuEntry.Selected += FullscreenMenuEntrySelected;
            windowedMenuEntry.Selected += WindowedMenuEntrySelected;

            _menuEntries.AddRange(new[] { fullscreenMenuEntry, windowedMenuEntry });
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _backgroundSize = new Vector2(_menuEntriesWidthSum, _menuEntriesHeightSum) + _backgroundPadding;
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(_background, new Rectangle((_initialPosition - _backgroundPadding / 2).ToPoint(), _backgroundSize.ToPoint()), Color.SeaGreen);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static DisplayModePopupMenuScreen Create(ScreenManager screenManager, Vector2 initialPosition) => new(screenManager, initialPosition);

        private void FullscreenMenuEntrySelected(object? sender, EventArgs e)
        {
            var settings = _settingsManager.GetSettings();

            settings.IsFullScreen = true;

            _settingsManager.SetSettings(settings);

            ExitScreen();
        }

        private void WindowedMenuEntrySelected(object? sender, EventArgs e)
        {
            var settings = _settingsManager.GetSettings();

            settings.IsFullScreen = false;

            _settingsManager.SetSettings(settings);

            ExitScreen();
        }

        protected override void UpdateMenuEntryLocations()
        {
            var position = _initialPosition;

            foreach (var menuEntry in _menuEntries)
            {
                menuEntry.Position = position;

                position.Y += menuEntry.GetHeight();
            }
        }
    }
}
