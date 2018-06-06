namespace GameUI
{
    public class DictBinding : IDictBinding
    {
        private AutoBinding[] arrayBind;

        public DictBinding(AutoBinding[] arrayBind)
        {
            this.arrayBind = arrayBind;
        }

        public AutoBinding this[string key]
        {
            get
            {
                for (int i = 0; i < arrayBind.Length; i++)
                {
                    AutoBinding abind = arrayBind[i];
                    if (abind.name == key)
                    {
                        return abind;
                    }
                }
                return null;
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < arrayBind.Length; i++)
            {
                AutoBinding abind = arrayBind[i];
                if (null != abind)
                {
                    abind.cacheObj = null;
                }
            }
            arrayBind = null;
        }
    }
}
