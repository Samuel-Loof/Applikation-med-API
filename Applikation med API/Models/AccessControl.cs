﻿using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Applikation_med_API.Data
{
    public class AccessControl
    {
        private readonly AppDbContext _db;
        public int LoggedInAccountID { get; private set; }
        public string LoggedInAccountName { get; private set; }

        // Constructor
        public AccessControl(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            var user = httpContextAccessor.HttpContext.User;
            string subject = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string issuer = user.FindFirst(ClaimTypes.NameIdentifier)?.Issuer;

            var account = db.Accounts.SingleOrDefault(a => a.OpenIDIssuer == issuer && a.OpenIDSubject == subject);
            if (account != null)
            {
                LoggedInAccountID = account.ID;
                LoggedInAccountName = user.FindFirst(ClaimTypes.Name)?.Value;
            }
        }

        // Method to retrieve the current user's ShoppingCartId
        public int GetCurrentShoppingCartId()
        {
            // Check if a ShoppingCart exists for the current user
            var shoppingCart = _db.ShoppingCarts.SingleOrDefault(sc => sc.AccountID == LoggedInAccountID);

            if (shoppingCart != null)
            {
                // If exists, return its ID
                return shoppingCart.ID;
            }
            else
            {
                // If not exists, create a new ShoppingCart
                shoppingCart = new ShoppingCart
                {
                    AccountID = LoggedInAccountID,
                    // Initialize other properties as needed
                };

                _db.ShoppingCarts.Add(shoppingCart);
                _db.SaveChanges(); 

                return shoppingCart.ID; // Return the ID of the newly created ShoppingCart
            }
        }

    }
}
