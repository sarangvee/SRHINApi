using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRHINApi.Support
{
    internal class Datamodel2
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int id { get; set; }
            public int schoolId { get; set; }
            public string classIds { get; set; }
            public string examName { get; set; }
            public string acadamicYear { get; set; }
            public bool activated { get; set; }
            public DateTime createdDate { get; set; }
            public object school { get; set; }
        }

    }
}
