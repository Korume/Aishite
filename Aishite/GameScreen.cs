using Microsoft.Xna.Framework;

namespace Aishite
{
    public abstract class GameScreen
    {
        public ScreenManager ScreenManager { get; internal set; }

        public virtual void Activate()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}
