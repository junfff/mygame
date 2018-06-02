using Assets.Sources.Core.DataBinding;
using GameUtil;
using uMVVM.Sources.Infrastructure;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameUI
{
    public abstract class BaseView<T> : IBaseView where T : ViewModelBase
    {
        public UIType ViewType { get; set; }
        public ICoreUtil Core { get; set; }
        public IMonoUI monoUI { get; set; }

        private AutoBinding[] arrayBind;
        public virtual void Dispose()
        {
            if (null != BindingContext)
            {
                BindingContext.OnDestory();
                BindingContext = null;
                ViewModelProperty.OnValueChanged = null;
            }

        }

        public virtual void Initialize()
        {
            //无所ViewModel的Value怎样变化，只对OnValueChanged事件监听(绑定)一次
            ViewModelProperty.OnValueChanged += OnBindingContextChanged;
            monoUI.Initialize();
            arrayBind = monoUI.GetAutoBinding();
        }

        public virtual void OnEnter()
        {
            OnAutoBinding();
            BindingContext.OnStartReveal();

            monoUI.OnEnter();

            BindingContext.OnFinishReveal();
        }


        public virtual void OnExit()
        {
            BindingContext.OnStartHide();
            monoUI.OnExit();
            BindingContext.OnFinishHide();
        }

        public virtual void OnPause()
        {
            monoUI.OnPause();
        }

        public virtual void OnResume()
        {
            monoUI.OnResume();
        }
        public void AddButton(string name, UnityAction action)
        {
            AutoBinding abind = GetBindBy(name);
            if (null != abind)
            {
                Button btn = abind.GetComponent<Button>();
                if (null != btn)
                {
                    btn.onClick.AddListener(action);
                    abind.cacheObj = btn;
                }
            }
        }
        public void RemoveButton(string name, UnityAction action)
        {
            AutoBinding abind = GetBindBy(name);
            if (null != abind && (abind.cacheObj is Button))
            {
                Button btn = abind.cacheObj as Button;
                btn.onClick.RemoveListener(action);
            }
        }
        private AutoBinding GetBindBy(string name)
        {
            for (int i = 0; i < arrayBind.Length; i++)
            {
                AutoBinding abind = arrayBind[i];
                if (abind.name == name)
                {
                    return abind;
                }
            }
            return null;
        }

        private void OnAutoBinding()
        {
            for (int i = 0; i < arrayBind.Length; i++)
            {
                AutoBinding abind = arrayBind[i];

            }
            //Binder.Add<string>("Name", OnNamePropertyValueChanged);
            //Binder.Add<string>("Job", OnJobPropertyValueChanged);
            //Binder.Add<int>("ATK", OnATKPropertyValueChanged);
            //Binder.Add<float>("SuccessRate", OnSuccessRatePropertyValueChanged);
            //Binder.Add<State>("State", OnStatePropertyValueChanged);
        }

        //*****************************

        protected readonly PropertyBinder<T> Binder = new PropertyBinder<T>();
        public readonly BindableProperty<T> ViewModelProperty = new BindableProperty<T>();

        public T BindingContext
        {
            get { return ViewModelProperty.Value; }
            set
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
        }

    }
}
