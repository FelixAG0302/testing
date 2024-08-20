using AutoMapper;
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
        public async Task<Result> SaveAsync(TSaveModel entity)
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
        public async Task<Result> DeleteAsync(int Id)
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

        public async Task<Result<List<TModel>>> GetAllAsync()
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

        public Task<Result<TModel>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(TSaveModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
