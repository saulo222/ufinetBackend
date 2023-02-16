using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_AGGREGATES.Aggregates.Queries
{
    /// <summary>
    /// Created By : Saul Cruz
    /// Date Created : 15/02/2023
    /// Contains the query operations implemented by Property
    /// </summary>
    public interface IGetUsersServices : IDisposable
    {
        public User GetBynameLogin(string nameLogin,string password);

    }

}
