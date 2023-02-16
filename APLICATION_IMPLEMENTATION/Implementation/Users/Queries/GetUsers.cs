using APLICATION_AGGREGATES.Aggregates.Queries;
using DOMAIN_AGGREGATES.Users;
using DOMAIN_CORE.Class;
using INGETEC_INFRA_TOOLS_AGG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_IMPLEMENTATION.Implementation.Users.Queries
{
    /// <summary>
    /// Created by: Saul Cruz
    /// Date Created: 27/01/2022
    /// Service that contains the query operations that a property implements.
    /// </summary>
    public class GetUsersService : IGetUsersServices
    {
        private IGetUsers _users;
        private ITools _tools;

        public GetUsersService(IGetUsers users, ITools tools)
        {
            _users = users;
            _tools = tools;
        } 


        private User ValidateNameLogin(string nameLogin)
        {
            List<User> lsusers = new List<User>();
            User user =new User(); 
            lsusers = _users.GetAll();

            user = lsusers.Where(x => x.NameLogin.Equals(nameLogin.Trim())).FirstOrDefault();

            if(user == null)  throw new Exception("El nombre de usuario no existe");
      
            return user;

        }
        private bool ValidatePassword(string password, User user)
        {
          bool falg=false;
          string passwordDecryptKey =  _tools.DecryptKey(user.Password);
          if(passwordDecryptKey.Equals(password.Trim()))
                falg=true;

          return falg;
        }
        public User GetBynameLogin(string nameLogin, string password)
        {
              //string wncrypassword = _tools.EncryptKey(password);
             User user = ValidateNameLogin(nameLogin);

           if(!ValidatePassword(password, user))
             throw new Exception("La contraseña no coincide");

            return user;
        }



        public void Dispose()
        {
            _users.Dispose();
        }


    }
}
