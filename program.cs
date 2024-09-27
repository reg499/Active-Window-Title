using System;
using System.Text;
using System.Runtime.InteropServices;

public class Programa
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


    public static string ObtenerTituloVentanaActiva()
    {
        try
        {
            const int nChars = 256;
            StringBuilder buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();
            if (GetWindowText(handle, buff, nChars) > 0)
            {
                return buff.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        return "";
    }

    public static void Main()
    {
        string tituloVentanaActiva = ObtenerTituloVentanaActiva();
        Console.WriteLine("Título de la ventana activa: " + tituloVentanaActiva);
    }
}
