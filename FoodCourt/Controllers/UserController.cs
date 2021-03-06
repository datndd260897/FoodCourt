﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCourt.Framework.Helpers;
using FoodCourt.Framework.Models;
using FoodCourt.Framework.ViewModels;
using FoodCourt.Service.IdentityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodCourt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : FoodCourtController
    {
        private IIdentityService service;
        public UserController(IIdentityService service, ExtensionSettings extensionSettings, MyUserManager userManager) : base(extensionSettings, userManager)
        {
            this.service = service;
        }


        [HttpPost("login")]
        public async Task<dynamic> Authorize(LoginViewModel viewModel)
        {
            return await ExecuteInMonitoring( async () =>
            {
                return await service.AuthorizeAsync(this.userManager, viewModel);
            });
        }

        [HttpPost("register")]
        public async Task<dynamic> Register(RegisterViewModel viewModel)
        {
            return await ExecuteInMonitoring(async () =>
            {
                return await service.RegisterAsync(this.userManager, viewModel);
            });
        }

        [HttpPost("registerExternal")]
        public async Task<dynamic> RegisterExternal(RegisterExternalViewModel viewModel)
        {
            return await ExecuteInMonitoring(async () =>
            {
                return await service.RegisterExternalAsync(userManager, viewModel);
            });
        }

    }
}