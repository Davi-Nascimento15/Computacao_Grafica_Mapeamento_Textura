using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapeamento_Textura
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        float rotacao = 0;
        uint[] Textura = new uint[1];
        Bitmap Imagem_Textura;
        int estado = 0;
        bool estado_textura = true;
        float muda_rotacao = 0;
        private void Controller_OpenGL_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gL = Controller_OpenGL.OpenGL;
            Imagem_Textura = new Bitmap("Piramide.png");
            gL.Enable(OpenGL.GL_TEXTURE_2D);
            gL.GenTextures(1, Textura);
            gL.BindTexture(OpenGL.GL_TEXTURE_2D, 1);
            gL.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, 3, Imagem_Textura.Width, Imagem_Textura.Height, 0, OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE,
                Imagem_Textura.LockBits(new Rectangle(0, 0, Imagem_Textura.Width, Imagem_Textura.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb).Scan0);

            gL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            gL.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
        }

        private void Controller_OpenGL_Resized(object sender, EventArgs e)
        {
            OpenGL gl = Controller_OpenGL.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(20.0f, (double)this.Width / (double)this.Height, 0.01, 100.0);
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void Controller_OpenGL_OpenGLDraw(object sender, RenderEventArgs args)
        {
            SharpGL.OpenGL gl = this.Controller_OpenGL.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);
            gl.Rotate(rotacao, muda_rotacao, 1.0f, 0.0f);

            if (estado_textura == true)
            {
                gl.BindTexture(OpenGL.GL_TEXTURE_2D, 1);
                gl.Color(1.0f, 1.0f, 1.0f);
            }
            else
            {
                gl.Color(1.0f, 0.0f, 0.0f);
                gl.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            }
            gl.Begin(OpenGL.GL_TRIANGLES);

            if (estado >= 1)
            {
                //Piramede
                //Frente
                gl.TexCoord(0.2f, 0.0f);
                gl.Vertex(-0.7f, -0.7f, 0.7f);
                gl.TexCoord(0.6f, 0.0f);
                gl.Vertex(0.7f, -0.7f, 0.7f);
                gl.TexCoord(0.3f, 0.5f);
                gl.Vertex(0.0f, 0.7f, 0.0f);
            }
            if (estado >= 2)
            {
                //Lateral Esquerda
                gl.TexCoord(0.2f, 0.0f);
                gl.Vertex(0.7f, -0.7f, 0.7f);
                gl.TexCoord(0.6f, 0.0f);
                gl.Vertex(0.7f, -0.7f, -0.7f);
                gl.TexCoord(0.3f, 0.5f);
                gl.Vertex(0.0f, 0.7f, 0.0f);
            }
            if (estado >= 3)
            {
                //Fundo
                gl.TexCoord(0.2f, 0.0f);
                gl.Vertex(0.7f, -0.7f, -0.7f);
                gl.TexCoord(0.6f, 0.0f); 
                gl.Vertex(-0.7f, -0.7f, -0.7f);
                gl.TexCoord(0.3f, 0.5f); 
                gl.Vertex(0.0f, 0.7f, 0.0f);
            }
            if (estado >= 4)
            {
                //Lateral Direita
                gl.TexCoord(0.2f, 0.0f); 
                gl.Vertex(-0.7f, -0.7f, -0.7f);
                gl.TexCoord(0.6f, 0.0f);
                gl.Vertex(-0.7f, -0.7f, 0.7f);
                gl.TexCoord(0.3f, 0.5f);
                gl.Vertex(0.0f, 0.7f, 0.0f);
            }
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);

            //Base
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-0.7f, -0.7f, 0.7f);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.7f, -0.7f, 0.7f);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.7f, -0.7f, -0.7f);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-0.7f, -0.7f, -0.7f);

            gl.End();

            gl.Flush();
            rotacao += 1.0f;
        }
        private void Inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                if (estado == 4)
                    estado = 0;
                else
                    estado++;
            }
            else if (e.KeyChar == '-')
            {
                if (estado == 0)
                    estado = 4;
                else
                    estado--;
            }
            else if (e.KeyChar == '0')
            {
                estado_textura = !estado_textura;
            }
            else if(e.KeyChar == '1')
            {
                muda_rotacao--;
            }
            else if (e.KeyChar == '2')
            {
                muda_rotacao++;
            }
        }
    }
}