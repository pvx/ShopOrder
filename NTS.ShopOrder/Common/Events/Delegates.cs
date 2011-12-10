using System;

namespace Common.Events
{
    public delegate void OnChangeOrderHeader(object sender, EventChangeOrderHeader eventArgs);
    public delegate void OnDataRowChange(object sender, EventArgs eventArgs);

    public delegate void CloseForm(object sender, EventArgs eventArgs);
}