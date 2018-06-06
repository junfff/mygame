﻿using GameBase;
using System;
using GameBase;
namespace Modules
{
    public interface IModules : IInitialize, IDisposable, IUpdate, ILateUpdate,ICoreModules
    {
        ModulesType moduleType { get; }

    }
}