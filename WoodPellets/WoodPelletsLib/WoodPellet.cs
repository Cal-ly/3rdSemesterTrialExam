namespace WoodPelletsLib;

/// <summary>
/// Represents a wood pellet with properties for Id, Brand, Price, and Quantity.
/// </summary>
public class WoodPellet
{
    /// <summary>
    /// Gets or sets the unique identifier for the wood pellet.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the brand of the wood pellet.
    /// </summary>
    public string? Brand { get; set; }

    /// <summary>
    /// Gets or sets the price of the wood pellet.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the wood pellet.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Validates all properties of the wood pellet.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when any property is invalid.</exception>
    public void Validate()
    {
        ValidateId();
        ValidateBrand();
        ValidatePrice();
        ValidateQuantity();
    }

    /// <summary>
    /// Validates the Id property.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when Id is not a positive number.</exception>
    public void ValidateId()
    {
        if (Id <= 0)
        {
            throw new ArgumentException("Id must be a positive number.");
        }
    }

    /// <summary>
    /// Validates the Brand property.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when Brand is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when Brand is less than 2 characters long.</exception>
    public void ValidateBrand()
    {
        if (string.IsNullOrWhiteSpace(Brand))
        {
            throw new ArgumentNullException(nameof(Brand), "Brand cannot be null or empty.");
        }
        if (Brand.Length < 2)
        {
            throw new ArgumentException("Brand must be at least 2 characters long.");
        }
    }

    /// <summary>
    /// Validates the Price property.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when Price is not a positive number.</exception>
    public void ValidatePrice()
    {
        if (Price <= 0)
        {
            throw new ArgumentException("Price must be a positive number.");
        }
    }

    /// <summary>
    /// Validates the Quantity property.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when Quantity is not between 1 and 5.</exception>
    public void ValidateQuantity()
    {
        if (Quantity < 1 || Quantity > 5)
        {
            throw new ArgumentException("Quantity must be between 1 and 5.");
        }
    }

    /// <summary>
    /// Returns a string representation of the wood pellet.
    /// </summary>
    /// <returns>A string that represents the wood pellet.</returns>
    public override string ToString()
    {
        return $"WoodPellet [Id={Id}, Brand={Brand}, Price={Price}, Quantity={Quantity}]";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is WoodPellet other)
        {
            return Id == other.Id &&
                   Brand == other.Brand &&
                   Price == other.Price &&
                   Quantity == other.Quantity;
        }
        return false;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Brand, Price, Quantity);
    }
}
