using MRecon.AbstractFactory;
using MRecon.SQLConnectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.SQLConnectionFactory
{
    public class SQLConcreteFactory : IAbstractFactory
    {

        IRegistration IAbstractFactory.Registration()
        {
            return new RegistrationBAL();
        }
        ILogger IAbstractFactory.Logger()
        {
            return new LoggerBAL();
        }
        ILicenseKeys IAbstractFactory.LicenseKeys()
        {
            return new LicenseKeysBAL();
        }
        ISearchTypeMasters IAbstractFactory.SearchTypeMasters()
        {
            return new SearchTypeMastersBAL();
        }

        IUserMaster IAbstractFactory.UserMaster()
        {
            return new UserMasterBAL();
        }
    }
}
