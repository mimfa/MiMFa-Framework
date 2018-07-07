using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiMFa_Framework.Model;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Animate;
using System.Threading;

namespace MiMFa_Framework.Component.WinForm.Data
{
    public delegate void TableEventHandler(DataGridView dgv, DataTable table);
    public delegate void ColumnEventHandler(DataGridView dgv, DataColumn col);
    public delegate void RowEventHandler(DataGridView dgv, DataRow row);
    public delegate void CellEventHandler(DataGridView dgv, DataCell cell);
    public partial class DataGridView : UserControl
    {
        #region Field
        protected MiMFa_ObjectMoveOrResize OBJECTMOR = new MiMFa_ObjectMoveOrResize();

        private Dictionary<Point, bool> SelectedDic = new Dictionary<Point, bool>();
        public bool IsUpdating = false;
        public bool IsValueChanged = false;
        public bool IsTableFocuced = false;
        public bool IsHHeaderFocuced = false;
        public bool IsVHeaderFocuced = false;
        #endregion

        #region Property
        [CategoryAttribute()]
        public event ColumnEventHandler ColumnSelectionChanged = (dgv, oldCol) => { };
        public event RowEventHandler RowSelectionChanged = (dgv, oldRow) => { };
        public event CellEventHandler CellSelectionChanged = (dgv, oldCel) => { };
        public event TableEventHandler TableValueChanged = (dgv, table) => { };
        public event TableEventHandler TableValuesChanged = (dgv, table) => { };
        public event ColumnEventHandler ColumnValuesChanged = (dgv, col) => { };
        public event ColumnEventHandler ColumnAdded = (dgv, col) => { };
        public event ColumnEventHandler ColumnRemoved = (dgv, col) => { };
        public event RowEventHandler RowValuesChanged = (dgv, row) => { };
        public event RowEventHandler RowAdded = (dgv, row) => { };
        public event RowEventHandler RowRemoved = (dgv, row) => { };
        public event CellEventHandler CellValueChanged = (dgv, cel) => { };
        public event CellEventHandler CurrentCellValueChanged = (dgv, cel) => { };
        public new event ScrollEventHandler Scroll = (dgv, cel) => { };

        public MiMFa_Table Table = new MiMFa_Table();
        public DataRowCollection Rows => Table.MainTable.Rows;
        public DataColumnCollection Columns => Table.MainTable.Columns;

        public DataTable CurrentTable => Table.MainTable;
        public object CurrentValue => CurrentCell.ColumnIndex < 0 || CurrentCell.RowIndex < 0 ? null : Table.MainTable.Rows[CurrentCell.RowIndex][CurrentCell.ColumnIndex];
        public DataCell PreviousCell { get; private set; } = null;
        public DataCell CurrentCell { get; private set; } = null;
        public DataRow CurrentRow => CurrentCell.OwningRow;
        public DataColumn CurrentColumn => CurrentCell.OwningColumn;
        public int CurrentRowIndex => CurrentCell.RowIndex;
        public int CurrentColumnIndex => CurrentCell.ColumnIndex;


        private int _RowsHeight = 20;
        public virtual int RowsHeight
        {
            get { return _RowsHeight; }
            set
            {
                _RowsHeight = value;
                UpdateRows();
            }
        }
        private int _ColumnsWidth = 75;
        public virtual int ColumnsWidth
        {
            get { return _ColumnsWidth; }
            set
            {
                _ColumnsWidth = value;
                UpdateColumns();
            }
        }
        public virtual bool IsAlwaysShowScrollBars { get; set; } = false;
        private ScrollBars _ScrollBars = ScrollBars.Both;
        public virtual ScrollBars ScrollBars
        {
            get { return _ScrollBars; }
            set
            {
                _ScrollBars = value;
                UpdateStatus();
            }
        }

        public override bool Focused => IsHHeaderFocuced || IsVHeaderFocuced || IsTableFocuced;
        public virtual bool IsMultiSelect { get; set; } = false;
        public virtual bool IsReadOnly { get; set; } = false;


        public Func<int, string, int, Control> SetRowHeaderValue = (y, v, i) => new Control();
        public Func<int, string, int, Control> SetColumnHeaderValue = (y, v, i) => new Control();
        private ScrollBars _AutoHeaderValue = ScrollBars.None;
        public virtual ScrollBars AutoHeaderValue
        {
            get { return _AutoHeaderValue; }
            set
            {
                switch (_AutoHeaderValue = value)
                {
                    case ScrollBars.None:
                        SetRowHeaderValue = SetDataInRowHeader;
                        SetColumnHeaderValue = SetDataInColumnHeader;
                        break;
                    case ScrollBars.Horizontal:
                        SetRowHeaderValue = SetDataInRowHeader;
                        SetColumnHeaderValue = SetIndexInColumnHeader;
                        break;
                    case ScrollBars.Vertical:
                        SetRowHeaderValue = SetIndexInRowHeader;
                        SetColumnHeaderValue = SetDataInColumnHeader;
                        break;
                    case ScrollBars.Both:
                        SetRowHeaderValue = SetIndexInRowHeader;
                        SetColumnHeaderValue = SetIndexInColumnHeader;
                        break;
                }
            }
        }

