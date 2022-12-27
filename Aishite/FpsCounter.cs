using System.Collections.Generic;
using System.Linq;
using Aishite.Screens;
using Microsoft.Xna.Framework;

namespace Aishite
{
    public class FpsCounter : AdditionalInfoItem
    {
        public int AverageFps { get; private set; }

        private const int _maximumSamples = 10;

        private readonly Queue<float> _sampleBuffer;

        public FpsCounter()
        {
            _sampleBuffer = new(_maximumSamples);
        }

        public override void Update(AdditionalInfoScreen additionalInfoScreen, GameTime gameTime)
        {
            var currentFps = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;

            _sampleBuffer.Enqueue(currentFps);

            if (_sampleBuffer.Count >= _maximumSamples)
            {
                _sampleBuffer.Dequeue();

                AverageFps = (int)_sampleBuffer.Average(i => i);
                _text = $"FPS: {AverageFps}";
            }
        }

        public static FpsCounter Create() => new();
    }
}
