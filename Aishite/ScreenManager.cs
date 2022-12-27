using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aishite
{
    public class ScreenManager : DrawableGameComponent
    {
        private List<GameScreen> _gameScreens = new();

        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
        }

        public ScreenManager(Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (GameScreen gameScreen in _gameScreens)
            {
                gameScreen.Activate();
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var gameScreen in _gameScreens)
            {
                gameScreen.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var gameScreen in _gameScreens)
            {
                gameScreen.Draw(gameTime);
            }
        }

        public void AddScreen(GameScreen screen)
        {
            screen.ScreenManager = this;

            _gameScreens.Add(screen);
        }
    }
}
