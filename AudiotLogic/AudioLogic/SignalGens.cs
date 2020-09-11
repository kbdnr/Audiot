using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Linq;

namespace AudiotLogic.AudioLogic
{
    public static class SignalGens
    {
        public static void SinGen(double hertz = 440, double gain = 0.5, double seconds = 20)
        {
            var sine = new SignalGenerator()
            {
                Gain = gain,
                Frequency = hertz,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(seconds));


            using (var wo = new WaveOutEvent())
            {
                wo.Init(sine);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    //Thread.Sleep(500);
                }
            }
        }
    }
}
