
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
            this.buttonShapeColor = new System.Windows.Forms.Button();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTextPaddingFactor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialLabel = new System.Windows.Forms.Label();
            this.materialCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSaveGraph = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSaveGraph);
            this.panel1.Controls.Add(this.buttonShapeColor);
            this.panel1.Controls.Add(this.txtFontSize);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTextPaddingFactor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDelimiter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.materialLabel);
            this.panel1.Controls.Add(this.materialCombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 153);
            this.panel1.TabIndex = 0;
            // 
            // buttonShapeColor
            // 
            this.buttonShapeColor.Location = new System.Drawing.Point(768, 84);
            this.buttonShapeColor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShapeColor.Name = "buttonShapeColor";
            this.buttonShapeColor.Size = new System.Drawing.Size(144, 28);
            this.buttonShapeColor.TabIndex = 21;
            this.buttonShapeColor.Text = "Shape Color...";
            this.buttonShapeColor.UseVisualStyleBackColor = true;
            this.buttonShapeColor.Click += new System.EventHandler(this.buttonShapeColor_Click);
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(674, 89);
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
            this.label5.Location = new System.Drawing.Point(571, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Font Size:";
            // 
            // txtTextPaddingFactor
            // 
            this.txtTextPaddingFactor.Location = new System.Drawing.Point(460, 89);
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
            this.label4.Location = new System.Drawing.Point(336, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Text Padding Factor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "New Line Character:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(174, 89);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(28, 20);
            this.txtDelimiter.TabIndex = 15;
            this.txtDelimiter.Text = "^";
            this.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDelimiter.TextChanged += new System.EventHandler(this.txtDelimiter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(918, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Note: To graph, the table must be named \'ImmediateSuccessorSequences\'.  It must h" +
    "ave 3 columns; first column used as filter, second used as sequence and thrid us" +
    "ed as successor sequence.";
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Location = new System.Drawing.Point(8, 22);
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(32, 13);
            this.materialLabel.TabIndex = 10;
            this.materialLabel.Text = "Filter:";
            // 
            // materialCombo
            // 
            this.materialCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialCombo.FormattingEnabled = true;
            this.materialCombo.Location = new System.Drawing.Point(46, 16);
            this.materialCombo.Name = "materialCombo";
            this.materialCombo.Size = new System.Drawing.Size(316, 21);
            this.materialCombo.TabIndex = 9;
            this.materialCombo.SelectedIndexChanged += new System.EventHandler(this.materialCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select \'Filter\' to create the Graph (see the Graph tab). Use the Plus and Minus (" +
    "+/-) to zoom, and arrow keys to pan.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 482);
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
            this.gViewer.Size = new System.Drawing.Size(956, 482);
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
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Location = new System.Drawing.Point(768, 116);
            this.buttonSaveGraph.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(144, 28);
            this.buttonSaveGraph.TabIndex = 22;
            this.buttonSaveGraph.Text = "Save as DGML file...";
            this.toolTip1.SetToolTip(this.buttonSaveGraph, "Save data as a DirectedGraph (DGML) file.");
            this.buttonSaveGraph.UseVisualStyleBackColor = true;
            this.buttonSaveGraph.Click += new System.EventHandler(this.buttonSaveGraph_Click);
            // 
            // GraphSequenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(956, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphSequenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Sequence";
            this.Load += new System.EventHandler(this.GraphSequenceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label materialLabel;
        public System.Windows.Forms.ComboBox materialCombo;
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSaveGraph;
    }
}