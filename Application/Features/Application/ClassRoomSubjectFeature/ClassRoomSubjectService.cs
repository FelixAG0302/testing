﻿
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using testing.Application.Core;
using testing.Application.Extensions;
using testing.Application.Features.Application.ClassRoomSubjectFeature.Models;
using testing.Application.Utils.Enums;
using testing.Application.Utils.SessionHandler;
using testing.Application.Utils.StringGenerator;
using testing.Domain.Model;
using testing.Domain.Repositories.Persistance;
using testing.Domain.Settings;
using testing.Identity.Enums;

namespace testing.Application.Features.Application.ClassRoomSubjectFeature
{
    public class ClassRoomSubjectService : BaseService<SaveClassRoomSubjectModel, Domain.Entities.ClassRoomSubject>, IClassRoomSubjectService
    {
        private readonly IClassRoomSubjectRepository _classRoomSubjectRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationResponce _currentUserInfo;
        private readonly SessionKeys _sessionKeys;

        public ClassRoomSubjectService(IClassRoomSubjectRepository classRoomSubjectRepository, IMapper mapper, ISession session, IOptions<SessionKeys> sessionkeys) : base(classRoomSubjectRepository, mapper)
        {
            _classRoomSubjectRepository = classRoomSubjectRepository;
            _mapper = mapper;
            _sessionKeys = sessionkeys.Value;
            _currentUserInfo = session.Get<AuthenticationResponce>(_sessionKeys.UserKey);
        }

        public override Task<Result> SaveAsync(SaveClassRoomSubjectModel entity)
        {
            entity.SectionGroup = StringGenerator.RandomSectionGroupGenerator();
            return base.SaveAsync(entity);
        }

        public async Task<Result<List<ClassRoomSubjectModel>>> FilterAsync(FilterClassRoomSubjectModel filterModel)
        {
            try
            {
                List<Domain.Entities.ClassRoomSubject> entitiesGetted = await _classRoomSubjectRepository.Filter(filterModel.degreeId, filterModel.TeacherId, filterModel.ClassRoomCode, filterModel.Day);

                return new("Filter Succesfull", _mapper.Map<List<ClassRoomSubjectModel>>(entitiesGetted));
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error filtering the sections");
            }
        }

        public async Task<Result<List<ClassRoomSubjectModel>>> GetTeachesSectionAsync()
        {

            if (_currentUserInfo == null)
                return ErrorTypes.NoAuthenticated.Because("There is no user logged in");

            if (_currentUserInfo.Roles.Any(u => u == nameof(Roles.Teacher)))
                return ErrorTypes.NoAuthorize.Because("only teachers can access this resource");

            try
            {
                List<Domain.Entities.ClassRoomSubject> entitiesGetted = await _classRoomSubjectRepository.GetAllByUserIdAsync(_currentUserInfo.Id);

                return new("Teachers sections were getted successfully", _mapper.Map<List<ClassRoomSubjectModel>>(entitiesGetted));
            }
            catch
            {
                return ErrorTypes.Exceptions.Because("Critical error while getting the entities");
            }
        }
    }
}
