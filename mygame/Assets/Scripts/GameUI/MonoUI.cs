﻿namespace GameUI
{
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class MonoUI : MonoBehaviour, IMonoUI
    {
        [BitMask(typeof(UIStyle))]
        public UIStyle style = 0;
        public UIStyle uiStyle { get { return style; } }

        protected Animator _animator;
        public virtual void Initialize()
        {
            _animator = this.transform.GetComponent<Animator>();
        }
        public virtual void OnEnter()
        {
            _animator.SetTrigger("OnEnter");
        }

        public virtual void OnExit()
        {
            _animator.SetTrigger("OnExit");
        }

        public virtual void OnPause()
        {
            _animator.SetTrigger("OnPause");
        }

        public virtual void OnResume()
        {
            _animator.SetTrigger("OnResume");
        }

        public AutoBinding[] GetAutoBinding()
        {
            return this.transform.GetComponentsInChildren<AutoBinding>();
        }

    }
}
