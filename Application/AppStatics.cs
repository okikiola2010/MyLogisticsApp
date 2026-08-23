using Application.Interfaces.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Application
{
    public class AppStatics
    {
        public static string AdminRole = "app_Admin";
        public static string ClientRole = "app_Client";
        public static string DeliveryManRole = "app_Worker";
        public static string AdminEmail = "admin@gmail.com";
    }
}
