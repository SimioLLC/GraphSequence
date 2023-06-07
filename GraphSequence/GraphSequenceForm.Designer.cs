
namespace GraphSequence
{
    partial class GraphSequenceForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphSequenceForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tableCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSaveGraph = new System.Windows.Forms.Button();
            this.buttonShapeColor = new System.Windows.Forms.Button();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTextPaddingFactor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.materialLabel = new System.Windows.Forms.Label();
            this.filterCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tableCombo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonSaveGraph);
            this.panel1.Controls.Add(this.buttonShapeColor);
            this.panel1.Controls.Add(this.txtFontSize);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTextPaddingFactor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDelimiter);
            this.panel1.Controls.Add(this.materialLabel);
            this.panel1.Controls.Add(this.filterCombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 169);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(668, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(595, 44);
            this.label7.TabIndex = 22;
            this.label7.Text = "Select \'Table\' to get data for Graph.   Table must have 3 columns.; first column " +
    "used as filter, second used as sequence and thrid used as successor sequence.";
            // 
            // tableCombo
            // 
            this.tableCombo.FormattingEnabled = true;
            this.tableCombo.Location = new System.Drawing.Point(78, 8);
            this.tableCombo.Name = "tableCombo";
            this.tableCombo.Size = new System.Drawing.Size(561, 21);
            this.tableCombo.TabIndex = 14;
            this.tableCombo.SelectedIndexChanged += new System.EventHandler(this.tableComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Table:";
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(1091, 137);
            this.buttonSaveGraph.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(173, 28);
            this.buttonSaveGraph.TabIndex = 22;
            this.buttonSaveGraph.Text = "Save as DGML file...";
            this.toolTip1.SetToolTip(this.buttonSaveGraph, "Save data as a DirectedGraph (DGML) file.");
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            this.buttonSaveGraph.Click += new System.EventHandler(this.buttonSaveGraph_Click);
            // 
            // buttonShapeColor
            // 
            this.buttonShapeColor.Location = new System.Drawing.Point(1091, 105);
            this.buttonShapeColor.Name = "buttonShapeColor";
            this.buttonShapeColor.Size = new System.Drawing.Size(173, 28);
            this.buttonShapeColor.TabIndex = 21;
            this.buttonShapeColor.Text = "Shape Color...";
            this.buttonShapeColor.UseVisualStyleBackColor = true;
            this.buttonShapeColor.Click += new System.EventHandler(this.buttonShapeColor_Click);
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(894, 105);
            this.txtFontSize.Margin = new System.Windows.Forms.Padding(4);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(38, 20);
            this.txtFontSize.TabIndex = 20;
            this.txtFontSize.Text = "5.0";
            this.txtFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFontSize.TextChanged += new System.EventHandler(this.txtFontSize_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(756, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Font Size:";
            // 
            // txtTextPaddingFactor
            // 
            this.txtTextPaddingFactor.Location = new System.Drawing.Point(609, 125);
            this.txtTextPaddingFactor.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextPaddingFactor.Name = "txtTextPaddingFactor";
            this.txtTextPaddingFactor.Size = new System.Drawing.Size(44, 20);
            this.txtTextPaddingFactor.TabIndex = 18;
            this.txtTextPaddingFactor.Text = "0.0";
            this.txtTextPaddingFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTextPaddingFactor.TextChanged += new System.EventHandler(this.txtTextPaddingFactor_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Text Padding Factor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "New Line Character:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(227, 125);
            this.txtDelimiter.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(28, 20);
            this.txtDelimiter.TabIndex = 15;
            this.txtDelimiter.Text = "^";
            this.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDelimiter.TextChanged += new System.EventHandler(this.txtDelimiter_TextChanged);
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Location = new System.Drawing.Point(17, 68);
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(32, 13);
            this.materialLabel.TabIndex = 10;
            this.materialLabel.Text = "Filter:";
            // 
            // filterCombo
            // 
            this.filterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCombo.FormattingEnabled = true;
            this.filterCombo.Location = new System.Drawing.Point(78, 65);
            this.filterCombo.Margin = new System.Windows.Forms.Padding(4);
            this.filterCombo.Name = "filterCombo";
            this.filterCombo.Size = new System.Drawing.Size(561, 21);
            this.filterCombo.TabIndex = 9;
            this.filterCombo.SelectedIndexChanged += new System.EventHandler(this.materialCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(665, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(607, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select \'Filter\' to create the Graph (see the Graph tab). Use the Plus and Minus (" +
    "+/-) to zoom, and arrow keys to pan.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 169);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1276, 466);
            this.panel2.TabIndex = 1;
            // 
            // gViewer
            // 
            this.gViewer.ArrowheadLength = 10D;
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackwardEnabled = false;
            this.gViewer.BuildHitTree = true;
            this.gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewer.EdgeInsertButtonVisible = true;
            this.gViewer.FileName = "";
            this.gViewer.ForwardEnabled = false;
            this.gViewer.Graph = null;
            this.gViewer.InsertingEdge = false;
            this.gViewer.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer.LayoutEditingEnabled = true;
            this.gViewer.Location = new System.Drawing.Point(0, 0);
            this.gViewer.LooseOffsetForRouting = 0.25D;
            this.gViewer.Margin = new System.Windows.Forms.Padding(2);
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = true;
            this.gViewer.NeedToCalculateLayout = true;
            this.gViewer.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer.PaddingForEdgeRouting = 8D;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveAsImageEnabled = true;
            this.gViewer.SaveAsMsaglEnabled = true;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.SaveGraphButtonVisible = true;
            this.gViewer.SaveInVectorFormatEnabled = true;
            this.gViewer.Size = new System.Drawing.Size(1276, 466);
            this.gViewer.TabIndex = 0;
            this.gViewer.TightOffsetForRouting = 0.125D;
            this.gViewer.ToolBarIsVisible = true;
            this.gViewer.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer.Transform")));
            this.gViewer.UndoRedoButtonsVisible = true;
            this.gViewer.WindowZoomButtonPressed = false;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.PaleGreen;
            // 
            // GraphSequenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1276, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphSequenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Sequence";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label materialLabel;
        public System.Windows.Forms.ComboBox filterCombo;
        private System.Windows.Forms.Label label2;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDelimiter;
        public System.Windows.Forms.TextBox txtTextPaddingFactor;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonShapeColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox tableCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSaveGraph;
    }
}