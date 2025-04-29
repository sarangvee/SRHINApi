using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRHINApi.Support
{
    public class Datamodel
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string features { get; set; }
            public bool activated { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime updatedDate { get; set; }
        }

    }

}
