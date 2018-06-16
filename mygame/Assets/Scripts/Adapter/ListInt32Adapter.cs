//适配文件放到主程序中
using System;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class ListInt32Adapter : CrossBindingAdaptor
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
            return new Type[] { typeof(System.Collections.Generic.IList<System.Int32>) };
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

    internal class Adaptor : IList<Int32>, CrossBindingAdaptorType
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

        
        public Int32 this[int index]
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public int IndexOf(Int32 item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Int32 item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(Int32 item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Int32 item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Int32[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Int32 item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Int32> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}