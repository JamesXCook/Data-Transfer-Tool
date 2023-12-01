
namespace DataTransferTool
{
    partial class Form_DTS
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelMappingSettings = new System.Windows.Forms.Panel();
            this.MappingGroupBox = new System.Windows.Forms.GroupBox();
            this.MappingBtn = new System.Windows.Forms.Button();
            this.LV_Target = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Source = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CBox_Target = new System.Windows.Forms.ComboBox();
            this.CBox_Source = new System.Windows.Forms.ComboBox();
            this.TargetBtn = new System.Windows.Forms.Button();
            this.SourceBtn = new System.Windows.Forms.Button();
            this.PanelMappingSettings.SuspendLayout();
            this.MappingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMappingSettings
            // 
            this.PanelMappingSettings.AutoScroll = true;
            this.PanelMappingSettings.Controls.Add(this.MappingGroupBox);
            this.PanelMappingSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMappingSettings.Location = new System.Drawing.Point(0, 0);
            this.PanelMappingSettings.Name = "PanelMappingSettings";
            this.PanelMappingSettings.Size = new System.Drawing.Size(1058, 589);
            this.PanelMappingSettings.TabIndex = 18;
            this.PanelMappingSettings.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PanelMappingSettings_Scroll);
            // 
            // MappingGroupBox
            // 
            this.MappingGroupBox.Controls.Add(this.MappingBtn);
            this.MappingGroupBox.Controls.Add(this.LV_Target);
            this.MappingGroupBox.Controls.Add(this.LV_Source);
            this.MappingGroupBox.Controls.Add(this.CBox_Target);
            this.MappingGroupBox.Controls.Add(this.CBox_Source);
            this.MappingGroupBox.Controls.Add(this.TargetBtn);
            this.MappingGroupBox.Controls.Add(this.SourceBtn);
            this.MappingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MappingGroupBox.Name = "MappingGroupBox";
            this.MappingGroupBox.Size = new System.Drawing.Size(1058, 589);
            this.MappingGroupBox.TabIndex = 10;
            this.MappingGroupBox.TabStop = false;
            this.MappingGroupBox.Text = "字段关系匹配";
            this.MappingGroupBox.Enter += new System.EventHandler(this.MappingGroupBox_Enter);
            // 
            // MappingBtn
            // 
            this.MappingBtn.Location = new System.Drawing.Point(444, 33);
            this.MappingBtn.Name = "MappingBtn";
            this.MappingBtn.Size = new System.Drawing.Size(107, 23);
            this.MappingBtn.TabIndex = 15;
            this.MappingBtn.Text = "一键Mapping";
            this.MappingBtn.UseVisualStyleBackColor = true;
            this.MappingBtn.Click += new System.EventHandler(this.MappingBtn_Click);
            // 
            // LV_Target
            // 
            this.LV_Target.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.LV_Target.GridLines = true;
            this.LV_Target.HideSelection = false;
            this.LV_Target.Location = new System.Drawing.Point(626, 70);
            this.LV_Target.Name = "LV_Target";
            this.LV_Target.Scrollable = false;
            this.LV_Target.Size = new System.Drawing.Size(330, 470);
            this.LV_Target.TabIndex = 14;
            this.LV_Target.UseCompatibleStateImageBehavior = false;
            this.LV_Target.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 15;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "序号";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 40;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "字段名";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = " 字段类型";
            this.columnHeader8.Width = 70;
            // 
            // LV_Source
            // 
            this.LV_Source.CheckBoxes = true;
            this.LV_Source.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LV_Source.GridLines = true;
            this.LV_Source.HideSelection = false;
            this.LV_Source.Location = new System.Drawing.Point(20, 70);
            this.LV_Source.Name = "LV_Source";
            this.LV_Source.Scrollable = false;
            this.LV_Source.Size = new System.Drawing.Size(339, 470);
            this.LV_Source.TabIndex = 13;
            this.LV_Source.UseCompatibleStateImageBehavior = false;
            this.LV_Source.View = System.Windows.Forms.View.Details;
            this.LV_Source.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LV_Source_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "字段名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "字段类型";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = " ";
            this.columnHeader4.Width = 15;
            // 
            // CBox_Target
            // 
            this.CBox_Target.FormattingEnabled = true;
            this.CBox_Target.Location = new System.Drawing.Point(707, 33);
            this.CBox_Target.Name = "CBox_Target";
            this.CBox_Target.Size = new System.Drawing.Size(249, 20);
            this.CBox_Target.TabIndex = 12;
            this.CBox_Target.SelectedIndexChanged += new System.EventHandler(this.CBox_Target_SelectedIndexChanged);
            // 
            // CBox_Source
            // 
            this.CBox_Source.FormattingEnabled = true;
            this.CBox_Source.Location = new System.Drawing.Point(101, 34);
            this.CBox_Source.Name = "CBox_Source";
            this.CBox_Source.Size = new System.Drawing.Size(258, 20);
            this.CBox_Source.TabIndex = 11;
            this.CBox_Source.SelectedIndexChanged += new System.EventHandler(this.CBox_Source_SelectedIndexChanged);
            // 
            // TargetBtn
            // 
            this.TargetBtn.Location = new System.Drawing.Point(626, 31);
            this.TargetBtn.Name = "TargetBtn";
            this.TargetBtn.Size = new System.Drawing.Size(75, 23);
            this.TargetBtn.TabIndex = 10;
            this.TargetBtn.Text = "导入目标";
            this.TargetBtn.UseVisualStyleBackColor = true;
            this.TargetBtn.Click += new System.EventHandler(this.TargetBtn_Click);
            // 
            // SourceBtn
            // 
            this.SourceBtn.Location = new System.Drawing.Point(20, 31);
            this.SourceBtn.Name = "SourceBtn";
            this.SourceBtn.Size = new System.Drawing.Size(75, 23);
            this.SourceBtn.TabIndex = 9;
            this.SourceBtn.Text = "源数据";
            this.SourceBtn.UseVisualStyleBackColor = true;
            this.SourceBtn.Click += new System.EventHandler(this.SourceBtn_Click);
            // 
            // Form_DTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1058, 589);
            this.Controls.Add(this.PanelMappingSettings);
            this.Name = "Form_DTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Transfer Service";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_DTS_Load);
            this.PanelMappingSettings.ResumeLayout(false);
            this.MappingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMappingSettings;
        private System.Windows.Forms.GroupBox MappingGroupBox;
        private System.Windows.Forms.Button MappingBtn;
        private System.Windows.Forms.ListView LV_Target;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView LV_Source;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox CBox_Target;
        private System.Windows.Forms.ComboBox CBox_Source;
        private System.Windows.Forms.Button TargetBtn;
        private System.Windows.Forms.Button SourceBtn;
    }
}

