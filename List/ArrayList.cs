using System;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;

            _array = new int[10];
        }

        public ArrayList(int length)
        {
            Length = length;
            length = (int)(length * 1.33 + 1);

            _array = new int[length];
        }

        public void Add(int value)
        {
            if(Length == _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;
            ++Length;
        }

        public void RemoveLast()
        {
            if (Length != 0)
            {
                if ((Length == _array.Length / 2) && (Length > 10))
                {
                    DownSize();
                }

                --Length;
            }
        }

        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33 + 1);
            int[] tmpArray = new int[newLength];

            for(int i = 0; i < _array.Length; ++i)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.33 + 1);
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < _array.Length; ++i)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }
}
