using System;
using Microsoft.Xna.Framework;

namespace Aishite.Screens
{
    public abstract class BaseScreen
    {
        //private ScreenStates _state = ScreenStates.Active;

        public bool IsPopup { get; set; }
        public bool HasFocus { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public bool IsVisible { get; set; } = true;

        public ScreenManager ScreenManager { get; }

        protected BaseScreen(ScreenManager screenManager, bool isPopup)
        {
            ScreenManager = screenManager;
            IsPopup = isPopup;
        }

        public virtual void LoadContent()
        {
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }

        public virtual void HandleInput(GameTime gameTime, InputState input)
        {
        }

        public void ExitScreen()
        {
            ScreenManager.RemoveScreen(this);
        }
    }
}
