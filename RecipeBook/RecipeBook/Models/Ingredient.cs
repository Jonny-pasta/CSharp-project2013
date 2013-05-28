using System;
using System.Data.Entity;

namespace RecipeBook.Models
{
    /// <summary>
    /// class represents ingredient
    /// same ingredients are not same, if they are not in the same recipe
    /// </summary>
    public class Ingredient : IComparable<Ingredient>, IEquatable<Ingredient>
    {

        /// <summary>
        /// ID of ingredient
        /// </summary>
        public int ID 
        {
            get
            {
                return ID;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("id cannot be null or negative");
                }
                this.ID = value;
            }
        }

        /// <summary>
        /// Name of ingredient
        /// </summary>
        public string Name 
        {
            get
            {
                return Name;
            }

            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("name cannot be null or empty");
                }
                this.Name = value;
            }
        }

        /// <summary>
        /// Amount of unit
        /// </summary>
        public double Amount 
        {
            get
            {
                return Amount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("amount cannot be null or negative");
                }
                this.Amount = value;
            }
        }

        /// <summary>
        /// Unit of ingredient
        /// </summary>
        public string Unit 
        {
            get
            {
                return Unit;
            }

            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("unit cannot be null or empty");
                }
                this.Unit = value;
            }
        }

        /// <summary>
        /// parameterless constructor
        /// </summary>
        public Ingredient()
        {
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
            if ((this.Name == null) ? (other.Name != null) : !this.Name.Equals(other.Name))
            {
                return false;
            }

            if (BitConverter.DoubleToInt64Bits(this.Amount) != BitConverter.DoubleToInt64Bits(other.Amount))
            {
                return false;
            }

            if ((this.Unit == null) ? (other.Unit != null) : !this.Unit.Equals(other.Unit))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash = 53 * hash + (this.Name != null ? this.Name.GetHashCode() : 0);
            hash = 53 * hash + (int)(BitConverter.DoubleToInt64Bits(this.Amount) ^ (BitConverter.DoubleToInt64Bits(this.Amount) >> 32));
            hash = 53 * hash + (this.Unit != null ? this.Unit.GetHashCode() : 0);
            return hash;
        }

        // override object.ToString
        public override string ToString()
        {
            return "Ingredient{ID = " + ID + ", name = " + Name + ", amount = " + Amount + ", unit = " + Unit + "}";
        }

        // override IComparable<Ingredient>.CompareTo
        public int CompareTo(Ingredient other)
        {
            int diff = this.Name.CompareTo(other.Name);
            if (diff != 0)
            {
                return diff;
            }
            else
            {
                diff = this.Unit.CompareTo(other.Unit);
                if (diff != 0)
                {
                    return diff;
                }
                else
                {
                    return this.Amount.CompareTo(other.Amount);
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
            if ((this.Name == null) ? (other.Name != null) : !this.Name.Equals(other.Name))
            {
                return false;
            }

            if (BitConverter.DoubleToInt64Bits(this.Amount) != BitConverter.DoubleToInt64Bits(other.Amount))
            {
                return false;
            }

            if ((this.Unit == null) ? (other.Unit != null) : !this.Unit.Equals(other.Unit))
            {
                return false;
            }
            return true;
        }
    }

    public class IngredientDBContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}

