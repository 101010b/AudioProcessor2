using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor
{
    public class XMLDataFile
    {

        string fileName;
        StreamWriter file;

        List<string> xmlgroup;
        
        public XMLDataFile(String _fileName)
        {
            fileName = _fileName;
            file = new StreamWriter(fileName);
            xmlgroup = new List<string>();
            startGroup("root");
        }

        public string offset()
        {
            string rv = "";
            for (int i = 0; i < xmlgroup.Count; i++)
                rv += "\t";
            return rv;
        }

        public void writeString(string name, string value)
        {
            file.WriteLine(String.Format("{0}<{1}>\"{2}\"</{3}>", offset(), name, value, name));
        }

        public void writeNumeric(string name, int value)
        {
            file.WriteLine(String.Format("{0}<{1}>{2}</{3}>", offset(), name, value, name));
        }

        public void writeNumeric(string name, double value)
        {
            file.WriteLine(String.Format("{0}<{1}>{2}</{3}>", offset(), name, value, name));
        }

        public void writeNumericArray(string name, double[] value)
        {
            file.Write(String.Format("{0}<{1}>[",offset(), name));
            int linecount = 10;
            for (int i = 0;i<value.Length;i++)
            {
                if (i == value.Length - 1)
                    file.Write(String.Format("{0}]", value[i]));
                else
                    file.Write(String.Format("{0},", value[i]));
                linecount--;
                if (linecount == 0)
                {
//                    file.WriteLine();
//                    file.Write(String.Format("{0}\t", offset()));
                    linecount = 10;
                }
            }
            file.WriteLine();
            file.WriteLine(String.Format("{0}</{1}>", offset(), name));
        }

        public void startGroup(string name)
        {
            file.WriteLine(String.Format("{0}<{1}>",offset(),name));
            xmlgroup.Add(name);
        }

        public void closeGroup()
        {
            string name = xmlgroup.Last();
            xmlgroup.RemoveAt(xmlgroup.Count-1);
            file.WriteLine(String.Format("{0}</{1}>", offset(), name));
        }

        public void close()
        {
            while (xmlgroup.Count > 0)
                closeGroup();
            file.Close();
            file = null;
        }
        


    }
}
