using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E09_TrafficLights
{
    public class Startup
    {
        public static void Main()
        {
            var lightsInput = GetLightsInput();
            var changesCount = int.Parse(Console.ReadLine());
            var trafficLightsCollection = GetTrafficLights(lightsInput);
            RunTrafficLights(changesCount, trafficLightsCollection);
        }

        private static List<string> GetLightsInput()
        {
            return Console.ReadLine()
                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToList();
        }

        private static List<TrafficLight> GetTrafficLights(List<string> lightsInput)
        {
            var trafficLightsCollection = new List<TrafficLight>();
            foreach (var lightSignal in lightsInput)
            {
                LightColor initialColorState = (LightColor)Enum.Parse(typeof(LightColor), lightSignal);
                trafficLightsCollection.Add(new TrafficLight(initialColorState));
            }

            return trafficLightsCollection;
        }

        private static void RunTrafficLights(int changesCount, List<TrafficLight> trafficLightsCollection)
        {
            for (int i = 0; i < changesCount; i++)
            {
                var builder = new StringBuilder();
                foreach (var trafficLight in trafficLightsCollection)
                {
                    trafficLight.UpdateState();
                    builder.Append(trafficLight.ColorState).Append(" ");
                }
                Console.WriteLine(builder.ToString().Trim());
            }
        }
    }
}
