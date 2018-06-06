namespace Modules
{
    using GameBusiness;
    using System;
    using System.Collections.Generic;
    using uMVVM.Sources.Infrastructure;
    using UnityEngine;

    public class BusinessCollection : IInitialize, IDisposable, IUpdate, ILateUpdate, IBusinessCollection, ICoreModules
    {
        private List<ViewModelBase> listViewModel;
        private List<IBusiness> listBusiness;
        private List<IUpdate> lisUpdate;
        private List<ILateUpdate> lisLateUpdate;

        public IModulesCollection CoreModules { get; set; }

        public bool AddBusiness<T>() where T : IBusiness
        {
            T business = GetBusiness<T>();
            if (business != null)
            {
                business.refCount++;
                Debug.LogErrorFormat(">>>>> AddBusiness Already exist business !!name = {0} item.refCount !!", typeof(T).ToString(), business.refCount);
                return false;
            }

            business = System.Activator.CreateInstance<T>();

            if (business is IUpdate)
            {
                lisUpdate.Add(business as IUpdate);
            }
            if (business is ILateUpdate)
            {
                lisLateUpdate.Add(business as ILateUpdate);
            }
            if (business is ICoreModules)
            {
                (business as ICoreModules).CoreModules = this.CoreModules;
            }
            business.businessCollection = this;
            business.Initialize();
            listBusiness.Add(business);
            business.refCount++;
            return true;
        }

        public T CreateViewModel<T>() where T : ViewModelBase
        {
            //Debug.LogFormat("CreateViewModel >>>>  name = {0} !!", typeof(T).ToString());

            var enumerator = listViewModel.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.GetType() == typeof(T))
                {
                    Debug.LogErrorFormat("CreateViewModel Already exist name = {0} !!", typeof(T).ToString());
                    return (T)item;
                }
            }
            T t = System.Activator.CreateInstance<T>();
            listViewModel.Add(t);
            return t;
        }

        public void Dispose()
        {
            var enumerator = listBusiness.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.Dispose();
                RemoveUpdate(item);
            }
            var enumerator3 = listViewModel.GetEnumerator();
            while (enumerator3.MoveNext())
            {
                var item = enumerator3.Current;
                item.Dispose();
            }

            lisUpdate.Clear();
            lisLateUpdate.Clear();
            listBusiness.Clear();
            listViewModel.Clear();
        }

        public T GetViewModel<T>() where T : ViewModelBase
        {
            var enumerator = listViewModel.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.GetType() == typeof(T))
                {
                    return (T)item;
                }
            }
            Debug.LogErrorFormat("GetViewModel not find name = {0} !!", typeof(T).ToString());
            return null;
        }

        public void Initialize()
        {
            listViewModel = new List<ViewModelBase>();
            listBusiness = new List<IBusiness>();
            lisUpdate = new List<IUpdate>();
            lisLateUpdate = new List<ILateUpdate>();
        }

        public void OnEnd()
        {
            var enumerator = listBusiness.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.OnEnd();
            }
        }

        public void OnLateUpdate(float elapse)
        {
            var enumerator = lisLateUpdate.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.OnLateUpdate(elapse);
            }
        }

        public void OnStart()
        {
            var enumerator = listBusiness.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.OnStart();
            }
        }

        public void OnUpdate(float elapse)
        {
            var enumerator = lisUpdate.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                item.OnUpdate(elapse);
            }
        }

        public bool RemoveBusiness<T>() where T : IBusiness
        {
            bool ret = false;
            IBusiness removeItem = null;
            var enumerator = listBusiness.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.GetType() == typeof(T))
                {
                    removeItem = item;
                    item.refCount--;
                    ret = item.refCount == 0;
                    if (item.refCount < 0)
                    {
                        Debug.LogErrorFormat(">>>>> item.refCount < 0 business !!name = {0} item.refCount !!", typeof(T).ToString(), item.refCount);
                    }
                    break;
                }
            }

            if (ret)
            {
                removeItem.Dispose();
                RemoveUpdate(removeItem);
                listBusiness.Remove(removeItem);
            }
            return ret;
        }
        private T GetBusiness<T>() where T : IBusiness
        {
            var enumerator = listBusiness.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.GetType() == typeof(T))
                {
                    return (T)item;
                }
            }
            return default(T);
        }
        private void RemoveUpdate(IBusiness removeItem)
        {
            if (removeItem is IUpdate)
            {
                IUpdate iupdate = removeItem as IUpdate;
                if (lisUpdate.Contains(iupdate))
                {
                    lisUpdate.Remove(iupdate);
                }
            }
            if (removeItem is ILateUpdate)
            {
                ILateUpdate ilateUpdate = removeItem as ILateUpdate;
                if (lisLateUpdate.Contains(ilateUpdate))
                {
                    lisLateUpdate.Remove(ilateUpdate);
                }
            }
        }
    }
}
