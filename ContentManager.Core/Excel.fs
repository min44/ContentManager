module ContentManager.Core.Excel

open System.Data

//private static void AddDataTableHeader(ISheet sheet, DataTable dataTable)
//{
//    var headerRow = sheet.GetRow(0);
//
//    for (var cellIndex = 0; cellIndex < headerRow?.LastCellNum; cellIndex++)
//    {
//        var cell = headerRow.GetCell(cellIndex);
//        dataTable.Columns.Add(cell.GetCellValue());
//    }
//}
//
//let GetDataTable sheetName =
//    let sheet = Workbook.GetSheet(sheetName)
//    let dataTable = new DataTable()
//    
//    AddDataTableHeader(sheet, dataTable)
//
//    for (var rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
//        AddDataTableRow(sheet, dataTable, rowIndex)
//    dataTable