using Aishite.Screens.Menu;
using Aishite.SettignsManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aishite
{
    public class AishiteGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly ScreenManager _screenManager;
        private readonly ISettingsManager _settingsManager;

        public AishiteGame()
        {
            _settingsManager = new SettingsManager(new JsonSettingsProvider(), new MemoryStorage());
            Services.AddService(_settingsManager);

            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = false;

            _screenManager = ScreenManager.Create(this, true);
            Components.Add(_screenManager);

            _screenManager.AddScreen(TitleScreen.Create(_screenManager));
        }

        protected override void Initialize()
        {
            _settingsManager.NewSettings += SettingsManagerNewSettings;

            var settigns = _settingsManager.GetSettings();

            _graphics.SynchronizeWithVerticalRetrace = settigns.VerticalSync;
            _graphics.IsFullScreen = settigns.IsFullScreen;
            _graphics.PreferredBackBufferWidth = (int)settigns.WindowWidth;
            _graphics.PreferredBackBufferHeight = (int)settigns.WindowHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        private void SettingsManagerNewSettings(object? sender, NewSettingsEventArgs e)
        {
            _graphics.SynchronizeWithVerticalRetrace = e.Settings.VerticalSync;
            _graphics.IsFullScreen = e.Settings.IsFullScreen;
            _graphics.PreferredBackBufferWidth = (int)e.Settings.WindowWidth;
            _graphics.PreferredBackBufferHeight = (int)e.Settings.WindowHeight;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}