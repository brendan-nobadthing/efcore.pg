using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace brendan_tests
{
    public class TestEntity
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string TestValue { get; set; }

        public TextEntityData Data { get; set; }
    }


    public class TextEntityData
    {
        public LocalDate TestDate { get; set; }

        public LocalTime LocalTime { get; set; }

    }
}
