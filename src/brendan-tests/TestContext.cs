using System;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.TypeHandlers;
using Npgsql.TypeMapping;
using NpgsqlTypes;

namespace brendan_tests
{
    public class TestContext
    {
        public static TestContext Instance => Lazy.Value;

        private static readonly Lazy<TestContext> Lazy
            = new Lazy<TestContext>(() => new TestContext());


        public TestDbContext TestDbContext { get; }

        private TestContext()
        {
            //var serviceProvider = new ServiceCollection()
            //    .AddDbContext<TestDbContext>();


            TestDbContext = new TestDbContext();

var origJsonbMapping =
    NpgsqlConnection.GlobalTypeMapper.Mappings.Single(m => m.NpgsqlDbType == NpgsqlDbType.Jsonb);
NpgsqlConnection.GlobalTypeMapper.RemoveMapping(origJsonbMapping.PgTypeName);
NpgsqlConnection.GlobalTypeMapper.AddMapping(new NpgsqlTypeMappingBuilder
{
    PgTypeName = origJsonbMapping.PgTypeName,
    NpgsqlDbType = origJsonbMapping.NpgsqlDbType,
    DbTypes = origJsonbMapping.DbTypes,
    ClrTypes = origJsonbMapping.ClrTypes,
    InferredDbType = origJsonbMapping.InferredDbType,
    TypeHandlerFactory = new JsonbHandlerFactory(new JsonSerializerOptions()
        .ConfigureForNodaTime(DateTimeZoneProviders.Serialization))
}.Build());


            TestDbContext.Database.EnsureDeleted();
            TestDbContext.Database.Migrate();
        }

    }
}
