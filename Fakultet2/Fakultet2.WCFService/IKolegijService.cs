using Fakultet2.WCFService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Fakultet2.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKolegijService" in both code and config file together.
    [ServiceContract]
    public interface IKolegijService
    {
        [OperationContract]
        List<Kolegij> DohvatiKolegije();
        [OperationContract]
        Kolegij DohvatiKolegij(int id);
    }
}
