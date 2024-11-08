namespace WoodPelletTests;

[TestClass]
public class WoodPelletTest
{
    /// <summary>
    /// Creates a valid WoodPellet object for testing.
    /// </summary>
    /// <returns>A valid WoodPellet object.</returns>
    private WoodPellet CreateValidWoodPellet()
    {
        return new WoodPellet
        {
            Id = 1,
            Brand = "TestBrand",
            Price = 10.0m,
            Quality = 3
        };
    }

    /// <summary>
    /// Tests that ValidateId throws an ArgumentException when Id is not positive.
    /// </summary>
    [TestMethod("Validate Id")]
    [ExpectedException(typeof(ArgumentException))]
    public void ValidateId_ShouldThrowException_WhenIdIsNotPositive()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Id = 0;

        // Act
        woodPellet.ValidateId();

        // Assert is handled by ExpectedException
    }

    /// <summary>
    /// Tests that ValidateBrand throws an ArgumentNullException when Brand is null.
    /// </summary>
    [TestMethod("Validate Brand Null")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ValidateBrand_ShouldThrowException_WhenBrandIsNull()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Brand = null;

        // Act
        woodPellet.ValidateBrand();

        // Assert is handled by ExpectedException
    }

    /// <summary>
    /// Tests that ValidateBrand throws an ArgumentNullException when Brand is empty.
    /// </summary>
    [TestMethod("Validate Brand Empty")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ValidateBrand_ShouldThrowException_WhenBrandIsEmpty()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Brand = "";

        // Act
        woodPellet.ValidateBrand();

        // Assert is handled by ExpectedException
    }

    /// <summary>
    /// Tests that ValidateBrand throws an ArgumentException when Brand is too short.
    /// </summary>
    [TestMethod("Validate Brand Too Short")]
    [ExpectedException(typeof(ArgumentException))]
    public void ValidateBrand_ShouldThrowException_WhenBrandIsTooShort()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Brand = "A";

        // Act
        woodPellet.ValidateBrand();

        // Assert is handled by ExpectedException
    }

    /// <summary>
    /// Tests that ValidatePrice throws an ArgumentException when Price is not positive.
    /// </summary>
    [TestMethod("Validate Price")]
    [ExpectedException(typeof(ArgumentException))]
    public void ValidatePrice_ShouldThrowException_WhenPriceIsNotPositive()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Price = 0;

        // Act
        woodPellet.ValidatePrice();

        // Assert is handled by ExpectedException
    }




    /// <summary>
    /// Tests that ValidateQuality throws an ArgumentException when Quality is out of range.
    /// </summary>
    [TestMethod("Validate Quality")]
    [ExpectedException(typeof(ArgumentException))]
    public void ValidateQuality_ShouldThrowException_WhenQualityIsOutOfRange()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Quality = 0;

        // Act
        woodPellet.ValidateQuality();

        // Assert is handled by ExpectedException
    }

    /// <summary>
    /// Tests the border values for ValidateQuality within range.
    /// </summary>
    [DataTestMethod]
    [DataRow(1)]
    [DataRow(5)]
    public void ValidateQuality_ShouldNotThrowException_WhenQualityIsWithinRange(int Quality)
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Quality = Quality;

        // Act & Assert
        woodPellet.ValidateQuality();
    }

    /// <summary>
    /// Tests the border values for ValidateQuality outside range.
    /// </summary>
    [DataTestMethod]
    [DataRow(0)]
    [DataRow(6)]
    [ExpectedException(typeof(ArgumentException))]
    public void ValidateQuality_ShouldThrowException_WhenQualityIsOutsideRange(int Quality)
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        woodPellet.Quality = Quality;

        // Act
        woodPellet.ValidateQuality();

        // Assert is handled by ExpectedException
    }

    /// <summary>
    /// Tests that Equals returns true when objects are equal.
    /// </summary>
    [TestMethod("Equals True")]
    public void Equals_ShouldReturnTrue_WhenObjectsAreEqual()
    {
        // Arrange
        var woodPellet1 = CreateValidWoodPellet();
        var woodPellet2 = CreateValidWoodPellet();

        // Act
        var result = woodPellet1.Equals(woodPellet2);

        // Assert
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Tests that Equals returns false when objects are not equal.
    /// </summary>
    [TestMethod("Equals False")]
    public void Equals_ShouldReturnFalse_WhenObjectsAreNotEqual()
    {
        // Arrange
        var woodPellet1 = CreateValidWoodPellet();
        var woodPellet2 = CreateValidWoodPellet();
        woodPellet2.Id = 2;

        // Act
        var result = woodPellet1.Equals(woodPellet2);

        // Assert
        Assert.IsFalse(result);
    }

    /// <summary>
    /// Tests that GetHashCode returns the correct hash code.
    /// </summary>
    [TestMethod("GetHashCode")]
    public void GetHashCode_ShouldReturnCorrectHashCode()
    {
        // Arrange
        var woodPellet = CreateValidWoodPellet();
        var expectedHashCode = HashCode.Combine(woodPellet.Id, woodPellet.Brand, woodPellet.Price, woodPellet.Quality);

        // Act
        var result = woodPellet.GetHashCode();

        // Assert
        Assert.AreEqual(expectedHashCode, result);
    }
}
