using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Drawing;
using SimioAPI;
using SimioAPI.Extensions;

namespace GraphSequence
{
    public partial class GraphSequenceForm : Form
    {
        public DataTable DtRoutings { get; set; } = null;
        public string FilterColumn { get; set; }
        public string NameColumn { get; set; }
        public string SuccessorColumn { get; set; }

        DataTable _filteredRoutings;

        public double _textPaddingFactor = 0.0;
        public double _fontSize = 5.0;

        IDesignContext _context;

        public GraphSequenceForm(IDesignContext context)
        {   
            try
            { 
                _context = context;
                InitializeComponent();
                var dt = new DataTable();
                dt.Columns.Add("tableName");
                foreach (var table in _context.ActiveModel.Tables)
                {
                    string[] t = new string[] { table.Name };
                    dt.Rows.Add(t);
                }
                dt.DefaultView.Sort = "tableName";
                var distictNames = dt.DefaultView.ToTable(false, "tableName");
                foreach (DataRow row in distictNames.Rows)
                {
                    tableCombo.Items.Add(row["tableName"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ITable table = _context.ActiveModel.Tables[tableCombo.Text];
                if (table == null)
                {
                    throw new Exception($"No Simio Table has name={tableCombo.Text}");
                }

                var dt = SimioTableHelpers.CreateDataTableUsingInteractive(table);
                if (dt == null)
                {
                    throw new Exception($"Cannot locate table name={tableCombo.Text}");
                }

                if (dt.Columns.Count < 3)
                {
                    throw new Exception($"Table must have at least 3 columns={tableCombo.Text}");
                }

                string colForFilter = dt.Columns[0].ColumnName;
                string colForName = dt.Columns[1].ColumnName;
                string colForSuccessor = dt.Columns[2].ColumnName;

                // Launch the form for graphing
                DtRoutings = dt;
                FilterColumn = colForFilter;
                NameColumn = colForName;
                SuccessorColumn = colForSuccessor;

                DtRoutings.DefaultView.Sort = FilterColumn;
                var distictNames = DtRoutings.DefaultView.ToTable(true, FilterColumn);

                filterCombo.Items.Clear();
                foreach (DataRow row in distictNames.Rows)
                {
                    filterCombo.Items.Add(row[FilterColumn]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void DrawSequences()
        {
            try
            {
                Graph gg = new Graph("graph");                

                Dictionary<string, string> nodeDict = new Dictionary<string, string>();

                _filteredRoutings = DtRoutings.AsEnumerable()
                          .Where(row => row.Field<String>(FilterColumn) == filterCombo.Text)
                          .OrderByDescending(row => row.Field<String>(FilterColumn))
                          .CopyToDataTable();

                foreach (DataRow dr in _filteredRoutings.Rows)
                {
                    string name = dr[NameColumn] as string;
                    string successor = dr[SuccessorColumn] as string;

                    char delimiter = ' ';
                    if (txtDelimiter.Text.Length > 0)
                    {
                        delimiter = txtDelimiter.Text.First();

                        string[] names = name.Split(delimiter);
                        string[] successors = successor.Split(delimiter);

                        if (names.Length > 0)
                        {
                            int maxLength = 0;
                            for (int i = 0; i < names.Length; i++)
                            {
                                names[i].Trim();
                                if (names[i].Length > maxLength) maxLength = names[i].Length;

                            }
                            for (int i = 0; i < names.Length; i++)
                            {
                                var textLength = Math.Ceiling(_textPaddingFactor * maxLength) - names[i].Length;
                                for (int j = 0; j < textLength; j++)
                                {
                                    names[i] = names[i] + " ";
                                }
                                if (i == 0) name = names[i];
                                else name = name + Environment.NewLine + names[i];
                            }
                        }

                        if (successors.Length > 0)
                        {
                            int maxLength = 0;
                            for (int i = 0; i < successors.Length; i++)
                            {
                                successors[i].Trim();
                                if (successors[i].Length > maxLength) maxLength = successors[i].Length;

                            }
                            for (int i = 0; i < successors.Length; i++)
                            {
                                var textLength = Math.Ceiling(_textPaddingFactor * maxLength) - successors[i].Length;
                                for (int j = 0; j < textLength; j++)
                                {
                                    successors[i] = successors[i] + " ";
                                }
                                if (i == 0) successor = successors[i];
                                else successor = successor + Environment.NewLine + successors[i];
                            }
                        }
                    }
                    else
                    {
                        name = name.Trim();
                        var textLength = Math.Ceiling(_textPaddingFactor * name.Length);
                        for (int j = 0; j < textLength; j++)
                        {
                            name = name + " ";
                        }
                        successor = successor.Trim();
                        textLength = Math.Ceiling(_textPaddingFactor * successor.Length);
                        for (int j = 0; j < textLength; j++)
                        {
                            successor = successor + " ";
                        }
                    }

                    var edge = gg.AddEdge(name, successor);
                    string ss = $"Name={name} Successor={successor}";
                }

                foreach (var node in gg.Nodes)
                {
                    node.Label.GeometryLabel = new Microsoft.Msagl.Core.Layout.Label();
                    node.Attr.FillColor = new Microsoft.Msagl.Drawing.Color((byte)colorDialog1.Color.R, (byte)colorDialog1.Color.G, (byte)colorDialog1.Color.B); ;
                    node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                    node.Attr.LabelMargin = 15;
                    node.Attr.LineWidth = 1;
                    var font = new Font(node.Label.FontName, (float)node.Label.FontSize);
                    node.Label.FontSize = _fontSize;
                    Size ressize = TextRenderer.MeasureText(node.Label.Text, font);                   
                }

                gViewer.Graph = gg;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void materialCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSequences();
        }

        private void txtDelimiter_TextChanged(object sender, EventArgs e)
        {
            DrawSequences();
        }

        private void txtTextPaddingFactor_TextChanged(object sender, EventArgs e)
        {
            double textPaddingFactor = 0;

            if (double.TryParse(txtTextPaddingFactor.Text, out textPaddingFactor))
            {
                _textPaddingFactor = textPaddingFactor;
                DrawSequences();
            }
           
        }

        private void txtFontSize_TextChanged(object sender, EventArgs e)
        {
            double fontSize = 0;

            if (double.TryParse(txtFontSize.Text, out fontSize))
            {
                _fontSize= fontSize;
                DrawSequences();
            }            
        }

        private void buttonShapeColor_Click(object sender, EventArgs e)
        {
            var dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK) { DrawSequences(); }
        }

    }
}
