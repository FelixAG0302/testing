using AutoMapper;
using Infraestructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Contracts.Persistance;
using testing.Application.Core;
using testing.Application.Models.DegreeSubject;
using testing.Domain.Entities;
using testing.Domain.Repositories;
using testing.Infraestructure.Repositries;

namespace testing.Application.Services.Persistance
{
    internal class DegreeSubjectService: BaseService<SaveDegreeSubjectModel,DegreeSubject>, IDegreeSubjectService
    {
        private readonly IDegreeSubjectRepository _degreeSubjectRepository;
        public DegreeSubjectService(IDegreeSubjectRepository degreeSubjectRepository, IMapper mapper) : base (degreeSubjectRepository, mapper)
        {
            _degreeSubjectRepository = degreeSubjectRepository;
        }
    }
}
