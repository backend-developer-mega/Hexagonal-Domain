using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    class Class1
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        static Thread BackgroundTask;

        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de microservicio");
            Console.ReadLine();
            BackgroundTask = new Thread(UnityTest);
            BackgroundTask.IsBackground = true;
            BackgroundTask.Start();
            Console.WriteLine("...");
            Console.ReadLine();
        }

        private static void UnityTest()
        {
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(3000);
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                mouse_event(0x02 | 0x04, x, y, 0, 0);
            }
        }
    }
}
