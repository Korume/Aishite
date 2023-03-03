using System.Collections.Generic;
using Aishite.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aishite.Screens.Menu
{
    public abstract class MenuScreen : BaseScreen
    {
        protected readonly List<MenuEntry> _menuEntries = new();
        protected int _menuEntriesHeightSum = 0;
        protected int _menuEntriesWidthSum = 0;
        protected int _selectedEntry = 0;

        protected InputAction _upInputAction;
        protected InputAction _downInputAction;
        protected InputAction _enterInputAction;

        protected MenuScreen(ScreenManager screenManager, bool isPopup) : base(screenManager, isPopup)
        {
            _upInputAction = new InputAction(new Keys[] { Keys.Up }, true);
            _downInputAction = new InputAction(new Keys[] { Keys.Down }, true);
            _enterInputAction = new InputAction(new Keys[] { Keys.Enter }, true);
        }

        public override void LoadContent()
        {
            foreach (var menuEntry in _menuEntries)
            {
                menuEntry.LoadContent(ScreenManager.Game.Content, FontNames.DefaultFont);

                _menuEntriesHeightSum += menuEntry.GetHeight();

                var menuEntryWidth = menuEntry.GetWidth();
                if (menuEntryWidth > _menuEntriesWidthSum)
                {
                    _menuEntriesWidthSum = menuEntryWidth;
}
            }
        }

        public override void HandleInput(GameTime gameTime, InputState input)
        {
            if (_upInputAction.Evaluate(input))
            {
                _selectedEntry--;

                if (_selectedEntry < 0)
                {
                    _selectedEntry = _menuEntries.Count - 1;
                }
            }

            if (_downInputAction.Evaluate(input))
            {
                _selectedEntry++;

                if (_selectedEntry >= _menuEntries.Count)
                {
                    _selectedEntry = 0;
                }
            }

            if (_enterInputAction.Evaluate(input))
            {
                _menuEntries[_selectedEntry].OnSelectEntry();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            var spriteBatch = ScreenManager.SpriteBatch;

            for (int i = 0; i < _menuEntries.Count; i++)
            {
                bool isSelected = i == _selectedEntry;

                _menuEntries[i].Update(spriteBatch, isSelected, gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            UpdateMenuEntryLocations();

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            for (int i = 0; i < _menuEntries.Count; i++)
            {
                var menuEntry = _menuEntries[i];

                bool isSelected = i == _selectedEntry;
                menuEntry.Draw(spriteBatch, isSelected, gameTime);
            }

            spriteBatch.End();
        }

        protected virtual void UpdateMenuEntryLocations()
        {
            var initialPositionY = ScreenManager.GraphicsDevice.Viewport.Height / 2 - _menuEntriesHeightSum / 2;
            var position = new Vector2(0f, initialPositionY);

            foreach (var menuEntry in _menuEntries)
            {
                position.X = ScreenManager.GraphicsDevice.Viewport.Width / 2 - menuEntry.GetWidth() / 2;

                menuEntry.Position = position;

                position.Y += menuEntry.GetHeight();
            }
        }
    }
}
