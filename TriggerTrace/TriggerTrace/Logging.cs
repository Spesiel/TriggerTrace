using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TriggerTrace.Enums;

namespace TriggerTrace
{
    public static class Logging
    {
        private static LogLibrary _logs { get; set; }
        public static ReadOnlyDictionary<Guid, LogObject> Logs { get { return new ReadOnlyDictionary<Guid, LogObject>(_logs.Library); } }

        #region Information

        private static string _information = string.Empty;

        public static string Information
        {
            get { return _information; }
            set
            {
                if (value != _information)
                {
                    _information = value;
                    Add(new LogObject(Enums.Level.Information, value));
                }
            }
        }

        #endregion Information

        #region Warning

        private static string _warning = string.Empty;

        public static string Warning
        {
            get { return _warning; }
            set
            {
                if (value != _warning)
                {
                    _warning = value;
                    Add(new LogObject(Enums.Level.Information, value));
                }
            }
        }

        #endregion Warning

        #region Problem

        private static string _problem = string.Empty;

        public static string Problem
        {
            get { return _problem; }
            set
            {
                if (value != _problem)
                {
                    _problem = value;
                    Add(new LogObject(Enums.Level.Information, value));
                }
            }
        }

        #endregion Problem

        #region Error

        private static string _error = string.Empty;

        public static string Error
        {
            get { return _error; }
            set
            {
                if (value != _error)
                {
                    _error = value;
                    Add(new LogObject(Enums.Level.Information, value));
                }
            }
        }

        #endregion Error

        /// <summary>
        /// Add a new object in the log
        /// </summary>
        /// <param name="log">The object to log</param>
        private static void Add(LogObject log)
        {
            if (_logs == null)
            {
                _logs = new LogLibrary();
            }
            _logs.Library.Add(Guid.NewGuid(), log);
        }

        #region Getters

        /// <summary>
        /// Returns the log ordered ascendingly by the moment it happened
        /// </summary>
        public static IEnumerable<LogObject> Get()
        {
            return Logs.Values.OrderBy(l => l.Moment);
        }

        /// <summary>
        /// Returns the logs of at least a level<br/>
        /// ordered ascendingly by the moment it happened
        /// </summary>
        /// <param name="level">The level of logging we filter by</param>
        public static IEnumerable<LogObject> Get(Level level)
        {
            return Logs.Values.Where(l => l.Level >= level).OrderBy(l => l.Moment);
        }

        /// <summary>
        /// Returns the logs of a defined level<br/>
        /// ordered ascendingly by the moment it happened
        /// </summary>
        /// <param name="level">The level of logging we filter by</param>
        public static IEnumerable<LogObject> GetByLevel(Level level)
        {
            return Logs.Values.Where(l => l.Level == level).OrderBy(l => l.Moment);
        }

        #endregion Getters

        public static void Show()
        {
        }
    }
}