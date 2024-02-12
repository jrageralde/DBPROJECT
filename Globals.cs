using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;



namespace DBPROJECT
{
    static class Globals
    {
        // Connection Strings  
        public static String gdbServerName="";
        public static string gdbUser="";
        public static string gdbPassword="";
        public static string gdbPort="";
        public static string gdbDatabaseName="";

        public static string gsqlConnstr="";
        public static SqlConnection sqlconn;

        // User Profiles
        public static int gIdUser=0;
        public static string gLoginName="";


        // User has logged in
        public static bool gUserHasLoggedin=false;


        // default values for blank variables
        public static string gdefauldate = "1900/01/01";
        public static string gdefaultgender = "FEMALE";
        public static string gdefaultDateFormat = "MM/dd/yyyy";

        // colors
        public static Color gDialogBackgroundColor = Color.OldLace;

        public static Color gFormBackGroundColor = Color.OldLace;
        public static Color gGridEvenRowColor = Color.PapayaWhip;
        public static Color gGridOddRowColor = Color.White;
        public static Color gGridHeaderColor = Color.Tan;
        public static Color gGridFooterColor = Color.Tan;

        // Initialize Variables
        public static void glInitializeVariables()
        {
            String sname = ConfigurationManager.AppSettings["server"];
            String dname = ConfigurationManager.AppSettings["database"];

            if (sname != null && sname != "")
                gdbServerName = sname;
            else
                gdbServerName = @"localhost"; 
            if (dname != null && dname != "")
               gdbDatabaseName = dname;
            else
                gdbDatabaseName =  "ROYTEKDB";

            gdbUser ="DEMOUSER";
            gdbPassword= "Demo123";
            gdbPort= "";
            
            Globals.gsqlConnstr = 
                   @"Server="+Globals.gdbServerName+";"+
                   @"Database="+Globals.gdbDatabaseName+";"+
                  "User ID="+Globals.gdbUser+";"+
                  "Password="+Globals.gdbPassword;
            Globals.gUserHasLoggedin = false;
        }

        // Database Connections

