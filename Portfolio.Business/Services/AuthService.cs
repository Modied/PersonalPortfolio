using Microsoft.AspNetCore.Identity;
using Portfolio.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class AuthService : IAuth
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<LoginVModel> InitialAdminAsync()
        {
            if (!_userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    FirstName = "Admin",
                    UserName = "Admin",
                    Email = "Admin@admin.com",
                    LastName = "Adminl"

                };

                await _userManager.CreateAsync(user, "Admin1234");
                // await _userManager.AddToRoleAsync(user, "Admin");
            }
            return new LoginVModel { };

        }


        public async Task<AuthVModel> LoginAsync(LoginVModel loginVModel)
        {
            var authModel = new AuthVModel();

            var user = await _userManager.FindByEmailAsync(loginVModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginVModel.Password))
            {
                authModel.isAouthentecated = false;
                authModel.Message = "Invalid Email or Password from userManager";
                return authModel;
            }


            var userName = new EmailAddressAttribute().IsValid(loginVModel.Email) ? new MailAddress(loginVModel.Email).User : loginVModel.Email;
            userName = user.UserName;
            //  userName = new MailAddress(loginVModel.Email).User;
            //.IsValid(userName) ? user.Email : user.UserName;

            var result = await _signInManager.PasswordSignInAsync(userName, loginVModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                authModel.isAouthentecated = false;
                authModel.Message = "Invalid Email or Password from Sing Manager ";
                return authModel;
            }
            authModel.isAouthentecated = true;
            authModel.UserName = user.UserName;
            authModel.Email = user.Email;
            authModel.Roles = (await _userManager.GetRolesAsync(user)).ToList(); // as List<string>;
            return authModel;

        }

        public async Task<AuthVModel> RegisterAsync(RegisterVModel registerVModel)
        {
            var authModel = new AuthVModel();

            if (registerVModel == null)
            {
                authModel.isAouthentecated = false;
                authModel.Message = "Invalid Email or Password";
                return authModel;
            }
            if (await _userManager.FindByEmailAsync(registerVModel.Email) != null)
            {
                authModel.isAouthentecated = false;
                authModel.Message = "Email  or userName already exists";
                return authModel;
            }
            if (await _userManager.FindByNameAsync(registerVModel.UserName) != null)
            {
                authModel.isAouthentecated = false;
                authModel.Message = "UserName or email already exists";
                return authModel;
            }

            var user = new ApplicationUser
            {
                UserName = registerVModel.UserName,
                Email = registerVModel.Email,
                FirstName = registerVModel.FirstName,
                LastName = registerVModel.LastName
            };

            var result = await _userManager.CreateAsync(user, registerVModel.Password);

            if (!result.Succeeded)
            {
                var error = string.Empty;

                foreach (var item in result.Errors)
                {
                    error += $"{item.Description},";
                }

                authModel.Message = error;
                return authModel;

            }
            await _userManager.AddToRoleAsync(user, "User");

            authModel.isAouthentecated = true;
            authModel.UserName = user.UserName;
            authModel.Email = user.Email;
            authModel.Roles = await _userManager.GetRolesAsync(user) as List<string>;
            return authModel;


        }
    }
}
