﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.IO;

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

        private Byte iForceTime = 0;

        private System.Timers.Timer tForceTime = new System.Timers.Timer(); //Night 9m Realtime = 9h Gametime / Day 15m Realtime = 15 Gametime

        private Int64 iCount = 0;

        private Process pController;
        private Int32 iPriority = 1;

        private String sWorkingPath = String.Empty;
        private String sFileName = String.Empty;
        private StringBuilder sbArguments = new StringBuilder();

        private String sBufferOut = String.Empty;
        private String sBufferOutLower = String.Empty;

        private Int32 iPlayer = 0;

        private Boolean bRunning = false;

        private BackgroundWorker bwHelper = new BackgroundWorker();

        StreamWriter InputStream = null;

        #endregion

        #region Properties
        //Properties

        public String WorkingPath
        {//FileName
            set { this.sWorkingPath = value; }
        }

        public String FileName
        {//FileName
            set { this.sFileName = this.sWorkingPath + value; }
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
                    InputStream.WriteLine(value);
                    InputStream.Flush();
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

        public Int32 Priority
        {
            set { this.iPriority = value; }
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
            this.tForceTime.Interval = 4 * 60 * 1000;
            this.tForceTime.AutoReset = true;
            this.tForceTime.Enabled = true;
            this.tForceTime.Elapsed += new System.Timers.ElapsedEventHandler(tForceTime_Elapsed);
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

                ProcessPriorityClass ppcController;

                switch (this.iPriority)
                {
                    case 0:
                        ppcController = ProcessPriorityClass.RealTime;
                        break;
                    case 1:
                        ppcController = ProcessPriorityClass.High;
                        break;
                    case 2:
                        ppcController = ProcessPriorityClass.AboveNormal;
                        break;
                    case 3:
                        ppcController = ProcessPriorityClass.Normal;
                        break;
                    case 4:
                        ppcController = ProcessPriorityClass.BelowNormal;
                        break;
                    case 5:
                        ppcController = ProcessPriorityClass.Idle;
                        break;
                    default:
                        ppcController = ProcessPriorityClass.Normal;
                        break;
                }

                this.pController.StartInfo.FileName = this.sFileName;
                this.pController.StartInfo.Arguments = this.sbArguments.ToString().Replace("\r", "").Replace("\n", " ");
                this.pController.StartInfo.WorkingDirectory = this.sWorkingPath;

                this.pController.OutputDataReceived += pController_OutputDataReceived;
                this.pController.ErrorDataReceived += pController_ErrorDataReceived;

                this.pController.Exited += new System.EventHandler(pController_Exited);

                this.pController.Start();

                this.pController.PriorityClass = ppcController;

                this.bRunning = true;

                this.pController.BeginErrorReadLine();
                this.pController.BeginOutputReadLine();

                this.InputStream = new StreamWriter(this.pController.StandardInput.BaseStream, Encoding.Unicode);

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

                if (this.iCount <= 30 && !this.bLockVersion) //workarround get Terraria Server vx.x.x
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
                if (this.bAllowAdmin && this.sBufferOut.Contains("<" + this.sAdmin + "> /"))
                {
                    String sBufferLocal = Regex.Replace(this.sBufferOut, "\\s+", "");

                    sBufferLocal = Regex.Replace(sBufferLocal, "<" + this.sAdmin + ">", "");
                    sBufferLocal = Regex.Replace(sBufferLocal, ":", "");
                    sBufferLocal = Regex.Replace(sBufferLocal, "/", "");

                    this.pController.StandardInput.WriteLine(sBufferLocal);
                }
                else
                {
                    if (this.bLockTime && this.sBufferOutLower.Contains("time") && !this.sBufferOut.Contains("Server"))
                    {//Server send back Chat Message: time (Step 2)
                        this.bLockTime = false;
                        this.pController.StandardInput.WriteLine("say Game " + this.sBufferOut + " - Server Time: " + DateTime.Now.ToShortTimeString());
                    }

                    if (this.sBufferOutLower.Contains("> time") && !this.sBufferOut.Contains("Server"))
                    {//User send Chat Message: time (Step 1)
                        this.bLockTime = true;
                        this.pController.StandardInput.WriteLine("time");
                    }

                    if (this.bLockMotd && this.sBufferOutLower.Contains("motd") && !this.sBufferOut.Contains("Server"))
                    {//Server send back Chat Message: motd (Step 2)
                        this.bLockMotd = false;
                        this.pController.StandardInput.WriteLine("say " + this.sBufferOut);
                    }

                    if ((this.sBufferOutLower.Contains("> motd") || this.sBufferOutLower.Contains("help")) && !this.sBufferOut.Contains("Server") && !this.sBufferOutLower.Contains("type /"))
                    {//User send Chat Message: motd (Step 1)
                        this.bLockMotd = true;
                        this.pController.StandardInput.WriteLine("motd");
                    }

                    if (this.bLockPlaying && this.sBufferOutLower.Contains("(") && this.sBufferOutLower.Contains(")") && !this.sBufferOut.Contains("Server"))
                    {//Server send back Chat Message: playing (Step 2)
                        this.bLockPlaying = false;
                        this.pController.StandardInput.WriteLine("say " + this.sBufferOut);
                    }

                    if (this.sBufferOutLower.Contains("> playing") && !this.sBufferOut.Contains("Server"))
                    {//User send Chat Message: playing (Step 1)
                        this.bLockPlaying = true;
                        this.pController.StandardInput.WriteLine("playing");
                    }

                    if (this.bAllowUserTime || (this.bAllowAdmin && this.sBufferOut.Contains("<" + this.sAdmin + ">")))
                    {//dawn, noon, dusk or midnight
                        if (this.sBufferOutLower.Contains("> dawn"))
                        {
                            this.pController.StandardInput.WriteLine("dawn");
                            this.pController.StandardInput.WriteLine("say time set to dawn");
                        }

                        if (this.sBufferOutLower.Contains("> noon"))
                        {
                            this.pController.StandardInput.WriteLine("noon");
                            this.pController.StandardInput.WriteLine("say time set to noon");
                        }

                        if (this.sBufferOutLower.Contains("> dusk"))
                        {
                            this.pController.StandardInput.WriteLine("dusk");
                            this.pController.StandardInput.WriteLine("say time set to dusk");
                        }

                        if (this.sBufferOutLower.Contains("> midnight"))
                        {
                            this.pController.StandardInput.WriteLine("midnight");
                            this.pController.StandardInput.WriteLine("say time set to midnight");
                        }

                        if (this.sBufferOutLower.Contains("> forcedawn"))
                        {
                            this.pController.StandardInput.WriteLine("dawn");
                            this.iForceTime = 1;
                            this.tForceTime.Interval = 7 * 60 * 1000;
                            this.tForceTime.Start();
                            this.pController.StandardInput.WriteLine("say time forced to dawn (use resetforce for reset)");
                        }

                        if (this.sBufferOutLower.Contains("> forcenoon"))
                        {
                            this.pController.StandardInput.WriteLine("noon");
                            this.iForceTime = 2;
                            this.tForceTime.Interval = 7 * 60 * 1000;
                            this.tForceTime.Start();
                            this.pController.StandardInput.WriteLine("say time forced to noon (use resetforce for reset)");
                        }

                        if (this.sBufferOutLower.Contains("> forcedusk"))
                        {
                            this.pController.StandardInput.WriteLine("dusk");
                            this.iForceTime = 3;
                            this.tForceTime.Interval = 4 * 60 * 1000;
                            this.tForceTime.Start();
                            this.pController.StandardInput.WriteLine("say time forced to dusk (use resetforce for reset)");
                        }

                        if (this.sBufferOutLower.Contains("> forcemidnight"))
                        {
                            this.pController.StandardInput.WriteLine("midnight");
                            this.iForceTime = 4;
                            this.tForceTime.Interval = 4 * 60 * 1000;
                            this.tForceTime.Start();
                            this.pController.StandardInput.WriteLine("say time forced to midnight (use resetforce for reset)");
                        }

                        if (this.sBufferOutLower.Contains("> resetforce"))
                        {
                            this.iForceTime = 0;
                            this.tForceTime.Stop();
                            this.pController.StandardInput.WriteLine("say time force reseted");
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

        #region Timer Elapsed
        //Timer Elapsed

        private void tForceTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            switch (this.iForceTime)
            {
                case 1:
                    this.pController.StandardInput.WriteLine("dawn");
                    this.pController.StandardInput.WriteLine("say time forced to dawn (use resetforce for reset)");
                    break;
                case 2:
                    this.pController.StandardInput.WriteLine("noon");
                    this.pController.StandardInput.WriteLine("say time forced to noon (use resetforce for reset)");
                    break;
                case 3:
                    this.pController.StandardInput.WriteLine("dusk");
                    this.pController.StandardInput.WriteLine("say time forced to dusk (use resetforce for reset)");
                    break;
                case 4:
                    this.pController.StandardInput.WriteLine("midnight");
                    this.pController.StandardInput.WriteLine("say time forced to midnight (use resetforce for reset)");
                    break;
                default:
                    this.tForceTime.Stop();
                    break;
            }
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
                this.InputStream.Dispose();

                disposed = true;
            }
        }

        #endregion

    }
}
