﻿using System;
using System.Diagnostics;

namespace Cop.Selenium.ControlObjects.Html5;

internal static class FuncExtensions
{
    /// <summary>
    /// Executes a function until the result is true.
    /// </summary>
    internal static void WaitUntilTrue(this Func<bool> condition, TimeSpan timeout, string message)
    {
        var timer = Stopwatch.StartNew();
        while (timer.Elapsed.TotalMilliseconds < timeout.TotalMilliseconds)
        {
            if (condition())
            {
                return;
            }
        }
        throw new TimeoutException(message);
    }
}