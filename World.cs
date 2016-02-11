// -----------------------------------------------------------------------
// <file>World.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2013.</copyright>
// <author>Zoran Milicevic</author>
// <summary>Klasa koja enkapsulira OpenGL programski kod.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    using System;
    using Tao.OpenGl;
    using Assimp;
    using System.IO;
    using System.Reflection;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    /// <summary>
    ///  Klasa enkapsulira OpenGL kod i omogucava njegovo iscrtavanje i azuriranje.
    /// </summary>
    public class World : IDisposable
    {
        #region Atributi

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        private AssimpScene2 m_balloon;
        private Hangar m_hangar;
        private Terrain m_terrain;

        private double sun_x, sun_y, sun_z;
        private double green_x, green_y, green_z;

        private float[] diffuseLightPosition = { 0.0f, 0.0f, -7000.0f + 4000.0f, 1.0f };

        private float[] pozicijaReflekorskog = { 0.0f, 4.0f, 1.5f, 1.0f };
        private float[] pozicijaTackastog = { 5.0f, 3.0f, 0.0f, 1.0f }; 

        private float ballonScale = 8.0f;
        private float ballonRotate = 0.0f;
        private float ballonRotateStep = 3.0f;

        private enum TextureObjects { Sand = 0, Wood};
        private readonly int m_textureCount = Enum.GetNames(typeof(TextureObjects)).Length;
        private int[] m_textures = null;
        public string rootDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        private string[] m_textureFiles = {  "\\Textures\\Sand.jpg", "\\Textures\\Wood4.jpg" };

        private Glu.GLUquadric m_gluObj = Glu.gluNewQuadric();

        private OutlineFont m_font;
        /// <summary>
        ///	 Ugao rotacije sveta oko X ose.
        /// </summary>
        private float m_xRotation = 0.0f;

        /// <summary>
        ///	 Ugao rotacije sveta oko Y ose.
        /// </summary>
        private float m_yRotation = 0.0f;

        /// <summary>
        ///	 Udaljenost scene od kamere.
        /// </summary>
        private float m_sceneDistance = 7000.0f;

        /// <summary>
        ///	 Sirina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_width;

        /// <summary>
        ///	 Visina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_height;

        #endregion Atributi

        #region Properties

        public Hangar Hangar
        {
            get { return m_hangar; }
        }

        public double SunX {
            get { return sun_x; }
            set { sun_x = value; }
        }

        public double SunY
        {
            get { return sun_y; }
            set { sun_y = value; }
        }

        public double SunZ
        {
            get { return sun_z; }
            set { sun_z = value; }
        }

        public double GreenX
        {
            get { return green_x; }
            set { green_x = value; }
        }

        public double GreenY
        {
            get { return green_y; }
            set { green_y = value; }
        }

        public double GreenZ
        {
            get { return green_z; }
            set { green_z = value; }
        }


        public float BallonScale
        {
            get { return ballonScale; }
            set { ballonScale = value; }
        }

        public float BallonRotation
        {
            get { return ballonRotate; }
            set { ballonRotate = value; }
        }

        public float BallonRotationStep
        {
            get { return ballonRotateStep; }
            set { ballonRotateStep = value; }
        }

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        public AssimpScene2 Balloon
        {
            get { return m_balloon; }
            set { m_balloon = value; }
        }


        public string RootDirectory
        {
            get { return rootDirectory; }
        }

        /// <summary>
        ///	 Ugao rotacije sveta oko X ose.
        /// </summary>
        public float RotationX
        {
            get { return m_xRotation; }
            set { m_xRotation = value; }
        }

        /// <summary>
        ///	 Ugao rotacije sveta oko Y ose.
        /// </summary>
        public float RotationY
        {
            get { return m_yRotation; }
            set { m_yRotation = value; }
        }

        /// <summary>
        ///	 Udaljenost scene od kamere.
        /// </summary>
        public float SceneDistance
        {
            get { return m_sceneDistance; }
            set { m_sceneDistance = value; }
        }

        /// <summary>
        ///	 Sirina OpenGL kontrole u pikselima.
        /// </summary>
        public int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        /// <summary>
        ///	 Visina OpenGL kontrole u pikselima.
        /// </summary>
        public int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        #endregion Properties

        #region Konstruktori

        /// <summary>
        ///  Konstruktor klase World.
        /// </summary>
        public World(String scenePath, String sceneFileName, int width, int height)
        {
            this.m_balloon = new AssimpScene2(scenePath, sceneFileName);
            this.m_hangar = new Hangar(10.0f, 10.0f, 12.0f);
            this.m_terrain = new Terrain();
            //this.m_hangar = new Hangar(3.0f, 2.5f, 6.0f);
            this.m_width = width;
            this.m_height = height;

            try
            {
                // TODO 4.0: Podsavanje fonta Courier New, 11pt, bold, italic
                m_font = new OutlineFont("Courier New", 11, 0.02f, true, true, false, false);
                m_textures = new int[m_textureCount];
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL fonta", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Initialize();  // Korisnicka inicijalizacija OpenGL parametara

            this.Resize();      // Podesi projekciju i viewport
        }

        /// <summary>
        ///  Destruktor klase World.
        /// </summary>
        ~World()
        {
            this.Dispose(false);
        }

        #endregion Konstruktori

        #region Metode

        /// <summary>
        ///  Iscrtavanje OpenGL kontrole.
        /// </summary>
        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            // TODO 2.1: skaliranje i translacija balona na scenu

            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, 0.0f, -m_sceneDistance);
                Gl.glRotatef(m_xRotation, 1.0f, 0.0f, 0.0f);
                Gl.glRotatef(m_yRotation, 0.0f, 1.0f, 0.0f);
                Gl.glScalef(35.0f, 35.0f, 35.0f);

                // da gleda sa strane gde se vide i antena i balon i prednja strana
                Glu.gluLookAt(0.0f, 0.0f, 0.0f,
                              -1.0f, 0.0f, -1.0f,
                              0.0f, 1.0f, 0.0f);

                Gl.glPushMatrix();
                    Gl.glTranslated(SunX, SunY, SunZ);
                    Gl.glColor3ub(255, 255, 102);
                    // fiksiranje izvora svetlosti na sunce
                    Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, new float[] { (float)SunX, (float)SunY, (float)SunZ, 1.0f });
                    Glu.gluSphere(m_gluObj, 15.0f, 128, 128);       // sun
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                    Gl.glColor3ub(0, 255, 0);
                    Gl.glTranslated(GreenX, GreenY, GreenZ);
                    Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, new float[] { (float)GreenX, (float)GreenY, (float)GreenZ, 1.0f });
                    Glu.gluSphere(m_gluObj, 5.0f, 128, 128);        // green light
                    Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, new float[] {0.0f, -1.0f, 0.0f});
                Gl.glPopMatrix();
                
                // balloon model draw at world.....
                Gl.glPushMatrix();

                    Gl.glScalef(BallonScale * 0.01f, BallonScale * 0.01f, BallonScale * 0.01f);
                    if(MainForm.BALOON_TYPE != 0)
                        Gl.glScalef(BallonScale+100.0f, BallonScale+100.0f, BallonScale+100.0f); //za drugi model
                    else
                        Gl.glTranslated(m_balloon.X, m_balloon.Y, m_balloon.Z);     // za prvi model
                    Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_ADD);       // nacin stapanja GL_ADD za model
                    Gl.glRotatef(BallonRotation, 0.0f, 1.0f, 0.0f);     // rotiraj oko svoje ose balon   
                    m_balloon.Draw();
                    Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);       // nacin stapanja 
                Gl.glPopMatrix();
                
                // TODO 2.2: postavljanje balona ispred hangara, tako sto postavljam hangar iza balona :))
                Gl.glPushMatrix();
                    Gl.glTranslatef(20.0f, -20.0f, -60.0f);
                    Gl.glScalef(4.0f, 4.0f, 4.0f);
                    Gl.glColor3ub(255, 255, 102);       // zutom da iscrta antenu i drzac- zlatna
                    m_hangar.Draw();
                Gl.glPopMatrix();
                // terrain load
                m_terrain.Draw();

            Gl.glPopMatrix();

            writeVectorText();

            // Oznaci kraj iscrtavanja
            Gl.glFlush();
        }

        /// <summary>
        ///  Korisnicka inicijalizacija i podesavanje OpenGL parametara.
        /// </summary>
        private void Initialize()
        {

            // Boja pozadine je nebesko plava
            Gl.glClearColor(0.67f, 0.84f, 0.9f, 1.0f);
            // TODO 1.2: ukljucen test dubine, i sakrivanje nevidljivih povrsina
            Gl.glEnable(Gl.GL_DEPTH_TEST);  // ukljucen test dubine
            Gl.glEnable(Gl.GL_CULL_FACE); // ukljuceno sakrivanje nevidljivih povrsina...
            Gl.glFrontFace(Gl.GL_CCW);
           
           
            formLightingCalculation();

            // TODO 7.0: Ucitavanje i postavljanje tekstura u projekat
            formTextures();

        }

        private void formTextures()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);       // nacin stapanja 

            // Ucitaj slike i kreiraj teksture

            Gl.glGenTextures(m_textureCount, m_textures);
            for (int i = 0; i < m_textureCount; ++i)
            {
                // Pridruzi teksturu odgovarajucem identifikatoru
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[i]);

                // Ucitaj sliku i podesi parametre teksture
                Bitmap image = new Bitmap(RootDirectory +  m_textureFiles[i]);
                // rotiramo sliku zbog koordinantog sistema opengl-a
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                // RGBA format (dozvoljena providnost slike tj. alfa kanal)
                BitmapData imageData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                      System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, (int)Gl.GL_RGBA8, image.Width, image.Height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, imageData.Scan0);
                
                // nacin filtrianja NEAREST
                //Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MIN_FILTER, (int)Gl.GL_LINEAR_MIPMAP_LINEAR);
                Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MIN_FILTER, (int)Gl.GL_NEAREST_MIPMAP_NEAREST);
                Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MAG_FILTER, (int)Gl.GL_NEAREST_MIPMAP_NEAREST);
                
                // wrapping GL_REPEAT po obema osama
                Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

                image.UnlockBits(imageData);
                image.Dispose();
            }
            m_terrain.Textures = m_textures;        // prosledi u ostale klase nove teksture...
            m_hangar.Textures = m_textures;

        }

        private void formLightingCalculation()
        {
            float[] ambientalLight = { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] diffuseLight = { 0.7f, 0.7f, 0.7f, 1.0f };
           

            // Ukljuci proracun osvetljenja
            Gl.glEnable(Gl.GL_LIGHTING);
            
            // ukljuci automatsku normalizaciju
            Gl.glEnable(Gl.GL_NORMALIZE);

            //TODO 6.0: Ukljuciti color tracking mehanizam difuzno i ambientalno svetlo, glColor se definisu komponente materijala
            // Ukljuci i podesi color tracking
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

            // ambientalno svetlo
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, ambientalLight);
            
            // Podesi parametre tackastog svetlosnog izvora
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, new float[] {0.3f, 0.3f, 0.3f});
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambientalLight);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 180.0f);

            //  Definisati reflektorski svetlosni izvor (cut-off=30º) 
            //  zelene boje iznad balona, usmeren ka balonu.

            float[] ambijentalnaKomponenta = { 0.0f, 0.5f, 0.0f, 0.5f };
            float[] difuznaKomponenta = { 0.0f, 0.5f, 0.0f, 0.5f };
            float[] smer = { 0.0f, -1.0f, 0.0f }; // posto je iznad balona onda negativnom smeru Y ose

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, ambijentalnaKomponenta);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, difuznaKomponenta);

            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 30.0f);

            // Ukljuci svetlosni izvor
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHT2);
            
            Glu.gluQuadricNormals(m_gluObj, Glu.GLU_SMOOTH);
           // Glu.gluQuadricTexture(m_gluObj, Gl.GL_TRUE);
            
        }

        /// <summary>
        /// Podesava viewport i projekciju za OpenGL kontrolu.
        /// </summary>
        public void Resize()
        {
            // TODO 1.0: viewport preko celog ekrana..
            Gl.glViewport(0, 0, m_width, m_height); // kreiraj viewport po celom prozoru
            Gl.glMatrixMode(Gl.GL_PROJECTION);      // selektuj Projection Matrix
            Gl.glLoadIdentity();			        // resetuj Projection Matrix

            // TODO 1.1: vrednosti za podesavanja projekcije u perspektivi: fov= 55; near = 0.5
            
            Glu.gluPerspective(55.0, (double)m_width / (double)m_height, 0.5, 20000.0); // fov= 55; near = 0.5
           
            Gl.glMatrixMode(Gl.GL_MODELVIEW);   // selektuj ModelView Matrix
            Gl.glLoadIdentity();                // resetuj ModelView Matrix

        }

        /// <summary>
        ///  Implementacija IDisposable interfejsa.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Oslodi managed resurse
            }

            // Oslobodi unmanaged resurse
            m_balloon.Dispose();
            m_font.Dispose();
            Gl.glDeleteTextures(m_textureCount, m_textures);
            Glu.gluDeleteQuadric(m_gluObj);
        }

        #endregion Metode

        #region IDisposable metode

        /// <summary>
        ///  Dispose metoda.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void writeVectorText() {

            // TODO 4.1: gluOrtho2D projekcija, ispis teksta
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glViewport(m_width - 260, 0, 250, 250);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-7, 7, -7, 7);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();

            Gl.glPushAttrib(Gl.GL_CURRENT_BIT);
            Gl.glColor3ub(255, 255, 0);

            Gl.glPushMatrix();
            Gl.glTranslatef(-7, -2, 0);
            m_font.DrawText("Predmet: Racunarska grafika");
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-7, -3, 0);
            m_font.DrawText("Sk.god: 2015/16.");
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-7, -4, 0);
            m_font.DrawText("Ime: Aleksandar");
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-7, -5, 0);
            m_font.DrawText("Prezime: Bosnjak");
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(-7, -6, 0);
            m_font.DrawText("Sifra zad: 8.3");
            Gl.glPopMatrix();
            Gl.glPopAttrib();
            Gl.glPopMatrix();
            Gl.glEnable(Gl.GL_LIGHTING);
            Resize();

            //
        }

        #endregion IDisposable metode
    }

}
