using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.Localization;
using System.Linq;
using TH.POST.Address.Domain.Entities;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.OracleDB.GraphQL.Features.Amphures
{
    public class AmphurType : ObjectType<AmphurEntity>
    {
        private readonly IStringLocalizer<AmphurType> _localizer;
        public AmphurType(IStringLocalizer<AmphurType> localizer) : base()
        {
            _localizer = localizer;
        }

        protected override void Configure(IObjectTypeDescriptor<AmphurEntity> descriptor)
        {
            descriptor.Description(_localizer["Represents any amphur"]);

            descriptor
                .Field(c => c.Id)
                .Description(_localizer["Represents the unique ID for the amphur"]);

            descriptor
                .Field(c => c.Code)
                .Description(_localizer["Represents the code for the amphur"]);

            descriptor
                .Field(c => c.NameTH)
                .Description(_localizer["Represents the name thai for the amphur"]);

            descriptor
                .Field(c => c.NameEN)
                .Description(_localizer["Represents the name english for the amphur"]);

            descriptor
                .Field(c => c.ProvinceId)
                .Description(_localizer["Represents the unique ID of the province which the amphur"]);

            descriptor
                .Field(c => c.Province)
                .ResolveWith<Resolvers>(c => c.GetProvince(default!, default!))
                .UseDbContext<AppOracleDBContext>()
                .Description(_localizer["This is the province to which the amphur"]);

            descriptor
                .Field(p => p.Districts)
                .ResolveWith<Resolvers>(p => p.GetDistricts(default!, default!))
                .UseDbContext<AppOracleDBContext>()
                .Description(_localizer["This is the list of district for this amphur"]);

        }

        private class Resolvers
        {
            public ProvinceEntity GetProvince(AmphurEntity amphur, [ScopedService] AppOracleDBContext context)
            {
                return context.Provinces.FirstOrDefault(p => p.Id == amphur.ProvinceId);
            }

            public IQueryable<DistrictEntity> GetDistricts(AmphurEntity amphur, [ScopedService] AppOracleDBContext context)
            {
                return context.Districts.Where(p => p.AmphurId == amphur.Id);
            }
        }
    }
}
