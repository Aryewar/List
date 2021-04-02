namespace List
{
    public interface IList
    {
        int Length { get; }

        int this[int index] { get; set; }

        void Add(int value);

        void Add(IList obj);

        void AddFirst(int value);

        void AddFirst(IList obj);

        void AddByIndex(int index, int value);

        void AddByIndex(int index, IList obj);

        void Remove();

        void Remove(int count);

        void RemoveFirst();

        void RemoveFirst(int count);

        void RemoveByIndex(int index);

        void RemoveByIndex(int index, int count);

        int GetIndexByValue(int value);

        void Reverse();

        int GetMaxIndex();

        int GetMinIndex();

        int GetMaxElement();

        int GetMinElement();

        void RemoveByValue(int value);

        void RemoveAllByValue(int value);

        void Sort(bool isDecending);

        int[] ToArray();

        string ToString();

        bool Equals(object obj);
    }
}
