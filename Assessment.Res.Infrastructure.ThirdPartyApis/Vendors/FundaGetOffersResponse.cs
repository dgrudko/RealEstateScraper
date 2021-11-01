using System;
using System.Collections.Generic;

namespace Assessment.Res.Infrastructure.ThirdPartyApis.Vendors
{
    public class FundaGetOffersResponse
    {
        public List<FundaObject> Objects { get; set; }
        public FundaPaging Paging { get; set; }
        public int TotaalAantalObjecten { get; set; }
    }

    public class FundaPaging
    {
        public int AantalPaginas { get; set; }
        public int HuidigePagina { get; set; }
    }

    public class FundaObject
    {
        public Guid Id { get; set; }
        public int MakelaarId { get; set; }
        public string MakelaarNaam { get; set; }
        public string Adres { get; set; }
        public string URL { get; set; }
    }
}
