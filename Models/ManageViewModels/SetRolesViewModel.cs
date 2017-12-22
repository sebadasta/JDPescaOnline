using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using JDPesca.Data;
using JDPesca.Models;
using JDPesca.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using JDPesca.Authorization;

namespace JDPesca.Models.ManageViewModels
{

    public class SetRolesViewModel
    {

        [Display(Name = "Usuario")]
        public string UserID { get; set; }


        [Display(Name = "Rol")]
        public string Role { get; set; }

        public string StatusMessage { get; set; }
    }
}
