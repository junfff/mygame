using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesMgr : IInitialize, IClear, IDisposable
{
    private Dictionary<ModulesType, IModules> modulesDict;
    public void Initialize()
    {
        modulesDict = new Dictionary<ModulesType, IModules>();
    }
    public void Clear()
    {

    }
    public void Add()
    {

    }

    public void Dispose()
    {
       
    }
}
