using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using static WebApi.Contracts.IRepositoryBase;

namespace WebApi.Contracts
{
    public interface IBuildingRepository : IRepositoryBase<Building>
    {
    }
}
