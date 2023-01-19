using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PDM_Draxton.Models;

namespace PDM_Draxton
{
    public partial class AccountController : Controller
    {
        private readonly SignInManager<Usuario> signInManager;
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment env;

        public AccountController(IWebHostEnvironment env, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;
        }

        private IActionResult RedirectWithError(string error, string redirectUrl)
        {
             if (!string.IsNullOrEmpty(redirectUrl))
             {
                 return Redirect($"~/login?error={error}&redirectUrl={Uri.EscapeDataString(redirectUrl)}");
             }
             else
             {
                 return Redirect($"~/login?error={error}");
             }
        }


       [HttpPost]
        public async Task<IActionResult> login(string userName, string password, string redirectUrl)
        {
            if (env.EnvironmentName == "Development" && userName == "admin" && password == "admin")
            {
                var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Email, "admin")
                };
                await signInManager.SignInWithClaimsAsync(new Usuario { UserName = userName, Correo = userName }, isPersistent: false, claims);

                return Redirect($"~/{redirectUrl}");
            }

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {

                var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

                if (result.Succeeded)
                {
                    return Redirect($"~/{redirectUrl}");
                }
            }

            return RedirectWithError("Invalid user or password", redirectUrl);
        }


        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();

            return Redirect("~/");
        }
    }
}
