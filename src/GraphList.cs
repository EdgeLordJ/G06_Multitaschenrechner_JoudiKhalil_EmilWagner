using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Multitaschenrechner
{
    public class GraphList
    {
        private new List<Graph> _grapheneList = new List<Graph>();

        private Brush[] _brushesArray = new Brush[] { Brushes.Blue, Brushes.Green, Brushes.Red, Brushes.AliceBlue, Brushes.Gray, Brushes.Pink, Brushes.Yellow, Brushes.Orange, Brushes.DarkBlue, Brushes.Cyan };

        private List<Brush> _usedBrushes = new List<Brush>();

        private int _rounds;
        public GraphList() 
        { 
        
        }

        public List<Graph> GetList()
        {
            return this._grapheneList;
        }
        public void Add(Graph graph)
        {

            if (this._grapheneList.Count < 10)
            {
                if (graph.Color == null)
                {
                    Brush newColor = this._brushesArray[this._rounds];


                    graph.Color = newColor;
                    this._usedBrushes.Add(graph.Color);
                    this._rounds++;

                }
                this._grapheneList.Add(graph);
                this._usedBrushes.Add(graph.Color);

            }
        }

        public void DrawGraphene(Canvas canvas, Label label, int scale)
        {
            
            for (int i = 0; i < this._grapheneList.Count; i++)
            {
                if (this._grapheneList[i].Function == null)
                {

                }
                else
                {
                    this._grapheneList[i].DrawGraph(canvas, scale);
                }
                
                
                
            }
        }

    }
}
