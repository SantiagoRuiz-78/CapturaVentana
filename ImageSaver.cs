using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapturadorSantiago2
{
  public static class ImageSaver
  {
    public static void SaveImage(Bitmap bmp, string folderPath)
    {
      if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

      string fileName = $"captura_{DateTime.Now:yyyyMMdd_HHmmss}.png";
      string fullPath = Path.Combine(folderPath, fileName);

      bmp.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
    }
  }
}