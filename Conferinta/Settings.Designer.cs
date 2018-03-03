namespace Conferinta
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.dataSourceLab = new System.Windows.Forms.Label();
            this.dataSourcetextBox = new System.Windows.Forms.TextBox();
            this.initCatTextBox = new System.Windows.Forms.TextBox();
            this.initCatLab = new System.Windows.Forms.Label();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.userIDLab = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.passLab = new System.Windows.Forms.Label();
            this.saveConBtn = new System.Windows.Forms.Button();
            this.cancelSetBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.showPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dataSourceLab
            // 
            this.dataSourceLab.AutoSize = true;
            this.dataSourceLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataSourceLab.Location = new System.Drawing.Point(51, 61);
            this.dataSourceLab.Name = "dataSourceLab";
            this.dataSourceLab.Size = new System.Drawing.Size(96, 22);
            this.dataSourceLab.TabIndex = 0;
            this.dataSourceLab.Text = "DataSource";
            // 
            // dataSourcetextBox
            // 
            this.dataSourcetextBox.Location = new System.Drawing.Point(201, 64);
            this.dataSourcetextBox.Name = "dataSourcetextBox";
            this.dataSourcetextBox.Size = new System.Drawing.Size(213, 20);
            this.dataSourcetextBox.TabIndex = 1;
            // 
            // initCatTextBox
            // 
            this.initCatTextBox.Location = new System.Drawing.Point(201, 139);
            this.initCatTextBox.Name = "initCatTextBox";
            this.initCatTextBox.Size = new System.Drawing.Size(213, 20);
            this.initCatTextBox.TabIndex = 3;
            // 
            // initCatLab
            // 
            this.initCatLab.AutoSize = true;
            this.initCatLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.initCatLab.Location = new System.Drawing.Point(51, 136);
            this.initCatLab.Name = "initCatLab";
            this.initCatLab.Size = new System.Drawing.Size(116, 22);
            this.initCatLab.TabIndex = 2;
            this.initCatLab.Text = "Initial Catalog";
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Location = new System.Drawing.Point(201, 200);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(213, 20);
            this.userIDTextBox.TabIndex = 5;
            // 
            // userIDLab
            // 
            this.userIDLab.AutoSize = true;
            this.userIDLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userIDLab.Location = new System.Drawing.Point(51, 197);
            this.userIDLab.Name = "userIDLab";
            this.userIDLab.Size = new System.Drawing.Size(67, 22);
            this.userIDLab.TabIndex = 4;
            this.userIDLab.Text = "User ID";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(201, 271);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(213, 20);
            this.passTextBox.TabIndex = 7;
            // 
            // passLab
            // 
            this.passLab.AutoSize = true;
            this.passLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.passLab.Location = new System.Drawing.Point(51, 268);
            this.passLab.Name = "passLab";
            this.passLab.Size = new System.Drawing.Size(81, 22);
            this.passLab.TabIndex = 6;
            this.passLab.Text = "Password";
            // 
            // saveConBtn
            // 
            this.saveConBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.saveConBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveConBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveConBtn.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveConBtn.Location = new System.Drawing.Point(338, 366);
            this.saveConBtn.Name = "saveConBtn";
            this.saveConBtn.Size = new System.Drawing.Size(75, 23);
            this.saveConBtn.TabIndex = 8;
            this.saveConBtn.Text = "Save";
            this.saveConBtn.UseVisualStyleBackColor = false;
            this.saveConBtn.Click += new System.EventHandler(this.saveConBtn_Click);
            // 
            // cancelSetBtn
            // 
            this.cancelSetBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cancelSetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelSetBtn.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cancelSetBtn.Location = new System.Drawing.Point(248, 366);
            this.cancelSetBtn.Name = "cancelSetBtn";
            this.cancelSetBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelSetBtn.TabIndex = 9;
            this.cancelSetBtn.Text = "Cancel";
            this.cancelSetBtn.UseVisualStyleBackColor = false;
            this.cancelSetBtn.Click += new System.EventHandler(this.cancelSetBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.testBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.testBtn.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.testBtn.Location = new System.Drawing.Point(43, 366);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 10;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // showPass
            // 
            this.showPass.AutoSize = true;
            this.showPass.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showPass.Location = new System.Drawing.Point(297, 297);
            this.showPass.Name = "showPass";
            this.showPass.Size = new System.Drawing.Size(117, 18);
            this.showPass.TabIndex = 11;
            this.showPass.Text = "Show password";
            this.showPass.UseVisualStyleBackColor = true;
            this.showPass.CheckStateChanged += new System.EventHandler(this.showPass_CheckStateChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 401);
            this.Controls.Add(this.showPass);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.cancelSetBtn);
            this.Controls.Add(this.saveConBtn);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.passLab);
            this.Controls.Add(this.userIDTextBox);
            this.Controls.Add(this.userIDLab);
            this.Controls.Add(this.initCatTextBox);
            this.Controls.Add(this.initCatLab);
            this.Controls.Add(this.dataSourcetextBox);
            this.Controls.Add(this.dataSourceLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dataSourceLab;
        private System.Windows.Forms.TextBox dataSourcetextBox;
        private System.Windows.Forms.TextBox initCatTextBox;
        private System.Windows.Forms.Label initCatLab;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.Label userIDLab;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label passLab;
        private System.Windows.Forms.Button saveConBtn;
        private System.Windows.Forms.Button cancelSetBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.CheckBox showPass;
    }
}