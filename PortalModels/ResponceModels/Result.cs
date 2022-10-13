using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalModels.ResponceModels
{
    public class Result<T>
    {

        public dynamic message { get; set; }
        public dynamic data { get; set; }
        public dynamic success { get; set; }

    }
}
