using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managent_System
{
    internal class Connection
    {
        public static SqlConnection Connect()
        {
            return new SqlConnection("Server=tcp:myserever.database.windows.net,1433;Initial Catalog=Project;Persist Security Info=False;User ID=admin1;Password=2@Amit12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); 
        }
    }
}
