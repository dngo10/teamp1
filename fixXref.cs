using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixXref_File1
{
    public class fixXref
    {

        [CommandMethod("fixXref")]
        public void checkFile()
        {
            
            string fileName = @"G:\65038\SITE PLOT\520_N_Formosa-PLAN_20-Spanish\5038_PLAN 20 - SP_520_N_Formosa.dwg";
            Directory.SetCurrentDirectory(Path.GetDirectoryName(fileName));
            Database db = new Database();
            db.ReadDwgFile(fileName, FileOpenMode.OpenForReadAndAllShare, true, "");

            XrefGraph xg = db.GetHostDwgXrefGraph(true);
            GraphNode root = xg.RootNode;
            List<XrefDetails> xrefList = new List<XrefDetails>();
            using(Transaction tr = db.TransactionManager.StartTransaction())
            {
                
                for (int i = 0; i < root.NumOut; i++)
                {
                    XrefDetails xrefDetails = new XrefDetails();
                    XrefGraphNode child = (XrefGraphNode)root.Out(i);

                    xrefDetails.name = child.Name;
                    xrefDetails.isNested = child.IsNested;
                    xrefDetails.status = child.XrefStatus;

                    if (child.XrefStatus  != XrefStatus.NotAnXref)
                    {
                        BlockTableRecord btr = (BlockTableRecord)tr.GetObject(child.BlockTableRecordId, OpenMode.ForWrite);
                        xrefDetails.relativePathName = btr.PathName;
                        xrefDetails.fullPathName = Path.GetFullPath(btr.PathName);
                    }
                    xrefList.Add(xrefDetails);
                }
            }
        }
    }

    public class XrefDetails
    {
        public string name;
        public string relativePathName;
        public string fullPathName;
        public XrefStatus status;
        public bool isNested;
        public string xrefileName;
    }

    public class InputDetails
    {
        public string newLocation;
        public string oldLocation;
        public string accorePath;
        public string dllPath;
        public string command;
    }
}
