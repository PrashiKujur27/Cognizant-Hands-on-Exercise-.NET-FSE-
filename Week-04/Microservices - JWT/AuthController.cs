using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthWebApiLab.Models;
namespace JwtAuthWebApiLab.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase{
[HttpPost("login")]
public IActionResult Login(LoginModel model){
if(model.Username=="admin" && model.Password=="admin123")
return Ok(new{Token=Generate(model.Username)});
return Unauthorized();
}
[Authorize]
[HttpGet("secure")]
public IActionResult Secure()=>Ok("JWT Authentication Successful");
string Generate(string user){
var claims=new[]{new Claim(ClaimTypes.Name,user)};
var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtToken"));
var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
var token=new JwtSecurityToken("MyAuthServer","MyApiUsers",claims,
expires:DateTime.UtcNow.AddMinutes(60),signingCredentials:creds);
return new JwtSecurityTokenHandler().WriteToken(token);
}
}