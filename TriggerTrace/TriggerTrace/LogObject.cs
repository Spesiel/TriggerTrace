using System;
using TriggerTrace.Enums;

namespace TriggerTrace
{
    public class LogObject
    {
        public DateTime Moment { get; internal set; }
        public Level Level { get; internal set; }
        public string Message { get; internal set; }

        #region ctor

        /// <summary>
        /// Unused constructor
        /// </summary>
        private LogObject()
        {
        }

        /// <summary>
        /// Create a new log object
        /// </summary>
        /// <param name="level">The level of information contained</param>
        /// <param name="message">Message logged</param>
        ///
        public LogObject(Level level, string message)
        {
            Moment = DateTime.UtcNow;
            Level = level;
            Message = message;
        }

        #endregion ctor
    }
}