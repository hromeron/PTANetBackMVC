using PT.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.Interfaces
{
    public interface IBalanceResponsibleParty
    {
        List<BalanceResponsiblePartyDto> Get();

        BalanceResponsiblePartyDto Get(string Code);

        bool Exists(string Code);

        bool Load(List<BalanceResponsiblePartyDto> data);
    }
}
