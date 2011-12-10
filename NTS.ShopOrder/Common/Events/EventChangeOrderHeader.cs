using System;
using System.Data;

namespace Common.Events
{
    public class EventChangeOrderHeader : EventArgs
    {
        public Guid IdOrderHeader { get; set; }
        public int OrderHeaderState { get; set; }
    }
}