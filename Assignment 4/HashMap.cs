using System;
using System.Collections.Generic;

namespace Assignment_4
{
    public class HashMap<K, V>
    {
        public Entry<StringKey, Item>[] Table;
        public int Capacity { get; set; }
        public double LoadFactor { get; set; }

        private int countActive;
        private int countPlaceholder;

        public int Size
        {
            get { return countActive; }
        }

        public int Placeholders
        {
            get { return countPlaceholder; }
        }

        public HashMap(int initialCapacity = 11, double loadFactor = 0.75)
        {
            if (initialCapacity <= 0)
                throw new ArgumentException("Capacity must be > 0");
            if (loadFactor <= 0.0 || loadFactor > 1.0)
                throw new ArgumentException("Load factor must be between 0 and 1");

            Capacity = initialCapacity;
            LoadFactor = loadFactor;
            Table = new Entry<StringKey, Item>[Capacity];
            countActive = 0;
            countPlaceholder = 0;
        }

        public bool IsEmpty()
        {
            return countActive == 0;
        }

        public void Clear()
        {
            Table = new Entry<StringKey, Item>[Capacity];
            countActive = 0;
            countPlaceholder = 0;
        }

        private int ComputeIndex(int rawHash)
        {
            int slotPos = rawHash % Capacity;
            if (slotPos < 0) slotPos += Capacity;
            return slotPos;
        }

        public int GetMatchingOrNextAvailableBucket(StringKey lookupKey)
        {
            if (lookupKey == null)
                throw new ArgumentNullException("lookupKey");

            int slotPos = ComputeIndex(lookupKey.GetHashCode());
            int origin = slotPos;

            while (Table[slotPos] != null && !Table[slotPos].Key.Equals(lookupKey))
            {
                slotPos = (slotPos + 1) % Capacity;
                if (slotPos == origin)
                    throw new InvalidOperationException("HashMap full");
            }

            return slotPos;
        }

        public Item Get(StringKey lookupKey)
        {
            if (lookupKey == null)
                throw new ArgumentNullException("lookupKey");

            int slotPos = GetMatchingOrNextAvailableBucket(lookupKey);
            var cell = Table[slotPos];
            if (cell == null || cell.Value == null)
                return null;

            return cell.Value;
        }

        public Item Put(StringKey lookupKey, Item newValue)
        {
            if (lookupKey == null)
                throw new ArgumentNullException("lookupKey");
            if (newValue == null)
                throw new ArgumentNullException("newValue");

            int loadThreshold = (int)(Capacity * LoadFactor);
            if (countActive + countPlaceholder >= loadThreshold - 1)
            {
                ReHash();
            }

            int slotPos = GetMatchingOrNextAvailableBucket(lookupKey);
            var cell = Table[slotPos];

            if (cell == null)
            {
                Table[slotPos] = new Entry<StringKey, Item>(lookupKey, newValue);
                countActive++;
                return null;
            }
            else if (cell.Value == null)
            {
                cell.Value = newValue;
                countActive++;
                countPlaceholder--;
                return null;
            }
            else
            {
                Item previous = cell.Value;
                cell.Value = newValue;
                return previous;
            }
        }

        public Item Remove(StringKey lookupKey)
        {
            if (lookupKey == null)
                throw new ArgumentNullException("lookupKey");

            int slotPos = GetMatchingOrNextAvailableBucket(lookupKey);
            var cell = Table[slotPos];
            if (cell == null || cell.Value == null)
                return null;

            Item previous = cell.Value;
            cell.Value = null;
            countActive--;
            countPlaceholder++;
            return previous;
        }

        public List<StringKey> Keys()
        {
            var keyCollection = new List<StringKey>();
            foreach (var cell in Table)
            {
                if (cell != null && cell.Value != null)
                    keyCollection.Add(cell.Key);
            }
            return keyCollection;
        }

        public List<Item> Values()
        {
            var valueCollection = new List<Item>();
            foreach (var cell in Table)
            {
                if (cell != null && cell.Value != null)
                    valueCollection.Add(cell.Value);
            }
            return valueCollection;
        }

        private void ReHash()
        {
            var oldTable = Table;
            int nextCap = NextPrime(Capacity * 2 + 1);

            Table = new Entry<StringKey, Item>[nextCap];
            Capacity = nextCap;
            countActive = 0;
            countPlaceholder = 0;

            foreach (var cell in oldTable)
            {
                if (cell != null && cell.Value != null)
                {
                    int slotPos = ComputeIndex(cell.Key.GetHashCode());
                    while (Table[slotPos] != null)
                        slotPos = (slotPos + 1) % Capacity;

                    Table[slotPos] = new Entry<StringKey, Item>(cell.Key, cell.Value);
                    countActive++;
                }
            }
        }

        private int NextPrime(int start)
        {
            int candidate = start;
            while (!IsPrime(candidate))
                candidate++;
            return candidate;
        }

        private bool IsPrime(int value)
        {
            if (value < 2) return false;
            if (value % 2 == 0) return (value == 2);
            int limitRoot = (int)Math.Sqrt(value);
            for (int divisor = 3; divisor <= limitRoot; divisor += 2)
                if (value % divisor == 0) return false;
            return true;
        }
    }
}
