using System;
using Microsoft.AspNetCore.Http;
namespace FirstReactReduxApp.ViewModels
{
    public class UserRequest
    {
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
        public IFormFile Avatar { get; set; }
    }
}
