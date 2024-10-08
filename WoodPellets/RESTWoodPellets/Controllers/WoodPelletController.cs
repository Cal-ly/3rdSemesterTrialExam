using Microsoft.AspNetCore.Mvc;

namespace RESTWoodPellets.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WoodPelletController : ControllerBase
{
    private readonly WoodPelletRepository _repository;

    public WoodPelletController(WoodPelletRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        //_repository.Add(new WoodPellet { Brand = "BrandA", Price = 99.95m, Quantity = 3 });
        //_repository.Add(new WoodPellet { Brand = "BrandB", Price = 129.95m, Quantity = 2 });
        //_repository.Add(new WoodPellet { Brand = "BrandC", Price = 99.95m, Quantity = 4 });
        //_repository.Add(new WoodPellet { Brand = "BrandD", Price = 119.95m, Quantity = 1 });
        //_repository.Add(new WoodPellet { Brand = "BrandE", Price = 139.95m, Quantity = 5 });
    }

    // GET: api/<WoodPelletController>
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var woodpellets = _repository.GetAll();
            return Ok(woodpellets);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving wood pellets.");
        }
    }

    // GET api/<WoodPelletController>/5
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public ActionResult<WoodPellet> Get(int id)
    {
        try
        {
            var woodpellet = _repository.GetById(id);
            if (woodpellet == null)
            {
                return NotFound($"No wood pellet found with id: {id}");
            }
            return Ok(woodpellet);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the wood pellet.");
        }
    }

    // POST api/<WoodPelletController>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    public ActionResult<WoodPellet> Add([FromBody] WoodPellet woodPellet)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var existingWoodPellet = _repository.GetById(woodPellet.Id);
            if (existingWoodPellet != null)
            {
                return Conflict($"A wood pellet with id: {woodPellet.Id} already exists.");
            }

            var addedWoodPellet = _repository.Add(woodPellet);
            return CreatedAtAction(nameof(Get), new { id = addedWoodPellet.Id }, addedWoodPellet);
        }
        catch (ArgumentNullException)
        {
            return BadRequest("Wood pellet cannot be null.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the wood pellet.");
        }
    }

    // PUT api/<WoodPelletController>/5
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPut("{id}")]
    public ActionResult<WoodPellet> Update(int id, [FromBody] WoodPellet woodPellet)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var existingWoodPellet = _repository.GetById(id);
            if (existingWoodPellet == null)
            {
                return NotFound($"No wood pellet found with id: {id}");
            }

            if (id != woodPellet.Id)
            {
                return BadRequest("Id does not match the wood pellet.");
            }

            var updatedWoodPellet = _repository.Update(woodPellet);
            return Ok(updatedWoodPellet);
        }
        catch (ArgumentNullException)
        {
            return BadRequest("Wood pellet cannot be null.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the wood pellet.");
        }
    }

    // DELETE api/<WoodPelletController>/5
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id}")]
    public ActionResult<WoodPellet> Delete(int id)
    {
        try
        {
            var woodpellet = _repository.Delete(id);
            if (woodpellet == null)
            {
                return NotFound($"No wood pellet found with id: {id}");
            }
            return Ok(woodpellet);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the wood pellet.");
        }
    }
}
