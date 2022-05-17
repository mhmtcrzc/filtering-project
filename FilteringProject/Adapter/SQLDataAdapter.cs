using System;
using System.Collections.Generic;

namespace FilteringProject.Adapter
{
    public class SQLDataAdapter : DataAdapter
    {
        public override List<Table> ConvertToTable(List<Dictionary<string, string>> data)
        {
            var tables = new List<Table>();

            foreach (var tableData in data)
            {
                var id = tableData["id"];
                var pot = int.Parse(tableData["pot"]);
                var type = int.Parse(tableData["type"]);

                var newTable = new Table
                {
                    Id = id,
                    Pot = pot,
                    Type = (TableTypes) type
                };
                
                tables.Add(newTable);

            }
            
            return tables;
        }
    }
}