using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Localization;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.OracleDB.GraphQL.Features.Geographies
{
    public class GeographyType : ObjectType<GeographyEntity>
    {
        private readonly IStringLocalizer<GeographyType> _localizer;
        public GeographyType(IStringLocalizer<GeographyType> localizer) : base()
        {
            _localizer = localizer;
        }

        protected override void Configure(IObjectTypeDescriptor<GeographyEntity> descriptor)
        {
            descriptor.Description(_localizer["Represents any geographic information"]);

            descriptor
                .Field(p => p.Id)
                .Description(_localizer["Represents the unique ID for the geography"]);

            descriptor
                .Field(p => p.Name)
                .Description(_localizer["Represents the name for the geography"]);

            descriptor
                .Field(p => p.Provinces)
                .ResolveWith<Resolvers>(p => p.GetProvinces(default!, default!))
                .UseDbContext<AppOracleDBContext>()
                .Description(_localizer["This is the list of provinces for this geography"]);
        }

        private class Resolvers
        {
            public IQueryable<ProvinceEntity> GetProvinces(GeographyEntity geography, [ScopedService] AppOracleDBContext context)
            {
                return context.Provinces.Where(p => p.GeographyId == geography.Id);
            }
        }
    }
}
