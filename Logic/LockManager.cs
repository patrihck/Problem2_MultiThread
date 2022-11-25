using Problem2_MultiThread.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_MultiThread.Logic
{
    internal class LockManager
    {
        static ConcurrentDictionary<string, LockObject> _locks =
          new ConcurrentDictionary<string, LockObject>();

        private static LockObject GetLock(string filename)
        {
            LockObject o = null;
            if (_locks.TryGetValue(filename.ToLower(), out o))
            {
                o.Count++;
                return o;
            }
            else
            {
                o = new LockObject();
                _locks.TryAdd(filename.ToLower(), o);
                o.Count++;
                return o;
            }
        }

        public static void GetLock(string filename, Action action)
        {
            lock (GetLock(filename))
            {
                action();
                Unlock(filename);
            }
        }

        private static void Unlock(string filename)
        {
            LockObject o = null;
            if (_locks.TryGetValue(filename.ToLower(), out o))
            {
                o.Count--;
                if (o.Count == 0)
                    _locks.TryRemove(filename.ToLower(), out LockObject value);
            }
        }
    }
}
