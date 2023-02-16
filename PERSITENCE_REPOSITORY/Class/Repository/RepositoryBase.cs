using DOMAIN_AGGREGATES.Base;
using PERSITENCE_CORE.Aggregates;
using System.Linq;

namespace PERSITENCE_REPOSITORY.Class.Repository
{
    public class RepositoryBaseUnit<Entity> : IRepositoryBase<Entity> where Entity : class
    {
        private IContextWorkUnit _contextWorkUnit;

        public IWorkUnit WorkUnit
        {
            get { return _contextWorkUnit; }
        }
        public RepositoryBaseUnit(IContextWorkUnit contextWorkUnit)
        {
            _contextWorkUnit = contextWorkUnit;
        }

        public Entity GetByID(Guid id)
        {
            return _contextWorkUnit.Set<Entity>().Find(id);
        }


        public async Task<bool> AddRange(List<Entity> entities)
        {

            await _contextWorkUnit.Set<Entity>().AddRangeAsync(entities);
            return true;

        }


        public async Task<bool> Add(Entity entity)
        {

            await _contextWorkUnit.Set<Entity>().AddAsync(entity);
            return true;

        }

        public bool Attach(Entity entity)
        {

            _contextWorkUnit.Set<Entity>().Attach(entity);
            return true;

        }


        public void SetDetached(Entity entity)
        {

            _contextWorkUnit.SetDetached<Entity>(entity);

        }


        public bool Update(Entity entity)
        {

            _contextWorkUnit.Set<Entity>().Update(entity);
            return true;
        }



        public bool UpdateRange(Entity entity)
        {

            _contextWorkUnit.Set<Entity>().UpdateRange(entity);
            return true;
        }


        public bool Delete(Entity entity)
        {

            _contextWorkUnit.Set<Entity>().Remove(entity);
            return true;
        }

        public List<Entity> GetAll()
        {
            return _contextWorkUnit.Set<Entity>().ToList();
        }

        public void Dispose()
        {
            _contextWorkUnit.Dispose();
        }



    }
}
