using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;

namespace andrea_svg
{
    public class SVG_xml_file
    {
        public List<SVG_d>[] ds;
        public SVG_rec[] qq;
        public SVG_xml_file(string filesvg)
        {
            XmlDocument aa = new XmlDocument();
            aa.Load(filesvg);
            XmlNodeList pl = aa.DocumentElement.GetElementsByTagName("path");
            ds= new List<SVG_d>[pl.Count];
            qq= new SVG_rec[pl.Count];
            int c=0;
            foreach (XmlElement eee in pl)
            {
                ds[c] = new List<SVG_d>();
                SVG_d.ReadSVG_d_attribute(ds[c],eee.GetAttribute("d"),eee.GetAttribute("transform"));
                qq[c] = SVG_d.GetLen(ds[c]);               
                c++;
            }
        }

        public void Save(string nf)
        {
            StreamWriter sw =new StreamWriter(nf);
            sw.WriteLine("<svg style=\"fill:none;stroke-width:0.5;stroke-linecap:round;stroke-linejoin:round;stroke:rgb(0%,0%,0%);stroke-opacity:1;stroke-miterlimit:10;\" >");
            for (int a = 0; a < ds.Length; a++)
            {              
                sw.WriteLine("<path d=\""+SVG_d.UpdateSVG_d_attribute(ds[a])+"\"/>");                    
            }
            sw.WriteLine("</svg>");
            sw.Flush();
            sw.Close();
        }

        public static void Save(string nf,List<SVG_d> ds)
        {
            StreamWriter sw =new StreamWriter(nf);
            sw.WriteLine("<svg style=\"fill:none;stroke-width:0.5;stroke-linecap:round;stroke-linejoin:round;stroke:rgb(0%,0%,0%);stroke-opacity:1;stroke-miterlimit:10;\" >");
            sw.WriteLine("<path d=\""+SVG_d.UpdateSVG_d_attribute(ds)+"\"/>");                    
            sw.WriteLine("</svg>");
            sw.Flush();
            sw.Close();
        }
    }
}