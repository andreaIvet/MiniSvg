using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace andrea_svg
{

    public class SVG_Form_outDriver : SVG_outDriver
    {
        private Graphics gr;
        private Pen pen =new Pen(Brushes.Black,1F);
        public void DrawPatch(List<SVG_d>[] ds,Bitmap bmp)
        {           
            gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White,0,0,bmp.Width,bmp.Height);
            for(int c=0;c<ds.Length;c++)
            {
                Draw(ds[c]);
            }
            gr.Dispose();
        }

        public void DrawPatch(List<SVG_d> ds,Bitmap bmp,Rectangle r)
        {
            Bitmap bmpi = new Bitmap(r.Width,r.Height);
            Graphics mgr = Graphics.FromImage(bmp);
            gr = Graphics.FromImage(bmpi);
            gr.FillRectangle(Brushes.White,0,0,r.Width,r.Height);
            Draw(ds);
            gr.Dispose();
            mgr.DrawImage(bmpi,new Point(r.Left,r.Top));
            mgr.Dispose();
        }
        
        public override void BezierTo(double x, double y, double cx1, double cy1, double cx2, double cy2)
        {            
            gr.DrawBezier(pen,new PointF((float)xp, (float)yp),new PointF((float)cx1, (float)cy1),new PointF((float)cx1, (float)cy1),new PointF((float)x, (float)y));   
        }

        public override void BezierTo(double x, double y, double cx, double cy)
        {
            throw new Exception("not imp.");
        }

        public override void LineTo(double x, double y)
        {
            gr.DrawLine(pen,new PointF((float)xp,(float)yp),new PointF((float)x,(float)y));
        }

        public override void BeginFigure(double x, double y)
        {            
        }

        public override void CloseFigure()
        {            
        }
    }
}
