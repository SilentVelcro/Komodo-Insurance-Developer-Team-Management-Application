using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    //POCO
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int TeamIdNumber { get; set; }
        public List<Dev> TeamMembers { get; set; } = new List<Dev>();
        

        public DevTeam() { }

        public DevTeam(string teamName, int teamIdNumber, List<Dev> teamMembers)
        {
            TeamName = teamName;
            TeamIdNumber = teamIdNumber;
            TeamMembers = teamMembers;
        }
    }
}
