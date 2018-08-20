using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;
using RestSharp;
using TextToSpeech.Model;

namespace TextToSpeech
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -2;     // -10...10

            var news = APIHelper.Get<Headlines>("https://newsapi.org/", Method.GET,
                "v2/top-headlines?apiKey=6f165c1c5cdd4c7f9d5c3e3b19456547&country=in");
            synthesizer.Speak("Welcome to News Now!!");

            foreach (var headline in news.articles)
            {
                Thread.Sleep(1000);
                synthesizer.Speak(headline.title);
                Thread.Sleep(500);
                synthesizer.Speak(headline.description);
            }

            synthesizer.Speak("That's it for now. See you again in an hour!");
            // Asynchronous
            //synthesizer.SpeakAsync("Programmatically send synthesized speech or recorded sound files to any number. Get Free Trial. High Quality Voice. Highlights: Extensive Language Coverage, Engage Large Audience Efficiently, Enable Worldwide Delivery, Use Reliable Global Carrier Network.");
        }
    }
}