        public static bool glOpenSqlConn()
        {
           
            if (sqlconn==null || sqlconn.State == ConnectionState.Closed)
            {
                bool result = true;

                sqlconn = new SqlConnection(gsqlConnstr);

                try
                {
                    sqlconn.Open();
                }
                catch (Exception ex)
                {
                    csMessageBox.Show("Exception Error:" + ex.Message,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                }
                return result;
            }
            return true;
        }
        public static void glCloseSqlConn()
        {
            sqlconn.Close();          
        }

        //this function Converts to Encode Password
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Converts to Decode Password
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        // setting screen size
        static public void glSetSizeToScreen(this Form form)
        {
            int left = Screen.PrimaryScreen.Bounds.Left;
            int top = Screen.PrimaryScreen.Bounds.Top;
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            form.Location = new Point(left, top);
            form.Size = new Size(width, height);
        }

        static public void glSetSizeToDesktop(this Form form)
        {
            int left = SystemInformation.WorkingArea.Left;
            int top = SystemInformation.WorkingArea.Top;
            int width = SystemInformation.WorkingArea.Width;
            int height = SystemInformation.WorkingArea.Height;
            form.Location = new Point(left, top);
            form.Size = new Size(width, height);
        }

        // Qouting of strings
        static public String glQoutedstr(String str)
        {
            return "\"" + str + "\"";
        }

        static public String glQoutedSinglestr(String str)
        {
            return "'" + str + "'";
        }

        // convert blank dates to default date
        static public String glConvertBlankGender(String genderstr)
        {
            String trimmedstr = genderstr.Trim();
            if (trimmedstr == "")
                return Globals.gdefaultgender;
            else
                return trimmedstr;
        }

        // convert blank dates to default date
        static public DateTime glConvertBlankDate(String dtstr)
        {
            if (dtstr.Trim() == "")
                return Convert.ToDateTime(Globals.gdefauldate);
            else
                return Convert.ToDateTime(dtstr);
        }

        // convert a date into mysql date
        static public String glToMySqlDate(DateTime dt)
        {
            String yy, mm, dd;

            yy = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            mm = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            if (mm.Length<2) mm = "0" + mm;

            dd = DateTime.Parse(DateTime.Now.ToString()).Day.ToString();
            if (dd.Length < 2) dd = "0" + dd;

            return yy.ToString() + "/" + mm.ToString() + "/" + dd.ToString()+" 00:00:00";

        }

        // convert a date into mysql datetime
        static public String glToMySqlDateTime(DateTime dt)
        {
            String yy, mm, dd, hh, nn, ss;

            yy = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            mm = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            if (mm.Length < 2) mm = "0" + mm;

            dd = DateTime.Parse(DateTime.Now.ToString()).Day.ToString();
            if (dd.Length < 2) dd = "0" + dd;

            hh = DateTime.Parse(DateTime.Now.ToString()).Hour.ToString();
            if (hh.Length < 2) hh = "0" + hh;

            nn = DateTime.Parse(DateTime.Now.ToString()).Minute.ToString();
            if (nn.Length < 2) nn = "0" + nn;

            ss = DateTime.Parse(DateTime.Now.ToString()).Second.ToString();
            if (ss.Length < 2) ss = "0" + ss;

            return yy.ToString() + "/" + mm.ToString() + "/" + dd.ToString() + " "
                +hh.ToString()+":"+ nn.ToString()+":"+ss.ToString();

        }

        // convert a date into MSSql date
        static public String glToMSSqlDate(DateTime dt)
        {
            String yy, mm, dd;

            yy = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            mm = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            if (mm.Length < 2) mm = "0" + mm;

            dd = DateTime.Parse(DateTime.Now.ToString()).Day.ToString();
            if (dd.Length < 2) dd = "0" + dd;

            return dd.ToString() + "/" + mm.ToString() + "/" + yy.ToString() + " 00:00:00";

        }

        // convert a date into MSSql datetime
        static public String glToMSSqlDateTime(DateTime dt)
        {
            String yy, mm, dd, hh, nn, ss;

            yy = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            mm = DateTime.Parse(DateTime.Now.ToString()).Month.ToString();
            if (mm.Length < 2) mm = "0" + mm;

            dd = DateTime.Parse(DateTime.Now.ToString()).Day.ToString();
            if (dd.Length < 2) dd = "0" + dd;

            hh = DateTime.Parse(DateTime.Now.ToString()).Hour.ToString();
            if (hh.Length < 2) hh = "0" + hh;

            nn = DateTime.Parse(DateTime.Now.ToString()).Minute.ToString();
            if (nn.Length < 2) nn = "0" + nn;

            ss = DateTime.Parse(DateTime.Now.ToString()).Second.ToString();
            if (ss.Length < 2) ss = "0" + ss;

            return dd.ToString() + "/" + mm.ToString() + "/" + yy.ToString() + " "
                + hh.ToString() + ":" + nn.ToString() + ":" + ss.ToString();

        }
        public static bool gCheckUserRole(long iduser, ref String[] roles)
        {

            bool resultval = false;

            if (Globals.glOpenSqlConn())
            {
                String inRoles="", qrystr;

                // stitch all roles together;
                foreach(String r in roles )
                {
                    if (inRoles.Length == 0)
                        inRoles += Globals.glQoutedSinglestr(r.ToUpper());
                    else
                        inRoles += "," + Globals.glQoutedSinglestr(r.ToUpper()); ;
                }

               inRoles = "(" + inRoles + ")";

               qrystr = "select ur.iduser,r.name "+
                     " from dbo.userroles ur left join dbo.roles r " +
                       " on ur.idrole = r.id " +
                       " where ur.iduser = " + iduser.ToString() + " " +
                       "and UPPER(r.name) in "+inRoles;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Globals.sqlconn;
                cmd.CommandText = qrystr;
                                                                         
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) resultval = true;
                
                          
            }

            Globals.glCloseSqlConn();
            return resultval;

        }

        public static void  gstrAlignRight(ref String str, int mlength)
        {
            String bstring = "                                                " +
                             "                                                ";
            int l = str.Length;

            if (mlength > l)

                str = bstring.Substring(0, mlength - l) + str;

        }

        public static void GetUserEmail(long uid, ref String uemail,
            ref String usmtphost, ref String usmtpport)
        {
            if (Globals.glOpenSqlConn())
            {
                SqlCommand cmd = new SqlCommand("spGetUserEmail",
                    Globals.sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid",uid);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    uemail = reader["email"].ToString();
                    usmtphost = reader["smtphost"].ToString();
                    usmtpport = reader["smtpport"].ToString();
                                  

                }
                
            }
            Globals.glCloseSqlConn();

        }

        public static void glUserMustChangePwd(long uid, ref bool result)
        {
            String vread = "";
            result = true;
            if (Globals.glOpenSqlConn())
            {
                SqlCommand cmd = new SqlCommand("spUserMustChangePwd",
                    Globals.sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    vread =reader["mustchangepwd"].ToString().Trim().ToLower();
                    //csMessageBox.Show("mustchange:" + vread,
                    //    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (vread == "false") result = false;

                }

            }
            Globals.glCloseSqlConn();

        }

        public static void glRemoveMustChangePwd(long uid)
        {
            if (Globals.glOpenSqlConn())
            {
                try
                {


                    SqlCommand cmd = new SqlCommand("spRemoveMustChangePwd", Globals.sqlconn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@uid", uid);

                    
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    csMessageBox.Show("Exception Error:" + ex.Message,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            Globals.glCloseSqlConn();
        }
    }
}
