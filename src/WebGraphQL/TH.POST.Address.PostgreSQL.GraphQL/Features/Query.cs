using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.PostgreSQL.GraphQL.Features
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {

        [UseDbContext(typeof(AppPostgreSQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable geography.")]
        public IQueryable<GeographyEntity> GetGeography([ScopedService] AppPostgreSQLContext context)
        {
            return context.Geographies;
        }


        [UseDbContext(typeof(AppPostgreSQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable province.")]
        public IQueryable<ProvinceEntity> GetProvince([ScopedService] AppPostgreSQLContext context)
        {
            return context.Provinces;
        }

        [UseDbContext(typeof(AppPostgreSQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable amphur.")]
        public IQueryable<AmphurEntity> GetAmphur([ScopedService] AppPostgreSQLContext context)
        {
            return context.Amphures;
        }

        [UseDbContext(typeof(AppPostgreSQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable district.")]
        public IQueryable<DistrictEntity> GetDistrict([ScopedService] AppPostgreSQLContext context)
        {
            return context.Districts;
        }
    }
}
