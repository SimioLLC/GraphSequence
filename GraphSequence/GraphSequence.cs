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
                // Launch the form for graphing
                var form = new GraphSequenceForm(context);
                form.ShowDialog();
            }
        }

        #endregion
    }
}
