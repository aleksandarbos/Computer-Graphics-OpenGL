// -----------------------------------------------------------------------
// <file>Box.cs</file>
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
    public class Box
    {
        #region Atributi

        private bool isOpenedDoor = false;

        private float doorStep = 0.0f;
        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        double m_height = 1.0;

        /// <summary>
        ///	 Sirina kvadra.
        /// </summary>
        double m_width = 1.0;

        /// <summary>
        ///	 Dubina kvadra.
        /// </summary>
        double m_depth = 1.0;

        #endregion Atributi

        #region Properties

        public float DoorStep 
        {
            get { return doorStep; }
            set { doorStep = value; }
        }

        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        public double Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        public bool IsOpenedDoor
        {
            get { return isOpenedDoor; }
            set { isOpenedDoor = value; }
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
        public Box()
        {
        }

        /// <summary>
        ///		Konstruktor sa parametrima.
        /// </summary>
        /// <param name="width">Sirina kvadra.</param>
        /// <param name="height">Visina kvadra.</param>
        /// <param name="depth"></param>
        public Box(double width, double height, double depth)
        {
            this.m_width = width;
            this.m_height = height;
            this.m_depth = depth;
        }

        #endregion Konstruktori

        #region Metode

        public void Draw()
        {
            Gl.glFrontFace(Gl.GL_CCW);
            Gl.glBegin(Gl.GL_QUADS);
            //Gl.glColor3f(0.5f, 0.5f, 0.26f);     // svetlo braon

            // Zadnja
            Gl.glNormal3fv(Lighting.FindFaceNormal((float)-m_width / 2, (float)-m_height / 2, (float)-m_depth / 2, (float)-m_width / 2, (float)m_height / 2, (float)-m_depth / 2, (float)m_width / 2, (float)m_height / 2, (float)-m_depth / 2));
            Gl.glTexCoord2f(1.0f, 0.0f);    Gl.glVertex3d(-m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);    Gl.glVertex3d(-m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);    Gl.glVertex3d(m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(0.0f, 0.0f);    Gl.glVertex3d(m_width / 2, -m_height / 2, -m_depth / 2);
           
            
            //Gl.glColor3f(0.2f, 0.1f, 0.7f);
            // Desna
            Gl.glNormal3fv(Lighting.FindFaceNormal((float)m_width / 2, (float)-m_height / 2, (float)-m_depth / 2, (float)m_width / 2, (float)m_height / 2, (float)-m_depth / 2, (float)m_width / 2, -(float)m_height / 2, (float)m_depth / 2));
            Gl.glTexCoord2f(1.0f, 0.0f);    Gl.glVertex3d(m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);    Gl.glVertex3d(m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);    Gl.glVertex3d(m_width / 2, m_height / 2, m_depth / 2);
            Gl.glTexCoord2f(0.0f, 0.0f);    Gl.glVertex3d(m_width / 2, -m_height / 2, m_depth / 2);

            Gl.glNormal3fv(Lighting.FindFaceNormal((float)-m_width / 2, (float)-m_height / 2, (float)m_depth / 2, (float)-m_width / 2, (float)m_height / 2, (float)m_depth / 2, (float)-m_width / 2, (float)m_height / 2, (float)-m_depth / 2));
            // Leva
            Gl.glVertex3d(-m_width / 2, -m_height / 2, m_depth / 2);    Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3d(-m_width / 2, m_height / 2, m_depth / 2);     Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3d(-m_width / 2, m_height / 2, -m_depth / 2);    Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, -m_depth / 2);   Gl.glTexCoord2f(0.0f, 0.0f);
            
            //Gl.glColor3f(0.5f, 0.0f, 0.7f);
            // Donja
            Gl.glVertex3d(-m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glVertex3d(m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glVertex3d(m_width / 2, -m_height / 2, m_depth / 2);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, m_depth / 2);


            //Gl.glColor3f(0.0f, 0.4f, 0.8f);
            // Gornja
            Gl.glNormal3fv(Lighting.FindFaceNormal((float)-m_width / 2, (float)m_height / 2, (float)-m_depth / 2, (float)-m_width / 2, (float)m_height / 2, (float)m_depth / 2, (float)-m_width / 2, (float)m_height / 2, (float)m_depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);    Gl.glVertex3d(-m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);    Gl.glVertex3d(-m_width / 2, m_height / 2, m_depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);    Gl.glVertex3d(m_width / 2, m_height / 2, m_depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);    Gl.glVertex3d(m_width / 2, m_height / 2, -m_depth / 2);

            Gl.glEnd();
            
            // TODO 3.2.0: Modifikacija prednje strane box modela, tako da ima rupu za vrata..
            // prednji deo
            //Gl.glColor3f(0.9f, 0.4f, 0.8f);

            Gl.glPushMatrix();
                Gl.glTranslated(-m_width / 4, 0.0, 0.0);      // pola od sirine
                Gl.glTranslated(DoorStep, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glNormal3fv(Lighting.FindFaceNormal((float)-m_width / 4, (float)-m_height / 2, (float)m_depth / 2, (float)m_width / 4, (float)m_height / 2, (float)m_depth / 2, (float)-m_width / 4, (float)m_height / 2, (float)m_depth / 2));
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(m_width / 4, -m_height / 2, m_depth / 2);
                    Gl.glTexCoord2f(1.0f, 1.0f);    Gl.glVertex3d(m_width / 4, m_height / 2, m_depth / 2);
                    Gl.glTexCoord2f(0.0f, 1.0f);    Gl.glVertex3d(-m_width / 4, m_height / 2, m_depth / 2);
                    Gl.glTexCoord2f(0.0f, 0.0f);    Gl.glVertex3d(-m_width / 4, -m_height / 2, m_depth / 2);
                Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslated(m_width / 4, 0.0, 0.0);      // pola od sirine
                Gl.glTranslated(-DoorStep, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glNormal3fv(Lighting.FindFaceNormal((float)m_width / 4, (float)-m_height / 2, (float)m_depth / 2, (float)m_width / 4, (float)m_height / 2, (float)m_depth / 2, (float)-m_width / 4, (float)m_height / 2, (float)m_depth / 2));
                    Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3d(m_width / 4, -m_height / 2, m_depth / 2);
                    Gl.glTexCoord2f(1.0f, 1.0f);    Gl.glVertex3d(m_width / 4, m_height / 2, m_depth / 2);
                    Gl.glTexCoord2f(0.0f, 1.0f);    Gl.glVertex3d(-m_width / 4, m_height / 2, m_depth / 2);
                    Gl.glTexCoord2f(0.0f, 0.0f);    Gl.glVertex3d(-m_width / 4, -m_height / 2, m_depth / 2);
                Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glFlush();
        }

        public void SetSize(double width, double height, double depth)
        {
            m_depth = depth;
            m_height = height;
            m_width = width;
        }

        #endregion Metode

        public static bool openedDoor = false;
    }
}
