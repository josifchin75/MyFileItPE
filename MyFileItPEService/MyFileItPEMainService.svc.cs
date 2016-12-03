using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyFileItPEService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyFileItPEMainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyFileItPEMainService.svc or MyFileItPEMainService.svc.cs at the Solution Explorer and start debugging.
    public class MyFileItPEMainService : IMyFileItPEMainService
    {
        public void DoWork()
        {
            using (var svc = new FileItMainService.FileItServiceClient()) {
                var result = svc.GetCabinets("admin", "admin", "admin", true);
                int i = 0;
            }
        }
    }
}
