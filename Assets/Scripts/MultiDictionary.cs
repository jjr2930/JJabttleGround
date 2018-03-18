////////////////////////////////////////////////////////////////////////////////////
//
//  Created by Joo Jung Yeol
//

using UnityEngine;

namespace System.Collections.Generic
{
    public class JMultiDictionary<Key_T, Value_T> : Dictionary<Key_T, List<Value_T>>
    {
        public bool ContainsValue(Value_T obj)
        {
            foreach( var item in this )
            {
                if( item.Value.Contains(obj) )
                    return true;
            }

            return false;
        }

        public void Add(Key_T key, Value_T value)
        {
            List<Value_T> list = null;
            if( base.TryGetValue(key, out list) )
            {
                if( !list.Contains(value) )
                    list.Add(value);
                else
                    Debug.LogErrorFormat("Value is already key : {0}", key.ToString());
            }
            else
            {
                list = new List<Value_T>();
                list.Add(value);
                base.Add(key, list);
            }
        }

        public Value_T GetFirst(Key_T key)
        {
            List<Value_T> list = null;
            if( base.TryGetValue(key, out list) )
            {
                if( list.Count > 0 )
                    return list[ 0 ];
            }

            Debug.LogErrorFormat("key : {0} is not exist in dictionary", key.ToString());
            return default(Value_T);
        }

        public new int Count()
        {
            int count = 0;
            foreach( var item in this )
            {
                count += item.Value.Count;
            }

            return count;
        }

        public void Remove(Key_T key, Value_T value)
        {
            List<Value_T> list = null;
            if( base.TryGetValue(key, out list) )
            {
                if( list.Contains(value) )
                {
                    list.Remove(value);
                    return;
                }
            }

            Debug.LogErrorFormat("{0} can not founded key : {0}, value : {1}", key.ToString(), value.ToString());
        }
    }
}