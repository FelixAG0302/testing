﻿using Infraestructure.Context;
using Infraestructure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;
using testing.Domain.Repositories.Persistance;

namespace testing.Infraestructure.Repositries
{
    public class DegreeRepository : BaseCompleteRepository<Degree>, IDegreeRepository
    {
        private readonly AplicationContext _context;

        public DegreeRepository(AplicationContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<bool> UpdateAsync(Degree entity)
        {
            if (!await ExitsAsync(c => c.Id == entity.Id)) return false;

            Degree degreeToBeUpdated = await _context.Degree.FindAsync(entity.Id);

            degreeToBeUpdated.Name = entity.Name;
            degreeToBeUpdated.Description = entity.Description;


            return await base.UpdateAsync(degreeToBeUpdated);
        }
    }
}
