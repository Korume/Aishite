using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace Aishite.Screens
{
    public class AdditionalInfoScreen : GameScreen
    {
        private readonly List<AdditionalInfoItem> _additionalInfoItems = new();

        public override void Activate()
        {
            var fpsCounter = FpsCounter.Create();
            fpsCounter.LoadContent(this, "FpsFont");
            _additionalInfoItems.Add(fpsCounter);

            var version = typeof(AdditionalInfoScreen).Assembly.GetName().Version;
            var testText = new AdditionalInfoItem($"Aishite v.{version}");
            testText.LoadContent(this, "FpsFont");
            _additionalInfoItems.Add(testText);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            UpdateAdditionalInfoItemLocations();

            foreach (var additionalInfoItem in _additionalInfoItems)
            {
                additionalInfoItem.Update(this, gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();

            foreach (var additionalInfoItem in _additionalInfoItems)
            {
                additionalInfoItem.Draw(this, gameTime);
            }

            spriteBatch.End();
        }

        protected virtual void UpdateAdditionalInfoItemLocations()
        {
            var position = new Vector2(10f, 10f);

            foreach (var additionalInfoItem in _additionalInfoItems)
            {
                additionalInfoItem.Position = position;

                position.Y += additionalInfoItem.GetHeight();
            }
        }

    }
}
