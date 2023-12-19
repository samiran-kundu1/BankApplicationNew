﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IDAL
{
    public interface IBankDAL
    {
         List<User> GetUserList();

         List<Account> GetUserAccountList(int userId);

         List<Account> CreateUserAccount(int userId, decimal amount);

         List<Account> DeleteUserAccount(int userId, int accntId);
    }
}
