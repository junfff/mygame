namespace GameBase
{
    using System.Collections.Generic;

    public static class DictionaryExtension
    {

        /// <summary>
        /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
        /// </summary>
        public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            TValue tmp = default(TValue);
            if (!dict.TryGetValue(key, out tmp))
            {
                dict.Add(key, value);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }
        public static Dictionary<TKey, TValue> TryRemove<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            TValue tmp = default(TValue);
            if (dict.TryGetValue(key, out tmp)) dict.Remove(key);
            return dict;
        }



    }
}