using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_Trial.DataLayer;
using SP_Trial.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserController : Controller
{
    private readonly ApplicationDbContext _db;

    public UserController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> UsersList()
    {
        var users = await GetAllUsersAsync(string.Empty);
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> SearchUsers([FromBody] string keyword)
    {
        var users = await GetAllUsersAsync(keyword);
        return PartialView("_UserListPartial", users);
    }

    private async Task<List<User>> GetAllUsersAsync(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return await _db.Users.FromSqlRaw("EXEC GetAllUsers").ToListAsync();
        }
        else
        {
            SqlParameter param = new SqlParameter("@p0", keyword);
            return await _db.Users.FromSqlRaw("EXEC SearchUser @p0", param).ToListAsync();
        }
    }
}
