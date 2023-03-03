using System;
using Aishite.SettignsManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aishite.Screens.Menu.SettingsScreens
{
    public class ResolutionPopupMenuScreen : MenuScreen
    {
        private readonly ISettingsManager _settingsManager;
        private readonly Vector2 _initialPosition;
        private readonly Vector2 _backgroundPadding = new(10, 10);
        private Vector2 _backgroundSize;
        private readonly Texture2D _background;

        public ResolutionPopupMenuScreen(ScreenManager screenManager, Vector2 initialPosition) : base(screenManager, true)
        {
            _background = new Texture2D(ScreenManager.GraphicsDevice, 1, 1);
            _background.SetData(new Color[] { Color.White });

            _settingsManager = screenManager.Game.Services.GetService<ISettingsManager>();
            _initialPosition = initialPosition;

            var resolution2560x1440MenuEntry = new MenuEntry("2560x1440");
            var resolution800x600MenuEntry = new MenuEntry("800x600");

            resolution2560x1440MenuEntry.Selected += Resolution2560x1440MenuEntrySelected;
            resolution800x600MenuEntry.Selected += Resolution800x600MenuEntrySelected;

            _menuEntries.AddRange(new[] { resolution2560x1440MenuEntry, resolution800x600MenuEntry });
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

        public static ResolutionPopupMenuScreen Create(ScreenManager screenManager, Vector2 initialPosition) => new(screenManager, initialPosition);

        private void Resolution2560x1440MenuEntrySelected(object? sender, EventArgs e)
        {
            var settings = _settingsManager.GetSettings();

            settings.WindowWidth = 2560;
            settings.WindowHeight = 1440;

            _settingsManager.SetSettings(settings);

            ExitScreen();
        }

        private void Resolution800x600MenuEntrySelected(object? sender, EventArgs e)
        {
            var settings = _settingsManager.GetSettings();

            settings.WindowWidth = 800;
            settings.WindowHeight = 600;

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
