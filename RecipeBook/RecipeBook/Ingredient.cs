using System;

namespace RecipeBook
{
    /// <summary>
    /// class represents ingredient
    /// same ingredients are not same, if they are not in the same recipe
    /// </summary>
    public class Ingredient : IComparable<Ingredient>, IEquatable<Ingredient>
    {
        /// <summary>
        /// attributes
        /// id of ingredient
        /// name of ingredient
        /// amount of ingredient
        /// unit of amount
        /// </summary>
        private long? id;
        private string name;
        private double amount;
        private string unit;

        /// <summary>
        /// parameterless constructor
        /// </summary>
        public Ingredient()
        {
        }

        /// <summary>
        /// getter for ID
        /// </summary>
        /// <returns>ID</returns>
        public long? GetId()
        {
            return this.id;
        }

        /// <summary>
        /// setter for ID
        /// </summary>
        /// <param name="id">ID</param>
        public void SetId(long? id)
        {
            if ((id == null) || (id < 0))
            {
                throw new ArgumentException("id cannot be null or negative");
            }
            this.id = id;
        }

        /// <summary>
        /// getter for name
        /// </summary>
        /// <returns>name</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// setter for name
        /// </summary>
        /// <param name="name">name</param>
        public void SetName(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("name cannot be null");
            }
            this.name = name;
        }

        /// <summary>
        /// getter for amount
        /// </summary>
        /// <returns>amount</returns>
        public double GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// setter for amount
        /// </summary>
        /// <param name="amount">amount</param>
        public void SetAmount(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("amount cannot be null or negative");
            }
            this.amount = amount;
        }

        /// <summary>
        /// getter for unit
        /// </summary>
        /// <returns>unit</returns>
        public string GetUnit()
        {
            return this.unit;
        }

        /// <summary>
        /// setter for unit
        /// </summary>
        /// <param name="unit">unit</param>
        public void SetUnit(string unit)
        {
            if (unit == null)
            {
                throw new ArgumentException("unit cannot be null");
            }
            this.unit = unit;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Ingredient other = (Ingredient)obj;
            if ((this.name == null) ? (other.GetName() != null) : !this.name.Equals(other.GetName()))
            {
                return false;
            }

            if (BitConverter.DoubleToInt64Bits(this.amount) != BitConverter.DoubleToInt64Bits(other.GetAmount()))
            {
                return false;
            }

            if ((this.unit == null) ? (other.unit != null) : !this.unit.Equals(other.GetUnit()))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash = 53 * hash + (this.name != null ? this.name.GetHashCode() : 0);
            hash = 53 * hash + (int)(BitConverter.DoubleToInt64Bits(this.amount) ^ (BitConverter.DoubleToInt64Bits(this.amount) >> 32));
            hash = 53 * hash + (this.unit != null ? this.unit.GetHashCode() : 0);
            return hash;
        }

        // override object.ToString
        public override string ToString()
        {
            return "Ingredient{ID = " + id + ", name = " + name + ", amount = " + amount + ", unit = " + unit + "}";
        }

        // override IComparable<Ingredient>.CompareTo
        public int CompareTo(Ingredient other)
        {
            int diff = this.GetName().CompareTo(other.GetName());
            if (diff != 0)
            {
                return diff;
            }
            else
            {
                diff = this.GetUnit().CompareTo(other.GetUnit());
                if (diff != 0)
                {
                    return diff;
                }
                else
                {
                    return this.GetAmount().CompareTo(other.GetAmount());
                }
            }
        }

        // override IEquatable.Equals
        public bool Equals(Ingredient other)
        {
            if (other == null)
            {
                return false;
            }
            if ((this.name == null) ? (other.GetName() != null) : !this.name.Equals(other.GetName()))
            {
                return false;
            }

            if (BitConverter.DoubleToInt64Bits(this.amount) != BitConverter.DoubleToInt64Bits(other.GetAmount()))
            {
                return false;
            }

            if ((this.unit == null) ? (other.unit != null) : !this.unit.Equals(other.GetUnit()))
            {
                return false;
            }
            return true;
        }
    }
}