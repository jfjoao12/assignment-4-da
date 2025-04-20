using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class StringKey : IComparable<StringKey>
    {
        public string KeyName { get; set; }

        /// <summary>
        /// Constructor, initializes property KeyName
        /// </summary>
        /// <param name="KeyName"></param>
        public StringKey(string KeyName)
        {
            this.KeyName = KeyName;
        }

        /// <summary>
        /// Method that will validate if two KeyName are the same
        /// </summary>
        /// <param name="obj">The object to be passed, in this case, KeyName</param>
        /// <returns>True is is the same, false if it's not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(StringKey)) return false;

            StringKey objCompare = (StringKey)obj;

            return this.KeyName == objCompare.KeyName;
        }

        /// <summary>
        /// Method that will compare 2 Items
        /// </summary>
        /// <param name="other">The other KeyName to be compared</param>
        /// <returns></returns>
        public int CompareTo(StringKey other) => KeyName.CompareTo(other.KeyName);

        /// <summary>
        /// Method that returns a string
        /// </summary>
        /// <returns>Returns the HashCode of the KeyName</returns>
        public override string ToString() => $"KeyName: stop HashCode: {GetHashCode()}";

        /// <summary>
        /// Will generate a new hash for KeyName
        /// </summary>
        /// <returns>The generated hash of KeyName</returns>
        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(KeyName)) return 0;

            int hash = 0;
            int exp = 1;

            foreach (char c in KeyName)
            {
                hash += c * exp;
                exp *= 31;
            }

            return hash < 0 ? 0 : hash;
        }
    }
}
