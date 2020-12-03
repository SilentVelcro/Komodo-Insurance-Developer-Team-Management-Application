using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DevTeam_Repo
    {
        private List<DevTeam> _listOfTeams = new List<DevTeam>();

        //C
        public void AddDevTeamToList(DevTeam team)
        {
            _listOfTeams.Add(team);
        }

        public void AddDeveloperToTeam(DevTeam devTeam, Dev addSingleDeveloper)
        {
            devTeam.TeamMembers.Add(addSingleDeveloper);
        }

        //R
        public List<DevTeam> GetTeamList()
        {
            return _listOfTeams;
        }
        //U
        public bool UpdateExisitingTeamList(int teamId, DevTeam newTeam)
        {
            //find employee
            DevTeam oldTeam = GetTeamById(teamId);

            //update employee
            if (oldTeam != null)
            {
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamIdNumber = newTeam.TeamIdNumber;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddingEmployeeToList(int addDevToTeamId, Dev addDeveloper)
        {
            //find employee
            DevTeam addTeamMember = GetTeamById(addDevToTeamId);

            //add employee

            if (addTeamMember != null)
            {
                addTeamMember.TeamMembers.Add(addDeveloper);

                return true;
            }
            else
            {
                return false;
            }

        }

        //D
        public bool RemoveEmployeeFromList(string teamname)
        {
            DevTeam team = GetTeamByName(teamname);

            if (team == null)
            {
                return false;
            }

            int initalCount = _listOfTeams.Count;
            _listOfTeams.Remove(team);

            if (initalCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELP!
        private DevTeam GetTeamByName(string teamname)
        {
            foreach (DevTeam team in _listOfTeams)
            {
                if (team.TeamName == teamname.ToLower())
                {
                    return team;
                }
            }
            return null;

        }
        public DevTeam GetTeamById(int teamid)
        {
            foreach (DevTeam team in _listOfTeams)
            {
                if (team.TeamIdNumber == teamid)
                {
                    return team;
                }
            }
            return null;
        }

        // Write function to return single DevTeam by DevTeamId
    }
}

