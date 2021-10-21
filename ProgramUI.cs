using DeveloperPOCO;
using DeveloperRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoConsoleApp
{
    class ProgramUI
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            TeamList();
            //DeveloperList();
            RunMenu();
        }
        public void RunMenu()
        {
            bool runProgram = true;
            while (runProgram)
            {
                Console.Clear();
                Console.WriteLine("Hello!\n" +
                    "Welcome to Komodo Insurance Managment Application.\n" +
                    "Please enter one of the numbers below to access the following option.\n" +
                    "1. Team Options\n" +
                    "2. Developer Options\n" +
                    "3. Exit Application");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {

                    Console.WriteLine("Please enter one of the numbers below to access the following option.\n" +
                        "1. Show All Teams\n" +
                        "2. Find Team by ID\n" +
                        "3. Add Team\n" +
                        "4. Update a Team\n" +
                        "5. Add Developer to a Team\n" +
                        "6. Remove Developer From a Team\n" +
                        "7. Remove a Team\n");
                    string userInput1 = Console.ReadLine();
                    switch (userInput1)
                    {
                        case "1":
                            ShowAllTeams();
                            break;
                        case "2":
                            FindTeam();
                            break;
                        case "3":
                            CreateNewTeam();
                            break;
                        case "4":
                            //also add option to add/remove team member
                            UpdateTeam();
                            break;
                        case "5":
                            AddDeveloperToTeam();
                            break;
                        case "6":
                            RemoveDeveloperFromTeam();
                            break;
                        case "7":
                            RemoveTeam();
                            break;
                    }
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Please enter one of the numbers below to access the following option.\n" +
                        "1. Developer Directory \n" +
                        "2. Find a Developer by ID\n" +
                        "3. Add a Developer\n" +
                        "4. Update a Developer\n" +
                        "5. Remove a Developer from Directory\n" +
                        "6. See Developers With No PluralSight Access\n");
                    string userInput2 = Console.ReadLine();
                    switch (userInput2)
                    {
                        case "1":
                            ShowAllDevelopers();
                            // also give option to add developer to a team
                            break;
                        case "2":
                            FindDeveloper();
                            break;
                        case "3":
                            CreateNewDeveloper();
                            //also give option to add developer to a team
                            break;
                        case "4":
                            UpdateDeveloper();
                            break;
                        case "5":
                            DeleteDeveloper();
                            break;
                        case "6":
                            PluralSightAccess();
                            break;
                    }
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Goodbye!");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.Write("Please enter a valid number: ");
                }
            }
        }
        //ask if there is way to seperate into a one big class
        //developer options case 1
        private void ShowAllDevelopers()
        {
            Console.Clear();
            List<Developer> listDevelopers = _developerRepo.ListDevelopers();

            foreach (Developer developerMember in listDevelopers)
            {
                DisplayDevelopers(developerMember);
                Console.WriteLine("======================");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

        }
        public void DisplayDevelopers(Developer member)
        {
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"ID Number: {member.ID}");
            Console.WriteLine($"PluralSight Access: {member.PluralSight}");
        }
        public void DeveloperList()
        {
            Developer developer1 = new Developer("Rex", 1, false);
            Developer developer2 = new Developer("Mindy", 2, true);
            Developer developer3 = new Developer("Brian", 3, true);
            Developer developer4 = new Developer("Susan", 4, false);
            Developer developer5 = new Developer("Leon", 5, true);
            Developer developer6 = new Developer("Reese", 6, false);
            Developer developer7 = new Developer("Kip", 7, false);
            Developer developer8 = new Developer("Harriet", 8, true);
            Developer developer9 = new Developer("Michael", 9, true);
            Developer developer10 = new Developer("Beau", 10, false);
            _developerRepo.AddDeveloper(developer1);
            _developerRepo.AddDeveloper(developer2);
            _developerRepo.AddDeveloper(developer3);
            _developerRepo.AddDeveloper(developer4);
            _developerRepo.AddDeveloper(developer5);
            _developerRepo.AddDeveloper(developer6);
            _developerRepo.AddDeveloper(developer7);
            _developerRepo.AddDeveloper(developer8);
            _developerRepo.AddDeveloper(developer9);
            _developerRepo.AddDeveloper(developer10);
        }
        //developer options case 2
        private void FindDeveloper()
        {
            Console.Write("Please enter the number of the developer you would like to find: ");
            int developerID = int.Parse(Console.ReadLine());
            Developer developer = _developerRepo.RetrieveDeveloperByID(developerID);
            DisplayDevelopers(developer);
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        //developer options case 3
        private void CreateNewDeveloper()
        {
            bool creatingDeveloper = true;
            while (creatingDeveloper)
            {
                Developer newDeveloper = new Developer();

                Console.Write("Please enter the name of the member you want to add: ");
                newDeveloper.Name = Console.ReadLine();

                Console.Write("Please enter the member ID: ");
                string developerIDInput = Console.ReadLine();
                try
                {
                    newDeveloper.ID = int.Parse(developerIDInput);
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }

                Console.Write("Enter YES or NO if the developer has access to PluralSight? ");
                string input = Console.ReadLine().ToUpper();
                if (input != "yes")
                {
                    newDeveloper.PluralSight = false;
                }
                bool addDeveloper = _developerRepo.AddDeveloper(newDeveloper);
                if (addDeveloper != false)
                {
                    Console.WriteLine("Developer has been added to list.");
                    Console.ReadKey();
                    break;
                }
            }
        }
        //developer options case 4
        private void UpdateDeveloper()
        {
            Developer newDeveloper = new Developer();
            Console.Write("Please enter the ID number of the developer you want to update: ");
            int originalDeveloper;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out originalDeveloper);
            if (parseSuccessful != true)
            {
                Console.WriteLine("Please enter a valid ID number");
            }

            Developer oldDeveloper = _developerRepo.RetrieveDeveloperByID(originalDeveloper);
            DisplayDevelopers(oldDeveloper);
            Console.ReadKey();
            Console.Write("Enter the new name for the developer: ");
            newDeveloper.Name = Console.ReadLine();
            Console.Write("Enter the developer's new ID: ");
            try
            {
                newDeveloper.ID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("Please enter a valid number: ");
            }
            Console.Write("Enter YES or NO if you want PluralSight to be accesible to the developer: ");
            string accessPluralSight = Console.ReadLine().ToUpper();
            if (accessPluralSight != "yes")
            {
                newDeveloper.PluralSight = false;
            }
            _developerRepo.UpdateDeveloperProp(originalDeveloper, newDeveloper);
            ShowAllDevelopers();
        }
        //developer options case 5 
        private void DeleteDeveloper()
        {
            Console.Write("Please enter the ID of the developer you want to remove: ");
            int developer;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out developer);
            if (parseSuccessful != true)
            {
                Console.WriteLine("Please enter a valid ID number.");
            }
            Developer deletedDeveloper = _developerRepo.RetrieveDeveloperByID(developer);
            DisplayDevelopers(deletedDeveloper);
            Console.ReadKey();
            Console.WriteLine("Are you sure you want to delete the developer from this list?\n" +
                "Please enter YES or NO\n");
            bool switchLoop = true;
            while (switchLoop)
            {
                string delete = Console.ReadLine().ToUpper();
                switch (delete)
                {
                    case "YES":
                        _developerRepo.RemoveDeveloper(deletedDeveloper);
                        Console.WriteLine("Developer has been successfully deleted\n");
                        switchLoop = false;
                        Console.ReadKey();
                        break;
                    case "NO":
                        Console.WriteLine("Developer remains in directory.");
                        switchLoop = false;
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter YES or NO");
                        switchLoop = true;
                        Console.ReadKey();
                        break;
                }
            }
            ShowAllDevelopers();

            //}

        }
        //developer options case 6
        private void PluralSightAccess()
        {
            List<Developer> pluralSight = _developerRepo.DeveloperPluralSight();
            foreach (Developer noLicense in pluralSight)
            {
                DisplayDevelopers(noLicense);
            }
            Console.ReadKey();
        }

        //team options case 1
        private void ShowAllTeams()
        {
            List<DevTeam> listOfTeams = _devTeamRepo.ListTeams();

            foreach (DevTeam team in listOfTeams)
            {
                DisplayTeams(team);
                Console.WriteLine("(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)(*)");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void DisplayTeams(DevTeam team)
        {
            Console.WriteLine($"Team Name: {team.TeamName}");
            Console.WriteLine($"Team ID: {team.TeamID}");
            foreach (Developer member in team.TeamMembers)
            {
                Console.WriteLine($"Team Members: {member.Name}");
            }

        }
        public void TeamList()
        {

            Developer developer1 = new Developer("Rex", 1, false);
            Developer developer2 = new Developer("Mindy", 2, true);
            Developer developer3 = new Developer("Brian", 3, true);
            Developer developer4 = new Developer("Susan", 4, false);
            Developer developer5 = new Developer("Leon", 5, true);
            Developer developer6 = new Developer("Reese", 6, false);
            Developer developer7 = new Developer("Kip", 7, false);
            Developer developer8 = new Developer("Michael", 8, true);
            Developer developer9 = new Developer("Harriet", 9, true);
            Developer developer10 = new Developer("Beau", 10, false);
            _developerRepo.AddDeveloper(developer1);
            _developerRepo.AddDeveloper(developer2);
            _developerRepo.AddDeveloper(developer3);
            _developerRepo.AddDeveloper(developer4);
            _developerRepo.AddDeveloper(developer5);
            _developerRepo.AddDeveloper(developer6);
            _developerRepo.AddDeveloper(developer7);
            _developerRepo.AddDeveloper(developer8);
            _developerRepo.AddDeveloper(developer9);
            _developerRepo.AddDeveloper(developer10);

            List<Developer> teamMem1 = new List<Developer>();
            teamMem1.Add(developer7);
            teamMem1.Add(developer2);
            teamMem1.Add(developer5);
            List<Developer> teamMem2 = new List<Developer>();
            teamMem2.Add(developer9);
            teamMem2.Add(developer3);
            teamMem2.Add(developer10);
            List<Developer> teamMem3 = new List<Developer>();
            teamMem3.Add(developer6);
            teamMem3.Add(developer1);
            teamMem3.Add(developer4);
            DevTeam teamOne = new DevTeam("LevelUp", 1, teamMem1);
            DevTeam teamTwo = new DevTeam("Bangerang", 2, teamMem2);
            DevTeam teamThree = new DevTeam("JBrekkie", 3, teamMem3);
            _devTeamRepo.AddTeam(teamOne);
            _devTeamRepo.AddTeam(teamTwo);
            _devTeamRepo.AddTeam(teamThree);
        }
        //team options case 2
        private void FindTeam()
        {
            Console.Write("Please enter the Team ID of the team you would to find: ");
            int teamID;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out teamID);
            if (parseSuccessful != true)
            {
                Console.WriteLine("Please enter a valid ID number.");
            }
            DevTeam team = _devTeamRepo.GetTeamByID(teamID);
            DisplayTeams(team);
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

        }
        //team options case 3
        private void CreateNewTeam()
        {
            bool creatingTeam = true;
            while (creatingTeam)
            {
                DevTeam newTeam = new DevTeam();
                Console.Write("Please enter the name you want to give your team: ");
                newTeam.TeamName = Console.ReadLine();
                Console.Write("Please enter the number ID you want to give your team: ");
                string teamID = Console.ReadLine();
                try
                {
                    newTeam.TeamID = int.Parse(teamID);
                }
                catch
                {
                    Console.Write("Please enter a valid number: ");
                }
                bool createTeam = _devTeamRepo.AddTeam(newTeam);
                if (createTeam != false)
                {
                    Console.WriteLine("Team Added!\n" + "Press any key to continue...\n");
                    Console.ReadKey();
                    break;
                }
            }
        }
        //team options case 4
        private void UpdateTeam()
        {
            DevTeam newTeam = new DevTeam();
            Console.Write("Please enter the team ID number that you want to update: ");
            int originalTeam;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out originalTeam);
            if (parseSuccessful != true)
            {
                Console.Write("Please enter a valid number: ");
            }
            DevTeam oldTeam = _devTeamRepo.GetTeamByID(originalTeam);
            DisplayTeams(oldTeam);
            Console.ReadKey();
            Console.Write("Please enter the new name you want to give the team:  ");
            oldTeam.TeamName = Console.ReadLine();
            Console.Write("Enter the new ID number you want to give the team: ");
            try
            {
                newTeam.TeamID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("Please enter a valid number: ");
            }
            _devTeamRepo.UpdateExistingTeam(originalTeam, newTeam);
            Console.ReadKey();
            ShowAllTeams();

        }
        //team options case 5
        private void AddDeveloperToTeam()
        {
            Console.Clear();
            ShowAllTeams();
            Console.Write("Please enter the ID of the team you would like to display: ");
            int teamID;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out teamID);
            if (parseSuccessful != true)
            {
                Console.WriteLine("Please enter a valid ID number.");
            }
            Console.Clear();
            DevTeam team = _devTeamRepo.GetTeamByID(teamID);
            DisplayTeams(team);
            bool addingMember = true;
            while (addingMember)
            {
                Console.WriteLine("Do you want to add a developer to this team?\n" +
                    "YES or NO");
                string input = Console.ReadLine().ToUpper();
                if (input == "YES")
                {
                    Console.Clear();

                    ShowAllDevelopers();
                    Console.Write("Enter the ID of the developer you want to add: ");
                    int developerID;
                    bool parsedSuccessful = int.TryParse(Console.ReadLine(), out developerID);
                    if (parsedSuccessful != true)
                    {
                        Console.WriteLine("Please enter a valid ID number.");
                    }
                    Developer member = _developerRepo.RetrieveDeveloperByID(developerID);
                    _devTeamRepo.AddMemberToTeam(teamID, member);
                    DisplayTeams(team);
                    Console.ReadKey();
                    Console.WriteLine("Developer successfully added!");
                    Console.ReadKey();
                    break;
                }
                else if (input == "NO")
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    addingMember = false;
                }
                else
                {
                    Console.WriteLine("Please enter YES or NO");
                }
                Console.ReadKey();
            }

        }
        //teamoptions case 6
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            ShowAllTeams();
            Console.Write("Please enter the ID of the team you would like to display: ");
            int teamID;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out teamID);
            if (parseSuccessful != true)
            {
                Console.WriteLine("Please enter a valid ID number.");
            }
            Console.Clear();
            DevTeam team = _devTeamRepo.GetTeamByID(teamID);
            DisplayTeams(team);
            bool addingMember = true;
            while (addingMember)
            {
                Console.WriteLine("Do you want to remove a developer from this team?\n" +
                    "YES or NO");
                string input = Console.ReadLine().ToUpper();
                if (input == "YES")
                {
                    Console.Clear();

                    ShowAllDevelopers();
                    Console.Write("Enter the ID of the developer you want to remove: ");
                    int developerID;
                    bool parsedSuccessful = int.TryParse(Console.ReadLine(), out developerID);
                    if (parsedSuccessful != true)
                    {
                        Console.WriteLine("Please enter a valid ID number.");
                    }
                    Developer member = _developerRepo.RetrieveDeveloperByID(developerID);
                    _devTeamRepo.RemoveMemberFromTeam(teamID, member);
                    DisplayTeams(team);
                    Console.ReadKey();
                    Console.WriteLine("Developer successfully removed!");
                    Console.ReadKey();
                    break;
                }
                else if (input == "NO")
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    addingMember = false;
                }
                else
                {
                    Console.WriteLine("Please enter YES or NO");
                }
                Console.ReadKey();
            }

        }
        //team options case 7
        private void RemoveTeam()
        {
            Console.Write("Please enter the ID number of the team you want to delete: ");
            int team;
            bool parseSuccessful = int.TryParse(Console.ReadLine(), out team);
            if (parseSuccessful != true)
            {
                Console.Write("Please enter a valid ID number: ");
            }
            DevTeam deletedTeam = _devTeamRepo.GetTeamByID(team);
            DisplayTeams(deletedTeam);
            Console.WriteLine("Are you sure you want to delete this team?\n" +
                "YES or NO");
            bool switchLoop = true;
            while (switchLoop)
            {
                string delete = Console.ReadLine().ToUpper();
                switch (delete)
                {
                    case "YES":
                        _devTeamRepo.RemoveExistingTeam(deletedTeam);
                        Console.WriteLine("Team has been successfully deleted.");
                        switchLoop = false;
                        break;
                    case "NO":
                        Console.WriteLine("Team has not been deleted.");
                        switchLoop = false;
                        break;
                    default:
                        Console.WriteLine("Please enter YES or NO.");
                        switchLoop = true;
                        break;
                }
            }
            Console.Clear();
            ShowAllTeams();

        }

    }
}

