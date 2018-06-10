namespace GameUI
{
    using GameBase;
    using GameUtil;
    using UnityEngine;

    public abstract class BaseView<T> : IBaseView where T : ViewModelBase
    {
        public ICoreUtil Core { get; set; }
        public IModulesCollection CoreModules { get; set; }
        public IMonoUI monoUI { get; set; }

        protected IDictBinding dictBind;
        public UIType ViewType { get; set; }

        public virtual void Dispose()
        {
            if (null != BindingContext)
            {
                BindingContext.Dispose();
                BindingContext = null;
                ViewModelProperty.OnValueChanged = null;
            }
            dictBind.Dispose();
        }

        public virtual void Initialize()
        {
            //无所ViewModel的Value怎样变化，只对OnValueChanged事件监听(绑定)一次
            ViewModelProperty.OnValueChanged += OnBindingContextChanged;
            monoUI.Initialize();
            AutoBinding[] arrayBind = monoUI.GetAutoBinding();
            dictBind = new DictBinding(arrayBind);
        }

        public virtual void OnEnter()
        {
            BindingContext = CoreModules.sceneMDL.curScene.businessCollection.GetViewModel<T>();

            BindingContext.OnStartReveal();

            monoUI.OnEnter();

            BindingContext.OnFinishReveal();
        }


        public virtual void OnExit()
        {
            BindingContext.OnStartHide();
            monoUI.OnExit();
            BindingContext.OnFinishHide();
            BindingContext = null;
        }

        public virtual void OnPause()
        {
            monoUI.OnPause();
        }

        public virtual void OnResume()
        {
            monoUI.OnResume();
        }





        //*****************************

        protected readonly PropertyBinder<T> Binder = new PropertyBinder<T>();
        public readonly BindableProperty<T> ViewModelProperty = new BindableProperty<T>();

        public T BindingContext
        {
            get { return ViewModelProperty.Value; }
            private set
            {
                //触发OnValueChanged事件
                ViewModelProperty.Value = value;
            }
        }



        /// <summary>
        /// 绑定的上下文发生改变时的响应方法
        /// 利用反射+=/-=OnValuePropertyChanged
        /// </summary>
        public virtual void OnBindingContextChanged(T oldValue, T newValue)
        {
            Binder.Unbind(oldValue);
            Binder.Bind(newValue);
            //Debug.LogErrorFormat("OnBindingContextChanged is null? = {0}", newValue == null);
        }

    }
}
