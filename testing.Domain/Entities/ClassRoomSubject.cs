using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing.Domain.Entities
{
   public class ClassRoomSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int DegreeId { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan HourBegin { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan HourFinish { get; set; }
        public int Day { get; set; }
        public Subject Subject { get; set; }
        public ClassRoom ClassRoom { get; set; }
    }
}
