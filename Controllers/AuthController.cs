using EnvarterTakip.Data;
using EnvarterTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvarterTakip.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController: ControllerBase{
    private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
    {
        _context = context;
    }
//Post: api/auth/register
[HttpPost("register")]
public async Task<IActionResult> Register(User user)
{
    // Kullanıcı zaten var mı kontrol et
    if (await _context.Users.AnyAsync(u => u.userName == user.userName))//LinQ
    {
        return BadRequest("User already exists");
    }
    //kullanıcıyı veritabanına ekle
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    //oluşan kullanıcıyı dön
    return Ok(user);
}
//delete
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteUser(int id){
    var dUser = await _context.Users.FindAsync(id);
    if(dUser == null){
        return NotFound();
    }
    _context.Users.Remove(dUser);
    await _context.SaveChangesAsync();
    return Ok(dUser);
}
//update
[HttpPut("{id}")]
public async Task<IActionResult> UpdateUser(int id, User request){
    var uUser =  await _context.Users.FindAsync(id);
    if(uUser == null){
        return NotFound();
    }
    uUser.userName = request.userName;
    uUser.surname = request.surname;
    uUser.email = request.email;
    uUser.password = request.password;

    await _context.SaveChangesAsync();
    return Ok(uUser);
}
//listeleme
[HttpGet]
public async Task<IActionResult> List(){
    var listUser = await _context.Users.ToListAsync();
    return Ok(listUser);
}

}