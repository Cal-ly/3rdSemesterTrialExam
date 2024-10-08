namespace WoodPelletTests;

[TestClass]
public class WoodPelletRepositoryTest
{
    private WoodPellet CreateValidWoodPellet()
    {
        return new WoodPellet
        {
            Id = 1,
            Brand = "TestBrand",
            Price = 10.0m,
            Quantity = 3
        };
    }

    [TestMethod("GetAll")]
    public void GetAll_ShouldReturnAllWoodPellets()
    {
        // Arrange
        var repository = new WoodPelletRepository();
        var woodPellet = CreateValidWoodPellet();
        repository.Add(woodPellet);

        // Act
        var result = repository.GetAll();

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(woodPellet, result[0]);
    }

    [TestMethod("GetById")]
    public void GetById_ShouldReturnCorrectWoodPellet()
    {
        // Arrange
        var repository = new WoodPelletRepository();
        var woodPellet = CreateValidWoodPellet();
        repository.Add(woodPellet);

        // Act
        var result = repository.GetById(woodPellet.Id);

        // Assert
        Assert.AreEqual(woodPellet, result);
    }

    [TestMethod("GetById Not Found")]
    public void GetById_ShouldReturnNull_WhenNotFound()
    {
        // Arrange
        var repository = new WoodPelletRepository();

        // Act
        var result = repository.GetById(1);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod("Add")]
    public void Add_ShouldAddNewWoodPellet()
    {
        // Arrange
        var repository = new WoodPelletRepository();
        var woodPellet = CreateValidWoodPellet();

        // Act
        var result = repository.Add(woodPellet);

        // Assert
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual(1, repository.GetAll().Count);
    }

    [TestMethod("Update")]
    public void Update_ShouldUpdateExistingWoodPellet()
    {
        // Arrange
        var repository = new WoodPelletRepository();
        var woodPellet = CreateValidWoodPellet();
        repository.Add(woodPellet);
        woodPellet.Brand = "UpdatedBrand";

        // Act
        var result = repository.Update(woodPellet);

        // Assert
        Assert.AreEqual("UpdatedBrand", result.Brand);
    }

    [TestMethod("Update Not Found")]
    [ExpectedException(typeof(ArgumentException))]
    public void Update_ShouldThrowException_WhenNotFound()
    {
        // Arrange
        var repository = new WoodPelletRepository();
        var woodPellet = CreateValidWoodPellet();

        // Act
        repository.Update(woodPellet);

        // Assert is handled by ExpectedException
    }

    [TestMethod("Delete")]
    public void Delete_ShouldRemoveWoodPellet()
    {
        // Arrange
        var repository = new WoodPelletRepository();
        var woodPellet = CreateValidWoodPellet();
        repository.Add(woodPellet);

        // Act
        var result = repository.Delete(woodPellet.Id);

        // Assert
        Assert.AreEqual(woodPellet, result);
        Assert.AreEqual(0, repository.GetAll().Count);
    }

    [TestMethod("Delete Not Found")]
    [ExpectedException(typeof(ArgumentException))]
    public void Delete_ShouldThrowException_WhenNotFound()
    {
        // Arrange
        var repository = new WoodPelletRepository();

        // Act
        var result = repository.Delete(1);

        // Assert
        // Is handled by ExpectedException
    }
}
