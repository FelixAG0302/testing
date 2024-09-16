
using MapsterMapper;
using testing.Application.Extensions;
using testing.Application.Utils.Enums;
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
                if (entity == null) return ErrorTypes.Validation.Because("The entity to be saved cant be null"); 

                TEntity entityToBeSave = _mapper.Map<TEntity>(entity);

                bool isSaveOperationASuccess = await _baseRepository.SaveAsync(entityToBeSave);

                return !isSaveOperationASuccess ? 
                    ErrorTypes.OperationError.Because("Error while saving the entity") : new("entity saved was succesfull") ;
            }
            catch
            {
              return ErrorTypes.Exceptions.Because("Critical error saving the entity");
            }
        }
        public virtual async Task<Result> DeleteAsync(int Id)
        {
            try
            {
                if (Id <= 0) return ErrorTypes.Validation.Because("Id cant be null");

                bool isDeleteOperationASuccess = await _baseRepository.DeleteAsync(Id);

                return !isDeleteOperationASuccess ? ErrorTypes.OperationError.Because("Error while deleting the entity") : new("Entity Was successfully deleted");
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while attempting to delete the entity");
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

                return  _mapper.Map<List<TModel>>(entitesGetted);
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while getting the entities");
            }
        }

        public virtual async Task<Result<TModel>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0) 
                    return ErrorTypes.Validation.Because("The id is null");

                TEntity entityGetted = await _baseRepository.GetByIdAsync(id);

                if (entityGetted == null) 
                    return ErrorTypes.OperationError.Because("The entity wasn't found");
               
                return  _mapper.Map<TModel>(entityGetted);
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Crticial error while getting the entity by id");
            }
        }

        public virtual async Task<Result> UpdateAsync(TSaveModel entity)
        {
            try
            {
                if (entity == null) 
                    return ErrorTypes.Validation.Because("The entity is null");
              
                TEntity entityForUpdate = _mapper.Map<TEntity>(entity);

                bool isUpdateOperationASuccess = await _baseRepository.UpdateAsync(entityForUpdate);

                return !isUpdateOperationASuccess ? ErrorTypes.OperationError.Because("Error while updating the entity")
                    : new("The update was successfull");
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while updating the entity");
            }
        }
    }
}
