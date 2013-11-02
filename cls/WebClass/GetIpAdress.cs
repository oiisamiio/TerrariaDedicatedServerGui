using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Local.WebClass
{
    class GetIpAdress
    {

        #region Declaration
        //Declaration

        private BackgroundWorker bgwHelper = new BackgroundWorker();

        String sIPAdress = String.Empty;

        Exception exBuffer;

        #endregion

        #region Events
        //Events

        public delegate void EventHandler();

        public event EventHandler Completed;

        private void SetCompleted()
        {
            if (Completed != null)
            {
                Completed();
            }
        }

        #endregion

        #region Properties
        //Properties

        public String IPAdress
        {
            get { return sIPAdress; }
        }

        public Exception Exception
        {
            get { return exBuffer; }
        }

        #endregion

        #region Construct
        //Construct

        public GetIpAdress()
        {
            this.bgwHelper.DoWork += new DoWorkEventHandler(bgwHelper_DoWork);
            this.bgwHelper.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwHelper_RunWorkerCompleted);
        }

        #endregion

        #region Init
        //Init

        public void Init()
        {
            if (!this.bgwHelper.IsBusy)
            {
                this.bgwHelper.RunWorkerAsync();
            }
        }

        #endregion

        #region Events - Backgroundworker
        //Events - Backgroundworker

        private void bgwHelper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Completed();
        }

        #endregion

        #region Function - Retrieve - External IP Adress
        //Function - Retrieve - External IP Adress

        private void bgwHelper_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                String sExtIpAdress = String.Empty;

                using (WebClient wcGetString = new WebClient())
                {
                    Regex rexFilter = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");

                    sExtIpAdress = wcGetString.DownloadString("http://checkip.dyndns.org/");
                    sExtIpAdress = rexFilter.Matches(sExtIpAdress)[0].ToString();

                    if (!String.IsNullOrEmpty(sExtIpAdress))
                    {
                        this.sIPAdress = sExtIpAdress;
                    }
                    else
                    {
                        this.sIPAdress = "External IP Adress unknown";
                    }
                }

            }
            catch (Exception ex)
            {
                this.exBuffer = ex;
            }
        }

        #endregion

    }
}
