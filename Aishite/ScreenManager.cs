using System.Collections.Generic;
using System.Linq;
using Aishite.Screens;
using Aishite.Screens.Debug;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aishite
{
    public class ScreenManager : DrawableGameComponent
    {
        private readonly List<BaseScreen> _screens = new();
        private readonly InputState _input = new();

        private bool _isInitialized;

        private DebugScreen? _debugScreen;

        public SpriteBatch SpriteBatch { get; private set; } = null!;

        public ScreenManager(Game game, bool enableDebug = false) : base(game)
        {
            if (enableDebug)
            {
                EnableDebug();
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            _isInitialized = true;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var screen in _screens)
            {
                screen.LoadContent();
            }

            _debugScreen?.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _input.Update();

            var screensToUpdate = _screens.ToList();

            var isScreenVisible = true;
            var hasScreenFocus = true;

            for (var i = 0; i < screensToUpdate.Count; i++)
            {
                var screen = screensToUpdate[screensToUpdate.Count - i - 1];

                if (screen.IsActive)
                {
                    screen.Update(gameTime);
                    screen.IsVisible = isScreenVisible;
                    screen.HasFocus = hasScreenFocus;
                }

                if (screen.HasFocus)
                {
                    screen.HandleInput(gameTime, _input);

                    hasScreenFocus = false;
                }

                if (!screen.IsPopup)
                {
                    isScreenVisible = false;
                }
            }

            if (_debugScreen != null)
            {
                if (_debugScreen.IsActive)
                {
                    _debugScreen.Update(gameTime);
                }

                if (_debugScreen.HasFocus)
                {
                    _debugScreen.HandleInput(gameTime, _input);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var screen in _screens)
            {
                if (screen.IsVisible)
                {
                    screen.Draw(gameTime);
                }
            }

            if (_debugScreen != null && _debugScreen.IsVisible)
            {
                _debugScreen.Draw(gameTime);
            }
        }

        public void AddScreen(BaseScreen screen)
        {
            if (_isInitialized)
            {
                screen.LoadContent();
            }

            _screens.Add(screen);
        }

        public void RemoveScreen(BaseScreen screen)
        {
            screen.UnloadContent();

            _screens.Remove(screen);
        }

        public List<string> GetLoadedScreenNames()
        {
            return _screens.Select(s => s.GetType().Name).ToList();
        }

        public void Clear()
        {
            _screens.RemoveAll(s => s.GetType() != typeof(DebugScreen));
        }

        public void EnableDebug()
        {
            _debugScreen = DebugScreen.Create(this);
        }

        public void DisableDebug()
        {
            _debugScreen = null;
        }

        public static ScreenManager Create(Game game, bool enableDebug = false) => new(game, enableDebug);
    }
}
