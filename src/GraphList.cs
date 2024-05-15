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

        public GraphList() 
        { 
        
        }

        public void Add(Graph graph)
        {
            this._grapheneList.Add(graph);
        }

        public void DrawGraphene(Canvas canvas)
        {
            for (int i = 0; i < this._grapheneList.Count; i++)
            {
                this._grapheneList[i].DrawGraph(canvas);
            }
        }

    }
}
