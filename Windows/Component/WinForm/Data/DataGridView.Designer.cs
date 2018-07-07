namespace MiMFa_Framework.Component.WinForm.Data
{
    partial class DataGridView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CMS_Table = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RowHeader = new System.Windows.Forms.TableLayoutPanel();
            this.CMS_VHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnHeader = new System.Windows.Forms.TableLayoutPanel();
            this.VerticalScrollBar = new System.Windows.Forms.VScrollBar();
            this.HorizontalScrollBar = new System.Windows.Forms.HScrollBar();
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.Control_Search = new System.Windows.Forms.Panel();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ColumnBox = new System.Windows.Forms.ComboBox();
            this.CMS_HHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel.SuspendLayout();
            this.CMS_Table.SuspendLayout();
            this.CMS_VHeader.SuspendLayout();
            this.Control_Search.SuspendLayout();
            this.CMS_HHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.ColumnCount = 3;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPanel.ContextMenuStrip = this.CMS_Table;
            this.MainPanel.Controls.Add(this.RowHeader, 0, 1);
            this.MainPanel.Controls.Add(this.ColumnHeader, 1, 0);
            this.MainPanel.Controls.Add(this.VerticalScrollBar, 2, 1);
            this.MainPanel.Controls.Add(this.HorizontalScrollBar, 1, 2);
            this.MainPanel.Controls.Add(this.MainTable, 1, 1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 3;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPanel.Size = new System.Drawing.Size(465, 308);
            this.MainPanel.TabIndex = 0;
            // 
            // CMS_Table
            // 
            this.CMS_Table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.CMS_Table.Name = "CMS_Columns";
            this.CMS_Table.Size = new System.Drawing.Size(145, 98);
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.selectToolStripMenuItem.Text = "Selection Change";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // RowHeader
            // 
            this.RowHeader.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.RowHeader.ColumnCount = 1;
            this.RowHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowHeader.ContextMenuStrip = this.CMS_VHeader;
            this.RowHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.RowHeader.Location = new System.Drawing.Point(0, 25);
            this.RowHeader.Margin = new System.Windows.Forms.Padding(0);
            this.RowHeader.Name = "RowHeader";
            this.RowHeader.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.RowHeader.RowCount = 2;
            this.RowHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RowHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RowHeader.Size = new System.Drawing.Size(48, 268);
            this.RowHeader.TabIndex = 4;
            // 
            // CMS_VHeader
            // 
            this.CMS_VHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.CMS_VHeader.Name = "CMS_Columns";
            this.CMS_VHeader.Size = new System.Drawing.Size(108, 48);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ColumnHeader.ColumnCount = 2;
            this.ColumnHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColumnHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColumnHeader.ContextMenuStrip = this.CMS_VHeader;
            this.ColumnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ColumnHeader.Location = new System.Drawing.Point(48, 0);
            this.ColumnHeader.Margin = new System.Windows.Forms.Padding(0);
            this.ColumnHeader.Name = "ColumnHeader";
            this.ColumnHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ColumnHeader.RowCount = 1;
            this.ColumnHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ColumnHeader.Size = new System.Drawing.Size(402, 25);
            this.ColumnHeader.TabIndex = 3;
            // 
            // VerticalScrollBar
            // 
            this.VerticalScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.VerticalScrollBar.LargeChange = 1;
            this.VerticalScrollBar.Location = new System.Drawing.Point(450, 25);
            this.VerticalScrollBar.Maximum = 0;
            this.VerticalScrollBar.Name = "VerticalScrollBar";
            this.VerticalScrollBar.Size = new System.Drawing.Size(15, 268);
            this.VerticalScrollBar.TabIndex = 0;
            this.VerticalScrollBar.Visible = false;
            this.VerticalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            this.VerticalScrollBar.ValueChanged += new System.EventHandler(this.VerticalScrollBar_ValueChanged);
            // 
            // HorizontalScrollBar
            // 
            this.HorizontalScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HorizontalScrollBar.LargeChange = 1;
            this.HorizontalScrollBar.Location = new System.Drawing.Point(48, 293);
            this.HorizontalScrollBar.Maximum = 0;
            this.HorizontalScrollBar.Name = "HorizontalScrollBar";
            this.HorizontalScrollBar.Size = new System.Drawing.Size(402, 15);
            this.HorizontalScrollBar.TabIndex = 1;
            this.HorizontalScrollBar.Visible = false;
            this.HorizontalScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            this.HorizontalScrollBar.ValueChanged += new System.EventHandler(this.HorizontalScrollBar_ValueChanged);
            // 
            // MainTable
            // 
            this.MainTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.MainTable.ColumnCount = 2;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.ContextMenuStrip = this.CMS_Table;
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(48, 25);
            this.MainTable.Margin = new System.Windows.Forms.Padding(0);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 2;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTable.Size = new System.Drawing.Size(402, 268);
            this.MainTable.TabIndex = 2;
            // 
            // Control_Search
            // 
            this.Control_Search.AutoSize = true;
            this.Control_Search.Controls.Add(this.SearchTextBox);
            this.Control_Search.Controls.Add(this.ColumnBox);
            this.Control_Search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Control_Search.Location = new System.Drawing.Point(0, 308);
            this.Control_Search.Name = "Control_Search";
            this.Control_Search.Size = new System.Drawing.Size(465, 20);
            this.Control_Search.TabIndex = 17;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(344, 20);
            this.SearchTextBox.TabIndex = 17;
            // 
            // ColumnBox
            // 
            this.ColumnBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ColumnBox.FormattingEnabled = true;
            this.ColumnBox.Location = new System.Drawing.Point(344, 0);
            this.ColumnBox.Name = "ColumnBox";
            this.ColumnBox.Size = new System.Drawing.Size(121, 21);
            this.ColumnBox.TabIndex = 18;
            // 
            // CMS_HHeader
            // 
            this.CMS_HHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.CMS_HHeader.Name = "CMS_Columns";
            this.CMS_HHeader.Size = new System.Drawing.Size(153, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Insert";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // DataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Control_Search);
            this.Name = "DataGridView";
            this.Size = new System.Drawing.Size(465, 328);
            this.Resize += new System.EventHandler(this.DataGridView_Resize);
            this.MainPanel.ResumeLayout(false);
            this.CMS_Table.ResumeLayout(false);
            this.CMS_VHeader.ResumeLayout(false);
            this.Control_Search.ResumeLayout(false);
            this.Control_Search.PerformLayout();
            this.CMS_HHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        public System.Windows.Forms.VScrollBar VerticalScrollBar;
        public System.Windows.Forms.HScrollBar HorizontalScrollBar;
        public System.Windows.Forms.TableLayoutPanel MainTable;
        public System.Windows.Forms.TableLayoutPanel RowHeader;
        public System.Windows.Forms.TableLayoutPanel ColumnHeader;
        public System.Windows.Forms.Panel Control_Search;
        public System.Windows.Forms.TextBox SearchTextBox;
        public System.Windows.Forms.ComboBox ColumnBox;
        private System.Windows.Forms.ContextMenuStrip CMS_VHeader;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMS_Table;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CMS_HHeader;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}
