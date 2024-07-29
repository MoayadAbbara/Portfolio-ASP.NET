using DataLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Auth
    {
        public static List<Claim>? Login(string Email, string Password)
        {
            PortfolioContext Model = new PortfolioContext();

            var User = Model.Users.FirstOrDefault(f => f.Email == Email && f.Password == Password);

            if (User != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("ID", User.Id.ToString()));
                claims.Add(new Claim("UserName", User.UserName));
                claims.Add(new Claim("Email", User.Email));
                claims.Add(new Claim("IsAdmin", User.isAdmin.ToString()));
                return claims;
            }
            return null;
        }
    }
}
