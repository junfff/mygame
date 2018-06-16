using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;


public class EqualityComparerSingleAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(System.Collections.Generic.EqualityComparer<System.Single>); ;//这是你想继承的那个类
        }
    }

    public override Type AdaptorType
    {
        get
        {
            return typeof(Adaptor);//这是实际的适配器类
        }
    }

    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
    {
        return new Adaptor(appdomain, instance);//创建一个新的实例
    }

    //实际的适配器类需要继承你想继承的那个类，并且实现CrossBindingAdaptorType接口
    class Adaptor : System.Collections.Generic.EqualityComparer<System.Single>,
        CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;


        //缓存这个数组来避免调用时的GC Alloc
        object[] param1 = new object[1];

        public Adaptor()
        {

        }

        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            this.appdomain = appdomain;
            this.instance = instance;
        }

        public ILTypeInstance ILInstance { get { return instance; } }


        //你需要重写所有你希望在热更脚本里面重写的方法，并且将控制权转到脚本里去
        public override string ToString()
        {
            IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
            m = instance.Type.GetVirtualMethod(m);
            if (m == null || m is ILMethod)
            {
                return instance.ToString();
            }
            else
                return instance.Type.FullName;
        }

        //************************** 
        IMethod mEqualsMethod;
        bool mEqualsMethodGot;
        public bool Equals(System.Byte other)
        {
            if (!mEqualsMethodGot)
            {
                mEqualsMethod = instance.Type.GetMethod("System.IEquatable<System.Byte>.Equals", 1);
                mEqualsMethodGot = true;
            }

            if (mEqualsMethod != null)
            {
                var res = appdomain.Invoke(mEqualsMethod, instance, other);
                if (res is bool)
                {
                    return (bool)res;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        IMethod mGetHashCodeMethod;
        bool mGetHashCodeMethodGot;
        public override int GetHashCode()
        {
            if (!mGetHashCodeMethodGot)
            {
                mGetHashCodeMethod = instance.Type.GetMethod("System.IEquatable<T>.GetHashCode", 0);
                mGetHashCodeMethodGot = true;
            }

            if (mGetHashCodeMethod != null)
            {
                var res = appdomain.Invoke(mGetHashCodeMethod, instance, null);
                if (res is int)
                {
                    return (int)res;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public override int GetHashCode(System.Single obj)
        {
            return obj.GetHashCode();
        }

        public override bool Equals(System.Single x, System.Single y)
        {
            return x.Equals(y);
        }
    }
}