using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Aishite.Screens.Menu
{
    public class MenuEntry
    {
        public Vector2 Position { get; set; }

        protected SpriteFont _font = null!;
        protected string _text;

        public event EventHandler<EventArgs>? Selected;

        public MenuEntry(string text)
        {
            _text = text;
        }

        protected internal virtual void OnSelectEntry()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }

        public virtual void LoadContent(ContentManager contentManager, string fontName)
        {
            _font = contentManager.Load<SpriteFont>(fontName);
        }

        public virtual void Update(SpriteBatch spriteBatch, bool isSelected, GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, bool isSelected, GameTime gameTime)
        {
            var color = isSelected ? Color.Yellow : Color.White;

            spriteBatch.DrawString(_font, _text, Position, color);
        }

        public virtual int GetHeight()
        {
            return _font.LineSpacing;
        }

        public virtual int GetWidth()
        {
            return (int)_font.MeasureString(_text).X;
        }
    }
}
