using System;
using System.Diagnostics;

namespace Cop.Selenium.ControlObjects.Html5.Tests
{
    internal class TestRunTimer
    {
        private readonly Stopwatch _timer = new();
        private Stopwatch _initializationTimer;
        private Stopwatch _cleanupTimer;

        public long InitializationDuration => _initializationTimer.ElapsedMilliseconds;

        public long CleanupDuration => _cleanupTimer.ElapsedMilliseconds;

        public long Duration => _timer.ElapsedMilliseconds;

        public static TestRunTimer StartNew()
        {
            var timer = new TestRunTimer();
            timer.Start();
            return timer;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void InitializationStart()
        {
            _initializationTimer = Stopwatch.StartNew();
        }

        public void InitializationStop()
        {
            _initializationTimer.Stop();
        }

        public void CleanupStart()
        {
            _cleanupTimer = Stopwatch.StartNew();
        }

        public void CleanupStop()
        {
            _cleanupTimer.Stop();
        }

        public void WriteToConsole()
        {
            Console.WriteLine($"Initialization Duration: {InitializationDuration} ms");
            Console.WriteLine($"Cleanup Duration: {CleanupDuration} ms");
            Console.WriteLine($"Total Time: {Duration} ms");
        }
    }
}