using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SWProjv1
{
    class Server
    {
        static SqlConnection sql;
        public static SqlCommand command;

        public static bool Init()
        {
            try
            {
                sql = new SqlConnection("Data Source =JAKES-LAPTOP\\SQLEXPRESS; Initial Catalog = SEProjectDB ; Integrated Security = SSPI");
                sql.Open();
                command = sql.CreateCommand();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static void setCommand(String type, String searchTerm)
        {
            if (type.Equals("Room"))
                command.CommandText = "SELECT * FROM " + type;
            else if (type.Equals("Student"))
                command.CommandText = "SELECT * FROM Student, User_T WHERE Student.UserID = User_T.UserID AND Student.userID= Student.studentID";
			else if (type.Equals("Message"))
				command.CommandText = "SELECT * FROM Message, User_T WHERE messageAcknowledge = 0 AND recieverUserID IN (SELECT recieverUserID FROM Message, Admin WHERE recieverUserID=userID)  AND user_T.userID=Message.senderUserID;";
			else if (type.Equals("TempKey"))
				command.CommandText = "SELECT * FROM TempKey";
			else if (type.Equals("RAApplication"))
				command.CommandText = "SELECT * FROM RAApplication";
		}

        public static List<ListBoxItem> runQuery(String type)
        {
            List<ListBoxItem> results = new List<ListBoxItem>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                switch (type)
                {
                    case "SWProjv1.Room":
                        String roomSide;
                        try
                        {
                            roomSide = reader.GetString(1).Trim();
                        }
                        catch (Exception excep)
                        {
                            roomSide = "";
                        }
                        Room room = new Room(
                            reader.GetString(0).Trim(),
                            roomSide,
                            reader.GetString(2).Trim(),
                            reader.GetString(3).Trim(),
                            reader.GetString(4).Trim(),
                            reader.GetString(5).Trim()
                        );
                        room.setListBoxItem();
                        results.Add(room.listboxitem);
                        break;
                    case "SWProjv1.Student":
						Student student = new Student(
							reader.GetString(0).Trim(),
							reader.GetBoolean(3),
							"123",//reader.GetString(2).Trim(),
							"0000000000001",//reader.GetString(1).Trim(),
							reader.GetString(7).Trim(),
							reader.GetString(9).Trim(),
							reader.GetString(8).Trim(),
							reader.GetString(5).Trim(),
							reader.GetString(6).Trim(),
							reader.GetDateTime(10).ToString().Trim()
                            );
						student.setListBoxItem();
						results.Add(student.listboxitem);
                        break;
					case "SWProjv1.Message":
						Message message = new Message(
							reader.GetString(1).Trim(),
							reader.GetString(2).Trim(),
							reader.GetString(3).Trim(),
							reader.GetDateTime(4).ToString().Trim(),
							reader.GetString(8).Trim() + " " +  reader.GetString(9).Trim()
							);
						MessageBox.Show(reader.GetString(8).Trim() + " " + reader.GetString(9).Trim());
						message.setListBoxItem();
						results.Add(message.listboxitem);
						break;
				}
            }
            reader.Close();
            return results;
        }
        public static int LogInQuery(String username, String password)//////////////////////////////////////////////
        {
            Init();
            command.CommandText = "LogInProc";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@uname", username));
            command.Parameters.Add(new SqlParameter("@pword", password));
            command.Parameters.Add(new SqlParameter("@result", System.Data.SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
            command.ExecuteNonQuery();
            int result = Convert.ToInt32(command.Parameters["@result"].Value);
            return result;
        }
        public static SqlDataReader run_query(String commandtext)
        {
            SqlCommand cmd = new SqlCommand(commandtext, sql);
            return cmd.ExecuteReader();
        }
        public static void Executer(String command)
        {
            SqlCommand cmd = new SqlCommand(command, sql);
            cmd.ExecuteNonQuery();
        }
    }
}
