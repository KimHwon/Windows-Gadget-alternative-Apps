using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace GadgetAlternativeApps
{
    public static class GadgetManager
    {
        private static string _filePath;
        private static List<GadgetInfo> _gadgetInfoList;
        private static Dictionary<int, GadgetForm> _gadgetFormList;

        public static void Init()
        {
            _gadgetInfoList = new List<GadgetInfo>();
            _gadgetFormList = new Dictionary<int, GadgetForm>();

            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GadgetAlternativeApps", "GadgetData.dat");
            try
            {
                var dataList = File.ReadLines(_filePath);

                foreach (var data in dataList)
                {
                    string[] spData = data.Split('=');
                    addGadget(spData[0]);

                    setGadgetPositionAt(_gadgetInfoList.Count - 1, int.Parse(spData[2]), int.Parse(spData[3]));
                    setGadgetActivationAt(_gadgetInfoList.Count - 1, bool.Parse(spData[1]));
                }
            }
            catch { }
        }
        public static void Close()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var gInfo in _gadgetInfoList)
            {
                sb.AppendFormat("{0}={1}={2}={3}\n", gInfo.rootDir, gInfo.isActived, gInfo.X, gInfo.Y);
            }

            try
            {
                if (!Directory.Exists(_filePath))
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GadgetAlternativeApps"));
                }

                File.WriteAllText(_filePath, sb.ToString());
            }
            catch { }
        }

        public static bool addGadget(string dirPath)
        {
            XmlDocument menifestXml;
            GadgetInfo gadgetInfo = new GadgetInfo();
            try
            {
                gadgetInfo.rootDir = dirPath;

                menifestXml = new XmlDocument();
                menifestXml.Load(Path.Combine(dirPath, "Gadget.xml"));

                XmlNode gadgetNode = menifestXml.SelectSingleNode("gadget");

                gadgetInfo.name = gadgetNode.SelectSingleNode("name").InnerText;
                gadgetInfo.version = gadgetNode.SelectSingleNode("version").InnerText;
                string absolutePath = gadgetNode.SelectSingleNode("base").Attributes.GetNamedItem("src").Value;
                if (!Path.IsPathRooted(absolutePath))
                {
                    absolutePath = Path.Combine(dirPath, absolutePath);
                }
                gadgetInfo.htmlPath = absolutePath;

                try
                {
                    XmlNode authorNode = gadgetNode.SelectSingleNode("author");
                    gadgetInfo.autherInfo.name = authorNode.Attributes.GetNamedItem("name").Value;

                    try
                    {
                        gadgetInfo.autherInfo.infoUrl = authorNode.SelectSingleNode("info").Attributes.GetNamedItem("url").Value;
                    }
                    catch { }
                    try
                    {
                        string absoluteSrc = authorNode.SelectSingleNode("logo").Attributes.GetNamedItem("src").Value;
                        if (!Path.IsPathRooted(absoluteSrc))
                        {
                            absoluteSrc = Path.Combine(dirPath, absoluteSrc);
                        }
                        gadgetInfo.autherInfo.logoIcon.src = absoluteSrc;
                    }
                    catch { }
                    try
                    {
                        gadgetInfo.autherInfo.logoIcon.height = float.Parse(authorNode.SelectSingleNode("logo").Attributes.GetNamedItem("height").Value);
                    }
                    catch { }
                    try
                    {
                        gadgetInfo.autherInfo.logoIcon.width = float.Parse(authorNode.SelectSingleNode("logo").Attributes.GetNamedItem("width").Value);
                    }
                    catch { }
                }
                catch { }

                try
                {
                    gadgetInfo.licence = gadgetNode.SelectSingleNode("copyright").InnerText;
                }
                catch { }

                try
                {
                    gadgetInfo.description = gadgetNode.SelectSingleNode("description").InnerText;
                }
                catch { }

                try
                {
                    XmlNode iconNode = gadgetNode.SelectSingleNode("icons").SelectSingleNode("icon");

                    try
                    {
                        string absoluteSrc = iconNode.Attributes.GetNamedItem("src").Value;
                        if (!Path.IsPathRooted(absoluteSrc))
                        {
                            absoluteSrc = Path.Combine(dirPath, absoluteSrc);
                        }
                        gadgetInfo.icon.src = absoluteSrc;
                    }
                    catch { }
                    try
                    {
                        gadgetInfo.icon.height = float.Parse(iconNode.Attributes.GetNamedItem("height").Value);
                    }
                    catch { }
                    try
                    {
                        gadgetInfo.icon.width = float.Parse(iconNode.Attributes.GetNamedItem("width").Value);
                    }
                    catch { }
                }
                catch { }

                try
                {
                    string absoluteSrc = gadgetNode.SelectSingleNode("defaultImage").Attributes.GetNamedItem("src").Value;
                    if (!Path.IsPathRooted(absoluteSrc))
                    {
                        absoluteSrc = Path.Combine(dirPath, absoluteSrc);
                    }
                    gadgetInfo.defaultImg.src = absoluteSrc;
                }
                catch { }
                try
                {
                    gadgetInfo.defaultImg.height = float.Parse(gadgetNode.SelectSingleNode("defaultImage").Attributes.GetNamedItem("height").Value);
                }
                catch { }
                try
                {
                    gadgetInfo.defaultImg.width = float.Parse(gadgetNode.SelectSingleNode("defaultImage").Attributes.GetNamedItem("width").Value);
                }
                catch { }

                gadgetInfo.isActived = false;
                gadgetInfo.X = 0;
                gadgetInfo.Y = 0;

                _gadgetInfoList.Add(gadgetInfo);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static int getGedgetCount()
        {
            return _gadgetInfoList.Count;
        }
        public static List<GadgetInfo> getGadgetInfoList()
        {
            return _gadgetInfoList;
        }
        public static GadgetInfo getGadgetInfoAt(int index)
        {
            return _gadgetInfoList[index];
        }
        public static GadgetInfo getLastGadgetInfo()
        {
            return _gadgetInfoList.Last();
        }

        public static void setGadgetActivationAt(int index, bool isActive)
        {
            GadgetInfo gInfo = _gadgetInfoList[index];
            gInfo.isActived = isActive;
            _gadgetInfoList[index] = gInfo;

            if (isActive && !_gadgetFormList.ContainsKey(index))
            {
                // Create
                _gadgetFormList.Add(index, new GadgetForm(index, gInfo.X, gInfo.Y));
                _gadgetFormList[index].Show();
            }
            else if (!isActive && _gadgetFormList.ContainsKey(index))
            {
                // Delete
                _gadgetFormList[index].Close();
                _gadgetFormList.Remove(index);
            }
        }
        public static void setGadgetPositionAt(int index, int posX, int posY)
        {
            GadgetInfo gInfo = _gadgetInfoList[index];
            gInfo.X = posX;
            gInfo.Y = posY;
            _gadgetInfoList[index] = gInfo;
        }
    }
}
