using System;
using System.Collections;
using System.Threading;

public class WaitUntilOrForSeconds : IEnumerator
{
    private Func<bool> _condition;
    private DateTime _endTime;

    public WaitUntilOrForSeconds(Func<bool> condition, float seconds)
    {
        _condition = condition;
        _endTime = DateTime.Now.AddSeconds(seconds);
    }

    public object Current => null; // Not used, but required by IEnumerator

    public bool MoveNext()
    {
        return !_condition() && DateTime.Now < _endTime;
    }

    public void Reset()
    {
        throw new NotSupportedException();
    }
}
