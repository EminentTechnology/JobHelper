using log4net;
using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace JobHelper
{
    public partial class JobRunner : Form, IAppender
    {
        private readonly string[] _args;
        private readonly Dictionary<string, JobSwitch> _switches;

        

        public JobRunner(string[] args, Dictionary<string, JobSwitch> switches)
        {
            this.InitializeComponent();
            this._args = args;
            this._switches = switches;
            base.Show();
        }

        public static void DisplayHelp(Dictionary<string, JobSwitch> switches)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine("The following are available switches:\r\n");

            foreach (KeyValuePair<string, JobSwitch> s in switches)
            {
                retVal.AppendFormat("{0} -- {1}\r\n", s.Key, s.Value.Description);
            }

            MessageBox.Show(retVal.ToString(), "Usage", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        

        public void DoAppend(LoggingEvent loggingEvent)
        {
            this.ReportProgress(string.Format("{0} - {1}: {2}", loggingEvent.TimeStamp, loggingEvent.Level.Name, loggingEvent.MessageObject.ToString()));
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.LogTextBox.Text = "";

                KeyValuePair<string, JobSwitch> s = (KeyValuePair<string, JobSwitch>)this.switchesCombo.SelectedItem;
                string command = string.Concat(s.Key, " ", this.parameters.Text);
                string[] args = new string[0];
                if (!string.IsNullOrEmpty(s.Key))
                {
                    args = command.Split(new char[] { ' ' });
                }
                JobRunner.LogInfo(string.Format("Job {0} executed with following arguments {1}", s.Value.Job, command));
                s.Value.Job.Execute(args);
            }
            catch (Exception exception)
            {
                Exception ex = exception;
                JobRunner.LogException(ex, false);
                MessageBox.Show(ex.Message);
            }
        }

        private void FillSwitchesCombo()
        {
            foreach (KeyValuePair<string, JobSwitch> s in this._switches)
            {
                this.switchesCombo.Items.Add(s);
            }
            if (this._switches.Count > 0)
            {
                this.switchesCombo.SelectedIndex = 0;
            }
        }

        

        private void JobRunner_Load(object sender, EventArgs e)
        {
            this.FillSwitchesCombo();
        }

        void log4net.Appender.IAppender.Close()
        {
            base.Close();
        }

        string log4net.Appender.IAppender.Name
        {
            get
            {
                return base.Name;
            }
            set => base.Name = value;

        }

        public static void LogDebug(string Message)
        {
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Debug(Message);
        }

        public static void LogException(Exception ex)
        {
            LogException(ex, true);
        }

        public static void LogException(Exception ex, bool rethrow)
        {
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(ex);
            if (rethrow)
            {
                throw ex;
            }
        }

        public static void LogInfo(string Message)
        {
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Info(Message);
        }

        private void ReportProgress(string message)
        {
            this.LogTextBox.AppendText(string.Concat(message, "\r\n\r\n"));
        }

        public static void RunJob(string[] args, Dictionary<string, JobSwitch> switches)
        {
            try
            {
                JobSwitch j = null;
                if ((int)args.Length > 0)
                {
                    if (!switches.TryGetValue(args[0], out j))
                    {
                        throw new ApplicationException(string.Format("Invalid job switch: {0}", args[0]));
                    }
                }
                else if (!switches.TryGetValue(string.Empty, out j))
                {
                    throw new ApplicationException(string.Format("Invalid job switch: {0}", args[0]));
                }
                if (j != null)
                {
                    j.Job.Execute(args);
                }
            }
            catch (Exception exception)
            {
                LogException(exception);
            }
        }

        public static void Init(string[] args, Dictionary<string, JobSwitch> switches)
        {
            log4net.Config.XmlConfigurator.Configure();



            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "/debug":
                        JobRunner runnerForm = new JobRunner(args, switches);
                        ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.AddAppender(runnerForm);
                        Application.Run(runnerForm);
                        break;
                    case "/?":
                    case "/help":
                    case "-help":
                    case "--help":
                    case "help":
                        JobRunner.DisplayHelp(switches);
                        break;
                    default:
                        JobRunner.RunJob(args, switches);
                        break;
                }

            }
            else
            {
                JobRunner.RunJob(args, switches);
            }
        }
    }
}
