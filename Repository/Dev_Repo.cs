using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Dev_Repo
    {
        private List<Dev> _listOfDevelopers = new List<Dev>();

        //c
        public void AddEmployeeToList(Dev developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //R
        public List<Dev> GetEmployeeList()
        {
            return _listOfDevelopers;
        }

        public List<Dev> NeedAccess()
        { 
            List<Dev> noAccess = new List<Dev>();

            foreach (Dev dev in _listOfDevelopers)
            {
                if (dev.HasAccess == false)
                {
                    noAccess.Add(dev);
                }
            }
            return noAccess;
        }

        //U
        public bool UpdateExisitingEmployeeList(int oldId, Dev newDeveloper)
        {
            //find employee
            Dev oldDeveloper = GetEmployeeById(oldId);

            //update employee
            if (oldDeveloper != null)
            {
                oldDeveloper.DevName = newDeveloper.DevName;
                oldDeveloper.HasAccess = newDeveloper.HasAccess;

                return true;
            }
            else
            {
                return false;
            }

        }

        //D
        public bool RemoveEmployeeFromList(string devname)
        {
            Dev developer = GetEmployeeByName(devname);

            if (developer == null)
            {
                return false;
            }

            int initalCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if (initalCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //HELP!
        private Dev GetEmployeeByName(string devname)
        {
            foreach (Dev Developer in _listOfDevelopers)
            {
                if (Developer.DevName == devname.ToLower())
                {
                    return Developer;
                }
            }
            return null;
        }
        public Dev GetEmployeeById(int devId)
        {
            foreach (Dev Developer in _listOfDevelopers)
            {
                if (Developer.IdNumber == devId)
                {
                    return Developer;
                }
            }
            return null;
        }
    }
}