using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN_AGGREGATES.Base;
using DOMAIN_CORE.Class;

namespace DOMAIN_AGGREGATES.Users
{
    /// <summary>
    /// Created By : Saul Cruz
    /// Date Created : 30\06\2022
    /// Contains the query operations implemented by User
    /// </summary>
    public interface IGetUsers : IRepositoryBase<User>, IDisposable
    {

    }
}
