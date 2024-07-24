using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace engRevitAddin
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class NewAddIn : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            try
            {
                var view = doc.ActiveView;
                var viewName = view.Name;
                var viewId = view.Id;
                var viewTemplateId = view.ViewTemplateId;
                var viewTemplate = viewTemplateId.ToString() == "-1" ? "No Template" : doc.GetElement(viewTemplateId).Name;

                MainWindow mainWindow = new MainWindow(uidoc);
                mainWindow.ShowDialog();

                return Result.Succeeded;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }
    }
}
