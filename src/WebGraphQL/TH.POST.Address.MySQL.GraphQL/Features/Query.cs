using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.MySQL.GraphQL.Features
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {

        [UseDbContext(typeof(AppMySQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable geography.")]
        public IQueryable<GeographyEntity> GetGeography([ScopedService] AppMySQLContext context)
        {
            return context.Geographies;
        }


        [UseDbContext(typeof(AppMySQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable province.")]
        public IQueryable<ProvinceEntity> GetProvince([ScopedService] AppMySQLContext context)
        {
            return context.Provinces;
        }

        [UseDbContext(typeof(AppMySQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable amphur.")]
        public IQueryable<AmphurEntity> GetAmphur([ScopedService] AppMySQLContext context)
        {
            return context.Amphures;
        }

        [UseDbContext(typeof(AppMySQLContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable district.")]
        public IQueryable<DistrictEntity> GetDistrict([ScopedService] AppMySQLContext context)
        {
            return context.Districts;
        }
    }
}
