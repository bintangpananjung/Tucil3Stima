using System;
using System.Collections.Generic;
using System.Text;

namespace TucilStima3
{
    class NodeSumCost
    {
        public Node tempNode;
        public double sumCost;
        public NodeSumCost(Node tempNode, double sumCost)
        {
            this.tempNode = tempNode;
            this.sumCost = sumCost;
        }
    }
}
