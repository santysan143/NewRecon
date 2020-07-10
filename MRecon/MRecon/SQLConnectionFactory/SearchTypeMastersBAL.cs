using MRecon.Database;
using MRecon.AbstractFactory;
using MRecon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.SQLConnectionFactory
{
    public class SearchTypeMastersBAL : ISearchTypeMasters
    {
        DbModel db;
        public SearchTypeMastersBAL()
        {
            db = new DbModel();
        }
        List<Service> ISearchTypeMasters.SearchTypeList()
        {
            return db.SearchTypeMasters.Select(s => new MRecon.ViewModel.Service() { IsActivated = false, IsRequired = false, ServiceID = s.SearchTypeID, ServiceName = s.SearchName }).ToList();
        }
        List<Service> ISearchTypeMasters.SearchTypeList(long RegistrationID)
        {
            return db.RegistrationWiseSearchTypes.Join(db.SearchTypeMasters, x => x.SearchTypeID, y => y.SearchTypeID, (x, y) => new { x, y.SearchName }).Where(w => w.x.RegistrationID == RegistrationID).Select(s => new Service() { ServiceID = s.x.SearchTypeID, IsRequired = s.x.IsRequired, IsActivated = false, ServiceName = s.SearchName }).ToList();
        }
    }
}
