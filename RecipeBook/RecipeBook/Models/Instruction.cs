using System;

namespace RecipeBook.Models
{
    /// <summary>
    /// class represents one instruction of recipe
    /// NOTE: class has a natural ordering that is inconsistent with equals
    /// </summary>
    public class Instruction : IComparable<Instruction>, IEquatable<Instruction>
    {
        /// <summary>
        /// ID of instruction
        /// </summary>
        public long? ID 
        {
            get
            {
                return ID;
            }

            set
            {
                if (value == null || value < 0)
                {
                    throw new ArgumentException("id cannot be null or negative");
                }
                this.ID = value;
            }
        }

        /// <summary>
        /// Text of instruction
        /// </summary>
        public string Text 
        {
            get
            {
                return Text;
            }

            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("text cannot be null");
                }
                this.Text = value;
            }
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

            Instruction other = (Instruction)obj;
            if ((this.Text == null) ? (other.Text != null) : !this.Text.Equals(other.Text))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash = 53 * hash + (this.Text != null ? this.Text.GetHashCode() : 0);
            return hash;
        }

        // override object.ToString
        public override string ToString()
        {
            return Text;
        }

        // override IComparable<Instruction>.CompareTo
        int IComparable<Instruction>.CompareTo(Instruction other)
        {
            if ((this.ID == null) || (other.ID == null))
            {
                throw new ArgumentException("comparing instruction with null ID");
            }
            long thisId = (long)this.ID;
            long otherId = (long)other.ID;
            return thisId.CompareTo(otherId);
        }

        // override IEquatable<Instruction>.Equals
        bool IEquatable<Instruction>.Equals(Instruction other)
        {
            if (other == null)
            {
                return false;
            }
            if ((this.Text == null) ? (other.Text != null) : !this.Text.Equals(other.Text))
            {
                return false;
            }
            return true;
        }
    }
}
