using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {


        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            System_Object_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
            MonoSingleton_1_GameRoot_Binding.Register(app);
            UnityEngine_MonoBehaviour_Binding.Register(app);
            UnityEngine_SceneManagement_SceneManager_Binding.Register(app);
            System_NotSupportedException_Binding.Register(app);
            System_Collections_Generic_List_1_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_List_1_CoroutineAdapter_Binding_Adaptor_Binding_Enumerator_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Type_Binding.Register(app);
            UnityEngine_Object_Binding.Register(app);
            System_String_Binding.Register(app);
            GameUI_AutoBinding_Binding.Register(app);
            UnityEngine_UI_Text_Binding.Register(app);
            System_Activator_Binding.Register(app);
            System_Net_Sockets_Socket_Binding.Register(app);
            System_Exception_Binding.Register(app);
            System_Net_Sockets_SocketAsyncEventArgs_Binding.Register(app);
            System_Net_IPAddress_Binding.Register(app);
            System_Net_IPEndPoint_Binding.Register(app);
            System_ArraySegment_1_Byte_Binding.Register(app);
            System_Byte_Binding.Register(app);
            System_IDisposable_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_Stack_1_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_CoroutineAdapter_Binding_Adaptor_Binding_Enumerator_Int32_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_CoroutineAdapter_Binding_Adaptor_Binding.Register(app);
            UnityEngine_GameObject_Binding.Register(app);
            SceneUIUtil_Binding.Register(app);
            UnityEngine_Transform_Binding.Register(app);
            System_NotImplementedException_Binding.Register(app);
            GameUI_IMonoUI_Binding.Register(app);
            UnityEngine_Component_Binding.Register(app);
            UnityEngine_UI_Button_Binding.Register(app);
            UnityEngine_Events_UnityEvent_Binding.Register(app);
            System_Collections_IEnumerator_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Text_StringBuilder_Binding.Register(app);
            System_DateTime_Binding.Register(app);
            UnityEngine_SystemInfo_Binding.Register(app);
            System_Reflection_MethodBase_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
        }
    }
}
