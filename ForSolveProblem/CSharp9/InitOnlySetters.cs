using System;
namespace ForSolveProblem
{
    public class InitOnlySetters : IProblem
    {
        public InitOnlySetters()
        {
        }

        public void RunProblem()
        {
            var t = TestClass.TestFunc();
            Console.WriteLine(t.RecordAt);
        }

        public struct WeatherObservation
        {
            public DateTime RecordAt { get; init; }

            public decimal TemperatureInCelsius { get; }

            public decimal PressureInMillibars { get; private set; }

            public WeatherObservation(decimal _)
            {
                RecordAt = DateTime.Now.Date.AddDays(1);
                TemperatureInCelsius = 20m;
                PressureInMillibars = 30m;
            }

            public void Func1()
            {
                PressureInMillibars = 40m;
            }
        }

        public class TestClass
        {
            public static WeatherObservation TestFunc()
            {
                return new WeatherObservation(15m)
                {
                    RecordAt = DateTime.Now.Date
                };
            }
        }
    }
}
