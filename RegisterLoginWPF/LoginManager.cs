using System.Data.SqlClient;
using System.IO;

namespace RegisterLogin
{
    public class LoginManager
    {
        private readonly List<Login> logins = [];
        private readonly string txt = @"..\..\..\logins.txt";
        private SqlConnection myConn = new SqlConnection("Server=labVMH8OX\\SQLEXPRESS;database=RegisterLogin;integrated security = true");

        public LoginManager()
        {
            myConn.Open();
        }

        //public LoginManager(string txt)
        //{
        //    this.txt = txt;
        //}

        //public bool LoadFromTxt()
        //{
        //    try
        //    {
        //        StreamReader readtext = new(txt);
        //        while (!readtext.EndOfStream)
        //        {
        //            string? username = readtext.ReadLine();
        //            string? password = readtext.ReadLine();
        //            AddUser(username, password);
        //        }
        //        readtext.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return false;
        //    }
        //    return true;
        //}

        //public bool AddUserToTxt(string username, string password)
        //{
        //    try
        //    {
        //        StreamWriter sw = new(txt, true);
        //        sw.WriteLine(username);
        //        sw.WriteLine(password);
        //        sw.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }
        //    return true;
        //}

        //public bool AddUser(Login login)
        //{
        //    )
        //    //if (HasUser(login.GetUsername()))
        //    //{
        //    //    return false;
        //    //}
        //    //logins.Add(login);
        //    //return true;
        //}

        public bool AddUser(string? username, string? password)
        {
            ArgumentNullException.ThrowIfNull(username);
            ArgumentNullException.ThrowIfNull(password);
            SqlCommand command = new SqlCommand("INSERT INTO tbl VALUES (\'" + username + "\', \'" + password + "\')", myConn);
            command.ExecuteNonQuery();
            return true;
            //return username != null && password != null && AddUser(new Login(username, password));
        }

        public bool CheckLogin(string username, string password)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT [User] FROM tbl WHERE [User] = \'" + username + "\' AND password = '" + password + "'", myConn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].Equals(username))
                    {
                        reader.Dispose();
                        return true;
                    }
                }
                reader.Dispose();
                return false;
            }
            catch (SqlException)
            {
                throw;
            }
            
            //foreach (Login login in logins)
            //{
            //    if (login.GetUsername().Equals(username))
            //    {
            //        return login.CheckPassword(password);
            //    }
            //}
            //return false;
        }

        public bool HasUser(string username)
        {
            foreach (Login login in logins)
            {
                if (login.GetUsername().Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ChangeUserPassword(string username, string password, string newPass)
        {
            foreach (Login login in logins)
            {
                if (login.GetUsername().Equals(username))
                {
                    return login.ChangePassword(password, newPass);
                }
            }
            return false;
        }
    }
}