        public virtual bool ShowColumnHeaderInTable { get; set; } = true;
        public virtual int ColumnsHeaderRowIndex { get; set; } = 0;
        public virtual TableLayoutPanelCellBorderStyle ColumnHeaderBorderStyle
        {
            get { return ColumnHeader.CellBorderStyle; }
            set { ColumnHeader.CellBorderStyle = value; }
        }
        public virtual bool ColumnHeaderVisible
        {
            get { return ColumnHeader.Visible; }
            set { ColumnHeader.Visible = value; }
        }
        public virtual Color ColumnHeaderBackColor { get { return ColumnHeader.BackColor; } set { ColumnHeader.BackColor = value; } }
        public virtual Color ColumnHeaderForeColor { get { return ColumnHeader.ForeColor; } set { ColumnHeader.ForeColor = value; } }
        public virtual Color SelectedColumnHeaderBackColor { get; set; } = Color.LightGray;
        public virtual Color SelectedColumnHeaderForeColor { get; set; } = Color.Black;
        public virtual int ColumnHeaderHeight { get; set; } = 25;

        public virtual int IDColumnIndex { get; set; } = 0;
        public virtual int IDRowIndex { get; set; } = -1;

        public virtual bool ShowRowHeaderInTable { get; set; } = true;
        public virtual int RowsHeaderColumnIndex { get; set; } = 1;
        public virtual TableLayoutPanelCellBorderStyle RowHeaderBorderStyle
        {
            get { return RowHeader.CellBorderStyle; }
            set { RowHeader.CellBorderStyle = value; }
        }
        public virtual bool RowHeaderVisible
        {
            get { return RowHeader.Visible; }
            set { RowHeader.Visible = value; }
        }
        public virtual Color RowHeaderBackColor { get { return RowHeader.BackColor; } set { RowHeader.BackColor = value; } }
        public virtual Color RowHeaderForeColor { get { return RowHeader.ForeColor; } set { RowHeader.ForeColor = value; } }
        public virtual Color SelectedRowHeaderBackColor { get; set; } = Color.LightGray;
        public virtual Color SelectedRowHeaderForeColor { get; set; } = Color.Black;
        public virtual int RowHeaderWidth { get; set; } = 50;

        public virtual TableLayoutPanelCellBorderStyle CellBorderStyle
        {
            get { return MainTable.CellBorderStyle; }
            set { MainTable.CellBorderStyle = value; }
        }
        public virtual Color CellBackColor { get; set; } = Color.White;
        public virtual Color CellForeColor { get; set; } = Color.DimGray;
        public virtual Color SelectedCellBackColor { get; set; } = Color.AliceBlue;
        public virtual Color SelectedCellForeColor { get; set; } = Color.Black;
        public List<DataCell> SelectedCells { get; private set; } = new List<DataCell>();
        public SortedDictionary<int, DataColumn> SelectedColumns { get; private set; } = new SortedDictionary<int, DataColumn>();
        public SortedDictionary<int, DataRow> SelectedRows { get; private set; } = new SortedDictionary<int, DataRow>();
        public bool AllowSearchBox { get { return Control_Search.Visible; } set { Control_Search.Visible = value; } }
        public DataGridViewAutoSizeRowsMode AutoSizeRowsMode { get; set; } = DataGridViewAutoSizeRowsMode.None;
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; } = DataGridViewAutoSizeColumnsMode.None;
        public DataGridViewTriState CellWrapMode { get; set; } = DataGridViewTriState.NotSet;
        #endregion

        #region Function
        public virtual void Bind(DataTable table)
        {
            Bind(new MiMFa_Table(table));
        }
        public virtual void Bind(MiMFa_Table table)
        {
            IsUpdating = true;
            Table = table;
            try
            {
                for (int r = 0; r < MainTable.RowCount; r++)
                    for (int c = 0; c < MainTable.ColumnCount; c++)
                        MainTable.GetControlFromPosition(c, r).Text = "";
                for (int r = 0; r < RowHeader.RowCount; r++)
                    for (int c = 0; c < RowHeader.ColumnCount; c++)
                        RowHeader.GetControlFromPosition(c, r).Text = "";
                for (int r = 0; r < ColumnHeader.RowCount; r++)
                    for (int c = 0; c < ColumnHeader.ColumnCount; c++)
                        ColumnHeader.GetControlFromPosition(c, r).Text = "";
            }
            catch { }
            VerticalScrollBar.Value = 0;
            HorizontalScrollBar.Value = 0;
            int rl = Math.Min(Table.MainTable.Rows.Count, VerticalScrollBar.Value + MainTable.RowCount);
            int cl = Math.Min(Table.MainTable.Columns.Count, HorizontalScrollBar.Value + MainTable.ColumnCount);
            VerticalScrollBar.Maximum = Table.Rows.Count - rl;
            HorizontalScrollBar.Maximum = Table.Columns.Count - cl;
            UpdateAll();
            IsUpdating = false;
            TableValueChanged(this,CurrentTable);
        }

