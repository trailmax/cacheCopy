using System;
using System.Windows.Forms;

namespace cacheCopy
{
    /// <summary>
    /// 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            // auto-generated
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                 //create the core of the application
                Core core = new Core();

                // create GUI for the application, giving reference to core
                MainGUI gui = new MainGUI(ref core);

                FirefoxHelper firefox = new FirefoxHelper();
                gui.addProfile(firefox.getProfiles());

                ChromeHelper chrome = new ChromeHelper();
                gui.addProfile(chrome.getProfiles());

                ChromiumHelper chromium = new ChromiumHelper();
                gui.addProfile(chromium.getProfiles());

                IEHelper explorer = new IEHelper();
                gui.addProfile(explorer.getProfiles());

                OperaHelper opera = new OperaHelper();
                gui.addProfile(opera.getProfiles());


                // provide core with reference to GUI object
                core.setMainGUI(ref gui);

                Application.Run(gui);
            }
            catch (Exception e)
            {
                Util.WriteToLogFile(e);
            }

        }


    }
}
