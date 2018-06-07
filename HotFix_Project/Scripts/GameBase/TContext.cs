namespace GameBase
{
    using UnityEngine.Events;

    public class TContext<T> : IContext<T> where T : class
    {
        private T mContext;
        private UnityAction<T> mOnSetContext;
        private UnityAction<T> mOnRemoveContext;
        public TContext(UnityAction<T> set, UnityAction<T> remove)
        {
            mOnSetContext = set;
            mOnRemoveContext = remove;
        }
        public T Context
        {
            get
            {
                return this.mContext;
            }
            set
            {
                if (this.mContext == value)
                {
                    return;
                }
                if (null != this.mContext)
                {
                    this.mOnRemoveContext(this.mContext);
                }
                this.mContext = value;
                if (null != this.mContext)
                {
                    this.mOnSetContext(this.mContext);
                }
            }
        }
    }
}
