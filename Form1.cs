using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapturadorSantiago2
{
  public partial class Form1 : Form
  {
    private string carpetaDestino = "";
    private MouseHook mouseHook;

    public Form1()
    {
      InitializeComponent();

      // Cargar última ruta guardada
      carpetaDestino = Properties.Settings.Default.UltimaRuta;

      if (!string.IsNullOrWhiteSpace(carpetaDestino))
        txtCarpeta.Text = carpetaDestino;

      // Inicializar hook
      mouseHook = new MouseHook();
      mouseHook.MiddleClick += MouseHook_MiddleClick;
    }

    private void MouseHook_MiddleClick(Point cursorPos, IntPtr hWnd)
    {
      if (string.IsNullOrWhiteSpace(carpetaDestino))
        return;
      if (hWnd == IntPtr.Zero)
        return;

      // Ignorar si es el formulario
      if (hWnd == this.Handle)
        return;

      var bmp = WindowCapture.CaptureWindow(hWnd);
      if (bmp == null)
      {
        return;
      }
      pictureBox1.Image = bmp;
      ImageSaver.SaveImage(bmp, carpetaDestino);
    }

    private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
    {
      using (var dialog = new FolderBrowserDialog())
      {
        dialog.Description = "Selecciona la carpeta donde se guardarán las capturas";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
          carpetaDestino = dialog.SelectedPath;
          txtCarpeta.Text = carpetaDestino;

          // Guardar en settings
          Properties.Settings.Default.UltimaRuta = carpetaDestino;
          Properties.Settings.Default.Save();
        }
      }
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(carpetaDestino))
      {
        MessageBox.Show("Debes seleccionar una carpeta antes de iniciar.");
        return;
      }

      mouseHook.Start();
      MessageBox.Show("Captura iniciada. Haz clic en cualquier ventana para capturarla.");
      btnIniciar.BackColor = Color.LightGreen;
      btnDetener.BackColor = Color.Red;
    }

    private void btnDetener_Click(object sender, EventArgs e)
    {
      mouseHook.Stop();
      MessageBox.Show("Captura detenida.");
      btnIniciar.BackColor = SystemColors.Control;
      btnDetener.BackColor = SystemColors.Control;

    }


  }
}