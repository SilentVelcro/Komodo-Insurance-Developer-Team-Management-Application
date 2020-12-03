using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Dev
    {
        //POCO
        public string DevName { get; set; }
        public int IdNumber { get; set; }
        public bool HasAccess { get; set; }

        public Dev() { }

        public Dev(string devname, int idnumber, bool hasaccess)
        {
            DevName = devname;
            IdNumber = idnumber;
            HasAccess = hasaccess;
        }
    }
}
