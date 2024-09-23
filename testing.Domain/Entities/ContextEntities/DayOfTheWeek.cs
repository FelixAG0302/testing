using System.ComponentModel.DataAnnotations;


namespace testing.Domain.Entities.ContextEntities
{
    public class DayOfTheWeek
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
