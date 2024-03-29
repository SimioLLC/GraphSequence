﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Drawing;
using SimioAPI;
using SimioAPI.Extensions;
using System.Xml;
using System.IO;
using System.ComponentModel.Design.Serialization;

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

                string colForFilter = dt.Columns[0].ColumnName;
                string colForName = dt.Columns[1].ColumnName;
                string colForSuccessor = dt.Columns[2].ColumnName;

                if (dt.Columns.Count < 3)
                {
                    throw new Exception($"Table={tableCombo.Text} must have at least 3 columns, but found={dt.Columns.Count}");
                }

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

        /// <summary>
        /// A sequence item holds the three necessary data to describe a sequence of dependencies.
        /// </summary>
        internal class SequenceItem
        {
            /// <summary>
            /// 'Our' ID
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// A pointer to the ID of our successor
            /// </summary>
            public string SuccessorId { get; set; }

            /// <summary>
            /// The material
            /// </summary>
            public string Material { get; set; }

            public SequenceItem(string id, string successorId, string material)
            {
                this.Id = id;
                this.SuccessorId = successorId;
                this.Material = material;
            }
        }

        /// <summary>
        /// Draw the directed graph for the dependency sequences.
        /// </summary>
        private static void CreateDirectedGraphFromSequences(DataTable dtRoutings, string filepath, string filterColumn, string idColumn, string successorColumn, string filterText)
        {
            try
            {
                // Create a new XML document
                XmlDocument doc = new XmlDocument();

                // Create the root element for the DGML file
                XmlElement root = doc.CreateElement("DirectedGraph", "http://schemas.microsoft.com/vs/2009/dgml");

                // Add the root element to the document
                doc.AppendChild(root);

                Dictionary<string, SequenceItem> nodeDict = new Dictionary<string, SequenceItem>();

                DataTable _filteredRoutings = dtRoutings.AsEnumerable()
                          .Where(row => row.Field<String>(filterColumn) == filterText)
                          .OrderByDescending(row => row.Field<String>(filterColumn))
                          .CopyToDataTable();


                // Add nodes
                XmlElement xeNodes = doc.CreateElement("Nodes");
                root.AppendChild(xeNodes);

                foreach (DataRow dr in _filteredRoutings.Rows)
                {
                    string id = dr[idColumn] as string;

                    if (!nodeDict.Keys.Contains(id))
                    {
                        string filter = dr[filterColumn] as string;
                        string successorId = dr[successorColumn] as string;
                        nodeDict.Add(id, new SequenceItem(id, successorId, filter));

                        // Create a node element
                        XmlElement xeNode= doc.CreateElement("Node");
                        xeNode.SetAttribute("Id", id);
                        xeNode.SetAttribute("Label", id);

                        xeNodes.AppendChild(xeNode);
                    }
                }

                // Now run through the dictionary to make sure there are no forgotten nodes.
                // These would be successors and if there are no nodes then they are terminator nodes
                Dictionary<string, SequenceItem> terminatorDict = new Dictionary<string, SequenceItem>();
                foreach ( SequenceItem si in nodeDict.Values)
                {
                    if ( (false == nodeDict.ContainsKey(si.SuccessorId)) && (false == terminatorDict.ContainsKey(si.SuccessorId)))
                    {
                        terminatorDict.Add(si.SuccessorId, new SequenceItem(si.SuccessorId, string.Empty, si.Material));
                    }
                }

                foreach ( SequenceItem si in terminatorDict.Values)
                {
                    XmlElement xeNode = doc.CreateElement("Node");
                    xeNode.SetAttribute("Id", si.Id);
                    xeNode.SetAttribute("Label", si.Id);
                    xeNodes.AppendChild(xeNode);
                }

                // Do the edges
                XmlElement xeEdges = doc.CreateElement("Links");
                root.AppendChild(xeEdges);

                foreach (SequenceItem item in nodeDict.Values)
                {
                    // Create an edge element if there is a successor
                    if (!string.IsNullOrEmpty(item.SuccessorId))
                    {
                        XmlElement xeEdge = doc.CreateElement("Link");
                        xeEdge.SetAttribute("Source", item.Id);
                        xeEdge.SetAttribute("Target", item.SuccessorId);
                        xeEdge.SetAttribute("Label", "");

                        xeEdges.AppendChild(xeEdge);
                    }
                }

                doc.Save(filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Draw the directed graph for sequences.
        /// </summary>
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
                            successor += " ";
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

        private void buttonSaveGraph_Click(object sender, EventArgs e)
        {
            if (DtRoutings.Rows.Count == 0)
                return;
            if (string.IsNullOrEmpty(filterCombo.Text))
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Directed Graph as DGML file";
            dialog.Filter = "DGML Files (*.dgml)|*.dgml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilepath = dialog.FileName;

                CreateDirectedGraphFromSequences(DtRoutings, selectedFilepath, FilterColumn, NameColumn, SuccessorColumn, filterCombo.Text);
            }
        }
    }
}
