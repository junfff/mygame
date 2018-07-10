namespace GameBase
{
    using GameUI;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public static class DictBindingExtension
    {
        public static T FindUI<T>(this IDictBinding dictBind, string name) where T : Component
        {
            T t = default(T);
            AutoBinding abind = dictBind[name];
            if (null != abind)
            {
                t = abind.GetComponent<T>();
            }
            return t;
        }
        public static Button AddButton(this IDictBinding dictBind, string name, UnityAction action)
        {
            Button btn = null;
            AutoBinding abind = dictBind[name];
            if (null != abind)
            {
                btn = abind.GetComponent<Button>();
                if (null != btn)
                {
                    btn.onClick.AddListener(action);
                    abind.cacheObj = btn;
                }
            }
            return btn;
        }
        public static Button RemoveButton(this IDictBinding dictBind, string name, UnityAction action)
        {
            Button btn = null;
            AutoBinding abind = dictBind[name];
            if (null != abind && (abind.cacheObj is Button))
            {
                btn = abind.cacheObj as Button;
                btn.onClick.RemoveListener(action);
            }
            return btn;
        }

    }

}