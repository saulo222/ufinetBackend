using DOMAIN_AGGREGATES.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.Dynamic;
using static System.Collections.Specialized.BitVector32;
using DOMAIN_CORE.Class;
using PERSITENCE_CORE.GetTask.Command;

namespace PERSITENCE_CORE.Users
{
    public class MainContextGetBills : DbContext, IGetBills
    {



        public MainContextGetBills(DbContextOptions<MainContextGetBills> options)
            : base(options)
        {

        }

        public IEnumerable<GetBills> GetBill(Guid customerID)
        {

            Microsoft.Data.SqlClient.SqlParameter parameterCustomerID = new Microsoft.Data.SqlClient.SqlParameter();
            parameterCustomerID.ParameterName = "@CustomerID";
            parameterCustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            parameterCustomerID.Direction = ParameterDirection.Input;
            parameterCustomerID.Value = customerID;

            Microsoft.Data.SqlClient.SqlParameter[] parameters = {
                parameterCustomerID
            };

            string commandText = @"[dbo].[ProcGetAllBills] @CustomerID";


            return base.Set<GetBills>().FromSqlRaw(commandText, parameters);


        }


       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GetBillsConfig());
        }
    }
}
