using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPOCO
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public List<Developer> TeamMembers { get; set; }
        public DevTeam() { }
        public DevTeam(string teamName, int teamID, List<Developer> teamMembers)
        {
            TeamName = teamName;
            TeamID = teamID;
            TeamMembers = teamMembers;
        }
    }
}
