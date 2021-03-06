﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Input;

namespace SiliconStudio.Paradox.Audio.Tests
{
    public class BasicTest : AudioTestGame
    {
        public BasicTest()
        {
            CurrentVersion = 1;
        }


        private int count;
        private SoundEffect effectA;
        private SoundMusic musicA;
        private SoundEffect effect48kHz;
        private SoundEffect effect11kHz;
        private SoundEffect effect22kHz;
        private SoundEffect effect11kHzStereo;
        private SoundEffect effect22kHzStereo;

        protected override Task LoadContent()
        {
            effect48kHz = Asset.Load<SoundEffect>("Effect48000Hz");
            effect11kHz = Asset.Load<SoundEffect>("Effect11025Hz");
            effect22kHz = Asset.Load<SoundEffect>("Effect22050Hz");
            effect11kHzStereo = Asset.Load<SoundEffect>("Effect11025HzStereo");
            effect22kHzStereo = Asset.Load<SoundEffect>("Effect22050HzStereo");

            effectA = Asset.Load<SoundEffect>("EffectToneA");
            musicA = Asset.Load<SoundMusic>("MusicToneA");

            return Task.FromResult(true);
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Input.PointerEvents.Count > 0)
            {
                if (Input.PointerEvents.Any(x => x.State == PointerState.Up))
                {
                    if (count % 5 == 0)
                        effect48kHz.Play();
                    else if (count % 5 == 1)
                        effect11kHz.Play();
                    else if (count % 5 == 2)
                        effect22kHz.Play();
                    else if (count % 5 == 3)
                        effect11kHzStereo.Play();
                    else if (count % 5 == 4)
                        effect22kHzStereo.Play();

                    count++;
                }
            }
        }

        [Test]
        public void RunBasicGame()
        {
            RunGameTest(new BasicTest());
        }

        public static void Main()
        {
            using (var game = new BasicTest())
                game.Run();
        }
    }
}