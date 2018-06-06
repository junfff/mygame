﻿using System;

namespace GameBase
{
    /// <summary>
    /// 统一的视图接口
    /// </summary>
    public interface IView<T> where T : ViewModelBase
    {
        T BindingContext { get; set; }
        void Reveal(bool immediate=false,Action action=null);
        void Hide(bool immediate=false,Action action=null);
    }
}
