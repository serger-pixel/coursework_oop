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
            if (!Regex.IsMatch(fileName, RegsAndConsts.strings))
            {
                throw new NotStringException();
            }
            _service.openDataBase(path, status);
        }

        public void closeDataBase()
        {
            _service.closeDataBase();
        }

        public List<Tenant> GetAllTenants()
        {
            return _service.GetAllTenants();
        }
    }
}
