using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameBase
{
    public class PropertyBinder<T> where T : ViewModelBase
    {
        private delegate void BindHandler(T viewmodel);
        private delegate void UnBindHandler(T viewmodel);

        private readonly List<BindHandler> _binders = new List<BindHandler>();

        private readonly List<UnBindHandler> _unbinders = new List<UnBindHandler>();

        public void Add<TProperty>(string name, BindableProperty<TProperty>.ValueChangedHandler valueChangedHandler)
        {
            var fieldInfo = typeof(T).GetField(name, BindingFlags.Instance | BindingFlags.Public);
            if (fieldInfo == null)
            {
                throw new Exception(string.Format("Unable to find bindableproperty field '{0}.{1}'", typeof(T).Name, name));
            }

            _binders.Add(viewmodel =>
            {
                GetPropertyValue<TProperty>(name, viewmodel, fieldInfo).OnValueChanged += valueChangedHandler;
                //Debug.LogErrorFormat(">>>>>>>>>> GetPropertyValue<TProperty>(name, viewmodel, fieldInfo).OnValueChanged = {0}", GetPropertyValue<TProperty>(name, viewmodel, fieldInfo).OnValueChanged == null);
                //Debug.LogErrorFormat(">>>>>>>>>>>> valueChangedHandler = {0}", valueChangedHandler == null);
            });

            _unbinders.Add(viewModel =>
            {
                GetPropertyValue<TProperty>(name, viewModel, fieldInfo).OnValueChanged -= valueChangedHandler;
            });

        }

        private BindableProperty<TProperty> GetPropertyValue<TProperty>(string name, T viewModel, FieldInfo fieldInfo)
        {
            var value = fieldInfo.GetValue(viewModel);
            BindableProperty<TProperty> bindableProperty = value as BindableProperty<TProperty>;
            if (bindableProperty == null)
            {
                throw new Exception(string.Format("Illegal bindableproperty field '{0}.{1}' ", typeof(T).Name, name));
            }

            return bindableProperty;
        }

        public void Bind(T viewmodel)
        {
            if (viewmodel != null)
            {
                for (int i = 0; i < _binders.Count; i++)
                {
                    _binders[i](viewmodel);
                    //Debug.LogErrorFormat("Bind _binders i = {0} viewmodel = {1}", i, viewmodel.ToString());
                }
                //Debug.LogErrorFormat("Bind _binders.Count = {0}", _binders.Count);
            }
        }

        public void Unbind(T viewmodel)
        {
            if (viewmodel != null)
            {
                for (int i = 0; i < _unbinders.Count; i++)
                {
                    _unbinders[i](viewmodel);
                }
            }
        }

    }
}
