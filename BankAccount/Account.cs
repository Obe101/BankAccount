﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represent a single checking account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Deposits the amount in th bank account
        /// and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        /// <returns></returns>
        public double Deposit(double amt)
        {
            if (amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be smaller then 10000");
            }
            if(amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} must be a positive value");
            }
            Balance += amt;
            return Balance;
        }
        /// <summary>
        /// Gets current balance
        /// </summary>
        public double Balance { get; private set; }
        public void Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new ArgumentException("You can't withdraw more then current balance");
            }
            Balance -= amt;
        }
    }
}
