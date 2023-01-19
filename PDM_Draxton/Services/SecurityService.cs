using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using PDM_Draxton.Models;

namespace PDM_Draxton.Services{
    //public partial class SecurityService
    //{
    //    public event Action Authenticated;

    //    private readonly UserManager<Usuario> userManager;
    //    private readonly NavigationManager navigationManager;
    //    private Usuario user;

    //    public SecurityService(UserManager<Usuario> userManager, NavigationManager navigationManager)
    //    {
    //        this.userManager = userManager;
    //        this.navigationManager = navigationManager;
    //    }

    //    public ClaimsPrincipal Principal { get; set; }

    //    public async Task<bool> InitializeAsync(AuthenticationStateProvider authenticationStateProvider)
    //    {
    //        var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();

    //        Principal = authenticationState.User;

    //        var name = Principal.Identity.Name;

    //        if (user == null && name != null)
    //        {
    //            user = await userManager.FindByNameAsync(name);
    //        }

    //        var result = IsAuthenticated();

    //        if (result)
    //        {
    //            Authenticated?.Invoke();
    //        }

    //        return result;
    //    }

    //    public Usuario User
    //    {
    //        get
    //        {
    //            if (Principal == null)
    //            {
    //                return new Usuario { Nombre = "Anonymous" };
    //            }

    //            return user;
    //        }
    //    }

    //    public bool IsAuthenticated()
    //    {
    //        return Principal != null ? Principal.Identity.IsAuthenticated : false;
    //    }

    //    public bool IsInRole(params string[] roles)
    //    {
    //        if (roles.Contains("Everybody"))
    //        {
    //            return true;
    //        }

    //        if (!IsAuthenticated())
    //        {
    //            return false;
    //        }

    //        if (roles.Contains("Authenticated"))
    //        {
    //            return true;
    //        }

    //        return roles.Any(role => Principal.IsInRole(role));
    //    }

    //    public async Task Logout()
    //    {
    //        navigationManager.NavigateTo("Account/Logout", true);
    //    }
    //}
}
