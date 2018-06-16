//适配文件放到主程序中
using System;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class ListStringAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return null;
        }
    }

    public override Type[] BaseCLRTypes
    {
        get
        {
            return new Type[] { typeof(System.Collections.Generic.IList<System.String>) };
        }
    }

    public override Type AdaptorType
    {
        get
        {
            return typeof(Adaptor);
        }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);
    }

    internal class Adaptor : IList<String>, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;

        public Adaptor()
        {

        }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public object[] data1 = new object[1];

        public ILTypeInstance ILInstance { get { return instance; } }

        public int Count
        {
            get
            {
                return 0;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }


        public string this[int index]
        {
            get
            {
                return string.Empty;
            }
            set
            { 
}
        }

        public int IndexOf(string item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, string item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(string item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}