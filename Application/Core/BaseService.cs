
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
            Result result = new();
            try
            {
                //validacion
                if (entity == null) {
                    result.IsSuccess = false;
                    result.Message = "The entity to be saved cant be null";
                    return result;
                }

                TEntity entityToBeSave = _mapper.Map<TEntity>(entity);

                await _baseRepository.SaveAsync(entityToBeSave);

                result.Message = "entity saved was succesfull";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error saving the entity";
                return result;
            }
        }
        public virtual async Task<Result> DeleteAsync(int Id)
        {
            Result result = new();
            try
            {
                bool deleteOperation = await _baseRepository.DeleteAsync(Id);
                if (!deleteOperation)
                {
                    result.IsSuccess = false;
                    result.Message = "Error while deleting the entity";
                    return result;
                }
                result.Message = "Entity Was successfully deleted";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error while attempting to delete the entity";
                return result;
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
            Result<List<TModel>> result = new();
            try
            {
                List<TEntity> entitesGetted = await _baseRepository.GetAllAsync();
                result.Data = _mapper.Map<List<TModel>>(entitesGetted);
                result.Message = "The entities were successfull";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error while getting the entities";
                return result;
            }
        }

        public virtual async Task<Result<TModel>> GetByIdAsync(int id)
        {
            Result<TModel> result = new();
            try
            {
                if (id == default || id < 0)
                {
                    result.IsSuccess = false;
                    result.Message = "The id is null";
                    return result;
                }
                TEntity entityGetted = await _baseRepository.GetByIdAsync(id);
                if (entityGetted == null)
                {
                    result.IsSuccess = false;
                    result.Message = "The entity wasn't found";
                    return result;
                }
                result.Data = _mapper.Map<TModel>(entityGetted);
                result.Message = "The search was successfull";
                return result;
            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Crticial error while getting by id";
                return result;
            }
        }

        public virtual async Task<Result> UpdateAsync(TSaveModel entity)
        {
            Result result = new();
            try
            {
                if (entity == null)
                {
                    result.IsSuccess = false;
                    result.Message = "The entity is null";
                    return result;
                }
                TEntity entityForUpdate = _mapper.Map<TEntity>(entity);
                await _baseRepository.UpdateAsync(entityForUpdate);
                result.Message = "The update was successfull";
                return result;

            }
            catch
            {
                result.IsSuccess = false;
                result.Message = "Critical error";
                return result;
            }
        }
    }
}
