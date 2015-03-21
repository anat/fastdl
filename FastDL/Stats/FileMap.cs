using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using System.Drawing;

namespace FastDL.Stats
{

    public class FileMap
    {
        public Bitmap stats = new Bitmap(700, 30);

        private Graphics g;
        // Classe qui permet l'affichage du graphique d'état de téléchargement

        public FileMap()
        {
            g = Graphics.FromImage(stats);
            g.FillRectangle(Brushes.Azure, new RectangleF(0, 0, stats.Width, stats.Height));
        }


        public void update(List<FastDL.DB.DBChunk> dbc)
        {
            List<RectangleF> coords = new List<RectangleF>();
            //Try

            //g.FillRectangle(Brushes.Azure, New RectangleF(0, 0, stats.Width, stats.Height))
            foreach (FastDL.DB.DBChunk db in dbc)
            {
                float x = 0;
                float y = 0;
                float width = 0;
                float height = 0;

                x = getWidth(db.start_byte, db.dbd.size);
                y = 0;
                width = getWidth(db.current_byte - db.start_byte, db.dbd.size);
                height = stats.Height;

                RectangleF rec = new RectangleF(x, y, width, height);
                coords.Add(rec);
            }
            g.FillRectangles(Brushes.BlueViolet, coords.ToArray());
            //Catch ex As Exception
            //    MsgBox(ex.Message)
            //    Application.Exit()
            //End Try
        }

        public long getWidth(long relativeWidth, long totalWidth)
        {
            return (relativeWidth * stats.Width) / totalWidth;
        }


    }

}
