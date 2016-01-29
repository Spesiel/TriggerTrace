using System;
using System.Collections.Generic;

namespace TriggerTrace
{
    public static class Logging
    {
        public static Dictionary<Guid, LogObject> Logs { get; internal set; }

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

        private static void Add(LogObject log)
        {
            if (Logs == null)
            {
                Logs = new Dictionary<Guid, LogObject>();
            }
            Logs.Add(Guid.NewGuid(), log);
        }
    }
}