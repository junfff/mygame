using System;

namespace GameUI
{
    public interface IDictBinding: IDisposable
    {
        AutoBinding this[string key] { get; }
    }
}
