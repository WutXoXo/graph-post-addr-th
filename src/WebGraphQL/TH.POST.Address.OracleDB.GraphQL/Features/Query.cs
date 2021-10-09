using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.OracleDB.GraphQL.Features
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {

        [UseDbContext(typeof(AppOracleDBContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable geography.")]
        public IQueryable<GeographyEntity> GetGeography([ScopedService] AppOracleDBContext context)
        {
            return context.Geographies;
        }


        [UseDbContext(typeof(AppOracleDBContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable province.")]
        public IQueryable<ProvinceEntity> GetProvince([ScopedService] AppOracleDBContext context)
        {
            return context.Provinces;
        }

        [UseDbContext(typeof(AppOracleDBContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable amphur.")]
        public IQueryable<AmphurEntity> GetAmphur([ScopedService] AppOracleDBContext context)
        {
            return context.Amphures;
        }

        [UseDbContext(typeof(AppOracleDBContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable district.")]
        public IQueryable<DistrictEntity> GetDistrict([ScopedService] AppOracleDBContext context)
        {
            return context.Districts;
        }
    }
}
