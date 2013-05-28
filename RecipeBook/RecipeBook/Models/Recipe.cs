using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace RecipeBook.Models
{
    /// <summary>
    /// class represents recipe
    /// NOTE: class has a natural ordering that is inconsistent with equals
    /// </summary>
    public class Recipe : IComparable<Recipe>, IEquatable<Recipe>
    {
        /// <summary>
        /// ID of recipe
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
        /// Name of recipe
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
        /// Type of recipe
        /// </summary>
        public MealType MealType 
        {
            get
            {
                return MealType;
            }

            set
            {
                this.MealType = value;
            }
        }

        /// <summary>
        /// Category of recipe
        /// </summary>
        public MealCategory MealCategory 
        {
            get
            {
                return MealCategory;
            }

            set
            {
                this.MealCategory = value;
            }
        }

        /// <summary>
        /// Cooking time of recipe in minutes
        /// </summary>
        public int CookingTime 
        {
            get
            {
                return CookingTime;
            }

            set
            {
                this.CookingTime = value;
            }
        }

        /// <summary>
        /// Number of portions of recipe
        /// </summary>
        public int NumPortions 
        {
            get
            {
                return NumPortions;
            }

            set
            {
                this.NumPortions = value;
            }
        }

        /// <summary>
        /// Ingredients of recipe
        /// </summary>
        public SortedSet<Ingredient> Ingredients 
        {
            get
            {
                return Ingredients;
            }

            set
            {
                if (value == null || value.Count == 0 || value.Contains(null))
                {
                    throw new ArgumentException("Ingredients cannot be null, empty or contain null element");
                }
                this.Ingredients = new SortedSet<Ingredient>(value);
            }
        }

        /// <summary>
        /// Add ingredients to recipe
        /// </summary>
        /// <param name="Ingredients">ingredients to add</param>
        public void AddIngredients(SortedSet<Ingredient> Ingredients)
        {
            if (Ingredients == null || Ingredients.Count == 0 || Instructions.Contains(null))
            {
                throw new ArgumentException("Ingredients cannot be null, empty or contain null element");
            }
            this.Ingredients.UnionWith(Ingredients);
        }

        /// <summary>
        /// Removes ingredients from recipe
        /// </summary>
        /// <param name="Ingredients">ingredients to remove</param>
        public void RemoveIngredients(SortedSet<Ingredient> Ingredients)
        {
            if (Ingredients == null || Ingredients.Count == 0 || Instructions.Contains(null))
            {
                throw new ArgumentException("Ingredients cannot be null, empty or contain null element");
            }
            this.Ingredients.ExceptWith(Ingredients);
        }

        /// <summary>
        /// Instructions of recipe
        /// </summary>
        public List<Instruction> Instructions 
        {
            get
            {
                return Instructions;
            }

            set
            {
                if (value == null || value.Count == 0 || value.Contains(null))
                {
                    throw new ArgumentException("Instructions cannot be null, empty or contain null element");
                }
                this.Instructions = new List<Instruction>(value);
            }
        }

        /// <summary>
        /// parameterless constructor
        /// create empty set of ingredients
        /// </summary>
        public Recipe()
        {
            Ingredients = new SortedSet<Ingredient>();
            Instructions = new List<Instruction>();
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

            Recipe other = (Recipe)obj;
            if (this.ID != other.ID)
            {
                return false;
            }

            if ((this.Name == null) ? (other.Name != null) : !this.Name.Equals(other.Name))
            {
                return false;
            }

            if (!(this.MealType.Equals(other.MealType)))
            {
                return false;
            }

            if (!(this.MealCategory.Equals(other.MealCategory)))
            {
                return false;
            }

            if (this.CookingTime != other.CookingTime)
            {
                return false;
            }

            if (this.NumPortions != other.NumPortions)
            {
                return false;
            }

            if ((this.Instructions == null) ? (other.Instructions != null) : !this.Instructions.Equals(other.Instructions))
            {
                return false;
            }

            if (this.Ingredients != other.Ingredients && (this.Ingredients == null || !this.Ingredients.Equals(other.Ingredients)))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 7;
            hash = 97 * hash + this.ID.GetHashCode();
            hash = 97 * hash + (this.Name != null ? this.Name.GetHashCode() : 0);
            hash = 97 * hash + this.MealType.GetHashCode();
            hash = 97 * hash + this.MealCategory.GetHashCode();
            hash = 97 * hash + this.CookingTime;
            hash = 97 * hash + this.NumPortions;
            hash = 97 * hash + (this.Instructions != null ? this.Instructions.GetHashCode() : 0);
            hash = 97 * hash + (this.Ingredients != null ? this.Ingredients.GetHashCode() : 0);
            return hash;
        }

        // override object.ToString
        public override string ToString()
        {
            return "Recipe{" + "id=" + ID + ", name=" + Name + ", type=" + MealType + ", category=" + MealCategory + ", cookingTime=" + CookingTime + ", numPortions=" + NumPortions + ", instructions=" + Instructions + ", ingredients=" + Ingredients + "}";
        }

        // override IComparable.CompareTo
        public int CompareTo(Recipe other)
        {
            long thisId = (long)this.ID;
            long otherId = (long)other.ID;
            return thisId.CompareTo(otherId);
        }

        // override IEquatable.Equals
        public bool Equals(Recipe other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.ID != other.ID)
            {
                return false;
            }

            if ((this.Name == null) ? (other.Name != null) : !this.Name.Equals(other.Name))
            {
                return false;
            }

            if (!(this.MealType.Equals(other.MealType)))
            {
                return false;
            }

            if (!(this.MealCategory.Equals(other.MealCategory)))
            {
                return false;
            }

            if (this.CookingTime != other.CookingTime)
            {
                return false;
            }

            if (this.NumPortions != other.NumPortions)
            {
                return false;
            }

            if ((this.Instructions == null) ? (other.Instructions != null) : !this.Instructions.Equals(other.Instructions))
            {
                return false;
            }

            if (this.Ingredients != other.Ingredients && (this.Ingredients == null || !this.Ingredients.Equals(other.Ingredients)))
            {
                return false;
            }
            return true;
        }
    }

    public class RecipeDBContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
    }
}
