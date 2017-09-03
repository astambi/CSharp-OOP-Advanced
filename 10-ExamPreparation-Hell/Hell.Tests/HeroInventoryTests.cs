using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    //private const int value1 = 0;
    //private const int value2 = 100;
    private const int value1 = int.MaxValue;
    private const int value2 = int.MaxValue;

    private HeroInventory heroInventory;

    [SetUp]
    public void TestInit()
    {
        this.heroInventory = new HeroInventory();
    }

    // Constructor
    [Test]
    public void ConstuctorShouldInitializeHeroInventory()
    {
        // Assert
        Assert.DoesNotThrow(() => new HeroInventory(),
                            "Constructor did not initialize HeroInventory!");
    }

    // Fields
    [Test]
    public void ConstuctorShouldInitializeEmptyCommonItemsCollections()
    {
        // Act
        var commonItemsCollection = GetCommonItems();

        // Assert
        Assert.AreEqual(0, commonItemsCollection.Count,
                        "Constructor did not initialize empty collections!");
    }

    [Test]
    public void ConstuctorShouldInitializeEmptyRecipeItemsCollections()
    {
        // Act
        var recipeItemsCollection = GetRecipeItems();

        // Assert
        Assert.AreEqual(0, recipeItemsCollection.Count,
                        "Constructor did not initialize empty collections!");
    }

    // AddCommonItem
    [Test]
    public void AddCommonItemShouldIncreaseCollectionCount()
    {
        // Arrange
        var item = new CommonItem("Common Item", 1, 2, 3, 4, 5);

        // Act
        this.heroInventory.AddCommonItem(item);

        IDictionary<string, IItem> collection = GetCommonItems();

        // Assert
        Assert.AreEqual(1, collection.Count,
                        "Add item did not increase collection count!");
    }

    [Test]
    public void AddCommonItemShouldAddCorrectItem()
    {
        // Arrange
        var item = new CommonItem("Common Item", 1, 2, 3, 4, 5);

        var inputCollection = new List<IItem>() { item };

        // Act
        this.heroInventory.AddCommonItem(item);

        IDictionary<string, IItem> collection = GetCommonItems();

        // Assert
        CollectionAssert.AreEqual(inputCollection, collection.Values.ToList(),
                        "Returned collection did not match input collection!");
    }

    [Test]
    public void AddCommonItemWithUniqueItemsShouldIncreaseCollectionCount()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("Common Item 2", 6, 7, 8, 9, 10);
        var item3 = new CommonItem("Common Item 3", 11, 12, 13, 14, 15);

        // Act
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);
        this.heroInventory.AddCommonItem(item3);

        IDictionary<string, IItem> collection = GetCommonItems();

        // Assert
        Assert.AreEqual(3, collection.Count,
                        "Add item did not increase collection count!");
    }

    [Test]
    public void AddCommonItemWithUniqueItemsShouldAddAllItems()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("Common Item 2", 6, 7, 8, 9, 10);
        var item3 = new CommonItem("Common Item 3", 11, 12, 13, 14, 15);

        var inputCollection = new List<IItem>() { item1, item2, item3 };

        // Act
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);
        this.heroInventory.AddCommonItem(item3);

        IDictionary<string, IItem> collection = GetCommonItems();

        // Assert
        CollectionAssert.AreEqual(inputCollection, collection.Values.ToList(),
                        "Returned collection did not match input collection!");
    }

    //[Test]
    //public void AddCommonItemWithExistingItemShouldThrowException()
    //{
    //    // Arrange
    //    var item = new CommonItem("Common Item", 1, 2, 3, 4, 5);

    //    // Act
    //    this.heroInventory.AddCommonItem(item);

    //    IDictionary<string, IItem> collection = GetCommonItems();

    //    // Assert
    //    Assert.Throws<ArgumentException>(
    //        () => this.heroInventory.AddCommonItem(item),
    //        "An item with the same key has already been added.");
    //}

    // AddRecipeItem
    [Test]
    public void AddRecipeItemShouldIncreaseCollectionCount()
    {
        // Arrange
        var requiredItems = new List<string>() { "i1", "i2" };
        var item = new RecipeItem("Recipe Item", 1, 2, 3, 4, 5, requiredItems);

        // Act
        this.heroInventory.AddRecipeItem(item);

        IDictionary<string, IRecipe> collection = GetRecipeItems();

        // Assert
        Assert.AreEqual(1, collection.Count,
                        "Add item did not increase collection count!");
    }

    [Test]
    public void AddRecipeItemShouldAddCorrectItem()
    {
        // Arrange
        var requiredItems = new List<string>() { "i1", "i2" };
        var item = new RecipeItem("Recipe Item", 1, 2, 3, 4, 5, requiredItems);

        var inputCollection = new List<IRecipe>() { item };

        // Act
        this.heroInventory.AddRecipeItem(item);

        IDictionary<string, IRecipe> collection = GetRecipeItems();

        // Assert
        CollectionAssert.AreEqual(inputCollection, collection.Values.ToList(),
                        "Returned collection did not match input collection!");
    }

    [Test]
    public void AddRecipeItemWithUniqueItemsShouldIncreaseCollectionCount()
    {
        // Arrange
        var requiredItems = new List<string>() { "i1", "i2" };
        var item1 = new RecipeItem("Common Item 1", 1, 2, 3, 4, 5, requiredItems);
        var item2 = new RecipeItem("Common Item 2", 6, 7, 8, 9, 10, requiredItems);
        var item3 = new RecipeItem("Common Item 3", 11, 12, 13, 14, 15, requiredItems);

        // Act
        this.heroInventory.AddRecipeItem(item1);
        this.heroInventory.AddRecipeItem(item2);
        this.heroInventory.AddRecipeItem(item3);

        IDictionary<string, IRecipe> collection = GetRecipeItems();

        // Assert
        Assert.AreEqual(3, collection.Count,
                        "Add item did not increase collection count!");
    }

    [Test]
    public void AddRecipeItemWithUniqueItemsShouldAddAllItems()
    {
        // Arrange
        var requiredItems = new List<string>() { "i1", "i2" };
        var item1 = new RecipeItem("Common Item 1", 1, 2, 3, 4, 5, requiredItems);
        var item2 = new RecipeItem("Common Item 2", 6, 7, 8, 9, 10, requiredItems);
        var item3 = new RecipeItem("Common Item 3", 11, 12, 13, 14, 15, requiredItems);

        var inputCollection = new List<IRecipe>() { item1, item2, item3 };

        // Act
        this.heroInventory.AddRecipeItem(item1);
        this.heroInventory.AddRecipeItem(item2);
        this.heroInventory.AddRecipeItem(item3);

        IDictionary<string, IRecipe> collection = GetRecipeItems();

        // Assert
        CollectionAssert.AreEqual(inputCollection, collection.Values.ToList(),
                        "Returned collection did not match input collection!");
    }

    //[Test]
    //public void AddRecipeItemWithExistingItemShouldThrowException()
    //{
    //    // Arrange
    //    var requiredItems = new List<string>() { "i1", "i2" };
    //    var item = new RecipeItem("Recipe Item", 1, 2, 3, 4, 5, requiredItems);

    //    // Act
    //    this.heroInventory.AddRecipeItem(item);

    //    IDictionary<string, IRecipe> collection = GetRecipeItems();

    //    // Assert
    //    Assert.Throws<ArgumentException>(
    //        () => this.heroInventory.AddRecipeItem(item),
    //        "An item with the same key has already been added.");
    //}

    // Total Bonuses
    [Test]
    public void TotalStrengthBonusShouldReturnCorrectBonusSum()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", value1, 0, 0, 0, 0);
        var item2 = new CommonItem("Common Item 2", value2, 0, 0, 0, 0);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        // Act
        var sumValues = (long)value1 + (long)value2;
        var totalBonus = this.heroInventory.TotalStrengthBonus;

        // Assert
        Assert.AreEqual(sumValues, totalBonus,
                        "Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalAgilityBonusShouldReturnCorrectBonusSum()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", 0, value1, 0, 0, 0);
        var item2 = new CommonItem("Common Item 2", 0, value2, 0, 0, 0);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        // Act
        var sumValues = (long)value1 + (long)value2;
        var totalBonus = this.heroInventory.TotalAgilityBonus;

        // Assert
        Assert.AreEqual(sumValues, totalBonus,
                        "Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalIntelligenceBonusShouldReturnCorrectBonusSum()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", 0, 0, value1, 0, 0);
        var item2 = new CommonItem("Common Item 2", 0, 0, value2, 0, 0);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        // Act
        var sumValues = (long)value1 + (long)value2;
        var totalBonus = this.heroInventory.TotalIntelligenceBonus;

        // Assert
        Assert.AreEqual(sumValues, totalBonus,
                        "Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalHitPointsBonusShouldReturnCorrectBonusSum()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", 0, 0, 0, value1, 0);
        var item2 = new CommonItem("Common Item 2", 0, 0, 0, value2, 0);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        // Act
        var sumValues = (long)value1 + (long)value2;
        var totalBonus = this.heroInventory.TotalHitPointsBonus;

        // Assert
        Assert.AreEqual(sumValues, totalBonus,
                        "Sum of bonuses is incorrect!");
    }

    [Test]
    public void TotalDamageBonusShouldReturnCorrectBonusSum()
    {
        // Arrange
        var item1 = new CommonItem("Common Item 1", 0, 0, 0, 0, value1);
        var item2 = new CommonItem("Common Item 2", 0, 0, 0, 0, value2);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        // Act
        var sumValues = (long)value1 + (long)value2;
        var totalBonus = this.heroInventory.TotalDamageBonus;

        // Assert
        Assert.AreEqual(sumValues, totalBonus,
                        "Sum of bonuses is incorrect!");
    }

    // CombineRecipe
    [Test]
    public void CombineRecipeShouldUpdateCommonItemsCount()
    {
        // Arrange
        var item1 = new CommonItem("CommonItem1", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("CommonItem2", 6, 7, 8, 9, 10);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        var requiredItems = new List<string>() { "CommonItem1", "CommonItem2" };
        var recipe = new RecipeItem("CommonItem3", 100, 200, 300, 400, 500, requiredItems);

        // Act
        /* Method should remove existing common items (CommonItem1, CommonItem2)
         * and add a new common item with params from recipe (CommonItem3)
         * Common Items count should be 1 (the newly added item)
         */
        MethodInfo method = GetMethodByName("CombineRecipe");
        method.Invoke(this.heroInventory, new object[] { recipe });
        var commonItemsCollection = GetCommonItems();

        // Assert
        Assert.AreEqual(1, commonItemsCollection.Count,
                        "Common items count is incorrect!");
    }

    [Test]
    public void CombineRecipeShoulRemoveAllRequiredRecipeItemsFromCommonItems()
    {
        // Arrange
        var item1 = new CommonItem("CommonItem1", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("CommonItem2", 6, 7, 8, 9, 10);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        var requiredItems = new List<string>() { "CommonItem1", "CommonItem2" };
        var recipe = new RecipeItem("CommonItem3", 100, 200, 300, 400, 500, requiredItems);

        // Act
        MethodInfo method = GetMethodByName("CombineRecipe");
        method.Invoke(this.heroInventory, new object[] { recipe });

        var commonItemsCollection = GetCommonItems();

        // Assert
        Assert.AreEqual(false, commonItemsCollection.ContainsKey(item1.Name),
                        "Required recipe item was not removed!");
        Assert.AreEqual(false, commonItemsCollection.ContainsKey(item2.Name),
                        "Required recipe item was not removed!");
    }

    [Test]
    public void CombineRecipeShouldAddNewCommonItemFromRecipe()
    {
        // Arrange
        var item1 = new CommonItem("CommonItem1", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("CommonItem2", 6, 7, 8, 9, 10);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        var requiredItems = new List<string>() { "CommonItem1", "CommonItem2" };
        var recipe = new RecipeItem("CommonItem3", 100, 200, 300, 400, 500, requiredItems);

        // Act
        MethodInfo method = GetMethodByName("CombineRecipe");
        method.Invoke(this.heroInventory, new object[] { recipe });

        var commonItemsCollection = GetCommonItems();

        // Assert
        Assert.AreEqual(true, commonItemsCollection.ContainsKey(recipe.Name),
                        "New common item was not added!");
    }

    [Test]
    public void CombineRecipeShouldAddNewCommonItemWithCorrectBonusValuesFromRecipe()
    {
        // Arrange
        var item1 = new CommonItem("CommonItem1", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("CommonItem2", 6, 7, 8, 9, 10);
        this.heroInventory.AddCommonItem(item1);
        this.heroInventory.AddCommonItem(item2);

        var requiredItems = new List<string>() { "CommonItem1", "CommonItem2" };
        var recipe = new RecipeItem("CommonItem3", 100, 200, 300, 400, 500, requiredItems);

        // Act
        MethodInfo method = GetMethodByName("CombineRecipe");
        method.Invoke(this.heroInventory, new object[] { recipe });

        var commonItemsCollection = GetCommonItems();
        var newCommonItem = commonItemsCollection[recipe.Name];

        // Assert
        Assert.AreEqual(newCommonItem.Name, recipe.Name,
                        "Incorrect Bonus value!");
        Assert.AreEqual(newCommonItem.AgilityBonus, recipe.AgilityBonus,
                        "Incorrect Bonus value!");
        Assert.AreEqual(newCommonItem.DamageBonus, recipe.DamageBonus,
                        "Incorrect Bonus value!");
        Assert.AreEqual(newCommonItem.HitPointsBonus, recipe.HitPointsBonus,
                        "Incorrect Bonus value!");
        Assert.AreEqual(newCommonItem.IntelligenceBonus, recipe.IntelligenceBonus,
                        "Incorrect Bonus value!");
        Assert.AreEqual(newCommonItem.StrengthBonus, recipe.StrengthBonus,
                        "Incorrect Bonus value!");
    }

    public void CheckRecipes()
    {
        // TODO CheckRecipes
    }

    // Helper methods for getting the CommonItems, RecipeItems & Methods from HeroInventory
    private IDictionary<string, IItem> GetCommonItems()
    {
        var type = typeof(HeroInventory);

        var field = type.GetField("commonItems", BindingFlags.Instance | BindingFlags.NonPublic);
        //var field = type
        //                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        //                .FirstOrDefault(f => 
        //                    f.GetCustomAttributes(typeof(ItemAttribute)) != null);

        var collection = (IDictionary<string, IItem>)field
                        .GetValue(this.heroInventory);

        return collection;
    }

    private IDictionary<string, IRecipe> GetRecipeItems()
    {
        var type = typeof(HeroInventory);
        var field = type.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);

        var collection = (IDictionary<string, IRecipe>)field
                        .GetValue(this.heroInventory);

        return collection;
    }

    private MethodInfo GetMethodByName(string methodName)
    {
        var type = typeof(HeroInventory);
        var method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
        return method;
    }
}