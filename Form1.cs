 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace DataTransferTool
{ 
    public partial class Form_DTS : Form
    {
        private string accessDBFileConnection = "";
        private DataTable accessDBSchema = null;
        private DataTable sqliteDBSchema = null;
        private Button SourceBtnSelected = null;

        private Color StickButtonColor = Color.LightBlue; 
        private Color EraseColor = Color.White;
        private Color ActivatedSourceItemColor = Color.Green;
        private Color RelationLineColor = Color.Green;
        
        
        private List<KeyValuePair<Button, Button>> relationButtonMap = new List<KeyValuePair<Button, Button>>();

        //private List<KeyValuePair<string, string>> relationMap = new List<KeyValuePair<string, string>>();
        private DTSRelationDistionary GeneralRelationDic = new DTSRelationDistionary();
        public Form_DTS()
        {
            InitializeComponent();
      //      this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = this.EraseColor;
        }

        private void Form_DTS_Load(object sender, EventArgs e)
        {
            LV_Target.Top = LV_Source.Top;
        //    LoadSourceAccessDB(@"./DataCut1.mdb");
        //    LoadTargetSqliteDB(string.Format("Data Source={0}", @"./am_techtable - 2.1.db") );
           
        }

        private void LoadSourceAccessDB(string filename)
        {
            try
            {
                this.accessDBFileConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";";
                using (OleDbConnection accessDBConn = new OleDbConnection(accessDBFileConnection))
                {
                    accessDBConn.Open();
                    OleDbDataReader myReader = null;
                    this.accessDBSchema = accessDBConn.GetSchema("Columns");
                    DataTable tblist = accessDBConn.GetSchema("tables");
                    foreach (DataRow row in tblist.Rows)
                    {
                        if (row["TABLE_TYPE"].ToString().ToUpper() == "table".ToUpper())
                        {
                            CBox_Source.Items.Add(row["TABLE_NAME"].ToString());
                        }
                    }
                }
            }
            finally
            {

            } 
        }

       

    private void SourceBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Access DB Files (mdb)|*.mdb";
            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fileDialog.FileName))
            {
                this.accessDBFileConnection = fileDialog.FileName;
                LoadSourceAccessDB(accessDBFileConnection); 
            }
            else { this.accessDBFileConnection = ""; }
        }


        private void LoadTargetSqliteDB(string filename)
        {
            try
            {
                using (var connection = new SQLiteConnection(filename))
                {
                    connection.Open();
                    this.sqliteDBSchema = connection.GetSchema("Columns");
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @"
                        SELECT name FROM sqlite_schema 
                        WHERE type IN ('table','view') 
                        AND name NOT LIKE 'sqlite_%'
                        ORDER BY 1;
                    ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                            CBox_Target.Items.Add(name);
                        }
                    }
                }
            }
            finally
            {

            }

        }

        private void TargetBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Sqlite DB Files (db)|*.db";
            string accessDBFile = "";
            if (fileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fileDialog.FileName))
            {
                accessDBFile = fileDialog.FileName;
                string  connectionString = string.Format("Data Source={0}", accessDBFile);
                LoadTargetSqliteDB(connectionString); 
            }
        }

        public DataTable LinqSortDataTable(DataTable tmpDt, string fieldname) 
        { 
            DataTable dtsort = tmpDt.Clone(); 
            dtsort = tmpDt.Rows.Cast<DataRow>().OrderBy(r => r[fieldname].ToString()).CopyToDataTable(); 
            return dtsort;

        }

        private void CBox_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            EraseAllRelationArrowLine();
            int i = 0; int countBtn = LV_Source.Controls.Count;
            if (accessDBSchema!=null)
            {
                LV_Source.Items.Clear();
                for (int j = 0; j < countBtn - 1; j++)
                {
                    if (LV_Source.Controls[0].Name.Contains("SourceBtn_"))
                    {
                        LV_Source.Controls[0].Dispose();
                    }
                }
                accessDBSchema = LinqSortDataTable(accessDBSchema, "COLUMN_NAME");
                foreach (DataRow row in accessDBSchema.Rows)
                {
                    if (row["TABLE_NAME"].ToString().ToUpper() == CBox_Source.Text.ToUpper())
                    {
                        if (!string.IsNullOrEmpty(row["COLUMN_NAME"].ToString().Trim()))
                        {
                            i++;
                            var lineItem = LV_Source.Items.Add(i.ToString());
                            lineItem.Checked = false;

                            lineItem.SubItems.Add(row["COLUMN_NAME"].ToString().Trim());
                            lineItem.SubItems.Add(ConvertAccessDataType(row["DATA_TYPE"].ToString()));
                            lineItem.SubItems.Add("");
                            var btn = new RoundButton();
                            btn.FlatStyle = FlatStyle.Popup;
                            btn.BackColor = this.StickButtonColor;
                            btn.Text = "";
                            btn.Name = "SourceBtn_" + row["COLUMN_NAME"].ToString().Trim();
                            btn.Size = new Size(lineItem.SubItems[3].Bounds.Width, lineItem.SubItems[3].Bounds.Height);
                            btn.Left = lineItem.SubItems[3].Bounds.X;
                            btn.Top = lineItem.SubItems[3].Bounds.Y;
                            btn.Width = 15; btn.Height = 15;
                            btn.Visible = false;
                            btn.Click += BtnSource_Click;
                            LV_Source.Controls.Add(btn);
                        }
                    }
                }
                LV_Source.Height  = 50 +  i * 17;
                if (LV_Source.Items.Count >= LV_Target.Items.Count)
                {
                    LV_Target.Height = 50 + LV_Target.Items.Count * 17;
                    MappingGroupBox.Height = LV_Source.Height + 100;
                }
                else {
                    MappingGroupBox.Height = LV_Target.Height + 100;
                }
               
            }
        }

        private void BtnSource_Click(object sender, EventArgs e)
        {
            if (this.SourceBtnSelected != null)
            { this.SourceBtnSelected.BackColor = this.StickButtonColor; }
            this.SourceBtnSelected = (Button)sender;
            this.SourceBtnSelected.BackColor = this.ActivatedSourceItemColor;
        }

        private void CBox_Target_SelectedIndexChanged(object sender, EventArgs e)
        {
            EraseAllRelationArrowLine();
            int i = 0; int countBtn = LV_Target.Controls.Count;
            if (this.sqliteDBSchema != null)
            {
                LV_Target.Items.Clear();
                for (int j = 0; j < countBtn - 1; j++)
                {
                    if (LV_Target.Controls[0].Name.Contains("TargetBtn_"))
                    {
                        LV_Target.Controls[0].Dispose();
                    }
                }
                sqliteDBSchema = LinqSortDataTable(sqliteDBSchema, "COLUMN_NAME");
                foreach (DataRow row in this.sqliteDBSchema.Rows)
                {
                    if (row["TABLE_NAME"].ToString().ToUpper() == CBox_Target.Text.ToUpper())
                    {
                        if (!string.IsNullOrEmpty(row["COLUMN_NAME"].ToString().Trim()))
                        {
                            i++;
                            var lineItem = LV_Target.Items.Add("");
                            lineItem.Checked = false;
                            lineItem.SubItems.Add(i.ToString());
                            lineItem.SubItems.Add(row["COLUMN_NAME"].ToString().Trim());
                            lineItem.SubItems.Add(ConvertAccessDataType(row["DATA_TYPE"].ToString()));
                            lineItem.SubItems.Add("");
                            var btn = new RoundButton();
                            btn.FlatStyle = FlatStyle.Popup;
                            btn.BackColor = this.StickButtonColor;
                            btn.Text = "";
                            btn.Name = "TargetBtn_" + row["COLUMN_NAME"].ToString().Trim();
                            btn.Size = new Size(lineItem.SubItems[0].Bounds.Width, lineItem.SubItems[0].Bounds.Height);
                            btn.Left = lineItem.SubItems[0].Bounds.X;
                            btn.Top = lineItem.SubItems[0].Bounds.Y;
                            btn.Width = 15; btn.Height = 15;
                            btn.Click += BtnTarget_Click;
                            LV_Target.Controls.Add(btn);
                        }
                    }
                }
                LV_Target.Height = 50 + i * 17;
                if (LV_Source.Items.Count <= LV_Target.Items.Count)
                {
                    LV_Source.Height = 50 + LV_Source.Items.Count * 17;
                    MappingGroupBox.Height = LV_Target.Height + 100;
                }
                else { MappingGroupBox.Height = LV_Source.Height + 100; }
               
            }
        }

        private void BtnTarget_Click(object sender, EventArgs e)
        {
            KeyValuePair<Button, Button> relation = relationButtonMap.FirstOrDefault(x =>
                   x.Value.Name == ((Button)sender).Name);
            if (relation.Value!=null  )
            {
                return;
            }

            if (SourceBtnSelected != null)
            { 
                 KeyValuePair<Button, Button> item = relationButtonMap.FirstOrDefault(x =>
                    x.Key.Name == (SourceBtnSelected).Name
                 );
                if (item.Key != null && item.Value != null)
                {
                    EraseDrawLine(item.Key, item.Value, this.EraseColor);
                    relationButtonMap.Remove(item);
                }
                 
                relationButtonMap.Add(new KeyValuePair<Button, Button>(SourceBtnSelected, (Button)sender));
                relationButtonMap.ForEach(x=> {
                    AddDrawLine(x.Key, x.Value, this.RelationLineColor);
                });
            }
        }

        private void EraseAllRelationArrowLine()
        {
            relationButtonMap.ForEach(item => {
                EraseDrawLine(item.Key, item.Value, this.EraseColor);
            });
            relationButtonMap.Clear();
        }


        private string ConvertAccessDataType(string typeName)
        {
            string re = "";
            switch (typeName)
            {
                case "130":
                    re = "text";
                    break;
                case "3":
                    re = "int";
                    break;
                case "14":
                    re = "decomal";
                    break;
                case "5":
                    re = "double";
                    break;
                case "7":
                    re = "date";
                    break;
                case "134":
                    re = "time";
                    break;
                case "128":
                    re = "binary";
                    break;
                case "135":
                    re = "timestamp";
                    break;
                default:
                    re = typeName;
                    break;
            }
            return re;
        }

        private void LV_Source_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string temp = this.LV_Source.Items[e.Index].SubItems[1].Text;
            if (e.CurrentValue == CheckState.Unchecked)
            { 
                ((Button)this.Controls.Find("SourceBtn_" + temp, true)[0]).Visible = true;
            }
            else {
                ((Button)this.Controls.Find("SourceBtn_" + temp, true)[0]).Visible = false;
                KeyValuePair<Button, Button> item = relationButtonMap.FirstOrDefault(x =>  
                    x.Key.Name == "SourceBtn_" + temp 
                 );
                if(item.Key!= null && item.Value!=null)
                {
                    EraseDrawLine(item.Key, item.Value,this.EraseColor);
                }
                relationButtonMap.Remove(item);
                relationButtonMap.ForEach(x => {
                    AddDrawLine(x.Key, x.Value, this.RelationLineColor);
                });
            }
        }

        private void EraseDrawLine(Button aButton, Button bButton, Color eraserColor )
        {
            Point pt1 = FindLocation(aButton);
            Point pt1_1 = FindLocation(aButton);
            pt1.X += 80;
            pt1.Y += 10;
            pt1_1.Y += 10;

            Point pt2 = FindLocation(bButton);
            Point pt2_2 = FindLocation(bButton);
            pt2.X -= 50 ;
            pt2.Y += 10;
            pt2_2.Y += 10; 

            Graphics g = MappingGroupBox.CreateGraphics();
            g.DrawLine(new Pen(eraserColor, 3.0F), pt1, pt1_1);
            g.DrawLine(new Pen(eraserColor, 3.0F), pt2, pt1);
            g.DrawLine(new Pen(eraserColor, 3.0F), pt2_2, pt2);

            var pen = new Pen(eraserColor, 1);
            pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(pen, pt2_2.X - 20, pt2_2.Y, pt2_2.X, pt2_2.Y);
        }

        private void AddDrawLine(Button aButton, Button bButton, Color lineColor)
        { 
            Point pt1 = FindLocation(aButton);
            Point pt1_1 = FindLocation(aButton);
            pt1.X += 80;
            pt1.Y += 10;
            pt1_1.Y += 10;

            Point pt2 = FindLocation(bButton);
            Point pt2_2 = FindLocation(bButton);
            pt2.X -= 50;
            pt2.Y += 10; 
            pt2_2.Y += 10; 

            Graphics g = MappingGroupBox.CreateGraphics();
            g.DrawLine(new Pen(lineColor, 3.0F), pt1, pt1_1);
            g.DrawLine(new Pen(lineColor, 3.0F), pt2, pt1);
            g.DrawLine(new Pen(lineColor, 3.0F), pt2_2, pt2);

            var pen = new Pen(lineColor, 1);
            pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(pen, pt2_2.X - 20, pt2_2.Y, pt2_2.X, pt2_2.Y);
        }

        private Point FindLocation(Control ctrl)
        {
            if (ctrl != null)
            {
                if (ctrl.Parent is GroupBox)
                    return ctrl.Location;
                else
                {
                    Point p = FindLocation(ctrl.Parent);
                    p.X += ctrl.Location.X;
                    p.Y += ctrl.Location.Y;
                    return p;
                }
            }
            else { return new Point();  }
        }

        private void PanelMappingSettings_Scroll(object sender, ScrollEventArgs e)
        {
            relationButtonMap.ForEach(x => {
                AddDrawLine(x.Key, x.Value, this.RelationLineColor);
            });
        }

        private void MappingBtn_Click(object sender, EventArgs e)
        {
            relationButtonMap.Clear();
             Button abutton = null;  string aName;
            Button bButton = null;  string bName;
            foreach (ListViewItem sourceItem in LV_Source.Items)
            {
                foreach (ListViewItem targetItem in LV_Target.Items)
                {
                    aName = sourceItem.SubItems[1].Text.Trim();
                    bName = targetItem.SubItems[2].Text.Trim();
                    if (aName == bName)
                    {
                        abutton = (Button)LV_Source.Controls.Find("SourceBtn_" + aName, true)[0];
                        bButton = (Button)LV_Target.Controls.Find("TargetBtn_" + bName, true)[0];
                        AddDrawLine(abutton, bButton, this.RelationLineColor);
                        relationButtonMap.Add(new KeyValuePair<Button, Button>(abutton, bButton));
                    }
                }
            }
        }

        private void MappingGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