        public virtual void UpdateAll()
        {
            IsUpdating = true;
            MainPanel.Visible = false;
            try
            {
                UpdateRows();
                UpdateColumns();
                UpdateHeaderControls();
                UpdateStatus();
                UpdateControls();
                UpdateTable();
            }
            catch { }
            MainPanel.Visible = true;
            IsUpdating = false;
        }
        public virtual void UpdateTable()
        {
            if (CurrentTable.Rows.Count < ColumnsHeaderRowIndex + 1 || CurrentTable.Columns.Count < RowsHeaderColumnIndex + 1) return;
            int rl = Math.Min(Table.MainTable.Rows.Count, VerticalScrollBar.Value + MainTable.RowCount);
            int maincl = Math.Min(Table.MainTable.Columns.Count, HorizontalScrollBar.Value + MainTable.ColumnCount);
            int rn = ShowColumnHeaderInTable && ColumnsHeaderRowIndex  > -1 ? 0 : ColumnsHeaderRowIndex > -1 ? 1 : 0;
            int cn = ShowRowHeaderInTable && RowsHeaderColumnIndex > -1 ? 0 : RowsHeaderColumnIndex > -1 ? 1 : 0;
            int row = 0;
            for (int r = VerticalScrollBar.Value; r < rl; r++)
            {
                if (r > IDRowIndex && r > ColumnsHeaderRowIndex)
                    SetRowHeaderValue(row, CurrentTable.Rows[r][RowsHeaderColumnIndex < 0 ? 0 : RowsHeaderColumnIndex] + "", r - rn);
                else if (r < IDRowIndex && r < ColumnsHeaderRowIndex)
                    SetRowHeaderValue(row, CurrentTable.Rows[r][RowsHeaderColumnIndex < 0 ? 0 : RowsHeaderColumnIndex] + "", r + 1);
                else if (r < IDRowIndex && r > ColumnsHeaderRowIndex)
                    SetRowHeaderValue(row, CurrentTable.Rows[r][RowsHeaderColumnIndex < 0 ? 0 : RowsHeaderColumnIndex] + "", r + 1 - rn);
                else if (r > IDRowIndex && r < ColumnsHeaderRowIndex)
                    SetRowHeaderValue(row, CurrentTable.Rows[r][RowsHeaderColumnIndex < 0 ? 0 : RowsHeaderColumnIndex] + "", r);
                else if (!ShowColumnHeaderInTable) { rl++; continue; }
                int col = 0;
                int cl = maincl;
                for (int c = HorizontalScrollBar.Value; c < cl; c++)
                {
                    DataCell dc = (DataCell)MainTable.GetControlFromPosition(col, row);
                    if (c > IDColumnIndex && c > RowsHeaderColumnIndex)
                        dc.Set(CurrentTable, r, c, SetColumnHeaderValue(col++, CurrentTable.Rows[ColumnsHeaderRowIndex < 0 ? 0 : ColumnsHeaderRowIndex][c] + "", c - cn).Text);
                    else if (c < IDColumnIndex && c < RowsHeaderColumnIndex)
                        dc.Set(CurrentTable, r, c, SetColumnHeaderValue(col++, CurrentTable.Rows[ColumnsHeaderRowIndex < 0 ? 0 : ColumnsHeaderRowIndex][c] + "", c + 1).Text);
                    else if (c < IDColumnIndex && c > RowsHeaderColumnIndex)
                        dc.Set(CurrentTable, r, c, SetColumnHeaderValue(col++, CurrentTable.Rows[ColumnsHeaderRowIndex < 0 ? 0 : ColumnsHeaderRowIndex][c] + "", c + 1 - cn).Text);
                    else if (c > IDColumnIndex && c < RowsHeaderColumnIndex)
                        dc.Set(CurrentTable, r, c, SetColumnHeaderValue(col++, CurrentTable.Rows[ColumnsHeaderRowIndex < 0 ? 0 : ColumnsHeaderRowIndex][c] + "", c).Text);
                    else if (!ShowRowHeaderInTable) { cl++; continue; }
                    if (dc.IsSelected = GetSelection(c, r))
                    {
                        dc.BackColor = SelectedCellBackColor;
                        dc.ForeColor = SelectedCellForeColor;
                    }
                    else
                    {
                        dc.BackColor = CellBackColor;
                        dc.ForeColor = CellForeColor;
                    }
                }
                row++;
            }
        }
        public void UpdateCell(int rowIndex, string colID)
        {
            UpdateCell(rowIndex,CurrentTable.Columns[colID].Ordinal);
        }
        public void UpdateCell(int rowIndex, int colIndex)
        {
            DataCell dc = GetCell(rowIndex,colIndex);
            dc.Set(CurrentTable, rowIndex, colIndex);
            if (GetSelection(colIndex, rowIndex))
            {
                dc.BackColor = SelectedCellBackColor;
                dc.ForeColor = SelectedCellForeColor;
            }
            else
            {
                dc.BackColor = CellBackColor;
                dc.ForeColor = CellForeColor;
            }
        }
        public virtual void UpdateStatus()
        {
            switch (_ScrollBars)
            {
                case ScrollBars.None:
                    HorizontalScrollBar.Visible =
                    VerticalScrollBar.Visible = false;
                    break;
                case ScrollBars.Horizontal:
                    HorizontalScrollBar.Visible = IsAlwaysShowScrollBars || HorizontalScrollBar.Maximum > MainTable.ColumnCount;
                    VerticalScrollBar.Visible = false;
                    break;
                case ScrollBars.Vertical:
                    VerticalScrollBar.Visible = IsAlwaysShowScrollBars || VerticalScrollBar.Maximum > MainTable.RowCount;
                    HorizontalScrollBar.Visible = false;
                    break;
                default:
                    HorizontalScrollBar.Visible = IsAlwaysShowScrollBars || HorizontalScrollBar.Maximum > MainTable.ColumnCount;
                    VerticalScrollBar.Visible = IsAlwaysShowScrollBars || VerticalScrollBar.Maximum > MainTable.RowCount;
                    break;
            }
        }
        public virtual void UpdateHeaderControls()
        {
            if (RowHeader.Controls.Count < RowHeader.RowCount)
                for (int r = RowHeader.Controls.Count - 1; r < RowHeader.RowCount; r++)
                {
                    Label box = new Label();
                    box.Margin = new Padding(0);
                    box.TextAlign = ContentAlignment.MiddleCenter;
                    box.AutoSize = false;
                    box.Dock = DockStyle.Fill;
                    int nr = r;
                    box.GotFocus += (s, e) =>
                    {
                        RowHeader.Controls[nr].BackColor = SelectedRowHeaderBackColor;
                        RowHeader.Controls[nr].ForeColor = SelectedRowHeaderForeColor;
                    };
                    box.MouseDown += RowHeader_Click;
                    RowHeader.Controls.Add(box, 0, r);
                }
            else for (int i = RowHeader.Controls.Count - 1; i >= 0; i--)
                {
                    TableLayoutPanelCellPosition tlcp = RowHeader.GetPositionFromControl(RowHeader.Controls[i]);
                    if ( tlcp.Row >= RowHeader.RowCount)
                        RowHeader.Controls.RemoveAt(i);
                }
            if (ColumnHeader.Controls.Count < ColumnHeader.ColumnCount)
                for (int c = ColumnHeader.Controls.Count-1; c < ColumnHeader.ColumnCount; c++)
                {
                    Label box = new Label();
                    box.Margin = new Padding(0);
                    box.TextAlign = ContentAlignment.MiddleCenter;
                    box.AutoSize = false;
                    box.Dock = DockStyle.Fill;
                    int nc = c;
                    box.Click += (s, e) =>
                    {
                        ColumnHeader.Controls[nc].BackColor = SelectedColumnHeaderBackColor;
                        ColumnHeader.Controls[nc].ForeColor = SelectedColumnHeaderForeColor;
                    };
                    box.MouseDown += ColHeader_Click;
                    ColumnHeader.Controls.Add(box, c, 0);
                }
            else for (int i = ColumnHeader.Controls.Count - 1; i >= 0; i--)
                {
                    TableLayoutPanelCellPosition tlcp = ColumnHeader.GetPositionFromControl(ColumnHeader.Controls[i]);
                    if (tlcp.Row >= ColumnHeader.RowCount)
                        ColumnHeader.Controls.RemoveAt(i);
                }
        }
        public virtual void UpdateControls()
        {
            int con = MainTable.RowCount * MainTable.ColumnCount;
            if (MainTable.Controls.Count == con) return;
            else if (MainTable.Controls.Count < con)
                for (int c = 0; c < MainTable.ColumnCount; c++)
                    for (int r = 0; r < MainTable.RowCount; r++)
                    {
                        if (MainTable.GetControlFromPosition(c, r) == null)
                        {
                            DataCell box = new DataCell();
                            box.ReadOnly = IsReadOnly;
                            box.GotFocus += Box_GotFocus;
                            box.LostFocus += Box_LostFocus;
                            box.ContextMenuStrip = CMS_Table;
                            box.Click += (s, e) => ChangeSelection(box.ColumnIndex,box.RowIndex);
                            box.ValueChanged += Box_ValueChanged;
                            MainTable.Controls.Add(box, c, r);
                        }
                    }
            else for (int i = MainTable.Controls.Count - 1; i >= 0; i--)
                {
                    TableLayoutPanelCellPosition tlcp = MainTable.GetPositionFromControl(MainTable.Controls[i]);
                    if (tlcp.Column >= MainTable.ColumnCount || tlcp.Row >= MainTable.RowCount)
                        MainTable.Controls.RemoveAt(i);
                }
        }
        public virtual void UpdateRows()
        {
            int rn = Math.Min(MainTable.Height / _RowsHeight, CurrentTable.Rows.Count - VerticalScrollBar.Value);
            if (MainTable.RowCount == rn) return;
            if (MainTable.RowCount < rn)
            {
                RowHeader.RowCount =
                MainTable.RowCount = rn;
                int l = MainTable.Height / rn;
                for (int i = 0; i < RowHeader.RowStyles.Count; i++)
                {
                    RowHeader.RowStyles[i] = new RowStyle(SizeType.Absolute, l);
                    MainTable.RowStyles[i] = new RowStyle(SizeType.Absolute, l);
                }
                for (int i = RowHeader.RowStyles.Count; i < RowHeader.RowCount; i++)
                {
                    RowHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, l));
                    MainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, l));
                }
            }
            else
            {
                RowHeader.RowCount =
                MainTable.RowCount = rn;
                for (int i = RowHeader.RowStyles.Count - 1; i > rn; i--)
                {
                    RowHeader.RowStyles.RemoveAt(i);
                    MainTable.RowStyles.RemoveAt(i);
                }
            }
        }
        public virtual void UpdateColumns()
        {
            int cn = Math.Min( MainTable.Width / _ColumnsWidth, CurrentTable.Columns.Count-HorizontalScrollBar.Value);
            if (MainTable.ColumnCount == cn) return;
            if (MainTable.ColumnCount < cn)
            {
                ColumnHeader.ColumnCount =
                MainTable.ColumnCount = cn;
                int l = MainTable.Width/cn;
                for (int i = 0; i < ColumnHeader.ColumnStyles.Count; i++)
                {
                    ColumnHeader.ColumnStyles[i] = new ColumnStyle(SizeType.Absolute, l);
                    MainTable.ColumnStyles[i] = new ColumnStyle(SizeType.Absolute, l);
                }
                for (int i = ColumnHeader.ColumnStyles.Count; i < ColumnHeader.ColumnCount; i++)
                {
                    ColumnHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, l));
                    MainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, l));
                }
            }
            else
            {
                ColumnHeader.ColumnCount =
                MainTable.ColumnCount = cn;
                for (int i = ColumnHeader.ColumnStyles.Count - 1; i >= cn ; i--)
                {
                    ColumnHeader.ColumnStyles.RemoveAt(i);
                    MainTable.ColumnStyles.RemoveAt(i);
                }
            }
        }

        public virtual void Clear()
        {
            IsUpdating = true;
            Table = new MiMFa_Table();
            UpdateStatus();
            UpdateHeaderControls();
            try
            {
                for (int r = 0; r < MainTable.RowCount; r++)
                    for (int c = 0; c < MainTable.ColumnCount; c++)
                        MainTable.GetControlFromPosition(c, r).Text = "";
                for (int r = 0; r < RowHeader.RowCount; r++)
                    for (int c = 0; c < RowHeader.ColumnCount; c++)
                        RowHeader.GetControlFromPosition(c, r).Text = "";
                for (int r = 0; r < ColumnHeader.RowCount; r++)
                    for (int c = 0; c < ColumnHeader.ColumnCount; c++)
                        ColumnHeader.GetControlFromPosition(c, r).Text = "";
            }
            catch { }
            IsUpdating = false;
        }
        public new virtual void Focus()
        {
            if (CurrentCell != null) CurrentCell.Focus();
            else base.Focus();
        }
        public virtual void CellChanged()
        {
            if (PreviousCell == null) return;
            if (CurrentCell.RowIndex == PreviousCell.RowIndex && CurrentCell.ColumnIndex == PreviousCell.ColumnIndex) return;
            if (IsValueChanged)
            {
                if (CurrentCell.RowIndex != PreviousCell.RowIndex)
                {
                    RowValuesChanged(this, PreviousCell.OwningRow);
                    TableValuesChanged(this, CurrentTable);
                    IsValueChanged = false;
                }
                if (CurrentCell.ColumnIndex != PreviousCell.ColumnIndex)
                {
                    ColumnValuesChanged(this, PreviousCell.OwningColumn);
                    if (IsValueChanged)
                    {
                        TableValuesChanged(this, CurrentTable);
                        IsValueChanged = false;
                    }
                }
            }
        }

        private DataCell GetCell(int rowIndex, int colIndex)
        {
            foreach (DataCell item in MainTable.Controls)
                if (item.ColumnIndex == colIndex && item.RowIndex == rowIndex)
                    return item;
            return new DataCell(CurrentTable, rowIndex, colIndex, null);
        }
        public void SetCell(DataGridViewCell dgvc)
        {
            CurrentTable.Rows[dgvc.RowIndex][dgvc.OwningColumn.Name] = dgvc.Value;
            UpdateCell(dgvc.RowIndex,dgvc.OwningColumn.Name);
        }
        public void SetCell(DataCell dgvc)
        {
            CurrentTable.Rows[dgvc.RowIndex][dgvc.ColumnIndex] = dgvc.Value;
        }
        public void SetCell(int rowIndex, string colID, object value)
        {
            CurrentTable.Rows[rowIndex][colID] = value;
            UpdateCell(rowIndex, colID);
        }
        public void SetCell(int rowIndex, int colIndex, object value)
        {
            CurrentTable.Rows[rowIndex][colIndex] = value;
            UpdateCell(rowIndex, colIndex);
        }
        public void ViewCell(int rowIndex, int colIndex)
        {
           if(rowIndex < VerticalScrollBar.Maximum) VerticalScrollBar.Value = rowIndex;
           if(colIndex < HorizontalScrollBar.Maximum) HorizontalScrollBar.Value = colIndex;
        }
        public void SetCurrentCell(int rowIndex, int colIndex,bool selectAll = true)
        {
            ViewCell(rowIndex, colIndex);
            foreach (DataCell item in MainTable.Controls)
                if (item.ColumnIndex == colIndex && item.RowIndex == rowIndex)
                {
                    item.Focus();
                    //CurrentCell = item;
                    BeginEdit(selectAll);
                    break;
                }
        }
        public void BeginEdit(bool selectAll = true)
        {
            if (CurrentCell == null) return;
            CurrentCell.Focus();
            if (selectAll) CurrentCell.SelectAll();
        }

        public Control SetBothRowHeader(int y, string value, int index)
        {
            Control c = RowHeader.GetControlFromPosition(0, y);
            c.Tag = index;
            c.Text = string.Join(" ", index, value);
            return c;
        }
        public Control SetBothColumnHeader(int x, string value, int index)
        {
            Control c = ColumnHeader.GetControlFromPosition(x, 0);
            c.Tag = index;
            c.Text = string.Join(" ", MiMFa_Convert.ToAlphabet(index), value);
            return c;
        }
        public Control SetIndexInRowHeader(int y, string value, int index)
        {
            Control c = RowHeader.GetControlFromPosition(0, y);
            c.Tag = index;
            c.Text = index.ToString();
            return c;
        }
        public Control SetIndexInColumnHeader(int x, string value, int index)
        {
            Control c = ColumnHeader.GetControlFromPosition(x, 0);
            c.Tag = index;
            c.Text = MiMFa_Convert.ToAlphabet(index);
            return c;
        }
        public Control SetDataInRowHeader(int y, string value, int index)
        {
            Control c = RowHeader.GetControlFromPosition(0, y);
            c.Tag = index;
            c.Text = value;
            return c;
        }
        public Control SetDataInColumnHeader(int x, string value, int index)
        {
            Control c = ColumnHeader.GetControlFromPosition(x, 0);
            c.Tag = index;
            c.Text = value;
            return c;
        }

        public void ClearSelection()
        {
            SelectedDic.Clear();
            ClearTableSelection();
            ClearHeadersSelection();
        }
        public void ClearTableSelection()
        {
            for (int i = 0; i < MainTable.Controls.Count; i++)
            {
                DataCell c = (DataCell)MainTable.Controls[i];
                if (c.IsSelected)
                {
                    c.BackColor = CellBackColor;
                    c.ForeColor = CellForeColor;
                }
            }
        }
        public void ClearHeadersSelection()
        {
            for (int i = 0; i < RowHeader.Controls.Count; i++)
            {
                Control c = RowHeader.Controls[i];
                c.BackColor = RowHeaderBackColor;
                c.ForeColor = RowHeaderForeColor;
            }
            for (int i = 0; i < ColumnHeader.Controls.Count; i++)
            {
                Control c = ColumnHeader.Controls[i];
                c.BackColor = ColumnHeaderBackColor;
                c.ForeColor = ColumnHeaderForeColor;
            }
        }
        public void UpdateSelection()
        {
            UpdateTableSelection();
            UpdateHeadersSelection();
        }
        public void UpdateTableSelection()
        {
            for (int i = 0; i < MainTable.Controls.Count; i++)
            {
                DataCell c = (DataCell)MainTable.Controls[i];
                if (GetSelection(c.ColumnIndex, c.RowIndex))
                {
                    c.BackColor = SelectedCellBackColor;
                    c.ForeColor = SelectedCellForeColor;
                }
                else
                {
                    c.BackColor = CellBackColor;
                    c.ForeColor = CellForeColor;
                }
            }
        }
        public void UpdateHeadersSelection()
        {
            for (int i = 0; i < RowHeader.Controls.Count; i++)
            {
                Control c = RowHeader.Controls[i];
                if (GetSelection(-1, Convert.ToInt32(c.Tag)))
                {
                    c.BackColor = SelectedRowHeaderBackColor;
                    c.ForeColor = SelectedRowHeaderForeColor;
                }
                else
                {
                    c.BackColor = RowHeaderBackColor;
                    c.ForeColor = RowHeaderForeColor;
                }
            }
            for (int i = 0; i < ColumnHeader.Controls.Count; i++)
            {
                Control c = ColumnHeader.Controls[i];
                if (GetSelection(Convert.ToInt32(c.Tag), -1))
                {
                    c.BackColor = SelectedColumnHeaderBackColor;
                    c.ForeColor = SelectedColumnHeaderForeColor;
                }
                else
                {
                    c.BackColor = ColumnHeaderBackColor;
                    c.ForeColor = ColumnHeaderForeColor;
                }
            }
        }
        public void UpdateSelection(int col = -1, int row = -1)
        {
            UpdateTableSelection(col,row);
            UpdateHeadersSelection(col, row);
        }
        public void UpdateTableSelection(int col = -1, int row = -1)
        {
            if (col < 0 && row < 0) for (int i = 0; i < MainTable.Controls.Count; i++)
                {
                    DataCell c = (DataCell)MainTable.Controls[i];
                    if (GetSelection(c.ColumnIndex, c.RowIndex))
                    {
                        c.BackColor = SelectedCellBackColor;
                        c.ForeColor = SelectedCellForeColor;
                    }
                    else
                    {
                        c.BackColor = CellBackColor;
                        c.ForeColor = CellForeColor;
                    }
                }
            else if (col < 0) for (int i = 0; i < MainTable.Controls.Count; i++)
                {
                    DataCell c = (DataCell)MainTable.Controls[i];
                    if (c.RowIndex == row)
                        if (GetSelection(c.ColumnIndex, c.RowIndex))
                        {
                            c.BackColor = SelectedCellBackColor;
                            c.ForeColor = SelectedCellForeColor;
                        }
                        else
                        {
                            c.BackColor = CellBackColor;
                            c.ForeColor = CellForeColor;
                        }
                }
            else if (row < 0) for (int i = 0; i < MainTable.Controls.Count; i++)
                {
                    DataCell c = (DataCell)MainTable.Controls[i];
                    if (c.ColumnIndex == col)
                        if (GetSelection(c.ColumnIndex, c.RowIndex))
                        {
                            c.BackColor = SelectedCellBackColor;
                            c.ForeColor = SelectedCellForeColor;
                        }
                        else
                        {
                            c.BackColor = CellBackColor;
                            c.ForeColor = CellForeColor;
                        }
                }
            else for (int i = 0; i < MainTable.Controls.Count; i++)
                {
                    DataCell c = (DataCell)MainTable.Controls[i];
                    if (c.RowIndex == row && c.ColumnIndex == col)
                        if (GetSelection(c.ColumnIndex, c.RowIndex))
                        {
                            c.BackColor = SelectedCellBackColor;
                            c.ForeColor = SelectedCellForeColor;
                        }
                        else
                        {
                            c.BackColor = CellBackColor;
                            c.ForeColor = CellForeColor;
                        }
                }
        }
        public void UpdateHeadersSelection(int col = -1, int row = -1)
        {
            for (int i = 0; i < RowHeader.Controls.Count; i++)
            {
                Control c = RowHeader.Controls[i];
                if (GetSelection(-1, Convert.ToInt32(c.Tag)))
                {
                    c.BackColor = SelectedRowHeaderBackColor;
                    c.ForeColor = SelectedRowHeaderForeColor;
                }
                else
                {
                    c.BackColor = RowHeaderBackColor;
                    c.ForeColor = RowHeaderForeColor;
                }
            }
            for (int i = 0; i < ColumnHeader.Controls.Count; i++)
            {
                Control c = ColumnHeader.Controls[i];
                if (GetSelection(Convert.ToInt32(c.Tag), -1))
                {
                    c.BackColor = SelectedColumnHeaderBackColor;
                    c.ForeColor = SelectedColumnHeaderForeColor;
                }
                else
                {
                    c.BackColor = ColumnHeaderBackColor;
                    c.ForeColor = ColumnHeaderForeColor;
                }
            }
        }
        public string GetColumnLabel(int i)
        {
            return "";
        }
        public void SetVisibleColumn(int i, bool v)
        {
            return;
        }
        public bool IsVisibleColumn(int i)
        {
            return true;
        }
        public bool IsVisibleCell(int rowIndex, int colIndex)
        {
            throw new NotImplementedException();
        }

        public bool GetSelection(int col = -1, int row = -1)
        {
            if (SelectedDic.Count < 1) return false;
            try { return SelectedDic[new Point(col, row)]; }
            catch
            {
                bool b = false;
                foreach (var item in SelectedDic)
                    if ((item.Key.X < 0 && item.Key.Y == row)
                        || (item.Key.Y < 0 && item.Key.X == col)
                        || (item.Key.X < 0 && item.Key.Y < 0))
                        b = item.Value;
                return b;
            }
        }
        public void SetSelection(int col = -1, int row = -1, bool selected = true)
        {
            Execute(() =>
            {
                if ((System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift)
                || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift)
                || System.Windows.Input.Mouse.RightButton == System.Windows.Input.MouseButtonState.Pressed)
                && (PreviousCell != null && !(PreviousCell.ColumnIndex < 0 || PreviousCell.RowIndex < 0))
                && (CurrentCell != null && !(CurrentCell.ColumnIndex < 0 || CurrentCell.RowIndex < 0))
                && !(row < 0 && col < 0))
                {
                    if (row < 0)
                    {
                        int mincol = Math.Min(col, CurrentCell.ColumnIndex);
                        int maxcol = Math.Max(col, CurrentCell.ColumnIndex);
                        for (int c = mincol + 1; c <= maxcol; c++)
                        {
                            Point to = new Point(c, -1);
                            SelectedDic.Remove(to);
                            SelectedDic.Add(to, selected);
                        }
                    }
                    else if (col < 0)
                    {
                        int minrow = Math.Min(row, CurrentCell.RowIndex);
                        int maxrow = Math.Max(row, CurrentCell.RowIndex);
                        for (int r = minrow + 1; r <= maxrow; r++)
                        {
                            Point to = new Point(-1, r);
                            SelectedDic.Remove(to);
                            SelectedDic.Add(to, selected);
                        }
                    }
                    else
                    {
                        int minrow = Math.Min(row, PreviousCell.RowIndex);
                        int maxrow = Math.Max(row, PreviousCell.RowIndex);
                        int mincol = Math.Min(col, PreviousCell.ColumnIndex);
                        int maxcol = Math.Max(col, PreviousCell.ColumnIndex);
                        for (int r = minrow; r <= maxrow; r++)
                            for (int c = mincol; c <= maxcol; c++)
                                if (!(r == PreviousCell.RowIndex && c == PreviousCell.ColumnIndex))
                                {
                                    Point to = new Point(c, r);
                                    SelectedDic.Remove(to);
                                    SelectedDic.Add(to, selected);
                                }
                    }
                    UpdateSelection();
                }
                else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl)
                    || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
                {
                    Point p = new Point(col, row);
                    SelectedDic.Remove(p);
                    SelectedDic.Add(p, selected);
                    if (row < 0 || col < 0) UpdateSelection(col, row);
                    else UpdateTableSelection(col, row);
                }
                else
                {
                    SelectedDic.Clear();
                    Point p = new Point(col, row);
                    SelectedDic.Remove(p);
                    SelectedDic.Add(p, selected);
                    UpdateSelection();
                }
            });
        }
        public void ChangeSelection(int col = -1, int row = -1)
        {
            Execute(() =>
            {
                if ((System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift)
                || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift)
                || System.Windows.Input.Mouse.RightButton == System.Windows.Input.MouseButtonState.Pressed)
                && (PreviousCell != null && !(PreviousCell.ColumnIndex < 0 || PreviousCell.RowIndex < 0))
                && (CurrentCell != null && !(CurrentCell.ColumnIndex < 0 || CurrentCell.RowIndex < 0))
                && !(row < 0 && col < 0))
                {
                    if (row < 0)
                    {
                        int mincol = Math.Min(col, CurrentCell.ColumnIndex);
                        int maxcol = Math.Max(col, CurrentCell.ColumnIndex);
                        for (int c = mincol + 1; c <= maxcol; c++)
                        {
                            bool b = GetSelection(c, -1);
                            Point to = new Point(c, -1);
                            SelectedDic.Remove(to);
                            SelectedDic.Add(to, !b);
                        }
                    }
                    else if (col < 0)
                    {
                        int minrow = Math.Min(row, CurrentCell.RowIndex);
                        int maxrow = Math.Max(row, CurrentCell.RowIndex);
                        for (int r = minrow + 1; r <= maxrow; r++)
                        {
                            bool b = GetSelection(-1, r);
                            Point to = new Point(-1, r);
                            SelectedDic.Remove(to);
                            SelectedDic.Add(to, !b);
                        }
                    }
                    else
                    {
                        int minrow = Math.Min(row, PreviousCell.RowIndex);
                        int maxrow = Math.Max(row, PreviousCell.RowIndex);
                        int mincol = Math.Min(col, PreviousCell.ColumnIndex);
                        int maxcol = Math.Max(col, PreviousCell.ColumnIndex);
                        for (int r = minrow; r <= maxrow; r++)
                            for (int c = mincol; c <= maxcol; c++)
                                if (!(r == PreviousCell.RowIndex && c == PreviousCell.ColumnIndex))
                                {
                                    bool b = GetSelection(c, r);
                                    Point to = new Point(c, r);
                                    SelectedDic.Remove(to);
                                    SelectedDic.Add(to, !b);
                                }
                    }
                    UpdateSelection();
                }
                else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl)
                    || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightCtrl))
                {
                    bool b = GetSelection(col, row);
                    Point p = new Point(col, row);
                    SelectedDic.Remove(p);
                    SelectedDic.Add(p, !b);
                    if (row < 0 || col < 0) UpdateSelection(col, row);
                    else UpdateTableSelection(col, row);
                }
                else
                {
                    SelectedDic.Clear();
                    bool b = GetSelection(col, row);
                    Point p = new Point(col, row);
                    SelectedDic.Remove(p);
                    SelectedDic.Add(p, !b);
                    UpdateSelection();
                }
            });
        }

        #endregion

        #region Target
        public DataGridView()
        {
            InitializeComponent();
            MouseWheel += Table_MouseWheel;
            OBJECTMOR.AddControl(RowHeader, MiMFa_ObjectMoveOrResize.MoveOrResize.Resize);
            OBJECTMOR.AddControl(ColumnHeader, MiMFa_ObjectMoveOrResize.MoveOrResize.Resize);
            AutoHeaderValue = ScrollBars.Both;
            RowHeader.Width = RowHeaderWidth;
            ColumnHeader.Height = ColumnHeaderHeight;
            UpdateRows();
            UpdateColumns();
        }

        public void Execute(ThreadStart action)
        {
            action();
            //Thread th = new Thread(action);
            //th.SetApartmentState(ApartmentState.STA);
            //th.IsBackground = true;
            //th.Start();
        }

        private void DataGridView_Resize(object sender, EventArgs e)
        {
            if (MainPanel.Visible) UpdateAll();
        }
        private void Table_MouseWheel(object sender, MouseEventArgs e)
        {
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.RightShift)
                 || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift))
            {
                int val = HorizontalScrollBar.Value + e.Delta;
                if (val < 0)
                    HorizontalScrollBar.Value = 0;
                else if (val > HorizontalScrollBar.Maximum)
                    HorizontalScrollBar.Value = HorizontalScrollBar.Maximum;
                else HorizontalScrollBar.Value = val;
            }
            else
            {
                int val = VerticalScrollBar.Value - e.Delta;
                if (val < 0)
                    VerticalScrollBar.Value = 0;
                else if (val > VerticalScrollBar.Maximum)
                    VerticalScrollBar.Value = VerticalScrollBar.Maximum;
                else VerticalScrollBar.Value = val;
            }
        }
        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
        private void HorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void Box_GotFocus(object sender, EventArgs e)
        {
            IsTableFocuced = true;
            CurrentCell = (DataCell)sender;
            if (PreviousCell != null && CurrentCell.RowIndex == PreviousCell.RowIndex && CurrentCell.ColumnIndex == PreviousCell.ColumnIndex) return;
            if (IsUpdating || CurrentCell.ColumnIndex < 0 || CurrentCell.RowIndex < 0) return;
            CellSelectionChanged(this, PreviousCell);
            if (PreviousCell == null) PreviousCell = CurrentCell;
            if (PreviousCell.RowIndex != CurrentCell.RowIndex)
                RowSelectionChanged(this, PreviousCell.OwningRow);
            if (PreviousCell.ColumnIndex != CurrentCell.ColumnIndex)
                ColumnSelectionChanged(this, PreviousCell.OwningColumn);
        }
        private void Box_LostFocus(object sender, EventArgs e)
        {
            IsTableFocuced = false;
            PreviousCell = new DataCell((DataCell)sender);
            CellChanged();
        }
        private void Box_ValueChanged(DataCell cell, object value)
        {
            if (IsUpdating || cell.ColumnIndex < 0 || cell.RowIndex < 0) return;
            IsValueChanged = true;
            CellValueChanged(this, cell);
            if (cell.Focused) CurrentCellValueChanged(this, cell);
            if (PreviousCell == null) PreviousCell = cell;
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Scroll(sender, e);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelection(-1, -1, true);
        }
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSelection(CurrentCell.ColumnIndex,CurrentCell.RowIndex);
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void RowHeader_Click(object sender, EventArgs e)
        {
            Control box = (Control)sender;
            if (box.Tag == null) return;
            if (CurrentCell == null) CurrentCell = new DataCell(Table.MainTable, Convert.ToInt32(box.Tag), -1, box.Text);
            else CurrentCell.Set(Table.MainTable, Convert.ToInt32(box.Tag), -1, box.Text);
            ChangeSelection(-1, CurrentCell.RowIndex);
        }
        private void ColHeader_Click(object sender, EventArgs e)
        {
            Control box = (Control)sender;
            if (box.Tag == null) return;
            if (CurrentCell == null) CurrentCell = new DataCell(Table.MainTable, -1, Convert.ToInt32(box.Tag), box.Text);
            else CurrentCell.Set(Table.MainTable, Convert.ToInt32(box.Tag), -1, box.Text);
            ChangeSelection(Convert.ToInt32(box.Tag), -1);
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table.Rows.InsertAt(Table.MainTable.NewRow(), CurrentRowIndex);
            RowAdded(this, Table.Rows[CurrentRowIndex]);
            UpdateAll();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = Table.MainTable.NewRow();
            dr.ItemArray = Table.Rows[CurrentRowIndex].ItemArray;
            Table.Rows.RemoveAt(CurrentRowIndex);
            RowRemoved(this, dr);
            UpdateAll();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Table.AddColumnSafe(CurrentColumnIndex, "");
            ColumnAdded(this, Table.Columns[CurrentColumnIndex]);
            UpdateAll();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataColumn dc = new DataColumn(Table.Columns[CurrentRowIndex].ColumnName, Table.Columns[CurrentRowIndex].DataType);
            Table.Columns.RemoveAt(CurrentColumnIndex);
            ColumnRemoved(this, dc);
            UpdateAll();
        }
    }
    #endregion
}
