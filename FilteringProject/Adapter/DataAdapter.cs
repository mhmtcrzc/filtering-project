using System.Collections.Generic;

namespace FilteringProject.Adapter
{
    // DataAdapter abstract class to be used for different approaches in convertion
    public abstract class DataAdapter
    {
        public abstract List<Table> ConvertToTable(List<Dictionary<string, string>> data);
    }
}