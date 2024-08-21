﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Models.DegreeSubject;

namespace testing.Application.Models.Degree
{
    public class DegreeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<DegreeSubjectModel> DegreeSubjects { get; set; }
    }
}
