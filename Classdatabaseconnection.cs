using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace schoolmgmt
{
    public partial class Classdatabaseconnection
    {



        public string path = @"C:\SchoolManagement\Database\File\School_Management.sqlite";

        public void CreateDatabaseAndTable()
        {

            if (!System.IO.File.Exists(path))
            {
               Directory.CreateDirectory(@"C:\SchoolManagement\Database\File\");

                Console.WriteLine("Just entered to create Sync DB");
                SQLiteConnection.CreateFile(path);

                using (var sqlite = new SQLiteConnection((@"Data Source=" + path)))
                {
                    sqlite.Open();
                    string sql1 = "CREATE TABLE student (id INTEGER,name TEXT,surname TEXT,age TEXT,rollnumber TEXT,hobby TEXT,	PRIMARY KEY(id AUTOINCREMENT))";
                    SQLiteCommand command1 = new SQLiteCommand(sql1, sqlite);
                    command1.ExecuteNonQuery();

                    string sql2 = @"INSERT INTO student VALUES(1,'Manulla','Khan','23','515','Playing')";
                    SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite);
                    command2.ExecuteNonQuery();
                    sqlite.Close();
                }
            }

         
            else
            {
                // Console.WriteLine("Database Can not Created");
                // return;
            }

        }

        //insert student
        public void insertstudent(string name,string surname,string age,string rollnumber,string hobby)
        {
            using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
            {
                sqlite.Open();
                string sql2 = "INSERT INTO student (name,surname,age,rollnumber,hobby) VALUES('"+name+ "','" +surname+ "','" + age+ "','" +rollnumber+ "','" +hobby+ "')";
                SQLiteCommand command2 = new SQLiteCommand(sql2, sqlite);
                command2.ExecuteNonQuery();
                sqlite.Close();

            }

        }

        //return path of database
        public string cspath()
        {
            return path;
        
        }
        

        
    }
}
