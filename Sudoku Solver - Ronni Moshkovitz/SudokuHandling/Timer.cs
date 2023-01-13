using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling
{
    // This class, Timer, represents a stopwatch object.
    internal class Timer
    {
        // Start time of the timer.
        private DateTime _startTime;

        // The timed result in time representation format.
        internal TimeSpan Time { get; private set; }

        // The timed result in milliseconds representation format.
        internal double TimeInMilli { get { return Time.TotalMilliseconds; } }

        // Constractor for Timer object.
        internal Timer()
        {
            // Initialize the time atribute.
            Time = TimeSpan.Zero;
        }

        // This function starts the stopwatch.
        internal void StartTimer()
        {
            _startTime = DateTime.Now;
        }

        // This function stops the stopwatch.
        internal void StopTimer()
        {
            // Stop timing.
            DateTime finish = DateTime.Now;

            // if the stopwatch never started, time is zero.
            if (_startTime == default)
            {
                Time = TimeSpan.Zero;
            }
            else
            {
                // Update time and set starting time back to defult.
                Time = finish - _startTime;
                _startTime = default;
            }
        }
    }
}