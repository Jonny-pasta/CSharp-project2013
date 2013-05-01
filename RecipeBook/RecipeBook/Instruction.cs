using System;

namespace RecipeBook
{
    class Instruction : IComparable<Instruction>, IEquatable<Instruction>
    {
        /// <summary>
        /// attributes
        /// ID of instruction
        /// text of the instruction
        /// </summary>
        private long? id;
        private string text;

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
        /// <param name="id">ID to set</param>
        public void SetId(long? id)
        {
            if (id == null || id<0)
            {
                throw new ArgumentException("id cannot be null or negative");
            }
            this.id = id;
        }

        /// <summary>
        /// getter for text
        /// </summary>
        /// <returns>text of the instruction</returns>
        public string GetText()
        {
            return text;
        }

        /// <summary>
        /// setter for text
        /// </summary>
        /// <param name="text">text to set</param>
        public void SetText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("text cannot be null");
            }
            this.text = text;
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
            if ((this.GetText() == null) ? (other.GetText() != null) : !this.GetText().Equals(other.GetText()))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 3;
            hash = 53 * hash + (this.GetText() != null ? this.GetText().GetHashCode() : 0);
            return hash;
        }

        // override object.ToString
        public override string ToString()
        {
            return text;
        }

        // override IComparable<Instruction>.CompareTo
        int IComparable<Instruction>.CompareTo(Instruction other)
        {
            if ((this.GetId() == null) || (other.GetId() == null))
            {
                throw new ArgumentException("comparing instruction with null ID");
            }
            long thisId = (long)this.GetId();
            long otherId = (long)other.GetId();
            return thisId.CompareTo(otherId);
        }

        // override IEquatable<Instruction>.Equals
        bool IEquatable<Instruction>.Equals(Instruction other)
        {
            if (other == null)
            {
                return false;
            }
            if ((this.GetText() == null) ? (other.GetText() != null) : !this.GetText().Equals(other.GetText()))
            {
                return false;
            }
            return true;
        }
    }
}
