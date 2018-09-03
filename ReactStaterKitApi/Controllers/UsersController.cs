using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ReactStaterKitApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Threading;
using ReactStaterKitApi.Data;
using ReactStaterKitApi.ViewModels;

namespace ReactStaterKitApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public ReactStaterKitDbContext context { get; set; }

        public UsersController(ReactStaterKitDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<User> Get()
        {
            return context.Users.ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public User Get(int id)
        {
            return context.Users.FirstOrDefault(u=>u.Id==id);
        }
        [HttpGet]
        [Route("IsEmailOrUserNameExist/{usernameOrEmail}/{id}")]
        public bool IsEmailOrUserNameExist(string usernameOrEmail,int id){
            
            if(IsValidEmail(usernameOrEmail)){
                return context.Users.Any(e => e.Email.ToLower().Equals(usernameOrEmail.ToLower()) && e.Id!=id);
            }
            return context.Users.Any(e => e.Username.ToLower().Equals(usernameOrEmail.ToLower()) && e.Id != id);

        }


        [HttpPost]
        public User Post([FromForm]UserRequest user)
        {

            var userUpdated = context.Users.FirstOrDefault(u => u.Id == user.Id);
            var avatar = GetImageByte(user.Avatar);
            if (userUpdated != null)
            {
                userUpdated.Username = user.Username;
                userUpdated.FirstName = user.FirstName;
                userUpdated.LastName = user.LastName;
                userUpdated.Email = user.Email;
                if(avatar != null){
                    userUpdated.Avatar = GetImageByte(user.Avatar);
                }

            }
            else
            {
                userUpdated =  new User
                {
                    //Id = DummyData.Users.Count() + 1,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
                if (avatar != null)
                {
                    userUpdated.Avatar = GetImageByte(user.Avatar);
                }
                context.Users.Add(userUpdated);
            }

            context.SaveChanges();
            return userUpdated;

        }

        [HttpDelete] 
        [Route("{id}")] 
        public bool Delete(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            context.SaveChanges();
            
            return true;
        }


        private byte[] GetImageByte(IFormFile avatar)
        {
            byte[] result = null;

            if (avatar != null && avatar.Length > 0)
            {
                var memory = new MemoryStream();
                avatar.CopyTo(memory);
                result = memory.ToArray();
            }
            return result;

        }
        private bool IsValidEmail(string email){
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
