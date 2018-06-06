using UnityEngine.Events;
using UnityEngine.UI;

namespace GameUI
{
    public static class UIHelper
    {
        //public static void AddButton(string name, IDictBinding dictBind, UnityAction action)
        //{
        //    AutoBinding abind = dictBind[name];
        //    if (null != abind)
        //    {
        //        Button btn = abind.GetComponent<Button>();
        //        if (null != btn)
        //        {
        //            btn.onClick.AddListener(action);
        //            abind.cacheObj = btn;
        //        }
        //    }
        //}
        //public static void RemoveButton(string name, IDictBinding dictBind, UnityAction action)
        //{
        //    AutoBinding abind = dictBind[name];
        //    if (null != abind && (abind.cacheObj is Button))
        //    {
        //        Button btn = abind.cacheObj as Button;
        //        btn.onClick.RemoveListener(action);
        //    }
        //}
    }
}
