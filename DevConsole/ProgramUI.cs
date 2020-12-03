using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConsole
{
    class ProgramUI
    {
        private Dev_Repo _developerRepo = new Dev_Repo();

        private DevTeam_Repo _teamRepo = new DevTeam_Repo();

        public void Run()
        {
            SeeDeveloperList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View All Developer-Teams\n" +
                    "4. Update Existing Employee\n" +
                    "5. Update Existing Developer-Team\n" +
                    "6. Create New Developer-Team\n" +
                    "7. Add Developer to a Team\n" +
                    "8. Need Pluralsight Access\n" +
                    "9. View Team by ID#\n" +
                    "10. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDevloper();
                        break;
                    case "2":
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        DisplayAllDeveloperTeams();
                        break;
                    case "4":
                        UpdateExisitingDeveloper();
                        break;
                    case "5":
                        UpdateExisitingDeveloperTeam();
                        break;
                    case "6":
                        CreateNewDeveloperTeam();
                        break;
                    case "7":
                        AddDeveloperToTeam();
                        break;
                    case "8":
                        NeedPluralsightAccess();
                        break;
                    case "9":
                        ViewTeamByTeamId();
                        break;
                    case "10":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press anu key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //1. Add New Developer
        private void CreateNewDevloper()
        {
            Console.Clear();
            Dev newDeveloper = new Dev();

            //name
            Console.WriteLine("Enter the first & last name for the new developer:");
            newDeveloper.DevName = Console.ReadLine();

            //ID# 
            Console.WriteLine("Enter Developer ID#:");
            string idnumberasstring = Console.ReadLine();
            newDeveloper.IdNumber = int.Parse(idnumberasstring);
  
            //access to pluralsight
            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string hasaccess = Console.ReadLine().ToLower();
            
            if (hasaccess == "y")
            {
                newDeveloper.HasAccess = true;
            }
            else
            {
                newDeveloper.HasAccess = false;
            }


            _developerRepo.AddEmployeeToList(newDeveloper);
        }

        //2. View All Developers
        public void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Dev> listOfDevelopers = _developerRepo.GetEmployeeList();

            foreach (Dev deveopler in listOfDevelopers)
            {
                Console.WriteLine($"Developer:{deveopler.DevName}\n" +
                    $"ID#:{deveopler.IdNumber}\n" +
                    $"Has access to Pluralsight:{deveopler.HasAccess}");
            }

        }

        //3. View All Developer-Teams
        public void DisplayAllDeveloperTeams()
        {
            Console.Clear();

            List<DevTeam> listofTeams = _teamRepo.GetTeamList();

            foreach (DevTeam team in listofTeams)
            {
                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                    $"Team ID#:{team.TeamIdNumber}\n");      
            }
        }

        //4. Update Existing Employee
        public void UpdateExisitingDeveloper()
        {

            DisplayAllDevelopers();

            Console.WriteLine("Enter the ID# of the developer you'd like to update.");
            int oldDeveloper = int.Parse(Console.ReadLine());

            Dev newDeveloper = new Dev();

            //name
            Console.WriteLine("Enter the first & last name for the developer you are updating:");
            newDeveloper.DevName = Console.ReadLine();

            //access to pluralsight
            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string hasaccess = Console.ReadLine().ToLower();

            if (hasaccess == "y")
            {
                newDeveloper.HasAccess = true;
            }
            else
            {
                newDeveloper.HasAccess = false;
            }

            bool wasUpdated = _developerRepo.UpdateExisitingEmployeeList(oldDeveloper, newDeveloper);
            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update developer.");
            }
        }

        //5. Update Existing Developer-Team
        public void UpdateExisitingDeveloperTeam()
        {
            DisplayAllDeveloperTeams();

            Console.WriteLine("Enter team ID# that you'd like to update.");
            int oldId = int.Parse(Console.ReadLine());

            DevTeam newTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the new name of the developer team:");
            newTeam.TeamName = Console.ReadLine();


            bool wasUpdated = _teamRepo.UpdateExisitingTeamList(oldId, newTeam);
            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Team.");
            }
        }

        //6. Create New Developer-Team
        public void CreateNewDeveloperTeam()
        {
            Console.Clear();
            DevTeam newDeveloperTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the name of the new developer team:");
            newDeveloperTeam.TeamName = Console.ReadLine();

            //ID# 
            Console.WriteLine("Enter the developer team ID#:");
            string teamidnumberasstring = Console.ReadLine();
            newDeveloperTeam.TeamIdNumber = int.Parse(teamidnumberasstring);

            newDeveloperTeam.TeamMembers = new List<Dev>();

            _teamRepo.AddDevTeamToList(newDeveloperTeam);
        }

        //7. Add Developer to a Team
        public void AddDeveloperToTeam()
        {
            Console.Clear();
            DisplayAllDeveloperTeams();

            Console.WriteLine("Enter the Team ID# that you would like add a developer to:");
            int teamID = int.Parse(Console.ReadLine());

            Console.Clear();
            
            Console.WriteLine("Enter the ID# of the developer you would like to add to the team.");
            int IdNumber = int.Parse(Console.ReadLine());

            Dev addDeveloper = _developerRepo.GetEmployeeById(IdNumber);

            bool wasUpdated = _teamRepo.AddingEmployeeToList(teamID, addDeveloper);
            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Team.");
            }
        }

        //8. Need Pluralsight Access
        public void NeedPluralsightAccess()
        {
            Console.Clear();

            List<Dev> needAccess = _developerRepo.NeedAccess();
            
            foreach (Dev devName in needAccess)
            {
                Console.WriteLine("{0}", devName.DevName);
            }
        }
        public void ViewTeamByTeamId()
        {
            Console.WriteLine("Please enter Team ID# to view members of that team.");
            string input = Console.ReadLine();
            int teamid;
            Int32.TryParse(input, out teamid);

            // Get and store single DevTeam by using the GetDevTeamById function passing in teamid as an argument

            DevTeam devTeamToView = _teamRepo.GetTeamById(teamid);

            // Iterate over the single DevTeam TeamMembers list

            foreach (Dev dev in devTeamToView.TeamMembers)
            {
                Console.WriteLine($"{dev.DevName}");
            }

        }

        //see method
        private void SeeDeveloperList()
        {
            Dev quentinTarantino = new Dev("Quentin Tarantino", 222, false);
            Dev steveBuscemi = new Dev("Steve Buscemi", 333, true);
            Dev harveyKeitel = new Dev("Harvey Keitel", 444, false);

            List<Dev> teamOrange = new List<Dev>();
            teamOrange.Add(quentinTarantino);
            teamOrange.Add(steveBuscemi);
            teamOrange.Add(harveyKeitel);

            List<Dev> teamBlack = new List<Dev>();
            teamBlack.Add(quentinTarantino);
            teamBlack.Add(harveyKeitel);

            DevTeam orangeTeam = new DevTeam("Orange Team", 666, teamOrange);
            DevTeam blackTeam = new DevTeam("Black Team", 999, teamBlack);
            _teamRepo.AddDevTeamToList(orangeTeam);
            _teamRepo.AddDevTeamToList(blackTeam);

            _developerRepo.AddEmployeeToList(quentinTarantino);
            _developerRepo.AddEmployeeToList(steveBuscemi);
            _developerRepo.AddEmployeeToList(harveyKeitel);
        }

    }
}
