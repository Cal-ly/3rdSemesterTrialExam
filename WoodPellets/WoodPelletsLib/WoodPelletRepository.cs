namespace WoodPelletsLib;

public class WoodPelletRepository
{
    private readonly List<WoodPellet> _woodPellets = [];

    public int NextId => FindNextId();

    /// <summary>
    /// Gets all wood pellets.
    /// </summary>
    /// <returns>A list of all wood pellets.</returns>
    public List<WoodPellet> GetAll()
    {
        return new List<WoodPellet>(_woodPellets);
    }

    /// <summary>
    /// Gets a wood pellet by its Id.
    /// </summary>
    /// <param name="id">The Id of the wood pellet.</param>
    /// <returns>The wood pellet with the specified Id, or null if not found.</returns>
    public WoodPellet? GetById(int id)
    {
        return _woodPellets.Find(wp => wp.Id == id);
    }

    /// <summary>
    /// Adds a new wood pellet to the repository.
    /// </summary>
    /// <param name="woodPellet">The wood pellet to add.</param>
    /// <returns>The added wood pellet.</returns>
    public WoodPellet Add(WoodPellet woodPellet)
    {
        ArgumentNullException.ThrowIfNull(woodPellet);

        woodPellet.Id = NextId;
        woodPellet.Validate();
        _woodPellets.Add(woodPellet);
        return woodPellet;
    }

    /// <summary>
    /// Updates an existing wood pellet in the repository.
    /// </summary>
    /// <param name="woodPellet">The wood pellet to update.</param>
    /// <returns>The updated wood pellet.</returns>
    public WoodPellet Update(WoodPellet woodPellet)
    {
        ArgumentNullException.ThrowIfNull(woodPellet);

        var existing = GetById(woodPellet.Id) ?? throw new ArgumentException("Wood pellet not found.");
        woodPellet.Validate();
        existing.Brand = woodPellet.Brand;
        existing.Price = woodPellet.Price;
        existing.Quantity = woodPellet.Quantity;
        return existing;
    }

    /// <summary>
    /// Deletes a wood pellet by its Id.
    /// </summary>
    /// <param name="id">The Id of the wood pellet to delete.</param>
    /// <returns>The deleted wood pellet, or null if not found.</returns>
    public WoodPellet? Delete(int id)
    {
        var woodPellet = GetById(id) ?? throw new ArgumentException("Wood pellet not found.");
        if (woodPellet != null)
        {
            _woodPellets.Remove(woodPellet);
        }
        return woodPellet;
    }


    /// <summary>
    /// Calculates the next available Id for a new wood pellet.
    /// </summary>
    /// <returns>The next available Id integer</returns>
    private int FindNextId()
    {
        return _woodPellets.Count == 0 ? 1 : _woodPellets.Max(wp => wp.Id) + 1;
    }
}
