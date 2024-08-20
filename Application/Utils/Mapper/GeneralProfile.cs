using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Application.Models.ClassRoom;
using testing.Domain.Entities;

namespace testing.Application.Utils.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Classroom mappigns settup configuration
            CreateMap< ClassRoom, ClassRoomModel>()
                .ForMember(dest => dest.ClassRoomSubjects, otp => otp.MapFrom(c => c.ClassRoomSubjects))
                .ReverseMap();

            CreateMap<ClassRoom, SaveClassRoomModel>()
              .ReverseMap();
            #endregion
        }
    }
}
