using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public int GoldPieces { get; set; }
        public double Weight { get; set; }
        /// <summary>
        /// Constructor, initializes properties for Name, GoldPieces, and Weight
        /// </summary>
        /// <param name="Name">The Name of the Item</param>
        /// <param name="GoldPieces">The GoldPieces of them Item</param>
        /// <param name="Weight">The Weight of the Item</param>
        public Item(string Name, int GoldPieces, double Weight) 
        {
            this.Name = Name;
            this.GoldPieces = GoldPieces;
            this.Weight = Weight;
        }


        /// <summary>
        /// Method that will validate if two Items are the same
        /// </summary>
        /// <param name="obj"> The Object to be passed, in this case, Item</param>
        /// <returns>True is is the same, false if it's not</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Item))
            {
                return false;
            }

            Item objCompare = (Item)obj;

            return this.Name == objCompare.Name &&
                   this.GoldPieces == objCompare.GoldPieces &&
                   this.Weight == objCompare.Weight;
        }

        /// <summary>
        /// Method that will compare the Name of the 2 Items
        /// </summary>
        /// <param name="other">The other item to be compared</param>
        /// <returns></returns>
        public int CompareTo(Item other) => Name.CompareTo(other.Name);

        /// <summary>
        /// Method that returns a string
        /// </summary>
        /// <returns>Return the Item name, GoldPieces and Weight</returns>
        public override string ToString() => $"{Name} is worth {GoldPieces}gp and weighs {Weight}kg";
        

    }
}
