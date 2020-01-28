using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SQLite;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Mapping;

namespace IssueLibrary
{
    public class IssueTest
    {
        private readonly IDataContext _context = new DataConnection(new SQLiteDataProvider(), "Data Source= :memory: ; Cache = Shared");
        // private readonly IDataContext _context = new DataConnection(new SqlServerDataProvider("abc", SqlServerVersion.v2012), "Data Source=localhost;Initial Catalog=IssueTest;Integrated Security=True");

        public IQueryable<Sample> GetData()
        {
            var qry = _context.GetTable<Sample>().Where(x => x.Name == "DEF");

            // putting a breakpoint on this line then stepping over gives an ThreadAbortException if run in .Net Framework on VS2019 but not in VS2017.
            // It doesn't give a ThreadAbortException for .NetCore in ether VS version
            return qry;
        }

        public class Sample
        {
            [Column(IsPrimaryKey = true, IsIdentity = true)]
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
