using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace Local.Server
{
    class Controller : IDisposable
    {

        #region Declaration
        //Declaration

        private Boolean disposed = false;
        private Boolean bExitForced = false;

        private Boolean bLockVersion = false;
        private String sVersion = String.Empty;

        private Boolean bAllowAdmin = false;
        private String sAdmin = String.Empty;

        private Boolean bLockTime = false;
        private Boolean bLockMotd = false;
        private Boolean bLockPlaying = false;

        private Boolean bAllowUserTime = false;

        private Int64 iCount = 0;

        private Process pController;

        private String sFileName = String.Empty;
        private StringBuilder sbArguments = new StringBuilder();

        private String sBufferOut = String.Empty;
        private String sBufferOutLower = String.Empty;

        private Int32 iPlayer = 0;

        private Boolean bRunning = false;

        private BackgroundWorker bwHelper = new BackgroundWorker();

        #endregion

        #region Properties
        //Properties

        public String FileName
        {//FileName
            set { this.sFileName = value + "\\TerrariaServer.exe"; }
        }

        public String Arguments
        {//Arguments
            set { this.sbArguments.AppendLine(value); }
        }

        public String Command
        {//Command
            set
            {
                if (this.pController != null && this.bRunning)
                {
                    this.pController.StandardInput.WriteLine(value);
                }
            }
        }

        public Boolean AllowAdmin
        {//Allow Admin (required for Admin Chat Message)
            set { this.bAllowAdmin = value; }
        }

        public String Admin
        {//Admin Name (required for Admin Chat Message)
            set { this.sAdmin = value; }
        }

        public Boolean AllowUserTime
        {//Allow User to change Time
            set { this.bAllowUserTime = value; }
        }

        public Int32 Player
        {//Player
            get { return this.iPlayer; }
        }

        public String Buffer
        {//Buffer
            get { return this.sBufferOut; }
        }

        public Boolean IsBusy
        {//IsBusy
            get { return this.bwHelper.IsBusy; }
        }

        public Boolean Running
        {//Running
            get { return this.bRunning; }
        }

        #endregion

        #region Add Events
        //Add Events

        public delegate void EventHandler();

        //Helper
        public event EventHandler ProgressChanged;
        public event EventHandler Completed;

        #endregion

        #region Event Handler
        //Event Handler

        private void SetProgressChanged()
        {
            if (ProgressChanged != null && !this.bExitForced)
            {
                ProgressChanged();
            }
        }

        private void SetCompleted()
        {
            if (Completed != null && !this.bExitForced)
            {
                Completed();
            }
        }

        #endregion

        #region Events BackgroundWorker
        //Events BackgroundWorker

        private void bwHelper_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DoJob();
        }

        private void bwHelper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetCompleted(); //report ui new data avaible
        }

        #endregion

        #region Construct
        //Construct

        public Controller()
        {
            this.bwHelper.WorkerReportsProgress = true;

            this.bwHelper.DoWork += new DoWorkEventHandler(bwHelper_DoWork);
            this.bwHelper.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwHelper_RunWorkerCompleted);
        }

        #endregion

        #region Init
        //Init

        public void Init()
        {

        }

        #endregion

        #region DoJobAsync
        //DoJobAsync

        public void DoJobAsync()
        {
            if (!this.bwHelper.IsBusy)
            {
                this.bwHelper.RunWorkerAsync();
            }
        }

        #endregion

        #region DoJob
        //DoJob

        private void DoJob()
        {
            this.ProcessController();
        }

        #endregion

        #region Process - Controller
        //Process - Controller

        private void ProcessController()
        {
            using (this.pController = new Process())
            {
                this.pController.StartInfo.UseShellExecute = false;
                this.pController.StartInfo.RedirectStandardError = true;
                this.pController.StartInfo.RedirectStandardOutput = true;
                this.pController.StartInfo.RedirectStandardInput = true;
                this.pController.StartInfo.CreateNoWindow = true;
                this.pController.EnableRaisingEvents = true;

                this.pController.StartInfo.FileName = this.sFileName;
                this.pController.StartInfo.Arguments = this.sbArguments.ToString().Replace("\r", "").Replace("\n", " ");

                this.pController.OutputDataReceived += pController_OutputDataReceived;
                this.pController.ErrorDataReceived += pController_ErrorDataReceived;

                this.pController.Exited += new System.EventHandler(pController_Exited);

                this.pController.Start();

                this.bRunning = true;

                this.pController.BeginErrorReadLine();
                this.pController.BeginOutputReadLine();

                this.pController.WaitForExit();
            }
        }

        #endregion

        #region Process - Error Receiver
        //Process - Error Receiver

        private void pController_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.sBufferOut = (String.Format("ERROR: {0}", e.Data));
                this.SetProgressChanged();
            }
        }

        #endregion

        #region Process - Data Receiver
        //Process - Data Receiver

        private void pController_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.iCount += 1; //raise received Messages Count +1

            if (e.Data != null)
            {
                this.sBufferOut = e.Data;
                this.sBufferOutLower = e.Data.ToLower();

                if (this.iCount <= 5 && !this.bLockVersion) //workarround get Terraria Server vx.x.x
                {
                    if (this.sBufferOutLower.Contains("terraria server v"))
                    {
                        this.sVersion = sBufferOut;
                        this.bLockVersion = true;
                    }
                }
                else
                {
                    this.sBufferOut = this.sBufferOut.Replace(this.sVersion, "");
                }

                if (this.sBufferOutLower.Contains("has joined"))
                {
                    iPlayer += 1;
                }

                if (this.sBufferOutLower.Contains("has left"))
                {
                    iPlayer -= 1;
                }

                //dirty! User could type Chat Message: blah <ADMINNAME> SERVER COMMAND
                //ToDo: fix it
                if (this.bAllowAdmin && this.sBufferOut.Contains("<" + this.sAdmin + "> "))
                {
                    this.pController.StandardInput.WriteLine(this.sBufferOut.Replace("<" + this.sAdmin + "> ", "").Replace(": ", ""));
                }
                else
                {
                    if (this.bLockTime && this.sBufferOutLower.Contains("time") && !this.sBufferOut.Contains("<Server>"))
                    {//Server send back Chat Message: time (Step 2)
                        this.bLockTime = false;
                        this.pController.StandardInput.WriteLine("say " + this.sBufferOut);
                    }

                    if (this.sBufferOutLower.Contains("> time") && !this.sBufferOut.Contains("<Server>"))
                    {//User send Chat Message: time (Step 1)
                        this.bLockTime = true;
                        this.pController.StandardInput.WriteLine("time");
                    }

                    if (this.bLockMotd && this.sBufferOutLower.Contains("motd") && !this.sBufferOut.Contains("<Server>"))
                    {//Server send back Chat Message: motd (Step 2)
                        this.bLockMotd = false;
                        this.pController.StandardInput.WriteLine("say " + this.sBufferOut);
                    }

                    if ((this.sBufferOutLower.Contains("> motd") || this.sBufferOutLower.Contains("help")) && !this.sBufferOut.Contains("<Server>"))
                    {//User send Chat Message: motd (Step 1)
                        this.bLockMotd = true;
                        this.pController.StandardInput.WriteLine("motd");
                    }

                    if (this.bLockPlaying && this.sBufferOutLower.Contains("(") && this.sBufferOutLower.Contains(")") && !this.sBufferOut.Contains("<Server>"))
                    {//Server send back Chat Message: playing (Step 2)
                        this.bLockPlaying = false;
                        this.pController.StandardInput.WriteLine("say " + this.sBufferOut);
                    }

                    if (this.sBufferOutLower.Contains("> playing") && !this.sBufferOut.Contains("<Server>"))
                    {//User send Chat Message: playing (Step 1)
                        this.bLockPlaying = true;
                        this.pController.StandardInput.WriteLine("playing");
                    }

                    if (this.bAllowUserTime)
                    {//dawn, noon, dusk or midnight
                        if (this.sBufferOutLower.Contains("> dawn"))
                        {
                            this.pController.StandardInput.WriteLine("dawn");
                        }

                        if (this.sBufferOutLower.Contains("> noon"))
                        {
                            this.pController.StandardInput.WriteLine("noon");
                        }

                        if (this.sBufferOutLower.Contains("> dusk"))
                        {
                            this.pController.StandardInput.WriteLine("dusk");
                        }

                        if (this.sBufferOutLower.Contains("> midnight"))
                        {
                            this.pController.StandardInput.WriteLine("midnight");
                        }
                    }
                }

                this.SetProgressChanged();
            }
        }

        #endregion

        #region Process - Exited
        //Process - Exited

        private void pController_Exited(object sender, EventArgs e)
        {
            this.sbArguments.Clear();
            this.iPlayer = 0;
            this.bRunning = false;
        }

        #endregion

        #region Process - Request - Exit
        //Process - Request - Exit

        public void RequestExit()
        {

            if (this.bRunning)
            {
                this.Command = "1";

                Thread.Sleep(100);

                for (int i = 0; i < 5; i++)
                {
                    this.Command = "";
                    Thread.Sleep(100);
                }

                this.Command = "exit-nosave";
            }
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

                this.pController.Dispose();

                disposed = true;
            }
        }

        #endregion

    }
}
