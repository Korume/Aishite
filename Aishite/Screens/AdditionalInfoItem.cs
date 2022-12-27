using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aishite.Screens
{
    public class AdditionalInfoItem
    {
        protected SpriteFont _font = null!;
        private Vector2 _position = Vector2.Zero;
        protected Color _color = Color.MonoGameOrange;
        protected string _text = string.Empty;

        public AdditionalInfoItem()
        {
        }

        public AdditionalInfoItem(string text)
        {
            _text = text;
        }

        public Vector2 Position { get => _position; set => _position = value; }

        public virtual void LoadContent(AdditionalInfoScreen additionalInfoScreen, string fontName)
        {
            _font = additionalInfoScreen.ScreenManager.Game.Content.Load<SpriteFont>(fontName);
        }

        public virtual void Update(AdditionalInfoScreen additionalInfoScreen, GameTime gameTime)
        {
        }

        public virtual void Draw(AdditionalInfoScreen additionalInfoScreen, GameTime gameTime)
        {
            var spriteBatch = additionalInfoScreen.ScreenManager.SpriteBatch;

            spriteBatch.DrawString(_font, _text, _position, _color);
        }

        public virtual int GetHeight()
        {
            return _font.LineSpacing;
        }
    }
}
