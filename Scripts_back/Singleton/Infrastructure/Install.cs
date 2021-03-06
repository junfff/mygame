﻿using Assets.Sources.ViewModels;
using Assets.Sources.Views;
using GameUI;
using uMVVM.Sources.ViewModels;
using UnityEngine;


namespace uMVVM.Sources
{
    public class Install:MonoBehaviour
    {
        // Use this for initialization
        public SetupView setupView;
        public TestView testView;
        void Start()
        {
            //绑定上下文
            //setupView.BindingContext=new SetupViewModel();TODO
            testView.BindingContext=new TestViewModel();
            //以动画模式缓慢显示
            //setupView.Reveal(false, () =>
            //{
            //    Debug.Log("测试");
            //});
            //立刻显示
            testView.Reveal(true);
        }
    }
}
