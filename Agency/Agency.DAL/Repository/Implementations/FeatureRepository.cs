using Agency.Core.Entities;
using Agency.Core.Entities.Common;
using Agency.DAL.DbContext;
using Agency.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL.Repository.Implementations
{
    public class FeatureRepository : Repository<Feature>, IFeature
    {
        public FeatureRepository(AppDbContext context) : base(context)
        {
        }
    }
}
