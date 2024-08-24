namespace GetName
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.chkExtension = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSysInfo = new System.Windows.Forms.TextBox();
            this.dateTP1 = new System.Windows.Forms.DateTimePicker();
            this.dateTP2 = new System.Windows.Forms.DateTimePicker();
            this.btnCalcDay = new System.Windows.Forms.Button();
            this.txtCalcDay = new System.Windows.Forms.TextBox();
            this.txtDay1 = new System.Windows.Forms.TextBox();
            this.txtDay2 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerCgIcon = new System.Windows.Forms.Timer(this.components);
            this.chkPath = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnRetain = new System.Windows.Forms.Button();
            this.txtRetain = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblPer = new System.Windows.Forms.Label();
            this.lblGetFolderN = new System.Windows.Forms.Label();
            this.btnRecover = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.bkgWorkerDrag = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCreatePath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblOpenPath = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnGetName = new System.Windows.Forms.Button();
            this.lblClear = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtPyFirst = new System.Windows.Forms.Button();
            this.btnToMoney = new System.Windows.Forms.Button();
            this.txtStringX = new System.Windows.Forms.TextBox();
            this.btnToNewLine = new System.Windows.Forms.Button();
            this.btnTo = new System.Windows.Forms.Button();
            this.numericUpDownWrap = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWrap)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(23, 48);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(85, 23);
            this.btnFolder.TabIndex = 0;
            this.btnFolder.Text = "选择文件夹";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txt1
            // 
            this.txt1.AllowDrop = true;
            this.txt1.Location = new System.Drawing.Point(114, 48);
            this.txt1.MaxLength = 999999999;
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt1.Size = new System.Drawing.Size(620, 349);
            this.txt1.TabIndex = 1;
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            this.txt1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt1_DragDrop);
            this.txt1.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt1_DragEnter);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(23, 374);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(82, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // chkExtension
            // 
            this.chkExtension.AutoSize = true;
            this.chkExtension.Checked = true;
            this.chkExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtension.Location = new System.Drawing.Point(23, 100);
            this.chkExtension.Name = "chkExtension";
            this.chkExtension.Size = new System.Drawing.Size(60, 16);
            this.chkExtension.TabIndex = 3;
            this.chkExtension.Text = "扩展名";
            this.chkExtension.UseVisualStyleBackColor = true;
            this.chkExtension.CheckedChanged += new System.EventHandler(this.chkExtension_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "系统信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSysInfo
            // 
            this.txtSysInfo.Location = new System.Drawing.Point(114, 481);
            this.txtSysInfo.Multiline = true;
            this.txtSysInfo.Name = "txtSysInfo";
            this.txtSysInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSysInfo.Size = new System.Drawing.Size(272, 64);
            this.txtSysInfo.TabIndex = 5;
            // 
            // dateTP1
            // 
            this.dateTP1.Location = new System.Drawing.Point(405, 454);
            this.dateTP1.Name = "dateTP1";
            this.dateTP1.Size = new System.Drawing.Size(122, 21);
            this.dateTP1.TabIndex = 6;
            this.dateTP1.ValueChanged += new System.EventHandler(this.dateTP1_ValueChanged);
            // 
            // dateTP2
            // 
            this.dateTP2.Location = new System.Drawing.Point(556, 454);
            this.dateTP2.Name = "dateTP2";
            this.dateTP2.Size = new System.Drawing.Size(121, 21);
            this.dateTP2.TabIndex = 7;
            this.dateTP2.ValueChanged += new System.EventHandler(this.dateTP2_ValueChanged);
            // 
            // btnCalcDay
            // 
            this.btnCalcDay.Location = new System.Drawing.Point(405, 522);
            this.btnCalcDay.Name = "btnCalcDay";
            this.btnCalcDay.Size = new System.Drawing.Size(75, 23);
            this.btnCalcDay.TabIndex = 8;
            this.btnCalcDay.Text = "日期差";
            this.btnCalcDay.UseVisualStyleBackColor = true;
            this.btnCalcDay.Click += new System.EventHandler(this.btnCalcDay_Click);
            // 
            // txtCalcDay
            // 
            this.txtCalcDay.Location = new System.Drawing.Point(486, 523);
            this.txtCalcDay.Name = "txtCalcDay";
            this.txtCalcDay.Size = new System.Drawing.Size(100, 21);
            this.txtCalcDay.TabIndex = 9;
            this.txtCalcDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDay1
            // 
            this.txtDay1.Location = new System.Drawing.Point(405, 481);
            this.txtDay1.Name = "txtDay1";
            this.txtDay1.Size = new System.Drawing.Size(122, 21);
            this.txtDay1.TabIndex = 10;
            // 
            // txtDay2
            // 
            this.txtDay2.Location = new System.Drawing.Point(556, 481);
            this.txtDay2.Name = "txtDay2";
            this.txtDay2.Size = new System.Drawing.Size(121, 21);
            this.txtDay2.TabIndex = 11;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "GetName";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.退出ToolStripMenuItem.Text = "退出(&E)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "offlineIcon2.ico");
            this.imageList1.Images.SetKeyName(1, "onlineIcon2.ico");
            this.imageList1.Images.SetKeyName(2, "onlineIcon3.ico");
            // 
            // timerCgIcon
            // 
            this.timerCgIcon.Enabled = true;
            this.timerCgIcon.Interval = 1000;
            this.timerCgIcon.Tick += new System.EventHandler(this.timerCgIcon_Tick);
            // 
            // chkPath
            // 
            this.chkPath.AutoSize = true;
            this.chkPath.Location = new System.Drawing.Point(23, 160);
            this.chkPath.Name = "chkPath";
            this.chkPath.Size = new System.Drawing.Size(78, 16);
            this.chkPath.TabIndex = 12;
            this.chkPath.Text = "文件路径 ";
            this.toolTip1.SetToolTip(this.chkPath, "针对选择2个文件或以上的情况");
            this.chkPath.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(711, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "V3.5";
            this.toolTip1.SetToolTip(this.label1, "2023.08.19 文件夹名");
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(23, 191);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(82, 23);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.Text = "过滤包含词";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(23, 220);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(82, 21);
            this.txtFilter.TabIndex = 15;
            // 
            // btnRetain
            // 
            this.btnRetain.Location = new System.Drawing.Point(23, 247);
            this.btnRetain.Name = "btnRetain";
            this.btnRetain.Size = new System.Drawing.Size(82, 23);
            this.btnRetain.TabIndex = 16;
            this.btnRetain.Text = "保留包含词";
            this.btnRetain.UseVisualStyleBackColor = true;
            this.btnRetain.Click += new System.EventHandler(this.btnRetain_Click);
            // 
            // txtRetain
            // 
            this.txtRetain.Location = new System.Drawing.Point(23, 276);
            this.txtRetain.Name = "txtRetain";
            this.txtRetain.Size = new System.Drawing.Size(82, 21);
            this.txtRetain.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Image = global::GetName.Properties.Resources.stop;
            this.label2.Location = new System.Drawing.Point(716, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 28;
            this.toolTip1.SetToolTip(this.label2, "取消操作");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(683, 401);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(0, 12);
            this.lblPer.TabIndex = 29;
            this.toolTip1.SetToolTip(this.lblPer, "可创建目录2020年02月15日 byQQ625999210");
            // 
            // lblGetFolderN
            // 
            this.lblGetFolderN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGetFolderN.Image = global::GetName.Properties.Resources.tagmark49;
            this.lblGetFolderN.Location = new System.Drawing.Point(738, 15);
            this.lblGetFolderN.Name = "lblGetFolderN";
            this.lblGetFolderN.Size = new System.Drawing.Size(16, 16);
            this.lblGetFolderN.TabIndex = 37;
            this.toolTip1.SetToolTip(this.lblGetFolderN, "获取文件夹名");
            this.lblGetFolderN.Click += new System.EventHandler(this.lblGetFolderN_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(23, 336);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(82, 23);
            this.btnRecover.TabIndex = 18;
            this.btnRecover.Text = "恢复原数据";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblInfo.Location = new System.Drawing.Point(247, 424);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 12);
            this.lblInfo.TabIndex = 19;
            // 
            // lblTop
            // 
            this.lblTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTop.Image = global::GetName.Properties.Resources.red_pin;
            this.lblTop.Location = new System.Drawing.Point(709, 484);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(24, 23);
            this.lblTop.TabIndex = 20;
            this.lblTop.Click += new System.EventHandler(this.lblTop_Click);
            this.lblTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseUp);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(118, 424);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(0, 12);
            this.lblNum.TabIndex = 21;
            // 
            // bkgWorkerDrag
            // 
            this.bkgWorkerDrag.WorkerReportsProgress = true;
            this.bkgWorkerDrag.WorkerSupportsCancellation = true;
            this.bkgWorkerDrag.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorkerDrag_DoWork);
            this.bkgWorkerDrag.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.bkgWorkerDrag.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgWorkerDrag_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(114, 401);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(563, 12);
            this.progressBar1.TabIndex = 22;
            // 
            // btnCreatePath
            // 
            this.btnCreatePath.Location = new System.Drawing.Point(114, 551);
            this.btnCreatePath.Name = "btnCreatePath";
            this.btnCreatePath.Size = new System.Drawing.Size(75, 23);
            this.btnCreatePath.TabIndex = 23;
            this.btnCreatePath.Text = "创建路径";
            this.btnCreatePath.UseVisualStyleBackColor = true;
            this.btnCreatePath.Click += new System.EventHandler(this.btnCreatePath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(196, 552);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(481, 21);
            this.txtPath.TabIndex = 24;
            // 
            // lblOpenPath
            // 
            this.lblOpenPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOpenPath.Enabled = false;
            this.lblOpenPath.Image = global::GetName.Properties.Resources.tagmark12;
            this.lblOpenPath.Location = new System.Drawing.Point(683, 552);
            this.lblOpenPath.Name = "lblOpenPath";
            this.lblOpenPath.Size = new System.Drawing.Size(24, 23);
            this.lblOpenPath.TabIndex = 25;
            this.lblOpenPath.Click += new System.EventHandler(this.lblOpenPath_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.AllowDrop = true;
            this.txtFolderPath.Location = new System.Drawing.Point(23, 12);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(617, 21);
            this.txtFolderPath.TabIndex = 26;
            this.txtFolderPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragDrop);
            this.txtFolderPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragEnter);
            // 
            // btnGetName
            // 
            this.btnGetName.BackColor = System.Drawing.Color.Gold;
            this.btnGetName.Location = new System.Drawing.Point(646, 12);
            this.btnGetName.Name = "btnGetName";
            this.btnGetName.Size = new System.Drawing.Size(64, 23);
            this.btnGetName.TabIndex = 27;
            this.btnGetName.Text = "获取";
            this.btnGetName.UseVisualStyleBackColor = false;
            this.btnGetName.Click += new System.EventHandler(this.btnGetName_Click);
            // 
            // lblClear
            // 
            this.lblClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClear.Image = global::GetName.Properties.Resources.Clear1;
            this.lblClear.Location = new System.Drawing.Point(710, 452);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(24, 23);
            this.lblClear.TabIndex = 28;
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // txtPyFirst
            // 
            this.txtPyFirst.Location = new System.Drawing.Point(311, 452);
            this.txtPyFirst.Name = "txtPyFirst";
            this.txtPyFirst.Size = new System.Drawing.Size(75, 23);
            this.txtPyFirst.TabIndex = 30;
            this.txtPyFirst.Text = "首字母";
            this.txtPyFirst.UseVisualStyleBackColor = true;
            this.txtPyFirst.Click += new System.EventHandler(this.txtPyFirst_Click);
            // 
            // btnToMoney
            // 
            this.btnToMoney.Location = new System.Drawing.Point(230, 452);
            this.btnToMoney.Name = "btnToMoney";
            this.btnToMoney.Size = new System.Drawing.Size(75, 23);
            this.btnToMoney.TabIndex = 30;
            this.btnToMoney.Text = "转金额";
            this.btnToMoney.UseVisualStyleBackColor = true;
            this.btnToMoney.Click += new System.EventHandler(this.btnToMoney_Click);
            // 
            // txtStringX
            // 
            this.txtStringX.Location = new System.Drawing.Point(23, 481);
            this.txtStringX.Name = "txtStringX";
            this.txtStringX.Size = new System.Drawing.Size(82, 21);
            this.txtStringX.TabIndex = 31;
            // 
            // btnToNewLine
            // 
            this.btnToNewLine.Location = new System.Drawing.Point(23, 502);
            this.btnToNewLine.Name = "btnToNewLine";
            this.btnToNewLine.Size = new System.Drawing.Size(82, 23);
            this.btnToNewLine.TabIndex = 32;
            this.btnToNewLine.Text = "字符→换行";
            this.btnToNewLine.UseVisualStyleBackColor = true;
            this.btnToNewLine.Click += new System.EventHandler(this.btnToNewLine_Click);
            // 
            // btnTo
            // 
            this.btnTo.Location = new System.Drawing.Point(23, 525);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(82, 23);
            this.btnTo.TabIndex = 33;
            this.btnTo.Text = "换行→字符";
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // numericUpDownWrap
            // 
            this.numericUpDownWrap.Font = new System.Drawing.Font("宋体", 9F);
            this.numericUpDownWrap.Location = new System.Drawing.Point(62, 555);
            this.numericUpDownWrap.Name = "numericUpDownWrap";
            this.numericUpDownWrap.Size = new System.Drawing.Size(43, 21);
            this.numericUpDownWrap.TabIndex = 34;
            this.numericUpDownWrap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownWrap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "换行数";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(23, 452);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(82, 23);
            this.btnDel.TabIndex = 36;
            this.btnDel.Text = "删除字符↓";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnGetName;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(759, 581);
            this.Controls.Add(this.lblGetFolderN);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.numericUpDownWrap);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.btnToNewLine);
            this.Controls.Add(this.txtStringX);
            this.Controls.Add(this.btnToMoney);
            this.Controls.Add(this.txtPyFirst);
            this.Controls.Add(this.lblPer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.btnGetName);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lblOpenPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnCreatePath);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.txtRetain);
            this.Controls.Add(this.btnRetain);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPath);
            this.Controls.Add(this.txtDay2);
            this.Controls.Add(this.txtDay1);
            this.Controls.Add(this.txtCalcDay);
            this.Controls.Add(this.btnCalcDay);
            this.Controls.Add(this.dateTP2);
            this.Controls.Add(this.dateTP1);
            this.Controls.Add(this.txtSysInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkExtension);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetName2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWrap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox chkExtension;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSysInfo;
        private System.Windows.Forms.DateTimePicker dateTP1;
        private System.Windows.Forms.DateTimePicker dateTP2;
        private System.Windows.Forms.Button btnCalcDay;
        private System.Windows.Forms.TextBox txtCalcDay;
        private System.Windows.Forms.TextBox txtDay1;
        private System.Windows.Forms.TextBox txtDay2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnRetain;
        private System.Windows.Forms.TextBox txtRetain;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Timer timerCgIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblNum;
        private System.ComponentModel.BackgroundWorker bkgWorkerDrag;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCreatePath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblOpenPath;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnGetName;
        private System.Windows.Forms.Label lblClear;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.Button txtPyFirst;
        private System.Windows.Forms.Button btnToMoney;
        private System.Windows.Forms.TextBox txtStringX;
        private System.Windows.Forms.Button btnToNewLine;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.NumericUpDown numericUpDownWrap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblGetFolderN;
    }
}

