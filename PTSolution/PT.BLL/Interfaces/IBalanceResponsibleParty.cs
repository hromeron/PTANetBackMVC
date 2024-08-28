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

        BalanceResponsiblePartyDto Get(string country, string Code);

        bool Exists(string country, string Code);

        bool IsEmpty();

        void Load(List<BalanceResponsiblePartyDto> data);
    }
}
