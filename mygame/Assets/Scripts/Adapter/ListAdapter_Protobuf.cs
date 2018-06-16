
//适配文件放到主程序中
using System;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;
using System.IO;
using System.Collections.Generic;
using System.Collections;


public class ListAdapter_Protobuf : CrossBindingAdaptor
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
            return new Type[] { typeof(System.Collections.Generic.IList<Adapter_Protobuf>) };
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

    internal class Adaptor : System.Collections.Generic.IList<Adapter_Protobuf>, CrossBindingAdaptorType
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


        public Adapter_Protobuf this[int index]
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public int IndexOf(Adapter_Protobuf item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Adapter_Protobuf item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(Adapter_Protobuf item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Adapter_Protobuf item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Adapter_Protobuf[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Adapter_Protobuf item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Adapter_Protobuf> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}