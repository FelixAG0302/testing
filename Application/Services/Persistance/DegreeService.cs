using AutoMapper;
using Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.Degree;
using testing.Domain.Entities;
using testing.Domain.Repositories;
using testing.Infraestructure.Repositries;

namespace testing.Application.Services.Persistance
{
    public class DegreeService : BaseCompleteService<DegreeModel, SaveDegreeModel, Degree>, IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;
        public DegreeService(IDegreeRepository degreeRepository, IMapper mapper) : base (degreeRepository, mapper)
        {
            _degreeRepository = degreeRepository;
        }
    }
}
