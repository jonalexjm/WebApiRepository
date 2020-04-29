using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contracts;
using WebApi.DataContexts;
using WebApi.Entities;

namespace WebApi.Repository
{
    public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
    {
        private readonly DataContext context;

        public BuildingRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
