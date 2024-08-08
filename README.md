# How do you set the focus to an entry control in a DataGridTemplateColumn when any cell in row is selected.
In this article, we will show you how to set the focus to an entry control in a DataGridTemplateColumn when any cell in row is selected in [.Net Maui DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## xaml
```
<syncfusion:SfDataGrid x:Name="sfGrid" Margin="10"
                       SelectionMode="Single"
                       NavigationMode="Cell"
                       SelectionChanged="sfGrid_SelectionChanged"
                       GridLinesVisibility="Both"
                       ColumnWidthMode="Auto"
                       HeaderGridLinesVisibility="Both"
                       AutoGenerateColumnsMode="None"
                       ItemsSource="{Binding Employees}">

    <syncfusion:SfDataGrid.Columns>
        <syncfusion:DataGridTextColumn MappingName="EmployeeID"
                                       HeaderText="Employee ID" />
        <syncfusion:DataGridTextColumn MappingName="Name"
                                       HeaderText="Employee Name" />
        <syncfusion:DataGridTextColumn MappingName="Title"
                                       HeaderText="Designation" />
        <syncfusion:DataGridTemplateColumn MappingName="ContactID"
                                           HeaderText="Contact ID">
            <syncfusion:DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Entry Text="{Binding ContactID}"
                           FontSize="16"
                           WidthRequest="100"
                           Margin="0"
                           ReturnType="Next" />
                </DataTemplate>
            </syncfusion:DataGridTemplateColumn.CellTemplate>
        </syncfusion:DataGridTemplateColumn>
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>
```

## C#
The below code illustrates how to set the focus to an entry control in a DataGridTemplateColumn when any cell in row is selected in DataGrid.
```
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
```
 ![EntryFocus.png](https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI3OTgyIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.g6oBhC5MEtTj-kP0ThaJ_N2ipAxDUpPdRq2JrylpqS0)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-do-you-set-the-focus-to-an-entry-control-in-a-DataGridTemplateColumn-of-a-selected-row)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to to set the focus to an entry control in a DataGridTemplateColumn when any cell in row is selected in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!