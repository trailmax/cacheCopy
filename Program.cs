// for release - remove the debug
using System;
using System.Windows.Forms;
using Homegrown.Updater;


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
#if !DEBUG
            try
            {
#endif
                 //create the core of the application
                Core core = new Core();

                // create GUI for the application, giving reference to core
                MainGUI gui = new MainGUI(ref core);

                FirefoxHelper firefox = new FirefoxHelper();
                gui.AddProfile(firefox.getProfiles());

                ChromeHelper chrome = new ChromeHelper();
                gui.AddProfile(chrome.getProfiles());

                ChromiumHelper chromium = new ChromiumHelper();
                gui.AddProfile(chromium.getProfiles());

                IEHelper explorer = new IEHelper();
                gui.AddProfile(explorer.getProfiles());

                OperaHelper opera = new OperaHelper();
                gui.AddProfile(opera.getProfiles());


                // provide core with reference to GUI object
                core.setMainGUI(ref gui);

                // create the application bridge for the updater - decoupling layer
                IApplicationUpdaterBridge application = new cacheCopyUpdaterBridge();

                // new updater, pass references for gui and application.
                IUpdater updater = new Updater((IMessagingGui)gui, application);
                gui.SetUpdater(ref updater);
                
                Application.Run(gui);

#if !DEBUG
            }
            catch (Exception e)
            {
                Util.WriteToLogFile(e);
            }
#endif

        }


    }
}
