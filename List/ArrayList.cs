using System;
using System.Text;

namespace List
{
    public class ArrayList: IList
    {
        public int Length { get; private set; }

        private int[] _array;
        private const int zeroIndex = 0;
        private const int shiftByOne = 1;

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

        public static ArrayList Create(int[] initArray)
        {
            if (!(initArray == null))
            {
                return new ArrayList(initArray);
            }

            throw new ArgumentException("initArray is null");
        }

        public void Add(int value)
        {
            Resize(Length);
            _array[Length] = value;
            ++Length;
        }

        public void Add(IList obj)
        {
            if (!(obj is null))
            {
                ArrayList list = ArrayList.Create(obj.ToArray());
                int oldLength = Length;
                Length += list.Length;

                Resize(oldLength);

                for (int i = 0; i < list.Length; ++i)
                {
                    _array[oldLength + i] = list[i];
                }
            }
            else
            {
                throw new ArgumentNullException("obj is null");
            }
        }

        public void AddFirst(int value)
        {
            ++Length;
            Resize(Length);
            ShiftRight(zeroIndex, shiftByOne);
            _array[zeroIndex] = value;
        }

        public void AddFirst(IList obj)
        {
            if (!(obj is null))
            {
                AddByIndex(zeroIndex, obj);
            }
            else
            {
                throw new ArgumentNullException("obj is null");
            }
        }

        public void AddByIndex(int index, int value)
        {
            if ((index == 0 && Length == 0) || (index < Length && index >= 0))
            {
                Resize(Length);
                ++Length;

                ShiftRight(index, shiftByOne);

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void AddByIndex(int index, IList obj)
        {
            if (!(obj is null))
            {
                if ((index == 0 && Length == 0) || (index < Length && index >= 0))
                {
                    ArrayList list = ArrayList.Create((obj.ToArray()));

                    int oldLength = Length;
                    Length += list.Length;

                    Resize(oldLength);

                    ShiftRight(index + list.Length - 1, list.Length);

                    for (int i = 0; i < list.Length; ++i)
                    {
                        _array[i + index] = list[i];
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Index Out Of Randge ");
                }
            }
            else
            {
                throw new ArgumentNullException(" obj is null");
            }
        }

        public void Remove()
        {
            if (Length > 0)
            {
                --Length;
                Resize(Length);
            }
        }

        public void RemoveFirst()
        {
            if (Length > 0)
            {
                ShiftLeft(zeroIndex, shiftByOne);
                --Length;
            }

            Resize(Length);
        }

        public void RemoveByIndex(int index)
        {
            if ((index == 0 && Length == 0) || (index < Length && index >= 0))
            {
                if (!(Length == 0))
                {
                    --Length;
                    ShiftLeft(index, shiftByOne);
                }

                Resize(Length);
            }
            else
            {
                throw new IndexOutOfRangeException("Index Out Of Randge ");
            }
        }

        public void Remove(int nElements)
        {
            if (nElements >= 0)
            {
                Length -= Length >= nElements ? nElements : Length;
                Resize(Length);
            }
            else
            {
                throw new ArgumentException("Removing negative number of elements");
            }
        }

        public void RemoveFirst(int nElements)
        {
            if (nElements >= 0)
            {
                Length -= Length >= nElements ? nElements : Length;

                ShiftLeft(zeroIndex, nElements);

                Resize(Length);
            }
            else
            {
                throw new ArgumentException("Removing negative number of elements");
            }
        }

        public void RemoveByIndex(int index, int nElements)
        {
            if (nElements >= 0)
            {
                if ((index == 0 && Length == 0) || (index < Length && index >= 0))
                {
                    if (Length - index >= nElements)
                    {
                        Length -= nElements;
                        ShiftLeft(index, nElements);
                    }
                    else if(Length - index > 0)
                    {
                        Length = index;
                    }
                    else
                    {
                        Length = 0;
                    }

                    Resize(Length);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index Out Of Randge ");
                }
            }
            else
            {
                throw new ArgumentException("Removing negative number of elements");
            }
        }

        public int GetIndexByValue(int value)
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

        public void Reverse()
        {
            int swapIndex;
            for (int i = 0; i < Length / 2; ++i)
            {
                swapIndex = Length - i - 1;
                Swap(i, swapIndex);
            }
        }

        public int GetMaxIndex()
        {
            if (Length != 0)
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
            else
            {
                throw new ArgumentException();
            }
        }

        public int GetMinIndex()
        {
            if (Length != 0)
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
            else
            {
                throw new ArgumentException();
            }
        }

        public int GetMaxElement()
        {
            return _array[GetMaxIndex()];
        }

        public int GetMinElement()
        {
            return _array[GetMinIndex()];
        }

        public int this[int index]
        {
            get
            {
                if (index < Length && index >= 0)
                {
                    return _array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }

            set
            {
                if (index < Length && index >= 0)
                {
                    _array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
        }

        public void RemoveByValue(int value)
        {
            int index = GetIndexByValue(value);

            if (!(index == -1))
            {
                RemoveByIndex(index);
            }
        }

        public void RemoveAllByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (value == _array[i])
                {
                    RemoveByIndex(i);
                    --i;
                }
            }
        }

        public void Sort(bool isDecending)
        {
            if (_array != null)
            {
                for (int i = 0; i < Length; ++i)
                {
                    int maxIndex = i;
                    for (int j = i; j < Length; ++j)
                    {
                        if ((_array[j] < _array[maxIndex] && isDecending) || (_array[j] > _array[maxIndex] && !isDecending))
                        {
                            maxIndex = j;
                        }
                    }

                    Swap(i, maxIndex);
                }
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                arr[i] = _array[i];
            }
            return arr;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                stringBuilder.Append($"{_array[i]} ");
            }

            return stringBuilder.ToString().Trim();
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

        private ArrayList(int[] initArray)
        {
            Length = initArray.Length;
            _array = new int[(int)(Length * 1.33d + 1)];

            for (int i = 0; i < Length; ++i)
            {
                _array[i] = initArray[i];
            }
        }

        private void Resize(int oldLength)
        {
            if((Length >= _array.Length) || (Length <= _array.Length / 2))
            {
                int newLength = (int)(Length * 1.33d + 1);
                int[] tempArray = new int[newLength];

                for (int i = 0; i < oldLength; ++i)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        private void ShiftRight(int index, int nElements)
        {
            for (int i = Length - 1; i > index; --i)
            {
                _array[i] = _array[i - nElements];
            }
        }

        private void ShiftLeft(int index, int nElements)
        {
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + nElements];
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

