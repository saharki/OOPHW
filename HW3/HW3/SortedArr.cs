using System;

namespace HW3
{
    class SortedArr<T>
    {
        private Func<object, object, bool> doubleIsEqual;
        private Func<object, object, bool> doubleIsGreater;

        public SortedArr(Func<object, object, bool> doubleIsGreater, Func<object, object, bool> doubleIsEqual)
        {
            this.doubleIsGreater = doubleIsGreater;
            this.doubleIsEqual = doubleIsEqual;
        }

        internal void add(double v)
        {
            throw new NotImplementedException();
        }

        internal void delete(double v)
        {
            throw new NotImplementedException();
        }

        internal bool Geti(int i)
        {
            throw new NotImplementedException();
        }
    }
}