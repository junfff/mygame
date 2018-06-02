
using UnityEngine;

public class BitMaskAttribute : PropertyAttribute
{
    public System.Type propType;
    public BitMaskAttribute(System.Type t)     
    {
        propType = t;
    }
}

