using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapturadorSantiago2
{
  public static class WindowCapture
  {
    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

    [DllImport("user32.dll")]
    private static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
      public int Left, Top, Right, Bottom;
    }

    public static Bitmap CaptureWindow(IntPtr handle)
    {
      if (handle == IntPtr.Zero)
        return null;

      if (!GetWindowRect(handle, out RECT rect))
        return null;

      int width = rect.Right - rect.Left;
      int height = rect.Bottom - rect.Top;

      if (width <= 0 || height <= 0)
        return null;

      Bitmap bmp = new Bitmap(width, height);

      using (Graphics g = Graphics.FromImage(bmp))
      {
        IntPtr hdc = g.GetHdc();
        PrintWindow(handle, hdc, 0);
        g.ReleaseHdc(hdc);
      }

      return bmp;
    }
  }
}