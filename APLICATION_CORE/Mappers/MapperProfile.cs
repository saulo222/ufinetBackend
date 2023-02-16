using APLICATION_CORE.Class;
using AutoMapper;
using DOMAIN_CORE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION_CORE.Mappers
{
    /// <summary>
    /// Created by: Saul Cruz
    /// Date Created:20/07/2022
    /// Operations to mapper class of the  domain
    /// into class of the aplication
    /// </summary>
    public sealed class MapperProfile : Profile
    {

        public MapperProfile()
        {


            var config = new MapperConfiguration(cfg =>
            {
                CreateMap<BillsDTO, Bills>();

            });
        }

    }
}
