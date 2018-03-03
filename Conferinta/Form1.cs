using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Conferinta
{

    public partial class Form1 : Form
    {
        //Variabile
        SqlConnection connection = new SqlConnection("Data Source = JOHNDOE\\SQLEXPRESS;" +
            " Initial Catalog = Management_Conferinte; Persist Security Info=True;" +
            "User ID = sa; Password=cris1296");
        bool confPress = false;
        bool angPress = false;
        bool clientiPress = false;
        bool salaPress = false;
        bool facPress = false;
        bool togMove;
        bool resize;
        bool canAdd = false;
        bool canDelete = false;
        bool runDashboard = true;
        bool exitChange = true;
        bool readyToSave = false;
        Button lastPressed;
        int mValX, mValY;
        int contor;
        List<int> preturiFac;
        List<int> facID;
        List<int> preturiSala;
        List<int> salaID;
        List<int> salaLoc;
        List<int> angID;
        List<string> angEmailList;
        List<string> angPozaList;
        List<string> salaPozaList;
        List<string> numeSalaList;
        int lastAddSala = 0;
        int currentAddFac = 0;
        int dateDiff = 1;
        string Email;
        string selOption="";
        string table;
        string colName;
        string tableUni;
        string prevUniVal;
        int idToUp = 0;
        int idToDel = 0;
        Panel previousSelectedPanel;
        Panel currentSelectedpanel;
        Point initLoc;
        AutoCompleteStringCollection source;
        Task tsk;

        /// <summary>
        /// SETS/GETS SQLConnection string.
        /// </summary>
        [CategoryAttribute("Custom Settings"), DescriptionAttribute(@"SETS/GETS SQLConnection")]
        public SqlConnection ConnectionSql
        {
            get
            {
                return connection;
            }

            set
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection = value;

                try
                {
                    connection.Open();
                }
                catch (SqlException er)
                {
                    MessageBox.Show("SQL Server returned: " + er.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            try
            {
                connection.Open();
                tsk = null;
                FlowPannel.Controls.Clear();
                Dashboard();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server returned: " + er.Message +"\n\n You may want to check Settings!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Highlight(Button btn)
        {
            btn.Font = new Font(btn.Font, FontStyle.Italic);
            btn.BackColor = Color.FromArgb(54, 70, 86);
        }

        private void NormalLight(Button btn)
        {
            btn.Font = new Font(btn.Font, FontStyle.Regular);
            btn.BackColor = Color.FromArgb(41, 63, 65);
        }

        private void Conferinte_MouseHover(object sender, EventArgs e)
        {
            if (!confPress)
            {
                Highlight(Conferinte);
            }
        }

        private void Conferinte_MouseLeave(object sender, EventArgs e)
        {
            if (!confPress)
            {
                NormalLight(Conferinte);
            }
        }

        private void Angajati_MouseHover(object sender, EventArgs e)
        {
            if (!angPress)
            {
                Highlight(Angajati);
            }
        }

        private void Angajati_MouseLeave(object sender, EventArgs e)
        {
            if (!angPress)
            {
                NormalLight(Angajati);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ListConf(ref SqlDataReader funcReader)
        {
            Size CONF_SIZE = new Size(710, 153);
            Point CONF_INIT_LOC = new Point(3, 3);
            previousSelectedPanel = null;
            idToDel = 0;

            Panel region = new Panel();
            PictureBox sala_pic = new PictureBox();
            Label numeConf = new Label();
            Label numeClient = new Label();
            Label dataI = new Label();
            Label dataS = new Label();
            Label pret = new Label();
            Label sala_lab = new Label();
            // 
            // region
            // 
            region.AccessibleName = funcReader[6].ToString();
            region.AutoScroll = true;
            region.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            //region.BackColor = System.Drawing.Color.Transparent;
            region.BackColor = System.Drawing.Color.White;
           // region.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            region.Controls.Add(sala_lab);
            region.Controls.Add(pret);
            region.Controls.Add(dataS);
            region.Controls.Add(dataI);
            region.Controls.Add(numeClient);
            region.Controls.Add(numeConf);
            region.Controls.Add(sala_pic);
            //region.ForeColor = System.Drawing.Color.White;
            region.Location = new System.Drawing.Point(3, contor * (CONF_SIZE.Height + 3) + 3);
            region.Name = "region" + contor.ToString();
            region.Size = new System.Drawing.Size(710, 153);
            region.TabIndex = contor + 8;
            region.DoubleClick += new EventHandler(UpdateThing);
            region.Click += new EventHandler(SingleClick);

            //sala_pic

            if (funcReader[7] != DBNull.Value)
            {
                sala_pic.ImageLocation = @funcReader[7].ToString();
            }
            else
            {
                sala_pic.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Icons\003-no-photo.png";
            }
            sala_pic.Location = new System.Drawing.Point(3, 42);
            sala_pic.Name = "sala_pic" + contor.ToString();
            sala_pic.Size = new System.Drawing.Size(112, 104);
            sala_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            sala_pic.TabIndex = contor + 0;
            sala_pic.TabStop = false;

            //sala_lab

            sala_lab.AutoSize = true;
            sala_lab.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            sala_lab.Location = new System.Drawing.Point(150, 127);
            sala_lab.Name = "sala_lab" + contor.ToString();
            sala_lab.Size = new System.Drawing.Size(54, 19);
            sala_lab.TabIndex = contor + 6;
            sala_lab.Text = "Sala: " + funcReader[2].ToString();

            //pret

            pret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pret.AutoSize = true;
            pret.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pret.Location = new System.Drawing.Point(483, 127);
            pret.Name = "pret" + contor.ToString();
            pret.Size = new System.Drawing.Size(54, 19);
            pret.TabIndex = contor + 5;
            pret.Text = "Pret: " + funcReader[5].ToString();

            //dataS

            dataS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dataS.AutoSize = true;
            dataS.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataS.Location = new System.Drawing.Point(410, 74);
            dataS.Name = "dataS" + contor.ToString();
            dataS.Size = new System.Drawing.Size(81, 19);
            dataS.TabIndex = contor + 4;
            dataS.Text = "Sfarsit: " + funcReader.GetDateTime(4).Date.ToShortDateString();

            //dataI

            dataI.AutoSize = true;
            dataI.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataI.Location = new System.Drawing.Point(150, 74);
            dataI.Name = "dataI" + contor.ToString();
            dataI.Size = new System.Drawing.Size(72, 19);
            dataI.TabIndex = contor + 3;
            dataI.Text = "Incepe: " + funcReader.GetDateTime(3).Date.ToShortDateString();

            //numeClient

            numeClient.AutoSize = true;
            numeClient.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeClient.Location = new System.Drawing.Point(150, 46);
            numeClient.Name = "numeClient" + contor.ToString();
            numeClient.Size = new System.Drawing.Size(117, 19);
            numeClient.TabIndex = contor + 2;
            numeClient.Text = "Nume client: " + funcReader[1].ToString();

            //numeConf

            numeConf.AutoSize = true;
            numeConf.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeConf.Location = new System.Drawing.Point(3, 12);
            numeConf.Name = "numeConf" + contor.ToString();
            numeConf.Size = new System.Drawing.Size(160, 22);
            numeConf.TabIndex = contor + 1;
            numeConf.Text = funcReader[0].ToString();


            FlowPannel.Controls.Add(region);
        }

        private void ListClienti(ref SqlDataReader funcReader)
        {
            Size CLIENTI_SIZE = new Size(710, 52);
            Point INIT_POINT = new Point(3, 3);
            previousSelectedPanel = null;
            idToDel = 0;

            Panel regionClient = new System.Windows.Forms.Panel();
            PictureBox clientPicture = new System.Windows.Forms.PictureBox();
            Label clientNume = new System.Windows.Forms.Label();
            Label clientTel = new System.Windows.Forms.Label();
            Label clientMail = new System.Windows.Forms.Label();

            regionClient.AccessibleName = funcReader[4].ToString();
            regionClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            regionClient.AutoScroll = true;
            regionClient.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionClient.Controls.Add(clientMail);
            regionClient.Controls.Add(clientTel);
            regionClient.Controls.Add(clientNume);
            regionClient.Controls.Add(clientPicture);
            regionClient.Location = new System.Drawing.Point(3, contor * (CLIENTI_SIZE.Height + 3) + 3);
            regionClient.Name = "region" + contor.ToString();
            regionClient.Size = new System.Drawing.Size(710, 52);
            regionClient.TabIndex = 1 + contor;
            regionClient.DoubleClick += new EventHandler(UpdateThing);
            regionClient.Click += new EventHandler(SingleClick);

            //clientPicture

            if (funcReader[3].ToString() == "M")
            {
                clientPicture.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Icons\001-avatar-1.png";
            }
            else
            {
                clientPicture.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Icons\002-woman.png";
            }
            clientPicture.Location = new System.Drawing.Point(3, 3);
            clientPicture.Name = "clientPicture" + contor.ToString();
            clientPicture.Size = new System.Drawing.Size(49, 46);
            clientPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            clientPicture.TabIndex = 0 + contor;
            clientPicture.TabStop = false;

            // clientNume

            clientNume.AutoSize = true;
            clientNume.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            clientNume.Location = new System.Drawing.Point(71, 15);
            clientNume.Name = "clientNume" + contor.ToString();
            clientNume.Size = new System.Drawing.Size(128, 26);
            clientNume.TabIndex = 1 + contor;
            clientNume.Text = funcReader[0].ToString();

            //clientTel

            clientTel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            clientTel.AutoSize = true;
            clientTel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            clientTel.Location = new System.Drawing.Point(307, 19);
            clientTel.Name = "clientTel" + contor.ToString();
            clientTel.Size = new System.Drawing.Size(99, 19);
            clientTel.TabIndex = 2 + contor;
            clientTel.Text = funcReader[1].ToString();

            //clientMail

            clientMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            clientMail.AutoSize = true;
            clientMail.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            clientMail.Location = new System.Drawing.Point(466, 19);
            clientMail.Name = "clientMail" + contor.ToString();
            clientMail.Size = new System.Drawing.Size(216, 19);
            clientMail.TabIndex = 3 + contor;
            clientMail.Text = funcReader[2].ToString();

            FlowPannel.Controls.Add(regionClient);
        }

        private void ListAngajati(ref SqlDataReader funcReader)
        {
            Size ANGAJATI_SIZE = new Size(710, 52);
            Point INIT_POINT = new Point(3, 3);
            previousSelectedPanel = null;
            idToDel = 0;

            Panel regionangajat = new System.Windows.Forms.Panel();
            PictureBox angajatPicture = new System.Windows.Forms.PictureBox();
            Label angajatNume = new System.Windows.Forms.Label();
            Label angajatTel = new System.Windows.Forms.Label();
            Label angajatMail = new System.Windows.Forms.Label();

            regionangajat.AccessibleName = funcReader[5].ToString();
            regionangajat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            regionangajat.AutoScroll = true;
            regionangajat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionangajat.Controls.Add(angajatMail);
            regionangajat.Controls.Add(angajatTel);
            regionangajat.Controls.Add(angajatNume);
            regionangajat.Controls.Add(angajatPicture);
            regionangajat.Location = new System.Drawing.Point(3, contor * (ANGAJATI_SIZE.Height + 3) + 3);
            regionangajat.Name = "region" + contor.ToString();
            regionangajat.Size = new System.Drawing.Size(710, 52);
            regionangajat.TabIndex = 1 + contor;
            regionangajat.DoubleClick += new EventHandler(UpdateThing);
            regionangajat.Click += new EventHandler(SingleClick);

            //angajatPicture

            if (funcReader[4] != DBNull.Value)
            {
                angajatPicture.ImageLocation = @funcReader[4].ToString();
            }
            else
            {
                if (funcReader[3].ToString() == "M")
                {
                    angajatPicture.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Icons\001-avatar-1.png";
                }
                else
                {
                    angajatPicture.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Icons\002-woman.png";
                }
            }
            angajatPicture.Location = new System.Drawing.Point(3, 3);
            angajatPicture.Name = "angajatPicture" + contor.ToString();
            angajatPicture.Size = new System.Drawing.Size(49, 46);
            angajatPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            angajatPicture.TabIndex = 0 + contor;
            angajatPicture.TabStop = false;

            // angajatNume

            angajatNume.AutoSize = true;
            angajatNume.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            angajatNume.Location = new System.Drawing.Point(71, 15);
            angajatNume.Name = "angajatNume" + contor.ToString();
            angajatNume.Size = new System.Drawing.Size(128, 26);
            angajatNume.TabIndex = 1 + contor;
            angajatNume.Text = funcReader[0].ToString();

            //angajatTel

            angajatTel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            angajatTel.AutoSize = true;
            angajatTel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            angajatTel.Location = new System.Drawing.Point(307, 19);
            angajatTel.Name = "angajatTel" + contor.ToString();
            angajatTel.Size = new System.Drawing.Size(99, 19);
            angajatTel.TabIndex = 2 + contor;
            angajatTel.Text = funcReader[1].ToString();

            //angajatMail

            angajatMail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            angajatMail.AutoSize = true;
            angajatMail.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            angajatMail.Location = new System.Drawing.Point(466, 19);
            angajatMail.Name = "angajatMail" + contor.ToString();
            angajatMail.Size = new System.Drawing.Size(216, 19);
            angajatMail.TabIndex = 3 + contor;
            angajatMail.Text = funcReader[2].ToString();

            FlowPannel.Controls.Add(regionangajat);
        }

        private void ListSala(ref SqlDataReader funcReader)
        {
            Size SALA_SIZE = new Size(FlowPannel.Width, 100);
            idToDel = 0;

            Panel regionSala = new Panel();
            Label numeSala = new Label();
            Label nrLoc = new Label();
            Label numeAngajat = new Label();
            Label pretSala = new Label();
            PictureBox salaPic = new PictureBox();

            // 
            // regionSala
            // 
            regionSala.AccessibleName = funcReader[5].ToString();
            regionSala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            regionSala.AutoScroll = true;
            regionSala.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionSala.Controls.Add(pretSala);
            regionSala.Controls.Add(numeAngajat);
            regionSala.Controls.Add(nrLoc);
            regionSala.Controls.Add(numeSala);
            regionSala.Controls.Add(salaPic);
            regionSala.Location = new System.Drawing.Point(3, contor * (SALA_SIZE.Height + 3) + 3);
            regionSala.Name = "regionSala" + contor.ToString();
            regionSala.Size = new Size(710, 111);
            regionSala.TabIndex = 3 + contor;
            regionSala.DoubleClick += new EventHandler(UpdateThing);
            regionSala.Click += new EventHandler(SingleClick);

            //salaPic

            if (funcReader[4] != DBNull.Value)
            {
                salaPic.ImageLocation = @funcReader[4].ToString();
            }
            else
            {
                salaPic.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Icons\003-no-photo.png";
            }
            salaPic.Location = new System.Drawing.Point(3, 3);
            salaPic.Name = "salaPic" + contor.ToString();
            salaPic.Size = new System.Drawing.Size(112, 104);
            salaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            salaPic.TabIndex = 0 + contor;
            salaPic.TabStop = false;

            //numeSala

            numeSala.AutoSize = true;
            numeSala.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeSala.Location = new System.Drawing.Point(121, 3);
            numeSala.Name = "numeSala" + contor.ToString();
            numeSala.Size = new System.Drawing.Size(111, 26);
            numeSala.TabIndex = 1 + contor;
            numeSala.Text = funcReader[0].ToString();

            //nrLoc

            nrLoc.AutoSize = true;
            nrLoc.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            nrLoc.Location = new System.Drawing.Point(123, 39);
            nrLoc.Name = "nrLoc" + contor.ToString();
            nrLoc.Size = new System.Drawing.Size(106, 19);
            nrLoc.TabIndex = 2 + contor;
            nrLoc.Text = "Numar locuri: " + funcReader[1].ToString();

            //numeAngajat

            numeAngajat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            numeAngajat.AutoSize = true;
            numeAngajat.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeAngajat.Location = new System.Drawing.Point(321, 38);
            numeAngajat.Name = "numeAngajat" + contor.ToString();
            numeAngajat.Size = new System.Drawing.Size(111, 19);
            numeAngajat.TabIndex = 3 + contor;
            numeAngajat.Text = "Nume angajat: " + funcReader[2].ToString();

            //pretSala

            pretSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pretSala.AutoSize = true;
            pretSala.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pretSala.Location = new System.Drawing.Point(321, 88);
            pretSala.Name = "pretSala" + contor.ToString();
            pretSala.Size = new System.Drawing.Size(61, 19);
            pretSala.TabIndex = 4 + contor;
            pretSala.Text = "Pret/zi: " + funcReader[3].ToString();

            FlowPannel.Controls.Add(regionSala);
        }

        private void ListFac(ref SqlDataReader funcReader)
        {
            Size FAC_SIZE = new Size(710, 52);
            previousSelectedPanel = null;
            idToDel = 0;

            Panel regionFac = new Panel();
            Label pretFac = new Label();
            Label numeFac = new Label();

            // 
            // regionFac
            // 
            regionFac.AccessibleName = funcReader[2].ToString();
            regionFac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            regionFac.AutoScroll = true;
            regionFac.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionFac.Controls.Add(pretFac);
            regionFac.Controls.Add(numeFac);
            regionFac.Location = new System.Drawing.Point(3, contor * (FAC_SIZE.Height + 3) + 3);
            regionFac.Name = "regionFac" + contor.ToString();
            regionFac.Size = new System.Drawing.Size(710, 52);
            regionFac.TabIndex = 3 + contor;
            regionFac.DoubleClick += new EventHandler(UpdateThing);
            regionFac.Click += new EventHandler(SingleClick);

            // 
            // pretFac
            // 
            pretFac.Anchor = System.Windows.Forms.AnchorStyles.Right;
            pretFac.AutoSize = true;
            pretFac.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pretFac.Location = new System.Drawing.Point(444, 20);
            pretFac.Name = "pretFac" + contor.ToString();
            pretFac.Size = new System.Drawing.Size(65, 19);
            pretFac.TabIndex = 1 + contor;
            pretFac.Text = "Pret/zi: " + funcReader[1].ToString();
            // 
            // numeFac
            // 
            numeFac.AutoSize = true;
            numeFac.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeFac.Location = new System.Drawing.Point(71, 15);
            numeFac.Name = "numeFac" + contor.ToString();
            numeFac.Size = new System.Drawing.Size(154, 26);
            numeFac.TabIndex = 2 + contor;
            numeFac.Text = funcReader[0].ToString();

            FlowPannel.Controls.Add(regionFac);
        }

        private void Dashboard()
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
            System.Windows.Forms.Button cmvfcButton;
            System.Windows.Forms.Button cmcsButton;
            System.Windows.Forms.Button alsButton;
            System.Windows.Forms.Button rasButton;
            System.Windows.Forms.Button ocButton;
            System.Windows.Forms.Button cdssButton;
            System.Windows.Forms.Button cmfcButton;
            System.Windows.Forms.Panel salaRegion;
            System.Windows.Forms.Label salaLab;
            System.Windows.Forms.Label nrPretLab;
            System.Windows.Forms.Label nrLocLab;
            System.Windows.Forms.Label pretLab;
            System.Windows.Forms.Label locLab;
            System.Windows.Forms.PictureBox salaPic;
            System.Windows.Forms.Panel regionButton;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();

            regionButton = new System.Windows.Forms.Panel();
            alsButton = new System.Windows.Forms.Button();
            rasButton = new System.Windows.Forms.Button();
            ocButton = new System.Windows.Forms.Button();
            cdssButton = new System.Windows.Forms.Button();
            cmfcButton = new System.Windows.Forms.Button();
            cmcsButton = new System.Windows.Forms.Button();
            cmvfcButton = new System.Windows.Forms.Button();
            salaRegion = new System.Windows.Forms.Panel();
            salaLab = new System.Windows.Forms.Label();
            dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            salaPic = new System.Windows.Forms.PictureBox();
            locLab = new System.Windows.Forms.Label();
            pretLab = new System.Windows.Forms.Label();
            nrLocLab = new System.Windows.Forms.Label();
            nrPretLab = new System.Windows.Forms.Label();

            // 
            // regionButton
            // 
            regionButton.Controls.Add(alsButton);
            regionButton.Controls.Add(rasButton);
            regionButton.Controls.Add(ocButton);
            regionButton.Controls.Add(cdssButton);
            regionButton.Controls.Add(cmfcButton);
            regionButton.Controls.Add(cmcsButton);
            regionButton.Controls.Add(cmvfcButton);
            regionButton.Location = new System.Drawing.Point(3, 3);
            regionButton.Name = "regionButton";
            regionButton.Size = new System.Drawing.Size(321, 196);
            regionButton.TabIndex = 0;
            // 
            // alsButton
            // 
            alsButton.BackColor = System.Drawing.Color.Transparent;
            alsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            alsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            alsButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            alsButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            alsButton.Location = new System.Drawing.Point(88, 137);
            alsButton.Name = "alsButton";
            alsButton.Size = new System.Drawing.Size(141, 56);
            alsButton.TabIndex = 6;
            alsButton.Text = "Angajat la sala cu profit > 1000";
            alsButton.UseVisualStyleBackColor = false;
            alsButton.Click += new System.EventHandler(ang1LinkLabel_LinkClicked);
            // 
            // rasButton
            // 
            rasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            rasButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            rasButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            rasButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            rasButton.Location = new System.Drawing.Point(228, 65);
            rasButton.Name = "rasButton";
            rasButton.Size = new System.Drawing.Size(75, 56);
            rasButton.TabIndex = 5;
            rasButton.Text = "Raport Angajat-Sala";
            rasButton.UseVisualStyleBackColor = true;
            rasButton.Click += new System.EventHandler(raportLinkLabel_LinkClicked);
            // 
            // ocButton
            // 
            ocButton.Cursor = System.Windows.Forms.Cursors.Hand;
            ocButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ocButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            ocButton.Location = new System.Drawing.Point(228, 3);
            ocButton.Name = "ocButton";
            ocButton.Size = new System.Drawing.Size(75, 56);
            ocButton.TabIndex = 2;
            ocButton.Text = "Oferte Clienti";
            ocButton.UseVisualStyleBackColor = true;
            ocButton.Click += new System.EventHandler(clie3LinkLabel_LinkClicked);
            // 
            // cdssButton
            // 
            cdssButton.Cursor = System.Windows.Forms.Cursors.Hand;
            cdssButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cdssButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            cdssButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            cdssButton.Location = new System.Drawing.Point(120, 65);
            cdssButton.Name = "cdssButton";
            cdssButton.Size = new System.Drawing.Size(75, 56);
            cdssButton.TabIndex = 4;
            cdssButton.Text = "Conf Sala Scumpa";
            cdssButton.UseVisualStyleBackColor = true;
            cdssButton.Click += new System.EventHandler(conf1LinkLabel_LinkClicked);
            // 
            // cmfcButton
            // 
            cmfcButton.Cursor = System.Windows.Forms.Cursors.Hand;
            cmfcButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cmfcButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            cmfcButton.Location = new System.Drawing.Point(16, 71);
            cmfcButton.Name = "cmfcButton";
            cmfcButton.Size = new System.Drawing.Size(75, 56);
            cmfcButton.TabIndex = 3;
            cmfcButton.Text = "Clienti Fideli";
            cmfcButton.UseVisualStyleBackColor = true;
            cmfcButton.Click += new System.EventHandler(clientLinkLabel_LinkClicked);
            // 
            // cmcsButton
            // 
            cmcsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            cmcsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cmcsButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            cmcsButton.Location = new System.Drawing.Point(120, 3);
            cmcsButton.Name = "cmcsButton";
            cmcsButton.Size = new System.Drawing.Size(75, 56);
            cmcsButton.TabIndex = 1;
            cmcsButton.Text = "Sali Cautate";
            cmcsButton.UseVisualStyleBackColor = true;
            cmcsButton.Click += new System.EventHandler(salaLinkLabel_LinkClicked);
            // 
            // cmvfcButton
            // 
            cmvfcButton.Cursor = System.Windows.Forms.Cursors.Hand;
            cmvfcButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cmvfcButton.Font = new System.Drawing.Font("Consolas", 8.25F);
            cmvfcButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            cmvfcButton.Location = new System.Drawing.Point(17, 3);
            cmvfcButton.Name = "cmvfcButton";
            cmvfcButton.Size = new System.Drawing.Size(75, 56);
            cmvfcButton.TabIndex = 0;
            cmvfcButton.Text = "Facilitati Vandute";
            cmvfcButton.UseVisualStyleBackColor = true;
            cmvfcButton.Click += new System.EventHandler(facVandLinkLabel_LinkClicked);
            // 
            // salaRegion
            // 
            salaRegion.Controls.Add(nrPretLab);
            salaRegion.Controls.Add(nrLocLab);
            salaRegion.Controls.Add(pretLab);
            salaRegion.Controls.Add(locLab);
            salaRegion.Controls.Add(salaPic);
            salaRegion.Controls.Add(salaLab);
            salaRegion.Location = new System.Drawing.Point(330, 3);
            salaRegion.Name = "salaRegion";
            salaRegion.Size = new System.Drawing.Size(367, 193);
            salaRegion.TabIndex = 4;
            // 
            // salaLab
            // 
            salaLab.AutoSize = true;
            salaLab.Font = new System.Drawing.Font("Garamond", 23.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            salaLab.ForeColor = System.Drawing.Color.White;
            salaLab.Location = new System.Drawing.Point(31, 6);
            salaLab.Name = "salaLab";
            salaLab.Size = new System.Drawing.Size(149, 35);
            salaLab.TabIndex = 0;
            salaLab.Text = "nume sala";
            // 
            // dataChart
            // 
            chartArea1.Name = "ChartArea1";
            dataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            dataChart.Legends.Add(legend1);
            dataChart.Location = new System.Drawing.Point(3, 205);
            dataChart.Name = "dataChart";
            dataChart.Size = new System.Drawing.Size(696, 186);
            dataChart.TabIndex = 3;
            dataChart.Text = "chart1";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            pictureBox2.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            pictureBox2.Image = global::Conferinta.Properties.Resources.resize;
            pictureBox2.Location = new System.Drawing.Point(687, 436);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(20, 21);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBox2_MouseDown);
            pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox2_MouseMove);
            pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(pictureBox2_MouseUp);
            // 
            // salaPic
            // 
            salaPic.Location = new System.Drawing.Point(3, 44);
            salaPic.Name = "salaPic";
            salaPic.Size = new System.Drawing.Size(205, 146);
            salaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            salaPic.TabIndex = 1;
            salaPic.TabStop = false;
            // 
            // locLab
            // 
            locLab.AutoSize = true;
            locLab.ForeColor = System.Drawing.Color.White;
            locLab.Location = new System.Drawing.Point(222, 80);
            locLab.Name = "locLab";
            locLab.Size = new System.Drawing.Size(64, 18);
            locLab.TabIndex = 2;
            locLab.Text = "Locuri:";
            // 
            // pretLab
            // 
            pretLab.AutoSize = true;
            pretLab.ForeColor = System.Drawing.Color.White;
            pretLab.Location = new System.Drawing.Point(222, 145);
            pretLab.Name = "pretLab";
            pretLab.Size = new System.Drawing.Size(48, 18);
            pretLab.TabIndex = 3;
            pretLab.Text = "Pret:";
            // 
            // nrLocLab
            // 
            nrLocLab.AutoSize = true;
            nrLocLab.ForeColor = System.Drawing.Color.White;
            nrLocLab.Location = new System.Drawing.Point(291, 80);
            nrLocLab.Name = "nrLocLab";
            nrLocLab.Size = new System.Drawing.Size(32, 18);
            nrLocLab.TabIndex = 4;
            nrLocLab.Text = "100";
            // 
            // nrPretLab
            // 
            nrPretLab.AutoSize = true;
            nrPretLab.ForeColor = System.Drawing.Color.White;
            nrPretLab.Location = new System.Drawing.Point(291, 145);
            nrPretLab.Name = "nrPretLab";
            nrPretLab.Size = new System.Drawing.Size(32, 18);
            nrPretLab.TabIndex = 5;
            nrPretLab.Text = "100";

            FlowPannel.Controls.Add(regionButton);
            FlowPannel.Controls.Add(salaRegion);            
            FlowPannel.Controls.Add(dataChart);

            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();

            
            runDashboard = true;
            contor = 0;
            PopulateSala();
            //if (tsk==null || tsk.IsCompleted)
            //{
                
                tsk = ChangeSala();
            //}
          
        }

        private void PopulateSala()
        {
            SqlCommand cmd = new SqlCommand("SELECT Sala_ID, Nume_sala, Nr_loc, Pret_h, Poza FROM Sala;", connection);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                salaID = new List<int>();
                salaLoc = new List<int>();
                preturiSala = new List<int>();
                numeSalaList = new List<string>();
                salaPozaList = new List<string>();

                while(reader.Read())
                {
                    salaID.Add(reader.GetInt32(0));
                    numeSalaList.Add(reader[1].ToString());
                    salaLoc.Add(reader.GetInt32(2));
                    preturiSala.Add(reader.GetInt32(3));
                    salaPozaList.Add(reader[4].ToString());
                }

                reader.Close();
                contor = 0;
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private async Task ChangeSala()
        {
            PictureBox tempPicBox = (PictureBox)FlowPannel.Controls["salaRegion"].Controls["salaPic"];

            if (exitChange)
            {
                try
                {
                    exitChange = false;
                    while (runDashboard)
                    {
                        Console.WriteLine(contor);
                        Console.WriteLine(salaPozaList[contor]);
                        tempPicBox.ImageLocation = salaPozaList[contor];
                        FlowPannel.Controls["salaRegion"].Controls["salaLab"].Text = numeSalaList[contor];
                        FlowPannel.Controls["salaRegion"].Controls["nrLocLab"].Text = salaLoc[contor].ToString();
                        FlowPannel.Controls["salaRegion"].Controls["nrPretLab"].Text = preturiSala[contor].ToString();

                        contor++;
                        contor = contor % preturiSala.Count;

                        await Task.Delay(5000);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Console.WriteLine("Iesit");
            }
            tempPicBox.Dispose();
            exitChange = true;
        }

        private void Conferinte_Click(object sender, EventArgs e)
        {
            if (!confPress)
            {
                Highlight(Conferinte);
                NormalLight(Angajati);
                NormalLight(clientiBtn);
                NormalLight(saliBtn);
                NormalLight(facBtn);
                
                angPress = false;
                clientiPress = false;
                facPress = false;
                salaPress = false;
                runDashboard = false;

                table = "Conferinte";
                colName = "Conf_ID";
                lastPressed = Conferinte;
            }
            
            canAdd = true;
            canDelete = true;
            idToDel = 0;
            idToUp = 0;
            FlowPannel.Controls.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand("Select C.Nume,(SELECT CL.Nume + ' ' + CL.Prenume " +
                    "FROM Client CL WHERE CL.Client_ID = C.ID_Client) as Nume_Client," +
                    "(SELECT S.Nume_sala FROM Sala S WHERE S.Sala_ID = C.ID_Sala)," +
                    "C.D_Inceput,C.D_Sfarsit,C.Pret,C.Conf_ID,(SELECT S.Poza FROM Sala S WHERE S.Sala_ID = C.ID_Sala) FROM Conferinte C" +
                    ""+selOption+";", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!confPress)
                {
                    source = new AutoCompleteStringCollection();
                }
                contor = 0;

                while (reader.Read())
                {
                    ListConf(ref reader);
                    if (!confPress)
                    {
                        source.Add(reader[0].ToString());
                    }
                    contor++;
                }
                if (!confPress)
                {
                    SearchTextBox.AutoCompleteCustomSource = source;
                    confPress = true;
                }

                reader.Close();
            }
            catch (SqlException er) {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }   //COMPLEX

        private void NewButton_Click(object sender, EventArgs e)
        {
            Button new_btn = (Button)sender;
            if (new_btn.Name == "Button2")
            {
                Button btn = new Button();

                btn.Name = "Button3";
                btn.Text = "Added Button 2";
                btn.Location = new Point(3, 46);
                btn.Size = new Size(691, 40);

                FlowPannel.Controls.Add(btn);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            connection.Close();
            Environment.Exit(0);
        }

        private void Angajati_Click(object sender, EventArgs e)
        {
            if (!angPress)
            {
                Highlight(Angajati);
                NormalLight(Conferinte);
                NormalLight(clientiBtn);
                NormalLight(saliBtn);
                NormalLight(facBtn);

                confPress = false;
                clientiPress = false;
                facPress = false;
                salaPress = false;
                runDashboard = false;

                table = "Angajat";
                colName = "Angajat_ID";
                lastPressed = Angajati;
            }
            canDelete = true;
            canAdd = true;
            idToDel = 0;
            idToUp = 0;
            FlowPannel.Controls.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand("Select Nume + ' ' + Prenume, Telefon, Mail," +
                    " Sex, Photo, Angajat_ID FROM Angajat" + selOption +"; ", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!angPress)
                {
                    source = new AutoCompleteStringCollection();
                }
                contor = 0;

                while (reader.Read())
                {
                    ListAngajati(ref reader);
                    source.Add(reader[0].ToString());
                    contor++;
                }
                if (!angPress)
                {
                    SearchTextBox.AutoCompleteCustomSource = source;
                    angPress = true;
                }
                reader.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void sala_lab_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = true;
            initLoc = new Point(this.DesktopLocation.X, this.DesktopLocation.Y);
            mValX = e.X;
            mValY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = false;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            resize = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            resize = false;
            this.Height = this.Height + e.Y;
            this.Width = this.Width + e.X;
            for (int i = 0; i < contor; i++)
            {
                FlowPannel.Controls["region" + i.ToString()].Width = FlowPannel.Width-10;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (resize)
            {
                //this.Height = this.Height + e.Y;
                //this.Width = this.Width + e.X;
                //FlowPannel.Height += e.Y;
                //FlowPannel.Width += e.X;
                //regionPic.Height += e.Y;
                //regionPic.Width += e.X;

                //if (confPress)
                //{
                    //for (int i = 0; i < contor; i++)
                    //{
                    //    FlowPannel.Controls["region" + i.ToString()].Width = FlowPannel.Width;
                    //}
                //}
            }
        }

        private void clientMail_Click(object sender, EventArgs e)
        {

        }

        private void clientiBtn_Click(object sender, EventArgs e)
        {
            if (!clientiPress)
            {
                Highlight(clientiBtn);
                NormalLight(Angajati);
                NormalLight(Conferinte);
                NormalLight(saliBtn);
                NormalLight(facBtn);

                confPress = false;
                angPress = false;
                facPress = false;
                salaPress = false;
                runDashboard = false;

                table = "Client";
                colName = "Client_ID";
                lastPressed = clientiBtn;
            }
            canAdd = false;
            canDelete = true;
            idToDel = 0;
            idToUp = 0;
            FlowPannel.Controls.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand("Select Nume + ' ' + Prenume as Nume," +
                    " Telefon, Mail, Sex, Client_ID FROM Client C" + selOption +"; ", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if(!clientiPress)
                    source = new AutoCompleteStringCollection();
                contor = 0;

                while (reader.Read())
                {
                    ListClienti(ref reader);
                    source.Add(reader[0].ToString());
                    contor++;
                }
                if(!clientiPress)
                    SearchTextBox.AutoCompleteCustomSource = source;
                clientiPress = true;
                reader.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void saliBtn_Click(object sender, EventArgs e)
        {
            if (!salaPress)
            {
                Highlight(saliBtn);
                NormalLight(Angajati);
                NormalLight(Conferinte);
                NormalLight(clientiBtn);
                NormalLight(facBtn);

                confPress = false;
                angPress = false;
                clientiPress = false;
                facPress = false;
                runDashboard = false;

                table = "Sala";
                lastPressed = saliBtn;
            }
            canAdd = false;
            canDelete = false ;
            idToDel = 0;
            idToUp = 0;
            FlowPannel.Controls.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT S.Nume_sala, S.Nr_loc," +
                    " (SELECT A.Nume+' '+A.Prenume FROM Angajat A WHERE A.Angajat_ID=S.ID_Angajat)," +
                    "S.Pret_h,S.Poza,S.Sala_ID FROM Sala S" + selOption +";", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if(!salaPress)
                    source = new AutoCompleteStringCollection();
                contor = 0;

                while (reader.Read())
                {
                    ListSala(ref reader);
                    source.Add(reader[0].ToString());
                    contor++;
                }
                if(!salaPress)
                    SearchTextBox.AutoCompleteCustomSource = source;
                salaPress = true;

                reader.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }   //COMPLEX

        private void facBtn_Click(object sender, EventArgs e)
        {
            if (!facPress)
            {
                Highlight(facBtn);
                NormalLight(Angajati);
                NormalLight(Conferinte);
                NormalLight(clientiBtn);
                NormalLight(saliBtn);

                confPress = false;
                angPress = false;
                clientiPress = false;
                salaPress = false;
                runDashboard = false;

                table = "Facilitati";
                colName = "ID_Fac";
                lastPressed = facBtn;
            }

            canAdd = true;
            canDelete = true;
            idToDel = 0;
            idToUp = 0;

            FlowPannel.Controls.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Nume_fac , Pret, ID_Fac" +
                    " FROM Facilitati" + selOption +"; ", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if(!facPress)
                    source = new AutoCompleteStringCollection();
                contor = 0;

                while (reader.Read())
                {
                    ListFac(ref reader);
                    source.Add(reader[0].ToString());
                    contor++;
                }
                if(!facPress)
                    SearchTextBox.AutoCompleteCustomSource = source;
                facPress = true;
                reader.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddFac(SqlDataReader reader)
        {
            tableUni = "Facilitati";

            Panel facRegion = new System.Windows.Forms.Panel();
            Label numeFac = new System.Windows.Forms.Label();
            Label pretFac = new System.Windows.Forms.Label();
            TextBox numeTextBox = new System.Windows.Forms.TextBox();
            TextBox pretTextBox = new System.Windows.Forms.TextBox();
            Label Titlu = new System.Windows.Forms.Label();
            Button saveBtn = new System.Windows.Forms.Button();
            Button cancelBtn = new System.Windows.Forms.Button();

            // 
            // facRegion
            // 
            facRegion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            facRegion.Controls.Add(cancelBtn);
            facRegion.Controls.Add(saveBtn);
            facRegion.Controls.Add(Titlu);
            facRegion.Controls.Add(pretTextBox);
            facRegion.Controls.Add(numeTextBox);
            facRegion.Controls.Add(pretFac);
            facRegion.Controls.Add(numeFac);
            facRegion.Location = new System.Drawing.Point(3, 3);
            facRegion.Name = "facRegion";
            facRegion.Size = new System.Drawing.Size(281, 267);
            facRegion.TabIndex = 0;

            //numeFac

            numeFac.AutoSize = true;
            numeFac.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeFac.Location = new System.Drawing.Point(12, 99);
            numeFac.Name = "numeFac";
            numeFac.Size = new System.Drawing.Size(56, 19);
            numeFac.TabIndex = 0;
            numeFac.Text = "Nume ";

            //pretFac

            pretFac.AutoSize = true;
            pretFac.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pretFac.Location = new System.Drawing.Point(12, 156);
            pretFac.Name = "pretFac";
            pretFac.Size = new System.Drawing.Size(38, 19);
            pretFac.TabIndex = 1;
            pretFac.Text = "Pret";

            //numeTextBox

            numeTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeTextBox.Location = new System.Drawing.Point(90, 97);
            numeTextBox.Name = "numeTextBox";
            numeTextBox.Size = new System.Drawing.Size(170, 26);
            numeTextBox.TabIndex = 2;
            numeTextBox.Tag = "Nume_fac";
            numeTextBox.Leave += new System.EventHandler(CheckUnicity);

            //pretTextBox

            pretTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pretTextBox.Location = new System.Drawing.Point(90, 158);
            pretTextBox.Name = "pretTextBox";
            pretTextBox.Size = new System.Drawing.Size(170, 26);
            pretTextBox.TabIndex = 3;

            //titlu

            Titlu.AutoSize = true;
            Titlu.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            Titlu.Location = new System.Drawing.Point(11, 21);
            Titlu.Name = "Titlu";
            Titlu.Size = new System.Drawing.Size(205, 26);
            Titlu.TabIndex = 4;
            Titlu.Text = "Adaugare Facilitate";

            //saveBtn

            saveBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            saveBtn.Location = new System.Drawing.Point(193, 230);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size(67, 31);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;

            //cancelBtn

            cancelBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cancelBtn.Location = new System.Drawing.Point(120, 230);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(67, 31);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += new EventHandler(CancelMeth);

            if (reader != null)
            {
                Titlu.Text = "Update Facilitate";

                numeTextBox.Text = reader[0].ToString();
                pretTextBox.Text = reader[1].ToString();
                saveBtn.Click += new EventHandler(UpFac);
                saveBtn.Text = "Update";

                readyToSave = true;
                prevUniVal = numeTextBox.Text; 
            }
            else
            {
                saveBtn.Click += new EventHandler(SaveFac);

                prevUniVal = "";
            }

            FlowPannel.Controls.Add(facRegion);
        }

        private void SaveFac(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Facilitati(Nume_fac, Pret) VALUES(TRIM(@0), @1)", connection);

            try
            {
                if(!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                cmd.Parameters.AddWithValue("0", FlowPannel.Controls["facRegion"].Controls["numeTextBox"].Text);
                //cmd.Parameters.AddWithValue("1", System.Convert.ToInt32(FlowPannel.Controls["facRegion"].Controls["pretTextBox"].Text.Trim()));
                if (CheckInt(FlowPannel.Controls["facRegion"].Controls["pretTextBox"]))
                {
                    cmd.Parameters.AddWithValue("1", System.Convert.ToInt32(FlowPannel.Controls["facRegion"].Controls["pretTextBox"].Text.Trim()));
                }
                else
                {
                    throw new Exception("Verifica datele introduse!");
                }
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();

                facBtn.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void UpFac(object sender, EventArgs e)
        {
            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                SqlCommand cmd = new SqlCommand("UPDATE Facilitati SET Nume_fac=@nume, Pret=@pret " +
                  "WHERE ID_Fac=@id;", connection);
                cmd.Parameters.AddWithValue("nume", FlowPannel.Controls["facRegion"].Controls["numeTextBox"].Text.Trim());
                if (CheckInt(FlowPannel.Controls["facRegion"].Controls["pretTextBox"]))
                {
                    cmd.Parameters.AddWithValue("pret", System.Convert.ToInt32(FlowPannel.Controls["facRegion"].Controls["pretTextBox"].Text.Trim()));
                }
                else
                {
                    throw new Exception("Verifica datele introduse!");
                }
                cmd.Parameters.AddWithValue("id", idToUp);

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();

                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void CancelMeth(object sender, EventArgs e)
        {
            lastPressed.PerformClick();
        }

        private void AddAngajatClient(SqlDataReader reader, bool method = false) //method: f-Angajat t-Client
        {
            tableUni = "Angajat";
            if(method)
            {
                tableUni = "Client";
            }

            System.Windows.Forms.Panel regionDatePers;
            System.Windows.Forms.TextBox textBox1;
            System.Windows.Forms.Label cnpLab;
            System.Windows.Forms.TextBox prenTextBox;
            System.Windows.Forms.TextBox numeTextBox;
            System.Windows.Forms.Label prenLab;
            System.Windows.Forms.Label numeLab;
            System.Windows.Forms.PictureBox angPoza;
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.ComboBox dayComboBox;
            System.Windows.Forms.ComboBox yearComboBox;
            System.Windows.Forms.ComboBox monthComboBox;
            System.Windows.Forms.RadioButton FRadioBtn;
            System.Windows.Forms.RadioButton MRadioBtn;
            System.Windows.Forms.Label sexLab;
            System.Windows.Forms.Label mailLab;
            System.Windows.Forms.TextBox mailTextBox;
            System.Windows.Forms.TextBox telTextBox;
            System.Windows.Forms.Label telLab;
            System.Windows.Forms.Panel regionAdresa;
            System.Windows.Forms.TextBox apTextBox;
            System.Windows.Forms.Label apLab;
            System.Windows.Forms.TextBox blocTextBox;
            System.Windows.Forms.Label blocLab;
            System.Windows.Forms.TextBox scaraTextBox;
            System.Windows.Forms.Label scaraLab;
            System.Windows.Forms.TextBox codTextBox;
            System.Windows.Forms.Label codLab;
            System.Windows.Forms.TextBox nrTextBox;
            System.Windows.Forms.Label nrLab;
            System.Windows.Forms.TextBox strTextBox;
            System.Windows.Forms.Label strLab;
            System.Windows.Forms.TextBox orasTextBox;
            System.Windows.Forms.Label orasLab;
            System.Windows.Forms.TextBox taraTextBox;
            System.Windows.Forms.Label taraLab;
            System.Windows.Forms.TextBox judetTextBox;
            System.Windows.Forms.Label judLab;
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.Button cancelBtn;
            System.Windows.Forms.Button saveBtn;
            System.Windows.Forms.TextBox salTextBox;
            System.Windows.Forms.Label salLab;

            regionDatePers = new System.Windows.Forms.Panel();
            yearComboBox = new System.Windows.Forms.ComboBox();
            monthComboBox = new System.Windows.Forms.ComboBox();
            dataLabel = new System.Windows.Forms.Label();
            dayComboBox = new System.Windows.Forms.ComboBox();
            textBox1 = new System.Windows.Forms.TextBox();
            cnpLab = new System.Windows.Forms.Label();
            prenTextBox = new System.Windows.Forms.TextBox();
            numeTextBox = new System.Windows.Forms.TextBox();
            prenLab = new System.Windows.Forms.Label();
            numeLab = new System.Windows.Forms.Label();
            telLab = new System.Windows.Forms.Label();
            telTextBox = new System.Windows.Forms.TextBox();
            mailTextBox = new System.Windows.Forms.TextBox();
            mailLab = new System.Windows.Forms.Label();
            sexLab = new System.Windows.Forms.Label();
            MRadioBtn = new System.Windows.Forms.RadioButton();
            FRadioBtn = new System.Windows.Forms.RadioButton();
            regionAdresa = new System.Windows.Forms.Panel();
            judetTextBox = new System.Windows.Forms.TextBox();
            judLab = new System.Windows.Forms.Label();
            taraTextBox = new System.Windows.Forms.TextBox();
            taraLab = new System.Windows.Forms.Label();
            orasTextBox = new System.Windows.Forms.TextBox();
            orasLab = new System.Windows.Forms.Label();
            strTextBox = new System.Windows.Forms.TextBox();
            strLab = new System.Windows.Forms.Label();
            nrTextBox = new System.Windows.Forms.TextBox();
            nrLab = new System.Windows.Forms.Label();
            codTextBox = new System.Windows.Forms.TextBox();
            codLab = new System.Windows.Forms.Label();
            scaraTextBox = new System.Windows.Forms.TextBox();
            scaraLab = new System.Windows.Forms.Label();
            blocTextBox = new System.Windows.Forms.TextBox();
            blocLab = new System.Windows.Forms.Label();
            apTextBox = new System.Windows.Forms.TextBox();
            apLab = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            salTextBox = new System.Windows.Forms.TextBox();
            salLab = new System.Windows.Forms.Label();
            saveBtn = new System.Windows.Forms.Button();
            cancelBtn = new System.Windows.Forms.Button();
            angPoza = new PictureBox();
            // 
            // regionDatePers
            // 
            regionDatePers.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionDatePers.Controls.Add(FRadioBtn);
            regionDatePers.Controls.Add(MRadioBtn);
            regionDatePers.Controls.Add(sexLab);
            regionDatePers.Controls.Add(mailLab);
            regionDatePers.Controls.Add(mailTextBox);
            regionDatePers.Controls.Add(telTextBox);
            regionDatePers.Controls.Add(telLab);
            regionDatePers.Controls.Add(yearComboBox);
            regionDatePers.Controls.Add(monthComboBox);
            regionDatePers.Controls.Add(dataLabel);
            regionDatePers.Controls.Add(dayComboBox);
            regionDatePers.Controls.Add(prenTextBox);
            regionDatePers.Controls.Add(numeTextBox);
            regionDatePers.Controls.Add(prenLab);
            regionDatePers.Controls.Add(numeLab);
            if (!method)
            {
                regionDatePers.Controls.Add(cnpLab);
                regionDatePers.Controls.Add(textBox1);
                regionDatePers.Controls.Add(angPoza);
            }
            regionDatePers.Location = new System.Drawing.Point(3, 3);
            regionDatePers.Name = "regionDatePers";
            regionDatePers.Size = new System.Drawing.Size(709, 221);
            regionDatePers.TabIndex = 0;
            // 
            // angPoza
            // 
            if (!method)
            {
                angPoza.Cursor = System.Windows.Forms.Cursors.Hand;
                angPoza.Image = global::Conferinta.Properties.Resources.picture;
                angPoza.Location = new System.Drawing.Point(3, 3);
                angPoza.Name = "angPoza";
                angPoza.Size = new System.Drawing.Size(178, 215);
                angPoza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                angPoza.TabIndex = 0;
                angPoza.TabStop = false;
                angPoza.Click += new System.EventHandler(angPoza_Click);
            }
            // 
            // yearComboBox
            // 
            yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            yearComboBox.FormattingEnabled = true;
            for (int i = System.DateTime.Now.Year - 18; i > (System.DateTime.Now.Year - 100); i--)
            {
                yearComboBox.Items.Add((object)i.ToString());
            }
            yearComboBox.Location = new System.Drawing.Point(529, 107);
            yearComboBox.Name = "yearComboBox";
            yearComboBox.Size = new System.Drawing.Size(80, 26);
            yearComboBox.TabIndex = 10;
            // 
            // monthComboBox
            // 
            monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            monthComboBox.FormattingEnabled = true;
            monthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            monthComboBox.Location = new System.Drawing.Point(461, 107);
            monthComboBox.Name = "monthComboBox";
            monthComboBox.Size = new System.Drawing.Size(42, 26);
            monthComboBox.TabIndex = 9;
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataLabel.Location = new System.Drawing.Point(393, 82);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(95, 22);
            dataLabel.TabIndex = 8;
            dataLabel.Text = "Data nastere";
            dataLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // dayComboBox
            // 
            dayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dayComboBox.FormattingEnabled = true;
            dayComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            dayComboBox.Location = new System.Drawing.Point(397, 107);
            dayComboBox.Name = "dayComboBox";
            dayComboBox.Size = new System.Drawing.Size(41, 26);
            dayComboBox.TabIndex = 7;
            if (!method)
            {
                // 
                // textBox1
                // 
                textBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                textBox1.Location = new System.Drawing.Point(187, 107);
                textBox1.MaxLength = 13;
                textBox1.Name = "textBox1";
                textBox1.Size = new System.Drawing.Size(168, 26);
                textBox1.TabIndex = 6;
                // 
                // cnpLab
                // 
                cnpLab.AutoSize = true;
                cnpLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                cnpLab.Location = new System.Drawing.Point(183, 82);
                cnpLab.Name = "cnpLab";
                cnpLab.Size = new System.Drawing.Size(44, 22);
                cnpLab.TabIndex = 5;
                cnpLab.Text = "CNP";
            }
            // 
            // prenTextBox
            // 
            prenTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            prenTextBox.Location = new System.Drawing.Point(396, 40);
            prenTextBox.Name = "prenTextBox";
            prenTextBox.Size = new System.Drawing.Size(213, 26);
            prenTextBox.TabIndex = 4;
            // 
            // numeTextBox
            // 
            numeTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeTextBox.Location = new System.Drawing.Point(187, 40);
            numeTextBox.Name = "numeTextBox";
            numeTextBox.Size = new System.Drawing.Size(168, 26);
            numeTextBox.TabIndex = 3;
            // 
            // prenLab
            // 
            prenLab.AutoSize = true;
            prenLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            prenLab.Location = new System.Drawing.Point(392, 15);
            prenLab.Name = "prenLab";
            prenLab.Size = new System.Drawing.Size(72, 22);
            prenLab.TabIndex = 2;
            prenLab.Text = "Prenume";
            // 
            // numeLab
            // 
            numeLab.AutoSize = true;
            numeLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeLab.Location = new System.Drawing.Point(183, 15);
            numeLab.Name = "numeLab";
            numeLab.Size = new System.Drawing.Size(53, 22);
            numeLab.TabIndex = 1;
            numeLab.Text = "Nume";
            // 
            // telLab
            // 
            telLab.AutoSize = true;
            telLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            telLab.Location = new System.Drawing.Point(183, 147);
            telLab.Name = "telLab";
            telLab.Size = new System.Drawing.Size(58, 22);
            telLab.TabIndex = 11;
            telLab.Text = "Telefon";
            // 
            // telTextBox
            // 
            telTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            telTextBox.Location = new System.Drawing.Point(187, 175);
            telTextBox.MaxLength = 12;
            telTextBox.Name = "telTextBox";
            telTextBox.Size = new System.Drawing.Size(168, 26);
            telTextBox.TabIndex = 12;
            // 
            // mailTextBox
            // 
            mailTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            mailTextBox.Location = new System.Drawing.Point(397, 175);
            mailTextBox.Name = "mailTextBox";
            mailTextBox.Size = new System.Drawing.Size(213, 26);
            mailTextBox.TabIndex = 13;
            mailTextBox.Tag = "Mail";
            mailTextBox.Leave += new EventHandler(CheckUnicity);
            // 
            // mailLab
            // 
            mailLab.AutoSize = true;
            mailLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            mailLab.Location = new System.Drawing.Point(393, 147);
            mailLab.Name = "mailLab";
            mailLab.Size = new System.Drawing.Size(56, 22);
            mailLab.TabIndex = 14;
            mailLab.Text = "E-Mail";
            // 
            // sexLab
            // 
            sexLab.AutoSize = true;
            sexLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            sexLab.Location = new System.Drawing.Point(640, 15);
            sexLab.Name = "sexLab";
            sexLab.Size = new System.Drawing.Size(34, 22);
            sexLab.TabIndex = 15;
            sexLab.Text = "Sex";
            // 
            // MRadioBtn
            // 
            MRadioBtn.AutoSize = true;
            MRadioBtn.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            MRadioBtn.Location = new System.Drawing.Point(644, 48);
            MRadioBtn.Name = "MRadioBtn";
            MRadioBtn.Size = new System.Drawing.Size(41, 23);
            MRadioBtn.TabIndex = 16;
            MRadioBtn.TabStop = true;
            MRadioBtn.Text = "M";
            MRadioBtn.UseVisualStyleBackColor = true;
            // 
            // FRadioBtn
            // 
            FRadioBtn.AutoSize = true;
            FRadioBtn.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            FRadioBtn.Location = new System.Drawing.Point(644, 76);
            FRadioBtn.Name = "FRadioBtn";
            FRadioBtn.Size = new System.Drawing.Size(36, 23);
            FRadioBtn.TabIndex = 17;
            FRadioBtn.TabStop = true;
            FRadioBtn.Text = "F";
            FRadioBtn.UseVisualStyleBackColor = true;
            // 
            // regionAdresa
            // 
            regionAdresa.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionAdresa.Controls.Add(apTextBox);
            regionAdresa.Controls.Add(apLab);
            regionAdresa.Controls.Add(blocTextBox);
            regionAdresa.Controls.Add(blocLab);
            regionAdresa.Controls.Add(scaraTextBox);
            regionAdresa.Controls.Add(scaraLab);
            regionAdresa.Controls.Add(codTextBox);
            regionAdresa.Controls.Add(codLab);
            regionAdresa.Controls.Add(nrTextBox);
            regionAdresa.Controls.Add(nrLab);
            regionAdresa.Controls.Add(strTextBox);
            regionAdresa.Controls.Add(strLab);
            regionAdresa.Controls.Add(orasTextBox);
            regionAdresa.Controls.Add(orasLab);
            regionAdresa.Controls.Add(taraTextBox);
            regionAdresa.Controls.Add(taraLab);
            regionAdresa.Controls.Add(judetTextBox);
            regionAdresa.Controls.Add(judLab);
            regionAdresa.Location = new System.Drawing.Point(3, 230);
            regionAdresa.Name = "regionAdresa";
            regionAdresa.Size = new System.Drawing.Size(707, 195);
            regionAdresa.TabIndex = 1;
            // 
            // judetTextBox
            // 
            judetTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            judetTextBox.Location = new System.Drawing.Point(283, 36);
            judetTextBox.Name = "judetTextBox";
            judetTextBox.Size = new System.Drawing.Size(168, 26);
            judetTextBox.TabIndex = 5;
            // 
            // judLab
            // 
            judLab.AutoSize = true;
            judLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            judLab.Location = new System.Drawing.Point(279, 11);
            judLab.Name = "judLab";
            judLab.Size = new System.Drawing.Size(45, 22);
            judLab.TabIndex = 4;
            judLab.Text = "Judet";
            // 
            // taraTextBox
            // 
            taraTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            taraTextBox.Location = new System.Drawing.Point(16, 34);
            taraTextBox.Name = "taraTextBox";
            taraTextBox.Size = new System.Drawing.Size(168, 26);
            taraTextBox.TabIndex = 7;
            // 
            // taraLab
            // 
            taraLab.AutoSize = true;
            taraLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            taraLab.Location = new System.Drawing.Point(12, 9);
            taraLab.Name = "taraLab";
            taraLab.Size = new System.Drawing.Size(40, 22);
            taraLab.TabIndex = 6;
            taraLab.Text = "Tara";
            // 
            // orasTextBox
            // 
            orasTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            orasTextBox.Location = new System.Drawing.Point(529, 34);
            orasTextBox.Name = "orasTextBox";
            orasTextBox.Size = new System.Drawing.Size(168, 26);
            orasTextBox.TabIndex = 9;
            // 
            // orasLab
            // 
            orasLab.AutoSize = true;
            orasLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            orasLab.Location = new System.Drawing.Point(525, 9);
            orasLab.Name = "orasLab";
            orasLab.Size = new System.Drawing.Size(43, 22);
            orasLab.TabIndex = 8;
            orasLab.Text = "Oras";
            // 
            // strTextBox
            // 
            strTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            strTextBox.Location = new System.Drawing.Point(16, 94);
            strTextBox.Name = "strTextBox";
            strTextBox.Size = new System.Drawing.Size(168, 26);
            strTextBox.TabIndex = 11;
            // 
            // strLab
            // 
            strLab.AutoSize = true;
            strLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            strLab.Location = new System.Drawing.Point(12, 69);
            strLab.Name = "strLab";
            strLab.Size = new System.Drawing.Size(55, 22);
            strLab.TabIndex = 10;
            strLab.Text = "Strada";
            // 
            // nrTextBox
            // 
            nrTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            nrTextBox.Location = new System.Drawing.Point(283, 96);
            nrTextBox.Name = "nrTextBox";
            nrTextBox.Size = new System.Drawing.Size(168, 26);
            nrTextBox.TabIndex = 13;
            // 
            // nrLab
            // 
            nrLab.AutoSize = true;
            nrLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            nrLab.Location = new System.Drawing.Point(279, 71);
            nrLab.Name = "nrLab";
            nrLab.Size = new System.Drawing.Size(33, 22);
            nrLab.TabIndex = 12;
            nrLab.Text = "Nr.";
            // 
            // codTextBox
            // 
            codTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            codTextBox.Location = new System.Drawing.Point(528, 94);
            codTextBox.Name = "codTextBox";
            codTextBox.MaxLength = 10;
            codTextBox.Size = new System.Drawing.Size(168, 26);
            codTextBox.TabIndex = 15;
            // 
            // codLab
            // 
            codLab.AutoSize = true;
            codLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            codLab.Location = new System.Drawing.Point(524, 69);
            codLab.Name = "codLab";
            codLab.Size = new System.Drawing.Size(82, 22);
            codLab.TabIndex = 14;
            codLab.Text = "Cod postal*";
            // 
            // scaraTextBox
            // 
            scaraTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            scaraTextBox.Location = new System.Drawing.Point(283, 160);
            scaraTextBox.Name = "scaraTextBox";
            scaraTextBox.Size = new System.Drawing.Size(58, 26);
            scaraTextBox.TabIndex = 17;
            // 
            // scaraLab
            // 
            scaraLab.AutoSize = true;
            scaraLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            scaraLab.Location = new System.Drawing.Point(279, 135);
            scaraLab.Name = "scaraLab";
            scaraLab.Size = new System.Drawing.Size(54, 22);
            scaraLab.TabIndex = 16;
            scaraLab.Text = "Scara*";
            // 
            // blocTextBox
            // 
            blocTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            blocTextBox.Location = new System.Drawing.Point(16, 158);
            blocTextBox.Name = "blocTextBox";
            blocTextBox.Size = new System.Drawing.Size(51, 26);
            blocTextBox.TabIndex = 19;
            // 
            // blocLab
            // 
            blocLab.AutoSize = true;
            blocLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            blocLab.Location = new System.Drawing.Point(12, 133);
            blocLab.Name = "blocLab";
            blocLab.Size = new System.Drawing.Size(45, 22);
            blocLab.TabIndex = 18;
            blocLab.Text = "Bloc*";
            // 
            // apTextBox
            // 
            apTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            apTextBox.Location = new System.Drawing.Point(529, 158);
            apTextBox.Name = "apTextBox";
            apTextBox.Size = new System.Drawing.Size(51, 26);
            apTextBox.TabIndex = 21;
            // 
            // apLab
            // 
            apLab.AutoSize = true;
            apLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            apLab.Location = new System.Drawing.Point(525, 133);
            apLab.Name = "apLab";
            apLab.Size = new System.Drawing.Size(98, 22);
            apLab.TabIndex = 20;
            apLab.Text = "Apartament*";
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            panel3.Controls.Add(cancelBtn);
            panel3.Controls.Add(saveBtn);
            if (!method)
            {
                panel3.Controls.Add(salTextBox);
                panel3.Controls.Add(salLab);
            }
            panel3.Location = new System.Drawing.Point(3, 431);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(709, 82);
            panel3.TabIndex = 2;
            if (!method)
            {
                // 
                // salTextBox
                // 
                salTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                salTextBox.Location = new System.Drawing.Point(16, 34);
                salTextBox.Name = "salTextBox";
                salTextBox.Size = new System.Drawing.Size(168, 26);
                salTextBox.TabIndex = 19;
                // 
                // salLab
                // 
                salLab.AutoSize = true;
                salLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                salLab.Location = new System.Drawing.Point(12, 9);
                salLab.Name = "salLab";
                salLab.Size = new System.Drawing.Size(58, 22);
                salLab.TabIndex = 18;
                salLab.Text = "Salariu";
            }
            // 
            // saveBtn
            // 
            saveBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            saveBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            saveBtn.Location = new System.Drawing.Point(610, 26);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size(75, 34);
            saveBtn.TabIndex = 20;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cancelBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            cancelBtn.Location = new System.Drawing.Point(505, 26);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(75, 34);
            cancelBtn.TabIndex = 21;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += new EventHandler(CancelMeth);

            if (reader != null)
            {


                saveBtn.Text = "Update";
                if (!method)
                {
                    numeTextBox.Text = reader[1].ToString();
                    prenTextBox.Text = reader[2].ToString();
                    textBox1.Text = reader[3].ToString();       //CNP
                    telTextBox.Text = reader[4].ToString();
                    mailTextBox.Text = reader[5].ToString();

                    if (reader[6].ToString().Equals("M"))
                    {
                        MRadioBtn.Checked = true;
                    }
                    else
                    {
                        FRadioBtn.Checked = true;
                    }

                    judetTextBox.Text = reader[7].ToString();
                    orasTextBox.Text = reader[8].ToString();
                    taraTextBox.Text = reader[9].ToString();
                    strTextBox.Text = reader[10].ToString();
                    nrTextBox.Text = reader[11].ToString();

                    if (reader[12] != DBNull.Value)
                    {
                        blocTextBox.Text = reader[12].ToString();
                    }

                    if (reader[13] != DBNull.Value)
                    {
                        scaraTextBox.Text = reader[13].ToString();
                    }

                    if (reader[14] != DBNull.Value)
                    {
                        apTextBox.Text = reader[14].ToString();
                    }

                    if (reader[19] != DBNull.Value)
                    {
                        codTextBox.Text = reader[19].ToString();
                    }

                    DateTime birthday = reader.GetDateTime(16);
                    dayComboBox.Text = birthday.Day.ToString();
                    monthComboBox.Text = birthday.Month.ToString();
                    yearComboBox.Text = birthday.Year.ToString();
                    salTextBox.Text = reader[17].ToString();

                    if (reader[18] != DBNull.Value)
                    {
                        angPoza.ImageLocation = @reader[18].ToString();
                    }

                    saveBtn.Click += new EventHandler(UpAng);
                }
                else
                {
                    numeTextBox.Text = reader[1].ToString();
                    prenTextBox.Text = reader[2].ToString();
                    telTextBox.Text = reader[3].ToString();
                    mailTextBox.Text = reader[4].ToString();

                    if (reader[5].ToString().Equals("M"))
                    {
                        MRadioBtn.Checked = true;
                    }
                    else
                    {
                        FRadioBtn.Checked = true;
                    }

                    DateTime birthday = reader.GetDateTime(15);
                    dayComboBox.Text = birthday.Day.ToString();
                    monthComboBox.Text = birthday.Month.ToString();
                    yearComboBox.Text = birthday.Year.ToString();

                    judetTextBox.Text = reader[6].ToString();
                    orasTextBox.Text = reader[7].ToString();
                    taraTextBox.Text = reader[8].ToString();
                    strTextBox.Text = reader[9].ToString();
                    nrTextBox.Text = reader[10].ToString();

                    if (reader[11] != DBNull.Value)
                    {
                        blocTextBox.Text = reader[11].ToString();
                    }

                    if (reader[12] != DBNull.Value)
                    {
                        scaraTextBox.Text = reader[12].ToString();
                    }

                    if (reader[13] != DBNull.Value)
                    {
                        apTextBox.Text = reader[13].ToString();
                    }

                    if (reader[14] != DBNull.Value)
                    {
                        codTextBox.Text = reader[14].ToString();
                    }

                    saveBtn.Click += new EventHandler(UpClient);
                }

                readyToSave = true;
                prevUniVal = mailTextBox.Text;
            }
            else
            {
                if (!method)
                {
                    saveBtn.Click += new EventHandler(SaveAng);
                }
                else
                {
                    saveBtn.Click += new EventHandler(SaveClient);
                }

                prevUniVal = "";
            }

            FlowPannel.Controls.Add(regionDatePers);
            FlowPannel.Controls.Add(regionAdresa);
            FlowPannel.Controls.Add(panel3);
        }

        private void SaveAng(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Angajat(Nume,Prenume,CNP,Telefon,Mail,Sex,Judet,Oras,Tara,Strada,Nr,Bloc," +
                "Scara,Apartament,Data_Angajarii,Data_Nastere,Salariu,Photo,ZIP_Code) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11," +
                "@12,@13,@14,@15,@16,@17,@18);", connection);
            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                cmd.Parameters.AddWithValue("0", FlowPannel.Controls["regionDatePers"].Controls["numeTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("1", FlowPannel.Controls["regionDatePers"].Controls["prenTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("2", FlowPannel.Controls["regionDatePers"].Controls["textBox1"].Text.Trim());
                cmd.Parameters.AddWithValue("3", FlowPannel.Controls["regionDatePers"].Controls["telTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("4", FlowPannel.Controls["regionDatePers"].Controls["mailTextBox"].Text.Trim());
                RadioButton rad = (RadioButton)FlowPannel.Controls["regionDatePers"].Controls["MRadioBtn"];
                if (rad.Checked)
                {
                    cmd.Parameters.AddWithValue("5", "M");
                }
                else
                {
                    cmd.Parameters.AddWithValue("5", "F");
                }
                cmd.Parameters.AddWithValue("6", FlowPannel.Controls["regionAdresa"].Controls["judetTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("7", FlowPannel.Controls["regionAdresa"].Controls["orasTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("8", FlowPannel.Controls["regionAdresa"].Controls["taraTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("9", FlowPannel.Controls["regionAdresa"].Controls["strTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("10", FlowPannel.Controls["regionAdresa"].Controls["nrTextBox"].Text.Trim());
                if (!FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("11", FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("11", DBNull.Value);
                }
                if (!FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("12", FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("12", DBNull.Value);
                }
                if (!FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("13", FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("13", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("14", SqlDbType.Date).Value = System.DateTime.Now.Date;

                DateTime birthday = new DateTime(System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["yearComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["monthComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["dayComboBox"].Text));

                cmd.Parameters.AddWithValue("15", SqlDbType.Date).Value = birthday.Date;
                cmd.Parameters.AddWithValue("16", System.Convert.ToInt32(FlowPannel.Controls["panel3"].Controls["salTextBox"].Text.Trim()));
                PictureBox tempPic = (PictureBox)FlowPannel.Controls["regionDatePers"].Controls["angPoza"];
                string loc = (string)tempPic.ImageLocation;
                if (string.IsNullOrEmpty(loc))
                {
                    cmd.Parameters.AddWithValue("17", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("17", tempPic.ImageLocation);
                }

                if (string.IsNullOrEmpty(FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text))
                {
                    cmd.Parameters.AddWithValue("18", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("18", FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text.Trim());
                }

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();

                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void UpAng(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Angajat SET Nume=@0, Prenume=@1, CNP=@2, Telefon=@3, Mail=@4, " +
                "Sex=@5, Judet=@6, Oras=@7, Tara=@8, Strada=@9, Nr=@10, Bloc=@11, Scara=@12, " +
                "Apartament=@13, Data_Nastere=@15, Salariu=@16, Photo=@17, ZIP_Code=@18 " +
                "WHERE Angajat_ID=@id;", connection);
            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                cmd.Parameters.AddWithValue("0", FlowPannel.Controls["regionDatePers"].Controls["numeTextBox"].Text.Trim());
                Console.WriteLine("0");
                cmd.Parameters.AddWithValue("1", FlowPannel.Controls["regionDatePers"].Controls["prenTextBox"].Text.Trim());
                Console.WriteLine("1");
                cmd.Parameters.AddWithValue("2", FlowPannel.Controls["regionDatePers"].Controls["textBox1"].Text.Trim());
                Console.WriteLine("2");
                cmd.Parameters.AddWithValue("3", FlowPannel.Controls["regionDatePers"].Controls["telTextBox"].Text.Trim());
                Console.WriteLine("3");
                cmd.Parameters.AddWithValue("4", FlowPannel.Controls["regionDatePers"].Controls["mailTextBox"].Text.Trim());
                Console.WriteLine("4");
                RadioButton rad = (RadioButton)FlowPannel.Controls["regionDatePers"].Controls["MRadioBtn"];
                if (rad.Checked)
                {
                    cmd.Parameters.AddWithValue("5", "M");
                }
                else
                {
                    cmd.Parameters.AddWithValue("5", "F");
                }
                Console.WriteLine("5");
                cmd.Parameters.AddWithValue("6", FlowPannel.Controls["regionAdresa"].Controls["judetTextBox"].Text.Trim());
                Console.WriteLine("6");
                cmd.Parameters.AddWithValue("7", FlowPannel.Controls["regionAdresa"].Controls["orasTextBox"].Text.Trim());
                Console.WriteLine("7");
                cmd.Parameters.AddWithValue("8", FlowPannel.Controls["regionAdresa"].Controls["taraTextBox"].Text.Trim());
                Console.WriteLine("8");
                cmd.Parameters.AddWithValue("9", FlowPannel.Controls["regionAdresa"].Controls["strTextBox"].Text.Trim());
                Console.WriteLine("9");
                cmd.Parameters.AddWithValue("10", FlowPannel.Controls["regionAdresa"].Controls["nrTextBox"].Text.Trim());
                Console.WriteLine("9");
                if (!FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("11", FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("11", DBNull.Value);
                }
                Console.WriteLine("11");
                if (!FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("12", FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("12", DBNull.Value);
                }
                Console.WriteLine("12");
                if (!FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("13", FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("13", DBNull.Value);
                }
                Console.WriteLine("13");
                DateTime birthday = new DateTime(System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["yearComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["monthComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["dayComboBox"].Text));

                cmd.Parameters.AddWithValue("15", SqlDbType.Date).Value = birthday.Date;
                Console.WriteLine("15");
                cmd.Parameters.AddWithValue("16", System.Convert.ToInt32(FlowPannel.Controls["panel3"].Controls["salTextBox"].Text.Trim()));
                Console.WriteLine("16");
                PictureBox tempPic = (PictureBox)FlowPannel.Controls["regionDatePers"].Controls["angPoza"];
                Console.WriteLine("pic");
                string loc = (string)tempPic.ImageLocation;
                if (string.IsNullOrEmpty(loc))
                {
                    cmd.Parameters.AddWithValue("17", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("17", tempPic.ImageLocation);
                }

                Console.WriteLine("17");
                if (string.IsNullOrEmpty(FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text))
                {
                    cmd.Parameters.AddWithValue("18", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("18", FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text.Trim());
                }
                Console.WriteLine("18");
                cmd.Parameters.AddWithValue("id", idToUp);
                Console.WriteLine("id");
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();

                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void SaveClient(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Client(Nume,Prenume,Telefon,Mail,Sex,Judet,Oras,Tara,Strada,Nr,Bloc," +
                "Scara,Apartament,ZIP_Code,Data_Nastere) VALUES(@nume,@pren,@tel,@mail,@sex,@jud,@oras,@tara,@str,@nr,@bl,@sc," +
                "@ap,@zip,@dn);", connection);
            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                Console.WriteLine("1");
                cmd.Parameters.AddWithValue("nume", FlowPannel.Controls["regionDatePers"].Controls["numeTextBox"].Text.Trim());
                Console.WriteLine("2");
                cmd.Parameters.AddWithValue("pren", FlowPannel.Controls["regionDatePers"].Controls["prenTextBox"].Text.Trim());
                Console.WriteLine("3");
                cmd.Parameters.AddWithValue("tel", FlowPannel.Controls["regionDatePers"].Controls["telTextBox"].Text.Trim());
                Console.WriteLine("4");
                cmd.Parameters.AddWithValue("mail", FlowPannel.Controls["regionDatePers"].Controls["mailTextBox"].Text.Trim());
                Console.WriteLine("5");
                RadioButton rad = (RadioButton)FlowPannel.Controls["regionDatePers"].Controls["MRadioBtn"];
                if (rad.Checked)
                {
                    cmd.Parameters.AddWithValue("sex", "M");
                }
                else
                {
                    cmd.Parameters.AddWithValue("sex", "F");
                }
                Console.WriteLine("6");
                cmd.Parameters.AddWithValue("jud", FlowPannel.Controls["regionAdresa"].Controls["judetTextBox"].Text.Trim());
                Console.WriteLine("7");
                cmd.Parameters.AddWithValue("oras", FlowPannel.Controls["regionAdresa"].Controls["orasTextBox"].Text.Trim());
                Console.WriteLine("8");
                cmd.Parameters.AddWithValue("tara", FlowPannel.Controls["regionAdresa"].Controls["taraTextBox"].Text.Trim());
                Console.WriteLine("9");
                cmd.Parameters.AddWithValue("str", FlowPannel.Controls["regionAdresa"].Controls["strTextBox"].Text.Trim());
                Console.WriteLine("10");
                cmd.Parameters.AddWithValue("nr", FlowPannel.Controls["regionAdresa"].Controls["nrTextBox"].Text.Trim());
                Console.WriteLine("14");
                if (!FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("bl", FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("bl", DBNull.Value);
                }
                Console.WriteLine("11");
                if (!FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("sc", FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("sc", DBNull.Value);
                }
                Console.WriteLine("12");
                if (!FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("ap", FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("ap", DBNull.Value);
                }

                Console.WriteLine("13");
                if (string.IsNullOrEmpty(FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text))
                {
                    cmd.Parameters.AddWithValue("zip", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("zip", FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text.Trim());
                }

                DateTime birthday = new DateTime(System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["yearComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["monthComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["dayComboBox"].Text));

                cmd.Parameters.AddWithValue("dn", SqlDbType.Date).Value = birthday.Date;
                Console.WriteLine("15");

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();

                Console.WriteLine("16");

                SqlDataReader reader = null;
                FlowPannel.Controls.Clear();
                AddConf(ref reader);
                //lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void UpClient(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Client SET Nume=@nume, Prenume=@pren, Telefon=@tel, Mail=@mail, " +
                "Sex=@sex, Judet=@jud, Oras=@oras, Tara=@tara, Strada=@str, Nr=@nr, Bloc=@bl, Scara=@sc, " +
                "Apartament=@ap, ZIP_Code=@zip, Data_Nastere=@dn " +
                "WHERE Client_ID=@id;", connection);
            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                Console.WriteLine("1");
                cmd.Parameters.AddWithValue("nume", FlowPannel.Controls["regionDatePers"].Controls["numeTextBox"].Text.Trim());
                Console.WriteLine("2");
                cmd.Parameters.AddWithValue("pren", FlowPannel.Controls["regionDatePers"].Controls["prenTextBox"].Text.Trim());
                Console.WriteLine("3");
                cmd.Parameters.AddWithValue("tel", FlowPannel.Controls["regionDatePers"].Controls["telTextBox"].Text.Trim());
                Console.WriteLine("4");
                cmd.Parameters.AddWithValue("mail", FlowPannel.Controls["regionDatePers"].Controls["mailTextBox"].Text.Trim());
                Console.WriteLine("5");
                RadioButton rad = (RadioButton)FlowPannel.Controls["regionDatePers"].Controls["MRadioBtn"];
                if (rad.Checked)
                {
                    cmd.Parameters.AddWithValue("sex", "M");
                }
                else
                {
                    cmd.Parameters.AddWithValue("sex", "F");
                }
                Console.WriteLine("6");
                cmd.Parameters.AddWithValue("jud", FlowPannel.Controls["regionAdresa"].Controls["judetTextBox"].Text.Trim());
                Console.WriteLine("7");
                cmd.Parameters.AddWithValue("oras", FlowPannel.Controls["regionAdresa"].Controls["orasTextBox"].Text.Trim());
                Console.WriteLine("8");
                cmd.Parameters.AddWithValue("tara", FlowPannel.Controls["regionAdresa"].Controls["taraTextBox"].Text.Trim());
                Console.WriteLine("9");
                cmd.Parameters.AddWithValue("str", FlowPannel.Controls["regionAdresa"].Controls["strTextBox"].Text.Trim());
                Console.WriteLine("10");
                cmd.Parameters.AddWithValue("nr", FlowPannel.Controls["regionAdresa"].Controls["nrTextBox"].Text.Trim());
                Console.WriteLine("14");
                if (!FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("bl", FlowPannel.Controls["regionAdresa"].Controls["blocTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("bl", DBNull.Value);
                }
                Console.WriteLine("11");
                if (!FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("sc", FlowPannel.Controls["regionAdresa"].Controls["scaraTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("sc", DBNull.Value);
                }
                Console.WriteLine("12");
                if (!FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("ap", FlowPannel.Controls["regionAdresa"].Controls["apTextBox"].Text.Trim());
                }
                else
                {
                    cmd.Parameters.AddWithValue("ap", DBNull.Value);
                }

                Console.WriteLine("13");
                if (string.IsNullOrEmpty(FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text))
                {
                    cmd.Parameters.AddWithValue("zip", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("zip", FlowPannel.Controls["regionAdresa"].Controls["codTextBox"].Text.Trim());
                }

                DateTime birthday = new DateTime(System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["yearComboBox"].Text),
                   System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["monthComboBox"].Text),
                    System.Convert.ToInt32(FlowPannel.Controls["regionDatePers"].Controls["dayComboBox"].Text));

                cmd.Parameters.AddWithValue("dn", SqlDbType.Date).Value = birthday.Date;
                Console.WriteLine("15");
                cmd.Parameters.AddWithValue("id", idToUp);
                Console.WriteLine("16");

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();

                Console.WriteLine("17");
                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void CheckClient()
        {
            Panel regionCheck = new System.Windows.Forms.Panel();
            Label maiLab = new System.Windows.Forms.Label();
            TextBox mailTextBox = new System.Windows.Forms.TextBox();
            Button ckBtn = new System.Windows.Forms.Button();
            // 
            // regionCheck
            // 
            regionCheck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionCheck.Controls.Add(mailTextBox);
            regionCheck.Controls.Add(maiLab);
            regionCheck.Controls.Add(ckBtn);
            regionCheck.Location = new System.Drawing.Point(3, 3);
            regionCheck.Name = "regionCheck";
            regionCheck.Size = new System.Drawing.Size(715, 102);
            regionCheck.TabIndex = 0;
            // 
            // maiLab
            // 
            maiLab.AutoSize = true;
            maiLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            maiLab.Location = new System.Drawing.Point(12, 20);
            maiLab.Name = "maiLab";
            maiLab.Size = new System.Drawing.Size(56, 22);
            maiLab.TabIndex = 0;
            maiLab.Text = "E-Mail";
            // 
            // mailTextBox
            // 
            mailTextBox.Location = new System.Drawing.Point(16, 57);
            mailTextBox.Name = "mailTextBox";
            mailTextBox.Size = new System.Drawing.Size(500, 25);
            mailTextBox.TabIndex = 1;
            mailTextBox.KeyDown += new KeyEventHandler(ckTextBox_KeyDown);
            // 
            // ckBtn
            // 
            ckBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            ckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ckBtn.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            ckBtn.Location = new System.Drawing.Point(590, 58);
            ckBtn.Name = "ckBtn";
            ckBtn.Size = new System.Drawing.Size(75, 23);
            ckBtn.TabIndex = 2;
            ckBtn.Text = "Check";
            ckBtn.UseVisualStyleBackColor = false;
            ckBtn.Click += new System.EventHandler(ckBtn_Click);

            FlowPannel.Controls.Add(regionCheck);
        }

        private void AddConf(ref SqlDataReader reader)
        {
            tableUni = "Conferinte";
            lastAddSala = 0;
            currentAddFac = 0;

            Panel regionNume;
            TextBox numeTextBox;
            Label numeLab;
            Panel regionData;
            DateTimePicker dsPicker;
            DateTimePicker diPicker;
            Label dsLab;
            Label diLab;
            Panel regionSalaFac;
            Label salaLab;
            Label facLab;
            Panel regionSave;
            ComboBox comboBox1;
            CheckedListBox facCheckList;
            Button cancelBtn;
            Button saveBtn;

            numeLab = new System.Windows.Forms.Label();
            numeTextBox = new System.Windows.Forms.TextBox();
            regionNume = new System.Windows.Forms.Panel();
            regionData = new System.Windows.Forms.Panel();
            diLab = new System.Windows.Forms.Label();
            dsLab = new System.Windows.Forms.Label();
            diPicker = new System.Windows.Forms.DateTimePicker();
            dsPicker = new System.Windows.Forms.DateTimePicker();
            regionSalaFac = new System.Windows.Forms.Panel();
            salaLab = new System.Windows.Forms.Label();
            facLab = new System.Windows.Forms.Label();
            regionSave = new System.Windows.Forms.Panel();
            facCheckList = new System.Windows.Forms.CheckedListBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            saveBtn = new System.Windows.Forms.Button();
            cancelBtn = new System.Windows.Forms.Button();

            Label pretLab = new Label();
            TextBox pretTextBox = new TextBox();
            // 
            // numeLab
            // 
            numeLab.AutoSize = true;
            numeLab.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeLab.Location = new System.Drawing.Point(12, 20);
            numeLab.Name = "numeLab";
            numeLab.Size = new System.Drawing.Size(170, 26);
            numeLab.TabIndex = 0;
            numeLab.Text = "Nume Conferinta";
            // 
            // numeTextBox
            // 
            numeTextBox.Location = new System.Drawing.Point(16, 57);
            numeTextBox.Name = "numeTextBox";
            numeTextBox.Size = new System.Drawing.Size(500, 25);
            numeTextBox.TabIndex = 1;
            numeTextBox.Tag = "Nume";
            numeTextBox.Leave += new EventHandler(CheckUnicity);
            // 
            // regionNume
            // 
            regionNume.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionNume.Controls.Add(numeTextBox);
            regionNume.Controls.Add(numeLab);
            regionNume.Location = new System.Drawing.Point(3, 3);
            regionNume.Name = "regionNume";
            regionNume.Size = new System.Drawing.Size(715, 102);
            regionNume.TabIndex = 0;
            // 
            // regionData
            // 
            regionData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionData.Controls.Add(dsPicker);
            regionData.Controls.Add(diPicker);
            regionData.Controls.Add(dsLab);
            regionData.Controls.Add(diLab);
            regionData.Location = new System.Drawing.Point(3, 111);
            regionData.Name = "regionData";
            regionData.Size = new System.Drawing.Size(715, 102);
            regionData.TabIndex = 1;
            regionData.Leave += new System.EventHandler(regionData_Leave);
            // 
            // diLab
            // 
            diLab.AutoSize = true;
            diLab.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            diLab.Location = new System.Drawing.Point(12, 20);
            diLab.Name = "diLab";
            diLab.Size = new System.Drawing.Size(128, 26);
            diLab.TabIndex = 0;
            diLab.Text = "Data Inceput";
            // 
            // dsLab
            // 
            dsLab.AutoSize = true;
            dsLab.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dsLab.Location = new System.Drawing.Point(417, 20);
            dsLab.Name = "dsLab";
            dsLab.Size = new System.Drawing.Size(118, 26);
            dsLab.TabIndex = 1;
            dsLab.Text = "Data Sfarsit";
            // 
            // diPicker
            // 
            diPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            diPicker.Location = new System.Drawing.Point(17, 62);
            diPicker.Name = "diPicker";
            diPicker.Size = new System.Drawing.Size(105, 25);
            diPicker.TabIndex = 2;
            diPicker.ValueChanged += new EventHandler(diChange);
            // 
            // dsPicker
            // 
            dsPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dsPicker.Location = new System.Drawing.Point(422, 62);
            dsPicker.Name = "dsPicker";
            dsPicker.Size = new System.Drawing.Size(105, 25);
            dsPicker.TabIndex = 3;
            dsPicker.ValueChanged += new EventHandler(dsChange);
            // 
            // regionSalaFac
            // 
            regionSalaFac.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionSalaFac.Controls.Add(comboBox1);
            regionSalaFac.Controls.Add(facCheckList);
            regionSalaFac.Controls.Add(facLab);
            regionSalaFac.Controls.Add(salaLab);
            regionSalaFac.Controls.Add(pretLab);
            regionSalaFac.Controls.Add(pretTextBox);
            regionSalaFac.Location = new System.Drawing.Point(3, 219);
            regionSalaFac.Name = "regionSalaFac";
            regionSalaFac.Size = new System.Drawing.Size(715, 217);
            regionSalaFac.TabIndex = 2;
            // 
            // salaLab
            // 
            salaLab.AutoSize = true;
            salaLab.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            salaLab.Location = new System.Drawing.Point(11, 14);
            salaLab.Name = "salaLab";
            salaLab.Size = new System.Drawing.Size(107, 26);
            salaLab.TabIndex = 1;
            salaLab.Text = "Alege Sala";
            // 
            // facLab
            // 
            facLab.AutoSize = true;
            facLab.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            facLab.Location = new System.Drawing.Point(417, 19);
            facLab.Name = "facLab";
            facLab.Size = new System.Drawing.Size(146, 26);
            facLab.TabIndex = 1;
            facLab.Text = "Alege Facilitati";
            // 
            // regionSave
            // 
            regionSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionSave.Controls.Add(cancelBtn);
            regionSave.Controls.Add(saveBtn);
            regionSave.Location = new System.Drawing.Point(3, 442);
            regionSave.Name = "regionSave";
            regionSave.Size = new System.Drawing.Size(715, 39);
            regionSave.TabIndex = 4;
            // 
            // facCheckList
            // 
            facCheckList.FormattingEnabled = true;
            facCheckList.Location = new System.Drawing.Point(422, 70);
            facCheckList.Name = "facCheckList";
            //PopulateCheckedList(ref facCheckList);
            facCheckList.Size = new System.Drawing.Size(222, 104);
            facCheckList.TabIndex = 2;
            //facCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(facCheckList_ItemCheck);
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(17, 70);
            comboBox1.Name = "comboBox1";
            //PopulateComboBox(ref comboBox1);
            comboBox1.Size = new System.Drawing.Size(105, 26);
            comboBox1.TabIndex = 3;
            comboBox1.MouseHover += new EventHandler(comboBox_MouseHover);
            //comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
            // 
            // saveBtn
            // 
            saveBtn.Location = new System.Drawing.Point(632, 10);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new System.Drawing.Size(75, 23);
            saveBtn.TabIndex = 0;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new System.Drawing.Point(536, 10);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(75, 23);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += new EventHandler(CancelMeth);
            // 
            // pretTextBox
            // 
            pretTextBox.Location = new System.Drawing.Point(16, 162);
            pretTextBox.Name = "pretTextBox";
            pretTextBox.ReadOnly = true;
            pretTextBox.Text = "0";
            pretTextBox.Size = new System.Drawing.Size(106, 25);
            pretTextBox.TabIndex = 5;
            // 
            // pretLab
            // 
            pretLab.AutoSize = true;
            pretLab.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pretLab.Location = new System.Drawing.Point(12, 133);
            pretLab.Name = "pretLab";
            pretLab.Size = new System.Drawing.Size(49, 26);
            pretLab.TabIndex = 4;
            pretLab.Text = "Pret";

            FlowPannel.Controls.Add(regionNume);
            FlowPannel.Controls.Add(regionData);
            FlowPannel.Controls.Add(regionSalaFac);
            FlowPannel.Controls.Add(regionSave);

            if (reader == null)
            {
                prevUniVal = "";

                diPicker.MinDate = System.DateTime.Now;
                dsPicker.MinDate = System.DateTime.Now;
                PopulateComboBox(ref comboBox1);
                PopulateCheckedList(ref facCheckList);
                saveBtn.Click += new EventHandler(SaveConf);
            }
            else
            {
                numeTextBox.Text = reader[0].ToString();

                string sala = reader[2].ToString();

                DateTime di = reader.GetDateTime(3);
                DateTime ds = reader.GetDateTime(4);
                diPicker.Value = di;
                dsPicker.Value = ds;
                dateDiff = 1 + System.Convert.ToInt32((dsPicker.Value.Date - diPicker.Value.Date).TotalDays.ToString());

                pretTextBox.Text = reader[5].ToString();

                lastAddSala = reader.GetInt32(6) * dateDiff;
                Email = reader[7].ToString();
                Console.WriteLine(lastAddSala);
                reader.Close();

                PopulateComboBox(ref comboBox1);
                PopulateCheckedList(ref facCheckList);
                comboBox1.SelectedIndex = comboBox1.FindStringExact(sala);
                SetCheckedItems(ref facCheckList);

                saveBtn.Text = "Update";
                saveBtn.Click += new EventHandler(UpConf);

                if(di < System.DateTime.Now)
                {
                    diPicker.Enabled = false;
                    dsPicker.Enabled = false;
                    comboBox1.Enabled = false;
                    facCheckList.Enabled = false;
                    saveBtn.Enabled = false;
                }

                readyToSave = true;
                prevUniVal = numeTextBox.Text;
            }

            facCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(facCheckList_ItemCheck);
            comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);

            //FlowPannel.Controls.Add(regionNume);
            //FlowPannel.Controls.Add(regionData);
            //FlowPannel.Controls.Add(regionSalaFac);
            //FlowPannel.Controls.Add(regionSave);
        }

        private void SaveConf(object sender, EventArgs e)
        {
            // Variabile ajutatoare
            CheckedListBox tempCheckBox = (CheckedListBox)FlowPannel.Controls["regionSalaFac"].Controls["facCheckList"];
            ComboBox tempComboBox = (ComboBox)FlowPannel.Controls["regionSalaFac"].Controls["comboBox1"];
            DateTimePicker tempDIPicker = (DateTimePicker)FlowPannel.Controls["regionData"].Controls["diPicker"];
            DateTimePicker tempDSPicker = (DateTimePicker)FlowPannel.Controls["regionData"].Controls["dsPicker"];

            //Parte de comenzi SQL
            SqlCommand insertConf = new SqlCommand("INSERT INTO Conferinte(Nume,ID_Client,ID_Sala,D_Inceput,D_Sfarsit,Pret)" +
                " VALUES(@nume,@idc,@ids,@di,@ds,@pret);", connection);
            SqlCommand insertFacConf = new SqlCommand("INSERT INTO FacilitatiConferinte(ID_conf,ID_Fac)" +
                "VALUES(@idc,@idf);", connection);

            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }
                //Param insert Conferinte
                insertConf.Parameters.AddWithValue("nume", FlowPannel.Controls["regionNume"].Controls["numeTextBox"].Text.Trim());
                insertConf.Parameters.AddWithValue("di", SqlDbType.Date).Value = tempDIPicker.Value.Date;
                insertConf.Parameters.AddWithValue("ds", SqlDbType.Date).Value = tempDSPicker.Value.Date;
                insertConf.Parameters.AddWithValue("pret", System.Convert.ToInt32(FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text));
                insertConf.Parameters.AddWithValue("ids", salaID[tempComboBox.SelectedIndex]);
                insertConf.Parameters.AddWithValue("idc", GetClientID());

                insertConf.ExecuteNonQuery();
                //param insert FacilitatiConferinte
                insertFacConf.Parameters.AddWithValue("idc", GetNewConfID());
                insertFacConf.Parameters.Add("idf", SqlDbType.Int);

                for (int i = 0; i < tempCheckBox.Items.Count; i++)
                {
                    if (tempCheckBox.GetItemChecked(i))
                    {
                        insertFacConf.Parameters["idf"].Value = facID[i];
                        insertFacConf.ExecuteNonQuery();
                    }
                }

                //MessageBox.Show("Success!");
                MakeSuccessImg();
                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void UpConf(object sender, EventArgs e)
        {
            // Variabile ajutatoare
            CheckedListBox tempCheckBox = (CheckedListBox)FlowPannel.Controls["regionSalaFac"].Controls["facCheckList"];
            ComboBox tempComboBox = (ComboBox)FlowPannel.Controls["regionSalaFac"].Controls["comboBox1"];
            DateTimePicker tempDIPicker = (DateTimePicker)FlowPannel.Controls["regionData"].Controls["diPicker"];
            DateTimePicker tempDSPicker = (DateTimePicker)FlowPannel.Controls["regionData"].Controls["dsPicker"];

            //Parte de comenzi SQL

            SqlCommand insertConf = new SqlCommand("UPDATE Conferinte SET Nume=@nume, ID_Client=@idc, " +
                "ID_Sala=@ids, D_Inceput=@di, D_Sfarsit=@ds, Pret=@pret WHERE Conf_ID=@id;", connection);
            SqlCommand insertFacConf = new SqlCommand("INSERT INTO FacilitatiConferinte(ID_conf,ID_Fac)" +
                "VALUES(@idc,@idf);", connection);
            SqlCommand deleteFacConf = new SqlCommand("DELETE FROM FacilitatiConferinte " +
                "WHERE ID_Conf=@idc;", connection);

            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }
                //Param insert Conferinte
                insertConf.Parameters.AddWithValue("nume", FlowPannel.Controls["regionNume"].Controls["numeTextBox"].Text.Trim());
                insertConf.Parameters.AddWithValue("di", SqlDbType.Date).Value = tempDIPicker.Value.Date;
                insertConf.Parameters.AddWithValue("ds", SqlDbType.Date).Value = tempDSPicker.Value.Date;
                insertConf.Parameters.AddWithValue("pret", System.Convert.ToInt32(FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text));
                insertConf.Parameters.AddWithValue("ids", salaID[tempComboBox.SelectedIndex]);
                insertConf.Parameters.AddWithValue("idc", GetClientID());
                insertConf.Parameters.AddWithValue("id", idToUp);

                insertConf.ExecuteNonQuery();

                //param insert FacilitatiConferinte
                deleteFacConf.Parameters.AddWithValue("idc", idToUp);

                deleteFacConf.ExecuteNonQuery();

                insertFacConf.Parameters.AddWithValue("idc", idToUp);
                insertFacConf.Parameters.Add("idf", SqlDbType.Int);

                for (int i = 0; i < tempCheckBox.Items.Count; i++)
                {
                    if (tempCheckBox.GetItemChecked(i))
                    {
                        insertFacConf.Parameters["idf"].Value = facID[i];
                        insertFacConf.ExecuteNonQuery();
                    }
                }

                //MessageBox.Show("Success!");
                MakeSuccessImg();
                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void diChange(object sender, EventArgs e)
        {
            
        }

        private void dsChange(object sender, EventArgs e)
        {

        }

        private void RecalcFac()
        {
            CheckedListBox tempCheckBox = (CheckedListBox)FlowPannel.Controls["regionSalaFac"].Controls["facCheckList"];
            int currentPrice = System.Convert.ToInt32(FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text);
            currentPrice -= currentAddFac;
            Console.WriteLine(currentAddFac);
            currentAddFac = 0;

            for (int i=0;i<tempCheckBox.Items.Count;i++)
            {
                if(tempCheckBox.GetItemChecked(i))
                {
                    currentAddFac += preturiFac[i];
                }
            }
            currentAddFac *= dateDiff;

            currentPrice += currentAddFac;
            FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text = currentPrice.ToString();
        }

        private int GetClientID()
        {
            int id = 0;

            SqlCommand cmd = new SqlCommand("SELECT Client_ID FROM Client" +
                " WHERE Mail=@email", connection);

            try
            {
                cmd.Parameters.AddWithValue("email", Email);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    id = System.Convert.ToInt32(reader[0]);
                    //reader.Close();
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }

            return id;
        }

        private int GetNewConfID()
        {
            int id = 0;

            SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('Conferinte');", connection);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    id = System.Convert.ToInt32(reader[0]);
                    //reader.Close();
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }

            return id;
        }

        private void PopulateCheckedList(ref CheckedListBox checkList)
        {
            SqlCommand cmd = new SqlCommand("SELECT Nume_fac, Pret, ID_Fac FROM Facilitati;", connection);
            preturiFac = new List<int>();
            facID = new List<int>();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkList.Items.Add(reader[0].ToString());
                        preturiFac.Add(System.Convert.ToInt32(reader[1]));
                        facID.Add(System.Convert.ToInt32(reader[2]));
                    }
                    reader.Close();
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void PopulateComboBox(ref ComboBox comboBox)
        {
            SqlCommand cmd = new SqlCommand("SELECT Nume_sala, Pret_h, Sala_ID, Poza" +
                " FROM Sala;", connection);
            preturiSala = new List<int>();
            salaID = new List<int>();
            salaPozaList = new List<string>();
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader[0].ToString());
                        preturiSala.Add(System.Convert.ToInt32(reader[1]));
                        salaID.Add(System.Convert.ToInt32(reader[2]));
                        salaPozaList.Add(reader[3].ToString());
                    }
                    reader.Close();
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void SetCheckedItems(ref CheckedListBox checkList)
        {
            SqlCommand cmd = new SqlCommand("SELECT F.Nume_fac FROM FacilitatiConferinte FC INNER JOIN Facilitati F on (FC.ID_Fac=F.ID_Fac) WHERE FC.ID_Conf=@id;", connection);
            cmd.Parameters.AddWithValue("id", idToUp);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkList.SetItemChecked(checkList.FindStringExact(reader[0].ToString()), true);
                        currentAddFac += preturiFac[checkList.FindStringExact(reader[0].ToString())];
                    }
                    currentAddFac *= dateDiff;
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void UpdateSala(ref SqlDataReader reader)
        {
            System.Windows.Forms.Panel regionSala;
            System.Windows.Forms.TextBox numeTextBox;
            System.Windows.Forms.Label numeLab;
            System.Windows.Forms.PictureBox salaPic;
            System.Windows.Forms.TextBox nrTextBox;
            System.Windows.Forms.Label nrLab;
            System.Windows.Forms.Label angLab;
            System.Windows.Forms.ComboBox angComboBox;
            System.Windows.Forms.TextBox pretTextBox;
            System.Windows.Forms.Label pretLab;
            System.Windows.Forms.Button cancelBtn;
            System.Windows.Forms.Button upBtn;

            regionSala = new System.Windows.Forms.Panel();
            salaPic = new System.Windows.Forms.PictureBox();
            numeLab = new System.Windows.Forms.Label();
            numeTextBox = new System.Windows.Forms.TextBox();
            nrTextBox = new System.Windows.Forms.TextBox();
            nrLab = new System.Windows.Forms.Label();
            pretTextBox = new System.Windows.Forms.TextBox();
            pretLab = new System.Windows.Forms.Label();
            angComboBox = new System.Windows.Forms.ComboBox();
            angLab = new System.Windows.Forms.Label();
            upBtn = new System.Windows.Forms.Button();
            cancelBtn = new System.Windows.Forms.Button();
            // 
            // regionSala
            // 
            regionSala.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            regionSala.Controls.Add(cancelBtn);
            regionSala.Controls.Add(upBtn);
            regionSala.Controls.Add(angLab);
            regionSala.Controls.Add(angComboBox);
            regionSala.Controls.Add(pretTextBox);
            regionSala.Controls.Add(pretLab);
            regionSala.Controls.Add(nrTextBox);
            regionSala.Controls.Add(nrLab);
            regionSala.Controls.Add(numeTextBox);
            regionSala.Controls.Add(numeLab);
            regionSala.Controls.Add(salaPic);
            regionSala.Location = new System.Drawing.Point(3, 3);
            regionSala.Name = "regionSala";
            regionSala.Size = new System.Drawing.Size(714, 195);
            regionSala.TabIndex = 0;
            // 
            // salaPic
            // 
            if (reader[4] == DBNull.Value)
            {
                salaPic.Image = global::Conferinta.Properties.Resources.picture;
            }
            else
            {
                salaPic.ImageLocation = @reader[4].ToString();
            }
            salaPic.Cursor = System.Windows.Forms.Cursors.Hand;
            salaPic.Location = new System.Drawing.Point(3, 3);
            salaPic.Name = "salaPic";
            salaPic.Size = new System.Drawing.Size(192, 189);
            salaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            salaPic.TabIndex = 0;
            salaPic.TabStop = false;
            salaPic.Click += new EventHandler(angPoza_Click);
            // 
            // numeLab
            // 
            numeLab.AutoSize = true;
            numeLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            numeLab.Location = new System.Drawing.Point(217, 15);
            numeLab.Name = "numeLab";
            numeLab.Size = new System.Drawing.Size(91, 22);
            numeLab.TabIndex = 1;
            numeLab.Text = "Nume Sala";
            // 
            // numeTextBox
            // 
            numeTextBox.Location = new System.Drawing.Point(221, 40);
            numeTextBox.Name = "numeTextBox";
            numeTextBox.Size = new System.Drawing.Size(220, 25);
            numeTextBox.TabIndex = 2;
            numeTextBox.Text = reader[0].ToString();
            // 
            // nrTextBox
            // 
            nrTextBox.Location = new System.Drawing.Point(221, 105);
            nrTextBox.Name = "nrTextBox";
            nrTextBox.Size = new System.Drawing.Size(67, 25);
            nrTextBox.TabIndex = 4;
            nrTextBox.Text = reader[1].ToString();
            // 
            // nrLab
            // 
            nrLab.AutoSize = true;
            nrLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            nrLab.Location = new System.Drawing.Point(217, 80);
            nrLab.Name = "nrLab";
            nrLab.Size = new System.Drawing.Size(115, 22);
            nrLab.TabIndex = 3;
            nrLab.Text = "Numar Locuri";
            // 
            // pretTextBox
            // 
            pretTextBox.Location = new System.Drawing.Point(221, 164);
            pretTextBox.Name = "pretTextBox";
            pretTextBox.Size = new System.Drawing.Size(67, 25);
            pretTextBox.TabIndex = 6;
            pretTextBox.Text = reader[2].ToString();
            // 
            // pretLab
            // 
            pretLab.AutoSize = true;
            pretLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            pretLab.Location = new System.Drawing.Point(217, 139);
            pretLab.Name = "pretLab";
            pretLab.Size = new System.Drawing.Size(59, 22);
            pretLab.TabIndex = 5;
            pretLab.Text = "Pret/zi";
            // 
            // angComboBox
            // 
            angComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            angComboBox.FormattingEnabled = true;
            angComboBox.Location = new System.Drawing.Point(499, 105);
            angComboBox.Name = "angComboBox";
            angComboBox.Size = new System.Drawing.Size(195, 26);
            angComboBox.TabIndex = 7;
            angComboBox.MouseHover += new EventHandler(comboBox_MouseHover);
            // 
            // angLab
            // 
            angLab.AutoSize = true;
            angLab.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            angLab.Location = new System.Drawing.Point(495, 80);
            angLab.Name = "angLab";
            angLab.Size = new System.Drawing.Size(68, 22);
            angLab.TabIndex = 8;
            angLab.Text = "Angajat";
            // 
            // upBtn
            // 
            upBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            upBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            upBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            upBtn.Location = new System.Drawing.Point(632, 169);
            upBtn.Name = "upBtn";
            upBtn.Size = new System.Drawing.Size(75, 23);
            upBtn.TabIndex = 9;
            upBtn.Text = "Update";
            upBtn.UseVisualStyleBackColor = false;
            upBtn.Click += new EventHandler(UpSala);
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cancelBtn.Location = new System.Drawing.Point(537, 169);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(75, 23);
            cancelBtn.TabIndex = 10;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += new EventHandler(CancelMeth);

            int idComboBox = -1;

            if (reader[3] != DBNull.Value)
            {
                idComboBox = reader.GetInt32(3);
            }

            reader.Close();
            PopulateAngajati(ref angComboBox);

            if (idComboBox != -1)
            {
                int indexComboBox = angID.IndexOf(idComboBox);
                angComboBox.SelectedIndex = indexComboBox;
            }

            readyToSave = true;
            prevUniVal = numeTextBox.Text;
            FlowPannel.Controls.Add(regionSala);
        }

        private void UpSala(object sender, EventArgs e)
        {
            //var ajutatoare
            ComboBox angajatComboBox = (ComboBox)FlowPannel.Controls["regionSala"].Controls["angComboBox"];
            PictureBox salaPicBox = (PictureBox)FlowPannel.Controls["regionSala"].Controls["salaPic"];

            SqlCommand cmd = new SqlCommand("UPDATE Sala SET Nume_sala=@nume, Nr_loc=@nr, Pret_h=@pret, " +
                "ID_Angajat=@ida, Poza=@poza WHERE Sala_ID=@id;", connection);
            try
            {
                if (!readyToSave)
                {
                    throw new Exception("Camp deja existent!");
                }

                cmd.Parameters.AddWithValue("nume", FlowPannel.Controls["regionSala"].Controls["numeTextBox"].Text.Trim());
                cmd.Parameters.AddWithValue("nr", System.Convert.ToInt32(FlowPannel.Controls["regionSala"].Controls["nrTextBox"].Text.Trim()));
                if (CheckInt(FlowPannel.Controls["regionSala"].Controls["pretTextBox"]))
                {
                    cmd.Parameters.AddWithValue("pret", System.Convert.ToInt32(FlowPannel.Controls["regionSala"].Controls["pretTextBox"].Text.Trim()));
                }
                else
                {
                    throw new Exception("Verificati datele introduse!");
                }
                cmd.Parameters.AddWithValue("ida", angID[angajatComboBox.SelectedIndex]);
                if(string.IsNullOrEmpty(salaPicBox.ImageLocation))
                {
                    cmd.Parameters.AddWithValue("poza", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("poza", salaPicBox.ImageLocation);
                }
                cmd.Parameters.AddWithValue("id", idToUp);

                cmd.ExecuteNonQuery();

                //MessageBox.Show("Success!");
                MakeSuccessImg();
                canAdd = true;
                lastPressed.PerformClick();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void PopulateAngajati(ref ComboBox comboBox)
        {
            SqlCommand cmd = new SqlCommand("SELECT Nume+' '+Prenume, Angajat_ID,Mail,Photo" +
                " FROM Angajat;",connection);
            angID = new List<int>();
            angEmailList = new List<string>();
            angPozaList = new List<string>();

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader[0].ToString());
                        angID.Add(reader.GetInt32(1));
                        angEmailList.Add(reader[2].ToString());
                        if (reader[3] != DBNull.Value)
                        {
                            angPozaList.Add(reader[3].ToString());
                        }
                        else
                        {
                            angPozaList.Add("");
                        }
                    }
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            if(facPress && canAdd)
            {
                FlowPannel.Controls.Clear();
                AddFac(reader);
            }
            if(angPress && canAdd)
            {
                FlowPannel.Controls.Clear();
                AddAngajatClient(reader);
            }
            if(clientiPress && canAdd)
            {
                FlowPannel.Controls.Clear();
                AddAngajatClient(reader, true);
            }
            if(confPress && canAdd)
            {
                FlowPannel.Controls.Clear();
                CheckClient();
            }
            canAdd = false;
            canDelete = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void angPoza_Click(object sender, EventArgs e)
        {
            //PictureBox tempPic = (PictureBox)FlowPannel.Controls["regionDatePers"].Controls["angPoza"];
            PictureBox tempPic = (PictureBox)sender;
            OpenFileDialog chooseImg = new OpenFileDialog();
            chooseImg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(chooseImg.ShowDialog()==DialogResult.OK)
            {
                tempPic.ImageLocation = @chooseImg.FileName;
            }
        }

        private void ckTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ckBtn_Click(null, null);
            }
        }

        private void ckBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Client WHERE Mail=@email;",connection);

            try
            {
                Email = FlowPannel.Controls["regionCheck"].Controls["mailTextBox"].Text.Trim();
                cmd.Parameters.AddWithValue("email", Email);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                bool valueRet = System.Convert.ToBoolean(reader[0]);
                reader.Close();

                if(valueRet)
                {
                    SqlDataReader reader1 = null;
                    FlowPannel.Controls.Clear();
                    AddConf(ref reader1);
                }
                else
                {
                    FlowPannel.Controls.Clear();
                    AddAngajatClient(null, true);
                    FlowPannel.Controls["regionDatePers"].Controls["mailTextBox"].Text = Email;
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tempComboBox = (ComboBox)sender;
            // Console.WriteLine("3");
            //MessageBox.Show(tempComboBox.SelectedIndex.ToString());
            //MessageBox.Show(lastAddSala.ToString() + "," + dateDiff.ToString());            
            if (tempComboBox.SelectedIndex > -1)
            {
               // Console.WriteLine("3");
                int currentPrice = System.Convert.ToInt32(FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text);
                Console.WriteLine(currentPrice);
                currentPrice -= lastAddSala;
                Console.WriteLine(currentPrice);
                currentPrice += preturiSala[tempComboBox.SelectedIndex]*dateDiff;
                Console.WriteLine(currentPrice);
                lastAddSala = preturiSala[tempComboBox.SelectedIndex]*dateDiff;
               // Console.WriteLine("7");
                FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text = currentPrice.ToString();
                //Console.WriteLine("8");
            }
        }

        private void facCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox tempCheckList = (CheckedListBox)sender;
            int currentPrice = System.Convert.ToInt32(FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text);
            if(e.NewValue==CheckState.Checked)
            {
                currentPrice += preturiFac[e.Index]*dateDiff;
                currentAddFac += preturiFac[e.Index]*dateDiff;
            }
            else
            {
                currentPrice -= preturiFac[e.Index]*dateDiff;
                currentAddFac -= preturiFac[e.Index] * dateDiff;
            }

            FlowPannel.Controls["regionSalaFac"].Controls["pretTextBox"].Text = currentPrice.ToString();
        }

        private void regionData_Leave(object sender, EventArgs e)
        {
            DateTimePicker diPicker = (DateTimePicker)FlowPannel.Controls["regionData"].Controls["diPicker"];
            DateTimePicker dsPicker = (DateTimePicker)FlowPannel.Controls["regionData"].Controls["dsPicker"];

            dateDiff = 1 + System.Convert.ToInt32((dsPicker.Value.Date - diPicker.Value.Date).TotalDays.ToString());
            if (dateDiff > 0)
            {
                comboBox1_SelectedIndexChanged((object)FlowPannel.Controls["regionSalaFac"].Controls["comboBox1"], e);
                RecalcFac();
            }
            else
            {
                MessageBox.Show("Data Sfarsit incorect aleasa!");
                dsPicker.Value = diPicker.Value;
                regionData_Leave(sender, e);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(togMove)
            {
                Console.WriteLine(MousePosition.X.ToString() + "," + MousePosition.Y);
                Console.WriteLine(initLoc.ToString());
                this.SetDesktopLocation(MousePosition.X-initLoc.X, MousePosition.Y);
            }
        }

        private void regionNume_DoubleClick(object sender, EventArgs e)
        {

        }

        private void UpdateThing(object sender, EventArgs e)
        {
            Panel tempPanel = (Panel)sender;
            idToUp = System.Convert.ToInt32(tempPanel.AccessibleName);
            FlowPannel.Controls.Clear();
            canAdd = false;
            canDelete = false;

            try
            {
                if (facPress)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Nume_fac, Pret FROM Facilitati WHERE ID_Fac=@id;", connection);
                    cmd.Parameters.AddWithValue("id", idToUp);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    AddFac(reader);

                    reader.Close();
                }
                if(angPress)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Angajat WHERE Angajat_ID = @id;", connection);
                    cmd.Parameters.AddWithValue("id", idToUp);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    AddAngajatClient(reader);

                    reader.Close();
                }
                if(clientiPress)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Client WHERE Client_ID = @id;", connection);
                    cmd.Parameters.AddWithValue("id", idToUp);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    AddAngajatClient(reader,true);

                    reader.Close();
                }

                if(confPress)
                {
                    SqlCommand cmd = new SqlCommand("SELECT C.Nume,CL.Nume+' '+CL.Prenume as Nume_Cli," +
                        "S.Nume_sala,C.D_Inceput,C.D_Sfarsit,C.Pret,S.Pret_h,CL.Mail FROM Conferinte C INNER JOIN Sala S" +
                        " on(C.ID_Sala=S.Sala_ID) INNER JOIN Client CL " +
                        "on (C.ID_Client=CL.Client_ID) WHERE C.Conf_ID=@id;", connection);
                    cmd.Parameters.AddWithValue("id", idToUp);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    AddConf(ref reader);
                    
                }

                if(salaPress)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Nume_sala, Nr_loc, Pret_h," +
                        " ID_Angajat,Poza FROM Sala WHERE Sala_ID=@id;", connection);
                    cmd.Parameters.AddWithValue("id", idToUp);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    UpdateSala(ref reader);

                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }

        } //JOIN

        private void hbPic_Click(object sender, EventArgs e)
        {
            FlowPannel.Controls.Clear();
            NormalLight(Conferinte);
            NormalLight(Angajati);
            NormalLight(clientiBtn);
            NormalLight(saliBtn);
            NormalLight(facBtn);
            canAdd = false;
            canDelete = false;

            angPress = false;
            clientiPress = false;
            facPress = false;
            salaPress = false;
            confPress = false;

            Dashboard();
        }

        private void delPic_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(table) && idToDel!=0)
            if(canDelete)
            {
                DialogResult deleteAsk = MessageBox.Show("Aceasta operatie poate afecta celelalte tabele!" +
                    "\n\nDoriti sa continuati?", "Delete", MessageBoxButtons.YesNo);
                if (deleteAsk == DialogResult.Yes)
                {
                    try
                    {
                        //if(!canAdd)
                        //{
                        //    throw new Exception("Acesta nu este un tabel!");
                        //}
                        SqlCommand cmd = new SqlCommand("DELETE FROM " + table + " WHERE " + colName +
                            "=@id;", connection);
                        cmd.Parameters.AddWithValue("id", idToDel);

                        cmd.ExecuteNonQuery();

                        lastPressed.PerformClick();
                    }
                    catch (SqlException er)
                    {
                        MessageBox.Show("SQL Server retruned: " + er.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Program returned: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Acest tabel nu poate suferi modificari de stergere" +
                    " sau nicio inregistrare nu a fost selectata!");
            }
        }

        private void saliBtn_MouseHover(object sender, EventArgs e)
        {
            if(!salaPress)
            {
                Highlight(saliBtn);
            }
        }

        private void saliBtn_MouseLeave(object sender, EventArgs e)
        {
            if(!salaPress)
            {
                NormalLight(saliBtn);
            }
        }

        private void clientiBtn_MouseHover(object sender, EventArgs e)
        {
            if(!clientiPress)
            {
                Highlight(clientiBtn);
            }
        }

        private void clientiBtn_MouseLeave(object sender, EventArgs e)
        {
            if(!clientiPress)
            {
                NormalLight(clientiBtn);
            }
        }

        private void facBtn_MouseHover(object sender, EventArgs e)
        {
            if(!facPress)
            {
                Highlight(facBtn);
            }
        }

        private void facBtn_MouseLeave(object sender, EventArgs e)
        {
            if(!facPress)
            {
                NormalLight(facBtn);
            }
        }

        private void delPic_MouseHover(object sender, EventArgs e)
        {
            if(canDelete)
            {
                delPic.Image = global::Conferinta.Properties.Resources._003_trash_can;
            }
        }

        private void delPic_MouseLeave(object sender, EventArgs e)
        {
            if (canDelete)
            {
                delPic.Image = global::Conferinta.Properties.Resources._002_waste_bin;
            }
        }

        private void addBox_MouseHover(object sender, EventArgs e)
        {
            if (!salaPress && canAdd)
            {
                addBox.Image = global::Conferinta.Properties.Resources._004_plus_sign_silhouette;
            }
        }

        private void addBox_MouseLeave(object sender, EventArgs e)
        {
            if (!salaPress)
            {
                addBox.Image = global::Conferinta.Properties.Resources._001_plus_sign_silhouette_1;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                if(confPress)
                {
                    selOption = " WHERE Nume='" + SearchTextBox.Text.Trim() + "'";
                }
                if (salaPress)
                {
                    selOption = " WHERE Nume_sala='" + SearchTextBox.Text.Trim() + "'";
                }
                if (clientiPress)
                {
                    selOption = " WHERE Nume+' '+Prenume='" + SearchTextBox.Text.Trim() + "'";
                }
                if (angPress)
                {
                    selOption = " WHERE Nume+' '+Prenume='" + SearchTextBox.Text.Trim() + "'";
                }
                if (facPress)
                {

                    selOption = " WHERE Nume_fac='" + SearchTextBox.Text.Trim() + "'";
                }

                lastPressed.PerformClick();
                selOption = "";
            }

        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void angComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            
        }

        private void cancelBtn_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void angComboBox_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void angComboBox_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBox_MouseHover(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if(comboBox.SelectedIndex>=0)
            {
                CustomToolTipDemo.CustomizedToolTip customToolTip = new CustomToolTipDemo.CustomizedToolTip();
               

                comboBox.Tag = Conferinta.Properties.Resources._003_no_photo;
                if (salaPress)
                {
                    if (!string.IsNullOrEmpty(angPozaList[comboBox.SelectedIndex]))
                    {
                        comboBox.Tag = Image.FromFile(@angPozaList[comboBox.SelectedIndex]);
                    }
                    customToolTip.SetToolTip(comboBox, angEmailList[comboBox.SelectedIndex]);
                }
                else
                {
                    if (!string.IsNullOrEmpty(salaPozaList[comboBox.SelectedIndex]))
                    {
                        comboBox.Tag = Image.FromFile(@salaPozaList[comboBox.SelectedIndex]);
                    }
                    customToolTip.SetToolTip(comboBox, "Pret: "+preturiSala[comboBox.SelectedIndex].ToString());
                }

                customToolTip.Font = new Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                customToolTip.AutoSize = false;
                customToolTip.Size = new Size(3 * 150, 2 * 50);
                customToolTip.BorderColor = System.Drawing.Color.Orange;
                customToolTip.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void SingleClick(object sender, EventArgs e)
        {
            currentSelectedpanel = (Panel)sender;

            if (previousSelectedPanel!=null)
            {
                previousSelectedPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            }

            currentSelectedpanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            previousSelectedPanel = currentSelectedpanel;

            if(!salaPress)
                idToDel = System.Convert.ToInt32(currentSelectedpanel.AccessibleName);
            Console.WriteLine(idToDel);
        }

        private async void MakeSuccessImg()
        {
            PictureBox picBox = new PictureBox();

            picBox.Cursor = System.Windows.Forms.Cursors.Hand;
            picBox.ImageLocation = @"E:\Scoala\Anul3\Sem 1\BD\Proiect\Imagini\Mesaj\SuccessMessage.gif";
            picBox.Name = "picBox";
            picBox.Size = new System.Drawing.Size(300, 300);
            picBox.Location = new System.Drawing.Point((regionPic.Width-picBox.Width)/2 + regionPic.Location.X,
                (regionPic.Height - picBox.Height) / 2 + regionPic.Location.Y);
            picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            this.Controls.Add(picBox);
            picBox.BringToFront();
            Console.WriteLine("img1");

            System.Media.SystemSounds.Exclamation.Play();
            await Task.Delay(4000);            
            await Task.Delay(1000);

            FlowPannel.ResumeLayout();
            Console.WriteLine("img2");

            this.Controls.Remove(picBox);
            picBox.Dispose();
        }

        private bool CheckInt(object sender)
        {
            TextBox tempTextBox = (TextBox)sender;

            if(!int.TryParse(tempTextBox.Text,out int val))
            {
                tempTextBox.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Settings setari = new Settings(this);
            setari.Show();

            this.Enabled = false;
            
        }

        private void settingsBtn_MouseHover(object sender, EventArgs e)
        {
            settingsBtn.Image= global::Conferinta.Properties.Resources._001_settings_1;
        }

        private void settingsBtn_MouseLeave(object sender, EventArgs e)
        {
            settingsBtn.Image = global::Conferinta.Properties.Resources._002_settings;
        }

        private void chart1_Click(object sender, EventArgs e)
        {


        }

        private void facVandLinkLabel_LinkClicked(object sender, EventArgs e) //JOIN
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart = (System.Windows.Forms.DataVisualization.Charting.Chart)FlowPannel.Controls["dataChart"];

            dataChart.Series.Clear();
            dataChart.Series.Add("Facilitati");

            SqlCommand cmd = new SqlCommand("SELECT F.Nume_fac, COUNT(*) as nr" +
                " FROM FacilitatiConferinte FC " +
                "INNER JOIN Facilitati F ON(FC.ID_Fac=F.ID_Fac)" +
                " GROUP BY F.Nume_fac ORDER BY nr DESC;", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    dataChart.Series["Facilitati"].Points.AddXY(reader[0].ToString(), reader.GetInt32(1));
                }
                reader.Close();

                ChangeColorButton(sender);
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }

        }

        private void salaLinkLabel_LinkClicked(object sender, EventArgs e) //JOIN
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart = (System.Windows.Forms.DataVisualization.Charting.Chart)FlowPannel.Controls["dataChart"];

            dataChart.Series.Clear();
            dataChart.Series.Add("Sala");
            dataChart.Series.Add("Ocupare X 20");
            
            SqlCommand cmd = new SqlCommand("SELECT S.Nume_sala,S.Pret_h,COUNT(*) as nr FROM Conferinte C" +
                " INNER JOIN Sala S ON (C.ID_Sala=S.Sala_ID)" +
                " GROUP BY S.Nume_sala,S.Pret_h ORDER BY nr DESC;", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataChart.Series["Sala"].Points.AddXY(reader[0].ToString(), reader.GetInt32(1));
                    dataChart.Series["Ocupare X 20"].Points.AddY(reader.GetInt32(2)*20);
                }
                reader.Close();
                ChangeColorButton(sender);
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void conf1LinkLabel_LinkClicked(object sender, EventArgs e) //COMPLEX
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart = (System.Windows.Forms.DataVisualization.Charting.Chart)FlowPannel.Controls["dataChart"]; 
            dataChart.Series.Clear();
            dataChart.Series.Add("Conferinte");

            SqlCommand cmd = new SqlCommand("SELECT C.Nume,C.Pret  FROM Conferinte C" +
                " WHERE(C.ID_Sala = (SELECT TOP(1) S.Sala_ID FROM SALA S" +
                " ORDER BY S.Pret_h DESC));", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataChart.Series["Conferinte"].Points.AddXY(reader[0].ToString(), reader.GetInt32(1));
                }

                reader.Close();
                ChangeColorButton(sender);
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void ang1LinkLabel_LinkClicked(object sender, EventArgs e) //COMPLEX
        {
            runDashboard = false;
            FlowPannel.Controls.Clear();
            SqlCommand cmd = new SqlCommand("SELECT A.Nume+' '+A.Prenume, A.Telefon, A.Mail," +
                " A.Sex, A.Photo, A.Angajat_ID FROM Angajat A WHERE(A.Angajat_ID IN (SELECT S.ID_Angajat" +
                " FROM SALA S WHERE (S.Sala_ID IN (SELECT C.ID_Sala FROM Conferinte C GROUP BY " +
                "C.ID_Sala HAVING SUM(C.Pret)>1000 ))));", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (!angPress)
                {
                    source = new AutoCompleteStringCollection();
                }
                contor = 0;

                while (reader.Read())
                {
                    Console.WriteLine("da");
                    ListAngajati(ref reader);
                    Console.WriteLine("dA1");
                    source.Add(reader[0].ToString());
                    contor++;
                }
                if (!angPress)
                {
                    SearchTextBox.AutoCompleteCustomSource = source;
                    angPress = true;
                }
                reader.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void clientLinkLabel_LinkClicked(object sender, EventArgs e) //JOIN
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart = (System.Windows.Forms.DataVisualization.Charting.Chart)FlowPannel.Controls["dataChart"];

            dataChart.Series.Clear();
            dataChart.Series.Add("Client");

            SqlCommand cmd = new SqlCommand("SELECT TOP(3) CL.Nume+' '+CL.Prenume as nume," +
                " COUNT(*) as nr FROM Conferinte C INNER JOIN Client CL ON(C.ID_Client=CL.Client_ID)" +
                " GROUP BY CL.Nume+' '+CL.Prenume ORDER BY nr DESC;", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataChart.Series["Client"].Points.AddXY(reader[0].ToString(), reader.GetInt32(1));
                }
                reader.Close();
                ChangeColorButton(sender);
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }

        private void raportLinkLabel_LinkClicked(object sender, EventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart = (System.Windows.Forms.DataVisualization.Charting.Chart)FlowPannel.Controls["dataChart"];

            dataChart.Series.Clear();
            dataChart.Series.Add("Angajat");
            dataChart.Series.Add("Sala");

            SqlCommand cmd = new SqlCommand("SELECT S.Nume_sala,S.Pret_h,A.Nume+' '+A.Prenume," +
                " A.Salariu FROM Angajat A INNER JOIN Sala S" +
                " ON(A.Angajat_ID=S.ID_Angajat);", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataChart.Series["Sala"].Points.AddXY(reader[0].ToString(), reader.GetInt32(1));
                    dataChart.Series["Angajat"].Points.AddXY(reader[2].ToString(), reader.GetInt32(3));
                }
                reader.Close();
                ChangeColorButton(sender);
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        } //JOIN

        private void clie3LinkLabel_LinkClicked(object sender, EventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart dataChart = (System.Windows.Forms.DataVisualization.Charting.Chart)FlowPannel.Controls["dataChart"];

            dataChart.Series.Clear();
            dataChart.Series.Add("Client");

            SqlCommand cmd = new SqlCommand("SELECT CL.Mail, SUM(C.Pret) FROM Conferinte C" +
                " INNER JOIN Client CL ON(C.ID_Client=CL.Client_ID) GROUP BY CL.Mail" +
                " HAVING SUM(C.Pret) > (SELECT AVG(CO.Pret) " +
                "FROM Conferinte CO);", connection);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dataChart.Series["Client"].Points.AddXY(reader[0].ToString(), reader.GetInt32(1));
                }
                reader.Close();
                ChangeColorButton(sender);
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        } //JOIN

        private void ChangeColorButton(object sender)
        {
            FlowPannel.Controls["regionButton"].Controls["alsButton"].BackColor = Color.Transparent;
            FlowPannel.Controls["regionButton"].Controls["cmvfcButton"].BackColor = Color.Transparent;
            FlowPannel.Controls["regionButton"].Controls["cmcsButton"].BackColor = Color.Transparent;
            FlowPannel.Controls["regionButton"].Controls["ocButton"].BackColor = Color.Transparent;
            FlowPannel.Controls["regionButton"].Controls["cmfcButton"].BackColor = Color.Transparent;
            FlowPannel.Controls["regionButton"].Controls["cdssButton"].BackColor = Color.Transparent;
            FlowPannel.Controls["regionButton"].Controls["rasButton"].BackColor = Color.Transparent;

            Button tempBtn = (Button)sender;
            tempBtn.BackColor = Color.DarkGreen;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void CheckUnicity(object sender, EventArgs e)
        {
            TextBox tempTextBox = (TextBox)sender;

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM " + tableUni +
                " WHERE "+ tempTextBox.Tag +"=@colUni;", connection);
            try
            {
                cmd.Parameters.AddWithValue("colUni", tempTextBox.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if(reader.GetInt32(0) == 0 || tempTextBox.Text.Equals(prevUniVal))
                {
                    readyToSave = true;
                    tempTextBox.BackColor = Color.LimeGreen;
                }
                else
                {
                    readyToSave = false;
                    tempTextBox.BackColor = Color.Tomato;
                }
                reader.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show("SQL Server retruned: " + er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Program returned: " + ex.Message);
            }
        }
    }
}
