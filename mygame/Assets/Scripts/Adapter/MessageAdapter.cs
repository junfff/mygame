//using Google.Protobuf;
//using Google.Protobuf.Reflection;
//using ILRuntime.CLR.Method;
//using ILRuntime.Runtime.Enviorment;
//using ILRuntime.Runtime.Intepreter;
//using System;
//using UnityEngine;

//public class MessageAdapter : CrossBindingAdaptor
//{
//    public override Type BaseCLRType
//    {
//        get
//        {
//            return typeof(IMessage);//这是你想继承的那个类
//        }
//    }

//    public override Type AdaptorType
//    {
//        get
//        {
//            return typeof(Adaptor);//这是实际的适配器类
//        }
//    }

//    public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
//    {
//        return new Adaptor(appdomain, instance);//创建一个新的实例
//    }

//    //实际的适配器类需要继承你想继承的那个类，并且实现CrossBindingAdaptorType接口
//    class Adaptor : IMessage, CrossBindingAdaptorType
//    {
//        ILTypeInstance instance;
//        ILRuntime.Runtime.Enviorment.AppDomain appdomain;


//        //缓存这个数组来避免调用时的GC Alloc
//        object[] param1 = new object[1];

//        public Adaptor()
//        {

//        }

//        public Adaptor(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
//        {
//            this.appdomain = appdomain;
//            this.instance = instance;
//        }

//        public ILTypeInstance ILInstance { get { return instance; } }


//        //你需要重写所有你希望在热更脚本里面重写的方法，并且将控制权转到脚本里去
//        public override string ToString()
//        {
//            IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
//            m = instance.Type.GetVirtualMethod(m);
//            if (m == null || m is ILMethod)
//            {
//                return instance.ToString();
//            }
//            else
//                return instance.Type.FullName;
//        }

//        //************************** 
//        IMethod mDescriptorMethod;
//        bool mDescriptorMethodGot;
//        public MessageDescriptor Descriptor
//        {
//            get
//            {
//                if (!mDescriptorMethodGot)
//                {
//                    mDescriptorMethod = instance.Type.GetMethod("get_Descriptor", 0);
//                    if (mDescriptorMethod == null)
//                    {
//                        //这里写System.Collections.IEnumerator.get_Current而不是直接get_Current是因为coroutine生成的类是显式实现这个接口的，通过Reflector等反编译软件可得知
//                        //为了兼容其他只实现了单一Current属性的，所以上面先直接取了get_Current
//                        mDescriptorMethod = instance.Type.GetMethod("Google.Protobuf.IMessage.get_Descriptor", 0);
//                    }
//                    mDescriptorMethodGot = true;
//                }

//                if (mDescriptorMethod != null)
//                {
//                    var res = appdomain.Invoke(mDescriptorMethod, instance, null);
//                    if (res is MessageDescriptor)
//                    {
//                        return res as MessageDescriptor;
//                    }
//                    else
//                    {
//                        Debug.LogErrorFormat("Descriptor get error !!!");
//                        return null;
//                    }
//                }
//                else
//                {
//                    Debug.LogErrorFormat("Descriptor get mDescriptorMethod null !!!");
//                    return null;
//                }
//            }
//        }

//        IMethod mMergeFromMethod;
//        bool mMergeFromMethodGot;
//        public void MergeFrom(CodedInputStream input)
//        {
//            if (!mMergeFromMethodGot)
//            {
//                mMergeFromMethod = instance.Type.GetMethod("MergeFrom", 1);
//                if (mMergeFromMethod == null)
//                {
//                    mMergeFromMethod = instance.Type.GetMethod("Google.Protobuf.IMessage.MergeFrom", 1);
//                }
//                mMergeFromMethodGot = true;
//            }

//            if (mMergeFromMethod != null)
//            {
//                appdomain.Invoke(mMergeFromMethod, instance, input);
//            }
//        }
//        IMethod mWriteToMethod;
//        bool mWriteToMethodGot;
//        public void WriteTo(CodedOutputStream output)
//        {
//            if (!mWriteToMethodGot)
//            {
//                mWriteToMethod = instance.Type.GetMethod("WriteTo", 1);
//                if (mWriteToMethod == null)
//                {
//                    mWriteToMethod = instance.Type.GetMethod("Google.Protobuf.IMessage.WriteTo", 1);
//                }
//                mWriteToMethodGot = true;
//            }

//            if (mWriteToMethod != null)
//            {
//                appdomain.Invoke(mWriteToMethod, instance, output);
//            }
//        }
//        IMethod mCalculateSizeMethod;
//        bool mCalculateSizeMethodGot;
//        public int CalculateSize()
//        {
//            if (!mCalculateSizeMethodGot)
//            {
//                mCalculateSizeMethod = instance.Type.GetMethod("CalculateSize", 0);
//                if (mCalculateSizeMethod == null)
//                {
//                    mCalculateSizeMethod = instance.Type.GetMethod("Google.Protobuf.IMessage.CalculateSize", 0);
//                }
//                mCalculateSizeMethodGot = true;
//            }

//            if (mCalculateSizeMethod != null)
//            {
//                var res = appdomain.Invoke(mCalculateSizeMethod, instance, null);
//                if (res is int)
//                {
//                    return (int)res;
//                }
//                else
//                {
//                    Debug.LogErrorFormat("CalculateSize error !!!");
//                    return 0;
//                }
//            }
//            else
//            {
//                Debug.LogErrorFormat("CalculateSize mCalculateSizeMethod is null ! !!!");
//                return 0;
//            }
//        }
//    }
//}