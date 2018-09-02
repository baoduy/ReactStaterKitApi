using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstReactReduxApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Threading;

namespace FirstReactReduxApp.Controllers
{
    public static class DummyData
    {
        public static List<UserResponse> Users = new List<UserResponse>{
            new UserResponse
            {
                    Id = 1,
                    Username="Tuan",
                FirstName = "Tuan",
                LastName="Nguyen",
                Email = "xuantuan93@gmail.com"
                },
            new UserResponse
            {
                    Id = 2,
                    Username="Steven",
                FirstName="Steven",
                LastName="Hoang",
                Email = "baoduy2412@outlook.com"
                }
            };
    }
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        [HttpGet]
        public List<UserResponse> Get()
        {
            return DummyData.Users;
        }
        [HttpGet]
        [Route("{id}")]
        public UserResponse Get(int id)
        {
            return DummyData.Users.FirstOrDefault(u=>u.Id==id);
        }
        [HttpGet]
        [Route("IsEmailOrUserNameExist/{usernameOrEmail}/{id}")]
        public bool IsEmailOrUserNameExist(string usernameOrEmail,int id){
            
            if(IsValidEmail(usernameOrEmail)){
                return DummyData.Users.Exists(e => e.Email.ToLower().Equals(usernameOrEmail.ToLower()) && e.Id!=id);
            }
            return DummyData.Users.Exists(e => e.Username.ToLower().Equals(usernameOrEmail.ToLower()) && e.Id != id);

        }


        [HttpPost]
        public UserResponse Post([FromForm]UserRequest user)
        {

            var userUpdated = DummyData.Users.FirstOrDefault(u => u.Id == user.Id);
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
                return userUpdated;

            }
            else
            {
                var userResponse = new UserResponse
                {
                    Id = DummyData.Users.Count() + 1,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
                if (avatar != null)
                {
                    userResponse.Avatar = GetImageByte(user.Avatar);
                }
                DummyData.Users.Add(userResponse);
                return userResponse;
            }

        }

        [HttpDelete] 
        [Route("{id}")] 
        public bool Delete(int id)
        {
            var user = DummyData.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            return DummyData.Users.Remove(user);
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
