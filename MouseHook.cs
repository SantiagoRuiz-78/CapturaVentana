using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapturadorSantiago2
{
  public class MouseHook
  {
    private const int WH_MOUSE_LL = 14;
    private const int WM_MBUTTONDOWN = 0x0207;

    private static IntPtr hookId = IntPtr.Zero;
    private static LowLevelMouseProc proc = HookCallback;

    public event Action<Point, IntPtr> MiddleClick;

    private static MouseHook instance;

    public MouseHook()
    {
      instance = this;
    }

    public void Start()
    {
      if (hookId == IntPtr.Zero)
        hookId = SetHook(proc);
    }

    public void Stop()
    {
      if (hookId != IntPtr.Zero)
      {
        UnhookWindowsHookEx(hookId);
        hookId = IntPtr.Zero;
      }
    }

    private static IntPtr SetHook(LowLevelMouseProc proc)
    {
      using (Process curProcess = Process.GetCurrentProcess())
      using (ProcessModule curModule = curProcess.MainModule)
      {
        return SetWindowsHookEx(WH_MOUSE_LL, proc,
            GetModuleHandle(curModule.ModuleName), 0);
      }
    }

    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential)]
    private struct MSLLHOOKSTRUCT
    {
      public POINT pt;
      public int mouseData;
      public int flags;
      public int time;
      public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
      public int x;
      public int y;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern IntPtr WindowFromPoint(POINT pt);

    [DllImport("user32.dll")]
    private static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

    private const uint GA_ROOT = 2;

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
      if (nCode >= 0 && wParam == (IntPtr)WM_MBUTTONDOWN)
      {
        MSLLHOOKSTRUCT hookStruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
        POINT pt = hookStruct.pt;

        IntPtr hWnd = WindowFromPoint(pt);
        if (hWnd != IntPtr.Zero)
        {
          // Obtener ventana raíz (no solo el control hijo)
          hWnd = GetAncestor(hWnd, GA_ROOT);
        }

        instance?.MiddleClick?.Invoke(
            new Point(pt.x, pt.y),
            hWnd
        );
      }

      return CallNextHookEx(hookId, nCode, wParam, lParam);
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
  }
}
