using SimioAPI;
using SimioAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GraphSequence
{
    class GraphSequence : IDesignAddIn
    {
        #region IDesignAddIn Members

        /// <summary>
        /// Property returning the name of the add-in. This name may contain any characters and is used as the display name for the add-in in the UI.
        /// </summary>
        public string Name
        {
            get { return "Graph Sequence"; }
        }

        /// <summary>
        /// Property returning a s hort description of what the add-in does.
        /// </summary>
        public string Description
        {
            get { return "Design-Time AddIn to Draw a graph based on a ImmedidSequence Dependency table."; }
        }

        /// <summary>
        /// Property returning an icon to display for the add-in in the UI.
        /// </summary>
        public System.Drawing.Image Icon
        {
            get { return Properties.Resources.sequence; }
        }

        /// <summary>
        /// Method called when the add-in is run.
        /// </summary>
        public void Execute(IDesignContext context)
        {
            // This example code places some new objects from the Standard Library into the active model of the project.
            if (context.ActiveModel != null)
            {
                //var form = new Form1();

                // Create a DataTable from the collection of Simio Tables and the Table name.
                // Note/Todo: These can be set in a schema section
                string explanation = "";
                string tableName = "ImmediateSuccessorSequences";

                var dt = SimioTableHelpers.CreateDataTableUsingInteractive(context.ActiveModel.Tables, tableName, out explanation);
                if (dt == null)
                {
                    throw new Exception($"Cannot locate table name={tableName}");
                }

                if (dt.Columns.Count < 3)
                {
                    throw new Exception($"Table must have at least 3 columns={tableName}");
                }

                string colForFilter = dt.Columns[0].ColumnName;
                string colForName = dt.Columns[1].ColumnName;
                string colForSuccessor = dt.Columns[2].ColumnName;

                // Launch the form for graphing
                var form = new GraphSequenceForm();
                form.DtRoutings = dt;
                form.FilterColumn = colForFilter;
                form.NameColumn = colForName;
                form.SuccessorColumn = colForSuccessor;
                form.ShowDialog();
            }
        }

        #endregion
    }
}
