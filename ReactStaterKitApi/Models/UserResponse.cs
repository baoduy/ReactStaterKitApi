using System;
using Microsoft.AspNetCore.Mvc;

namespace ReactStaterKitApi.Models
{
    public class UserResponse
    {
        public UserResponse()
        {
            
        }
        public int Id
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public byte[] Avatar
        {
            get;
            set;
        }
    }
}
