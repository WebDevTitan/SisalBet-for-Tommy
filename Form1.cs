using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace SisalBet
{
    public partial class Form1 : Form
    {
        private string prevMessage = string.Empty;
        Thread threadSisal = null;
        Thread threadScan = null;
        private string location = string.Empty;
        public Form1()
        {
            InitializeComponent();
            Global.WrittingLog += WriteStatus;
            LoadsettingInfo();
            initSet();
        }

        private void WriteStatus(string status)
        {
            try
            {
                string curPath = Directory.GetCurrentDirectory();
                if (txtLogs.InvokeRequired)
                    txtLogs.Invoke(Global.WrittingLog, status);
                else
                {
                    string logText = ((string.IsNullOrEmpty(txtLogs.Text) ? "" : "\r") + string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), status));
                    if (txtLogs.Lines.Length > 3000)
                        txtLogs.Clear();

                    txtLogs.AppendText(logText);
                    txtLogs.ScrollToCaret();
                    prevMessage = status;
                }

            }
            catch (Exception ex)
            {
                Global.WrittingLog(ex.Message);
            }
        }

        private void LoadsettingInfo()
        {

            try
            {
                if (File.Exists("setting.txt"))
                {
                    string[] lines = File.ReadAllLines("setting.txt");
                    foreach (string line in lines)
                    {
                        string[] values = line.Split('=');
                        if (values.Length == 2)
                        {
                            if (values[0] == "username")
                                Setting.Instance.Username = values[1];
                            else if (values[0] == "password")
                                Setting.Instance.Password = values[1];
                            else if (values[0] == "outcome")
                                Setting.Instance.Outcome = values[1];
                            else if (values[0] == "stake")
                                Setting.Instance.Stake = values[1];
                            else if (values[0] == "sport")
                                Setting.Instance.Sport = values[1];
                            else if (values[0] == "match1")
                                Setting.Instance.Match1 = values[1];
                            else if (values[0] == "match2")
                                Setting.Instance.Match2 = values[1];
                            else if (values[0] == "match3")
                                Setting.Instance.Match3 = values[1];
                            else if (values[0] == "match4")
                                Setting.Instance.Match4 = values[1];
                            else if (values[0] == "match5")
                                Setting.Instance.Match5 = values[1];
                        }
                    }
                    if (File.Exists("output.json"))
                    {
                        string jsonOutput = File.ReadAllText("output.json");
                        Setting.Instance.EventIdsResult = JArray.Parse(jsonOutput);
                    }
                }
            }
            catch
            {

            }
        }

        private void initSet()
        {
            try
            {
                txtUsername.Text = Setting.Instance.Username;
                txtPassword.Text = Setting.Instance.Password;
                txtOutcome.Text = Setting.Instance.Outcome;
                txtStake.Text = Setting.Instance.Stake;
                txtSportType.Text = Setting.Instance.Sport;
                txtMatch1.Text = Setting.Instance.Match1;
                txtMatch2.Text = Setting.Instance.Match2;
                txtMatch3.Text = Setting.Instance.Match3;
                txtMatch4.Text = Setting.Instance.Match4;
                txtMatch5.Text = Setting.Instance.Match5;

            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!canSave())
                    return;
                setValues();
                saveSettingInfo();

                MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                Global.WrittingLog("Error in Save info process:" + ex.Message);
            }
        }

        private bool canSave()
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Please input username");
                    return false;
                }
                if (string.IsNullOrEmpty(qwe.Text))
                {
                    qwe.Focus();
                    MessageBox.Show("Please input password");
                    return false;
                }
                if (string.IsNullOrEmpty(ad.Text))
                {
                    ad.Focus();
                    MessageBox.Show("Please input Stake");
                    return false;
                }
                if (string.IsNullOrEmpty(txtOutcome.Text))
                {
                    txtOutcome.Focus();
                    MessageBox.Show("Please input Outcome");
                    return false;
                }
                if (string.IsNullOrEmpty(txtSportType.Text))
                {
                    txtSportType.Focus();
                    MessageBox.Show("Please input sportType");
                    return false;
                }
                if (string.IsNullOrEmpty(txtMatch1.Text))
                {
                    txtMatch1.Focus();
                    MessageBox.Show("Please input Match1");
                    return false;
                }
                if (string.IsNullOrEmpty(txtMatch2.Text))
                {
                    txtMatch2.Focus();
                    MessageBox.Show("Please input Match2");
                    return false;
                }
                if (string.IsNullOrEmpty(txtMatch3.Text))
                {
                    txtMatch3.Focus();
                    MessageBox.Show("Please input Match3");
                    return false;
                }
                if (string.IsNullOrEmpty(txtMatch4.Text))
                {
                    txtMatch4.Focus();
                    MessageBox.Show("Please input Match4");
                    return false;
                }
                if (string.IsNullOrEmpty(txtMatch5.Text))
                {
                    txtMatch5.Focus();
                    MessageBox.Show("Please input Match5");
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void setValues()
        {
            Setting.Instance.Username = txtUsername.Text;
            Setting.Instance.Password = txtPassword.Text;
            Setting.Instance.Stake = txtStake.Text;
            Setting.Instance.Outcome = txtOutcome.Text;
            Setting.Instance.Sport = txtSportType.Text;
            Setting.Instance.Match1 = txtMatch1.Text;
            Setting.Instance.Match2 = txtMatch2.Text;
            Setting.Instance.Match3 = txtMatch3.Text;
            Setting.Instance.Match4 = txtMatch4.Text;
            Setting.Instance.Match5 = txtMatch5.Text;
            
        }
        private void saveSettingInfo()
        {
            try
            {
                string text = string.Format("username={0}\r\npassword={1}\r\noutcome={2}\r\nstake={3}\r\nsport={4}\r\nmatch1={5}\r\nmatch2={6}\r\nmatch3={7}\r\nmatch4={8}\r\nmatch5={9}", Setting.Instance.Username, Setting.Instance.Password, Setting.Instance.Outcome, Setting.Instance.Stake, Setting.Instance.Sport, Setting.Instance.Match1, Setting.Instance.Match2, Setting.Instance.Match3, Setting.Instance.Match4, Setting.Instance.Match5);
                File.WriteAllText("setting.txt", text);

            }
            catch
            {

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Global.WrittingLog("Bot Starting...");
                threadSisal = new Thread(ThreadFunc);
                threadSisal.Start();
            }
            catch
            {

            }
            
        }

        private void ThreadFunc()
        {
            try
            {
                SisalBet Sisal = new SisalBet();
                location = Sisal.getProxyLocation();
                Global.WrittingLog("region : " + location);
                bool isLogin = Sisal.login();
                if (isLogin)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        labelUser.Text = "User : " + Setting.Instance.Username;
                    });
                    Global.WrittingLog("Login success.");
                    List<CombinationBodyarray> body = Sisal.setAttribute();
                    if (body != null)
                    {
                        Global.WrittingLog("Set Attribute success.");
                        Sisal.Prediction(body);
                    }
                    else
                    {
                        Global.WrittingLog("Set Attribute false.");
                        return;
                    }
                } else
                {
                    Global.WrittingLog("Login False.");
                    return;
                }


            }
            catch
            {

            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                Global.WrittingLog("Scan Start...");
                threadScan = new Thread(ThreadScanFunc);
                threadScan.Start();
                
                
            }
            catch
            {

            }
            

        }

        private void ThreadScanFunc()
        {
            try
            {
                Scanner scanner = new Scanner();
                bool resultScan = scanner.ScanFunction();
                if (resultScan)
                {
                    Global.WrittingLog("Scanning is complete.");
                }
            }
            catch
            {

            }
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Global.WrittingLog(Setting.Instance.EventIdsResult.Count.ToString());
        }

        private void btnScanStop_Click(object sender, EventArgs e)
        {
            threadScan.Abort();
            Global.WrittingLog("Scan Stop.");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            threadSisal.Abort();
            Global.WrittingLog("Bot Stop.");
        }
    }
}
