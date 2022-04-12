using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.IRepositories;
using DesktopApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DesktopApp.Service
{
    public class UserService : IUserService
    {
        public async Task<bool> Add(User item)
        {
            try
            {
                var jsonFile = File.ReadAllText("Service\\User.json");
                if (jsonFile != null)
                {
                    var jsonobj = JObject.Parse(jsonFile);
                    var allUsers = jsonobj.GetValue("Users") as JArray;
                    var a = JObject.Parse(JsonConvert.SerializeObject(item));
                    allUsers!.Add(a);
                    jsonobj["Users"] = allUsers;
                    var finalResult = JsonConvert.SerializeObject(jsonobj, Formatting.Indented);
                    File.WriteAllText("Service\\User.json", finalResult);
                }

            }
            catch(Exception ex)
            {
                return false;
                throw;
            }
            return true ;

        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                var listofUsers = new List<User>();
                var jsonFile = File.ReadAllText("Service\\User.json");
                if (jsonFile != null)
                {
                    var jsonobj = JObject.Parse(jsonFile);
                    var allUsers = jsonobj.GetValue("Users") as JArray;

                    List<User> users = allUsers.ToObject<List<User>>();
                    listofUsers = users;

                }
                return listofUsers;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Remove(int UserId)
        {
            try
            {
                var jsonFile = File.ReadAllText("Service\\User.json");
                if (jsonFile != null)
                {
                    var jsonobj = JObject.Parse(jsonFile);
                    var allUsers = (JArray)jsonobj["Users"];
                    var UserToDeleted = allUsers.FirstOrDefault(obj => obj["Id"].Value<int>()== UserId);
                    allUsers.Remove(UserToDeleted);
                    string finalResult = JsonConvert.SerializeObject(jsonobj, Formatting.Indented);
     
                    File.WriteAllText("Service\\User.json", finalResult);
                    

                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw;
            }

        }

        public  async Task<bool> Update(User user , int userId)
        {
            try
            {

                var jsonFile = File.ReadAllText("Service\\User.json");
                if (jsonFile != null)
                {
                    var jsonobj = JObject.Parse(jsonFile);
                    var allUsers = (JArray)jsonobj["Users"];
                    var a = JObject.Parse(JsonConvert.SerializeObject(user));
                    var UserToDeleted = allUsers.FirstOrDefault(obj => obj["Id"].Value<int>() == userId);
                    allUsers.Remove(UserToDeleted);
                    allUsers.Add(a);
                    string finalResult = JsonConvert.SerializeObject(jsonobj, Formatting.Indented);

                    File.WriteAllText("Service\\User.json", finalResult);

                }

               
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
