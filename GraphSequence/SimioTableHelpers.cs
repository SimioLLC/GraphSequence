using SimioAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSequence
{
    public static class SimioTableHelpers
    {

        /// <summary>
        /// Demonstrates how to create a DataTable from a Simio ITable.
        /// The ITable is assumed to potentially have Property and State columns.
        /// The value for the State table is InteractiveValue.
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="simioTableName"></param>
        /// <returns></returns>
        public static DataTable CreateDataTableUsingInteractive(ITables tables, string simioTableName, out string explanation)
        {
            explanation = "";
            DataTable dt = null;

            try
            {
                ITable table = tables[simioTableName];
                if (table == null)
                {
                    explanation = $"No Simio Table has name={simioTableName}";
                    return null;
                }

                dt = new DataTable(simioTableName);
                List<string> colNames = new List<string>();

                List<string> propColNames = new List<string>();
                foreach (var col in table.Columns)
                {
                    colNames.Add(col.Name);
                    propColNames.Add(col.Name);
                }

                List<string> stateColNames = new List<string>();
                foreach (var stateCol in table.StateColumns)
                {
                    colNames.Add(stateCol.Name);
                    stateColNames.Add(stateCol.Name);
                }


                // The first entry in tablelist will have column names. All other entries are row values.
                List<string[]> tableRowList = new List<string[]>();

                int rowNumber = 0;
                foreach (var row in table.Rows)
                {
                    try
                    {
                        rowNumber++;
                        List<string> rowValues = new List<string>();

                        // Go through each Property column
                        foreach (var colName in propColNames)
                        {
                            var vv = row.Properties[colName.ToString()].Value;
                            rowValues.Add(vv ?? "");
                        }

                        // Go through each State column, and go to the StateRows to pick up the values
                        int stateRowNumber = rowNumber - 1;
                        foreach (var colName in stateColNames)
                        {
                            var vv = table.StateRows[stateRowNumber].StateValues[colName.ToString()].InteractiveValue;
                            if (vv == null) vv = table.StateRows[stateRowNumber].StateValues[colName.ToString()].PlanValue;
                            rowValues.Add(vv?.ToString() ?? "");
                        }

                        tableRowList.Add(rowValues.ToArray());

                    }
                    catch (Exception ex)
                    {
                        explanation = $"Data Row={rowNumber} Err={ex}";
                        return null;
                    }

                } // foreach row

                if (colNames != null && colNames.Any() )
                {
                    // Add the column names
                    foreach ( string colName in colNames)
                    {
                        dt.Columns.Add(colName);
                    }

                    // Add the data
                    foreach ( var dataArray in tableRowList)
                    {
                        dt.Rows.Add(dataArray);
                    }

                }
                return dt;
            }
            catch (Exception ex)
            {
                explanation = $"Create DataTable={simioTableName} Err={ex}";
                return null;
            }
        }

    }


}
