using OOPFirstLab.ANTLR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOPFirstLab.Forms
{
    public partial class FormExcel : Form
    {
        private void LoadTheme()
        {
            btnApply.BackColor = ThemeColor.PrimaryColor;
            btnApply.ForeColor = Color.White;
            btnApply.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnColumnAdd.BackColor = ThemeColor.PrimaryColor;
            btnColumnAdd.ForeColor = Color.White;
            btnColumnAdd.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            
            btnColumnDel.BackColor = ThemeColor.PrimaryColor;
            btnColumnDel.ForeColor = Color.White;
            btnColumnDel.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            
            btnRowAdd.BackColor = ThemeColor.PrimaryColor;
            btnRowAdd.ForeColor = Color.White;
            btnRowAdd.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnRowDel.BackColor = ThemeColor.PrimaryColor;
            btnRowDel.ForeColor = Color.White;
            btnRowDel.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            //lblEvaluateButton.ForeColor = ThemeColor.SecondaryColor;
            //lbResult.ForeColor = ThemeColor.SecondaryColor;
        }

        const int STARTING_MEASURES = 5;

        private Dictionary<string, DataCell> Dictionary = new Dictionary<string, DataCell>();

        private int _columnNumber = 0;
        private int _rowNumber = 0;

        public FormExcel()
        {
            InitializeComponent();

            openFileDialog.Filter = "Text files(*.txt)|*.txt.|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt.|All files(*.*)|*.*";

            CreateDataGridView(STARTING_MEASURES, STARTING_MEASURES);

            for (int i = 0; i < _rowNumber; i++)
            {
                for (int j = 0; j < _columnNumber; j++)
                {
                    string _cellName = SetCellName(i, j);
                    DataCell _dataCell = new DataCell(_cellName);
                    _dataCell.Value = 0;
                    _dataCell.Expression = "0";
                    _dataCell.Row = j;
                    _dataCell.Column = i;

                    Dictionary.Add(_cellName, _dataCell);
                }
            }
            
            AddressDependentUpdate();

            this.ActiveControl = dataGridView;
        }

        private void CreateDataGridView(int __columnNumber_, int __rowNumber_)
        {
            for(int i = 0; i < __columnNumber_; i++)
            {
                DataGridViewColumn _dgvColumn = new DataGridViewColumn();
                _dgvColumn.HeaderCell.Value = SetColumnName(i);

                DataCell _dgvColumnCell = new DataCell();
                _dgvColumn.CellTemplate = _dgvColumnCell;

                dataGridView.Columns.Add(_dgvColumn);

                _columnNumber++;
            }

            for(int i = 0; i < __rowNumber_; i++)
            {
                DataGridViewRow _dgvRow = new DataGridViewRow();
                _dgvRow.HeaderCell.Value = i.ToString();
                
                dataGridView.Rows.Add(_dgvRow);

                _rowNumber++;
            }
        }

        public string SetColumnName(int __coumnNumber_)
        {
            const int _alphabet = 26;
            string name = "";

            if(__coumnNumber_ < _alphabet)
            {
                return name + (char)(__coumnNumber_ + 65);
            }

            for(int i = __coumnNumber_; i >= _alphabet; i /= _alphabet)
            {
                int _mod = __coumnNumber_ % _alphabet;
                int _div = __coumnNumber_ / _alphabet;

                name += (char)(_div - 1 + 65);

                if(_div < _alphabet)
                {
                    name += (char)(_mod + 65);
                }
            }

            return name;
        }

        public string SetCellName(int __columnNumber_, int __rowNumber_)
        {
            return SetColumnName(__columnNumber_) + __rowNumber_;
        }

        private void SetCell(string _cellName)
        {
            Dictionary[_cellName].Expression = textBox.Text;
        }

        private void RefreshAllCells()
        {
            AddressDependentUpdate();

            foreach (string _cellName in Dictionary.Keys)
            {
                if (ReccurenceCheck(Dictionary[_cellName]))
                {
                    MessageBox.Show("Reccurence has been found! " +
                        "\nClearing cells");
                    List<string> _reccurenceList = new List<string>();
                    ReccurenceSearch(_cellName, _cellName, ref _reccurenceList);

                    foreach(string __cellName_ in _reccurenceList)
                    {
                        Dictionary[__cellName_].Value = 0;
                        Dictionary[__cellName_].Expression = "0";
                        Dictionary[__cellName_].CellsIDependOn.Clear();
                        Dictionary[__cellName_].CellsDependentOnMe.Clear();
                        dataGridView[Dictionary[__cellName_].Column, Dictionary[__cellName_].Row].Value = null;
                    }
                }

                Dictionary[_cellName].Value = Calculator.Evaluate(Dictionary[_cellName].Expression, Dictionary);
                if(Dictionary[_cellName].Expression == "0")
                {
                    dataGridView[Dictionary[_cellName].Column, Dictionary[_cellName].Row].Value = "";
                }
                else
                {
                    dataGridView[Dictionary[_cellName].Column, Dictionary[_cellName].Row].Value = Dictionary[_cellName].Value;
                }
            }
        }

        private void ReccurenceSearch(string _cellName, string _finalCell, ref List<string> _reccurenceList)
        {
            if (Dictionary[_cellName].CellsIDependOn.Contains(_finalCell))
            {
                _reccurenceList.Add(_cellName);
                if (!_reccurenceList.Contains(_finalCell))
                {
                    _reccurenceList.Add(_finalCell);
                }
                return;
            }
            foreach (string __cellName_ in Dictionary[_cellName].CellsIDependOn)
            {
                if (ReccurenceCheck(Dictionary[__cellName_]))
                {
                    _reccurenceList.Add(__cellName_);
                    ReccurenceSearch(__cellName_, _finalCell, ref _reccurenceList);
                }
            }
        }

        /*private void RefreshDependentCells(string _cellName)
        {
            foreach(string __cellName_ in Dictionary[_cellName].CellsDependentOnMe)
            {
                if (ReccurenceCheck(Dictionary[__cellName_]))
                {

                }

                Dictionary[__cellName_].Value = Calculator.Evaluate(Dictionary[__cellName_].Expression, Dictionary);

                dataGridView[Dictionary[__cellName_].Column, Dictionary[__cellName_].Row].Value = Dictionary[__cellName_].Value;

                RefreshDependentCells(_cellName);
            }
        }*/

        public bool ReccurenceCheck(DataCell _currentCell)
        {
            return RecurrencePathCheck(_currentCell, _currentCell);
        }

        public bool RecurrencePathCheck(DataCell _currentCell, DataCell _initialCell)
        {
            if (_currentCell.CellsIDependOn.Contains(_initialCell.Name))
            {
                return true;
            }
            foreach(string _cellName in _currentCell.CellsIDependOn)
            {
                if(RecurrencePathCheck(Dictionary[_cellName], _initialCell))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow _dgvRow = new DataGridViewRow();
            _dgvRow.HeaderCell.Value = _rowNumber.ToString();
           
            dataGridView.Rows.Add(_dgvRow);

            for(int i = 0; i < _columnNumber; i++)
            {
                string _cellName = SetCellName(i, _rowNumber);
                DataCell _dataCell = new DataCell(_cellName);
                _dataCell.Value = 0;
                _dataCell.Expression = "0";
                _dataCell.Column = i;
                _dataCell.Row = _rowNumber;

                Dictionary.Add(_cellName, _dataCell);
            }
            
            _rowNumber++;
        }

        private void btnColumnAdd_Click(object sender, EventArgs e)
        {
            DataGridViewColumn _dgvColumn = new DataGridViewColumn();
            _dgvColumn.HeaderCell.Value = SetColumnName(_columnNumber);

            DataCell _dgvColumnCell = new DataCell();
            _dgvColumn.CellTemplate = _dgvColumnCell;
            
            dataGridView.Columns.Add(_dgvColumn);

            for (int i = 0; i < _rowNumber; i++)
            {
                string _cellName = SetCellName(_columnNumber , i);
                DataCell _dataCell = new DataCell(_cellName);
                _dataCell.Value = 0;
                _dataCell.Expression = "0";
                _dataCell.Column = _columnNumber;
                _dataCell.Row = i;

                Dictionary.Add(_cellName, _dataCell);
            }

            _columnNumber++;
        }
        
        private void btnRowDel_Click(object sender, EventArgs e)
        {
            if(_rowNumber == 1)
            {
                MessageBox.Show("Whoops..." +
                    "\nYou are trying do delete the last row." +
                    "\nUnable to delete this one.");
                return;
            }

            int _indentifier = _rowNumber - 1;
            for(int i = 0; i < _columnNumber; i++)
            {
                if(Dictionary[SetCellName(i, _indentifier)].CellsDependentOnMe.Count != 0)
                {
                    foreach(string _str in Dictionary[SetCellName(i, _indentifier)].CellsDependentOnMe)
                    {
                        Debug.WriteLine(_str);
                    }
                    MessageBox.Show("Some cells in the row may have dependecies." +
                        "\nUnable to delete this one.");
                    return;
                }
            }

            for(int i = 0; i < _columnNumber; i++)
            {
                string _dataCellName = SetCellName(i, _indentifier);
                Dictionary.Remove(_dataCellName);
            }

            dataGridView.Rows.RemoveAt(_indentifier);

            _rowNumber--;
        }

        private void btnColumnDel_Click(object sender, EventArgs e)
        {
            if (_columnNumber == 1)
            {
                MessageBox.Show("Whoops..." +
                    "\nYou are trying do delete the last colunm." +
                    "\nUnable to delete this one.");
                return;
            }

            int _indentifier = _columnNumber - 1;
            for (int i = 0; i < _rowNumber; i++)
            {
                if (Dictionary[SetCellName(_indentifier, i)].CellsDependentOnMe.Count != 0)
                {
                    foreach (string _str in Dictionary[SetCellName(_indentifier, i)].CellsDependentOnMe)
                    {
                        Debug.WriteLine(_str);
                    }
                    MessageBox.Show("Some cells in the colunm may have dependecies." +
                        "\nUnable to delete this one.");
                    return;
                }
            }

            for (int i = 0; i < _rowNumber; i++)
            {
                string _dataCellName = SetCellName(_indentifier, i);
                Dictionary.Remove(_dataCellName);
            }

            dataGridView.Columns.RemoveAt(_indentifier);

            _columnNumber--;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SetCell(SetCellName(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex));
            //RefreshDependentCells(SetCellName(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex));
            RefreshAllCells();
        }


        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(Dictionary[SetCellName(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex)].Expression == "0")
            {
                textBox.ResetText();
            }
            else
            {
                textBox.Text = Dictionary[SetCellName(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex)].Expression;
            }
        }

        private void FormExcel_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void AddressDependentUpdate()
        {
            foreach(string _cellName in Dictionary.Keys)
            {
                foreach(string __cellName_ in Dictionary.Keys)
                {
                    if(AddressPresence(Dictionary[_cellName], __cellName_))
                    {
                        Dictionary[_cellName].CellsIDependOn.Add(__cellName_);
                        Debug.WriteLine(_cellName + "->" + __cellName_);
                        Dictionary[__cellName_].CellsDependentOnMe.Add(_cellName);
                    }
                }
            }
        }

        private bool AddressPresence(DataCell _dataCell, string _adress)
        {
            return _dataCell.Expression.Contains(_adress);
        }

        /*        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            textBox.Text = "XXX";

            if(Char.IsLetter((char)e.KeyValue) || Char.IsNumber((char)e.KeyValue))
            {
                if(textBox.Text == "0")
                {
                    textBox.Clear();
                }

                textBox.Text += (char)e.KeyValue;
                dataGridView.CurrentCell.Value = textBox.Text;
                this.ActiveControl = textBox;
                textBox.Focus();
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            string _cellName = SetCellName(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex);

            SetCell(_cellName);
            RefreshCells(_cellName);
        }*/
    }
}
