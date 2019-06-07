using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZP50.Core.CentroAscolto;

namespace ZP50.Web.Areas.CentroAscolto.Models
{
    public class NucleoFamiliareFilterModel
    {
        public string Query { get; set; }

        public IQueryable<NucleoFamiliare> Apply(IQueryable<NucleoFamiliare> queryable)
        {
            if (!String.IsNullOrEmpty(Query))
            {
                queryable = queryable.Where(x => x.Nome.Contains(Query));
            }
            return queryable;
        }
    }

    public class NucleoFamiliareListModel
    {
        public NucleoFamiliareFilterModel Filter { get; set; }
        public IEnumerable<NucleoFamiliare> Items { get; set; }
    }



    public class SchedaIncontroFilterModel
    {
        public Guid? NucleoFamiliareID { get; set; }
        public DateTime? CreataIl { get; set; }


        public string SortBy { get; set; }
        public string SortDir { get; set; }


        public IQueryable<SchedaIncontro> Apply(IQueryable<SchedaIncontro> queryable)
        {
            if (NucleoFamiliareID.HasValue)
            {
                queryable = queryable.Where(x => x.NucleoFamiliareID==NucleoFamiliareID.Value);
            }
            if (CreataIl.HasValue)
            {
                queryable = queryable.Where(x => x.CreataIl == CreataIl.Value);
            }

            return queryable;
        }
    }

    public class SchedaIncontroListModel
    {
        public SchedaIncontroFilterModel Filter { get; set; }
        public IEnumerable<SchedaIncontro> Items { get; set; }
    }
}