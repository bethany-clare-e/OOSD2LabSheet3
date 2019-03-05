using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class Member
    {
        public string MemberType { get; set; }

        public string MemberName { get; set; }

        public DateTime Joindate { get; set; }

        public static int NumberOfMembers { get; set; }



        public override string ToString()
        {
            return string.Format("{0} {1} {2}", MemberName, MemberType, Joindate.ToShortDateString());
        }
    }
}
