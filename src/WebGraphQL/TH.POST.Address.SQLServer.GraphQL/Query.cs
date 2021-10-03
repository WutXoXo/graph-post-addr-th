using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.SQLServer.GraphQL
{
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {

        [UseDbContext(typeof(AppSQLServerContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable geography.")]
        public IQueryable<GeographyEntity> GetGeography([ScopedService] AppSQLServerContext context)
        {
            return context.Geographies;
        }


        [UseDbContext(typeof(AppSQLServerContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable province.")]
        public IQueryable<ProvinceEntity> GetProvince([ScopedService] AppSQLServerContext context)
        {
            return context.Provinces;
        }

        [UseDbContext(typeof(AppSQLServerContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable amphur.")]
        public IQueryable<AmphurEntity> GetAmphur([ScopedService] AppSQLServerContext context)
        {
            return context.Amphures;
        }

        [UseDbContext(typeof(AppSQLServerContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable district.")]
        public IQueryable<DistrictEntity> GetDistrict([ScopedService] AppSQLServerContext context)
        {
            return context.Districts;
        }
    }
}
