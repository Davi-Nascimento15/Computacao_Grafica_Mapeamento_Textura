namespace Mapeamento_Textura
{
    partial class Inicio
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Controller_OpenGL = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.Controller_OpenGL)).BeginInit();
            this.SuspendLayout();
            // 
            // Controller_OpenGL
            // 
            this.Controller_OpenGL.DrawFPS = false;
            this.Controller_OpenGL.Location = new System.Drawing.Point(0, 0);
            this.Controller_OpenGL.Name = "Controller_OpenGL";
            this.Controller_OpenGL.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.Controller_OpenGL.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.Controller_OpenGL.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.Controller_OpenGL.Size = new System.Drawing.Size(986, 660);
            this.Controller_OpenGL.TabIndex = 0;
            this.Controller_OpenGL.OpenGLInitialized += new System.EventHandler(this.Controller_OpenGL_OpenGLInitialized);
            this.Controller_OpenGL.OpenGLDraw += new SharpGL.RenderEventHandler(this.Controller_OpenGL_OpenGLDraw);
            this.Controller_OpenGL.Resized += new System.EventHandler(this.Controller_OpenGL_Resized);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.Controller_OpenGL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapeamento de Textura";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Inicio_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Controller_OpenGL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl Controller_OpenGL;
    }
}

