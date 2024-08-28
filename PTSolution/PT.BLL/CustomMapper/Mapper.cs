using PT.BLL.Dto;
using PT.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.CustomMapper
{
    internal static class Mapper
    {
        internal static BalanceResponsiblePartyDto ToDto(BalanceResponsibleParties entity)
        {
            if (entity != null)
            {

                return new BalanceResponsiblePartyDto()
                {
                    brpCode = entity.Code,
                    brpName = entity.Name,
                    businessId = entity.BusinessId,
                    country = entity.Country,
                    codingScheme = entity.CodingScheme,
                    validityEnd = entity.ValidityEnd,
                    validityStart = entity.ValidityStart
                };
            }

            return null;
        }

        internal static BalanceResponsibleParties ToEntity(BalanceResponsiblePartyDto modelDto)
        {
            if (modelDto != null)
            {
                return new BalanceResponsibleParties()
                {
                    Code = modelDto.brpCode,
                    Name = modelDto.brpName,
                    BusinessId = modelDto.businessId,
                    Country = modelDto.country,
                    CodingScheme = modelDto.codingScheme,
                    ValidityEnd = modelDto.validityEnd,
                    ValidityStart = modelDto.validityStart
                };
            }

            return null;
        }
    }
}
