using APLICATION_AGGREGATES.Aggregates.Commands;
using APLICATION_CORE.Class;
using APLICATION_CORE.Mappers;
using AutoMapper;
using DOMAIN_AGGREGATES.GetTask.Commands;
using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_IMPLEMENTATION.Implementation.GetTask.Commands
{
    /// <summary>
    /// Created by: Saul Cruz
    /// Date Created:20/07/2022
    /// Service that contains the operations that a property implements.
    /// </summary>
    public class BillsServices : IBillsServices
    {

        private IBills _bills;
        public BillsServices(IBills bills

                               )
        {
            _bills = bills;

        }

        public async Task<bool> Add(BillsDTO Billsdto)
        {

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
            });
            int result = 0;
            Bills bills = new Bills();
            var mapper = config.CreateMapper();
            mapper.Map(Billsdto, bills);
             await _bills.Add(bills);
            result = _bills.WorkUnit.Save();
            _bills.Dispose();
            return result > 0 ? true : false;
        }


        public  bool Delete(BillsDTO Billsdto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
            });
            int result = 0;
            Bills bills = new Bills();
            var mapper = config.CreateMapper();
            mapper.Map(Billsdto, bills);
             _bills.Delete(bills);
            result = _bills.WorkUnit.Save();
            _bills.Dispose();
            return result > 0 ? true : false;
        }

        public void Dispose()
        {
            _bills.Dispose();
        }
    }
}
