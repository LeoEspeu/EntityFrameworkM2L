namespace EntityFrameworkM2L
{
    partial class FrmPrincipale
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipale));
            this.GrpIdentite = new System.Windows.Forms.GroupBox();
            this.TxtMail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TxtVille = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.TxtCp = new System.Windows.Forms.MaskedTextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.TxtAdr2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TxtAdr1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.TxtPrenom = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.TxtNom = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.GrpLicencie = new System.Windows.Forms.GroupBox();
            this.BtnEnregistrerLicencie = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TxtMontantCheque2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TxtNumeroCheque2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TxtNumeroCheque = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.TxtMontantCheque = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CmbQualiteLicenciee = new System.Windows.Forms.ComboBox();
            this.Qualité = new System.Windows.Forms.Label();
            this.GrpRepasAccompagnant = new System.Windows.Forms.GroupBox();
            this.RdbAccompagnantLicencieNon = new MaterialSkin.Controls.MaterialRadioButton();
            this.RdbAccompagnantLicencieOui = new MaterialSkin.Controls.MaterialRadioButton();
            this.PanRepasLicencie = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MskLicenceLicencie = new System.Windows.Forms.MaskedTextBox();
            this.GrpNuiteLicencie = new System.Windows.Forms.GroupBox();
            this.RdbNuiteLicencieNon = new MaterialSkin.Controls.MaterialRadioButton();
            this.RdbNuiteLicencieOui = new MaterialSkin.Controls.MaterialRadioButton();
            this.PanNuiteeLicencie = new System.Windows.Forms.Panel();
            this.PicAffiche = new System.Windows.Forms.PictureBox();
            this.BtnQuitter = new MaterialSkin.Controls.MaterialRaisedButton();
            this.LsbAtelierLicencie = new System.Windows.Forms.ListBox();
            this.GrpIdentite.SuspendLayout();
            this.GrpLicencie.SuspendLayout();
            this.GrpRepasAccompagnant.SuspendLayout();
            this.GrpNuiteLicencie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAffiche)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpIdentite
            // 
            this.GrpIdentite.Controls.Add(this.TxtMail);
            this.GrpIdentite.Controls.Add(this.TxtVille);
            this.GrpIdentite.Controls.Add(this.materialLabel7);
            this.GrpIdentite.Controls.Add(this.materialLabel6);
            this.GrpIdentite.Controls.Add(this.materialLabel5);
            this.GrpIdentite.Controls.Add(this.txtTel);
            this.GrpIdentite.Controls.Add(this.TxtCp);
            this.GrpIdentite.Controls.Add(this.materialLabel4);
            this.GrpIdentite.Controls.Add(this.TxtAdr2);
            this.GrpIdentite.Controls.Add(this.TxtAdr1);
            this.GrpIdentite.Controls.Add(this.materialLabel3);
            this.GrpIdentite.Controls.Add(this.TxtPrenom);
            this.GrpIdentite.Controls.Add(this.materialLabel2);
            this.GrpIdentite.Controls.Add(this.TxtNom);
            this.GrpIdentite.Controls.Add(this.materialLabel1);
            this.GrpIdentite.Location = new System.Drawing.Point(24, 78);
            this.GrpIdentite.Name = "GrpIdentite";
            this.GrpIdentite.Size = new System.Drawing.Size(431, 217);
            this.GrpIdentite.TabIndex = 0;
            this.GrpIdentite.TabStop = false;
            this.GrpIdentite.Text = "Identité";
            // 
            // TxtMail
            // 
            this.TxtMail.Depth = 0;
            this.TxtMail.Hint = "";
            this.TxtMail.Location = new System.Drawing.Point(271, 162);
            this.TxtMail.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.PasswordChar = '\0';
            this.TxtMail.SelectedText = "";
            this.TxtMail.SelectionLength = 0;
            this.TxtMail.SelectionStart = 0;
            this.TxtMail.Size = new System.Drawing.Size(154, 23);
            this.TxtMail.TabIndex = 22;
            this.TxtMail.Text = "leo.espeu@gmail.com";
            this.TxtMail.UseSystemPasswordChar = false;
            // 
            // TxtVille
            // 
            this.TxtVille.Depth = 0;
            this.TxtVille.Hint = "";
            this.TxtVille.Location = new System.Drawing.Point(271, 123);
            this.TxtVille.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtVille.Name = "TxtVille";
            this.TxtVille.PasswordChar = '\0';
            this.TxtVille.SelectedText = "";
            this.TxtVille.SelectionLength = 0;
            this.TxtVille.SelectionStart = 0;
            this.TxtVille.Size = new System.Drawing.Size(154, 23);
            this.TxtVille.TabIndex = 20;
            this.TxtVille.Text = "Toulon";
            this.TxtVille.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(218, 165);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(46, 19);
            this.materialLabel7.TabIndex = 17;
            this.materialLabel7.Text = "Mail :";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(218, 129);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(47, 19);
            this.materialLabel6.TabIndex = 16;
            this.materialLabel6.Text = "Ville :";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(16, 165);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(38, 19);
            this.materialLabel5.TabIndex = 15;
            this.materialLabel5.Text = "Tél :";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(99, 166);
            this.txtTel.Mask = "00 00 00 00 00";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 14;
            this.txtTel.Text = "6666666666";
            // 
            // TxtCp
            // 
            this.TxtCp.Location = new System.Drawing.Point(99, 126);
            this.TxtCp.Mask = "00000";
            this.TxtCp.Name = "TxtCp";
            this.TxtCp.Size = new System.Drawing.Size(90, 20);
            this.TxtCp.TabIndex = 13;
            this.TxtCp.Text = "83000";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(17, 125);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(36, 19);
            this.materialLabel4.TabIndex = 7;
            this.materialLabel4.Text = "CP :";
            // 
            // TxtAdr2
            // 
            this.TxtAdr2.Depth = 0;
            this.TxtAdr2.Hint = "";
            this.TxtAdr2.Location = new System.Drawing.Point(99, 87);
            this.TxtAdr2.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtAdr2.Name = "TxtAdr2";
            this.TxtAdr2.PasswordChar = '\0';
            this.TxtAdr2.SelectedText = "";
            this.TxtAdr2.SelectionLength = 0;
            this.TxtAdr2.SelectionStart = 0;
            this.TxtAdr2.Size = new System.Drawing.Size(326, 23);
            this.TxtAdr2.TabIndex = 6;
            this.TxtAdr2.UseSystemPasswordChar = false;
            // 
            // TxtAdr1
            // 
            this.TxtAdr1.Depth = 0;
            this.TxtAdr1.Hint = "";
            this.TxtAdr1.Location = new System.Drawing.Point(99, 49);
            this.TxtAdr1.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtAdr1.Name = "TxtAdr1";
            this.TxtAdr1.PasswordChar = '\0';
            this.TxtAdr1.SelectedText = "";
            this.TxtAdr1.SelectionLength = 0;
            this.TxtAdr1.SelectionStart = 0;
            this.TxtAdr1.Size = new System.Drawing.Size(326, 23);
            this.TxtAdr1.TabIndex = 5;
            this.TxtAdr1.Text = "34 rue du plsql";
            this.TxtAdr1.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(15, 49);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(72, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Adresse :";
            // 
            // TxtPrenom
            // 
            this.TxtPrenom.Depth = 0;
            this.TxtPrenom.Hint = "";
            this.TxtPrenom.Location = new System.Drawing.Point(297, 19);
            this.TxtPrenom.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtPrenom.Name = "TxtPrenom";
            this.TxtPrenom.PasswordChar = '\0';
            this.TxtPrenom.SelectedText = "";
            this.TxtPrenom.SelectionLength = 0;
            this.TxtPrenom.SelectionStart = 0;
            this.TxtPrenom.Size = new System.Drawing.Size(128, 23);
            this.TxtPrenom.TabIndex = 3;
            this.TxtPrenom.Text = "léo";
            this.TxtPrenom.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(214, 20);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(69, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Prénom :";
            // 
            // TxtNom
            // 
            this.TxtNom.Depth = 0;
            this.TxtNom.Hint = "";
            this.TxtNom.Location = new System.Drawing.Point(79, 19);
            this.TxtNom.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.PasswordChar = '\0';
            this.TxtNom.SelectedText = "";
            this.TxtNom.SelectionLength = 0;
            this.TxtNom.SelectionStart = 0;
            this.TxtNom.Size = new System.Drawing.Size(128, 23);
            this.TxtNom.TabIndex = 1;
            this.TxtNom.Text = "espeu";
            this.TxtNom.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(16, 20);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(50, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Nom :";
            // 
            // GrpLicencie
            // 
            this.GrpLicencie.Controls.Add(this.LsbAtelierLicencie);
            this.GrpLicencie.Controls.Add(this.BtnEnregistrerLicencie);
            this.GrpLicencie.Controls.Add(this.TxtMontantCheque2);
            this.GrpLicencie.Controls.Add(this.TxtNumeroCheque2);
            this.GrpLicencie.Controls.Add(this.TxtNumeroCheque);
            this.GrpLicencie.Controls.Add(this.TxtMontantCheque);
            this.GrpLicencie.Controls.Add(this.label15);
            this.GrpLicencie.Controls.Add(this.label14);
            this.GrpLicencie.Controls.Add(this.label13);
            this.GrpLicencie.Controls.Add(this.CmbQualiteLicenciee);
            this.GrpLicencie.Controls.Add(this.Qualité);
            this.GrpLicencie.Controls.Add(this.GrpRepasAccompagnant);
            this.GrpLicencie.Controls.Add(this.label12);
            this.GrpLicencie.Controls.Add(this.label11);
            this.GrpLicencie.Controls.Add(this.label10);
            this.GrpLicencie.Controls.Add(this.MskLicenceLicencie);
            this.GrpLicencie.Controls.Add(this.GrpNuiteLicencie);
            this.GrpLicencie.Location = new System.Drawing.Point(24, 322);
            this.GrpLicencie.Name = "GrpLicencie";
            this.GrpLicencie.Size = new System.Drawing.Size(788, 391);
            this.GrpLicencie.TabIndex = 27;
            this.GrpLicencie.TabStop = false;
            this.GrpLicencie.Text = "Complément Inscription Licencie";
            // 
            // BtnEnregistrerLicencie
            // 
            this.BtnEnregistrerLicencie.Depth = 0;
            this.BtnEnregistrerLicencie.Location = new System.Drawing.Point(570, 284);
            this.BtnEnregistrerLicencie.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnEnregistrerLicencie.Name = "BtnEnregistrerLicencie";
            this.BtnEnregistrerLicencie.Primary = true;
            this.BtnEnregistrerLicencie.Size = new System.Drawing.Size(138, 40);
            this.BtnEnregistrerLicencie.TabIndex = 54;
            this.BtnEnregistrerLicencie.Text = "Enregistrer";
            this.BtnEnregistrerLicencie.UseVisualStyleBackColor = true;
            this.BtnEnregistrerLicencie.Click += new System.EventHandler(this.BtnEnregistrerLicencie_Click);
            // 
            // TxtMontantCheque2
            // 
            this.TxtMontantCheque2.Depth = 0;
            this.TxtMontantCheque2.Hint = "";
            this.TxtMontantCheque2.Location = new System.Drawing.Point(570, 239);
            this.TxtMontantCheque2.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtMontantCheque2.Name = "TxtMontantCheque2";
            this.TxtMontantCheque2.PasswordChar = '\0';
            this.TxtMontantCheque2.SelectedText = "";
            this.TxtMontantCheque2.SelectionLength = 0;
            this.TxtMontantCheque2.SelectionStart = 0;
            this.TxtMontantCheque2.Size = new System.Drawing.Size(115, 23);
            this.TxtMontantCheque2.TabIndex = 53;
            this.TxtMontantCheque2.Text = "111";
            this.TxtMontantCheque2.UseSystemPasswordChar = false;
            // 
            // TxtNumeroCheque2
            // 
            this.TxtNumeroCheque2.Depth = 0;
            this.TxtNumeroCheque2.Hint = "";
            this.TxtNumeroCheque2.Location = new System.Drawing.Point(570, 172);
            this.TxtNumeroCheque2.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtNumeroCheque2.Name = "TxtNumeroCheque2";
            this.TxtNumeroCheque2.PasswordChar = '\0';
            this.TxtNumeroCheque2.SelectedText = "";
            this.TxtNumeroCheque2.SelectionLength = 0;
            this.TxtNumeroCheque2.SelectionStart = 0;
            this.TxtNumeroCheque2.Size = new System.Drawing.Size(115, 23);
            this.TxtNumeroCheque2.TabIndex = 52;
            this.TxtNumeroCheque2.Text = "111";
            this.TxtNumeroCheque2.UseSystemPasswordChar = false;
            // 
            // TxtNumeroCheque
            // 
            this.TxtNumeroCheque.Depth = 0;
            this.TxtNumeroCheque.Hint = "";
            this.TxtNumeroCheque.Location = new System.Drawing.Point(309, 29);
            this.TxtNumeroCheque.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtNumeroCheque.Name = "TxtNumeroCheque";
            this.TxtNumeroCheque.PasswordChar = '\0';
            this.TxtNumeroCheque.SelectedText = "";
            this.TxtNumeroCheque.SelectionLength = 0;
            this.TxtNumeroCheque.SelectionStart = 0;
            this.TxtNumeroCheque.Size = new System.Drawing.Size(100, 23);
            this.TxtNumeroCheque.TabIndex = 51;
            this.TxtNumeroCheque.Text = "111";
            this.TxtNumeroCheque.UseSystemPasswordChar = false;
            // 
            // TxtMontantCheque
            // 
            this.TxtMontantCheque.Depth = 0;
            this.TxtMontantCheque.Hint = "";
            this.TxtMontantCheque.Location = new System.Drawing.Point(187, 29);
            this.TxtMontantCheque.MouseState = MaterialSkin.MouseState.HOVER;
            this.TxtMontantCheque.Name = "TxtMontantCheque";
            this.TxtMontantCheque.PasswordChar = '\0';
            this.TxtMontantCheque.SelectedText = "";
            this.TxtMontantCheque.SelectionLength = 0;
            this.TxtMontantCheque.SelectionStart = 0;
            this.TxtMontantCheque.Size = new System.Drawing.Size(113, 23);
            this.TxtMontantCheque.TabIndex = 50;
            this.TxtMontantCheque.Text = "120";
            this.TxtMontantCheque.UseSystemPasswordChar = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(567, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 48;
            this.label15.Text = "Montant chèque 2:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(306, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Numéro chèque :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(567, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(215, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Numéro chèque 2 accompagnant(facultatif):";
            // 
            // CmbQualiteLicenciee
            // 
            this.CmbQualiteLicenciee.FormattingEnabled = true;
            this.CmbQualiteLicenciee.Location = new System.Drawing.Point(415, 31);
            this.CmbQualiteLicenciee.Name = "CmbQualiteLicenciee";
            this.CmbQualiteLicenciee.Size = new System.Drawing.Size(121, 21);
            this.CmbQualiteLicenciee.TabIndex = 44;
            // 
            // Qualité
            // 
            this.Qualité.AutoSize = true;
            this.Qualité.Location = new System.Drawing.Point(420, 16);
            this.Qualité.Name = "Qualité";
            this.Qualité.Size = new System.Drawing.Size(46, 13);
            this.Qualité.TabIndex = 41;
            this.Qualité.Text = "Qualité :";
            // 
            // GrpRepasAccompagnant
            // 
            this.GrpRepasAccompagnant.Controls.Add(this.RdbAccompagnantLicencieNon);
            this.GrpRepasAccompagnant.Controls.Add(this.RdbAccompagnantLicencieOui);
            this.GrpRepasAccompagnant.Controls.Add(this.PanRepasLicencie);
            this.GrpRepasAccompagnant.Location = new System.Drawing.Point(9, 60);
            this.GrpRepasAccompagnant.Name = "GrpRepasAccompagnant";
            this.GrpRepasAccompagnant.Size = new System.Drawing.Size(507, 114);
            this.GrpRepasAccompagnant.TabIndex = 37;
            this.GrpRepasAccompagnant.TabStop = false;
            this.GrpRepasAccompagnant.Text = "Repas accompagnant";
            // 
            // RdbAccompagnantLicencieNon
            // 
            this.RdbAccompagnantLicencieNon.AutoSize = true;
            this.RdbAccompagnantLicencieNon.Checked = true;
            this.RdbAccompagnantLicencieNon.Depth = 0;
            this.RdbAccompagnantLicencieNon.Font = new System.Drawing.Font("Roboto", 10F);
            this.RdbAccompagnantLicencieNon.Location = new System.Drawing.Point(12, 52);
            this.RdbAccompagnantLicencieNon.Margin = new System.Windows.Forms.Padding(0);
            this.RdbAccompagnantLicencieNon.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RdbAccompagnantLicencieNon.MouseState = MaterialSkin.MouseState.HOVER;
            this.RdbAccompagnantLicencieNon.Name = "RdbAccompagnantLicencieNon";
            this.RdbAccompagnantLicencieNon.Ripple = true;
            this.RdbAccompagnantLicencieNon.Size = new System.Drawing.Size(54, 30);
            this.RdbAccompagnantLicencieNon.TabIndex = 26;
            this.RdbAccompagnantLicencieNon.TabStop = true;
            this.RdbAccompagnantLicencieNon.Text = "Non";
            this.RdbAccompagnantLicencieNon.UseVisualStyleBackColor = true;
            this.RdbAccompagnantLicencieNon.CheckedChanged += new System.EventHandler(this.RdbRepasLicencie_CheckedChanged);
            // 
            // RdbAccompagnantLicencieOui
            // 
            this.RdbAccompagnantLicencieOui.AutoSize = true;
            this.RdbAccompagnantLicencieOui.Depth = 0;
            this.RdbAccompagnantLicencieOui.Font = new System.Drawing.Font("Roboto", 10F);
            this.RdbAccompagnantLicencieOui.Location = new System.Drawing.Point(12, 16);
            this.RdbAccompagnantLicencieOui.Margin = new System.Windows.Forms.Padding(0);
            this.RdbAccompagnantLicencieOui.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RdbAccompagnantLicencieOui.MouseState = MaterialSkin.MouseState.HOVER;
            this.RdbAccompagnantLicencieOui.Name = "RdbAccompagnantLicencieOui";
            this.RdbAccompagnantLicencieOui.Ripple = true;
            this.RdbAccompagnantLicencieOui.Size = new System.Drawing.Size(50, 30);
            this.RdbAccompagnantLicencieOui.TabIndex = 25;
            this.RdbAccompagnantLicencieOui.Text = "Oui";
            this.RdbAccompagnantLicencieOui.UseVisualStyleBackColor = true;
            this.RdbAccompagnantLicencieOui.CheckedChanged += new System.EventHandler(this.RdbRepasLicencie_CheckedChanged);
            // 
            // PanRepasLicencie
            // 
            this.PanRepasLicencie.Location = new System.Drawing.Point(89, 11);
            this.PanRepasLicencie.Name = "PanRepasLicencie";
            this.PanRepasLicencie.Size = new System.Drawing.Size(411, 97);
            this.PanRepasLicencie.TabIndex = 0;
            this.PanRepasLicencie.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Montant chèque :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(553, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Atelier : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Numéro de licence : ";
            // 
            // MskLicenceLicencie
            // 
            this.MskLicenceLicencie.Location = new System.Drawing.Point(21, 33);
            this.MskLicenceLicencie.Mask = "000000000000";
            this.MskLicenceLicencie.Name = "MskLicenceLicencie";
            this.MskLicenceLicencie.Size = new System.Drawing.Size(147, 20);
            this.MskLicenceLicencie.TabIndex = 31;
            this.MskLicenceLicencie.Text = "111111111111";
            // 
            // GrpNuiteLicencie
            // 
            this.GrpNuiteLicencie.Controls.Add(this.RdbNuiteLicencieNon);
            this.GrpNuiteLicencie.Controls.Add(this.RdbNuiteLicencieOui);
            this.GrpNuiteLicencie.Controls.Add(this.PanNuiteeLicencie);
            this.GrpNuiteLicencie.Location = new System.Drawing.Point(9, 180);
            this.GrpNuiteLicencie.Name = "GrpNuiteLicencie";
            this.GrpNuiteLicencie.Size = new System.Drawing.Size(507, 199);
            this.GrpNuiteLicencie.TabIndex = 30;
            this.GrpNuiteLicencie.TabStop = false;
            this.GrpNuiteLicencie.Text = "Nuités";
            // 
            // RdbNuiteLicencieNon
            // 
            this.RdbNuiteLicencieNon.AutoSize = true;
            this.RdbNuiteLicencieNon.Checked = true;
            this.RdbNuiteLicencieNon.Depth = 0;
            this.RdbNuiteLicencieNon.Font = new System.Drawing.Font("Roboto", 10F);
            this.RdbNuiteLicencieNon.Location = new System.Drawing.Point(89, 16);
            this.RdbNuiteLicencieNon.Margin = new System.Windows.Forms.Padding(0);
            this.RdbNuiteLicencieNon.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RdbNuiteLicencieNon.MouseState = MaterialSkin.MouseState.HOVER;
            this.RdbNuiteLicencieNon.Name = "RdbNuiteLicencieNon";
            this.RdbNuiteLicencieNon.Ripple = true;
            this.RdbNuiteLicencieNon.Size = new System.Drawing.Size(54, 30);
            this.RdbNuiteLicencieNon.TabIndex = 26;
            this.RdbNuiteLicencieNon.TabStop = true;
            this.RdbNuiteLicencieNon.Text = "Non";
            this.RdbNuiteLicencieNon.UseVisualStyleBackColor = true;
            this.RdbNuiteLicencieNon.CheckedChanged += new System.EventHandler(this.RdbNuiteLicencie_CheckedChanged);
            // 
            // RdbNuiteLicencieOui
            // 
            this.RdbNuiteLicencieOui.AutoSize = true;
            this.RdbNuiteLicencieOui.Depth = 0;
            this.RdbNuiteLicencieOui.Font = new System.Drawing.Font("Roboto", 10F);
            this.RdbNuiteLicencieOui.Location = new System.Drawing.Point(7, 17);
            this.RdbNuiteLicencieOui.Margin = new System.Windows.Forms.Padding(0);
            this.RdbNuiteLicencieOui.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RdbNuiteLicencieOui.MouseState = MaterialSkin.MouseState.HOVER;
            this.RdbNuiteLicencieOui.Name = "RdbNuiteLicencieOui";
            this.RdbNuiteLicencieOui.Ripple = true;
            this.RdbNuiteLicencieOui.Size = new System.Drawing.Size(50, 30);
            this.RdbNuiteLicencieOui.TabIndex = 25;
            this.RdbNuiteLicencieOui.Text = "Oui";
            this.RdbNuiteLicencieOui.UseVisualStyleBackColor = true;
            this.RdbNuiteLicencieOui.CheckedChanged += new System.EventHandler(this.RdbNuiteLicencie_CheckedChanged);
            // 
            // PanNuiteeLicencie
            // 
            this.PanNuiteeLicencie.Location = new System.Drawing.Point(6, 65);
            this.PanNuiteeLicencie.Name = "PanNuiteeLicencie";
            this.PanNuiteeLicencie.Size = new System.Drawing.Size(494, 128);
            this.PanNuiteeLicencie.TabIndex = 24;
            this.PanNuiteeLicencie.Visible = false;
            // 
            // PicAffiche
            // 
            this.PicAffiche.Image = global::EntityFrameworkM2L.Properties.Resources.affiche;
            this.PicAffiche.Location = new System.Drawing.Point(531, 78);
            this.PicAffiche.Name = "PicAffiche";
            this.PicAffiche.Size = new System.Drawing.Size(108, 164);
            this.PicAffiche.TabIndex = 28;
            this.PicAffiche.TabStop = false;
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Depth = 0;
            this.BtnQuitter.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnQuitter.Location = new System.Drawing.Point(531, 265);
            this.BtnQuitter.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Primary = true;
            this.BtnQuitter.Size = new System.Drawing.Size(138, 40);
            this.BtnQuitter.TabIndex = 29;
            this.BtnQuitter.Text = "Quitter";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // LsbAtelierLicencie
            // 
            this.LsbAtelierLicencie.FormattingEnabled = true;
            this.LsbAtelierLicencie.Location = new System.Drawing.Point(556, 31);
            this.LsbAtelierLicencie.Name = "LsbAtelierLicencie";
            this.LsbAtelierLicencie.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.LsbAtelierLicencie.Size = new System.Drawing.Size(140, 95);
            this.LsbAtelierLicencie.TabIndex = 55;
            // 
            // FrmPrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 718);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.PicAffiche);
            this.Controls.Add(this.GrpLicencie);
            this.Controls.Add(this.GrpIdentite);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipale";
            this.Text = "Maison des Ligues - Gestion Inscription licencié";
            this.GrpIdentite.ResumeLayout(false);
            this.GrpIdentite.PerformLayout();
            this.GrpLicencie.ResumeLayout(false);
            this.GrpLicencie.PerformLayout();
            this.GrpRepasAccompagnant.ResumeLayout(false);
            this.GrpRepasAccompagnant.PerformLayout();
            this.GrpNuiteLicencie.ResumeLayout(false);
            this.GrpNuiteLicencie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAffiche)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpIdentite;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtAdr2;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtAdr1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtPrenom;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtNom;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.MaskedTextBox TxtCp;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtMail;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtVille;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.GroupBox GrpLicencie;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CmbQualiteLicenciee;
        private System.Windows.Forms.Label Qualité;
        private System.Windows.Forms.GroupBox GrpRepasAccompagnant;
        private System.Windows.Forms.Panel PanRepasLicencie;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox MskLicenceLicencie;
        private System.Windows.Forms.GroupBox GrpNuiteLicencie;
        private System.Windows.Forms.Panel PanNuiteeLicencie;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtNumeroCheque;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtMontantCheque;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtMontantCheque2;
        private MaterialSkin.Controls.MaterialSingleLineTextField TxtNumeroCheque2;
        private System.Windows.Forms.PictureBox PicAffiche;
        private MaterialSkin.Controls.MaterialRaisedButton BtnEnregistrerLicencie;
        private MaterialSkin.Controls.MaterialRaisedButton BtnQuitter;
        private MaterialSkin.Controls.MaterialRadioButton RdbAccompagnantLicencieNon;
        private MaterialSkin.Controls.MaterialRadioButton RdbAccompagnantLicencieOui;
        private MaterialSkin.Controls.MaterialRadioButton RdbNuiteLicencieNon;
        private MaterialSkin.Controls.MaterialRadioButton RdbNuiteLicencieOui;
        private System.Windows.Forms.ListBox LsbAtelierLicencie;
    }
}

