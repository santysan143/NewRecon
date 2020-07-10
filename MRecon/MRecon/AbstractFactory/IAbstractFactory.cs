using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface IAbstractFactory
    {
        IRegistration Registration();
        ILogger Logger();
        ILicenseKeys LicenseKeys();
        ISearchTypeMasters SearchTypeMasters();
        IUserMaster UserMaster();
    }
}
