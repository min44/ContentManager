module ContentManager.Core.CommandUtils

open System
open System.Globalization
open System.IO
open System.Reflection
open ContentManager.Core
open ContentManager.Utils
open Microsoft.Win32
open Microsoft.FSharp.Reflection
open NPOI.SS.UserModel
open NPOI.XSSF.UserModel
open Literals
open Constructors
open Abstract
open Messages
open Types

let GetCellValue (cell: ICell) =
    match cell.CellType with
    | CellType.Numeric -> cell.NumericCellValue.ToString(CultureInfo.InvariantCulture).Replace(",", ".")
    | CellType.String  -> $@"{cell.StringCellValue.Trim()}"
    | CellType.Boolean -> if cell.BooleanCellValue then "1" else "0"
    | _                -> String.Empty


let GetAll (workBook: XSSFWorkbook) sheetName getDefaultItem =
    Logger.Info("CommandUtils GetAll")
    let sheet = workBook.GetSheet sheetName
    let headerRow = sheet.GetRow 0
    let getValue (row: IRow) = row.GetCell >> GetCellValue
    let collRange = seq { 0s..headerRow.LastCellNum - 1s }
    let rowRange  = seq { 1..sheet.LastRowNum }
    let headerNames = Seq.map int collRange |> Seq.map (getValue headerRow)
    let getPropertyInfos item =
        item.GetType()
        |> FSharpType.GetRecordFields
        |> Seq.filter(fun x -> Seq.contains x.Name headerNames)
        |> Seq.map(fun pi -> headerNames |> Seq.findIndex(fun x -> x = pi.Name), pi)
    let setValues item row (i, info: PropertyInfo) =
        let value = getValue row i
        let setValue value = info.SetValue(item, value)
        match info.PropertyType with
        | a when a = typeof<string> -> setValue value
        | a when a = typeof<int>    -> setValue (int value)
        | _                         -> Logger.Debug("Error: Unexpected value type")
    let processRows row =
        let item = getDefaultItem()
        getPropertyInfos item |> Seq.iter (setValues item row)
        item
    rowRange
    |> Seq.map sheet.GetRow
    |> Seq.map processRows
    |> Seq.toList


let GetContext workBook =
    Logger.Info("CommandUtils GetContext")
    { Elements          = GetAll workBook SF.Elements ItemElementConstructor.Default
      Parameters        = GetAll workBook SF.Parameters ItemParameterConstructor.Default
      Types             = GetAll workBook SF.Types ItemTypeConstructor.Default
      TypeParameters    = GetAll workBook SF.TypeParameters TypeParameterConstructor.Default
      ParameterValues   = GetAll workBook SF.ParameterValues ParameterValueConstructor.Default }


let Save (workbook: XSSFWorkbook) path = 
    use writeStream = new FileStream(path, FileMode.Create, FileAccess.Write)
    workbook.Write(writeStream)


let CreateSheetsIfNotExist (workbook: XSSFWorkbook) =
    Logger.Info("CommandUtils CreateSheetsIfNotExist")
    let createSheet name columns =
        let sheet = workbook.CreateSheet name
        let row = sheet.CreateRow 0
        columns |> Seq.iteri(fun i (column: string) -> (row.CreateCell i).SetCellValue column)
    SF.AllSheets
    |> Seq.filter(fun (name, _) -> name |> workbook.GetSheet |> isNull)
    |> Seq.iter(fun (name, columns) -> createSheet name columns)


let LoadData dispatch path =
    Logger.Info("CommandUtils LoadData")
    if File.Exists path then
        use readStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)
        let workbook = XSSFWorkbook(readStream)
        CreateSheetsIfNotExist workbook
        GetContext workbook |> Some |> SetContext |> dispatch
        Save workbook path
    else
        let workbook = XSSFWorkbook()
        CreateSheetsIfNotExist workbook
        GetContext workbook |> Some |> SetContext |> dispatch
        Save workbook path


let GetFile =
    Logger.Info("CommandUtils GetFile")
    let filter = "Excel files|*.xlsx"
    function
    | Open ->
        let dialog = OpenFileDialog()
        dialog.Filter <- filter
        if dialog.ShowDialog().HasValue then dialog.FileName else String.Empty
    | Create ->
        let dialog = SaveFileDialog()
        dialog.Filter <- filter
        if dialog.ShowDialog().HasValue then dialog.FileName else String.Empty