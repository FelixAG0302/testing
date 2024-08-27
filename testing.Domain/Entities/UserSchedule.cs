
using System.ComponentModel.DataAnnotations.Schema;


namespace testing.Domain.Entities
{
    public class UserSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ClassRoomSubjectId { get; set; }
        [ForeignKey("ClassRoomSubjectId")]
        public IList<ClassRoomSubject> ClassRoomSubject { get; set; }
    }
}
