using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LynkerSocial_API.Models;

namespace LynkerSocial_API
{
    public static class SeedDb
    {
        static Guid zeroUserId = Guid.NewGuid();
        public static void InsertUser(LynkerdbContext db)
        {
            User zero = new()
            {
                Name = "Zero"
            };
        }
    }
}