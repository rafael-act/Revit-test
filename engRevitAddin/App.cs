using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace engRevitAddin
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string path = System.IO.Path.GetDirectoryName(assemblyName);

            //creating tab
            string tabName = "Parameters";
            application.CreateRibbonTab(tabName);

            //creating a panel
            RibbonPanel engPanel = application.CreateRibbonPanel(tabName,"EngPanel");

            //creating button 
            PushButtonData btnParameterScanner = new PushButtonData("Parameter Scanner", "Parameter Scanner", assemblyName, "engRevitAddin.NewAddIn");

            btnParameterScanner.LargeImage = new BitmapImage(new System.Uri(path+@"\icon.png"));

            engPanel.AddItem(btnParameterScanner);

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Failed;
        }

      
    }
}
