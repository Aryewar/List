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

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }

        public ArrayList(int[] initArray)
        {
            Length = initArray.Length;
            _array = new int[(int)(Length * 1.33d + 1)];

            for (int i = 0; i < Length; ++i)
            {
                _array[i] = initArray[i];
            }
        }

        public void Add(int value)
        {
            Resize(Length);
            _array[Length] = value;
            ++Length;
        }

        public void AddFirst(int value)
        {
            Resize(Length);

            for (int i = Length; i >= 0; --i)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = value;

            ++Length;
        }

        public void AddByIndex(int index, int value)
        {
            if (index < Length && index >= 0)
            {
                Resize(Length);

                for (int i = Length; i >= index; --i)
                {
                    _array[i + 1] = _array[i];
                }

                _array[index] = value;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public int GetValue(int index)
        {
            if (index < Length && index >= 0)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index Out Of Randge ");
        }

        public void Remove()
        {
            --Length;
            Resize(Length);

        }

        public void RemoveFirst()
        {
            for (int i = 0; i < Length; ++i)
            {
                _array[i] = _array[i + 1];
            }

            --Length;
            Resize(Length);
        }

        public void RemoveByIndex(int index)
        {
            for (int i = index; i < Length; ++i)
            {
                _array[i] = _array[i + 1];

            }

            --Length;
            Resize(Length);
        }

        public void Remove(int nElelements)
        {
            Length -= Length >= nElelements ? nElelements : Length;
            Resize(Length);
        }

        public void RemoveFirst(int nElelements)
        {
            Length -= Length >= nElelements ? nElelements : Length;

            for (int i = 0; i < Length; ++i)
            {
                _array[i] = _array[i + nElelements];
            }

            Resize(Length);
        }

        public void RemoveByIndex(int index, int nElelements)
        {
            if (Length - index >= nElelements)
            {
                Length -= nElelements;

                for (int i = index; i < Length; ++i)
                {
                    _array[i] = _array[i + nElelements];
                }

            }
            else
            {
                Length = index;
            }
                Resize(Length);
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void ChangeByIndex(int index, int value)
        {
            if (index < Length && index >= 0)
            {

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void ReversArray()
        {
            int swapIndex;
            for (int i = 0; i < Length / 2; ++i)
            {
                swapIndex = Length - i - 1;
                Swap(i, swapIndex);
            }
        }

        public int MaxI()
        {
            int maxIndexOfElement = 0;
            for (int i = 1; i < Length; ++i)
            {
                if (_array[maxIndexOfElement] < _array[i])
                {
                    maxIndexOfElement = i;
                }
            }

            return maxIndexOfElement;
        }

        public int MinI()
        {
            int minIndexOfElement = 0;

            for (int i = 1; i < Length; ++i)
            {
                if (_array[minIndexOfElement] > _array[i])
                {
                    minIndexOfElement = i;
                }
            }

            return minIndexOfElement;
        }

        public int Max()
        {
            return _array[MaxI()];
        }

        public int Min()
        {
            return _array[MinI()];
        }

        public void RemoveValue(int value)
        {
            RemoveByIndex(IndexOf(value));
        }

        public void RemoveAllValue(int value)
        {
            int indexOfElements = IndexOf(value);
            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = IndexOf(value);
            }
        }

        public override string ToString()
        {
            string realValues = String.Empty;

            for(int i = 0; i < Length; ++i)
            {
                realValues += _array[i] + " ";
            }

            return realValues;
        }

        public override bool Equals(object obj)
        {
            ArrayList list = (ArrayList) obj;
            bool isEqual = false;

            if(this.Length == list.Length)
            {
                isEqual = true;

                for (int i = 0; i < Length; ++i)
                {
                    if (this._array[i] != list._array[i])
                    {
                        isEqual = false;
                        break;
                    }
                }
            }

            return isEqual;
        }

        private void Resize(int newLength)
        {
            if(newLength >= _array.Length)
            {
                newLength = (int)(newLength * 1.33d + 1);
                newArray(newLength);
            }
            else if((newLength <= _array.Length / 2) && (newLength > 10))
            {
                newLength = (int)(newLength * 0.66d + 1);
                newArray(newLength);
            }
            else if(newLength < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void newArray(int newLength)
        {
            if (newLength >= 0)
            {
                int[] tempArray = new int[newLength];

                for (int i = 0; i < Length; ++i)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _array[firstIndex];
            _array[firstIndex] = _array[secondIndex];
            _array[secondIndex] = temp;
        }


    }
}

