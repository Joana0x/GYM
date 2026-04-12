using System;
using System.Windows.Forms;
using GYM_NoSql;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new GYM_NoSql.FormMenu());


    }

}
