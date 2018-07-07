using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiMFa_Framework.Component.WinForm.Data
{
    public delegate void ValueEventHandler(DataCell cell, object value);
    public partial class DataCell : TextBox
    {
        public event ValueEventHandler ValueChanged = (cell, value) => { };
        public object Value { get { return Text; } set { Text = value + ""; } }

        public bool IsUpdating = false;
        public bool IsChanged = false;
        public bool IsSelected = false;

        public string Label { get; set; } = "";
        public int ColumnIndex { get; private set; } = -1;
        public int RowIndex { get; private set; } = -1;
        public DataTable OwnerTable { get; private set; } = null;
        public DataColumn OwningColumn => ColumnIndex < 0 ? null : OwnerTable.Columns[ColumnIndex];
        public DataRow OwningRow => RowIndex < 0 ? null : OwnerTable.Rows[RowIndex];

        public DataCell() : base()
        {
            InitializeComponent();
            Default();
        }
        public DataCell(DataCell dataCell) : base()
        {
            InitializeComponent();
            Default();
            Set(dataCell.OwnerTable, dataCell.RowIndex, dataCell.ColumnIndex, dataCell.Label);
        }
        public DataCell(DataTable ownerTable, int rowIndex, int colIndex,string label) : base()
        {
            InitializeComponent();
            Default();
            Set(ownerTable, rowIndex, colIndex,label);
        }

        public void Set(DataTable ownerTable, int rowIndex, int colIndex,string label)
        {
            IsUpdating = true;
            IsChanged = false;
            IsSelected = false;
            OwnerTable = ownerTable;
            RowIndex = rowIndex;
            ColumnIndex = colIndex;
            Label = label;
            Value = (rowIndex < 0 || colIndex < 0) ? null : ownerTable.Rows[rowIndex][colIndex];
            IsUpdating = false;
        }
        public void Set(DataTable ownerTable, int rowIndex, int colIndex)
        {
            IsUpdating = true;
            IsChanged = false;
            OwnerTable = ownerTable;
            RowIndex = rowIndex;
            ColumnIndex = colIndex;
            Value = (rowIndex < 0 || colIndex < 0) ? null : ownerTable.Rows[rowIndex][colIndex];
            IsUpdating = false;
        }

        internal void Default()
        {
            Margin = new Padding(0);
            Multiline = true;
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
            TextChanged += (s, a) => { if (IsChanged = !IsUpdating) ValueChanged(this, OwnerTable.Rows[RowIndex][ColumnIndex] = Value); };
        }
    }
}
