using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aishite
{
    public class InputState
    {
        public KeyboardState CurrentKeyboardState;
        public KeyboardState LastKeyboardState;

        public InputState()
        {
            CurrentKeyboardState = new KeyboardState();
        }

        public void Update()
        {
            LastKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }

        public bool IsKeyPressed(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }

        public bool IsNewKeyPress(Keys key)
        {
            if (CurrentKeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key))
            {
                return true;
            }

            return false;
        }
    }
}
