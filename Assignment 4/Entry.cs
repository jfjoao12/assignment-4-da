using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_4;

namespace Assignment_4
{
    public class Entry<K, V>
    {
        public StringKey Key{ get; set; }
        public Item Value { get; set; }

        /// <summary>
        /// Constructor, initializes properties for StringKey and Item
        /// </summary>
        /// <param name="StringKey">The StringKey of Entry</param>
        /// <param name="Item">The Item of Entry</param>
        public Entry(StringKey StringKey, Item Item)
        {
            this.Key = StringKey;
            this.Value = Item;
        }

    }
}
