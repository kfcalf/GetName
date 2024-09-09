using System;
using System.Drawing;
using System.IO;
using System.Management;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using Microsoft.International.Converters.PinYinConverter;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;


namespace GetName
{
    public partial class Form1 : Form
    {
        string pyName = "";
        //Thread ThreadGet;
        //string theInfo;
        private delegate void wtGet(ref string bl);
        //bmk 委托代码声明

        public string[] filePaths;
        public string fileA;
        public int picNum = 1;// 图片状态
        string txtStr="";
        //public static Boolean NetOk=true;
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        //private static Thread th;
        System.Diagnostics.Stopwatch sw;

        public Form1()
        {
            InitializeComponent();
        }


        private bool IsConnected()
        {

            int I = 0;

            bool state = InternetGetConnectedState(out I, 0);

            return state;

        }



        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            txt1.SelectAll();
            txt1.Copy();
            txt1.SelectionLength = 0;
        }

        private void chkExtension_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.AddMilliseconds(0 - Environment.TickCount);
            //Console.WriteLine("开机时间:" + dt.ToString());
            //MessageBox.Show(dt.ToString()+ RegistryInstallDate());
            txtSysInfo.Text += "启动时间：" + dt.ToString() + Environment.NewLine + "安装时间：" + RegistryInstallDate();
        }

        private static string RegistryInstallDate()
        {
            System.Management.ObjectQuery MyQuery = new System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            System.Management.ManagementScope MyScope = new System.Management.ManagementScope();
            ManagementObjectSearcher MySearch = new ManagementObjectSearcher(MyScope, MyQuery);
            ManagementObjectCollection MyCollection = MySearch.Get();
            string StrInfo = "";
            foreach (ManagementObject MyObject in MyCollection)
            {
                StrInfo = MyObject.GetText(TextFormat.Mof);
                //MessageBox.Show(StrInfo);
            }
            string InstallDate = StrInfo.Substring(StrInfo.LastIndexOf("InstallDate") + 15, 14);
            DateTime dt2 = DateTime.ParseExact(InstallDate, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            return dt2.ToString();
        }

        private void btnCalcDay_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt1 = DateTime.Now;
                //DateTime dt23 = DateTime.Parse("2013-5-30 14:20:45");
                //TimeSpan ts = dt1 - dt2;
                //Console.WriteLine(ts.Days);
                //Console.ReadKey();
                //DateTime dt1 = dateTP1.Value.Date;
                //DateTime dt2 = dateTP2.Value.Date;
                DateTime dt1 = DateTime.Parse(txtDay1.Text);
                DateTime dt2 = DateTime.Parse(txtDay2.Text);
                TimeSpan ts = dt2 - dt1;  //bmk 日期差
                txtCalcDay.Text = ts.Days.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("请检测日期格式！");

                //throw;
            }
        }

        private void dateTP1_ValueChanged(object sender, EventArgs e)
        {
            //txtDay1.Text = dateTP1.Value.Date.ToString();
            txtDay1.Text = dateTP1.Value.ToShortDateString();
        }

        private void dateTP2_ValueChanged(object sender, EventArgs e)
        {
            txtDay2.Text = dateTP2.Value.ToShortDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost =Properties.Settings.Default.IsTop;
            if (this.TopMost == true)
            {
                lblTop.Image = GetName.Properties.Resources.push_pin;
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
                lblTop.Image = GetName.Properties.Resources.red_pin;
            }



        }

        private void timerCgIcon_Tick(object sender, EventArgs e)
        {
            //if (IsConnected())
            //{
            //    MessageBox.Show("状态:网络畅通!");
            //}
            //else
            //{
            //    MessageBox.Show("状态:与目标网络无连接！");
            //}

            try
            {
                if (IsConnected())
                {
                    if (picNum == 1)
                    {

                        notifyIcon1.Icon = Properties.Resources.Green_Ball;
                        picNum =2;
                    }
                    else
                    {
                        notifyIcon1.Icon = Properties.Resources.Blue_Ball;
                        picNum = 1;
                    }
                    notifyIcon1.Text = "Online";

                }
                else
                {
                    notifyIcon1.Icon = Properties.Resources.Red_Ball;
                    notifyIcon1.Text = "Offline";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //return;
                //throw;
            }





        }

        private void txt1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;//调用DragDrop事件
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void txt1_DragDrop(object sender, DragEventArgs e)
        {
            //bmk DragDrop
            //选择一个目录时，获取目录下面所有完整文件名

            filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);//拖放的多个文件的路径列表
            fileA = filePaths[0];

            txt1.Clear();

            //call worker
            if (bkgWorkerDrag.IsBusy == false)
            {

                lblInfo.Text = "载入中...";
                bkgWorkerDrag.RunWorkerAsync();
            }


            if (txt1.Text!="")
            {
                sper.oldData = txt1.Text;

            }

        }

        private void bkgWorkerDrag_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //if (bkgWorkerDrag.CancellationPending == true)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //DragGet(this.bkgWorkerDrag);

            System.ComponentModel.BackgroundWorker worker = (System.ComponentModel.BackgroundWorker)sender;
            e.Result = DragGet(worker, e);
        }

       	public long DragGet(System.ComponentModel.BackgroundWorker worker, System.ComponentModel.DoWorkEventArgs e)
        {
            //bmk 线程获取名字

            try
            {
                string txtStr = "";
                sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                if (filePaths.Length == 1)
                {
                    //MessageBox.Show(folder.ToString());
                    if (Directory.Exists(fileA))//选择的其中一个是目录
                    {
                        DirectoryInfo folder = new DirectoryInfo(fileA);
                        if (chkExtension.Checked == true)
                        {
                            foreach (FileInfo file in folder.GetFiles("*.*"))
                            {
                                txtStr += file.Name + Environment.NewLine; //带扩展名
                            }
                            txt1.Text = txtStr;//此方法使速度更快，尽量不让控件参与循环
                        }
                        else
                        {
                            foreach (FileInfo file in folder.GetFiles("*.*"))
                            {
                                txtStr += Path.GetFileNameWithoutExtension(file.Name) + Environment.NewLine; //不带扩展名
                            }
                            txt1.Text = txtStr;
                        }
                    }
                    else if (File.Exists(fileA))
                    {
                        //MessageBox.Show("请选择一个目录！");
                        if (chkPath.Checked == true)//如果选择了路径
                        {
                            //txt1.Text += Path.GetFullPath(filePaths[i]) + Environment.NewLine; //不带扩展名
                            if (chkExtension.Checked == true)
                            {
                                txt1.Text += Path.GetFullPath(fileA) + Environment.NewLine;
                            }
                            else
                            {
                                txt1.Text += Path.GetFullPath(fileA).Replace(Path.GetExtension(fileA), "") + Environment.NewLine; //不带扩展名

                            }


                        }
                        else
                        {
                            //txt1.Text += Path.GetFileNameWithoutExtension(fileA) + Environment.NewLine; //不带扩展名
                            if (chkExtension.Checked == true)
                            {
                                //txt1.Text += Path.GetFullPath(fileA) + Environment.NewLine;
                                txt1.Text += Path.GetFileName(fileA) + Environment.NewLine;
                            }
                            else
                            {
                                txt1.Text += Path.GetFileName(fileA).Replace(Path.GetExtension(fileA), "") + Environment.NewLine;//不带扩展名

                            }
                        }
                        //txt1.Text = Path.GetFullPath(fileA);

                    }

                }
                else if (filePaths.Length > 1)//如果选择了多个文件
                {

                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if (File.Exists(filePaths[i]))
                        {
                            if (chkExtension.Checked == true)//如果选择了扩展名
                            {
                                if (chkPath.Checked == true)
                                {
                                    txtStr += Path.GetFullPath(filePaths[i]) + Environment.NewLine; //路径，带扩展名

                                }
                                else
                                {
                                    txtStr += Path.GetFileName(filePaths[i]) + Environment.NewLine;//只是文件名，带扩展

                                }


                            }
                            else
                            {
                                if (chkPath.Checked == true)//如果选择了路径
                                {
                                    //txt1.Text += Path.GetFullPath(filePaths[i]) + Environment.NewLine; //不带扩展名
                                    txtStr += Path.GetFullPath(filePaths[i]).Replace(Path.GetExtension(filePaths[i]), "") + Environment.NewLine; //不带扩展名

                                }
                                else
                                {
                                    txtStr += Path.GetFileNameWithoutExtension(filePaths[i]) + Environment.NewLine; //不带扩展名
                                }
                            }

                        }


                    }
                     txt1.Text = txtStr;

                }
                if (txt1.Text != "")
                {
                    sper.oldData = txt1.Text;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
             return 0;
        }


        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;

                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "" && txtFilter.Text!="")
            {
                string str = txtFilter.Text.Trim();
                string[] liststr = str.Split('+');
                string lastStr = "";


                List<string> cppTxt = new List<string>();
                cppTxt = txt1.Lines.ToList(); //texbox to list

                foreach (var strT in cppTxt) //结果列表
                {
                    //strT.Split(',').Intersect(liststr).Count() == 0
                    if (!strT.Contains(liststr[0]))
                    {
                        lastStr = lastStr + strT + Environment.NewLine;
                    }
                }
                txt1.Text = lastStr;
                //MessageBox.Show("处理成功！");
            }
        }

        private void btnRetain_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "" && txtRetain .Text != "")
            {
                string str = txtRetain.Text.Trim();
                string[] liststr = str.Split('+');
                string lastStr = "";


                List<string> cppTxt = new List<string>();
                cppTxt = txt1.Lines.ToList(); //texbox to list

                foreach (var strT in cppTxt) //结果列表
                {
                    //strT.Split(',').Intersect(liststr).Count() == 0
                    if (strT.Contains(liststr[0]))
                    {
                        lastStr = lastStr + strT + Environment.NewLine;
                    }
                }
                txt1.Text = lastStr;
                //MessageBox.Show("处理成功！");
            }
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            txt1.Text = sper.oldData;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            //string txtStr="";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //txt1.Clear();
                //DirectoryInfo folder = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                txtFolderPath.Text = folderBrowserDialog1.SelectedPath;
                btnGetName.PerformClick();
                //if (chkExtension.Checked == true)
                //{
                //    foreach (FileInfo file in folder.GetFiles("*.*"))
                //    {
                //        txtStr += file.Name + Environment.NewLine; //带扩展名
                //    }
                //}
                //else
                //{
                //    foreach (FileInfo file in folder.GetFiles("*.*"))
                //    {
                //        txtStr += Path.GetFileNameWithoutExtension(file.Name) + Environment.NewLine; //不带扩展名
                //    }
                //}
                //txt1.Text = txtStr;

                //if (txt1.Text != "")
                //{
                //    sper.oldData = txt1.Text;

                //}
               

            }
        }


        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTop_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void lblTop_Click(object sender, EventArgs e)
        {


            if (this.TopMost == true)
            {
                lblTop.Image = GetName.Properties.Resources.red_pin;
                this.TopMost = false;
                Properties.Settings.Default.IsTop = false;
            }
            else
            {
                this.TopMost = true;
                lblTop.Image = GetName.Properties.Resources.push_pin;
                Properties.Settings.Default.IsTop = true;
            }
            Properties.Settings.Default.Save();

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            TextBox txtK = new TextBox();//bmk 行数统计
            txtK.Text = txt1.Text.Trim();
            lblNum.Text = "Lines:" + txtK.Lines.Count();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bkgWorkerDrag_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //lblInfo.Text = "已完成！";
            if (bkgWorkerDrag.CancellationPending == true) { 
                lblInfo.Text = "任务已取消！";
                sw.Stop();
            
            }
            else
            {
                
                sw.Stop();
                lblInfo.Text = "已完成！"+ (((double)sw.ElapsedMilliseconds)/1000) + "秒";
                //tim.Start();
            }
        }

        private void btnCreatePath_Click(object sender, EventArgs e)
        {
            lblOpenPath.Enabled = false;
            string FilePath = txtPath.Text;
            try
            {
                Directory.CreateDirectory(FilePath);
                //MessageBox.Show("创建成功");
                lblOpenPath.Enabled = true;
            }
            catch (Exception ex)
            {
                lblOpenPath.Enabled = false;
                MessageBox.Show(ex.ToString());
                //throw;
            }
        }

        private void lblOpenPath_Click(object sender, EventArgs e)
        {
            if (txtPath.Text=="")
            {
                lblOpenPath.Enabled = false;
                return;
            }
            try
            {
                System.Diagnostics.Process.Start(txtPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());


                //throw;
            }

        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txt1.Clear();
        }

        private void btnGetName_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderPath.Text))
            {
                 MessageBox.Show(this, "请检查路径！");//注意不能在静态类中使用
                return;
            }

            if (chkFullDir.Checked)
            {
                string folderPath = txtFolderPath.Text;

                if (Directory.Exists(folderPath))
                {
                    try
                    {
                        // Get all directories in the specified path
                        string[] directories = Directory.GetDirectories(folderPath);

                        // Clear the TextBox before adding new content
                        txt1.Clear();

                        // Append each directory path to the TextBox
                        foreach (string directory in directories)
                        {
                            txt1.AppendText(directory + Environment.NewLine);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("检查指定目录是否存在！");
                }
                return;

            }



            txt1.Clear();

            //call worker
            if (backgroundWorker1.IsBusy == false)
            {

                lblInfo.Text = "获取中...";
                backgroundWorker1.RunWorkerAsync();
            }


 

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //bmk 回车获取
            DirectoryInfo folder = new DirectoryInfo(txtFolderPath.Text);

            string[] files = Directory.GetFiles(txtFolderPath.Text);
            int fileCount = files.Length;
            txtStr="";
            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            int i = 0;
            //for (int i = 0; i < fileCount; i++)
            //{

                if (chkExtension.Checked == true)
                {
                    foreach (FileInfo file in folder.GetFiles("*.*"))
                    {
                        txtStr += file.Name + Environment.NewLine; //带扩展名
                        int progressPercentage = (i + 1) * 100 / fileCount;
                        backgroundWorker1.ReportProgress(progressPercentage);
                        i++;
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }


                }
                else
                {
                    foreach (FileInfo file in folder.GetFiles("*.*"))
                    {
                        txtStr += Path.GetFileNameWithoutExtension(file.Name) + Environment.NewLine; //不带扩展名
                        int progressPercentage = (i + 1) * 100 / fileCount;
                        backgroundWorker1.ReportProgress(progressPercentage);
                        i++;
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                }

                
                // Do something with each file
                // Update progress bar


            //}



        }





        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblPer.Text = progressBar1.Value.ToString()+"%";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            //lblInfo.Text = "已完成！";
            if (backgroundWorker1.CancellationPending == true) { 
                lblInfo.Text = "拖任务已取消！";
                sw.Stop();
            }
            else
            {
                txt1.Text = txtStr;
                if (txt1.Text != "")
                {
                    sper.oldData = txt1.Text;


                }
                sw.Stop();
                lblInfo.Text = "已完成！" + (((double)sw.ElapsedMilliseconds) / 1000) + "秒";
                //tim.Start();
            }


        }

        private void txtPyFirst_Click(object sender, EventArgs e)
        {
            pyName = txt1.Text;
            Name= pyName;
            //txt1.Text += Environment.NewLine + Environment.NewLine + ($"{Name}\n全拼：{GetPinyin(Name)}，\n首拼：{GetFirstPinyin(Name)},\n繁体字：{GetTraditional(Name)},\n简体字：{GetSimplified(GetTraditional(Name))}");
            txt1.Text += string.Join(Environment.NewLine, new string[5]) +  $"首拼：{GetFirstPinyin(Name).ToLower()}" + string.Join(Environment.NewLine, new string[5]) + $"全拼：{GetPinyin(Name).ToLower()}" + string.Join(Environment.NewLine, new string[5]) + $"繁体字：{GetTraditional(Name)}" + string.Join(Environment.NewLine, new string[5]) + $"简体字：{GetSimplified(GetTraditional(Name))}";

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }

        /// <summary> 
        /// 汉字转化为拼音
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>全拼</returns> 
        public static string GetPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1)+" ";
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        /// <summary> 
        /// 汉字转化为拼音首字母
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>首字母</returns> 
        public static string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        // <summary> 
        /// 简体转换为繁体
        /// </summary> 
        /// <param name="str">简体字</param> 
        /// <returns>繁体字</returns> 
        public static string GetTraditional(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.SimplifiedToTraditional);
            return r;
        }
        /// <summary> 
        /// 繁体转换为简体
        /// </summary> 
        /// <param name="str">繁体字</param> 
        /// <returns>简体字</returns> 
        public static string GetSimplified(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.TraditionalToSimplified);
            return r;
        }

        private void btnToMoney_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt1.Text, out decimal result))
            {


                txt1.Text += string.Join(Environment.NewLine, new string[5]) + toMoney(result);
            }
            else
            {
                MessageBox.Show(this, "要转换的必须是数字！");//注意不能在静态类中使用
            }
        }


        public static string toMoney(decimal input)
        {
            string[] s1 = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] s2 = { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万", "拾万" }; //第一个空的为个位
            string[] s3 = { "角", "分" };



            string temp = input.ToString("0.00");

            if (temp.Length > 17)
            {
                return ("最大只能处理10亿");
            }

            string xsStr = temp.Substring(temp.Length - 2);

            string zsStr = temp.Substring(0, temp.Length - 3);

            decimal zs = decimal.Parse(zsStr);
            decimal xs = decimal.Parse(xsStr);

            decimal zsbk = zs;
            decimal xsbk = xs;
            string[] s11 = null;
            //Dim s22() As String
            string[] s33 = null;
            //Dim tmpnum As Integer
            int i = 0;
            s11 = new string[zsStr.Length];
            s33 = new string[xsStr.Length];

            //取得每一位整数数字
            for (int j = 0; j < zsStr.Length; j++)
            {
                s11[j] = zsStr[zsStr.Length - 1 - j].ToString();
            }

            //取得每一位小数数字
            for (int j = 0; j < xsStr.Length; j++)
            {
                s33[j] = xsStr[j].ToString();
            }

            //将整数部分加上s2中定义的字符生成大写字串
            string tmpzsStr = "";
            if (zs != 0M)
            {
                bool bhavezero = true;
                for (i = 0; i < s11.Length; i++)
                {
                    string zdStr = ""; //整读字符
                    switch (i + 1)
                    {
                        case 6:
                        case 7:
                        case 8: //加万
                            if (s11[i - 1] == "0" && s11[i] != "0")
                            {
                                zdStr = "万";
                            }
                            break;
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14: //加亿
                            if (s11[i - 1] == "0" && s11[i] != "0")
                            {
                                zdStr = "亿";
                            }
                            break;
                    }

                    if (i == 0 && s11[i] == "0" && zs >= 10M) //如果是个位并且个位是零,整数大于等于10
                    {
                        tmpzsStr = s2[i] + zdStr + tmpzsStr;
                    }
                    else
                    {
                        if (s11[i] != "0")
                        {
                            bhavezero = false;
                        }
                        if (bhavezero == false) //如果从个位起没有连续零了
                        {
                            if (s11[i] != "0") //如果当前位置不为零
                            {
                                tmpzsStr = s1[int.Parse(s11[i])] + s2[i] + zdStr + tmpzsStr;
                            }
                            else
                            {
                                if (i > 0 && s11[i - 1] != "0") //如果当前位置为零并且前面一个也为零
                                {
                                    tmpzsStr = s1[int.Parse(s11[i])] + zdStr + tmpzsStr;
                                }
                            }
                        }

                    }
                }
            }


            //将小数部分加上s3中定义的字符生成大写字串
            string tmpxsStr = "";
            if (xs != 0M)
            {
                for (i = 0; i < s33.Length; i++)
                {
                    //tmpxsStr = tmpxsStr & s33(i) & s3(i)
                    if (s33[i] == "0")
                    {
                        if (i < s33.Length - 1)
                        {
                            if (s33[i + 1] != "0") //如果不为零就加上零,如果是,就不加了
                            {
                                tmpxsStr = tmpxsStr + s1[int.Parse(s33[i])];
                            }
                        }
                        else //最后了
                        {
                            //什么也不加
                        }
                    }
                    else
                    {
                        tmpxsStr = tmpxsStr + s1[int.Parse(s33[i])] + s3[i];
                    }
                    //If CInt(s33(i)) = 0 Then
                    //    If i < s33.Length - 1 And zs <> 0 Then
                    //        tmpxsStr = tmpxsStr & s1(CInt(s33(i)))
                    //    End If
                    //Else
                    //    tmpxsStr = tmpxsStr & s1(CInt(s33(i))) & s3(i)
                    //End If
                    //tmpxsStr = tmpxsStr & s1(CInt(s33(i))) & s3(i)
                }
            }

            string tmpxsd = "";

            if (zs != 0M && xs == 0M)
            {
                tmpxsd = "整";
            }

            //Dim tmpStr As String = Replace(tmpzsStr & tmpxsd & tmpxsStr, "壹拾", "拾")
            string tmpStr = tmpzsStr + tmpxsd + tmpxsStr;
            return tmpStr;
        }

        private void btnToNewLine_Click(object sender, EventArgs e)
        {
            //bmk 字符转换行

            //txt1.Text = txt1.Text.Replace(";",Environment.NewLine);
            //txt1.Text = txt1.Text.Replace(Environment.NewLine,";");
            //textBox1.Text = string.Concat(Enumerable.Repeat(Environment.NewLine, 20));
            if (string.IsNullOrEmpty(txtStringX.Text))
            {
                return;
            }
            txt1.Text = txt1.Text.Replace(txtStringX.Text.Trim(),string.Concat(Enumerable.Repeat(Environment.NewLine, (int)numericUpDownWrap.Value)));


        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStringX.Text))
            {
                return;
            }
            txt1.Text = txt1.Text.Replace(string.Concat(Enumerable.Repeat(Environment.NewLine, (int)numericUpDownWrap.Value)), txtStringX.Text.Trim());

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStringX.Text))
            {
                MessageBox.Show("您要删除什么字符呢？请在下面输入.");
                return;
            }
            txt1.Text = txt1.Text.Replace(txtStringX.Text, "");//bmk 删除指定字符
        }

        private void lblGetFolderN_Click(object sender, EventArgs e)
        {
            string[] strArr = GetDirectories(txtFolderPath.Text);
            txt1.Text = string.Join(Environment.NewLine, strArr);

        }

        public static string[] GetDirectories(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] dirNames = new string[dirs.Length];
            for (int i = 0; i < dirs.Length; i++)
            {
                dirNames[i] = new DirectoryInfo(dirs[i]).Name;
            }

            return dirNames;

        }

        private void txtFolderPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.txtFolderPath.Cursor = System.Windows.Forms.Cursors.Arrow;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtFolderPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.txtFolderPath.Text = files[0];
            if (chkFullDir.Checked)
            {
                string folderPath = txtFolderPath.Text;

                if (Directory.Exists(folderPath))
                {
                    try
                    {
                        // Get all directories in the specified path
                        string[] directories = Directory.GetDirectories(folderPath);

                        // Clear the TextBox before adding new content
                        txt1.Clear();

                        // Append each directory path to the TextBox
                        foreach (string directory in directories)
                        {
                            txt1.AppendText(directory + Environment.NewLine);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("检查指定目录是否存在！");
                }

            }
        }

        private void txt1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the index of the line where the mouse was double-clicked
            int index = txt1.GetLineFromCharIndex(txt1.GetCharIndexFromPosition(e.Location));

            if (index >= 0)
            {
                // Get the content of the clicked line
                string line = txt1.Lines[index];
                // Trim leading and trailing whitespace
                string trimmedLine = line.Trim();

                // Copy to clipboard
                Clipboard.SetText(trimmedLine);
            }
        }
    }
}