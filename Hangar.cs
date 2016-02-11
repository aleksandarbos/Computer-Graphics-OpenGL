// -----------------------------------------------------------------------
// <file>Hangar.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2012.</copyright>
// <author>Srdjan Mihic</author>
// <summary>Klasa koja enkapsulira OpenGL programski kod za iscrtavanje kuce.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe
{
  using System;
  using System.Windows.Forms;
  using Tao.OpenGl; // prostor imena za rad sa OpenGL-om

  /// <summary>
  ///  Klasa enkapsulira OpenGL kod za iscrtavanje kuce.
  /// </summary>
  public class Hangar : IDrawable
  {
    #region Atributi

      private int[] m_textures;

      private enum TextureObjects { Sand = 0, Wood };

      /// <summary>
      ///	 Velicina stranice osnove kuce.
      /// </summary>
      private double m_size = 1.0;

      private float m_width = 6.0f;
      private float m_height = 6.5f;
      private float m_depth = 12.0f;
      

      /// <summary>
      ///	 Kocka.
      /// </summary>
      //private Cube m_cube = null;
      private Box m_box = null;
      private Antenna m_antena = null;


    #endregion Atributi

    #region Properties

      public int[] Textures
      {
          get { return m_textures; }
          set { m_textures = value; }
      }


      public Box Box
      {
          get 
          {
              return m_box;
          }
      }

      public Antenna Antenna
      {
          get
          {
              return m_antena;
          }
      }

      /// <summary>
      ///	 Velicina stranice kocke.
      /// </summary>
      public double Size
      {
        get { return m_size; }
        set
        {
          m_size = value;
          
          try
          {
            m_box = new Box(m_width, m_height, m_depth);
            m_antena = new Antenna(m_width / 5.0f, m_height / 5.0f, m_depth / 5.0f);
          }
          catch (Exception)
          {
            MessageBox.Show("Neuspesno kreirana instanca klase Box", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }

    #endregion Properties

    #region Konstruktori

      /// <summary>
      ///		Konstruktor klase Cube.
      /// </summary>
      public Hangar()
      {
        try
        {
            m_box = new Box(m_width, m_height, m_depth);
        }
        catch (Exception)
        {
          MessageBox.Show("Neuspesno kreirana instanca klase Box", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      
      /// <summary>
      ///		Konstruktor klase Cube sa parametrima.
      /// </summary>
      /// <param name="size">Velicina stranice kuce.</param>
      public Hangar(float width, float height, float depth)
      {
          this.m_width = width;
          this.m_height = height;
          this.m_depth = depth;

        try
        {
            m_box = new Box(m_width, m_height, m_depth);
            m_antena = new Antenna(m_width / 24.0f, m_height / 4.0f, m_depth / 5.0f);
        }
        catch (Exception)
        {
          MessageBox.Show("Neuspesno kreirana instanca klase Box", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

    #endregion Konstruktori

    #region Metode

      /// <summary>
      ///  Iscrtavanje kuce pomocu OpenGL-a.
      /// </summary>
      public void Draw()
      {
        // Osnova kuce
        //Gl.glColor3ub(0, 255, 255); // bela boja
        // nacrtati osnovu kuce koriscenjem instance klase Cube
        Gl.glBindTexture(Gl.GL_TEXTURE_2D, m_textures[(int)TextureObjects.Wood]);
        m_box.Draw();
          // TODO 3.3.1: postavljanje antene na vrh box modela(na krovu hangara)
        Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, m_height, 0.0f);
            Gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);

            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glTranslatef(4.0f, 0.0f, 3.0f);      // spusti antenu na hangar
            
            m_antena.Draw();

            Gl.glEnable(Gl.GL_TEXTURE_2D);
        Gl.glPopMatrix();
        Gl.glFlush();
        
        
        // Krov kuce
      }

    #endregion Metode
  }
}
