using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class GraphList
    {
        private new List<Graph> _grapheneList = new List<Graph>();

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
