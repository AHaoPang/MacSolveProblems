using System;
namespace ForSolveProblem
{
    public class TimeSpanLearn : IProblem
    {
        public void RunProblem()
        {
            Example1();
            JustDoIt();
            Function();
        }

        public void JustDoIt()
        {
            var d1 = new DateTime(2020, 1, 1, 0, 0, 1);
            var d2 = new DateTime(2020, 1, 1, 0, 0, 2);

            var d = d2 - d1;

            Console.WriteLine($"{d} | {d.Ticks}");

            var d3 = new TimeSpan(0, 0, 0, 0, 1);
            Console.WriteLine($"{d3} | {d3.Ticks}");
        }

        public void Function()
        {
            // Define two dates.
            DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);

            // Calculate the interval between the two dates.
            TimeSpan interval = date2 - date1;
            Console.WriteLine("{0} - {1} = {2}", date2, date1, interval.ToString());

            // Display individual properties of the resulting TimeSpan object.
            Console.WriteLine("   {0,-35} {1,20}", "Value of Days Component:", interval.Days);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Milliseconds:", interval.TotalMilliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Ticks:", interval.Ticks);

            // This example displays the following output:
            //       8/18/2010 1:30:30 PM - 1/1/2010 8:00:15 AM = 229.05:30:15
            //          Value of Days Component:                             229
            //          Total Number of Days:                   229.229340277778
            //          Value of Hours Component:                              5
            //          Total Number of Hours:                  5501.50416666667
            //          Value of Minutes Component:                           30
            //          Total Number of Minutes:                       330090.25
            //          Value of Seconds Component:                           15
            //          Total Number of Seconds:                      19,805,415
            //          Value of Milliseconds Component:                       0
            //          Total Number of Milliseconds:             19,805,415,000
            //          Ticks:                               198,054,150,000,000
        }

        static string Align(TimeSpan interval)
        {
            string intervalStr = interval.ToString();
            int pointIndex = intervalStr.IndexOf(':');

            pointIndex = intervalStr.IndexOf('.', pointIndex);
            if (pointIndex < 0) intervalStr += "        ";
            return intervalStr;
        }

        public void Example1()
        {
            const string numberFmt = "{0,-22}{1,18:N0}";
            const string timeFmt = "{0,-22}{1,26}";

            Console.WriteLine(
                "This example of the fields of the TimeSpan class" +
                "\ngenerates the following output.\n");
            Console.WriteLine(numberFmt, "Field", "Value");
            Console.WriteLine(numberFmt, "-----", "-----");

            // Display the maximum, minimum, and zero TimeSpan values.
            Console.WriteLine(timeFmt, "Maximum TimeSpan",
                Align(TimeSpan.MaxValue));
            Console.WriteLine(timeFmt, "Minimum TimeSpan",
                Align(TimeSpan.MinValue));
            Console.WriteLine(timeFmt, "Zero TimeSpan",
                Align(TimeSpan.Zero));
            Console.WriteLine();

            // Display the ticks-per-time-unit fields.
            Console.WriteLine(numberFmt, "Ticks per day",
                TimeSpan.TicksPerDay);
            Console.WriteLine(numberFmt, "Ticks per hour",
                TimeSpan.TicksPerHour);
            Console.WriteLine(numberFmt, "Ticks per minute",
                TimeSpan.TicksPerMinute);
            Console.WriteLine(numberFmt, "Ticks per second",
                TimeSpan.TicksPerSecond);
            Console.WriteLine(numberFmt, "Ticks per millisecond",
                TimeSpan.TicksPerMillisecond);
        }
    }
}
