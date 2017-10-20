/**************************************************************************
 **                                                                       *
 ** Copyright 2017 by Avalara, Inc.                                       *
 **   All Rights Reserved. No part of this publication may be reproduced, *
 **   stored in a retrieval system, or transmitted, in any form, by any   *
 **   means, without the prior written permission of the publisher.       *
 **                                                                       *
 **************************************************************************

Description
    UI for Rest Demo Application


 UPDATE HISTORY:
    Ryan Robinson   12/07/2016   Created
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Avalara.TestCommon.Benchmark;
using Newtonsoft.Json;
using System.IO;
using Avalara.TestCommon.APIObjects;
using Avalara.TestCommon.DataSetup;
using System.Configuration;
using Avalara.TestCommon.Common;
using System.Drawing;
using Telerik.WinControls;
using System.Timers;
using System.Threading;
using Avalara.TestCommon.ServerSetup;
using Telerik.Charting;
using System.Reflection;
using System.Diagnostics;

namespace Avalara.RestDemoApplication
{
    public partial class TestingWindow : Form
    {
        InputHandler inputHdlr = new InputHandler();
        string DefaultWorkingDirectory = string.Empty;
        public static TestingWindow TWinHdl = null;
        private static Thread benchmarkProcess;
        private DateTime benchmarkStartTime;
        public System.Threading.Timer DemoTimer;
        public static bool CancelBenchmark;
        public static bool FinishedBenchmark;
        public static bool AbortBenchmark;
        public int MaxTimedTestMins = 5;     // 5 minutes
        public int MaxCountThousands = 100;  // 100,000 count
        public bool DisplayAdvancedTab = false;
        public bool DisplayClock = false;
        public bool DisplayCPUs = false;
        public bool DisplayThroughput = false;
        public bool DisableGraph = false;
        internal DemoStatus DStatus = null;
        public bool StopTimerFlag = false;
        public enum TestTypes
        {
            TIMED_TEST,
            COUNT_TEST,
            FILE_TEST
        }

        // Constants
        public const int MAX_DATA_POINTS = 1000;
        public const int DEFAULT_TIMER_INTERVAL_MILLISECONDS = 1000;
        public const int TIMER_DUETIME_MILLISECONDS = 1000;
        public const int LARGEST_TICK_STEP = 100;
        public class DemoStatus
        {

            //Retrieved from benchmark
            public TimeSpan DemoTimeSpan;   // Total time span of all API calls
            public int DemoAPICalls;        // Count of API calls
            public List<double> AvgSecsPerCall;
            public int DataPointSpan;      // Number of calls to summarize to remain within MaxDataPoints limit

            //Passed into benchmark
            public TestTypes TestType;
            public int TimedTestSeconds;
            public DateTime DemoEndTime;
            public DateTime DemoStartTime;
            public int CountTestNumber;
            public int FileTestTransactions;
            public int MaxValue;
            public TestingWindow TestWin;

            internal int SmallTick = -1;
            internal int LargeTick = -1;

            public int TimerIntervalMilliseconds;
            private readonly object _threadLock = new object();

            public ChartData DemoChart = null;

            public int GetTransactionCount()
            {
                int tcnt = 0;
                switch (TestType)
                {
                    case TestTypes.COUNT_TEST:
                        tcnt = CountTestNumber;
                        break;
                    case TestTypes.TIMED_TEST:
                        tcnt = TimedTestSeconds;
                        break;
                    case TestTypes.FILE_TEST:
                        tcnt = FileTestTransactions;
                        break;
                }

                return tcnt;
            }

            public void ResetTicks()
            {
                SmallTick = -1;
                LargeTick = -1;
            }

            public void SetTicks(int threads, int idx)
            {
                if (LargeTick < LARGEST_TICK_STEP)
                {
                    int tick = 0;
                    if (idx > 25000) tick = LARGEST_TICK_STEP;
                    else if (idx > 10000) tick = 50;
                    else if (idx > 2500) tick = 25;
                    else if (idx > 1000) tick = 10;
                    else if (idx > 500) tick = 8;
                    else if (idx > 250) tick = 5;
                    else if (idx > 100) tick = 4;
                    else tick = 2;

                    LargeTick = tick + (int)(tick * ((double)threads / 4.0));
                    SmallTick = (int)((double)LargeTick / 4.0) + 1;
                }
            }

            public bool TestSmallTick(int idx)
            {
                return (idx % SmallTick == 0);
            }

            public bool TestLargeTick(int idx)
            {
                return (idx % LargeTick == 0);
            }

            public DemoStatus(TestTypes tt, int val)
            {
                ResetTicks();
                DemoTimeSpan = new TimeSpan();
                TestWin = TWinHdl;
                TestType = tt;
                MaxValue = val;
                TimerIntervalMilliseconds = DEFAULT_TIMER_INTERVAL_MILLISECONDS;

                switch (tt)
                {
                    case TestTypes.COUNT_TEST:
                        CountTestNumber = MaxValue;
                        break;
                    case TestTypes.TIMED_TEST:
                        TimedTestSeconds = MaxValue;
                        break;
                    case TestTypes.FILE_TEST:
                        FileTestTransactions = MaxValue;
                        break;
                }
            }

            public void StartTimer(int intervalMilliseconds)
            {
                DemoStartTime = DateTime.UtcNow;
                TestWin.StopTimerFlag = false;
                if ((TestType == TestTypes.TIMED_TEST) && (TimedTestSeconds > 0))
                {
                    DemoEndTime = DemoStartTime.AddSeconds(TimedTestSeconds);
                }
                if (intervalMilliseconds > 0) TimerIntervalMilliseconds = intervalMilliseconds;
                TestWin.DemoTimer = new System.Threading.Timer(OnTimedEvent, null, TIMER_DUETIME_MILLISECONDS, TimerIntervalMilliseconds);
            }

            public void StopTimer()
            {
                TestWin.StopTimerFlag = true;  // Disable timed event processing (OnTimedEvent) before disposing timer
                try
                {
                    if (TestWin.DemoTimer != null)
                    {
                        TestWin.DemoTimer.Dispose();
                        TestWin.DemoTimer = null;
                    }
                }
                catch (Exception ex)
                {
                    TestWin.DemoTimer = null;
                }
            }

            public void EndTimedDemo()
            {
                FinishedBenchmark = true;
                TestWin.DStatus = null;
                StopTimer();
            }

            public void OnTimedEvent(object source)
            {
                if (!TestWin.StopTimerFlag)
                {
                    if (TestWin.DemoTimer == null)
                    {
                        EndTimedDemo();
                        Console.WriteLine("Timer killed before its time ...");
                    }
                    else
                    {
                        // Specify what you want to happen when the Elapsed event is raised.
                        TimeSpan realTimeSpan = DateTime.UtcNow - DemoStartTime;
                        if (TestType == TestTypes.TIMED_TEST)
                        {
                            TestWin.SetBenchmarkProgressBar((int)realTimeSpan.TotalSeconds);
                        }
                        TestWin.UpdateElapsedTime(realTimeSpan);

                        if ((TestType == TestTypes.TIMED_TEST) && (DateTime.UtcNow > DemoEndTime))
                        {
                            EndTimedDemo();
                        }
                    }
                }
            }

        }

        public TestingWindow()
        {
            InitializeComponent();
            TWinHdl = this;
            string buff = ConfigurationManager.AppSettings["DefaultWorkingDir"];
            if (!string.IsNullOrEmpty(buff))
            {
                DefaultWorkingDirectory = buff;
            }

            UsernameTB.Text = ConfigurationManager.AppSettings["DefaultUsername"];
            PasswordTB.Text = ConfigurationManager.AppSettings["DefaultPassword"];
            ClientIdTB.Text = ConfigurationManager.AppSettings["ClientId"];
            ClientProfileIdTB.Text = ConfigurationManager.AppSettings["ClientProfileId"];
            UrlLabel.Text = ConfigurationManager.AppSettings["DefaultUrl"];
            AvailableCPUsTB.Text = Environment.ProcessorCount.ToString();
            ThreadTrackBar.Value = Environment.ProcessorCount;

            TestCountTB.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            BenchmarkProgressBar.ProgressBarElement.IndicatorElement1.BackColor = Color.FromArgb(255, 100, 0);
            BenchmarkProgressBar.ProgressBarElement.IndicatorElement1.BackColor2 = Color.FromArgb(255, 128, 0);
            BenchmarkProgressBar.ProgressBarElement.IndicatorElement1.BackColor3 = Color.FromArgb(51, 153, 255);
            BenchmarkProgressBar.ProgressBarElement.IndicatorElement1.BackColor4 = Color.FromArgb(0, 0, 255);
            BenchmarkProgressBar.ProgressBarElement.ShowProgressIndicators = true;

            ChartData chart = new ChartData(DemoChartView, this);
            ChartData.SetChartConfiguration(
               ConfigurationManager.AppSettings["MinChartXValue"],
               ConfigurationManager.AppSettings["MaxChartXValue"],
               ConfigurationManager.AppSettings["TossOutlierFlag"],
               ConfigurationManager.AppSettings["OutlierUpperBound"],
               ConfigurationManager.AppSettings["OutlierLowerBound"]
               );

            buff = ConfigurationManager.AppSettings["DisplayAdvancedTab"];
            if (!string.IsNullOrEmpty(buff)) bool.TryParse(buff, out DisplayAdvancedTab);
            if (!DisplayAdvancedTab)
            {
                DemoTabControl.TabPages.Remove(AdvancedSettingsTab);
            }

            buff = ConfigurationManager.AppSettings["DisplayClock"];
            if (!string.IsNullOrEmpty(buff)) bool.TryParse(buff, out DisplayClock);
            DemoClock.Visible = DisplayClock;

            buff = ConfigurationManager.AppSettings["DisplayCPUs"];
            if (!string.IsNullOrEmpty(buff)) bool.TryParse(buff, out DisplayCPUs);
            AvailableCPUsLB.Visible = DisplayCPUs;
            AvailableCPUsTB.Visible = DisplayCPUs;

            buff = ConfigurationManager.AppSettings["DisplayThroughput"];
            if (!string.IsNullOrEmpty(buff)) bool.TryParse(buff, out DisplayThroughput);
            ThroughputLB.Visible = DisplayThroughput;
            ThroughputTB.Visible = DisplayThroughput;

            buff = ConfigurationManager.AppSettings["DisableGraph"];
            if (!string.IsNullOrEmpty(buff)) bool.TryParse(buff, out DisableGraph);
            DisabledLB.Visible = DisableGraph;

            buff = ConfigurationManager.AppSettings["MaxThreads"];
            ThreadTrackBar.Minimum = 1;
            int maxThreads = 0;
            if (!string.IsNullOrEmpty(buff))
            {
                if (buff.ToUpper().Contains("CPU"))
                {
                    ThreadTrackBar.Maximum = Environment.ProcessorCount;
                }
                else if (Int32.TryParse(buff, out maxThreads))
                {
                    ThreadTrackBar.Maximum = maxThreads;
                }
            }

            if (ThreadTrackBar.Maximum <= 16)
            {
                ThreadTrackBar.LargeTickFrequency = 1;
            }
            else if (ThreadTrackBar.Maximum <= 32)
            {
                ThreadTrackBar.LargeTickFrequency = 2;
            }
            else if (ThreadTrackBar.Maximum <= 64)
            {
                ThreadTrackBar.LargeTickFrequency = 5;
            }
            else
            {
                ThreadTrackBar.LargeTickFrequency = 10;
            }

            buff = ConfigurationManager.AppSettings["MaxTimedTestMins"];
            if (!string.IsNullOrEmpty(buff)) Int32.TryParse(buff, out MaxTimedTestMins);

            buff = ConfigurationManager.AppSettings["MaxCountThousands"];
            if (!string.IsNullOrEmpty(buff)) Int32.TryParse(buff, out MaxCountThousands);

            //TestCountTB.MaskedEditBoxElement.MouseWheel += new MouseEventHandler(TestCountTB_MouseWheel);
            TestCountTB.MaskedEditBoxElement.EnableMouseWheel = false;
            TimedMinsTB.MaskedEditBoxElement.EnableMouseWheel = false;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text += " " + fvi.ProductVersion;

            SetStatusLabel("Pending");
        }

        public void SetElapsedTime(int value)
        {
            if (CancelBenchmark) return;

            if (BenchmarkProgressBar.InvokeRequired)
            {
                BenchmarkProgressBar.Invoke(new MethodInvoker(delegate
                {
                    if (value >= BenchmarkProgressBar.Maximum)
                    {
                        BenchmarkProgressBar.Value1 = BenchmarkProgressBar.Maximum;
                    }
                    else if (value <= BenchmarkProgressBar.Value1)
                    {
                        return;  // Do nothing - do not back up for delayed thread updates
                    }
                    else
                    {
                        BenchmarkProgressBar.Value1 = value;
                    }
                }));
            }
        }


        public void IncrementBenchmarkProgressBar(int inc)
        {
            if (CancelBenchmark) return;

            if (BenchmarkProgressBar.InvokeRequired)
            {
                BenchmarkProgressBar.Invoke(new MethodInvoker(delegate
                {
                    if ((BenchmarkProgressBar.Value1 + inc) >= BenchmarkProgressBar.Maximum)
                    {
                        BenchmarkProgressBar.Value1 = BenchmarkProgressBar.Maximum;
                    }
                    else
                    {
                        BenchmarkProgressBar.Value1 += inc;
                    }
                }));
            }
            else
            {
                if ((BenchmarkProgressBar.Value1 + inc) >= BenchmarkProgressBar.Maximum)
                {
                    BenchmarkProgressBar.Value1 = BenchmarkProgressBar.Maximum;
                }
                else
                {
                    BenchmarkProgressBar.Value1 += inc;
                }
            }
        }

        public void SetBenchmarkProgressBar(int value)
        {
            if (CancelBenchmark) return;

            if (BenchmarkProgressBar.InvokeRequired)
            {
                BenchmarkProgressBar.Invoke(new MethodInvoker(delegate
                {
                    if (value >= BenchmarkProgressBar.Maximum)
                    {
                        BenchmarkProgressBar.Value1 = BenchmarkProgressBar.Maximum;
                    }
                    else if (value <= BenchmarkProgressBar.Value1)
                    {
                        return;  // Do nothing - do not back up for delayed thread updates
                    }
                    else
                    {
                        BenchmarkProgressBar.Value1 = value;
                    }
                }));
            }
            else
            {
                if (value >= BenchmarkProgressBar.Maximum)
                {
                    BenchmarkProgressBar.Value1 = BenchmarkProgressBar.Maximum;
                }
                else if (value <= BenchmarkProgressBar.Value1)
                {
                    return;  // Do nothing - do not back up for delayed thread updates
                }
                else
                {
                    BenchmarkProgressBar.Value1 = value;
                }
            }
        }

        public int GetBenchmarkProgressBarStatus()
        {
            int value = 0;
            if (BenchmarkProgressBar.InvokeRequired)
            {
                BenchmarkProgressBar.Invoke(new MethodInvoker(delegate { value = BenchmarkProgressBar.Value1; }));
            }
            else
            {
                value = BenchmarkProgressBar.Value1;
            }

            return value;
        }

        public void UpdateChartView(int x, int y)
        {
            if (DemoChartView.InvokeRequired)
            {
                DemoChartView.Invoke(new MethodInvoker(delegate
                {
                    ((Telerik.WinControls.UI.ScatterSeries)DemoChartView.Series[0]).DataPoints.Add(new ScatterDataPoint(x, y));
                }));
            }
            else
            {
                ((Telerik.WinControls.UI.ScatterSeries)DemoChartView.Series[0]).DataPoints.Add(new ScatterDataPoint(x, y));
            }
        }

        public void InitAPIStats()
        {
            benchmarkStartTime = DateTime.UtcNow;
        }

        public void ResetAPIStatsForNewBenchmark()
        {
            AvgApiThreadTimeLB.Text = "(pending)";
            ApiCalls.Text = "(pending)";
            TestStartTimeLB.Text = "(pending)";
            TestEndTimeLB.Text = "(pending)";
            ElapsedTimeLB.Text = "(pending)";
            ThroughputTB.Text = "(pending)";
        }

        public void UpdateAPIStats(int apiCnt, double totApiTimeMillisecs)
        {
            double avgThreadTimeSecs = (totApiTimeMillisecs / apiCnt) / 1000;
            if (AvgApiThreadTimeLB.InvokeRequired)
            {
                AvgApiThreadTimeLB.Invoke(new MethodInvoker(delegate { AvgApiThreadTimeLB.Text = avgThreadTimeSecs.ToString("#.###### secs"); }));
            }
            else
            {
                AvgApiThreadTimeLB.Text = avgThreadTimeSecs.ToString("#.###### secs");
            }

            if (ApiCalls.InvokeRequired)
            {
                ApiCalls.Invoke(new MethodInvoker(delegate { ApiCalls.Text = apiCnt.ToString(); }));
            }
            else
            {
                ApiCalls.Text = apiCnt.ToString();
            }

        }

        public void UpdateElapsedTime(TimeSpan tspan)
        {
            if (ElapsedTimeLB.InvokeRequired)
            {
                ElapsedTimeLB.Invoke(new MethodInvoker(delegate
                {
                    ElapsedTimeLB.Text = string.Format("{0:mm\\.ss\\.fff} mm.ss.fff", tspan);
                }));
            }
            else
            {
                ElapsedTimeLB.Text = string.Format("{0:mm\\.ss\\.fff} mm.ss.fff", tspan);
            }
        }

        public void FinalizeAPIStats(int apiCnt, TimeSpan tspan)
        {
            UpdateElapsedTime(tspan);

            double throughput = tspan.TotalSeconds / (double)apiCnt;
            if (ThroughputTB.InvokeRequired)
            {
                ThroughputTB.Invoke(new MethodInvoker(delegate
                {
                    ThroughputTB.Text = throughput.ToString("##.##### secs/call");
                }));
            }
            else
            {
                ThroughputTB.Text = throughput.ToString("##.##### secs/call");
            }

            if (AbortBenchmark)
            {
                SetStatusLabel("Aborted!");
            }
            else
            {
                SetStatusLabel("Finished!");
            }
        }

        public void SetStartTime(DateTime start)
        {
            if (TestStartTimeLB.InvokeRequired)
            {
                TestStartTimeLB.Invoke(new MethodInvoker(delegate
                {
                    TestStartTimeLB.Text = start.ToLongTimeString();
                }));
            }
            else
            {
                TestStartTimeLB.Text = start.ToLongTimeString();
            }
        }

        public void SetEndTime(DateTime end)
        {
            if (TestEndTimeLB.InvokeRequired)
            {
                TestEndTimeLB.Invoke(new MethodInvoker(delegate
                {
                    TestEndTimeLB.Text = end.ToLongTimeString();
                }));
            }
            else
            {
                TestEndTimeLB.Text = end.ToLongTimeString();
            }
        }

        internal BenchmarkSettings GetBenchmarkSettings()
        {
            EnumeratedTypes.TestCalculationTypes calcType =
               CalcStandardRB.Checked ? EnumeratedTypes.TestCalculationTypes.StdTaxes :
               CalcAdjustmentRB.Checked ? EnumeratedTypes.TestCalculationTypes.StdAdjustments :
               CalcTaxInclusiveRB.Checked ? EnumeratedTypes.TestCalculationTypes.TaxInclusive :
               CalcTaxInclusiveAdjustmentRB.Checked ? EnumeratedTypes.TestCalculationTypes.TaxInclusiveAdjustment :
               ZipLookupRB.Checked ? EnumeratedTypes.TestCalculationTypes.ZipLookup :
               EnumeratedTypes.TestCalculationTypes.EndOfTestCalculationTypes;

            BenchmarkSettings bs = new BenchmarkSettings(
               CompanyIdentifierTB.Text,
               CustNoTB.Text,
               TransactionTB.Text,
               ServiceTB.Text,
               ChargeTB.Text,
               InvoiceDate.Value,
               PCodeTB.Text,
               calcType,
               (int)ThreadTrackBar.Value,
               inputHdlr.WorkingDirectory
               );

            return bs;
        }

        private void PostSampleBTN_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                TelecomBenchmark process = new TelecomBenchmark();

                int clientId = string.IsNullOrEmpty(ClientIdTB.Text) ? -1 : Convert.ToInt16(ClientIdTB.Text.Trim());
                int clientProfileId = string.IsNullOrEmpty(ClientProfileIdTB.Text) ? -1 : Convert.ToInt16(ClientProfileIdTB.Text.Trim());

                if (clientId >= 0 && clientProfileId >= 0)
                {
                    CommsPlatformRestApi.SetUserCredentials(UsernameTB.Text, PasswordTB.Text, clientId, clientProfileId);
                }
                else
                {
                    CommsPlatformRestApi.SetUserCredentials(UsernameTB.Text, PasswordTB.Text); // use ClientId and Client Profile Id from app.config
                }

                string results = process.RunSingleTransaction(GetBenchmarkSettings());
                //ResultsTB.Text = results;
            }
            catch (Exception ex)
            {
                //ResultsTB.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ViewReqJsonPB_Click(object sender, EventArgs e)
        {
            TelecomBenchmark process = new TelecomBenchmark();
            BenchmarkSettings settings = GetBenchmarkSettings();
            var trans = TelecomBenchmark.GetTransaction(settings.DefaultPCode, settings.DefaultTransactionType, settings.DefaultServiceType,
               settings.DefaultInvoiceDate, settings.DefaultCharge, settings.DefaultCompanyIdentifier, settings.DefaultCustomerNumber);
            var objectString = JsonConvert.SerializeObject(trans, Formatting.Indented);
            //ResultsTB.Text = objectString;
        }

        private int ImportFile(string filename)
        {
            FileInfo fi = new FileInfo(filename);

            if (!fi.Exists)
            {
                if (!string.IsNullOrEmpty(DefaultWorkingDirectory) && !InputFileBrowser.Text.Contains("\\"))
                {
                    fi = new FileInfo(Path.Combine(DefaultWorkingDirectory, filename));
                }

                if (!fi.Exists)
                {
                    throw new Exception(string.Format("File {0} not found!", filename));
                }
            }

            int convLines = 0;
            int procLines = 0;
            int failLines = 0;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<Transaction> t1 = inputHdlr.ProcessInputTransactions(fi, out convLines, out procLines, out failLines);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return convLines;
        }

        private void InputFileBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = ConfigurationManager.AppSettings["DefaultWorkingDir"];
            dlg.FileName = InputFileBrowser.Text;
            dlg.Filter = "Input File|*.csv|All files|*.*";
            dlg.Title = "Select comma delimited input file";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                InputFileBrowser.Text = dlg.FileName;
            }
        }

        private void TestingWindow_Load(object sender, EventArgs e)
        {
            // Add winform load time settings here
        }

        private void GoButton_MouseDown(object sender, MouseEventArgs e)
        {
            GoButton.Image = global::Avalara.RestDemoApplication.Properties.Resources.GoButtonClicked;
        }

        private void GoButton_MouseUp(object sender, MouseEventArgs e)
        {
            GoButton.Image = global::Avalara.RestDemoApplication.Properties.Resources.GoButtonStd;
        }

        private void DemoTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DemoTabControl.SelectedTab == DemoInputTab)
            {
                //Add tab specific updates for Input Tab here
            }
            else if (DemoTabControl.SelectedTab == DemoMetricsTab)
            {
                //Add tab specific updates for Metrics Tab here
            }

        }

        private bool VerifyCredentials(out string restVersion)
        {
            bool verified = false;
            restVersion = string.Empty;
            VerifyCredentialsErrorMsg.Text = string.Empty;
            int clientId = string.IsNullOrEmpty(ClientIdTB.Text) ? -1 : Convert.ToInt16(ClientIdTB.Text.Trim());
            int clientProfileId = string.IsNullOrEmpty(ClientProfileIdTB.Text) ? -1 : Convert.ToInt16(ClientProfileIdTB.Text.Trim());
            TelecomBenchmark process = new TelecomBenchmark();
            if (clientId >= 0 && clientProfileId >= 0)
            {
                CommsPlatformRestApi.SetUserCredentials(UsernameTB.Text, PasswordTB.Text, clientId, clientProfileId);
            }
            else
            {
                CommsPlatformRestApi.SetUserCredentials(UsernameTB.Text, PasswordTB.Text); // use ClientId and Client Profile Id from app.config
            }

            restVersion = process.GetRESTVersion(out verified);
            return verified;

        }
        private void VerifyCredentialCheckBox_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (!VerifyCredentialCheckBox.Checked)
            {
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor = Color.FromArgb(255, 238, 156, 156);
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor2 = Color.FromArgb(255, 255, 0, 0);
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor3 = Color.FromArgb(255, 178, 34, 34);
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor4 = Color.FromArgb(255, 114, 19, 19);

                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.GradientStyle = GradientStyles.Linear;
                RestVersionLB.Text = "REST API Version: (unverified)";
                return;
            }

            string restVersion = string.Empty;
            bool verified = VerifyCredentials(out restVersion);

            if (verified)
            {
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor = Color.FromArgb(255, 183, 238, 156);
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor2 = Color.FromArgb(255, 85, 255, 0);
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor3 = Color.FromArgb(255, 82, 178, 34);
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.BackColor4 = Color.FromArgb(255, 51, 114, 19);

                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.Fill.GradientStyle = GradientStyles.Linear;
                VerifyCredentialCheckBox.ButtonElement.CheckMarkPrimitive.CheckElement.ForeColor = Color.DarkBlue;
                RestVersionLB.Text = "REST API Version: " + restVersion;
                return;
            }

            //If it failed reset the state but leave up the error message
            VerifyCredentialsErrorMsg.Text = restVersion;
            VerifyCredentialCheckBox.Checked = false;
        }

        public void JoinThread()
        {
            benchmarkProcess.Join(TimeSpan.Zero);
        }

        public void SetStatusLabel(string text)
        {
            if (StatusLabel.InvokeRequired)
            {
                StatusLabel.Invoke(new MethodInvoker(delegate { StatusLabel.Text = text; }));
            }
            else
            {
                StatusLabel.Text = text;
            }

            if (StatusBGLabel.InvokeRequired)
            {
                StatusBGLabel.Invoke(new MethodInvoker(delegate { StatusBGLabel.Text = text; }));
            }
            else
            {
                StatusBGLabel.Text = text;
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            string restVersion = string.Empty;
            if (!VerifyCredentials(out restVersion))
            {
                MessageBox.Show("Credentials not valid.  Please update and verify before running test.",
                         "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FinishedBenchmark = false;
            AbortBenchmark = false;
            ResetAPIStatsForNewBenchmark();

            TestTypes tt = (CountTestTypeRB.IsChecked) ? TestTypes.COUNT_TEST :
               (TimedTestTypeRB.IsChecked) ? TestTypes.TIMED_TEST : TestTypes.FILE_TEST;

            int tstval = 0;
            List<Transaction> transList = null;
            int progressBarMaximum = 0;
            switch (tt)
            {
                case TestTypes.COUNT_TEST:
                    tstval = string.IsNullOrEmpty(TestCountTB.Text) ? 0 : int.Parse(TestCountTB.Text) * 1000;
                    if (tstval <= 0)
                    {
                        MessageBox.Show("Test count must be set and > 0 for the selected test type.",
                           "Test Count Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    progressBarMaximum = tstval;
                    break;
                case TestTypes.TIMED_TEST:
                    tstval = string.IsNullOrEmpty(TimedMinsTB.Text) ? 0 : int.Parse(TimedMinsTB.Text) * 60;
                    if (tstval <= 0)
                    {
                        MessageBox.Show("Test minutes must be set and > 0 for the selected test type.",
                           "Test Minutes Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    progressBarMaximum = tstval; // Test time in seconds
                    break;
                case TestTypes.FILE_TEST:
                    tstval = inputHdlr.GetTransactionCount();
                    transList = inputHdlr.GetTransactionList();
                    if ((transList == null) || (transList.Count == 0))
                    {
                        MessageBox.Show("No imported transactions found. " +
                           "Use the browse button to import a valid input file.",
                           "Import Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    progressBarMaximum = transList.Count;
                    break;
            }

            BenchmarkSettings settings = GetBenchmarkSettings();
            settings.Status = DStatus = new DemoStatus(tt, tstval);
            settings.Transactions = transList;
            //settings.TransactionCount = progressBarMaximum;
            settings.Status.DemoChart = new ChartData(DemoChartView, this);

            BenchmarkProgressBar.Value1 = 0;
            BenchmarkProgressBar.Maximum = progressBarMaximum;
            SetStatusLabel("In Progress ...");

            DemoTabControl.SelectedTab = DemoMetricsTab;

            CommsPlatformRestApi.SetUserCredentials(UsernameTB.Text, PasswordTB.Text);

            try
            {
                benchmarkProcess = new Thread(new ParameterizedThreadStart(TelecomBenchmark.ProcessRequestAsThread));
                benchmarkProcess.Start((object)settings);
            }
            catch (Exception ex)
            {
                if (!CancelBenchmark)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InputFileBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = (OpenFileDialog)InputFileBrowser.Dialog;
            //dlg.Filter = "(*.csv)|*.csv";
            dlg.Filter = "Input File|*.csv|All files|*.*";
            dlg.Title = "Select comma delimited input file";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImportedCountLB.Text = "Processing ...";
                InputFileBrowser.BrowseElement.TextBoxItem.Text = dlg.FileName;
                try
                {
                    InputTestTypeRB.IsChecked = true;
                    int tCnt = ImportFile(dlg.FileName);
                    ImportedCountLB.Text = string.Format("Imported {0} transactions", tCnt);
                }
                catch (Exception ex)
                {
                    ImportedCountLB.Text = string.Empty;
                    MessageBox.Show(ex.Message, "File Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void TestCountTB_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TimedMinsTB.Text))
            {
                return;
            }

            if (MaxCountThousands < int.Parse(TestCountTB.Text))
            {
                MessageBox.Show(string.Format("Test value of {0}K exceeded max API Calls {1}K - value set to max.  Update config setting \"MaxCountThousands\" to change the limit.",
                   TestCountTB.Text, MaxCountThousands));
                TestCountTB.Value = MaxCountThousands;
            }
            CountTestTypeRB.IsChecked = true;
        }

        private void TimedMinsTB_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TimedMinsTB.Text))
            {
                return;
            }

            if (MaxTimedTestMins < int.Parse(TimedMinsTB.Text))
            {
                MessageBox.Show(string.Format("Test value of {0} exceed max minutes {1} - value set to max.  Update config setting \"MaxTimedTestMins\" to change the limit.",
                   TimedMinsTB.Text, MaxTimedTestMins));
                TimedMinsTB.Value = MaxTimedTestMins;
            }
            TimedTestTypeRB.IsChecked = true;
        }

        private void TestingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelBenchmark = true;
            if (DStatus != null) DStatus.EndTimedDemo();
        }

        private void ThreadTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (ThreadTrackBar.Value == 0)
            {
                ThreadTrackBar.Value = 1;
            }
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            if (DStatus != null)
            {
                AbortBenchmark = true;
                DStatus.EndTimedDemo();
            }
        }

        private void TestCountTB_MouseWheel(object sender, MouseEventArgs e)
        {
            //Mouse wheel event disabled for now but left as reference should the mouse wheel event be re-enabled
            TestCountTB_ValueChanged(null, null);
        }
    }
}
