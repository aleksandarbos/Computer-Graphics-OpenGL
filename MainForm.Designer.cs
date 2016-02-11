namespace RacunarskaGrafika.Vezbe.AssimpNetSample
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
            this.m_world.Dispose();
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
            this.openglControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl
            // 
            this.openglControl.AccumBits = ((byte)(0));
            this.openglControl.AutoCheckErrors = false;
            this.openglControl.AutoFinish = false;
            this.openglControl.AutoMakeCurrent = true;
            this.openglControl.AutoSwapBuffers = true;
            this.openglControl.BackColor = System.Drawing.Color.Black;
            this.openglControl.ColorBits = ((byte)(32));
            this.openglControl.DepthBits = ((byte)(16));
            this.openglControl.Location = new System.Drawing.Point(0, 0);
            this.openglControl.Name = "openglControl";
            this.openglControl.Size = new System.Drawing.Size(713, 531);
            this.openglControl.StencilBits = ((byte)(0));
            this.openglControl.TabIndex = 1;
            this.openglControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlPaint);
            this.openglControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenGlControlKeyDown);
            this.openglControl.Resize += new System.EventHandler(this.OpenGlControlResize);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open/Close door";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(193, 10);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 84);
            this.panel1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(549, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "RESET";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown7);
            this.groupBox3.Controls.Add(this.numericUpDown8);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(549, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 59);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ballon attributes:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Scale:";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(85, 12);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown7.TabIndex = 15;
            this.numericUpDown7.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown7.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(85, 35);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown8.TabIndex = 17;
            this.numericUpDown8.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown8.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Rotation speed:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 81);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animations";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Play animation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.numericUpDown9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown10);
            this.groupBox1.Controls.Add(this.numericUpDown3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown11);
            this.groupBox1.Controls.Add(this.numericUpDown6);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDown5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDown4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(137, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 81);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sun X:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Green Z:";
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown9.Location = new System.Drawing.Point(330, 55);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown9.TabIndex = 23;
            this.numericUpDown9.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown9.ValueChanged += new System.EventHandler(this.numericUpDown9_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sun Y:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Green X:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(63, 10);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown10.Location = new System.Drawing.Point(63, 56);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown10.TabIndex = 21;
            this.numericUpDown10.ValueChanged += new System.EventHandler(this.numericUpDown10_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(330, 9);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown3.TabIndex = 7;
            this.numericUpDown3.Value = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(138, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Green Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sun Z:";
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown11.Location = new System.Drawing.Point(193, 56);
            this.numericUpDown11.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown11.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown11.TabIndex = 19;
            this.numericUpDown11.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown11.ValueChanged += new System.EventHandler(this.numericUpDown11_ValueChanged);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(193, 33);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown6.TabIndex = 9;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Balloon Y:";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(63, 33);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown5.TabIndex = 11;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Balloon X:";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(330, 32);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown4.TabIndex = 13;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Balloon Z:";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 30;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openglControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Graphics Final Project 2016 - Aleksandar Bosnjak RA-92/2012";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openglControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer3;
    }
}

