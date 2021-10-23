using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDataSource.Model
{
    class Client
    {
        public String CodClient { get; set; }
        public String Name { get; set; }
        public String fName { get; set; }
        public String ClientGroup { get; set; }
        public String NameClientGroup { get; set; }
        public String ClientType { get; set; }
        public Object DataInicioRelacao { get; set; }
    }
}
