using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using System;

public class IDisposableAdapter : CrossBindingAdaptor
{
    public override Type BaseCLRType
    {
        get
        {
            return typeof(IDisposable);//这是你想继承的那个类
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
    class Adaptor : IDisposable, CrossBindingAdaptorType
    {
        ILTypeInstance instance;
        ILRuntime.Runtime.Enviorment.AppDomain appdomain;
        IMethod mTestAbstract;
        bool mTestAbstractGot;
 
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

        public void Dispose()
        {
            if (!mTestAbstractGot)
            {
                mTestAbstract = instance.Type.GetMethod("Dispose", 1);
                mTestAbstractGot = true;
            }
            if (mTestAbstract != null)
            {
                appdomain.Invoke(mTestAbstract, instance, null);//没有参数建议显式传递null为参数列表，否则会自动new object[0]导致GC Alloc
            }
        }
    }
}