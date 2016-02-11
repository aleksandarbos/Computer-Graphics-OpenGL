// -----------------------------------------------------------------------
// <file>Terrain.cs</file>
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
    public class Terrain
    {
        #region Atributi

        private int[] m_textures;

        private enum TextureObjects { Sand = 0, Wood };

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

        public int[] Textures
        {
            get { return m_textures; }
            set { m_textures = value; }
        }

        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        public double Height
        {
            get { return m_height; }
            set { m_height = value; }
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
        public Terrain()
        {
            initialize();
        }

        /// <summary>
        ///		Konstruktor sa parametrima.
        /// </summary>
        /// <param name="width">Sirina kvadra.</param>
        /// <param name="height">Visina kvadra.</param>
        /// <param name="depth"></param>
        public Terrain(double width, double height, double depth)
        {
            initialize();
            
            this.m_width = width;
            this.m_height = height;
            this.m_depth = depth;
        }

        #endregion Konstruktori

        #region Metode

        public void Draw()
        {
            //  Zarotirati grid za 90 stepeni oko x ose i pomeriti ga za 5.5f po z osi
            Gl.glMatrixMode(Gl.GL_TEXTURE);     // rezim iscrtavanja tekstura
            Gl.glPushMatrix();
                Gl.glScalef(16.01f, 16.01f, 16.01f);
                //Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[(int)TextureObjects.Sand]);
                Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);       // nacin stapanja 
                Gl.glBegin(Gl.GL_QUADS);
                    Gl.glNormal3f(0.0f, 1.0f, 0.0f);
                    Gl.glTexCoord2f(1.0f, 1.0f);
                    Gl.glVertex3f(2200.0f, -40.0f, -3000.0f);

                    Gl.glTexCoord2f(1.0f, 0.0f);
                    Gl.glVertex3f(-2000.0f, -40.0f, -2000.0f);

                    Gl.glTexCoord2f(0.0f, 0.0f);
                    Gl.glVertex3f(-2000.0f, -40.0f, 900.0f);

                    Gl.glTexCoord2f(0.0f, 1.0f);
                    Gl.glVertex3f(2200.0f, -40.0f, 900.0f);
                Gl.glEnd();
                //Gl.glMatrixMode(Gl.GL_TEXTURE);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

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
        }

        #endregion Metode
    }
}
