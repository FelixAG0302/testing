﻿
using MapsterMapper;
using testing.Application.Core;
using testing.Application.Features.Application.DegreeFeature.Models;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Application.Features.Application.DegreeFeature
{
    public class DegreeService : BaseCompleteService<DegreeModel, SaveDegreeModel, Degree>, IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        public DegreeService(IDegreeRepository degreeRepository, IMapper mapper) : base(degreeRepository, mapper)
        {
            _degreeRepository = degreeRepository;
        }
    }
}
