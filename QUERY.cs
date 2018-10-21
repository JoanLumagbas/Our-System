using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Project010101
{
    class QUERY
    {
        public string[] LIST = new string [15];
        public DataTable table = new DataTable();
        public MySqlDataAdapter adpt = new MySqlDataAdapter();
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlConnection con;
        public MySqlDataReader read;
        public int count = 0;
        public string open;
        public string query;
        
        
        public void insert()    
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            query = "INSERT INTO `userinfo`( `NAME`, `LASTNAME`, `USER`, `PASS`) VALUES ('" + LIST[0] + "','" + LIST[1] + "','" + LIST[2] + "','" + LIST[3] + "')";
            adpt = new MySqlDataAdapter();
            con.Open();
            adpt.InsertCommand = new MySqlCommand(query,con);
            adpt.InsertCommand.ExecuteNonQuery();
        }

        public void display() 
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            query = "SELECT `ID`, `NAME`, `LASTNAME` FROM `userinfo`";
            cmd = new MySqlCommand(query, con);
            adpt = new MySqlDataAdapter(cmd);
            adpt.Fill(table);
        }

        public void LOGIN()
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            cmd = new MySqlCommand( "SELECT * FROM `userinfo` WHERE `USER`='"+LIST[0]+"' && `PASS` = '"+LIST[1]+"';",con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                count = count + 1;
            }                   
        }

        public void SAVELog()
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            cmd = new MySqlCommand("SELECT * FROM `userinfo` WHERE `USER`='" + LIST[2] + "'",con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                count = count + 1;
            }
        }

        public void AUTHENTICATE() 
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            cmd = new MySqlCommand("SELECT * FROM `userinfo` WHERE `USER`='" + LIST[3] + "' && `PASS` = '" + LIST[4] + "' && `ID` = '"+LIST[2]+"';", con);
            con.Open(); 
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                count = count + 1;
            }
        }

        public void UPDATE() 
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            query = "UPDATE `userinfo` SET`NAME`='"+LIST[0]+"',`LASTNAME`='"+LIST[1]+"' WHERE  `ID`='"+LIST[2]+"'";
            adpt = new MySqlDataAdapter();
            con.Open();
            adpt.InsertCommand = new MySqlCommand(query, con);
            adpt.InsertCommand.ExecuteNonQuery();
        }

        public void DELETE() 
        {
            open = "data source = localhost; initial catalog = user; userid = root; password =''";
            con = new MySqlConnection(open);
            query = "DELETE FROM `userinfo` WHERE `ID`='" + LIST[2] + "'";
            adpt = new MySqlDataAdapter();
            con.Open();
            adpt.InsertCommand = new MySqlCommand(query, con);
            adpt.InsertCommand.ExecuteNonQuery();
        }
    }
}
