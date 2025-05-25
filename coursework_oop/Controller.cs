using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace coursework_oop
{
    public class Controller
    {
        private Service _service;

        public Controller()
        {
            _service = new Service();
        }

        public void openDataBase(string path, Statuses status)
        {
        
            string fileName = Path.GetFileNameWithoutExtension(path);
            if ((!Regex.IsMatch(fileName, RegsAndConsts.strings) || fileName.Length < RegsAndConsts.minLengthStr) &&
                status == Statuses.NEW)
            {
                throw new NotStringException();
            }
            if (File.Exists(path) && status == Statuses.NEW) 
            {
                throw new FileAllReadyExits();
            }
            _service.openDataBase(path, status);
        }

        public void closeDataBase()
        {
            _service.closeDataBase();
        }

        public void deleteDataBase()
        {
            _service.deleteDataBase();
        }

        public List<Tenant> GetAllTenants()
        {
            return _service.GetAllTenants();
        }

        public void addRecord(long id, string firstName, string lastName, int apartNumb,
           double rent,double electricity, double utilities)
        {
            if (!Regex.IsMatch(firstName, RegsAndConsts.strings) ||
                firstName.Length < RegsAndConsts.minLengthStr)
            {
                throw new NotStringException();
            }

            if (!Regex.IsMatch(lastName, RegsAndConsts.strings) ||
                lastName.Length < RegsAndConsts.minLengthStr)
            {
                throw new NotStringException();
            }
            List<Tenant> allTenants = _service.GetAllTenants();

            foreach (Tenant current in allTenants) 
            {
                if (current.Id == id)
                {
                    throw new UserAlreadyExistsException();
                };
            }
            int cnt = 0;
            foreach (Tenant current in allTenants) 
            { 
                if (current.AppartamentNumb == apartNumb)
                {
                    cnt++;
                }
            }
            if (!(cnt <= RegsAndConsts.maxCntTenants - 1)) 
            {
                throw new MaxCntPersonException();
            }
            _service.addRecord(new Tenant(id, firstName, lastName, apartNumb,
                rent, electricity, utilities));
        }
    }
}
