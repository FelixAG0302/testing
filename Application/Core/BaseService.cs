
using MapsterMapper;
using testing.Domain.Core;

namespace testing.Application.Core
{
    public class BaseService<TSaveModel, TEntity> : IBaseService<TSaveModel>
        where TSaveModel : class
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }   
        public virtual async Task<Result> SaveAsync(TSaveModel entity)
        {
            try
            {
                if (entity == null) return new("The entity to be saved cant be null", false);

                TEntity entityToBeSave = _mapper.Map<TEntity>(entity);

                bool isSaveOperationASuccess = await _baseRepository.SaveAsync(entityToBeSave);

                return isSaveOperationASuccess ? new("entity saved was succesfull") : new("Error while saving the entity", false);
            }
            catch
            {
                return new("Critical error saving the entity", false);
            }
        }
        public virtual async Task<Result> DeleteAsync(int Id)
        {
            try
            {
                if ( Id <= 0) return new( "Id cant be null", isSuccess: false);

                bool isDeleteOperationASuccess = await _baseRepository.DeleteAsync(Id);

                return isDeleteOperationASuccess ? new("Entity Was successfully deleted") 
                    : new("Error while deleting the entity",  false);
            }
            catch
            {
                return new("Critical error while attempting to delete the entity", isSuccess: false);
            }
        }

     
    }
    public class BaseCompleteService<TModel, TSaveModel, TEntity> : BaseService< TSaveModel, TEntity>, IBaseCompleteService<TModel, TSaveModel>
        where TModel : class
     where TSaveModel : class
     where TEntity : class
    {
        private readonly IBaseCompleteRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseCompleteService(IBaseCompleteRepository<TEntity> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public virtual async Task<Result<List<TModel>>> GetAllAsync()
        {
            try
            {
                List<TEntity> entitesGetted = await _baseRepository.GetAllAsync();

                return new("The entities were successfull", _mapper.Map<List<TModel>>(entitesGetted));
            }
            catch
            {
                return new("Critical error while getting the entities",false);
            }
        }

        public virtual async Task<Result<TModel>> GetByIdAsync(int id)
        {
            try
            {
                if (id == default || id < 0) return new( "The id is null",false);

                TEntity entityGetted = await _baseRepository.GetByIdAsync(id);

                if (entityGetted == null) return new("The entity wasn't found", false);
               
                return new("The search was successfull", _mapper.Map<TModel>(entityGetted));
            }
            catch
            {
                return new( "Crticial error while getting the entity by id", false);
            }
        }

        public virtual async Task<Result> UpdateAsync(TSaveModel entity)
        {
            try
            {
                if (entity == null) return new("The entity is null", false);
              
                TEntity entityForUpdate = _mapper.Map<TEntity>(entity);

                bool isUpdateOperationASuccess = await _baseRepository.UpdateAsync(entityForUpdate);

                return isUpdateOperationASuccess ? new("The update was successfull") 
                    : new( "Error while updating the entity",false);
            }
            catch
            {
                return new("Critical error while updating the entity", false);
            }
        }
    }
}
