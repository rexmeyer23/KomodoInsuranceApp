using DeveloperPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepository
{
    public class DevTeamRepo
    {
        protected readonly List<DevTeam> _teamDirectory = new List<DevTeam>();

        //CRUD
        //Create
        public bool AddTeam(DevTeam developerTeam)
        {
            int listOfTeams = _teamDirectory.Count;
            _teamDirectory.Add(developerTeam);

            bool addedTeam = _teamDirectory.Count > listOfTeams ? true : false;
            return addedTeam;

        }
        //Read
        public List<DevTeam> ListTeams()
        {
            return _teamDirectory;
        }
        public DevTeam GetTeamByID(int teamID)
        {
            foreach (DevTeam team in _teamDirectory)
            {
                if (team.TeamID == teamID)
                {
                    return team;
                }
            }
            return null;
        }
        //Update
        public bool UpdateExistingTeam(int originalTeamID, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamByID(originalTeamID);
            if (oldTeam != null)
            {
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamID = newTeam.TeamID;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveExistingTeam(DevTeam currentTeam)
        {
            bool removedTeam = _teamDirectory.Remove(currentTeam);
            return removedTeam;
        }

        //Helper Methods
        public bool AddMemberToTeam(int teamID, Developer newMember)
        {
            DevTeam team = GetTeamByID(teamID);

            if (team != null)
            {
                team.TeamMembers.Add(newMember);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool RemoveMemberFromTeam(int teamID, Developer oldMember)
        {
            DevTeam team = GetTeamByID(teamID);

            if(team != null)
            {
                team.TeamMembers.Remove(oldMember);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
