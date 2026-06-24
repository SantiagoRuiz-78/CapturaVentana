namespace CapturadorSantiago2
{
  partial class Form1
  {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
      this.txtCarpeta = new System.Windows.Forms.TextBox();
      this.btnIniciar = new System.Windows.Forms.Button();
      this.btnDetener = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnSeleccionarCarpeta
      // 
      this.btnSeleccionarCarpeta.AutoSize = true;
      this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(318, 9);
      this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
      this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(113, 23);
      this.btnSeleccionarCarpeta.TabIndex = 0;
      this.btnSeleccionarCarpeta.Text = "Seleccionar Carpeta";
      this.btnSeleccionarCarpeta.UseVisualStyleBackColor = true;
      this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
      // 
      // txtCarpeta
      // 
      this.txtCarpeta.Location = new System.Drawing.Point(12, 12);
      this.txtCarpeta.Name = "txtCarpeta";
      this.txtCarpeta.ReadOnly = true;
      this.txtCarpeta.Size = new System.Drawing.Size(300, 20);
      this.txtCarpeta.TabIndex = 1;
      // 
      // btnIniciar
      // 
      this.btnIniciar.AutoSize = true;
      this.btnIniciar.Location = new System.Drawing.Point(12, 38);
      this.btnIniciar.Name = "btnIniciar";
      this.btnIniciar.Size = new System.Drawing.Size(85, 23);
      this.btnIniciar.TabIndex = 2;
      this.btnIniciar.Text = "Iniciar captura";
      this.btnIniciar.UseVisualStyleBackColor = true;
      this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
      // 
      // btnDetener
      // 
      this.btnDetener.AutoSize = true;
      this.btnDetener.Location = new System.Drawing.Point(103, 38);
      this.btnDetener.Name = "btnDetener";
      this.btnDetener.Size = new System.Drawing.Size(94, 23);
      this.btnDetener.TabIndex = 3;
      this.btnDetener.Text = "Detener captura";
      this.btnDetener.UseVisualStyleBackColor = true;
      this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(12, 67);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(419, 188);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // timer1
      // 
      this.timer1.Interval = 300;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(444, 271);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btnDetener);
      this.Controls.Add(this.btnIniciar);
      this.Controls.Add(this.txtCarpeta);
      this.Controls.Add(this.btnSeleccionarCarpeta);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnSeleccionarCarpeta;
    private System.Windows.Forms.TextBox txtCarpeta;
    private System.Windows.Forms.Button btnIniciar;
    private System.Windows.Forms.Button btnDetener;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Timer timer1;
  }
}

