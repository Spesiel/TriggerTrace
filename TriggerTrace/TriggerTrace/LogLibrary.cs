using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TriggerTrace
{
    public class LogLibrary
    {
        public Dictionary<Guid, LogObject> Library { get; internal set; }

        public LogLibrary()
        {
            Library = new Dictionary<Guid, LogObject>();
        }
    }
}