using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Windows.Media.Imaging;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace BindLinkElements
{
    public class App : IExternalApplication
    {
        static void AddRibbonPanel(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Link Elements");

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;            
            PushButtonData b1Data = new PushButtonData("Copy", "Copy", thisAssemblyPath, "BindLinkElements.Copy");
            PushButton pb1 = ribbonPanel.AddItem(b1Data) as PushButton;
            pb1.ToolTip = "Copy Elements from Link Instances to current Document.";
            BitmapImage pb1Image = new BitmapImage(new Uri(thisAssemblyPath.Replace("BindLinkElements.dll", "") + "BindLinkElements.png"));
            pb1.LargeImage = pb1Image;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            AddRibbonPanel(application);

            return Result.Succeeded;
        }
    }
}
