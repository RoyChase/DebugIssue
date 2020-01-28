using System;
using System.Linq;
using IssueLibrary;

namespace DebugIssueCore
{
    class Program
    {
        static void Main()
        {
            var lib = new IssueTest();

            var qry = lib.GetData();

            try
            {
                // putting a breakpoint here doesn't cause any issue in VS2019 or VS2017
                // we get a "Table not found" type exception which is as expected
                var result = qry.ToList();
            }
            catch (TypeInitializationException tie)
            {
                Console.WriteLine("ThreadAbort Exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Normal Exception");
            }
        }
    }
}
