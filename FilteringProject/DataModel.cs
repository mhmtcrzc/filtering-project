using System;
using System.Collections.Generic;
using FilteringProject.Adapter;

namespace FilteringProject
{
    public class DataModel
    {
        private readonly DataAdapter _adapter;
        private List<Table> _tables;
        // It is open for different types of adapters.
        public DataModel(DataAdapter adapter)
        {
            _adapter = adapter;
        }

        public void SetModel(List<Dictionary<string, string>> data)
        {
            _tables = _adapter.ConvertToTable(data);
        }
        
        public List<Table> GetTables(Func<Table, bool> filterFunction = null)
        {
            if (filterFunction == null) return _tables;

            var filteredList = new List<Table>();
            
            foreach (var table in _tables)
            {
                // Use filter function to filter out non suitable tables
                if (filterFunction(table)) filteredList.Add(table);
            }

            return filteredList;
        } 
    }
}