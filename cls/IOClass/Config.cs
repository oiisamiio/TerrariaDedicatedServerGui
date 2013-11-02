using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Local.Server
{
    class SetConfig : IDisposable
    {

        #region Declaration
        //Declaration

        private bool disposed = false;

        private String sAppPath = String.Empty;

        private DataTable dtConfig = new DataTable("Config");

        private String sServerPath = String.Empty; //Specifies the configuration file to use.
        private String sConfig = "serverconfig.txt"; //Specifies the configuration file to use.
        private String sBanlist = "banlist.txt"; //Specifies the location of the banlist. Defaults to "banlist.txt" in the working directory.

        private Int32 iPort = 7777; //Specifies the port to listen on.
        private Int32 iPlayers = 8; //Sets the max number of players

        private String sPass = String.Empty; //Sets the server password

        private String sWorldpath = String.Empty;
        private String sWorld = String.Empty; //Load a world and automatically start the server.

        private Boolean bAutocreate = false; //Creates a world if none is found in the path specified by -world. World size is specified by:
        private Int32 iAutocreate = 0; //1(small), 2(medium), and 3(large).
        private String sWorldname = "World"; //Sets the name of the world when using -autocreate.

        private Boolean bAutoshutdown = false;

        private Boolean bSecure = false; //Adds addition cheat protection to the server.
        private Boolean bNoupnp = false; //Disables automatic port forwarding		

        private Int32 iLanguage = 0; //Sets the server language 1:English, 2:German, 3:Italian, 4:French, 5:Spanish

        private Int32 iNpcstream = 60; //Reduces enemy skipping but increases bandwidth usage. The lower the number the less skipping will happen, but more data is sent. 0 is off.
        private Int32 iPriority = 1; //Default system priority 0:Realtime, 1:High, 2:AboveNormal, 3:Normal, 4:BelowNormal, 5:Idle

        private String sMotd = "Please dont cut the purple trees!";

        private bool bError = false;

        #endregion

        #region Properties
        //Properties

        public String AppPath
        {
            get { return this.sAppPath; }
            set { this.sAppPath = value; }
        }

        public String ServerPath
        {
            get { return this.sServerPath; }
            set { this.sServerPath = value; }
        }

        public String Config
        {
            get { return this.sConfig; }
            set { this.sConfig = value; }
        }

        public String BanList
        {
            get { return this.sBanlist; }
            set { this.sBanlist = value; }
        }

        public Int32 Port
        {
            get { return this.iPort; }
            set { this.iPort = value; }
        }

        public Int32 Players
        {
            get { return this.iPlayers; }
            set { this.iPlayers = value; }
        }

        public String Password
        {
            get { return this.sPass; }
            set { this.sPass = value; }
        }

        public String WorldPath
        {
            get { return this.sWorldpath; }
            set { this.sWorldpath = value; }
        }

        public String World
        {
            get { return this.sWorld; }
            set { this.sWorld = value; }
        }

        public Boolean AutoCreate
        {
            get { return this.bAutocreate; }
            set { this.bAutocreate = value; }
        }

        public Int32 AutoCreateValue
        {
            get { return this.iAutocreate; }
            set { this.iAutocreate = value; }
        }

        public String AutoCreateName
        {
            get { return this.sWorldname; }
            set { this.sWorldname = value; }
        }

        public Boolean AutoShutdown
        {
            get { return this.bAutoshutdown; }
            set { this.bAutoshutdown = value; }
        }

        public Boolean Secure
        {
            get { return this.bSecure; }
            set { this.bSecure = value; }
        }

        public Boolean NoUPNP
        {
            get { return this.bNoupnp; }
            set { this.bNoupnp = value; }
        }

        public Int32 Language
        {
            get { return this.iLanguage; }
            set { this.iLanguage = value; }
        }

        public Int32 Priority
        {
            get { return this.iPriority; }
            set { this.iPriority = value; }
        }

        public Int32 NpcStream
        {
            get { return this.iNpcstream; }
            set { this.iNpcstream = value; }
        }

        public Boolean Error
        { //Error
            get { return this.bError; }
            set { this.bError = value; }
        }

        #endregion

        #region Construct
        //Construct

        public SetConfig()
        {

        }

        #endregion

        #region Init
        //Init

        public bool Init(string AppPath)
        {
            this.sAppPath = AppPath + "\\";
            this.SetTable();

            this.ReadConfig();

            return this.bError;
        }

        #endregion

        #region Set Table Schema
        //Set Table Schema

        private void SetTable()
        {
            dtConfig.Columns.Add("Name", typeof(String));
            dtConfig.Columns.Add("Value", typeof(String));
        }

        #endregion

        #region Read Config
        //Read Config

        public bool ReadConfig()
        {
            try
            {
                if (!File.Exists(this.sAppPath + "config.xml"))
                {
                    this.LoadFailSafe();
                }
                else
                {
                    this.dtConfig.ReadXml(this.sAppPath + "config.xml");
                }

                if (this.dtConfig.Rows.Count == 0)
                {
                    this.LoadFailSafe();
                }

                //check async datarows
                Parallel.ForEach(this.dtConfig.AsEnumerable(), dr =>
                {
                    switch (dr[0].ToString())
                    {
                        case "serverpath":
                            this.sServerPath = Convert.ToString(dr[1]);
                            break;
                        case "config":
                            this.sConfig = Convert.ToString(dr[1]);
                            break;
                        case "banlist":
                            this.sBanlist = Convert.ToString(dr[1]);
                            break;
                        case "port":
                            this.iPort = Convert.ToInt32(dr[1]);
                            break;
                        case "players":
                            this.iPlayers = Convert.ToInt32(dr[1]);
                            break;
                        case "pass":
                            this.sPass = Convert.ToString(dr[1]);
                            break;
                        case "worldpath":
                            this.sWorldpath = Convert.ToString(dr[1]);
                            break;
                        case "world":
                            this.sWorld = Convert.ToString(dr[1]);
                            break;
                        case "autocreateon":
                            this.bAutocreate = Convert.ToBoolean(dr[1]);
                            break;
                        case "autocreate":
                            this.iAutocreate = Convert.ToInt32(dr[1]);
                            break;
                        case "worldname":
                            this.sWorldname = Convert.ToString(dr[1]);
                            break;
                        case "lang":
                            this.iLanguage = Convert.ToInt32(dr[1]);
                            break;
                        case "autoshutdown":
                            this.bAutoshutdown = Convert.ToBoolean(dr[1]);
                            break;
                        case "secure":
                            this.bSecure = Convert.ToBoolean(dr[1]);
                            break;
                        case "noupnp":
                            this.bNoupnp = Convert.ToBoolean(dr[1]);
                            break;
                        case "priority":
                            this.iPriority = Convert.ToInt32(dr[1]);
                            break;
                        case "npcstream":
                            this.iNpcstream = Convert.ToInt32(dr[1]);
                            break;
                        case "motd":
                            this.sMotd = Convert.ToString(dr[1]);
                            break;
                        default:
                            break;
                    }
                }
                );
            }
            catch (InvalidCastException ex)
            {
                this.CatchException(ex);
            }
            catch (IOException ex)
            {
                this.CatchException(ex);
            }
            catch (Exception ex)
            {
                this.CatchException(ex);
            }

            return this.bError;
        }

        #endregion

        #region Write Config
        //Write Config

        public bool WriteConfig()
        {
            try
            {
                if (this.dtConfig.Rows.Count == 0)
                {
                    this.LoadFailSafe();
                    throw new InvalidCastException("write config row count is null");
                }

                //setup option for each row
                foreach (DataRow dr in this.dtConfig.Rows)
                {
                    switch (dr[0].ToString())
                    {
                        case "serverpath":
                            dr[1] = this.sServerPath;
                            break;
                        case "config":
                            dr[1] = this.sConfig;
                            break;
                        case "banlist":
                            dr[1] = this.sBanlist;
                            break;
                        case "port":
                            dr[1] = this.iPort;
                            break;
                        case "players":
                            dr[1] = this.iPlayers;
                            break;
                        case "pass":
                            dr[1] = this.sPass;
                            break;
                        case "worldpath":
                            dr[1] = this.sWorldpath;
                            break;
                        case "world":
                            dr[1] = this.sWorld;
                            break;
                        case "autocreateon":
                            dr[1] = this.bAutocreate;
                            break;
                        case "autocreate":
                            dr[1] = this.iAutocreate;
                            break;
                        case "worldname":
                            dr[1] = this.sWorldname;
                            break;
                        case "lang":
                            dr[1] = this.iLanguage;
                            break;
                        case "autoshutdown":
                            dr[1] = this.bAutoshutdown;
                            break;
                        case "secure":
                            dr[1] = this.bSecure;
                            break;
                        case "noupnp":
                            dr[1] = this.bNoupnp;
                            break;
                        case "priority":
                            dr[1] = this.iPriority;
                            break;
                        case "npcstream":
                            dr[1] = this.iNpcstream;
                            break;
                        case "motd":
                            dr[1] = this.sMotd;
                            break;
                        default:
                            break;
                    }
                }

                this.dtConfig.WriteXml(this.AppPath + "config.xml", XmlWriteMode.WriteSchema, false);
            }
            catch (InvalidCastException ex)
            {
                this.CatchException(ex);
            }
            catch (Exception ex)
            {
                this.CatchException(ex);
            }

            return this.bError;
        }

        #endregion

        #region Load Fail Safe Data
        //Load Fail Safe Data

        private void LoadFailSafe()
        {
            this.bError = false;
            dtConfig.Rows.Add("serverpath", this.sServerPath);
            dtConfig.Rows.Add("config", this.sConfig);
            dtConfig.Rows.Add("banlist", this.sBanlist);
            dtConfig.Rows.Add("port", this.iPort);
            dtConfig.Rows.Add("players", this.iPlayers);
            dtConfig.Rows.Add("pass", this.sPass);
            dtConfig.Rows.Add("worldpath", this.sWorldpath);
            dtConfig.Rows.Add("world", this.sWorld);
            dtConfig.Rows.Add("autocreateon", this.bAutocreate);
            dtConfig.Rows.Add("autocreate", this.iAutocreate);
            dtConfig.Rows.Add("lang", this.iLanguage);
            dtConfig.Rows.Add("autoshutdown", this.bAutoshutdown);
            dtConfig.Rows.Add("worldname", this.sWorldname);
            dtConfig.Rows.Add("secure", this.bSecure);
            dtConfig.Rows.Add("noupnp", this.bNoupnp);
            dtConfig.Rows.Add("priority", this.iPriority);
            dtConfig.Rows.Add("npcstream", this.iNpcstream);
            dtConfig.Rows.Add("motd", this.sMotd);
        }

        #endregion

        #region Catch Exception
        //Catch Exception

        private void CatchException(Exception ex)
        {

            MessageBox.Show("Config File corrupt? Load Default values...\n" + ex.Message, "Corrupt Config File", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.bError = true;
        }

        #endregion

        #region implement idisposable
        // implement idisposable

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).

                }
                // Release unmanaged resources.
                // Set large fields to null.
                // Call Dispose on your base class.

                this.dtConfig.Dispose();

                disposed = true;
            }
        }

        #endregion

    }
}
