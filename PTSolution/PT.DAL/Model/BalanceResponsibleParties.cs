using System;
using System.Collections.Generic;

namespace PT.DAL.Model;

public partial class BalanceResponsibleParties
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string BusinessId { get; set; } = null!;

    public string CodingScheme { get; set; } = null!;

    public DateTime ValidityStart { get; set; }

    public DateTime ValidityEnd { get; set; }
}
