using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Students_Manager_System___With_MySql
{
    class tool
    {

        // connection 
        static public MySqlConnection MySqlCon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString);


        // MySql DataReader .. 
        static public MySqlDataAdapter Adapter;


        // Table ..
        static public DataTable Table = new DataTable();


        // MySql Command ..
        static public MySqlCommand Command;


    }
}
