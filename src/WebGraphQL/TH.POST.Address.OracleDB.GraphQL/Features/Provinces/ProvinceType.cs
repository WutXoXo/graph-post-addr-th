using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Localization;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.OracleDB.GraphQL.Features.Provinces
{
    public class ProvinceType : ObjectType<ProvinceEntity>
    {
        private readonly IStringLocalizer<ProvinceType> _localizer;
        public ProvinceType(IStringLocalizer<ProvinceType> localizer) : base()
        {
            _localizer = localizer;
        }

        protected override void Configure(IObjectTypeDescriptor<ProvinceEntity> descriptor)
        {
            descriptor.Description(_localizer["Represents any province"]);

            descriptor
                .Field(c => c.Id)
                .Description(_localizer["Represents the unique ID for the province"]);

            descriptor
                .Field(c => c.Code)
                .Description(_localizer["Represents the code for the province"]);

            descriptor
                .Field(c => c.NameTH)
                .Description(_localizer["Represents the name thai for the province"]);

            descriptor
                .Field(c => c.NameEN)
                .Description(_localizer["Represents the name english for the province"]);

            descriptor
                .Field(c => c.GeographyId)
                .Description(_localizer["Represents the unique ID of the geography which the province"]);

            descriptor
                .Field(c => c.Geography)
                .ResolveWith<Resolvers>(c => c.GetGeography(default!, default!))
                .UseDbContext<AppOracleDBContext>()
                .Description(_localizer["This is the geography to which the province"]);

            descriptor
                .Field(p => p.Amphures)
                .ResolveWith<Resolvers>(p => p.GetAmphures(default!, default!))
                .UseDbContext<AppOracleDBContext>()
                .Description(_localizer["This is the list of amphur for this province"]);

        }

        private class Resolvers
        {
            public GeographyEntity GetGeography(ProvinceEntity province, [ScopedService] AppOracleDBContext context)
            {
                return context.Geographies.FirstOrDefault(p => p.Id == province.GeographyId);
            }

            public IQueryable<AmphurEntity> GetAmphures(ProvinceEntity province, [ScopedService] AppOracleDBContext context)
            {
                return context.Amphures.Where(p => p.ProvinceId == province.Id);
            }
        }
    }
}
