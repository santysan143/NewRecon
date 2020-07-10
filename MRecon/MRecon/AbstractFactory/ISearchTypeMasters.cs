using MRecon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface ISearchTypeMasters
    {
        List<Service> SearchTypeList();
        List<Service> SearchTypeList(Int64 RegistrationID);
    }
}
