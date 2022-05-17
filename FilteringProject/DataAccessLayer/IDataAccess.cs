using System;
using System.Collections.Generic;

namespace FilteringProject.DataAccessLayer
{
    // DataAccess interface to be used for different approaches in data access
    // Endorses Open for extension closed for modification SOLID 
    public interface IDataAccess
    {
        public List<Dictionary<string, string>> Read();
        public void Write();
        public void Update();
        public void Delete();       
    }
}