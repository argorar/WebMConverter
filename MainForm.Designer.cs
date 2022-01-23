using System.Collections;
using WebMConverter.Objects;

namespace WebMConverter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TableLayoutPanel tableMainForm;
            System.Windows.Forms.GroupBox groupMain;
            System.Windows.Forms.TableLayoutPanel tableMain;
            System.Windows.Forms.Label labelInputFile;
            System.Windows.Forms.Label labelOutputFile;
            System.Windows.Forms.Button buttonBrowseOut;
            System.Windows.Forms.TabControl tabControlOptions;
            System.Windows.Forms.TabPage tabProcessing;
            System.Windows.Forms.TableLayoutPanel tableProcessing;
            System.Windows.Forms.ToolStrip toolStripProcessing;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.Panel panelProcessingInput;
            System.Windows.Forms.TabPage tabEncoding;
            System.Windows.Forms.TableLayoutPanel tableEncoding;
            System.Windows.Forms.GroupBox groupEncodingGeneral;
            System.Windows.Forms.TableLayoutPanel tableEncodingGeneral;
            System.Windows.Forms.Label labelGeneralModeVariableHint;
            System.Windows.Forms.Label labelGeneralModeConstantHint;
            System.Windows.Forms.Label labelGeneralMode;
            System.Windows.Forms.Label labelGeneralTitle;
            System.Windows.Forms.Label labelGeneralTitleHint;
            System.Windows.Forms.GroupBox groupEncodingVideo;
            System.Windows.Forms.Panel panelEncodingModeSwapper;
            System.Windows.Forms.Label labelVideoSizeLimit;
            System.Windows.Forms.Label labelVideoSizeLimitUnit;
            System.Windows.Forms.Label labelVideoBitrate;
            System.Windows.Forms.Label labelVideoBitrateUnit;
            System.Windows.Forms.Label labelVideoBitrateHint;
            System.Windows.Forms.Label labelVideoCrf;
            System.Windows.Forms.Label labelVideoCrfHint;
            System.Windows.Forms.Label labelVideoCrfTolerance;
            System.Windows.Forms.Label labelVideoCrfToleranceHint;
            System.Windows.Forms.GroupBox groupEncodingAudio;
            System.Windows.Forms.TableLayoutPanel tableEncodingAudio;
            System.Windows.Forms.Label labelAudioHint;
            System.Windows.Forms.Panel panelEncodingModeSwapperTwo;
            System.Windows.Forms.Label labelAudioBitrate;
            System.Windows.Forms.Label labelAudioBitrateUnit;
            System.Windows.Forms.Label labelAudioBitrateHint;
            System.Windows.Forms.Label labelAudioQuality;
            System.Windows.Forms.Label labelAudioQualityHint;
            System.Windows.Forms.TabPage tabAdvanced;
            System.Windows.Forms.TableLayoutPanel tableAdvanced;
            System.Windows.Forms.GroupBox groupAdvancedProcessing;
            System.Windows.Forms.TableLayoutPanel tableAdvancedProcessing;
            System.Windows.Forms.Label labelProcessingLevels;
            System.Windows.Forms.GroupBox groupAdvancedEncoding;
            System.Windows.Forms.TableLayoutPanel tableAdvancedEncoding;
            System.Windows.Forms.Label labelEncodingFrameRateHint;
            System.Windows.Forms.Label labelEncodingFrameRate;
            System.Windows.Forms.Label labelEncodingNGOVHint;
            System.Windows.Forms.Label labelEncodingThreads;
            System.Windows.Forms.Label labelEncodingThreadsHint;
            System.Windows.Forms.Label labelEncodingSlices;
            System.Windows.Forms.Label labelEncodingSlicesHint;
            System.Windows.Forms.Label labelEncodingArguments;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.StatusStrip statusStrip;
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.buttonBrowseIn = new System.Windows.Forms.Button();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonTrim = new System.Windows.Forms.ToolStripSplitButton();
            this.buttonMultipleTrim = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCrop = new System.Windows.Forms.ToolStripButton();
            this.buttonResize = new System.Windows.Forms.ToolStripButton();
            this.buttonSubtitle = new System.Windows.Forms.ToolStripButton();
            this.buttonReverse = new System.Windows.Forms.ToolStripButton();
            this.buttonOverlay = new System.Windows.Forms.ToolStripButton();
            this.buttonCaption = new System.Windows.Forms.ToolStripButton();
            this.boxAdvancedScripting = new System.Windows.Forms.ToolStripButton();
            this.buttonExportProcessing = new System.Windows.Forms.ToolStripButton();
            this.buttonPreview = new System.Windows.Forms.ToolStripButton();
            this.buttonDub = new System.Windows.Forms.ToolStripButton();
            this.buttonRate = new System.Windows.Forms.ToolStripButton();
            this.buttonRotate = new System.Windows.Forms.ToolStripButton();
            this.buttonFade = new System.Windows.Forms.ToolStripButton();
            this.listViewProcessingScript = new System.Windows.Forms.ListView();
            this.imageListFilters = new System.Windows.Forms.ImageList(this.components);
            this.textBoxProcessingScript = new System.Windows.Forms.TextBox();
            this.buttonVariableDefault = new System.Windows.Forms.Button();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.boxConstant = new System.Windows.Forms.RadioButton();
            this.boxVariable = new System.Windows.Forms.RadioButton();
            this.buttonConstantDefault = new System.Windows.Forms.Button();
            this.tableLayoutPanelEncodingVideo = new System.Windows.Forms.TableLayoutPanel();
            this.tableVideoConstantOptions = new System.Windows.Forms.TableLayoutPanel();
            this.boxLimit = new System.Windows.Forms.TextBox();
            this.boxBitrate = new System.Windows.Forms.TextBox();
            this.labelSizeLimit = new System.Windows.Forms.Label();
            this.tableVideoVariableOptions = new System.Windows.Forms.TableLayoutPanel();
            this.numericCrf = new System.Windows.Forms.NumericUpDown();
            this.numericCrfTolerance = new System.Windows.Forms.NumericUpDown();
            this.boxHQ = new System.Windows.Forms.CheckBox();
            this.checkMP4 = new System.Windows.Forms.CheckBox();
            this.checkHWAcceleration = new System.Windows.Forms.CheckBox();
            this.boxAudio = new System.Windows.Forms.CheckBox();
            this.tableAudioConstantOptions = new System.Windows.Forms.TableLayoutPanel();
            this.boxAudioBitrate = new System.Windows.Forms.TextBox();
            this.tableAudioVariableOptions = new System.Windows.Forms.TableLayoutPanel();
            this.numericAudioQuality = new System.Windows.Forms.NumericUpDown();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.lblDelay = new System.Windows.Forms.Label();
            this.comboLevels = new System.Windows.Forms.ComboBox();
            this.boxDeinterlace = new System.Windows.Forms.CheckBox();
            this.boxLoop = new System.Windows.Forms.CheckBox();
            this.labelSaturation = new System.Windows.Forms.Label();
            this.numericGamma = new System.Windows.Forms.NumericUpDown();
            this.numericSaturation = new System.Windows.Forms.NumericUpDown();
            this.labelGamma = new System.Windows.Forms.Label();
            this.boxDenoise = new System.Windows.Forms.CheckBox();
            this.boxStabilization = new System.Windows.Forms.CheckBox();
            this.numericContrast = new System.Windows.Forms.NumericUpDown();
            this.labelContrast = new System.Windows.Forms.Label();
            this.buttonPreview2 = new System.Windows.Forms.Button();
            this.txtLevel = new System.Windows.Forms.Label();
            this.comboBoxLevels = new System.Windows.Forms.ComboBox();
            this.boxFrameRate = new System.Windows.Forms.TextBox();
            this.boxNGOV = new System.Windows.Forms.CheckBox();
            this.trackThreads = new System.Windows.Forms.TrackBar();
            this.labelThreads = new System.Windows.Forms.Label();
            this.trackSlices = new System.Windows.Forms.TrackBar();
            this.labelSlices = new System.Windows.Forms.Label();
            this.boxArguments = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonOpenPath = new System.Windows.Forms.Button();
            this.CRFother = new System.Windows.Forms.NumericUpDown();
            this.CRF4k = new System.Windows.Forms.NumericUpDown();
            this.lblCRFConfiguration2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCRFConfiguration = new System.Windows.Forms.Label();
            this.textPathDownloaded = new System.Windows.Forms.TextBox();
            this.buttonPathChange = new System.Windows.Forms.Button();
            this.lblPathDownload = new System.Windows.Forms.Label();
            this.labelMaintained = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupGfycat = new System.Windows.Forms.GroupBox();
            this.boxTags = new System.Windows.Forms.TextBox();
            this.labelTags = new System.Windows.Forms.Label();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblFollowers = new System.Windows.Forms.Label();
            this.lblViews = new System.Windows.Forms.Label();
            this.lblTotalGfys = new System.Windows.Forms.Label();
            this.lblPublicGfys = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelContainTheProgressBar = new System.Windows.Forms.Panel();
            this.boxIndexingProgressDetails = new System.Windows.Forms.CheckBox();
            this.boxIndexingProgress = new System.Windows.Forms.TextBox();
            this.labelIndexingProgress = new System.Windows.Forms.Label();
            this.progressBarIndexing = new System.Windows.Forms.ProgressBar();
            this.panelHideTheOptions = new System.Windows.Forms.Panel();
            this.listViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listViewContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtType = new System.Windows.Forms.Label();
            this.comboStabType = new System.Windows.Forms.ComboBox();
            tableMainForm = new System.Windows.Forms.TableLayoutPanel();
            groupMain = new System.Windows.Forms.GroupBox();
            tableMain = new System.Windows.Forms.TableLayoutPanel();
            labelInputFile = new System.Windows.Forms.Label();
            labelOutputFile = new System.Windows.Forms.Label();
            buttonBrowseOut = new System.Windows.Forms.Button();
            tabControlOptions = new System.Windows.Forms.TabControl();
            tabProcessing = new System.Windows.Forms.TabPage();
            tableProcessing = new System.Windows.Forms.TableLayoutPanel();
            toolStripProcessing = new System.Windows.Forms.ToolStrip();
            panelProcessingInput = new System.Windows.Forms.Panel();
            tabEncoding = new System.Windows.Forms.TabPage();
            tableEncoding = new System.Windows.Forms.TableLayoutPanel();
            groupEncodingGeneral = new System.Windows.Forms.GroupBox();
            tableEncodingGeneral = new System.Windows.Forms.TableLayoutPanel();
            labelGeneralModeVariableHint = new System.Windows.Forms.Label();
            labelGeneralModeConstantHint = new System.Windows.Forms.Label();
            labelGeneralMode = new System.Windows.Forms.Label();
            labelGeneralTitle = new System.Windows.Forms.Label();
            labelGeneralTitleHint = new System.Windows.Forms.Label();
            groupEncodingVideo = new System.Windows.Forms.GroupBox();
            panelEncodingModeSwapper = new System.Windows.Forms.Panel();
            labelVideoSizeLimit = new System.Windows.Forms.Label();
            labelVideoSizeLimitUnit = new System.Windows.Forms.Label();
            labelVideoBitrate = new System.Windows.Forms.Label();
            labelVideoBitrateUnit = new System.Windows.Forms.Label();
            labelVideoBitrateHint = new System.Windows.Forms.Label();
            labelVideoCrf = new System.Windows.Forms.Label();
            labelVideoCrfHint = new System.Windows.Forms.Label();
            labelVideoCrfTolerance = new System.Windows.Forms.Label();
            labelVideoCrfToleranceHint = new System.Windows.Forms.Label();
            groupEncodingAudio = new System.Windows.Forms.GroupBox();
            tableEncodingAudio = new System.Windows.Forms.TableLayoutPanel();
            labelAudioHint = new System.Windows.Forms.Label();
            panelEncodingModeSwapperTwo = new System.Windows.Forms.Panel();
            labelAudioBitrate = new System.Windows.Forms.Label();
            labelAudioBitrateUnit = new System.Windows.Forms.Label();
            labelAudioBitrateHint = new System.Windows.Forms.Label();
            labelAudioQuality = new System.Windows.Forms.Label();
            labelAudioQualityHint = new System.Windows.Forms.Label();
            tabAdvanced = new System.Windows.Forms.TabPage();
            tableAdvanced = new System.Windows.Forms.TableLayoutPanel();
            groupAdvancedProcessing = new System.Windows.Forms.GroupBox();
            tableAdvancedProcessing = new System.Windows.Forms.TableLayoutPanel();
            labelProcessingLevels = new System.Windows.Forms.Label();
            groupAdvancedEncoding = new System.Windows.Forms.GroupBox();
            tableAdvancedEncoding = new System.Windows.Forms.TableLayoutPanel();
            labelEncodingFrameRateHint = new System.Windows.Forms.Label();
            labelEncodingFrameRate = new System.Windows.Forms.Label();
            labelEncodingNGOVHint = new System.Windows.Forms.Label();
            labelEncodingThreads = new System.Windows.Forms.Label();
            labelEncodingThreadsHint = new System.Windows.Forms.Label();
            labelEncodingSlices = new System.Windows.Forms.Label();
            labelEncodingSlicesHint = new System.Windows.Forms.Label();
            labelEncodingArguments = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            tableMainForm.SuspendLayout();
            groupMain.SuspendLayout();
            tableMain.SuspendLayout();
            tabControlOptions.SuspendLayout();
            tabProcessing.SuspendLayout();
            tableProcessing.SuspendLayout();
            toolStripProcessing.SuspendLayout();
            panelProcessingInput.SuspendLayout();
            tabEncoding.SuspendLayout();
            tableEncoding.SuspendLayout();
            groupEncodingGeneral.SuspendLayout();
            tableEncodingGeneral.SuspendLayout();
            groupEncodingVideo.SuspendLayout();
            this.tableLayoutPanelEncodingVideo.SuspendLayout();
            panelEncodingModeSwapper.SuspendLayout();
            this.tableVideoConstantOptions.SuspendLayout();
            this.tableVideoVariableOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrfTolerance)).BeginInit();
            groupEncodingAudio.SuspendLayout();
            tableEncodingAudio.SuspendLayout();
            panelEncodingModeSwapperTwo.SuspendLayout();
            this.tableAudioConstantOptions.SuspendLayout();
            this.tableAudioVariableOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAudioQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            tabAdvanced.SuspendLayout();
            tableAdvanced.SuspendLayout();
            groupAdvancedProcessing.SuspendLayout();
            tableAdvancedProcessing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericContrast)).BeginInit();
            groupAdvancedEncoding.SuspendLayout();
            tableAdvancedEncoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlices)).BeginInit();
            this.tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CRFother)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRF4k)).BeginInit();
            this.groupGfycat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            statusStrip.SuspendLayout();
            this.panelContainTheProgressBar.SuspendLayout();
            this.panelHideTheOptions.SuspendLayout();
            this.listViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableMainForm
            // 
            tableMainForm.ColumnCount = 1;
            tableMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableMainForm.Controls.Add(groupMain, 0, 0);
            tableMainForm.Controls.Add(tabControlOptions, 0, 1);
            tableMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            tableMainForm.Location = new System.Drawing.Point(4, 4);
            tableMainForm.Margin = new System.Windows.Forms.Padding(4);
            tableMainForm.Name = "tableMainForm";
            tableMainForm.RowCount = 3;
            tableMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            tableMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableMainForm.Size = new System.Drawing.Size(1423, 545);
            tableMainForm.TabIndex = 0;
            // 
            // groupMain
            // 
            groupMain.Controls.Add(tableMain);
            groupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            groupMain.Location = new System.Drawing.Point(4, 4);
            groupMain.Margin = new System.Windows.Forms.Padding(4);
            groupMain.Name = "groupMain";
            groupMain.Padding = new System.Windows.Forms.Padding(4);
            groupMain.Size = new System.Drawing.Size(1415, 95);
            groupMain.TabIndex = 0;
            groupMain.TabStop = false;
            groupMain.Text = "Main";
            // 
            // tableMain
            // 
            tableMain.ColumnCount = 4;
            tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            tableMain.Controls.Add(labelInputFile, 0, 0);
            tableMain.Controls.Add(this.textBoxIn, 1, 0);
            tableMain.Controls.Add(this.buttonBrowseIn, 2, 0);
            tableMain.Controls.Add(labelOutputFile, 0, 1);
            tableMain.Controls.Add(this.textBoxOut, 1, 1);
            tableMain.Controls.Add(buttonBrowseOut, 2, 1);
            tableMain.Controls.Add(this.buttonGo, 3, 0);
            tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableMain.Location = new System.Drawing.Point(4, 19);
            tableMain.Margin = new System.Windows.Forms.Padding(4);
            tableMain.Name = "tableMain";
            tableMain.RowCount = 2;
            tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableMain.Size = new System.Drawing.Size(1407, 72);
            tableMain.TabIndex = 0;
            // 
            // labelInputFile
            // 
            labelInputFile.AutoSize = true;
            labelInputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            labelInputFile.Location = new System.Drawing.Point(4, 0);
            labelInputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelInputFile.Name = "labelInputFile";
            labelInputFile.Size = new System.Drawing.Size(84, 36);
            labelInputFile.TabIndex = 0;
            labelInputFile.Text = "Input file:";
            labelInputFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxIn
            // 
            this.textBoxIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIn.Location = new System.Drawing.Point(96, 7);
            this.textBoxIn.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.Size = new System.Drawing.Size(1101, 22);
            this.textBoxIn.TabIndex = 1;
            this.textBoxIn.Tag = "";
            this.textBoxIn.TextChanged += new System.EventHandler(this.textBoxIn_TextChanged);
            this.textBoxIn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxIn_KeyUp);
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBrowseIn.Location = new System.Drawing.Point(1205, 4);
            this.buttonBrowseIn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(95, 28);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Browse";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // labelOutputFile
            // 
            labelOutputFile.AutoSize = true;
            labelOutputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            labelOutputFile.Location = new System.Drawing.Point(4, 36);
            labelOutputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelOutputFile.Name = "labelOutputFile";
            labelOutputFile.Size = new System.Drawing.Size(84, 36);
            labelOutputFile.TabIndex = 0;
            labelOutputFile.Text = "Output file:";
            labelOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxOut
            // 
            this.textBoxOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOut.Location = new System.Drawing.Point(96, 43);
            this.textBoxOut.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(1101, 22);
            this.textBoxOut.TabIndex = 3;
            // 
            // buttonBrowseOut
            // 
            buttonBrowseOut.Dock = System.Windows.Forms.DockStyle.Fill;
            buttonBrowseOut.Location = new System.Drawing.Point(1205, 40);
            buttonBrowseOut.Margin = new System.Windows.Forms.Padding(4);
            buttonBrowseOut.Name = "buttonBrowseOut";
            buttonBrowseOut.Size = new System.Drawing.Size(95, 28);
            buttonBrowseOut.TabIndex = 4;
            buttonBrowseOut.Text = "Browse";
            buttonBrowseOut.UseVisualStyleBackColor = true;
            buttonBrowseOut.Click += new System.EventHandler(this.buttonBrowseOut_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGo.Enabled = false;
            this.buttonGo.Location = new System.Drawing.Point(1308, 4);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGo.Name = "buttonGo";
            tableMain.SetRowSpan(this.buttonGo, 2);
            this.buttonGo.Size = new System.Drawing.Size(95, 64);
            this.buttonGo.TabIndex = 5;
            this.buttonGo.Text = "Convert";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // tabControlOptions
            // 
            tabControlOptions.Controls.Add(tabProcessing);
            tabControlOptions.Controls.Add(tabEncoding);
            tabControlOptions.Controls.Add(tabAdvanced);
            tabControlOptions.Controls.Add(this.tabPage1);
            tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlOptions.Location = new System.Drawing.Point(4, 107);
            tabControlOptions.Margin = new System.Windows.Forms.Padding(4);
            tabControlOptions.Name = "tabControlOptions";
            tabControlOptions.SelectedIndex = 0;
            tabControlOptions.Size = new System.Drawing.Size(1415, 409);
            tabControlOptions.TabIndex = 1;
            // 
            // tabProcessing
            // 
            tabProcessing.Controls.Add(tableProcessing);
            tabProcessing.Location = new System.Drawing.Point(4, 25);
            tabProcessing.Margin = new System.Windows.Forms.Padding(4);
            tabProcessing.Name = "tabProcessing";
            tabProcessing.Padding = new System.Windows.Forms.Padding(4);
            tabProcessing.Size = new System.Drawing.Size(1407, 380);
            tabProcessing.TabIndex = 3;
            tabProcessing.Text = "Processing";
            // 
            // tableProcessing
            // 
            tableProcessing.ColumnCount = 1;
            tableProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableProcessing.Controls.Add(toolStripProcessing, 0, 0);
            tableProcessing.Controls.Add(panelProcessingInput, 0, 1);
            tableProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            tableProcessing.Location = new System.Drawing.Point(4, 4);
            tableProcessing.Margin = new System.Windows.Forms.Padding(4);
            tableProcessing.Name = "tableProcessing";
            tableProcessing.RowCount = 2;
            tableProcessing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            tableProcessing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableProcessing.Size = new System.Drawing.Size(1399, 372);
            tableProcessing.TabIndex = 0;
            // 
            // toolStripProcessing
            // 
            toolStripProcessing.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStripProcessing.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStripProcessing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonTrim,
            this.buttonCrop,
            this.buttonResize,
            this.buttonSubtitle,
            this.buttonReverse,
            this.buttonOverlay,
            this.buttonCaption,
            this.boxAdvancedScripting,
            this.buttonExportProcessing,
            this.buttonPreview,
            this.buttonDub,
            this.buttonRate,
            this.buttonRotate,
            this.buttonFade});
            toolStripProcessing.Location = new System.Drawing.Point(0, 0);
            toolStripProcessing.Name = "toolStripProcessing";
            toolStripProcessing.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStripProcessing.ShowItemToolTips = false;
            toolStripProcessing.Size = new System.Drawing.Size(1399, 25);
            toolStripProcessing.TabIndex = 0;
            toolStripProcessing.TabStop = true;
            // 
            // buttonTrim
            // 
            this.buttonTrim.AccessibleDescription = "Select a clip from your video.";
            this.buttonTrim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonMultipleTrim});
            this.buttonTrim.Enabled = false;
            this.buttonTrim.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.buttonTrim.Name = "buttonTrim";
            this.buttonTrim.Size = new System.Drawing.Size(46, 22);
            this.buttonTrim.Text = "Trim";
            this.buttonTrim.ButtonClick += new System.EventHandler(this.buttonTrim_Click);
            this.buttonTrim.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonTrim.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonMultipleTrim
            // 
            this.buttonMultipleTrim.AccessibleDescription = "Select many clips from your video, and sort them on a timeline.";
            this.buttonMultipleTrim.Name = "buttonMultipleTrim";
            this.buttonMultipleTrim.Size = new System.Drawing.Size(144, 22);
            this.buttonMultipleTrim.Text = "Multiple Trim";
            this.buttonMultipleTrim.Click += new System.EventHandler(this.buttonMultipleTrim_Click);
            this.buttonMultipleTrim.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonMultipleTrim.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonCrop
            // 
            this.buttonCrop.AccessibleDescription = "Crop your video into a smaller frame.";
            this.buttonCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonCrop.Enabled = false;
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(37, 22);
            this.buttonCrop.Text = "Crop";
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            this.buttonCrop.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonCrop.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonResize
            // 
            this.buttonResize.AccessibleDescription = "Scale your video.";
            this.buttonResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonResize.Enabled = false;
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(43, 22);
            this.buttonResize.Text = "Resize";
            this.buttonResize.Click += new System.EventHandler(this.buttonResize_Click);
            this.buttonResize.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonResize.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonSubtitle
            // 
            this.buttonSubtitle.AccessibleDescription = "Burn subtitles into the video.";
            this.buttonSubtitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonSubtitle.Enabled = false;
            this.buttonSubtitle.Name = "buttonSubtitle";
            this.buttonSubtitle.Size = new System.Drawing.Size(56, 22);
            this.buttonSubtitle.Text = "Subtitles";
            this.buttonSubtitle.Click += new System.EventHandler(this.buttonSubtitle_Click);
            this.buttonSubtitle.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonSubtitle.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonReverse
            // 
            this.buttonReverse.AccessibleDescription = "Everything is backwards!";
            this.buttonReverse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonReverse.Enabled = false;
            this.buttonReverse.Name = "buttonReverse";
            this.buttonReverse.Size = new System.Drawing.Size(51, 22);
            this.buttonReverse.Text = "Reverse";
            this.buttonReverse.Click += new System.EventHandler(this.buttonReverse_Click);
            this.buttonReverse.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonReverse.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonOverlay
            // 
            this.buttonOverlay.AccessibleDescription = "Overlay a picture on top of your video.";
            this.buttonOverlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonOverlay.Enabled = false;
            this.buttonOverlay.Name = "buttonOverlay";
            this.buttonOverlay.Size = new System.Drawing.Size(51, 22);
            this.buttonOverlay.Text = "Overlay";
            this.buttonOverlay.Click += new System.EventHandler(this.buttonOverlay_Click);
            this.buttonOverlay.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonOverlay.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonCaption
            // 
            this.buttonCaption.AccessibleDescription = "Add some funny text to your video.";
            this.buttonCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonCaption.Enabled = false;
            this.buttonCaption.Name = "buttonCaption";
            this.buttonCaption.Size = new System.Drawing.Size(53, 22);
            this.buttonCaption.Text = "Caption";
            this.buttonCaption.Click += new System.EventHandler(this.buttonCaption_Click);
            this.buttonCaption.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonCaption.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // boxAdvancedScripting
            // 
            this.boxAdvancedScripting.AccessibleDescription = "Are you a bad enough dude? Take care, there is no way back. You will have to star" +
    "t over if you fuck up.";
            this.boxAdvancedScripting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.boxAdvancedScripting.Name = "boxAdvancedScripting";
            this.boxAdvancedScripting.Size = new System.Drawing.Size(64, 22);
            this.boxAdvancedScripting.Text = "Advanced";
            this.boxAdvancedScripting.Click += new System.EventHandler(this.boxAdvancedScripting_Click);
            this.boxAdvancedScripting.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.boxAdvancedScripting.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonExportProcessing
            // 
            this.buttonExportProcessing.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonExportProcessing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonExportProcessing.Enabled = false;
            this.buttonExportProcessing.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportProcessing.Image")));
            this.buttonExportProcessing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExportProcessing.Name = "buttonExportProcessing";
            this.buttonExportProcessing.Size = new System.Drawing.Size(45, 22);
            this.buttonExportProcessing.Text = "Export";
            this.buttonExportProcessing.Click += new System.EventHandler(this.buttonExportProcessing_Click);
            // 
            // buttonPreview
            // 
            this.buttonPreview.AccessibleDescription = "Open a preview window that will loop your processing settings. Note that this doe" +
    "sn\'t reflect output encoding quality.";
            this.buttonPreview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonPreview.Enabled = false;
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(84, 22);
            this.buttonPreview.Text = "Preview filters";
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            this.buttonPreview.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonPreview.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonDub
            // 
            this.buttonDub.AccessibleDescription = "Add or replace the audio on your video.";
            this.buttonDub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDub.Enabled = false;
            this.buttonDub.Name = "buttonDub";
            this.buttonDub.Size = new System.Drawing.Size(33, 22);
            this.buttonDub.Text = "Dub";
            this.buttonDub.Click += new System.EventHandler(this.buttonDub_Click);
            this.buttonDub.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonDub.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonRate
            // 
            this.buttonRate.AccessibleDescription = "Speed up or slow down your video.";
            this.buttonRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonRate.Enabled = false;
            this.buttonRate.Name = "buttonRate";
            this.buttonRate.Size = new System.Drawing.Size(78, 22);
            this.buttonRate.Text = "Change Rate";
            this.buttonRate.Click += new System.EventHandler(this.buttonRate_Click);
            this.buttonRate.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonRate.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonRotate
            // 
            this.buttonRotate.AccessibleDescription = "Rotate or flip your video.";
            this.buttonRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonRotate.Enabled = false;
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(45, 22);
            this.buttonRotate.Text = "Rotate";
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            this.buttonRotate.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonRotate.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // buttonFade
            // 
            this.buttonFade.AccessibleDescription = "Add fading effects to the start and/or end to your video.";
            this.buttonFade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonFade.Enabled = false;
            this.buttonFade.Name = "buttonFade";
            this.buttonFade.Size = new System.Drawing.Size(36, 22);
            this.buttonFade.Text = "Fade";
            this.buttonFade.Click += new System.EventHandler(this.buttonFade_Click);
            this.buttonFade.MouseEnter += new System.EventHandler(this.ToolStripItemTooltip);
            this.buttonFade.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // panelProcessingInput
            // 
            panelProcessingInput.Controls.Add(this.listViewProcessingScript);
            panelProcessingInput.Controls.Add(this.textBoxProcessingScript);
            panelProcessingInput.Dock = System.Windows.Forms.DockStyle.Fill;
            panelProcessingInput.Location = new System.Drawing.Point(0, 31);
            panelProcessingInput.Margin = new System.Windows.Forms.Padding(0);
            panelProcessingInput.Name = "panelProcessingInput";
            panelProcessingInput.Size = new System.Drawing.Size(1399, 341);
            panelProcessingInput.TabIndex = 1;
            // 
            // listViewProcessingScript
            // 
            this.listViewProcessingScript.AccessibleDescription = "Double click a filter to edit it. Select a filter and press Delete to remove it.";
            this.listViewProcessingScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProcessingScript.HideSelection = false;
            this.listViewProcessingScript.LargeImageList = this.imageListFilters;
            this.listViewProcessingScript.Location = new System.Drawing.Point(0, 0);
            this.listViewProcessingScript.Margin = new System.Windows.Forms.Padding(0);
            this.listViewProcessingScript.Name = "listViewProcessingScript";
            this.listViewProcessingScript.Size = new System.Drawing.Size(1399, 341);
            this.listViewProcessingScript.TabIndex = 3;
            this.listViewProcessingScript.UseCompatibleStateImageBehavior = false;
            this.listViewProcessingScript.ItemActivate += new System.EventHandler(this.listViewProcessingScript_ItemActivate);
            this.listViewProcessingScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProcessingScript_KeyDown);
            this.listViewProcessingScript.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewProcessingScript_KeyUp);
            this.listViewProcessingScript.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewProcessingScript_MouseClick);
            this.listViewProcessingScript.MouseEnter += new System.EventHandler(this.ControlTooltip);
            this.listViewProcessingScript.MouseLeave += new System.EventHandler(this.clearToolTip);
            // 
            // imageListFilters
            // 
            this.imageListFilters.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFilters.ImageStream")));
            this.imageListFilters.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFilters.Images.SetKeyName(0, "Trim");
            this.imageListFilters.Images.SetKeyName(1, "Crop");
            this.imageListFilters.Images.SetKeyName(2, "Subtitles");
            this.imageListFilters.Images.SetKeyName(3, "Reverse");
            this.imageListFilters.Images.SetKeyName(4, "Resize");
            this.imageListFilters.Images.SetKeyName(5, "Overlay");
            this.imageListFilters.Images.SetKeyName(6, "Caption");
            this.imageListFilters.Images.SetKeyName(7, "Dub");
            this.imageListFilters.Images.SetKeyName(8, "Rate");
            this.imageListFilters.Images.SetKeyName(9, "Fade");
            this.imageListFilters.Images.SetKeyName(10, "Rotate");
            // 
            // textBoxProcessingScript
            // 
            this.textBoxProcessingScript.AcceptsReturn = true;
            this.textBoxProcessingScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProcessingScript.Location = new System.Drawing.Point(0, 0);
            this.textBoxProcessingScript.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxProcessingScript.Multiline = true;
            this.textBoxProcessingScript.Name = "textBoxProcessingScript";
            this.textBoxProcessingScript.Size = new System.Drawing.Size(1399, 341);
            this.textBoxProcessingScript.TabIndex = 2;
            this.textBoxProcessingScript.Text = "# This is an AviSynth script. You may write advanced commands below, or just pres" +
    "s the buttons above for smooth sailing.";
            this.textBoxProcessingScript.Visible = false;
            this.textBoxProcessingScript.Leave += new System.EventHandler(this.textBoxProcessingScript_Leave);
            // 
            // tabEncoding
            // 
            tabEncoding.BackColor = System.Drawing.SystemColors.Control;
            tabEncoding.Controls.Add(tableEncoding);
            tabEncoding.Location = new System.Drawing.Point(4, 25);
            tabEncoding.Margin = new System.Windows.Forms.Padding(4);
            tabEncoding.Name = "tabEncoding";
            tabEncoding.Padding = new System.Windows.Forms.Padding(4);
            tabEncoding.Size = new System.Drawing.Size(1407, 380);
            tabEncoding.TabIndex = 0;
            tabEncoding.Text = "Encoding";
            // 
            // tableEncoding
            // 
            tableEncoding.ColumnCount = 1;
            tableEncoding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableEncoding.Controls.Add(groupEncodingGeneral, 0, 0);
            tableEncoding.Controls.Add(groupEncodingVideo, 0, 1);
            tableEncoding.Controls.Add(groupEncodingAudio, 0, 2);
            tableEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            tableEncoding.Location = new System.Drawing.Point(4, 4);
            tableEncoding.Margin = new System.Windows.Forms.Padding(4);
            tableEncoding.Name = "tableEncoding";
            tableEncoding.RowCount = 4;
            tableEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            tableEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            tableEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            tableEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableEncoding.Size = new System.Drawing.Size(1399, 372);
            tableEncoding.TabIndex = 0;
            // 
            // groupEncodingGeneral
            // 
            groupEncodingGeneral.Controls.Add(tableEncodingGeneral);
            groupEncodingGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            groupEncodingGeneral.Location = new System.Drawing.Point(4, 4);
            groupEncodingGeneral.Margin = new System.Windows.Forms.Padding(4);
            groupEncodingGeneral.Name = "groupEncodingGeneral";
            groupEncodingGeneral.Padding = new System.Windows.Forms.Padding(4);
            groupEncodingGeneral.Size = new System.Drawing.Size(1391, 124);
            groupEncodingGeneral.TabIndex = 1;
            groupEncodingGeneral.TabStop = false;
            groupEncodingGeneral.Text = "General";
            // 
            // tableEncodingGeneral
            // 
            tableEncodingGeneral.ColumnCount = 5;
            tableEncodingGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            tableEncodingGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            tableEncodingGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableEncodingGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            tableEncodingGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableEncodingGeneral.Controls.Add(this.buttonVariableDefault, 2, 2);
            tableEncodingGeneral.Controls.Add(labelGeneralModeVariableHint, 3, 2);
            tableEncodingGeneral.Controls.Add(labelGeneralModeConstantHint, 3, 1);
            tableEncodingGeneral.Controls.Add(labelGeneralMode, 0, 1);
            tableEncodingGeneral.Controls.Add(labelGeneralTitle, 0, 0);
            tableEncodingGeneral.Controls.Add(this.boxTitle, 1, 0);
            tableEncodingGeneral.Controls.Add(labelGeneralTitleHint, 4, 0);
            tableEncodingGeneral.Controls.Add(this.boxConstant, 1, 1);
            tableEncodingGeneral.Controls.Add(this.boxVariable, 1, 2);
            tableEncodingGeneral.Controls.Add(this.buttonConstantDefault, 2, 1);
            tableEncodingGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            tableEncodingGeneral.Location = new System.Drawing.Point(4, 19);
            tableEncodingGeneral.Margin = new System.Windows.Forms.Padding(4);
            tableEncodingGeneral.Name = "tableEncodingGeneral";
            tableEncodingGeneral.RowCount = 3;
            tableEncodingGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableEncodingGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableEncodingGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableEncodingGeneral.Size = new System.Drawing.Size(1383, 101);
            tableEncodingGeneral.TabIndex = 0;
            // 
            // buttonVariableDefault
            // 
            this.buttonVariableDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonVariableDefault.Location = new System.Drawing.Point(226, 72);
            this.buttonVariableDefault.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVariableDefault.Name = "buttonVariableDefault";
            this.buttonVariableDefault.Size = new System.Drawing.Size(72, 26);
            this.buttonVariableDefault.TabIndex = 5;
            this.buttonVariableDefault.Text = "Default";
            this.buttonVariableDefault.UseVisualStyleBackColor = true;
            this.buttonVariableDefault.Visible = false;
            this.buttonVariableDefault.Click += new System.EventHandler(this.buttonVariableDefault_Click);
            // 
            // labelGeneralModeVariableHint
            // 
            labelGeneralModeVariableHint.AutoSize = true;
            tableEncodingGeneral.SetColumnSpan(labelGeneralModeVariableHint, 2);
            labelGeneralModeVariableHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelGeneralModeVariableHint.Location = new System.Drawing.Point(306, 68);
            labelGeneralModeVariableHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelGeneralModeVariableHint.Name = "labelGeneralModeVariableHint";
            labelGeneralModeVariableHint.Size = new System.Drawing.Size(1073, 34);
            labelGeneralModeVariableHint.TabIndex = 0;
            labelGeneralModeVariableHint.Text = "This will make your video get the size it deserves to look good.";
            labelGeneralModeVariableHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGeneralModeConstantHint
            // 
            labelGeneralModeConstantHint.AutoSize = true;
            tableEncodingGeneral.SetColumnSpan(labelGeneralModeConstantHint, 2);
            labelGeneralModeConstantHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelGeneralModeConstantHint.Location = new System.Drawing.Point(306, 34);
            labelGeneralModeConstantHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelGeneralModeConstantHint.Name = "labelGeneralModeConstantHint";
            labelGeneralModeConstantHint.Size = new System.Drawing.Size(1073, 34);
            labelGeneralModeConstantHint.TabIndex = 0;
            labelGeneralModeConstantHint.Text = "This will make your video have a specific filesize, and suffer lower quality to m" +
    "atch that size.";
            labelGeneralModeConstantHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGeneralMode
            // 
            labelGeneralMode.AutoSize = true;
            labelGeneralMode.Dock = System.Windows.Forms.DockStyle.Fill;
            labelGeneralMode.Location = new System.Drawing.Point(4, 34);
            labelGeneralMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelGeneralMode.Name = "labelGeneralMode";
            labelGeneralMode.Size = new System.Drawing.Size(97, 34);
            labelGeneralMode.TabIndex = 0;
            labelGeneralMode.Text = "Mode:";
            labelGeneralMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGeneralTitle
            // 
            labelGeneralTitle.AutoSize = true;
            labelGeneralTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            labelGeneralTitle.Location = new System.Drawing.Point(4, 0);
            labelGeneralTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelGeneralTitle.Name = "labelGeneralTitle";
            labelGeneralTitle.Size = new System.Drawing.Size(97, 34);
            labelGeneralTitle.TabIndex = 0;
            labelGeneralTitle.Text = "Title:";
            labelGeneralTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxTitle
            // 
            this.boxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            tableEncodingGeneral.SetColumnSpan(this.boxTitle, 3);
            this.boxTitle.Location = new System.Drawing.Point(109, 6);
            this.boxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.Size = new System.Drawing.Size(520, 22);
            this.boxTitle.TabIndex = 1;
            this.boxTitle.TextChanged += new System.EventHandler(this.UpdateArguments);
            // 
            // labelGeneralTitleHint
            // 
            labelGeneralTitleHint.AutoSize = true;
            labelGeneralTitleHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelGeneralTitleHint.Location = new System.Drawing.Point(637, 0);
            labelGeneralTitleHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelGeneralTitleHint.Name = "labelGeneralTitleHint";
            labelGeneralTitleHint.Size = new System.Drawing.Size(742, 34);
            labelGeneralTitleHint.TabIndex = 0;
            labelGeneralTitleHint.Text = "Adds a string of text to the metadata of the video, which can be used to indicate" +
    " the source of a video, for example. Leave blank for no title.";
            labelGeneralTitleHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // boxConstant
            // 
            this.boxConstant.AutoSize = true;
            this.boxConstant.Checked = true;
            this.boxConstant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxConstant.Location = new System.Drawing.Point(109, 38);
            this.boxConstant.Margin = new System.Windows.Forms.Padding(4);
            this.boxConstant.Name = "boxConstant";
            this.boxConstant.Size = new System.Drawing.Size(109, 26);
            this.boxConstant.TabIndex = 2;
            this.boxConstant.TabStop = true;
            this.boxConstant.Text = "Constant";
            this.boxConstant.UseVisualStyleBackColor = true;
            this.boxConstant.CheckedChanged += new System.EventHandler(this.boxConstant_CheckedChanged);
            // 
            // boxVariable
            // 
            this.boxVariable.AutoSize = true;
            this.boxVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxVariable.Location = new System.Drawing.Point(109, 72);
            this.boxVariable.Margin = new System.Windows.Forms.Padding(4);
            this.boxVariable.Name = "boxVariable";
            this.boxVariable.Size = new System.Drawing.Size(109, 26);
            this.boxVariable.TabIndex = 3;
            this.boxVariable.Text = "Variable";
            this.boxVariable.UseVisualStyleBackColor = true;
            this.boxVariable.CheckedChanged += new System.EventHandler(this.boxVariable_CheckedChanged);
            // 
            // buttonConstantDefault
            // 
            this.buttonConstantDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConstantDefault.Location = new System.Drawing.Point(226, 38);
            this.buttonConstantDefault.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConstantDefault.Name = "buttonConstantDefault";
            this.buttonConstantDefault.Size = new System.Drawing.Size(72, 26);
            this.buttonConstantDefault.TabIndex = 4;
            this.buttonConstantDefault.Text = "Default";
            this.buttonConstantDefault.UseVisualStyleBackColor = true;
            this.buttonConstantDefault.Visible = false;
            this.buttonConstantDefault.Click += new System.EventHandler(this.buttonConstantDefault_Click);
            // 
            // groupEncodingVideo
            // 
            groupEncodingVideo.Controls.Add(this.tableLayoutPanelEncodingVideo);
            groupEncodingVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            groupEncodingVideo.Location = new System.Drawing.Point(4, 136);
            groupEncodingVideo.Margin = new System.Windows.Forms.Padding(4);
            groupEncodingVideo.Name = "groupEncodingVideo";
            groupEncodingVideo.Padding = new System.Windows.Forms.Padding(4);
            groupEncodingVideo.Size = new System.Drawing.Size(1391, 124);
            groupEncodingVideo.TabIndex = 2;
            groupEncodingVideo.TabStop = false;
            groupEncodingVideo.Text = "Video";
            // 
            // tableLayoutPanelEncodingVideo
            // 
            this.tableLayoutPanelEncodingVideo.ColumnCount = 5;
            this.tableLayoutPanelEncodingVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanelEncodingVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanelEncodingVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanelEncodingVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 641F));
            this.tableLayoutPanelEncodingVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 447F));
            this.tableLayoutPanelEncodingVideo.Controls.Add(panelEncodingModeSwapper, 0, 1);
            this.tableLayoutPanelEncodingVideo.Controls.Add(this.boxHQ, 0, 0);
            this.tableLayoutPanelEncodingVideo.Controls.Add(this.checkMP4, 3, 0);
            this.tableLayoutPanelEncodingVideo.Controls.Add(this.checkHWAcceleration, 4, 0);
            this.tableLayoutPanelEncodingVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEncodingVideo.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanelEncodingVideo.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelEncodingVideo.Name = "tableLayoutPanelEncodingVideo";
            this.tableLayoutPanelEncodingVideo.RowCount = 3;
            this.tableLayoutPanelEncodingVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelEncodingVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelEncodingVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelEncodingVideo.Size = new System.Drawing.Size(1383, 101);
            this.tableLayoutPanelEncodingVideo.TabIndex = 0;
            // 
            // panelEncodingModeSwapper
            // 
            this.tableLayoutPanelEncodingVideo.SetColumnSpan(panelEncodingModeSwapper, 4);
            panelEncodingModeSwapper.Controls.Add(this.tableVideoConstantOptions);
            panelEncodingModeSwapper.Controls.Add(this.tableVideoVariableOptions);
            panelEncodingModeSwapper.Dock = System.Windows.Forms.DockStyle.Fill;
            panelEncodingModeSwapper.Location = new System.Drawing.Point(0, 34);
            panelEncodingModeSwapper.Margin = new System.Windows.Forms.Padding(0);
            panelEncodingModeSwapper.Name = "panelEncodingModeSwapper";
            this.tableLayoutPanelEncodingVideo.SetRowSpan(panelEncodingModeSwapper, 2);
            panelEncodingModeSwapper.Size = new System.Drawing.Size(936, 68);
            panelEncodingModeSwapper.TabIndex = 2;
            // 
            // tableVideoConstantOptions
            // 
            this.tableVideoConstantOptions.ColumnCount = 5;
            this.tableVideoConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableVideoConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableVideoConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableVideoConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableVideoConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableVideoConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableVideoConstantOptions.Controls.Add(labelVideoSizeLimit, 0, 0);
            this.tableVideoConstantOptions.Controls.Add(this.boxLimit, 1, 0);
            this.tableVideoConstantOptions.Controls.Add(labelVideoSizeLimitUnit, 2, 0);
            this.tableVideoConstantOptions.Controls.Add(labelVideoBitrate, 0, 1);
            this.tableVideoConstantOptions.Controls.Add(this.boxBitrate, 1, 1);
            this.tableVideoConstantOptions.Controls.Add(labelVideoBitrateUnit, 2, 1);
            this.tableVideoConstantOptions.Controls.Add(labelVideoBitrateHint, 3, 1);
            this.tableVideoConstantOptions.Controls.Add(this.labelSizeLimit, 3, 0);
            this.tableVideoConstantOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableVideoConstantOptions.Location = new System.Drawing.Point(0, 0);
            this.tableVideoConstantOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tableVideoConstantOptions.Name = "tableVideoConstantOptions";
            this.tableVideoConstantOptions.RowCount = 2;
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableVideoConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableVideoConstantOptions.Size = new System.Drawing.Size(936, 68);
            this.tableVideoConstantOptions.TabIndex = 0;
            // 
            // labelVideoSizeLimit
            // 
            labelVideoSizeLimit.AutoSize = true;
            labelVideoSizeLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoSizeLimit.Location = new System.Drawing.Point(4, 0);
            labelVideoSizeLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoSizeLimit.Name = "labelVideoSizeLimit";
            labelVideoSizeLimit.Size = new System.Drawing.Size(97, 34);
            labelVideoSizeLimit.TabIndex = 0;
            labelVideoSizeLimit.Text = "Size limit:";
            labelVideoSizeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxLimit
            // 
            this.boxLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.boxLimit.Location = new System.Drawing.Point(109, 6);
            this.boxLimit.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.boxLimit.Name = "boxLimit";
            this.boxLimit.Size = new System.Drawing.Size(153, 22);
            this.boxLimit.TabIndex = 1;
            this.boxLimit.TextChanged += new System.EventHandler(this.UpdateArguments);
            this.boxLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumbersOnly);
            // 
            // labelVideoSizeLimitUnit
            // 
            labelVideoSizeLimitUnit.AutoSize = true;
            labelVideoSizeLimitUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoSizeLimitUnit.Location = new System.Drawing.Point(262, 0);
            labelVideoSizeLimitUnit.Margin = new System.Windows.Forms.Padding(0);
            labelVideoSizeLimitUnit.Name = "labelVideoSizeLimitUnit";
            labelVideoSizeLimitUnit.Size = new System.Drawing.Size(44, 34);
            labelVideoSizeLimitUnit.TabIndex = 0;
            labelVideoSizeLimitUnit.Text = "MiB";
            labelVideoSizeLimitUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVideoBitrate
            // 
            labelVideoBitrate.AutoSize = true;
            labelVideoBitrate.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoBitrate.Location = new System.Drawing.Point(4, 34);
            labelVideoBitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoBitrate.Name = "labelVideoBitrate";
            labelVideoBitrate.Size = new System.Drawing.Size(97, 34);
            labelVideoBitrate.TabIndex = 0;
            labelVideoBitrate.Text = "Bitrate:";
            labelVideoBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxBitrate
            // 
            this.boxBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.boxBitrate.Location = new System.Drawing.Point(109, 40);
            this.boxBitrate.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.boxBitrate.Name = "boxBitrate";
            this.boxBitrate.Size = new System.Drawing.Size(153, 22);
            this.boxBitrate.TabIndex = 2;
            this.boxBitrate.TextChanged += new System.EventHandler(this.UpdateArguments);
            this.boxBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumbersOnly);
            // 
            // labelVideoBitrateUnit
            // 
            labelVideoBitrateUnit.AutoSize = true;
            labelVideoBitrateUnit.Dock = System.Windows.Forms.DockStyle.Left;
            labelVideoBitrateUnit.Location = new System.Drawing.Point(262, 34);
            labelVideoBitrateUnit.Margin = new System.Windows.Forms.Padding(0);
            labelVideoBitrateUnit.Name = "labelVideoBitrateUnit";
            labelVideoBitrateUnit.Size = new System.Drawing.Size(34, 34);
            labelVideoBitrateUnit.TabIndex = 0;
            labelVideoBitrateUnit.Text = "kb/s";
            labelVideoBitrateUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVideoBitrateHint
            // 
            labelVideoBitrateHint.AutoSize = true;
            this.tableVideoConstantOptions.SetColumnSpan(labelVideoBitrateHint, 2);
            labelVideoBitrateHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoBitrateHint.Location = new System.Drawing.Point(310, 34);
            labelVideoBitrateHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoBitrateHint.Name = "labelVideoBitrateHint";
            labelVideoBitrateHint.Size = new System.Drawing.Size(622, 34);
            labelVideoBitrateHint.TabIndex = 0;
            labelVideoBitrateHint.Text = "Determines the quality of the video.";
            labelVideoBitrateHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSizeLimit
            // 
            this.labelSizeLimit.AutoSize = true;
            this.tableVideoConstantOptions.SetColumnSpan(this.labelSizeLimit, 2);
            this.labelSizeLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSizeLimit.Location = new System.Drawing.Point(310, 0);
            this.labelSizeLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSizeLimit.Name = "labelSizeLimit";
            this.labelSizeLimit.Size = new System.Drawing.Size(622, 34);
            this.labelSizeLimit.TabIndex = 3;
            this.labelSizeLimit.Text = "Will adjust the quality to attempt to stay below this limit, and cut off the end " +
    "of a video if needed.";
            this.labelSizeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableVideoVariableOptions
            // 
            this.tableVideoVariableOptions.ColumnCount = 4;
            this.tableVideoVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableVideoVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableVideoVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableVideoVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableVideoVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableVideoVariableOptions.Controls.Add(labelVideoCrf, 0, 0);
            this.tableVideoVariableOptions.Controls.Add(this.numericCrf, 1, 0);
            this.tableVideoVariableOptions.Controls.Add(labelVideoCrfHint, 3, 0);
            this.tableVideoVariableOptions.Controls.Add(labelVideoCrfTolerance, 0, 1);
            this.tableVideoVariableOptions.Controls.Add(this.numericCrfTolerance, 1, 1);
            this.tableVideoVariableOptions.Controls.Add(labelVideoCrfToleranceHint, 4, 1);
            this.tableVideoVariableOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableVideoVariableOptions.Location = new System.Drawing.Point(0, 0);
            this.tableVideoVariableOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tableVideoVariableOptions.Name = "tableVideoVariableOptions";
            this.tableVideoVariableOptions.RowCount = 2;
            this.tableVideoVariableOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableVideoVariableOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableVideoVariableOptions.Size = new System.Drawing.Size(936, 68);
            this.tableVideoVariableOptions.TabIndex = 0;
            // 
            // labelVideoCrf
            // 
            labelVideoCrf.AutoSize = true;
            labelVideoCrf.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoCrf.Location = new System.Drawing.Point(4, 0);
            labelVideoCrf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoCrf.Name = "labelVideoCrf";
            labelVideoCrf.Size = new System.Drawing.Size(97, 34);
            labelVideoCrf.TabIndex = 0;
            labelVideoCrf.Text = "CRF:";
            labelVideoCrf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericCrf
            // 
            this.tableVideoVariableOptions.SetColumnSpan(this.numericCrf, 2);
            this.numericCrf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericCrf.Location = new System.Drawing.Point(109, 4);
            this.numericCrf.Margin = new System.Windows.Forms.Padding(4);
            this.numericCrf.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericCrf.Name = "numericCrf";
            this.numericCrf.Size = new System.Drawing.Size(189, 22);
            this.numericCrf.TabIndex = 1;
            this.numericCrf.TabStop = false;
            this.numericCrf.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericCrf.ValueChanged += new System.EventHandler(this.UpdateArguments);
            // 
            // labelVideoCrfHint
            // 
            labelVideoCrfHint.AutoSize = true;
            labelVideoCrfHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoCrfHint.Location = new System.Drawing.Point(306, 0);
            labelVideoCrfHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoCrfHint.Name = "labelVideoCrfHint";
            labelVideoCrfHint.Size = new System.Drawing.Size(626, 34);
            labelVideoCrfHint.TabIndex = 0;
            labelVideoCrfHint.Text = "The constant rate factor of the video determines what level of quality the video " +
    "should get.";
            labelVideoCrfHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVideoCrfTolerance
            // 
            labelVideoCrfTolerance.AutoSize = true;
            labelVideoCrfTolerance.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoCrfTolerance.Location = new System.Drawing.Point(4, 34);
            labelVideoCrfTolerance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoCrfTolerance.Name = "labelVideoCrfTolerance";
            labelVideoCrfTolerance.Size = new System.Drawing.Size(97, 34);
            labelVideoCrfTolerance.TabIndex = 0;
            labelVideoCrfTolerance.Text = "Tolerance:";
            labelVideoCrfTolerance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericCrfTolerance
            // 
            this.tableVideoVariableOptions.SetColumnSpan(this.numericCrfTolerance, 2);
            this.numericCrfTolerance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericCrfTolerance.Location = new System.Drawing.Point(109, 38);
            this.numericCrfTolerance.Margin = new System.Windows.Forms.Padding(4);
            this.numericCrfTolerance.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.numericCrfTolerance.Name = "numericCrfTolerance";
            this.numericCrfTolerance.Size = new System.Drawing.Size(189, 22);
            this.numericCrfTolerance.TabIndex = 2;
            this.numericCrfTolerance.TabStop = false;
            this.numericCrfTolerance.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCrfTolerance.ValueChanged += new System.EventHandler(this.UpdateArguments);
            // 
            // labelVideoCrfToleranceHint
            // 
            labelVideoCrfToleranceHint.AutoSize = true;
            labelVideoCrfToleranceHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelVideoCrfToleranceHint.Location = new System.Drawing.Point(306, 34);
            labelVideoCrfToleranceHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelVideoCrfToleranceHint.Name = "labelVideoCrfToleranceHint";
            labelVideoCrfToleranceHint.Size = new System.Drawing.Size(626, 34);
            labelVideoCrfToleranceHint.TabIndex = 0;
            labelVideoCrfToleranceHint.Text = "This value determines how far the encoder is allowed to stray from the CRF value " +
    "in order to not waste too many bits on some frames.";
            labelVideoCrfToleranceHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // boxHQ
            // 
            this.boxHQ.AutoSize = true;
            this.boxHQ.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanelEncodingVideo.SetColumnSpan(this.boxHQ, 3);
            this.boxHQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxHQ.Location = new System.Drawing.Point(8, 4);
            this.boxHQ.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.boxHQ.Name = "boxHQ";
            this.boxHQ.Size = new System.Drawing.Size(279, 26);
            this.boxHQ.TabIndex = 1;
            this.boxHQ.Text = "Enable high quality mode:";
            this.boxHQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxHQ.UseVisualStyleBackColor = true;
            this.boxHQ.CheckedChanged += new System.EventHandler(this.BoxHighQuality_CheckedChanged);
            // 
            // checkMP4
            // 
            this.checkMP4.AutoSize = true;
            this.checkMP4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkMP4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkMP4.Location = new System.Drawing.Point(299, 4);
            this.checkMP4.Margin = new System.Windows.Forms.Padding(4);
            this.checkMP4.Name = "checkMP4";
            this.checkMP4.Padding = new System.Windows.Forms.Padding(267, 0, 173, 0);
            this.checkMP4.Size = new System.Drawing.Size(633, 26);
            this.checkMP4.TabIndex = 6;
            this.checkMP4.Text = "Activate mp4 conversion";
            this.checkMP4.UseVisualStyleBackColor = true;
            this.checkMP4.CheckedChanged += new System.EventHandler(this.checkMP4_CheckedChanged);
            // 
            // checkHWAcceleration
            // 
            this.checkHWAcceleration.AutoSize = true;
            this.checkHWAcceleration.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkHWAcceleration.Enabled = false;
            this.checkHWAcceleration.Location = new System.Drawing.Point(940, 4);
            this.checkHWAcceleration.Margin = new System.Windows.Forms.Padding(4);
            this.checkHWAcceleration.Name = "checkHWAcceleration";
            this.checkHWAcceleration.Padding = new System.Windows.Forms.Padding(53, 2, 0, 0);
            this.checkHWAcceleration.Size = new System.Drawing.Size(304, 22);
            this.checkHWAcceleration.TabIndex = 7;
            this.checkHWAcceleration.Text = "Hardware Acceleration (NVIDIA GPU)";
            this.checkHWAcceleration.UseVisualStyleBackColor = true;
            this.checkHWAcceleration.CheckedChanged += new System.EventHandler(this.checkHWAcceleration_CheckedChanged);
            // 
            // groupEncodingAudio
            // 
            groupEncodingAudio.Controls.Add(tableEncodingAudio);
            groupEncodingAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            groupEncodingAudio.Location = new System.Drawing.Point(4, 268);
            groupEncodingAudio.Margin = new System.Windows.Forms.Padding(4);
            groupEncodingAudio.Name = "groupEncodingAudio";
            groupEncodingAudio.Padding = new System.Windows.Forms.Padding(4);
            groupEncodingAudio.Size = new System.Drawing.Size(1391, 89);
            groupEncodingAudio.TabIndex = 3;
            groupEncodingAudio.TabStop = false;
            groupEncodingAudio.Text = "Audio";
            // 
            // tableEncodingAudio
            // 
            tableEncodingAudio.ColumnCount = 5;
            tableEncodingAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            tableEncodingAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableEncodingAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            tableEncodingAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            tableEncodingAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableEncodingAudio.Controls.Add(this.boxAudio, 0, 0);
            tableEncodingAudio.Controls.Add(labelAudioHint, 4, 0);
            tableEncodingAudio.Controls.Add(panelEncodingModeSwapperTwo, 0, 1);
            tableEncodingAudio.Controls.Add(this.numericDelay, 3, 0);
            tableEncodingAudio.Controls.Add(this.lblDelay, 2, 0);
            tableEncodingAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            tableEncodingAudio.Location = new System.Drawing.Point(4, 19);
            tableEncodingAudio.Margin = new System.Windows.Forms.Padding(0);
            tableEncodingAudio.Name = "tableEncodingAudio";
            tableEncodingAudio.RowCount = 2;
            tableEncodingAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableEncodingAudio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableEncodingAudio.Size = new System.Drawing.Size(1383, 66);
            tableEncodingAudio.TabIndex = 0;
            // 
            // boxAudio
            // 
            this.boxAudio.AutoSize = true;
            this.boxAudio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            tableEncodingAudio.SetColumnSpan(this.boxAudio, 2);
            this.boxAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxAudio.Location = new System.Drawing.Point(8, 4);
            this.boxAudio.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.boxAudio.Name = "boxAudio";
            this.boxAudio.Size = new System.Drawing.Size(124, 26);
            this.boxAudio.TabIndex = 1;
            this.boxAudio.Text = "Enable audio:";
            this.boxAudio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxAudio.UseVisualStyleBackColor = true;
            this.boxAudio.CheckedChanged += new System.EventHandler(this.boxAudio_CheckedChanged);
            // 
            // labelAudioHint
            // 
            labelAudioHint.AutoSize = true;
            labelAudioHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioHint.Location = new System.Drawing.Point(306, 0);
            labelAudioHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAudioHint.Name = "labelAudioHint";
            labelAudioHint.Size = new System.Drawing.Size(1073, 34);
            labelAudioHint.TabIndex = 0;
            labelAudioHint.Text = "Do you want a WebM with sound? You found the setting for it.";
            labelAudioHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEncodingModeSwapperTwo
            // 
            tableEncodingAudio.SetColumnSpan(panelEncodingModeSwapperTwo, 5);
            panelEncodingModeSwapperTwo.Controls.Add(this.tableAudioConstantOptions);
            panelEncodingModeSwapperTwo.Controls.Add(this.tableAudioVariableOptions);
            panelEncodingModeSwapperTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            panelEncodingModeSwapperTwo.Location = new System.Drawing.Point(0, 34);
            panelEncodingModeSwapperTwo.Margin = new System.Windows.Forms.Padding(0);
            panelEncodingModeSwapperTwo.Name = "panelEncodingModeSwapperTwo";
            panelEncodingModeSwapperTwo.Size = new System.Drawing.Size(1383, 34);
            panelEncodingModeSwapperTwo.TabIndex = 2;
            // 
            // tableAudioConstantOptions
            // 
            this.tableAudioConstantOptions.ColumnCount = 4;
            this.tableAudioConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableAudioConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableAudioConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableAudioConstantOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAudioConstantOptions.Controls.Add(labelAudioBitrate, 0, 0);
            this.tableAudioConstantOptions.Controls.Add(this.boxAudioBitrate, 1, 0);
            this.tableAudioConstantOptions.Controls.Add(labelAudioBitrateUnit, 2, 0);
            this.tableAudioConstantOptions.Controls.Add(labelAudioBitrateHint, 4, 0);
            this.tableAudioConstantOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableAudioConstantOptions.Location = new System.Drawing.Point(0, 0);
            this.tableAudioConstantOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tableAudioConstantOptions.Name = "tableAudioConstantOptions";
            this.tableAudioConstantOptions.RowCount = 1;
            this.tableAudioConstantOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAudioConstantOptions.Size = new System.Drawing.Size(1383, 34);
            this.tableAudioConstantOptions.TabIndex = 0;
            // 
            // labelAudioBitrate
            // 
            labelAudioBitrate.AutoSize = true;
            labelAudioBitrate.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioBitrate.Location = new System.Drawing.Point(4, 0);
            labelAudioBitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAudioBitrate.Name = "labelAudioBitrate";
            labelAudioBitrate.Size = new System.Drawing.Size(97, 34);
            labelAudioBitrate.TabIndex = 0;
            labelAudioBitrate.Text = "Bitrate:";
            labelAudioBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxAudioBitrate
            // 
            this.boxAudioBitrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.boxAudioBitrate.Enabled = false;
            this.boxAudioBitrate.Location = new System.Drawing.Point(109, 6);
            this.boxAudioBitrate.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.boxAudioBitrate.Name = "boxAudioBitrate";
            this.boxAudioBitrate.Size = new System.Drawing.Size(153, 22);
            this.boxAudioBitrate.TabIndex = 1;
            this.boxAudioBitrate.TextChanged += new System.EventHandler(this.UpdateArguments);
            this.boxAudioBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumbersOnly);
            // 
            // labelAudioBitrateUnit
            // 
            labelAudioBitrateUnit.AutoSize = true;
            labelAudioBitrateUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioBitrateUnit.Location = new System.Drawing.Point(262, 0);
            labelAudioBitrateUnit.Margin = new System.Windows.Forms.Padding(0);
            labelAudioBitrateUnit.Name = "labelAudioBitrateUnit";
            labelAudioBitrateUnit.Size = new System.Drawing.Size(40, 34);
            labelAudioBitrateUnit.TabIndex = 0;
            labelAudioBitrateUnit.Text = "kb/s";
            labelAudioBitrateUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAudioBitrateHint
            // 
            labelAudioBitrateHint.AutoSize = true;
            labelAudioBitrateHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioBitrateHint.Location = new System.Drawing.Point(306, 0);
            labelAudioBitrateHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAudioBitrateHint.Name = "labelAudioBitrateHint";
            labelAudioBitrateHint.Size = new System.Drawing.Size(1073, 34);
            labelAudioBitrateHint.TabIndex = 0;
            labelAudioBitrateHint.Text = "Determines the quality of the audio.";
            labelAudioBitrateHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableAudioVariableOptions
            // 
            this.tableAudioVariableOptions.ColumnCount = 4;
            this.tableAudioVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableAudioVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableAudioVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableAudioVariableOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAudioVariableOptions.Controls.Add(labelAudioQuality, 0, 0);
            this.tableAudioVariableOptions.Controls.Add(this.numericAudioQuality, 1, 0);
            this.tableAudioVariableOptions.Controls.Add(labelAudioQualityHint, 4, 0);
            this.tableAudioVariableOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableAudioVariableOptions.Location = new System.Drawing.Point(0, 0);
            this.tableAudioVariableOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tableAudioVariableOptions.Name = "tableAudioVariableOptions";
            this.tableAudioVariableOptions.RowCount = 1;
            this.tableAudioVariableOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAudioVariableOptions.Size = new System.Drawing.Size(1383, 34);
            this.tableAudioVariableOptions.TabIndex = 0;
            // 
            // labelAudioQuality
            // 
            labelAudioQuality.AutoSize = true;
            labelAudioQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioQuality.Location = new System.Drawing.Point(4, 0);
            labelAudioQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAudioQuality.Name = "labelAudioQuality";
            labelAudioQuality.Size = new System.Drawing.Size(97, 34);
            labelAudioQuality.TabIndex = 0;
            labelAudioQuality.Text = "Quality:";
            labelAudioQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericAudioQuality
            // 
            this.tableAudioVariableOptions.SetColumnSpan(this.numericAudioQuality, 2);
            this.numericAudioQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericAudioQuality.Enabled = false;
            this.numericAudioQuality.Location = new System.Drawing.Point(109, 4);
            this.numericAudioQuality.Margin = new System.Windows.Forms.Padding(4);
            this.numericAudioQuality.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericAudioQuality.Name = "numericAudioQuality";
            this.numericAudioQuality.Size = new System.Drawing.Size(189, 22);
            this.numericAudioQuality.TabIndex = 1;
            this.numericAudioQuality.TabStop = false;
            this.numericAudioQuality.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericAudioQuality.ValueChanged += new System.EventHandler(this.UpdateArguments);
            // 
            // labelAudioQualityHint
            // 
            labelAudioQualityHint.AutoSize = true;
            labelAudioQualityHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelAudioQualityHint.Location = new System.Drawing.Point(306, 0);
            labelAudioQualityHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAudioQualityHint.Name = "labelAudioQualityHint";
            labelAudioQualityHint.Size = new System.Drawing.Size(1073, 34);
            labelAudioQualityHint.TabIndex = 0;
            labelAudioQualityHint.Text = "Determines the average quality of the audio. 10 is the highest quality.";
            labelAudioQualityHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericDelay
            // 
            this.numericDelay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericDelay.DecimalPlaces = 1;
            this.numericDelay.Enabled = false;
            this.numericDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericDelay.Location = new System.Drawing.Point(233, 6);
            this.numericDelay.Margin = new System.Windows.Forms.Padding(4);
            this.numericDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericDelay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(65, 22);
            this.numericDelay.TabIndex = 3;
            this.numericDelay.ValueChanged += new System.EventHandler(this.numericDelay_ValueChanged);
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(178, 9);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(47, 16);
            this.lblDelay.TabIndex = 4;
            this.lblDelay.Text = "Delay:";
            // 
            // tabAdvanced
            // 
            tabAdvanced.AutoScroll = true;
            tabAdvanced.BackColor = System.Drawing.SystemColors.Control;
            tabAdvanced.Controls.Add(tableAdvanced);
            tabAdvanced.Location = new System.Drawing.Point(4, 25);
            tabAdvanced.Margin = new System.Windows.Forms.Padding(4);
            tabAdvanced.Name = "tabAdvanced";
            tabAdvanced.Padding = new System.Windows.Forms.Padding(4);
            tabAdvanced.Size = new System.Drawing.Size(1407, 380);
            tabAdvanced.TabIndex = 4;
            tabAdvanced.Text = "Advanced";
            // 
            // tableAdvanced
            // 
            tableAdvanced.ColumnCount = 1;
            tableAdvanced.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableAdvanced.Controls.Add(groupAdvancedProcessing, 0, 1);
            tableAdvanced.Controls.Add(groupAdvancedEncoding, 0, 2);
            tableAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            tableAdvanced.Location = new System.Drawing.Point(4, 4);
            tableAdvanced.Margin = new System.Windows.Forms.Padding(4);
            tableAdvanced.Name = "tableAdvanced";
            tableAdvanced.RowCount = 4;
            tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            tableAdvanced.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableAdvanced.Size = new System.Drawing.Size(1399, 372);
            tableAdvanced.TabIndex = 1;
            // 
            // groupAdvancedProcessing
            // 
            groupAdvancedProcessing.Controls.Add(tableAdvancedProcessing);
            groupAdvancedProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            groupAdvancedProcessing.Location = new System.Drawing.Point(4, 11);
            groupAdvancedProcessing.Margin = new System.Windows.Forms.Padding(4);
            groupAdvancedProcessing.Name = "groupAdvancedProcessing";
            groupAdvancedProcessing.Padding = new System.Windows.Forms.Padding(4);
            groupAdvancedProcessing.Size = new System.Drawing.Size(1391, 138);
            groupAdvancedProcessing.TabIndex = 1;
            groupAdvancedProcessing.TabStop = false;
            groupAdvancedProcessing.Text = "Processing";
            // 
            // tableAdvancedProcessing
            // 
            tableAdvancedProcessing.ColumnCount = 9;
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            tableAdvancedProcessing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 673F));
            tableAdvancedProcessing.Controls.Add(labelProcessingLevels, 0, 0);
            tableAdvancedProcessing.Controls.Add(this.comboLevels, 1, 0);
            tableAdvancedProcessing.Controls.Add(this.boxDeinterlace, 1, 1);
            tableAdvancedProcessing.Controls.Add(this.boxLoop, 0, 1);
            tableAdvancedProcessing.Controls.Add(this.labelSaturation, 4, 0);
            tableAdvancedProcessing.Controls.Add(this.numericGamma, 3, 0);
            tableAdvancedProcessing.Controls.Add(this.numericSaturation, 5, 0);
            tableAdvancedProcessing.Controls.Add(this.labelGamma, 2, 0);
            tableAdvancedProcessing.Controls.Add(this.boxDenoise, 0, 2);
            tableAdvancedProcessing.Controls.Add(this.boxStabilization, 1, 2);
            tableAdvancedProcessing.Controls.Add(this.numericContrast, 7, 0);
            tableAdvancedProcessing.Controls.Add(this.labelContrast, 6, 0);
            tableAdvancedProcessing.Controls.Add(this.buttonPreview2, 8, 0);
            tableAdvancedProcessing.Controls.Add(this.txtLevel, 2, 2);
            tableAdvancedProcessing.Controls.Add(this.comboBoxLevels, 3, 2);
            tableAdvancedProcessing.Controls.Add(this.txtType, 5, 2);
            tableAdvancedProcessing.Controls.Add(this.comboStabType, 6, 2);
            tableAdvancedProcessing.Location = new System.Drawing.Point(4, 18);
            tableAdvancedProcessing.Margin = new System.Windows.Forms.Padding(4);
            tableAdvancedProcessing.Name = "tableAdvancedProcessing";
            tableAdvancedProcessing.RowCount = 3;
            tableAdvancedProcessing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedProcessing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedProcessing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedProcessing.Size = new System.Drawing.Size(1383, 101);
            tableAdvancedProcessing.TabIndex = 1;
            // 
            // labelProcessingLevels
            // 
            labelProcessingLevels.AutoSize = true;
            labelProcessingLevels.Dock = System.Windows.Forms.DockStyle.Right;
            labelProcessingLevels.Location = new System.Drawing.Point(93, 0);
            labelProcessingLevels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelProcessingLevels.Name = "labelProcessingLevels";
            labelProcessingLevels.Size = new System.Drawing.Size(40, 34);
            labelProcessingLevels.TabIndex = 12;
            labelProcessingLevels.Text = "Filter:";
            labelProcessingLevels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboLevels
            // 
            this.comboLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLevels.Items.AddRange(new object[] {
            "Original",
            "Light Filter",
            "Dark Filter",
            "Advanced"});
            this.comboLevels.Location = new System.Drawing.Point(141, 5);
            this.comboLevels.Margin = new System.Windows.Forms.Padding(4);
            this.comboLevels.Name = "comboLevels";
            this.comboLevels.Size = new System.Drawing.Size(153, 24);
            this.comboLevels.TabIndex = 13;
            this.comboLevels.SelectedIndexChanged += new System.EventHandler(this.comboLevels_SelectedIndexChanged_1);
            // 
            // boxDeinterlace
            // 
            this.boxDeinterlace.AutoSize = true;
            this.boxDeinterlace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxDeinterlace.Dock = System.Windows.Forms.DockStyle.Right;
            this.boxDeinterlace.Location = new System.Drawing.Point(195, 38);
            this.boxDeinterlace.Margin = new System.Windows.Forms.Padding(4);
            this.boxDeinterlace.Name = "boxDeinterlace";
            this.boxDeinterlace.Size = new System.Drawing.Size(99, 26);
            this.boxDeinterlace.TabIndex = 14;
            this.boxDeinterlace.Text = "Deinterlace:";
            this.boxDeinterlace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxDeinterlace.UseVisualStyleBackColor = true;
            // 
            // boxLoop
            // 
            this.boxLoop.AutoSize = true;
            this.boxLoop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxLoop.Dock = System.Windows.Forms.DockStyle.Right;
            this.boxLoop.Location = new System.Drawing.Point(72, 38);
            this.boxLoop.Margin = new System.Windows.Forms.Padding(4);
            this.boxLoop.Name = "boxLoop";
            this.boxLoop.Size = new System.Drawing.Size(61, 26);
            this.boxLoop.TabIndex = 16;
            this.boxLoop.Text = "Loop:";
            this.boxLoop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxLoop.UseVisualStyleBackColor = true;
            this.boxLoop.CheckedChanged += new System.EventHandler(this.boxLoop_CheckedChanged);
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(424, 7);
            this.labelSaturation.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(68, 16);
            this.labelSaturation.TabIndex = 18;
            this.labelSaturation.Text = "Saturation";
            // 
            // numericGamma
            // 
            this.numericGamma.DecimalPlaces = 1;
            this.numericGamma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericGamma.Enabled = false;
            this.numericGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericGamma.Location = new System.Drawing.Point(365, 2);
            this.numericGamma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericGamma.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericGamma.Name = "numericGamma";
            this.numericGamma.Size = new System.Drawing.Size(53, 22);
            this.numericGamma.TabIndex = 19;
            this.numericGamma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericSaturation
            // 
            this.numericSaturation.DecimalPlaces = 1;
            this.numericSaturation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericSaturation.Enabled = false;
            this.numericSaturation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericSaturation.Location = new System.Drawing.Point(503, 2);
            this.numericSaturation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericSaturation.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericSaturation.Name = "numericSaturation";
            this.numericSaturation.Size = new System.Drawing.Size(49, 22);
            this.numericSaturation.TabIndex = 20;
            this.numericSaturation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(301, 0);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labelGamma.Size = new System.Drawing.Size(56, 23);
            this.labelGamma.TabIndex = 17;
            this.labelGamma.Text = "Gamma";
            // 
            // boxDenoise
            // 
            this.boxDenoise.AutoSize = true;
            this.boxDenoise.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxDenoise.Dock = System.Windows.Forms.DockStyle.Right;
            this.boxDenoise.Location = new System.Drawing.Point(52, 72);
            this.boxDenoise.Margin = new System.Windows.Forms.Padding(4);
            this.boxDenoise.Name = "boxDenoise";
            this.boxDenoise.Size = new System.Drawing.Size(81, 26);
            this.boxDenoise.TabIndex = 15;
            this.boxDenoise.Text = "Denoise:";
            this.boxDenoise.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxDenoise.UseVisualStyleBackColor = true;
            // 
            // boxStabilization
            // 
            this.boxStabilization.AutoSize = true;
            this.boxStabilization.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxStabilization.Dock = System.Windows.Forms.DockStyle.Right;
            this.boxStabilization.Location = new System.Drawing.Point(192, 72);
            this.boxStabilization.Margin = new System.Windows.Forms.Padding(4);
            this.boxStabilization.Name = "boxStabilization";
            this.boxStabilization.Size = new System.Drawing.Size(102, 26);
            this.boxStabilization.TabIndex = 24;
            this.boxStabilization.Text = "Stabilization:";
            this.boxStabilization.UseVisualStyleBackColor = true;
            this.boxStabilization.CheckedChanged += new System.EventHandler(this.boxStabilization_CheckedChanged);
            // 
            // numericContrast
            // 
            this.numericContrast.DecimalPlaces = 1;
            this.numericContrast.Enabled = false;
            this.numericContrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericContrast.Location = new System.Drawing.Point(643, 4);
            this.numericContrast.Margin = new System.Windows.Forms.Padding(4);
            this.numericContrast.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericContrast.Name = "numericContrast";
            this.numericContrast.Size = new System.Drawing.Size(48, 22);
            this.numericContrast.TabIndex = 23;
            this.numericContrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelContrast
            // 
            this.labelContrast.AutoSize = true;
            this.labelContrast.Location = new System.Drawing.Point(559, 0);
            this.labelContrast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labelContrast.Size = new System.Drawing.Size(57, 23);
            this.labelContrast.TabIndex = 22;
            this.labelContrast.Text = "Contrast";
            // 
            // buttonPreview2
            // 
            this.buttonPreview2.Enabled = false;
            this.buttonPreview2.Location = new System.Drawing.Point(713, 2);
            this.buttonPreview2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPreview2.Name = "buttonPreview2";
            tableAdvancedProcessing.SetRowSpan(this.buttonPreview2, 2);
            this.buttonPreview2.Size = new System.Drawing.Size(136, 28);
            this.buttonPreview2.TabIndex = 21;
            this.buttonPreview2.Text = "Preview";
            this.buttonPreview2.UseVisualStyleBackColor = true;
            this.buttonPreview2.Click += new System.EventHandler(this.buttonPreview2_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.AutoSize = true;
            this.txtLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLevel.Location = new System.Drawing.Point(302, 68);
            this.txtLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.txtLevel.Size = new System.Drawing.Size(56, 34);
            this.txtLevel.TabIndex = 25;
            this.txtLevel.Text = "Level";
            // 
            // comboBoxLevels
            // 
            tableAdvancedProcessing.SetColumnSpan(this.comboBoxLevels, 2);
            this.comboBoxLevels.FormattingEnabled = true;
            this.comboBoxLevels.Location = new System.Drawing.Point(366, 72);
            this.comboBoxLevels.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLevels.Name = "comboBoxLevels";
            this.comboBoxLevels.Size = new System.Drawing.Size(128, 24);
            this.comboBoxLevels.TabIndex = 26;
            // 
            // groupAdvancedEncoding
            // 
            groupAdvancedEncoding.AutoSize = true;
            groupAdvancedEncoding.Controls.Add(tableAdvancedEncoding);
            groupAdvancedEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            groupAdvancedEncoding.Location = new System.Drawing.Point(4, 157);
            groupAdvancedEncoding.Margin = new System.Windows.Forms.Padding(4);
            groupAdvancedEncoding.Name = "groupAdvancedEncoding";
            groupAdvancedEncoding.Padding = new System.Windows.Forms.Padding(4);
            groupAdvancedEncoding.Size = new System.Drawing.Size(1391, 205);
            groupAdvancedEncoding.TabIndex = 2;
            groupAdvancedEncoding.TabStop = false;
            groupAdvancedEncoding.Text = "Encoding";
            // 
            // tableAdvancedEncoding
            // 
            tableAdvancedEncoding.ColumnCount = 4;
            tableAdvancedEncoding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            tableAdvancedEncoding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            tableAdvancedEncoding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableAdvancedEncoding.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableAdvancedEncoding.Controls.Add(this.boxFrameRate, 1, 2);
            tableAdvancedEncoding.Controls.Add(labelEncodingFrameRateHint, 3, 2);
            tableAdvancedEncoding.Controls.Add(labelEncodingFrameRate, 0, 2);
            tableAdvancedEncoding.Controls.Add(labelEncodingNGOVHint, 3, 3);
            tableAdvancedEncoding.Controls.Add(this.boxNGOV, 0, 3);
            tableAdvancedEncoding.Controls.Add(labelEncodingThreads, 0, 0);
            tableAdvancedEncoding.Controls.Add(this.trackThreads, 1, 0);
            tableAdvancedEncoding.Controls.Add(this.labelThreads, 2, 0);
            tableAdvancedEncoding.Controls.Add(labelEncodingThreadsHint, 3, 0);
            tableAdvancedEncoding.Controls.Add(labelEncodingSlices, 0, 1);
            tableAdvancedEncoding.Controls.Add(this.trackSlices, 1, 1);
            tableAdvancedEncoding.Controls.Add(this.labelSlices, 2, 1);
            tableAdvancedEncoding.Controls.Add(labelEncodingSlicesHint, 3, 1);
            tableAdvancedEncoding.Controls.Add(labelEncodingArguments, 0, 4);
            tableAdvancedEncoding.Controls.Add(this.boxArguments, 1, 4);
            tableAdvancedEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            tableAdvancedEncoding.Location = new System.Drawing.Point(4, 19);
            tableAdvancedEncoding.Margin = new System.Windows.Forms.Padding(4);
            tableAdvancedEncoding.Name = "tableAdvancedEncoding";
            tableAdvancedEncoding.RowCount = 5;
            tableAdvancedEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            tableAdvancedEncoding.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableAdvancedEncoding.Size = new System.Drawing.Size(1383, 182);
            tableAdvancedEncoding.TabIndex = 0;
            // 
            // boxFrameRate
            // 
            this.boxFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            tableAdvancedEncoding.SetColumnSpan(this.boxFrameRate, 2);
            this.boxFrameRate.Location = new System.Drawing.Point(109, 74);
            this.boxFrameRate.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.boxFrameRate.Name = "boxFrameRate";
            this.boxFrameRate.Size = new System.Drawing.Size(193, 22);
            this.boxFrameRate.TabIndex = 8;
            this.boxFrameRate.TextChanged += new System.EventHandler(this.UpdateArguments);
            this.boxFrameRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumbersOnly);
            this.boxFrameRate.Leave += new System.EventHandler(this.boxFrameRate_Leave);
            // 
            // labelEncodingFrameRateHint
            // 
            labelEncodingFrameRateHint.AutoSize = true;
            labelEncodingFrameRateHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingFrameRateHint.Location = new System.Drawing.Point(306, 68);
            labelEncodingFrameRateHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingFrameRateHint.Name = "labelEncodingFrameRateHint";
            labelEncodingFrameRateHint.Size = new System.Drawing.Size(1073, 34);
            labelEncodingFrameRateHint.TabIndex = 7;
            labelEncodingFrameRateHint.Text = "Interpolate  your video to 60 or 120 fps (recommended values). Keep blank and not" +
    "hing happend here.";
            labelEncodingFrameRateHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncodingFrameRate
            // 
            labelEncodingFrameRate.AutoSize = true;
            labelEncodingFrameRate.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingFrameRate.Location = new System.Drawing.Point(4, 68);
            labelEncodingFrameRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingFrameRate.Name = "labelEncodingFrameRate";
            labelEncodingFrameRate.Size = new System.Drawing.Size(97, 34);
            labelEncodingFrameRate.TabIndex = 6;
            labelEncodingFrameRate.Text = "Interpolate to:";
            labelEncodingFrameRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEncodingNGOVHint
            // 
            labelEncodingNGOVHint.AutoSize = true;
            labelEncodingNGOVHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingNGOVHint.Location = new System.Drawing.Point(306, 102);
            labelEncodingNGOVHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingNGOVHint.Name = "labelEncodingNGOVHint";
            labelEncodingNGOVHint.Size = new System.Drawing.Size(1073, 34);
            labelEncodingNGOVHint.TabIndex = 0;
            labelEncodingNGOVHint.Text = "Use the next-gen VP9/Opus encoders instead of the standard VP8/Vorbis. It can tak" +
    "e more time.";
            labelEncodingNGOVHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // boxNGOV
            // 
            this.boxNGOV.AutoSize = true;
            this.boxNGOV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            tableAdvancedEncoding.SetColumnSpan(this.boxNGOV, 3);
            this.boxNGOV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxNGOV.Location = new System.Drawing.Point(4, 106);
            this.boxNGOV.Margin = new System.Windows.Forms.Padding(4);
            this.boxNGOV.Name = "boxNGOV";
            this.boxNGOV.Size = new System.Drawing.Size(294, 26);
            this.boxNGOV.TabIndex = 4;
            this.boxNGOV.Text = "VP9/Opus:";
            this.boxNGOV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boxNGOV.UseVisualStyleBackColor = true;
            this.boxNGOV.CheckedChanged += new System.EventHandler(this.boxNGOV_CheckedChanged);
            // 
            // labelEncodingThreads
            // 
            labelEncodingThreads.AutoSize = true;
            labelEncodingThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingThreads.Location = new System.Drawing.Point(4, 0);
            labelEncodingThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingThreads.Name = "labelEncodingThreads";
            labelEncodingThreads.Size = new System.Drawing.Size(97, 34);
            labelEncodingThreads.TabIndex = 0;
            labelEncodingThreads.Text = "Threads:";
            labelEncodingThreads.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackThreads
            // 
            this.trackThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackThreads.Location = new System.Drawing.Point(105, 0);
            this.trackThreads.Margin = new System.Windows.Forms.Padding(0);
            this.trackThreads.Maximum = 16;
            this.trackThreads.Minimum = 1;
            this.trackThreads.Name = "trackThreads";
            this.trackThreads.Size = new System.Drawing.Size(157, 34);
            this.trackThreads.TabIndex = 1;
            this.trackThreads.Value = 1;
            this.trackThreads.ValueChanged += new System.EventHandler(this.trackThreads_ValueChanged);
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelThreads.Location = new System.Drawing.Point(262, 0);
            this.labelThreads.Margin = new System.Windows.Forms.Padding(0);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(40, 34);
            this.labelThreads.TabIndex = 0;
            this.labelThreads.Text = "1";
            this.labelThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncodingThreadsHint
            // 
            labelEncodingThreadsHint.AutoSize = true;
            labelEncodingThreadsHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingThreadsHint.Location = new System.Drawing.Point(306, 0);
            labelEncodingThreadsHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingThreadsHint.Name = "labelEncodingThreadsHint";
            labelEncodingThreadsHint.Size = new System.Drawing.Size(1073, 34);
            labelEncodingThreadsHint.TabIndex = 0;
            labelEncodingThreadsHint.Text = "Determines amount of threads ffmpeg uses. Try setting this to 1 if ffmpeg.exe cra" +
    "shes as soon as you click Convert.";
            labelEncodingThreadsHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncodingSlices
            // 
            labelEncodingSlices.AutoSize = true;
            labelEncodingSlices.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingSlices.Location = new System.Drawing.Point(4, 34);
            labelEncodingSlices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingSlices.Name = "labelEncodingSlices";
            labelEncodingSlices.Size = new System.Drawing.Size(97, 34);
            labelEncodingSlices.TabIndex = 0;
            labelEncodingSlices.Text = "Slices:";
            labelEncodingSlices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackSlices
            // 
            this.trackSlices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackSlices.Location = new System.Drawing.Point(105, 34);
            this.trackSlices.Margin = new System.Windows.Forms.Padding(0);
            this.trackSlices.Maximum = 4;
            this.trackSlices.Minimum = 1;
            this.trackSlices.Name = "trackSlices";
            this.trackSlices.Size = new System.Drawing.Size(157, 34);
            this.trackSlices.TabIndex = 2;
            this.trackSlices.Value = 1;
            this.trackSlices.ValueChanged += new System.EventHandler(this.trackSlices_ValueChanged);
            // 
            // labelSlices
            // 
            this.labelSlices.AutoSize = true;
            this.labelSlices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSlices.Location = new System.Drawing.Point(262, 34);
            this.labelSlices.Margin = new System.Windows.Forms.Padding(0);
            this.labelSlices.Name = "labelSlices";
            this.labelSlices.Size = new System.Drawing.Size(40, 34);
            this.labelSlices.TabIndex = 0;
            this.labelSlices.Text = "1";
            this.labelSlices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncodingSlicesHint
            // 
            labelEncodingSlicesHint.AutoSize = true;
            labelEncodingSlicesHint.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingSlicesHint.Location = new System.Drawing.Point(306, 34);
            labelEncodingSlicesHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingSlicesHint.Name = "labelEncodingSlicesHint";
            labelEncodingSlicesHint.Size = new System.Drawing.Size(1073, 34);
            labelEncodingSlicesHint.TabIndex = 0;
            labelEncodingSlicesHint.Text = "Split frames into slices before encoding them. Results in a higher quality per fr" +
    "ame. 4 slices is standard for 720p resolutions.";
            labelEncodingSlicesHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncodingArguments
            // 
            labelEncodingArguments.AutoSize = true;
            labelEncodingArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEncodingArguments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            labelEncodingArguments.Location = new System.Drawing.Point(4, 136);
            labelEncodingArguments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEncodingArguments.Name = "labelEncodingArguments";
            labelEncodingArguments.Size = new System.Drawing.Size(97, 46);
            labelEncodingArguments.TabIndex = 0;
            labelEncodingArguments.Text = "Arguments:";
            labelEncodingArguments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxArguments
            // 
            this.boxArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            tableAdvancedEncoding.SetColumnSpan(this.boxArguments, 3);
            this.boxArguments.Location = new System.Drawing.Point(109, 148);
            this.boxArguments.Margin = new System.Windows.Forms.Padding(4);
            this.boxArguments.Name = "boxArguments";
            this.boxArguments.Size = new System.Drawing.Size(1270, 22);
            this.boxArguments.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(groupBox1);
            this.tabPage1.Controls.Add(this.labelMaintained);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.groupGfycat);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1407, 380);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "General";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.buttonOpenPath);
            groupBox1.Controls.Add(this.CRFother);
            groupBox1.Controls.Add(this.CRF4k);
            groupBox1.Controls.Add(this.lblCRFConfiguration2);
            groupBox1.Controls.Add(this.label7);
            groupBox1.Controls.Add(this.lblCRFConfiguration);
            groupBox1.Controls.Add(this.textPathDownloaded);
            groupBox1.Controls.Add(this.buttonPathChange);
            groupBox1.Controls.Add(this.lblPathDownload);
            groupBox1.Location = new System.Drawing.Point(7, 14);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(1391, 105);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // buttonOpenPath
            // 
            this.buttonOpenPath.Location = new System.Drawing.Point(1293, 21);
            this.buttonOpenPath.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenPath.Name = "buttonOpenPath";
            this.buttonOpenPath.Size = new System.Drawing.Size(89, 28);
            this.buttonOpenPath.TabIndex = 6;
            this.buttonOpenPath.Text = "Open";
            this.buttonOpenPath.UseVisualStyleBackColor = true;
            this.buttonOpenPath.Click += new System.EventHandler(this.buttonOpenPath_Click);
            // 
            // CRFother
            // 
            this.CRFother.Location = new System.Drawing.Point(391, 62);
            this.CRFother.Margin = new System.Windows.Forms.Padding(4);
            this.CRFother.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.CRFother.Name = "CRFother";
            this.CRFother.Size = new System.Drawing.Size(55, 22);
            this.CRFother.TabIndex = 4;
            this.CRFother.ValueChanged += new System.EventHandler(this.CRFother_ValueChanged);
            // 
            // CRF4k
            // 
            this.CRF4k.Location = new System.Drawing.Point(215, 62);
            this.CRF4k.Margin = new System.Windows.Forms.Padding(4);
            this.CRF4k.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.CRF4k.Name = "CRF4k";
            this.CRF4k.Size = new System.Drawing.Size(56, 22);
            this.CRF4k.TabIndex = 3;
            this.CRF4k.ValueChanged += new System.EventHandler(this.CRF4k_ValueChanged);
            // 
            // lblCRFConfiguration2
            // 
            this.lblCRFConfiguration2.AutoSize = true;
            this.lblCRFConfiguration2.Location = new System.Drawing.Point(277, 64);
            this.lblCRFConfiguration2.Name = "lblCRFConfiguration2";
            this.lblCRFConfiguration2.Size = new System.Drawing.Size(100, 16);
            this.lblCRFConfiguration2.TabIndex = 2;
            this.lblCRFConfiguration2.Text = "otherwise set to";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 1;
            // 
            // lblCRFConfiguration
            // 
            this.lblCRFConfiguration.AutoSize = true;
            this.lblCRFConfiguration.Location = new System.Drawing.Point(13, 63);
            this.lblCRFConfiguration.Name = "lblCRFConfiguration";
            this.lblCRFConfiguration.Size = new System.Drawing.Size(182, 16);
            this.lblCRFConfiguration.TabIndex = 0;
            this.lblCRFConfiguration.Text = "When source is 4k set CRF to";
            // 
            // textPathDownloaded
            // 
            this.textPathDownloaded.Enabled = false;
            this.textPathDownloaded.Location = new System.Drawing.Point(184, 23);
            this.textPathDownloaded.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPathDownloaded.Name = "textPathDownloaded";
            this.textPathDownloaded.Size = new System.Drawing.Size(1004, 22);
            this.textPathDownloaded.TabIndex = 1;
            // 
            // buttonPathChange
            // 
            this.buttonPathChange.Location = new System.Drawing.Point(1197, 21);
            this.buttonPathChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPathChange.Name = "buttonPathChange";
            this.buttonPathChange.Size = new System.Drawing.Size(95, 28);
            this.buttonPathChange.TabIndex = 2;
            this.buttonPathChange.Text = "Change";
            this.buttonPathChange.UseVisualStyleBackColor = true;
            this.buttonPathChange.Click += new System.EventHandler(this.buttonPathChange_Click);
            // 
            // lblPathDownload
            // 
            this.lblPathDownload.AutoSize = true;
            this.lblPathDownload.Location = new System.Drawing.Point(11, 23);
            this.lblPathDownload.Name = "lblPathDownload";
            this.lblPathDownload.Size = new System.Drawing.Size(160, 16);
            this.lblPathDownload.TabIndex = 0;
            this.lblPathDownload.Text = "Path downloaded videos:";
            // 
            // labelMaintained
            // 
            this.labelMaintained.AutoSize = true;
            this.labelMaintained.Location = new System.Drawing.Point(12, 357);
            this.labelMaintained.Name = "labelMaintained";
            this.labelMaintained.Size = new System.Drawing.Size(253, 16);
            this.labelMaintained.TabIndex = 4;
            this.labelMaintained.Text = "WebMConverter is maintained by argorar";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1292, 359);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(103, 16);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Visit the website";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupGfycat
            // 
            this.groupGfycat.Controls.Add(this.boxTags);
            this.groupGfycat.Controls.Add(this.labelTags);
            this.groupGfycat.Controls.Add(this.buttonLogOut);
            this.groupGfycat.Controls.Add(this.pictureBox);
            this.groupGfycat.Controls.Add(this.lblFollowers);
            this.groupGfycat.Controls.Add(this.lblViews);
            this.groupGfycat.Controls.Add(this.lblTotalGfys);
            this.groupGfycat.Controls.Add(this.lblPublicGfys);
            this.groupGfycat.Controls.Add(this.label2);
            this.groupGfycat.Controls.Add(this.lblUser);
            this.groupGfycat.Location = new System.Drawing.Point(5, 122);
            this.groupGfycat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupGfycat.Name = "groupGfycat";
            this.groupGfycat.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupGfycat.Size = new System.Drawing.Size(1393, 108);
            this.groupGfycat.TabIndex = 5;
            this.groupGfycat.TabStop = false;
            this.groupGfycat.Text = "Gfycat";
            // 
            // boxTags
            // 
            this.boxTags.Location = new System.Drawing.Point(308, 70);
            this.boxTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxTags.Name = "boxTags";
            this.boxTags.Size = new System.Drawing.Size(385, 22);
            this.boxTags.TabIndex = 9;
            // 
            // labelTags
            // 
            this.labelTags.AutoSize = true;
            this.labelTags.Location = new System.Drawing.Point(268, 71);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(46, 16);
            this.labelTags.TabIndex = 8;
            this.labelTags.Text = "Tags: ";
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(8, 60);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 32);
            this.buttonLogOut.TabIndex = 7;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(1200, 20);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 60);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // lblFollowers
            // 
            this.lblFollowers.AutoSize = true;
            this.lblFollowers.Location = new System.Drawing.Point(599, 43);
            this.lblFollowers.Name = "lblFollowers";
            this.lblFollowers.Size = new System.Drawing.Size(89, 16);
            this.lblFollowers.TabIndex = 5;
            this.lblFollowers.Text = "Followers: {0}";
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Location = new System.Drawing.Point(599, 18);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(67, 16);
            this.lblViews.TabIndex = 4;
            this.lblViews.Text = "Views: {0}";
            // 
            // lblTotalGfys
            // 
            this.lblTotalGfys.AutoSize = true;
            this.lblTotalGfys.Location = new System.Drawing.Point(267, 43);
            this.lblTotalGfys.Name = "lblTotalGfys";
            this.lblTotalGfys.Size = new System.Drawing.Size(113, 16);
            this.lblTotalGfys.TabIndex = 3;
            this.lblTotalGfys.Text = "Total Gfycats: {0} ";
            // 
            // lblPublicGfys
            // 
            this.lblPublicGfys.AutoSize = true;
            this.lblPublicGfys.Location = new System.Drawing.Point(267, 18);
            this.lblPublicGfys.Name = "lblPublicGfys";
            this.lblPublicGfys.Size = new System.Drawing.Size(116, 16);
            this.lblPublicGfys.TabIndex = 2;
            this.lblPublicGfys.Text = "Public Gfycats: {0}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(5, 18);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(134, 16);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "You are log in as {0}. ";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            statusStrip.Location = new System.Drawing.Point(4, 527);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            statusStrip.Size = new System.Drawing.Size(1423, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(1403, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContainTheProgressBar
            // 
            this.panelContainTheProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelContainTheProgressBar.AutoSize = true;
            this.panelContainTheProgressBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContainTheProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelContainTheProgressBar.Controls.Add(this.boxIndexingProgressDetails);
            this.panelContainTheProgressBar.Controls.Add(this.boxIndexingProgress);
            this.panelContainTheProgressBar.Controls.Add(this.labelIndexingProgress);
            this.panelContainTheProgressBar.Controls.Add(this.progressBarIndexing);
            this.panelContainTheProgressBar.Location = new System.Drawing.Point(399, 182);
            this.panelContainTheProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.panelContainTheProgressBar.Name = "panelContainTheProgressBar";
            this.panelContainTheProgressBar.Size = new System.Drawing.Size(625, 251);
            this.panelContainTheProgressBar.TabIndex = 0;
            // 
            // boxIndexingProgressDetails
            // 
            this.boxIndexingProgressDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxIndexingProgressDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.boxIndexingProgressDetails.AutoSize = true;
            this.boxIndexingProgressDetails.Location = new System.Drawing.Point(557, 6);
            this.boxIndexingProgressDetails.Margin = new System.Windows.Forms.Padding(4);
            this.boxIndexingProgressDetails.Name = "boxIndexingProgressDetails";
            this.boxIndexingProgressDetails.Size = new System.Drawing.Size(60, 26);
            this.boxIndexingProgressDetails.TabIndex = 1;
            this.boxIndexingProgressDetails.Text = "Details";
            this.boxIndexingProgressDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.boxIndexingProgressDetails.UseVisualStyleBackColor = true;
            this.boxIndexingProgressDetails.CheckedChanged += new System.EventHandler(this.boxIndexingProgressDetails_CheckedChanged);
            // 
            // boxIndexingProgress
            // 
            this.boxIndexingProgress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boxIndexingProgress.Location = new System.Drawing.Point(8, 75);
            this.boxIndexingProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 7);
            this.boxIndexingProgress.Multiline = true;
            this.boxIndexingProgress.Name = "boxIndexingProgress";
            this.boxIndexingProgress.ReadOnly = true;
            this.boxIndexingProgress.Size = new System.Drawing.Size(608, 169);
            this.boxIndexingProgress.TabIndex = 0;
            this.boxIndexingProgress.Visible = false;
            // 
            // labelIndexingProgress
            // 
            this.labelIndexingProgress.BackColor = System.Drawing.Color.Transparent;
            this.labelIndexingProgress.Location = new System.Drawing.Point(5, 6);
            this.labelIndexingProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIndexingProgress.Name = "labelIndexingProgress";
            this.labelIndexingProgress.Size = new System.Drawing.Size(613, 28);
            this.labelIndexingProgress.TabIndex = 1;
            this.labelIndexingProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarIndexing
            // 
            this.progressBarIndexing.Location = new System.Drawing.Point(8, 39);
            this.progressBarIndexing.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.progressBarIndexing.Name = "progressBarIndexing";
            this.progressBarIndexing.Size = new System.Drawing.Size(609, 28);
            this.progressBarIndexing.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarIndexing.TabIndex = 0;
            // 
            // panelHideTheOptions
            // 
            this.panelHideTheOptions.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelHideTheOptions.Controls.Add(this.panelContainTheProgressBar);
            this.panelHideTheOptions.Location = new System.Drawing.Point(4, 108);
            this.panelHideTheOptions.Margin = new System.Windows.Forms.Padding(4);
            this.panelHideTheOptions.Name = "panelHideTheOptions";
            this.panelHideTheOptions.Size = new System.Drawing.Size(1423, 438);
            this.panelHideTheOptions.TabIndex = 3;
            // 
            // listViewContextMenu
            // 
            this.listViewContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.listViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listViewContextMenuEdit,
            this.listViewContextMenuDelete});
            this.listViewContextMenu.Name = "listViewContextMenu";
            this.listViewContextMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // listViewContextMenuEdit
            // 
            this.listViewContextMenuEdit.Name = "listViewContextMenuEdit";
            this.listViewContextMenuEdit.Size = new System.Drawing.Size(107, 22);
            this.listViewContextMenuEdit.Text = "Edit...";
            this.listViewContextMenuEdit.Click += new System.EventHandler(this.listViewContextMenuEdit_Click);
            // 
            // listViewContextMenuDelete
            // 
            this.listViewContextMenuDelete.Name = "listViewContextMenuDelete";
            this.listViewContextMenuDelete.Size = new System.Drawing.Size(107, 22);
            this.listViewContextMenuDelete.Text = "Delete";
            this.listViewContextMenuDelete.Click += new System.EventHandler(this.listViewContextMenuDelete_Click);
            // 
            // txtType
            // 
            this.txtType.AutoSize = true;
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Location = new System.Drawing.Point(503, 68);
            this.txtType.Name = "txtType";
            this.txtType.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.txtType.Size = new System.Drawing.Size(49, 34);
            this.txtType.TabIndex = 27;
            this.txtType.Text = "Type";
            // 
            // comboStabType
            // 
            this.comboStabType.FormattingEnabled = true;
            this.comboStabType.Items.AddRange(new object[] {
            "bicubic",
            "bilinear",
            "linear",
            "no"});
            this.comboStabType.Location = new System.Drawing.Point(558, 71);
            this.comboStabType.Name = "comboStabType";
            this.comboStabType.Size = new System.Drawing.Size(78, 24);
            this.comboStabType.TabIndex = 28;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonGo;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 549);
            this.Controls.Add(statusStrip);
            this.Controls.Add(tableMainForm);
            this.Controls.Add(this.panelHideTheOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1293, 316);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebM for Lazys v{0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.HandleDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.HandleDragEnter);
            tableMainForm.ResumeLayout(false);
            groupMain.ResumeLayout(false);
            tableMain.ResumeLayout(false);
            tableMain.PerformLayout();
            tabControlOptions.ResumeLayout(false);
            tabProcessing.ResumeLayout(false);
            tableProcessing.ResumeLayout(false);
            tableProcessing.PerformLayout();
            toolStripProcessing.ResumeLayout(false);
            toolStripProcessing.PerformLayout();
            panelProcessingInput.ResumeLayout(false);
            panelProcessingInput.PerformLayout();
            tabEncoding.ResumeLayout(false);
            tableEncoding.ResumeLayout(false);
            groupEncodingGeneral.ResumeLayout(false);
            tableEncodingGeneral.ResumeLayout(false);
            tableEncodingGeneral.PerformLayout();
            groupEncodingVideo.ResumeLayout(false);
            this.tableLayoutPanelEncodingVideo.ResumeLayout(false);
            this.tableLayoutPanelEncodingVideo.PerformLayout();
            panelEncodingModeSwapper.ResumeLayout(false);
            this.tableVideoConstantOptions.ResumeLayout(false);
            this.tableVideoConstantOptions.PerformLayout();
            this.tableVideoVariableOptions.ResumeLayout(false);
            this.tableVideoVariableOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCrfTolerance)).EndInit();
            groupEncodingAudio.ResumeLayout(false);
            tableEncodingAudio.ResumeLayout(false);
            tableEncodingAudio.PerformLayout();
            panelEncodingModeSwapperTwo.ResumeLayout(false);
            this.tableAudioConstantOptions.ResumeLayout(false);
            this.tableAudioConstantOptions.PerformLayout();
            this.tableAudioVariableOptions.ResumeLayout(false);
            this.tableAudioVariableOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAudioQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            tabAdvanced.ResumeLayout(false);
            tableAdvanced.ResumeLayout(false);
            tableAdvanced.PerformLayout();
            groupAdvancedProcessing.ResumeLayout(false);
            tableAdvancedProcessing.ResumeLayout(false);
            tableAdvancedProcessing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericContrast)).EndInit();
            groupAdvancedEncoding.ResumeLayout(false);
            tableAdvancedEncoding.ResumeLayout(false);
            tableAdvancedEncoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSlices)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CRFother)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CRF4k)).EndInit();
            this.groupGfycat.ResumeLayout(false);
            this.groupGfycat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            this.panelContainTheProgressBar.ResumeLayout(false);
            this.panelContainTheProgressBar.PerformLayout();
            this.panelHideTheOptions.ResumeLayout(false);
            this.panelHideTheOptions.PerformLayout();
            this.listViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxIn;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.ToolStripButton buttonCrop;
        private System.Windows.Forms.ToolStripButton buttonResize;
        private System.Windows.Forms.ToolStripButton buttonReverse;
        private System.Windows.Forms.ToolStripButton buttonSubtitle;
        private System.Windows.Forms.TextBox textBoxProcessingScript;
        private System.Windows.Forms.TextBox boxTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEncodingVideo;
        private System.Windows.Forms.CheckBox boxHQ;
        private System.Windows.Forms.Panel panelHideTheOptions;
        private System.Windows.Forms.ProgressBar progressBarIndexing;
        private System.Windows.Forms.Label labelIndexingProgress;
        private System.Windows.Forms.TextBox boxArguments;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSplitButton buttonTrim;
        private System.Windows.Forms.ToolStripMenuItem buttonMultipleTrim;
        private System.Windows.Forms.ToolStripButton buttonCaption;
        private System.Windows.Forms.ToolStripButton buttonOverlay;
        private System.Windows.Forms.CheckBox boxAudio;
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ToolStripButton buttonPreview;
        private System.Windows.Forms.ImageList imageListFilters;
        private System.Windows.Forms.ListView listViewProcessingScript;
        private System.Windows.Forms.TrackBar trackSlices;
        private System.Windows.Forms.Label labelSlices;
        private System.Windows.Forms.TrackBar trackThreads;
        private System.Windows.Forms.Label labelThreads;
        private System.Windows.Forms.CheckBox boxNGOV;
        private System.Windows.Forms.RadioButton boxConstant;
        private System.Windows.Forms.RadioButton boxVariable;
        private System.Windows.Forms.TableLayoutPanel tableVideoConstantOptions;
        private System.Windows.Forms.TextBox boxBitrate;
        private System.Windows.Forms.TextBox boxLimit;
        private System.Windows.Forms.TableLayoutPanel tableVideoVariableOptions;
        private System.Windows.Forms.NumericUpDown numericCrf;
        private System.Windows.Forms.NumericUpDown numericCrfTolerance;
        private System.Windows.Forms.TableLayoutPanel tableAudioConstantOptions;
        private System.Windows.Forms.TextBox boxAudioBitrate;
        private System.Windows.Forms.TableLayoutPanel tableAudioVariableOptions;
        private System.Windows.Forms.NumericUpDown numericAudioQuality;
        private System.Windows.Forms.Button buttonConstantDefault;
        private System.Windows.Forms.Button buttonVariableDefault;
        private System.Windows.Forms.TextBox boxFrameRate;
        private System.Windows.Forms.ToolStripButton buttonExportProcessing;
        public System.Windows.Forms.ToolStripButton boxAdvancedScripting;
        private System.Windows.Forms.TextBox boxIndexingProgress;
        private System.Windows.Forms.CheckBox boxIndexingProgressDetails;
        private System.Windows.Forms.Panel panelContainTheProgressBar;
        private System.Windows.Forms.ToolStripButton buttonDub;
        private System.Windows.Forms.ToolStripButton buttonRate;
        private System.Windows.Forms.ToolStripButton buttonRotate;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem listViewContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem listViewContextMenuDelete;
        private System.Windows.Forms.ToolStripButton buttonFade;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonPathChange;
        private System.Windows.Forms.TextBox textPathDownloaded;
        private System.Windows.Forms.Label lblPathDownload;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelMaintained;
        private System.Windows.Forms.ComboBox comboLevels;
        private System.Windows.Forms.CheckBox boxDeinterlace;
        private System.Windows.Forms.CheckBox boxDenoise;
        private System.Windows.Forms.CheckBox boxLoop;
        private System.Windows.Forms.Label lblFollowers;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label lblTotalGfys;
        private System.Windows.Forms.Label lblPublicGfys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.TextBox boxTags;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.NumericUpDown CRFother;
        private System.Windows.Forms.NumericUpDown CRF4k;
        private System.Windows.Forms.Label lblCRFConfiguration2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCRFConfiguration;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Label labelSaturation;
        private System.Windows.Forms.NumericUpDown numericGamma;
        private System.Windows.Forms.NumericUpDown numericSaturation;
        private System.Windows.Forms.GroupBox groupGfycat;
        private System.Windows.Forms.Button buttonPreview2;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.NumericUpDown numericContrast;
        private System.Windows.Forms.Button buttonOpenPath;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.CheckBox checkMP4;
        private System.Windows.Forms.Label labelSizeLimit;
        private System.Windows.Forms.CheckBox checkHWAcceleration;
        private System.Windows.Forms.CheckBox boxStabilization;
        private System.Windows.Forms.Label txtLevel;
        private System.Windows.Forms.ComboBox comboBoxLevels;
        private System.Windows.Forms.Label txtType;
        private System.Windows.Forms.ComboBox comboStabType;
        // private System.Windows.Forms.GroupBox groupGfycat;
    }
}
