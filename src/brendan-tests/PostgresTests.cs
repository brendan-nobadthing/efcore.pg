using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NodaTime;
using Xunit;

namespace brendan_tests
{
    public class PostgresTests
    {

        [Fact]
        public void PostgresTest()
        {
            var ctx = TestContext.Instance.TestDbContext;

            var entity = new TestEntity
            {
                TestValue = Guid.NewGuid().ToString(),
                Data = new TextEntityData()
                {
                    LocalTime = new LocalTime(12,20),
                    TestDate = new LocalDate(2019, 11, 05)
                }
            };

            ctx.Add(entity);
            ctx.SaveChanges();

            var loadedEntity =  ctx.TestEntities
                .Where(t => t.TestValue == entity.TestValue)
                .SingleOrDefault();

            Assert.NotNull(loadedEntity);
            Assert.Equal(entity.TestValue, loadedEntity.TestValue);
            Assert.Equal(entity.Data.TestDate, loadedEntity.Data.TestDate);
            Assert.Equal(entity.Data.LocalTime, loadedEntity.Data.LocalTime);
        }
    }
}
