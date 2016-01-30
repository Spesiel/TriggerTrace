using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using TriggerTrace.Enums;

namespace TriggerTrace
{
    public static class Logging
    {
        private static Dictionary<Guid, LogObject> _logs { get; set; }
        private static Window Window { get; set; }

        public static ReadOnlyDictionary<Guid, LogObject> Logs { get { return new ReadOnlyDictionary<Guid, LogObject>(_logs); } }

        #region Information

        private static string _information = string.Empty;

        public static string Information
        {
            get { return _information; }
            set
            {
                _information = value;
                Add(new LogObject(Enums.Level.Information, value));
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
                _warning = value;
                Add(new LogObject(Enums.Level.Warning, value));
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
                _problem = value;
                Add(new LogObject(Enums.Level.Problem, value));
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
                _error = value;
                Add(new LogObject(Enums.Level.Error, value));
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
                _logs = new Dictionary<Guid, LogObject>();
            }
            _logs.Add(Guid.NewGuid(), log);

            UpdateWindowList();
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

        private static LogObject GetByIndex(int index)
        {
            return Logs.Values.OrderBy(l => l.Moment).ToList()[index];
        }

        #endregion Getters

        public static void Show()
        {
            Window = new Window();
            Window.List.RetrieveVirtualItem += List_RetrieveVirtualItem;
            UpdateWindowList();
            Window.Show();
        }

        public static void Hide()
        {
            if (Window != null)
            {
                Window.Close();
                Window.Dispose();
                Window = null;
            }
        }

        private static void List_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            LogObject obj = GetByIndex(e.ItemIndex);

            ListViewItem lvi = new ListViewItem(obj.Moment.ToLongTimeString());
            lvi.SubItems.Add(obj.Level.ToString());
            lvi.SubItems.Add(obj.Message);
            e.Item = lvi;
        }

        private static void UpdateWindowList()
        {
            if (Window != null)
            {
                Window.List.VirtualListSize = Logs.Count;
            }
        }
    }
}