// -----------------------------------------------------------------------
// <file>Antenna.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2012.</copyright>
// <author>Srdjan Mihic</author>
// <summary>Klasa koja enkapsulira OpenGL programski kod za iscrtavanje kvadra sa tezistem u koord.pocetku.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe
{
    using Tao.OpenGl;

    /// <summary>
    ///  Klasa enkapsulira OpenGL kod za iscrtavanje kvadra.
    /// </summary>
    public class Antenna
    {
        #region Atributi

        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        double m_height = 1.0;

        /// <summary>
        ///	 Sirina kvadra.
        /// </summary>
        double m_width = 1.0;

        private Glu.GLUquadric m_gluObj;


        /// <summary>
        ///	 Dubina kvadra.
        /// </summary>
        double m_depth = 1.0;

        #endregion Atributi

        #region Properties

        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        public double Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        public Glu.GLUquadric GluObj
        {
            get
            {
                return m_gluObj;
            }
        }
        /// <summary>
        ///	 Sirina kvadra.
        /// </summary>
        public double Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        /// <summary>
        ///	 Dubina kvadra.
        /// </summary>
        public double Depth
        {
            get { return m_depth; }
            set { m_depth = value; }
        }

        #endregion Properties

        #region Konstruktori

        /// <summary>
        ///		Konstruktor.
        /// </summary>
        public Antenna()
        {
            initialize();
        }

        /// <summary>
        ///		Konstruktor sa parametrima.
        /// </summary>
        /// <param name="width">Sirina kvadra.</param>
        /// <param name="height">Visina kvadra.</param>
        /// <param name="depth"></param>
        public Antenna(double width, double height, double depth)
        {
            initialize();
            
            this.m_width = width;
            this.m_height = height;
            this.m_depth = depth;
        }

        #endregion Konstruktori

        ~Antenna() {
            Glu.gluDeleteQuadric(m_gluObj);
        }

        #region Metode

        public void Draw()
        {
            // TODO 3.3.0: Modelovanje modela antene u zasebnoj klasi Antenna
            //zlatan materijal
                     
            float[] Ka = { 0.42f, 1.0f, 0.0f, 1.0f };
            float[] Kd = { 1.0f, 1.0f, 0.0f, 0.0f };
            float[] Ks = { 1.0f, 0.62f, 1.0f, 1.0f};
            float[] Ke = { 0.21f, 0.03f, 0.0f, 1.0f };
            float[] Se  = {10.0f};

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Ka);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Kd);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Ks);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, Ke);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, Se);

            // spine
            Gl.glPushMatrix();
                Gl.glTranslatef(-0.5f, 0.0f, 0.0f);
                Glu.gluCylinder(m_gluObj, m_width, m_width+1, m_height, 15, 15);
            Gl.glPopMatrix();
            // disc
            Gl.glPushMatrix();
                Gl.glRotatef(180-45, 0, 1, 0);
                //Gl.glTranslatef(3.0f, 0.0f, 0.0f);
                Glu.gluDisk(m_gluObj, 0, 5, 128, 128);
            Gl.glPopMatrix();

            
            Gl.glFlush();
        }

        public void SetSize(double width, double height, double depth)
        {
            m_depth = depth;
            m_height = height;
            m_width = width;
        }

        public void initialize() {
            m_gluObj = Glu.gluNewQuadric();
            Glu.gluQuadricNormals(m_gluObj, Glu.GLU_SMOOTH);
            //Glu.gluQuadricTexture(m_gluObj, Gl.GL_TRUE);
        }

        #endregion Metode
    }
}
