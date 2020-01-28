using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using IssueLibrary;

namespace DebugIssue
{
    class Program
    {
        static void Main()
        {
            var lib = new IssueTest();

            var qry = lib.GetData();
            try
            {
                // putting a breakpoint here causes a type initializationexception in VS2019 but not in VS2017
                // without the breakpoint we get a "Table not found" type exception which is as expected
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
