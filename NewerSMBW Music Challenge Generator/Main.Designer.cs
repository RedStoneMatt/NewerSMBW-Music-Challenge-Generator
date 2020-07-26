using System;
using System.Windows.Forms;

namespace NewerSMBW_Music_Challenge_Generator
{
    partial class Main
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
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 60; // in miliseconds
            timer1.Start();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.musicGroupBox = new System.Windows.Forms.GroupBox();
            this.musicListBox = new System.Windows.Forms.ListBox();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.noteGroupBox = new System.Windows.Forms.GroupBox();
            this.infoButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.timingLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.sfxComboBox = new System.Windows.Forms.ComboBox();
            this.sfxLabel = new System.Windows.Forms.Label();
            this.timingNumBox = new System.Windows.Forms.NumericUpDown();
            this.blockLabel = new System.Windows.Forms.Label();
            this.blockNumBox = new System.Windows.Forms.NumericUpDown();
            this.noteComboBox = new System.Windows.Forms.ComboBox();
            this.sequenceComboBox = new System.Windows.Forms.ComboBox();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.difficultyNumBox = new System.Windows.Forms.NumericUpDown();
            this.tempoLabel = new System.Windows.Forms.Label();
            this.idNumBox = new System.Windows.Forms.NumericUpDown();
            this.tempoNumBox = new System.Windows.Forms.NumericUpDown();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.songButton = new System.Windows.Forms.Button();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.redBlock = new System.Windows.Forms.PictureBox();
            this.orangeBlock = new System.Windows.Forms.PictureBox();
            this.yellowBlock = new System.Windows.Forms.PictureBox();
            this.greenBlock = new System.Windows.Forms.PictureBox();
            this.purpleBlock = new System.Windows.Forms.PictureBox();
            this.cyanBlock = new System.Windows.Forms.PictureBox();
            this.blueBlock = new System.Windows.Forms.PictureBox();
            this.redNote = new System.Windows.Forms.ComboBox();
            this.orangeNote = new System.Windows.Forms.ComboBox();
            this.yellowNote = new System.Windows.Forms.ComboBox();
            this.greenNote = new System.Windows.Forms.ComboBox();
            this.blueNote = new System.Windows.Forms.ComboBox();
            this.cyanNote = new System.Windows.Forms.ComboBox();
            this.purpleNote = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.musicGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.noteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timingNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempoNumBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangeBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purpleBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBlock)).BeginInit();
            this.SuspendLayout();
            // 
            // musicGroupBox
            // 
            this.musicGroupBox.Controls.Add(this.musicListBox);
            this.musicGroupBox.Location = new System.Drawing.Point(12, 27);
            this.musicGroupBox.Name = "musicGroupBox";
            this.musicGroupBox.Size = new System.Drawing.Size(239, 522);
            this.musicGroupBox.TabIndex = 0;
            this.musicGroupBox.TabStop = false;
            this.musicGroupBox.Text = "Music List";
            // 
            // musicListBox
            // 
            this.musicListBox.FormattingEnabled = true;
            this.musicListBox.Location = new System.Drawing.Point(7, 20);
            this.musicListBox.Name = "musicListBox";
            this.musicListBox.Size = new System.Drawing.Size(226, 511);
            this.musicListBox.TabIndex = 0;
            this.musicListBox.SelectedIndexChanged += new System.EventHandler(this.musicListBox_SelectedIndexChanged);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.noteGroupBox);
            this.settingsGroupBox.Controls.Add(this.difficultyLabel);
            this.settingsGroupBox.Controls.Add(this.difficultyNumBox);
            this.settingsGroupBox.Controls.Add(this.tempoLabel);
            this.settingsGroupBox.Controls.Add(this.idNumBox);
            this.settingsGroupBox.Controls.Add(this.tempoNumBox);
            this.settingsGroupBox.Controls.Add(this.nameTextBox);
            this.settingsGroupBox.Controls.Add(this.nameLabel);
            this.settingsGroupBox.Controls.Add(this.idLabel);
            this.settingsGroupBox.Location = new System.Drawing.Point(814, 27);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(273, 522);
            this.settingsGroupBox.TabIndex = 1;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // noteGroupBox
            // 
            this.noteGroupBox.Controls.Add(this.infoButton);
            this.noteGroupBox.Controls.Add(this.addButton);
            this.noteGroupBox.Controls.Add(this.timingLabel);
            this.noteGroupBox.Controls.Add(this.removeButton);
            this.noteGroupBox.Controls.Add(this.sfxComboBox);
            this.noteGroupBox.Controls.Add(this.sfxLabel);
            this.noteGroupBox.Controls.Add(this.timingNumBox);
            this.noteGroupBox.Controls.Add(this.blockLabel);
            this.noteGroupBox.Controls.Add(this.blockNumBox);
            this.noteGroupBox.Controls.Add(this.noteComboBox);
            this.noteGroupBox.Controls.Add(this.sequenceComboBox);
            this.noteGroupBox.Location = new System.Drawing.Point(7, 125);
            this.noteGroupBox.Name = "noteGroupBox";
            this.noteGroupBox.Size = new System.Drawing.Size(260, 391);
            this.noteGroupBox.TabIndex = 5;
            this.noteGroupBox.TabStop = false;
            this.noteGroupBox.Text = "Notes";
            // 
            // infoButton
            // 
            this.infoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("infoButton.BackgroundImage")));
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.infoButton.Location = new System.Drawing.Point(3, 125);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(26, 26);
            this.infoButton.TabIndex = 29;
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(35, 46);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 23);
            this.addButton.TabIndex = 30;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // timingLabel
            // 
            this.timingLabel.AutoSize = true;
            this.timingLabel.Location = new System.Drawing.Point(27, 131);
            this.timingLabel.Name = "timingLabel";
            this.timingLabel.Size = new System.Drawing.Size(41, 13);
            this.timingLabel.TabIndex = 5;
            this.timingLabel.Text = "Timing:";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(6, 46);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 23);
            this.removeButton.TabIndex = 29;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // sfxComboBox
            // 
            this.sfxComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sfxComboBox.FormattingEnabled = true;
            this.sfxComboBox.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.sfxComboBox.Location = new System.Drawing.Point(74, 101);
            this.sfxComboBox.Name = "sfxComboBox";
            this.sfxComboBox.Size = new System.Drawing.Size(180, 21);
            this.sfxComboBox.TabIndex = 5;
            this.sfxComboBox.SelectedIndexChanged += new System.EventHandler(this.sfxComboBox_SelectedIndexChanged);
            // 
            // sfxLabel
            // 
            this.sfxLabel.AutoSize = true;
            this.sfxLabel.Location = new System.Drawing.Point(10, 105);
            this.sfxLabel.Name = "sfxLabel";
            this.sfxLabel.Size = new System.Drawing.Size(58, 13);
            this.sfxLabel.TabIndex = 4;
            this.sfxLabel.Text = "Note/SFX:";
            // 
            // timingNumBox
            // 
            this.timingNumBox.Location = new System.Drawing.Point(74, 128);
            this.timingNumBox.Name = "timingNumBox";
            this.timingNumBox.Size = new System.Drawing.Size(180, 20);
            this.timingNumBox.TabIndex = 4;
            this.timingNumBox.ValueChanged += new System.EventHandler(this.timingNumBox_ValueChanged);
            // 
            // blockLabel
            // 
            this.blockLabel.AutoSize = true;
            this.blockLabel.Location = new System.Drawing.Point(9, 78);
            this.blockLabel.Name = "blockLabel";
            this.blockLabel.Size = new System.Drawing.Size(59, 13);
            this.blockLabel.TabIndex = 3;
            this.blockLabel.Text = "Noteblock:";
            // 
            // blockNumBox
            // 
            this.blockNumBox.Location = new System.Drawing.Point(74, 74);
            this.blockNumBox.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.blockNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blockNumBox.Name = "blockNumBox";
            this.blockNumBox.Size = new System.Drawing.Size(180, 20);
            this.blockNumBox.TabIndex = 2;
            this.blockNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blockNumBox.ValueChanged += new System.EventHandler(this.blockNumBox_ValueChanged);
            // 
            // noteComboBox
            // 
            this.noteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noteComboBox.FormattingEnabled = true;
            this.noteComboBox.Location = new System.Drawing.Point(64, 47);
            this.noteComboBox.Name = "noteComboBox";
            this.noteComboBox.Size = new System.Drawing.Size(190, 21);
            this.noteComboBox.TabIndex = 1;
            this.noteComboBox.SelectedIndexChanged += new System.EventHandler(this.noteComboBox_SelectedIndexChanged);
            // 
            // sequenceComboBox
            // 
            this.sequenceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sequenceComboBox.FormattingEnabled = true;
            this.sequenceComboBox.Items.AddRange(new object[] {
            "Sequence 1",
            "Sequence 2",
            "Sequence 3",
            "Sequence 4"});
            this.sequenceComboBox.Location = new System.Drawing.Point(7, 20);
            this.sequenceComboBox.Name = "sequenceComboBox";
            this.sequenceComboBox.Size = new System.Drawing.Size(247, 21);
            this.sequenceComboBox.TabIndex = 0;
            this.sequenceComboBox.SelectedIndexChanged += new System.EventHandler(this.sequenceComboBox_SelectedIndexChanged);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(4, 102);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(50, 13);
            this.difficultyLabel.TabIndex = 3;
            this.difficultyLabel.Text = "Difficulty:";
            // 
            // difficultyNumBox
            // 
            this.difficultyNumBox.Location = new System.Drawing.Point(60, 99);
            this.difficultyNumBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.difficultyNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.difficultyNumBox.Name = "difficultyNumBox";
            this.difficultyNumBox.Size = new System.Drawing.Size(207, 20);
            this.difficultyNumBox.TabIndex = 4;
            this.difficultyNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.difficultyNumBox.ValueChanged += new System.EventHandler(this.difficultyNumBox_ValueChanged);
            // 
            // tempoLabel
            // 
            this.tempoLabel.AutoSize = true;
            this.tempoLabel.Location = new System.Drawing.Point(11, 76);
            this.tempoLabel.Name = "tempoLabel";
            this.tempoLabel.Size = new System.Drawing.Size(43, 13);
            this.tempoLabel.TabIndex = 2;
            this.tempoLabel.Text = "Tempo:";
            // 
            // idNumBox
            // 
            this.idNumBox.Location = new System.Drawing.Point(60, 19);
            this.idNumBox.Name = "idNumBox";
            this.idNumBox.Size = new System.Drawing.Size(207, 20);
            this.idNumBox.TabIndex = 2;
            this.idNumBox.ValueChanged += new System.EventHandler(this.idNumBox_ValueChanged);
            // 
            // tempoNumBox
            // 
            this.tempoNumBox.Location = new System.Drawing.Point(60, 73);
            this.tempoNumBox.Name = "tempoNumBox";
            this.tempoNumBox.Size = new System.Drawing.Size(207, 20);
            this.tempoNumBox.TabIndex = 3;
            this.tempoNumBox.ValueChanged += new System.EventHandler(this.tempoNumBox_ValueChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(60, 47);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(207, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(16, 50);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(33, 22);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 13);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openToolStripMenuItem.Text = "Open File...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.playButton.Location = new System.Drawing.Point(390, 38);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(276, 56);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play Sequence";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputTextBox.Location = new System.Drawing.Point(257, 432);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(538, 111);
            this.outputTextBox.TabIndex = 4;
            this.outputTextBox.Text = "";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(257, 416);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(33, 13);
            this.outputLabel.TabIndex = 5;
            this.outputLabel.Text = "Logs:";
            // 
            // songButton
            // 
            this.songButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.songButton.Location = new System.Drawing.Point(390, 100);
            this.songButton.Name = "songButton";
            this.songButton.Size = new System.Drawing.Size(276, 56);
            this.songButton.TabIndex = 6;
            this.songButton.Text = "Play Song";
            this.songButton.UseVisualStyleBackColor = true;
            this.songButton.Click += new System.EventHandler(this.songButton_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // redBlock
            // 
            this.redBlock.Image = ((System.Drawing.Image)(resources.GetObject("redBlock.Image")));
            this.redBlock.Location = new System.Drawing.Point(335, 193);
            this.redBlock.Name = "redBlock";
            this.redBlock.Size = new System.Drawing.Size(50, 50);
            this.redBlock.TabIndex = 7;
            this.redBlock.TabStop = false;
            this.redBlock.Click += new System.EventHandler(this.redBlock_Click);
            // 
            // orangeBlock
            // 
            this.orangeBlock.Image = ((System.Drawing.Image)(resources.GetObject("orangeBlock.Image")));
            this.orangeBlock.Location = new System.Drawing.Point(391, 193);
            this.orangeBlock.Name = "orangeBlock";
            this.orangeBlock.Size = new System.Drawing.Size(50, 50);
            this.orangeBlock.TabIndex = 9;
            this.orangeBlock.TabStop = false;
            this.orangeBlock.Click += new System.EventHandler(this.orangeBlock_Click);
            // 
            // yellowBlock
            // 
            this.yellowBlock.Image = ((System.Drawing.Image)(resources.GetObject("yellowBlock.Image")));
            this.yellowBlock.Location = new System.Drawing.Point(447, 193);
            this.yellowBlock.Name = "yellowBlock";
            this.yellowBlock.Size = new System.Drawing.Size(50, 50);
            this.yellowBlock.TabIndex = 11;
            this.yellowBlock.TabStop = false;
            this.yellowBlock.Click += new System.EventHandler(this.yellowBlock_Click);
            // 
            // greenBlock
            // 
            this.greenBlock.Image = ((System.Drawing.Image)(resources.GetObject("greenBlock.Image")));
            this.greenBlock.Location = new System.Drawing.Point(503, 193);
            this.greenBlock.Name = "greenBlock";
            this.greenBlock.Size = new System.Drawing.Size(50, 50);
            this.greenBlock.TabIndex = 13;
            this.greenBlock.TabStop = false;
            this.greenBlock.Click += new System.EventHandler(this.greenBlock_Click);
            // 
            // purpleBlock
            // 
            this.purpleBlock.Image = ((System.Drawing.Image)(resources.GetObject("purpleBlock.Image")));
            this.purpleBlock.Location = new System.Drawing.Point(671, 193);
            this.purpleBlock.Name = "purpleBlock";
            this.purpleBlock.Size = new System.Drawing.Size(50, 50);
            this.purpleBlock.TabIndex = 19;
            this.purpleBlock.TabStop = false;
            this.purpleBlock.Click += new System.EventHandler(this.purpleBlock_Click);
            // 
            // cyanBlock
            // 
            this.cyanBlock.Image = ((System.Drawing.Image)(resources.GetObject("cyanBlock.Image")));
            this.cyanBlock.Location = new System.Drawing.Point(615, 193);
            this.cyanBlock.Name = "cyanBlock";
            this.cyanBlock.Size = new System.Drawing.Size(50, 50);
            this.cyanBlock.TabIndex = 17;
            this.cyanBlock.TabStop = false;
            this.cyanBlock.Click += new System.EventHandler(this.cyanBlock_Click);
            // 
            // blueBlock
            // 
            this.blueBlock.Image = ((System.Drawing.Image)(resources.GetObject("blueBlock.Image")));
            this.blueBlock.Location = new System.Drawing.Point(559, 193);
            this.blueBlock.Name = "blueBlock";
            this.blueBlock.Size = new System.Drawing.Size(50, 50);
            this.blueBlock.TabIndex = 15;
            this.blueBlock.TabStop = false;
            this.blueBlock.Click += new System.EventHandler(this.blueBlock_Click);
            // 
            // redNote
            // 
            this.redNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.redNote.FormattingEnabled = true;
            this.redNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.redNote.Location = new System.Drawing.Point(335, 297);
            this.redNote.Name = "redNote";
            this.redNote.Size = new System.Drawing.Size(50, 21);
            this.redNote.TabIndex = 21;
            // 
            // orangeNote
            // 
            this.orangeNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orangeNote.FormattingEnabled = true;
            this.orangeNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.orangeNote.Location = new System.Drawing.Point(391, 297);
            this.orangeNote.Name = "orangeNote";
            this.orangeNote.Size = new System.Drawing.Size(50, 21);
            this.orangeNote.TabIndex = 22;
            // 
            // yellowNote
            // 
            this.yellowNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yellowNote.FormattingEnabled = true;
            this.yellowNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.yellowNote.Location = new System.Drawing.Point(447, 297);
            this.yellowNote.Name = "yellowNote";
            this.yellowNote.Size = new System.Drawing.Size(50, 21);
            this.yellowNote.TabIndex = 23;
            // 
            // greenNote
            // 
            this.greenNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.greenNote.FormattingEnabled = true;
            this.greenNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.greenNote.Location = new System.Drawing.Point(503, 297);
            this.greenNote.Name = "greenNote";
            this.greenNote.Size = new System.Drawing.Size(50, 21);
            this.greenNote.TabIndex = 24;
            // 
            // blueNote
            // 
            this.blueNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blueNote.FormattingEnabled = true;
            this.blueNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.blueNote.Location = new System.Drawing.Point(559, 297);
            this.blueNote.Name = "blueNote";
            this.blueNote.Size = new System.Drawing.Size(50, 21);
            this.blueNote.TabIndex = 25;
            // 
            // cyanNote
            // 
            this.cyanNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cyanNote.FormattingEnabled = true;
            this.cyanNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.cyanNote.Location = new System.Drawing.Point(616, 297);
            this.cyanNote.Name = "cyanNote";
            this.cyanNote.Size = new System.Drawing.Size(50, 21);
            this.cyanNote.TabIndex = 26;
            // 
            // purpleNote
            // 
            this.purpleNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.purpleNote.FormattingEnabled = true;
            this.purpleNote.Items.AddRange(new object[] {
            "3C",
            "3C#",
            "3D",
            "3D#",
            "3E",
            "3F",
            "3F#",
            "3G",
            "3G#",
            "3A",
            "3A#",
            "3B",
            "4C",
            "4C#",
            "4D",
            "4D#",
            "4E",
            "4F",
            "4F#",
            "4G",
            "4G#",
            "4A",
            "4A#",
            "4B"});
            this.purpleNote.Location = new System.Drawing.Point(672, 297);
            this.purpleNote.Name = "purpleNote";
            this.purpleNote.Size = new System.Drawing.Size(50, 21);
            this.purpleNote.TabIndex = 28;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 561);
            this.Controls.Add(this.purpleNote);
            this.Controls.Add(this.cyanNote);
            this.Controls.Add(this.blueNote);
            this.Controls.Add(this.greenNote);
            this.Controls.Add(this.yellowNote);
            this.Controls.Add(this.orangeNote);
            this.Controls.Add(this.redNote);
            this.Controls.Add(this.purpleBlock);
            this.Controls.Add(this.cyanBlock);
            this.Controls.Add(this.blueBlock);
            this.Controls.Add(this.greenBlock);
            this.Controls.Add(this.yellowBlock);
            this.Controls.Add(this.orangeBlock);
            this.Controls.Add(this.redBlock);
            this.Controls.Add(this.songButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.musicGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "NewerSMBW Music Challenge Generator";
            this.Load += new System.EventHandler(this.Main_Load);
            this.musicGroupBox.ResumeLayout(false);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.noteGroupBox.ResumeLayout(false);
            this.noteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timingNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempoNumBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangeBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yellowBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purpleBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cyanBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueBlock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox musicGroupBox;
        private System.Windows.Forms.ListBox musicListBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label tempoLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.NumericUpDown idNumBox;
        private System.Windows.Forms.NumericUpDown tempoNumBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.NumericUpDown difficultyNumBox;
        private System.Windows.Forms.GroupBox noteGroupBox;
        private System.Windows.Forms.ComboBox sequenceComboBox;
        private System.Windows.Forms.ComboBox noteComboBox;
        private System.Windows.Forms.ComboBox sfxComboBox;
        private System.Windows.Forms.NumericUpDown timingNumBox;
        private System.Windows.Forms.NumericUpDown blockNumBox;
        private System.Windows.Forms.Label timingLabel;
        private System.Windows.Forms.Label sfxLabel;
        private System.Windows.Forms.Label blockLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button songButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.PictureBox redBlock;
        private System.Windows.Forms.PictureBox orangeBlock;
        private System.Windows.Forms.PictureBox yellowBlock;
        private System.Windows.Forms.PictureBox greenBlock;
        private System.Windows.Forms.PictureBox purpleBlock;
        private System.Windows.Forms.PictureBox cyanBlock;
        private System.Windows.Forms.PictureBox blueBlock;
        private System.Windows.Forms.ComboBox redNote;
        private System.Windows.Forms.ComboBox orangeNote;
        private System.Windows.Forms.ComboBox yellowNote;
        private System.Windows.Forms.ComboBox greenNote;
        private System.Windows.Forms.ComboBox blueNote;
        private System.Windows.Forms.ComboBox cyanNote;
        private System.Windows.Forms.ComboBox purpleNote;
        private System.Windows.Forms.Timer timer1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button removeButton;
        private Button addButton;
        private Button infoButton;
    }
}

