using System;
using Microsoft.Xna.Framework.Input;

namespace Aishite
{
    public class InputAction
    {
        private readonly Keys[] _keys;
        private readonly bool _newPressOnly;

        private delegate bool KeyPress(Keys key);

        public InputAction(Keys[] keys, bool newPressOnly)
        {
            _keys = keys != null ? (Keys[])keys.Clone() : Array.Empty<Keys>();

            _newPressOnly = newPressOnly;
        }

        public bool Evaluate(InputState state)
        {
            KeyPress keyPressCheck = _newPressOnly ? state.IsNewKeyPress : state.IsKeyPressed;

            foreach (Keys key in _keys)
            {
                if (keyPressCheck(key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
