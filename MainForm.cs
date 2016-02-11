// -----------------------------------------------------------------------
// <file>MainForm.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2013.</copyright>
// <author>Zoran Milicevic</author>
// <summary>Demonstracija ucitavanja modela pomocu AssimpNet biblioteke i koriscenja u OpenGL-u.</summary>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assimp;
using System.IO;
using System.Reflection;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    public partial class MainForm : Form
    {
        #region Atributi

        /// <summary>
        ///	 Instanca OpenGL "sveta" - klase koja je zaduzena za iscrtavanje koriscenjem OpenGL-a.
        /// </summary>
        World m_world = null;

        public static int BALOON_TYPE = 0;      // swtich balona

        #endregion Atributi

        #region Konstruktori

        public MainForm()
        {
            // Inicijalizacija komponenti
            InitializeComponent();

            // Inicijalizacija OpenGL konteksta
            openglControl.InitializeContexts();

            // Kreiranje OpenGL sveta
            // TODO 2.0: ucitavam model balona preko AssimNet biblioteke u klasu AssimpScene
            try
            {                                                                                                             // \\Balloon\\  "Balloon.3ds"
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "3D Models\\Balloon\\" + ((this.BALLON_TYPE == 0) ? "model\\OBJ\\" : "")), (this.BALLON_TYPE == 0) ? "Hot_Air_Balloon.obj" : "Balloon.3ds", openglControl.Width, openglControl.Height);
                m_world.Draw();
                initNumerics();
                timer1.Start();
            }
           
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta. Poruka greške: " + e.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void initNumerics()
        {
            numericUpDown1_ValueChanged(numericUpDown1, null);      // manually trigger event
            numericUpDown2_ValueChanged(numericUpDown2, null);      // manually trigger event
            numericUpDown3_ValueChanged(numericUpDown3, null);      // manually trigger event
            numericUpDown4_ValueChanged(numericUpDown4, null);      // manually trigger event
            numericUpDown5_ValueChanged(numericUpDown5, null);      // manually trigger event
            numericUpDown6_ValueChanged(numericUpDown6, null);      // manually trigger event
            numericUpDown7_ValueChanged(numericUpDown7, null);      // manually trigger event
            numericUpDown8_ValueChanged(numericUpDown8, null);      // manually trigger event
            numericUpDown9_ValueChanged(numericUpDown9, null);      // manually trigger event
            numericUpDown10_ValueChanged(numericUpDown10, null);      // manually trigger event
            numericUpDown11_ValueChanged(numericUpDown11, null);      // manually trigger event
        }

        ~MainForm() {
            m_world.Dispose();
            timer1.Dispose();
            timer2.Dispose();
            timer3.Dispose();
            openglControl.Dispose();
        }

        #endregion Konstruktori

        #region Rukovaoci dogadjajima OpenGL kontrole

        /// <summary>
        /// Rukovalac dogadja izmene dimenzija OpenGL kontrole
        /// </summary>
        private void OpenGlControlResize(object sender, EventArgs e)
        {
            m_world.Height = openglControl.Height;
            m_world.Width = openglControl.Width;

            m_world.Resize();
        }

        /// <summary>
        /// Rukovalac dogadjaja iscrtavanja OpenGL kontrole
        /// </summary>
        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            // Iscrtaj svet
            m_world.Draw();
        }


        public int BALLON_TYPE
        {
            get {return BALOON_TYPE; }
            set {BALOON_TYPE = value; }
        }

        /// <summary>
        /// Rukovalac dogadjaja: obrada tastera nad formom
        /// </summary>
        //TODO 5.0: Rotacija sveta, ogranicenja, priblizavanje, udaljavanje.
        private void OpenGlControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10: this.Close(); break;
                case Keys.S: if (m_world.RotationX > 0) m_world.RotationX -= 5.0f; break;
                case Keys.W: if (m_world.RotationX < 90) m_world.RotationX += 5.0f;  /*System.Diagnostics.Debug.WriteLine("m_world.RotationX: " + m_world.RotationX);*/ break;
                case Keys.A: m_world.RotationY -= 5.0f;  /*System.Diagnostics.Debug.WriteLine("m_world.RotationY: " + m_world.RotationY);*/ break;
                case Keys.D: m_world.RotationY += 5.0f; /*System.Diagnostics.Debug.WriteLine("m_world.RotationY: " + m_world.RotationY);*/ break;
                case Keys.Add: m_world.SceneDistance -= 700.0f; m_world.Resize(); break;
                case Keys.Subtract: m_world.SceneDistance += 700.0f; m_world.Resize(); break;
                case Keys.F7: System.Windows.Forms.Application.Exit(); break;
                case Keys.C: button2_Click(button2, null); break;      // pokreni animaciju
                case Keys.F2:
                    OpenFileDialog opfModel = new OpenFileDialog();
                    if (opfModel.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            World newWorld = new World(Directory.GetParent(opfModel.FileName).ToString(), Path.GetFileName(opfModel.FileName), openglControl.Width, openglControl.Height);
                            m_world.Dispose();
                            m_world = newWorld;
                            openglControl.Invalidate();
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta:\n" + exp.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                
            }

            openglControl.Refresh();
        }

        #endregion Rukovaoci dogadjajima OpenGL kontrole

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Box.openedDoor)
            {
                Box.openedDoor = true;
            }
            else {
                Box.openedDoor = false;
            }
            timer2.Start();
            // iscrtaj promene..
            openglControl.Select(); // vracam u fokus, kako bi imao mogucnost za wasd listener..
            openglControl.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            m_world.SunY = ((double)numericUpDown1.Value);
            openglControl.Refresh();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            m_world.SunX = ((double)numericUpDown2.Value);
            openglControl.Refresh();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            m_world.SunZ = ((double)numericUpDown3.Value);
            openglControl.Refresh();

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            m_world.Balloon.X = ((double)numericUpDown5.Value);
            openglControl.Refresh();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            m_world.Balloon.Y = ((double)numericUpDown6.Value);
            openglControl.Refresh();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            m_world.Balloon.Z = ((double)numericUpDown4.Value);
            openglControl.Refresh();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            m_world.BallonScale = (float)numericUpDown7.Value;
            openglControl.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_world.BallonRotation += m_world.BallonRotationStep;
            m_world.BallonRotation = (m_world.BallonRotation > 360) ? 0 : m_world.BallonRotation;
            openglControl.Refresh();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            m_world.BallonRotationStep = (float)numericUpDown8.Value;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (m_world.Hangar.Box.IsOpenedDoor == false)
            {
                if (m_world.Hangar.Box.DoorStep <= -4.2f)
                {
                    timer2.Stop();
                    m_world.Hangar.Box.IsOpenedDoor = true;
                }
                m_world.Hangar.Box.DoorStep -= 0.1f;
            }
            else {
                if (m_world.Hangar.Box.DoorStep >= -0.1f)
                {
                    timer2.Stop();
                    m_world.Hangar.Box.IsOpenedDoor = false;
                    m_world.Hangar.Box.DoorStep -= 0.1f;
                }
                m_world.Hangar.Box.DoorStep += 0.1f;
            }
            
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            m_world.GreenX = ((double)numericUpDown10.Value);
            openglControl.Refresh();

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            m_world.GreenY = ((double)numericUpDown11.Value);
            openglControl.Refresh();

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            m_world.GreenZ = ((double)numericUpDown9.Value);
            openglControl.Refresh();

        }
        // reset all
        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 105;
            numericUpDown2.Value = 150;
            numericUpDown3.Value = -40;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 8;
            numericUpDown8.Value = 3;
            numericUpDown9.Value = 20;
            numericUpDown10.Value = 0;
            numericUpDown11.Value = 150;
            if (m_world.Hangar.Box.IsOpenedDoor == true)
                button1_Click(button1, null);

            numericUpDown1_ValueChanged(numericUpDown1, null);      // manually trigger event
            numericUpDown2_ValueChanged(numericUpDown2, null);      // manually trigger event
            numericUpDown3_ValueChanged(numericUpDown3, null);      // manually trigger event
            numericUpDown4_ValueChanged(numericUpDown4, null);      // manually trigger event
            numericUpDown5_ValueChanged(numericUpDown5, null);      // manually trigger event
            numericUpDown6_ValueChanged(numericUpDown6, null);      // manually trigger event
            numericUpDown7_ValueChanged(numericUpDown7, null);      // manually trigger event
            numericUpDown8_ValueChanged(numericUpDown8, null);      // manually trigger event
            numericUpDown9_ValueChanged(numericUpDown9, null);      // manually trigger event
            numericUpDown10_ValueChanged(numericUpDown10, null);      // manually trigger event
            numericUpDown11_ValueChanged(numericUpDown11, null);      // manually trigger event


            openglControl.Refresh();
        }
        // start animation
        private void button2_Click(object sender, EventArgs e)
        {
            button3_Click(button3, null);
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(m_world.Hangar.Box.IsOpenedDoor == false)
                button1_Click(button1, null);       // otvori vrata

            openglControl.KeyDown -= OpenGlControlKeyDown;
            setControlsEnabled(false);
            openglControl.Select();

            if (m_world.Balloon.X <= 500)
                m_world.Balloon.X += 7;
            if (m_world.Balloon.Y >= -1000)
                m_world.Balloon.Y -= 17;
            if (m_world.Balloon.Z >= -1550)
                m_world.Balloon.Z -= 15;
            if (m_world.BallonScale > 4)
                m_world.BallonScale -= 0.1f;

            if (m_world.Balloon.X >= 500 && m_world.Balloon.Y <= -1000 && m_world.Balloon.Z <= -1550 && m_world.BallonScale <= 4)
            {
                if (m_world.Hangar.Box.IsOpenedDoor == true)
                    button1_Click(button1, null);       // otvori vrata
                timer3.Stop();
                setControlsEnabled(true);
                openglControl.Select();
                openglControl.KeyDown += OpenGlControlKeyDown;
            }

        }

        public void setControlsEnabled(bool value) { 
            foreach(Control c in Controls) {
                c.Enabled = value;
            }
        }

    }

}
