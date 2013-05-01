using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecipeBook
{
    /// <summary>
    /// class represents recipe
    /// NOTE: class has a natural ordering that is inconsistent with equals
    /// </summary>
    class Recipe : IComparable<Recipe>, IEquatable<Recipe>
    {
        /// <summary>
        /// attributes
        /// ID, name, type (soup, dessert, salad...), category
        /// (meat, meatless, fish...), cookingTime (cooking time in minutes), 
        /// numPortions (number of portions), ingredients (sorted set of ingredients),
        /// instructions (instructions to cook the recipe)
        /// </summary>
        private long? id;
        private string name;
        private MealType mealType;
        private MealCategory category;
        private int cookingTime;
        private int numPortions;
        private SortedSet<Ingredient> ingredients;
        private List<Instruction> instructions;

        /// <summary>
        /// parameterless constructor
        /// create empty set of ingredients
        /// </summary>
        public Recipe()
        {
            ingredients = new SortedSet<Ingredient>();
        }

        /// <summary>
        /// getter for ID
        /// </summary>
        /// <returns>ID</returns>
        public long? GetId()
        {
            return id;
        }

        /// <summary>
        /// setter for ID
        /// </summary>
        /// <param name="id">ID</param>
        public void SetId(long? id)
        {
            if ((id==null)||(id < 0))
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
            return name;
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
        /// getter for type
        /// </summary>
        /// <returns>type</returns>
        public MealType GetMealType()
        {
            return mealType;
        }

        /// <summary>
        /// setter for type
        /// </summary>
        /// <param name="mealType">type</param>
        public void SetMealType(MealType mealType)
        {
            this.mealType = mealType;
        }

        /// <summary>
        /// getter for category
        /// </summary>
        /// <returns>category</returns>
        public MealCategory GetCategory()
        {
            return category;
        }

        /// <summary>
        /// setter for category
        /// </summary>
        /// <param name="category">category</param>
        public void SetCategory(MealCategory category)
        {
            this.category = category;
        }

        /// <summary>
        /// getter fot ingredients
        /// </summary>
        /// <returns>ingredients</returns>
        public SortedSet<Ingredient> GetIngredients()
        {
            return ingredients;
        }

        /// <summary>
        /// sets given sorted set as recipe's ingredients
        /// </summary>
        /// <param name="ingredients">ingredients</param>
        public void SetIngredients(SortedSet<Ingredient> ingredients)
        {
            if (ingredients == null)
            {
                throw new ArgumentException("ingredients cannot be null");
            }
            this.ingredients = new SortedSet<Ingredient>(ingredients);
        }

        /// <summary>
        /// adds ingredient to recipe
        /// </summary>
        /// <param name="ingredient">ingredient</param>
        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentException("ingredient cannot be null");
            }
            this.ingredients.Add(ingredient);
        }

        /// <summary>
        /// removes ingredient from recipe
        /// </summary>
        /// <param name="ingredient">ingredient</param>
        public void RemoveIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentException("ingredient cannot be null");
            }
            if (!(ingredients.Contains(ingredient)))
            {
                throw new ArgumentException("ingredient is not in this recipe");
            }
            this.ingredients.Remove(ingredient);
        }

        /// <summary>
        /// getter for cooking time
        /// </summary>
        /// <returns>cooking time</returns>
        public int GetCookingTime()
        {
            return cookingTime;
        }

        /// <summary>
        /// setter for cooking time
        /// </summary>
        /// <param name="cookingTime">cooking time</param>
        public void SetCookingTime(int cookingTime)
        {
            if (cookingTime < 0)
            {
                throw new ArgumentException("time has to be possitive");
            }
            this.cookingTime = cookingTime;
        }

        /// <summary>
        /// getter for number of portions
        /// </summary>
        /// <returns>number of portions</returns>
        public int GetNumPortions()
        {
            return numPortions;
        }

        /// <summary>
        /// setter for number of portions
        /// </summary>
        /// <param name="numPortions">number of portions</param>
        public void SetNumPortions(int numPortions)
        {
            if (numPortions < 1)
            {
                throw new ArgumentException("num of portions has to be possitive");
            }
            this.numPortions = numPortions;
        }

        /// <summary>
        /// getter for instructions
        /// </summary>
        /// <returns>instructions</returns>
        public List<Instruction> GetInstructions()
        {
            return instructions;
        }

        /// <summary>
        /// setter for instructions
        /// </summary>
        /// <param name="instructions">instructions</param>
        public void SetInstructions(List<Instruction> instructions)
        {
            if (instructions == null)
            {
                throw new ArgumentException("instructions cannot be null");
            }
            this.instructions = instructions;
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
            if (this.GetId() != other.GetId())
            {
                return false;
            }

            if ((this.GetName() == null) ? (other.GetName() != null) : !this.GetName().Equals(other.GetName()))
            {
                return false;
            }

            if (!(this.GetMealType().Equals(other.GetMealType())))
            {
                return false;
            }

            if (!(this.category.Equals(other.category)))
            {
                return false;
            }

            if (this.cookingTime != other.cookingTime)
            {
                return false;
            }

            if (this.numPortions != other.numPortions)
            {
                return false;
            }

            if ((this.instructions == null) ? (other.instructions != null) : !this.instructions.Equals(other.instructions))
            {
                return false;
            }

            if (this.ingredients != other.ingredients && (this.ingredients == null || !this.ingredients.Equals(other.ingredients)))
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 7;
            hash = 97 * hash + this.id.GetHashCode();
            hash = 97 * hash + (this.name != null ? this.name.GetHashCode() : 0);
            hash = 97 * hash + this.mealType.GetHashCode();
            hash = 97 * hash + this.category.GetHashCode();
            hash = 97 * hash + this.cookingTime;
            hash = 97 * hash + this.numPortions;
            hash = 97 * hash + (this.instructions != null ? this.instructions.GetHashCode() : 0);
            hash = 97 * hash + (this.ingredients != null ? this.ingredients.GetHashCode() : 0);
            return hash;
        }

        // override object.ToString
        public override string ToString()
        {
            return "Recipe{" + "id=" + id + ", name=" + name + ", type=" + mealType + ", category=" + category + ", cookingTime=" + cookingTime + ", numPortions=" + numPortions + ", instructions=" + instructions + ", ingredients=" + ingredients + "}";
        }

        // override IComparable.CompareTo
        public int CompareTo(Recipe other)
        {
            if ((this.GetId() == null)||(other.GetId() == null))
            {
                throw new ArgumentException("comparing recipe with null ID");
            }
            long thisId = (long)this.GetId();
            long otherId = (long)other.GetId();
            return thisId.CompareTo(otherId);
        }

        // override IEquatable.Equals
        public bool Equals(Recipe other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.GetId() != other.GetId())
            {
                return false;
            }

            if ((this.GetName() == null) ? (other.GetName() != null) : !this.GetName().Equals(other.GetName()))
            {
                return false;
            }

            if (!(this.GetMealType().Equals(other.GetMealType())))
            {
                return false;
            }

            if (!(this.category.Equals(other.category)))
            {
                return false;
            }

            if (this.cookingTime != other.cookingTime)
            {
                return false;
            }

            if (this.numPortions != other.numPortions)
            {
                return false;
            }

            if ((this.instructions == null) ? (other.instructions != null) : !this.instructions.Equals(other.instructions))
            {
                return false;
            }

            if (this.ingredients != other.ingredients && (this.ingredients == null || !this.ingredients.Equals(other.ingredients)))
            {
                return false;
            }
            return true;
        }
    }
}
