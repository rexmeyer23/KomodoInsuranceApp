using DeveloperPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepository
{
    public class DeveloperRepo
    {
        protected readonly List<Developer> _developerDirectory = new List<Developer>();

        //CRUD
        //Create
        public bool AddDeveloper(Developer developer)
        {
            int list = _developerDirectory.Count;
            _developerDirectory.Add(developer);

            bool addedMember = _developerDirectory.Count > list ? true : false;
            return addedMember;
        }
        //Read
        public List<Developer> ListDevelopers()
        {
            return _developerDirectory;
        }
        
        //Update
        public bool UpdateDeveloperProp(int originalDeveloper, Developer newDeveloper)
        {
            Developer oldDeveloper = RetrieveDeveloperByID(originalDeveloper);

            if (oldDeveloper != null)
            {
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.ID = newDeveloper.ID;
                oldDeveloper.PluralSight = newDeveloper.PluralSight;
                return true;

            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDeveloper(Developer currentDeveloper)
        {
            bool removedDeveloper = _developerDirectory.Remove(currentDeveloper);
            return removedDeveloper;
        }
        //Helper
        public Developer RetrieveDeveloperByID(int idNum)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.ID == idNum)
                {
                    return developer;
                }
            }
            return null;
        }
        public List<Developer> DeveloperPluralSight()
        {
            List<Developer> developerLicense = new List<Developer>();
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.PluralSight == false)
                {
                    developerLicense.Add(developer);
                }
            }
            return developerLicense;
        }
    }
}

