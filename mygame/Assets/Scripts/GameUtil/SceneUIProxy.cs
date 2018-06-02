namespace GameUtil
{
    using GameUI;
    using Modules;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class SceneUIProxy : IUIUtil
    {
        //*********************
        private Dictionary<int, IBaseView> _UIDict;
        public ICoreUtil Core { get; set; }

        public IModulesCollection CoreModules { get; set; }

        public void Initialize()
        {
            _UIDict = new Dictionary<int, IBaseView>();
        }
        public void Dispose()
        {
            while (_contextStack.Count > 0)
            {
                this.Pop();
            }

            var enumerator = _UIDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Value.Dispose();
            }
            _UIDict.Clear();
        }

        public bool Show(int panelId)
        {
            IBaseView panel = CreatePanel(panelId);
            Push(panelId);
            return true;
        }
        public bool Hide(int panelId)
        {
            //BaseView panel = GetView(panelId);
            //contextMgr.Pop();
            return true;
        }

        public IBaseView CreatePanel(int panelId)
        {
            IBaseView tmp = null;
            if (_UIDict.TryGetValue(panelId, out tmp))
            {
                return tmp;
            }

            IBaseView view = ViewFactory.CreateView(panelId);

            UIType uiType = view.ViewType;
            if (null == uiType)
            {
                Debug.LogErrorFormat("path null error!!");
            }
            GameObject go = this.CoreModules.resMDL.GetRes<GameObject>(uiType.Path);
            if (null == go)
            {
                Debug.LogErrorFormat("GameObject null error!!");
            }
            go.transform.SetParent(CoreModules.seneUnity.uiRoot, false);
            go.name = uiType.Name;

            MonoUI monoUI = go.GetComponent<MonoUI>();
            if (null == view)
            {
                Debug.LogErrorFormat("view null error!!");
            }
            view.Core = this.Core;
            view.monoUI = monoUI;
            view.Initialize();
            _UIDict.AddOrReplace(uiType.panelId, view);

            return view;
        }



        public void BackPage()
        {
            if (contextMgrCount > 1)
            {
                Pop();
            }
        }











        public void Back()
        {
            throw new System.NotImplementedException();
        }


        public void BackPageTo(int panelId)
        {
            throw new System.NotImplementedException();
        }







        public bool IsShow(int panelId)
        {
            throw new System.NotImplementedException();
        }



        //********************
        public int contextMgrCount { get { return _contextStack.Count; } }
        private Stack<IBaseView> _contextStack = new Stack<IBaseView>();

    

        public void Push(int panelId)
        {
            IBaseView nextView = Core.UI.CreatePanel(panelId);
            if (_contextStack.Count != 0)
            {
                IBaseView curView = _contextStack.Peek();
                if (IsNew(nextView))
                {
                    curView.OnExit();
                }
                else
                {
                    curView.OnPause();
                }
            }

            _contextStack.Push(nextView);
            _UIDict.AddOrReplace(nextView.ViewType.panelId, nextView);
            nextView.OnEnter();
        }

        private bool IsNew(IBaseView nextView)
        {
            return (nextView.monoUI.style & UIStyle.NEW) > 0;
        }

        public void Pop()
        {
            if (_contextStack.Count != 0)
            {
                IBaseView curView = _contextStack.Peek();
                _contextStack.Pop();
                _UIDict.TryRemove(curView.ViewType.panelId);
                curView.OnExit();
            }

            if (_contextStack.Count != 0)
            {
                IBaseView curView = _contextStack.Peek();
                curView.OnResume();
            }
        }

        public IBaseView PeekOrNull()
        {
            if (_contextStack.Count != 0)
            {
                return _contextStack.Peek();
            }
            return null;
        }

 
    }
}
