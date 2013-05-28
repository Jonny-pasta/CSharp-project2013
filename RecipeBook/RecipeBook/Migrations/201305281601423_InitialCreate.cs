namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MealType = c.Int(nullable: false),
                        MealCategory = c.Int(nullable: false),
                        CookingTime = c.Int(nullable: false),
                        NumPortions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        Unit = c.String(),
                        Recipe_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.Recipe_ID)
                .Index(t => t.Recipe_ID);
            
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        Recipe_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.Recipe_ID)
                .Index(t => t.Recipe_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Instructions", new[] { "Recipe_ID" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_ID" });
            DropForeignKey("dbo.Instructions", "Recipe_ID", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Recipe_ID", "dbo.Recipes");
            DropTable("dbo.Instructions");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Recipes");
        }
    }
}
