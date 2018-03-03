namespace Conferinta
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingsBtn = new System.Windows.Forms.PictureBox();
            this.SearchButton = new System.Windows.Forms.PictureBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.delPic = new System.Windows.Forms.PictureBox();
            this.hbPic = new System.Windows.Forms.PictureBox();
            this.addBox = new System.Windows.Forms.PictureBox();
            this.facBtn = new System.Windows.Forms.Button();
            this.clientiBtn = new System.Windows.Forms.Button();
            this.saliBtn = new System.Windows.Forms.Button();
            this.Angajati = new System.Windows.Forms.Button();
            this.Conferinte = new System.Windows.Forms.Button();
            this.FlowPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.regionButton = new System.Windows.Forms.Panel();
            this.alsButton = new System.Windows.Forms.Button();
            this.rasButton = new System.Windows.Forms.Button();
            this.ocButton = new System.Windows.Forms.Button();
            this.cdssButton = new System.Windows.Forms.Button();
            this.cmfcButton = new System.Windows.Forms.Button();
            this.cmcsButton = new System.Windows.Forms.Button();
            this.cmvfcButton = new System.Windows.Forms.Button();
            this.salaRegion = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nrPretLab = new System.Windows.Forms.Label();
            this.nrLocLab = new System.Windows.Forms.Label();
            this.pretLab = new System.Windows.Forms.Label();
            this.locLab = new System.Windows.Forms.Label();
            this.salaPic = new System.Windows.Forms.PictureBox();
            this.salaLab = new System.Windows.Forms.Label();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.regionPic = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBox)).BeginInit();
            this.FlowPannel.SuspendLayout();
            this.regionButton.SuspendLayout();
            this.salaRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.regionPic.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.settingsBtn);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Controls.Add(this.Close);
            this.panel1.Location = new System.Drawing.Point(199, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 48);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBtn.Image = global::Conferinta.Properties.Resources._002_settings;
            this.settingsBtn.Location = new System.Drawing.Point(506, 10);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(27, 28);
            this.settingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsBtn.TabIndex = 4;
            this.settingsBtn.TabStop = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            this.settingsBtn.MouseLeave += new System.EventHandler(this.settingsBtn_MouseLeave);
            this.settingsBtn.MouseHover += new System.EventHandler(this.settingsBtn_MouseHover);
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Image = global::Conferinta.Properties.Resources._001_search;
            this.SearchButton.Location = new System.Drawing.Point(454, 14);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(23, 20);
            this.SearchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SearchButton.TabIndex = 2;
            this.SearchButton.TabStop = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchTextBox.Location = new System.Drawing.Point(23, 14);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(425, 20);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            this.SearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTextBox_KeyPress);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.Image = global::Conferinta.Properties.Resources._004_error;
            this.Close.Location = new System.Drawing.Point(662, 3);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(38, 35);
            this.Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Close.TabIndex = 0;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel2.Controls.Add(this.delPic);
            this.panel2.Controls.Add(this.hbPic);
            this.panel2.Controls.Add(this.addBox);
            this.panel2.Controls.Add(this.facBtn);
            this.panel2.Controls.Add(this.clientiBtn);
            this.panel2.Controls.Add(this.saliBtn);
            this.panel2.Controls.Add(this.Angajati);
            this.panel2.Controls.Add(this.Conferinte);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 504);
            this.panel2.TabIndex = 1;
            // 
            // delPic
            // 
            this.delPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delPic.Image = global::Conferinta.Properties.Resources._002_waste_bin;
            this.delPic.Location = new System.Drawing.Point(104, 467);
            this.delPic.Name = "delPic";
            this.delPic.Size = new System.Drawing.Size(28, 28);
            this.delPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delPic.TabIndex = 9;
            this.delPic.TabStop = false;
            this.delPic.Click += new System.EventHandler(this.delPic_Click);
            this.delPic.MouseLeave += new System.EventHandler(this.delPic_MouseLeave);
            this.delPic.MouseHover += new System.EventHandler(this.delPic_MouseHover);
            // 
            // hbPic
            // 
            this.hbPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hbPic.Image = global::Conferinta.Properties.Resources.Logo;
            this.hbPic.Location = new System.Drawing.Point(0, 0);
            this.hbPic.Name = "hbPic";
            this.hbPic.Size = new System.Drawing.Size(200, 100);
            this.hbPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hbPic.TabIndex = 8;
            this.hbPic.TabStop = false;
            this.hbPic.Click += new System.EventHandler(this.hbPic_Click);
            // 
            // addBox
            // 
            this.addBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBox.Image = global::Conferinta.Properties.Resources._001_plus_sign_silhouette_1;
            this.addBox.Location = new System.Drawing.Point(58, 467);
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(28, 28);
            this.addBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addBox.TabIndex = 7;
            this.addBox.TabStop = false;
            this.addBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.addBox.MouseLeave += new System.EventHandler(this.addBox_MouseLeave);
            this.addBox.MouseHover += new System.EventHandler(this.addBox_MouseHover);
            // 
            // facBtn
            // 
            this.facBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.facBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.facBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facBtn.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.facBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.facBtn.Location = new System.Drawing.Point(3, 382);
            this.facBtn.Name = "facBtn";
            this.facBtn.Size = new System.Drawing.Size(194, 37);
            this.facBtn.TabIndex = 4;
            this.facBtn.Text = "Facilitati";
            this.facBtn.UseVisualStyleBackColor = false;
            this.facBtn.Click += new System.EventHandler(this.facBtn_Click);
            this.facBtn.MouseLeave += new System.EventHandler(this.facBtn_MouseLeave);
            this.facBtn.MouseHover += new System.EventHandler(this.facBtn_MouseHover);
            // 
            // clientiBtn
            // 
            this.clientiBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.clientiBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientiBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.clientiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientiBtn.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clientiBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientiBtn.Location = new System.Drawing.Point(3, 249);
            this.clientiBtn.Name = "clientiBtn";
            this.clientiBtn.Size = new System.Drawing.Size(194, 37);
            this.clientiBtn.TabIndex = 2;
            this.clientiBtn.Text = "Clienti";
            this.clientiBtn.UseVisualStyleBackColor = false;
            this.clientiBtn.Click += new System.EventHandler(this.clientiBtn_Click);
            this.clientiBtn.MouseLeave += new System.EventHandler(this.clientiBtn_MouseLeave);
            this.clientiBtn.MouseHover += new System.EventHandler(this.clientiBtn_MouseHover);
            // 
            // saliBtn
            // 
            this.saliBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saliBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saliBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.saliBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saliBtn.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saliBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saliBtn.Location = new System.Drawing.Point(3, 183);
            this.saliBtn.Name = "saliBtn";
            this.saliBtn.Size = new System.Drawing.Size(194, 37);
            this.saliBtn.TabIndex = 1;
            this.saliBtn.Text = "Sali";
            this.saliBtn.UseVisualStyleBackColor = false;
            this.saliBtn.Click += new System.EventHandler(this.saliBtn_Click);
            this.saliBtn.MouseLeave += new System.EventHandler(this.saliBtn_MouseLeave);
            this.saliBtn.MouseHover += new System.EventHandler(this.saliBtn_MouseHover);
            // 
            // Angajati
            // 
            this.Angajati.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Angajati.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Angajati.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Angajati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Angajati.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Angajati.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Angajati.Location = new System.Drawing.Point(3, 314);
            this.Angajati.Name = "Angajati";
            this.Angajati.Size = new System.Drawing.Size(194, 37);
            this.Angajati.TabIndex = 3;
            this.Angajati.Text = "Angajati";
            this.Angajati.UseVisualStyleBackColor = false;
            this.Angajati.Click += new System.EventHandler(this.Angajati_Click);
            this.Angajati.MouseLeave += new System.EventHandler(this.Angajati_MouseLeave);
            this.Angajati.MouseHover += new System.EventHandler(this.Angajati_MouseHover);
            // 
            // Conferinte
            // 
            this.Conferinte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Conferinte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Conferinte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Conferinte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Conferinte.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Conferinte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Conferinte.Location = new System.Drawing.Point(3, 118);
            this.Conferinte.Name = "Conferinte";
            this.Conferinte.Size = new System.Drawing.Size(194, 37);
            this.Conferinte.TabIndex = 0;
            this.Conferinte.Text = "Conferinte";
            this.Conferinte.UseVisualStyleBackColor = false;
            this.Conferinte.Click += new System.EventHandler(this.Conferinte_Click);
            this.Conferinte.MouseLeave += new System.EventHandler(this.Conferinte_MouseLeave);
            this.Conferinte.MouseHover += new System.EventHandler(this.Conferinte_MouseHover);
            // 
            // FlowPannel
            // 
            this.FlowPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowPannel.AutoScroll = true;
            this.FlowPannel.BackColor = System.Drawing.Color.Transparent;
            this.FlowPannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlowPannel.Controls.Add(this.regionButton);
            this.FlowPannel.Controls.Add(this.salaRegion);
            this.FlowPannel.Controls.Add(this.dataChart);
            this.FlowPannel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FlowPannel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FlowPannel.Location = new System.Drawing.Point(2, 7);
            this.FlowPannel.Name = "FlowPannel";
            this.FlowPannel.Size = new System.Drawing.Size(708, 423);
            this.FlowPannel.TabIndex = 2;
            // 
            // regionButton
            // 
            this.regionButton.Controls.Add(this.alsButton);
            this.regionButton.Controls.Add(this.rasButton);
            this.regionButton.Controls.Add(this.ocButton);
            this.regionButton.Controls.Add(this.cdssButton);
            this.regionButton.Controls.Add(this.cmfcButton);
            this.regionButton.Controls.Add(this.cmcsButton);
            this.regionButton.Controls.Add(this.cmvfcButton);
            this.regionButton.Location = new System.Drawing.Point(3, 3);
            this.regionButton.Name = "regionButton";
            this.regionButton.Size = new System.Drawing.Size(321, 196);
            this.regionButton.TabIndex = 0;
            // 
            // alsButton
            // 
            this.alsButton.BackColor = System.Drawing.Color.Transparent;
            this.alsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.alsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.alsButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.alsButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.alsButton.Location = new System.Drawing.Point(88, 137);
            this.alsButton.Name = "alsButton";
            this.alsButton.Size = new System.Drawing.Size(141, 56);
            this.alsButton.TabIndex = 6;
            this.alsButton.Text = "Angajat la sala cu profit > 1000";
            this.alsButton.UseVisualStyleBackColor = false;
            this.alsButton.Click += new System.EventHandler(this.ang1LinkLabel_LinkClicked);
            // 
            // rasButton
            // 
            this.rasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rasButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rasButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rasButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rasButton.Location = new System.Drawing.Point(228, 65);
            this.rasButton.Name = "rasButton";
            this.rasButton.Size = new System.Drawing.Size(75, 56);
            this.rasButton.TabIndex = 5;
            this.rasButton.Text = "Raport Angajat-Sala";
            this.rasButton.UseVisualStyleBackColor = true;
            this.rasButton.Click += new System.EventHandler(this.raportLinkLabel_LinkClicked);
            // 
            // ocButton
            // 
            this.ocButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ocButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ocButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ocButton.Location = new System.Drawing.Point(228, 3);
            this.ocButton.Name = "ocButton";
            this.ocButton.Size = new System.Drawing.Size(75, 56);
            this.ocButton.TabIndex = 2;
            this.ocButton.Text = "Oferte Clienti";
            this.ocButton.UseVisualStyleBackColor = true;
            this.ocButton.Click += new System.EventHandler(this.clie3LinkLabel_LinkClicked);
            // 
            // cdssButton
            // 
            this.cdssButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cdssButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cdssButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.cdssButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cdssButton.Location = new System.Drawing.Point(120, 65);
            this.cdssButton.Name = "cdssButton";
            this.cdssButton.Size = new System.Drawing.Size(75, 56);
            this.cdssButton.TabIndex = 4;
            this.cdssButton.Text = "Conf Sala Scumpa";
            this.cdssButton.UseVisualStyleBackColor = true;
            this.cdssButton.Click += new System.EventHandler(this.conf1LinkLabel_LinkClicked);
            // 
            // cmfcButton
            // 
            this.cmfcButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmfcButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmfcButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cmfcButton.Location = new System.Drawing.Point(16, 71);
            this.cmfcButton.Name = "cmfcButton";
            this.cmfcButton.Size = new System.Drawing.Size(75, 56);
            this.cmfcButton.TabIndex = 3;
            this.cmfcButton.Text = "Clienti Fideli";
            this.cmfcButton.UseVisualStyleBackColor = true;
            this.cmfcButton.Click += new System.EventHandler(this.clientLinkLabel_LinkClicked);
            // 
            // cmcsButton
            // 
            this.cmcsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmcsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmcsButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cmcsButton.Location = new System.Drawing.Point(120, 3);
            this.cmcsButton.Name = "cmcsButton";
            this.cmcsButton.Size = new System.Drawing.Size(75, 56);
            this.cmcsButton.TabIndex = 1;
            this.cmcsButton.Text = "Sali Cautate";
            this.cmcsButton.UseVisualStyleBackColor = true;
            this.cmcsButton.Click += new System.EventHandler(this.salaLinkLabel_LinkClicked);
            // 
            // cmvfcButton
            // 
            this.cmvfcButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmvfcButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmvfcButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.cmvfcButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cmvfcButton.Location = new System.Drawing.Point(17, 3);
            this.cmvfcButton.Name = "cmvfcButton";
            this.cmvfcButton.Size = new System.Drawing.Size(75, 56);
            this.cmvfcButton.TabIndex = 0;
            this.cmvfcButton.Text = "Facilitati Vandute";
            this.cmvfcButton.UseVisualStyleBackColor = true;
            this.cmvfcButton.Click += new System.EventHandler(this.facVandLinkLabel_LinkClicked);
            // 
            // salaRegion
            // 
            this.salaRegion.Controls.Add(this.textBox1);
            this.salaRegion.Controls.Add(this.nrPretLab);
            this.salaRegion.Controls.Add(this.nrLocLab);
            this.salaRegion.Controls.Add(this.pretLab);
            this.salaRegion.Controls.Add(this.locLab);
            this.salaRegion.Controls.Add(this.salaPic);
            this.salaRegion.Controls.Add(this.salaLab);
            this.salaRegion.Location = new System.Drawing.Point(330, 3);
            this.salaRegion.Name = "salaRegion";
            this.salaRegion.Size = new System.Drawing.Size(367, 193);
            this.salaRegion.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Tomato;
            this.textBox1.Location = new System.Drawing.Point(225, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "sadsa";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // nrPretLab
            // 
            this.nrPretLab.AutoSize = true;
            this.nrPretLab.ForeColor = System.Drawing.Color.White;
            this.nrPretLab.Location = new System.Drawing.Point(291, 145);
            this.nrPretLab.Name = "nrPretLab";
            this.nrPretLab.Size = new System.Drawing.Size(32, 18);
            this.nrPretLab.TabIndex = 5;
            this.nrPretLab.Text = "100";
            // 
            // nrLocLab
            // 
            this.nrLocLab.AutoSize = true;
            this.nrLocLab.ForeColor = System.Drawing.Color.White;
            this.nrLocLab.Location = new System.Drawing.Point(291, 80);
            this.nrLocLab.Name = "nrLocLab";
            this.nrLocLab.Size = new System.Drawing.Size(32, 18);
            this.nrLocLab.TabIndex = 4;
            this.nrLocLab.Text = "100";
            // 
            // pretLab
            // 
            this.pretLab.AutoSize = true;
            this.pretLab.ForeColor = System.Drawing.Color.White;
            this.pretLab.Location = new System.Drawing.Point(222, 145);
            this.pretLab.Name = "pretLab";
            this.pretLab.Size = new System.Drawing.Size(48, 18);
            this.pretLab.TabIndex = 3;
            this.pretLab.Text = "Pret:";
            // 
            // locLab
            // 
            this.locLab.AutoSize = true;
            this.locLab.ForeColor = System.Drawing.Color.White;
            this.locLab.Location = new System.Drawing.Point(222, 80);
            this.locLab.Name = "locLab";
            this.locLab.Size = new System.Drawing.Size(64, 18);
            this.locLab.TabIndex = 2;
            this.locLab.Text = "Locuri:";
            // 
            // salaPic
            // 
            this.salaPic.Location = new System.Drawing.Point(3, 44);
            this.salaPic.Name = "salaPic";
            this.salaPic.Size = new System.Drawing.Size(205, 146);
            this.salaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.salaPic.TabIndex = 1;
            this.salaPic.TabStop = false;
            // 
            // salaLab
            // 
            this.salaLab.AutoSize = true;
            this.salaLab.Font = new System.Drawing.Font("Garamond", 23.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.salaLab.ForeColor = System.Drawing.Color.White;
            this.salaLab.Location = new System.Drawing.Point(31, 6);
            this.salaLab.Name = "salaLab";
            this.salaLab.Size = new System.Drawing.Size(149, 35);
            this.salaLab.TabIndex = 0;
            this.salaLab.Text = "nume sala";
            // 
            // dataChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(3, 205);
            this.dataChart.Name = "dataChart";
            this.dataChart.Size = new System.Drawing.Size(696, 186);
            this.dataChart.TabIndex = 3;
            this.dataChart.Text = "chart1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBox2.Image = global::Conferinta.Properties.Resources.resize;
            this.pictureBox2.Location = new System.Drawing.Point(687, 436);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // regionPic
            // 
            this.regionPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regionPic.BackgroundImage = global::Conferinta.Properties.Resources.Final_2_0;
            this.regionPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.regionPic.Controls.Add(this.FlowPannel);
            this.regionPic.Controls.Add(this.pictureBox2);
            this.regionPic.Location = new System.Drawing.Point(200, 46);
            this.regionPic.Name = "regionPic";
            this.regionPic.Size = new System.Drawing.Size(713, 457);
            this.regionPic.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Conferinta.Properties.Resources.Final_2_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(913, 502);
            this.Controls.Add(this.regionPic);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conferinte";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.delPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBox)).EndInit();
            this.FlowPannel.ResumeLayout(false);
            this.regionButton.ResumeLayout(false);
            this.salaRegion.ResumeLayout(false);
            this.salaRegion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.regionPic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Conferinte;
        private System.Windows.Forms.Button Angajati;
        private System.Windows.Forms.FlowLayoutPanel FlowPannel;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.PictureBox SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button clientiBtn;
        private System.Windows.Forms.Button saliBtn;
        private System.Windows.Forms.Button facBtn;
        private System.Windows.Forms.PictureBox addBox;
        private System.Windows.Forms.PictureBox hbPic;
        private System.Windows.Forms.Panel regionPic;
        private System.Windows.Forms.PictureBox settingsBtn;
        private System.Windows.Forms.PictureBox delPic;
        private System.Windows.Forms.Panel regionButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.Button cmvfcButton;
        private System.Windows.Forms.Button cmcsButton;
        private System.Windows.Forms.Button alsButton;
        private System.Windows.Forms.Button rasButton;
        private System.Windows.Forms.Button ocButton;
        private System.Windows.Forms.Button cdssButton;
        private System.Windows.Forms.Button cmfcButton;
        private System.Windows.Forms.Panel salaRegion;
        private System.Windows.Forms.Label salaLab;
        private System.Windows.Forms.Label nrPretLab;
        private System.Windows.Forms.Label nrLocLab;
        private System.Windows.Forms.Label pretLab;
        private System.Windows.Forms.Label locLab;
        private System.Windows.Forms.PictureBox salaPic;
        private System.Windows.Forms.TextBox textBox1;
    }
}

