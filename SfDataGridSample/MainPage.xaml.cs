using Syncfusion.Maui.DataGrid;
using System.Collections;
using System.Reflection;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void sfGrid_SelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            var dataColumn = sfGrid.CurrentCellManager.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name == "dataColumn").GetValue(sfGrid.CurrentCellManager);

            if (dataColumn is DataColumnBase column)
            {
                var dataRow = column.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "DataRow").GetValue(column);
                if (dataRow != null)
                {
                    var element = dataRow.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "Element").GetValue(dataRow);
                    if (element != null)
                    {
                        var childrenProperty = element.GetType()
                                                      .GetRuntimeProperties()
                                                      .FirstOrDefault(x => x.Name == "Children")
                                                      ?.GetValue(element);

                        if (childrenProperty is IEnumerable children)
                        {
                            foreach (var child in children)
                            {
                                if (child is DataGridCell cell)
                                {
                                    if (cell.Content is Entry entry)
                                    {
                                        entry.Focus();
                                        break; // Exit the loop once the entry is found and focused
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
