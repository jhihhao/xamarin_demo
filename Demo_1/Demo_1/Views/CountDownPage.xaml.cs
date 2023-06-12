using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo_1.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountDownPage:ContentPage {
        Stopwatch s = new Stopwatch();
        public BackgroundWorker bw;

        public CountDownPage() {
            InitializeComponent();
            initBackgroundWorker();
            if (!bw.IsBusy) {
                bw.RunWorkerAsync();
            }
            s.Start();
        }

        private void initBackgroundWorker() {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkCompleted);
        }
        private double pollPeriod = 1; // 1s
        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            long freq;
            double CounterPoint = 0;
            double TimePass;
            freq = Stopwatch.Frequency; //The system frquency of Stopwatch.  

            while (!bw.CancellationPending) {
                TimePass = (s.ElapsedTicks - CounterPoint) / freq;
                if (TimePass >= pollPeriod) {
                    CounterPoint = s.ElapsedTicks;
                    bw.ReportProgress(100);
                }
            }
        }

        private readonly int INIT_VALUE = 1000;
        private bool isCountdown = false;
        private int countdownValue = 1000;

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (isCountdown) {
                lbCountDownResult.Text = "Time: " + $"{countdownValue}" + "s";
                countdownValue--;
                if (countdownValue == 0) {
                    isCountdown = false;
                }
            } else {
                countdownValue = INIT_VALUE;
            }

        }

        private void bw_RunWorkCompleted(object sender, RunWorkerCompletedEventArgs e) { }

        private void BtnStartCountdown_Clicked(object sender, EventArgs e) {
            isCountdown = true;
        }

        private void BtnStopCoutndown_Clicked(object sender, EventArgs e) {
            isCountdown = false;
        }
    }
}