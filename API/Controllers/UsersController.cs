using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    public DataContext _Context { get; set; }
    public UsersController(DataContext context)
    {
      _Context = context;

    }
    [HttpGet]
    public async Task<List<AppUser>> GetUsers()
    {
      return  await _Context.Users.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
      return await _Context.Users.FindAsync(id);
    }
  }
}