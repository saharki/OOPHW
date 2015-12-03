using System;

namespace HW3
{
    internal class Priority<T>
    {
        private Func<object, object, bool> intIsEqual;
        private Func<object, object, bool> intIsGreater;

        public Priority(Func<object, object, bool> intIsGreater, Func<object, object, bool> intIsEqual)
        {
            this.intIsGreater = intIsGreater;
            this.intIsEqual = intIsEqual;
        }

        internal void add(int v)
        {
            throw new NotImplementedException();
        }

        internal bool removeMax()
        {
            throw new NotImplementedException();
        }
    }
}