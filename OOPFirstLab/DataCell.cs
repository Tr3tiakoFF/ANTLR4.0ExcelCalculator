using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPFirstLab
{
    public class DataCell : DataGridViewTextBoxCell
    {
        public double Value { get; set; }
        public string Name { get; set; }
        public string Expression { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        private List<string> _cellsIDependOn = new List<string>();
        private List<string> _cellsDependentOnMe = new List<string>();
        
        public List<string> CellsIDependOn { get => _cellsIDependOn; set => _cellsIDependOn = value; }
        public List<string> CellsDependentOnMe { get => _cellsDependentOnMe; set => _cellsDependentOnMe = value; }

        public DataCell()
        {

        }
        public DataCell(string _name)
        {
            Name = _name;
        }
    }
}
