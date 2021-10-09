using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Localization;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.OracleDB.GraphQL.Features.Districts
{
    public class DistrictType : ObjectType<DistrictEntity>
    {
        private readonly IStringLocalizer<DistrictType> _localizer;
        public DistrictType(IStringLocalizer<DistrictType> localizer) : base()
        {
            _localizer = localizer;
        }

        protected override void Configure(IObjectTypeDescriptor<DistrictEntity> descriptor)
        {
            descriptor.Description(_localizer["Represents any district"]);

            descriptor
                .Field(c => c.Id)
                .Description(_localizer["Represents the unique ID for the district"]);

            descriptor
                .Field(c => c.Code)
                .Description(_localizer["Represents the code for the district"]);

            descriptor
                .Field(c => c.NameTH)
                .Description(_localizer["Represents the name thai for the district"]);

            descriptor
                .Field(c => c.NameEN)
                .Description(_localizer["Represents the name english for the district"]);

            descriptor
                .Field(c => c.ZipCode)
                .Description(_localizer["Represents the zip code for the district"]);

            descriptor
                .Field(c => c.AmphurId)
                .Description(_localizer["Represents the unique ID of the amphur which the district"]);

            descriptor
                .Field(c => c.Amphur)
                .ResolveWith<Resolvers>(c => c.GetAmphur(default!, default!))
                .UseDbContext<AppOracleDBContext>()
                .Description(_localizer["This is the amphur to which the district"]);

        }

        private class Resolvers
        {
            public AmphurEntity GetAmphur(DistrictEntity district, [ScopedService] AppOracleDBContext context)
            {
                return context.Amphures.FirstOrDefault(p => p.Id == district.AmphurId);
            }
        }
    }
}
