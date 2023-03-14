using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class PathFinderForm : Form
    {
        private Network? network;

        public PathFinderForm()
        {
            InitializeComponent();
        }
        public PathFinderForm(Network network)
        {
            InitializeComponent();
            this.network = network;
        }
    }
}
