using Ford.MFalHarnesAnalyze.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using ExcelInt = Microsoft.Office.Interop.Excel;

namespace Ford.MFalHarnesAnalyze.Office
{
    public static class ExcelHelper
    {
        #region Constants

        /// <summary>
        /// Index of the row and column to begin writting the table.
        /// </summary>
        private const int HomeRowColum = 3;

        private static ExcelInt.Range range;

        #endregion Constants

        #region Public Methods

        /// <summary>
        /// Opens an Excel workbook with the report of thetake rate calculation.
        /// </summary>
        /// <param name="calculation">Informatio of the calculations.</param>
        public static void GenerateExcelReport(List<AnalyzeCalculation> calculation, string regionName)
        {
            int row = 3;
            int col = 1;
            int maxCol = 0;
            CultureInfo oldCI = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var excelApp = new ExcelInt.Application();

            try
            {
                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                ExcelInt.Worksheet workSheet = (ExcelInt.Worksheet)excelApp.ActiveSheet;

                //Title
                workSheet.Cells[1, 1] = "Test Report:";
                workSheet.Cells[1, 2] = regionName ?? "No name";

                //Headers
                workSheet.Cells[row, col] = "MFal";
                col++;
                workSheet.Cells[row, col] = "Total Take Rate";
                col++;
                workSheet.Cells[row, col] = "Harness Base Number";
                col++;
                workSheet.Cells[row, col] = "Circuit Count";
                col++;
                workSheet.Cells[row, col] = "Wire Name";

                maxCol = col;

                foreach (var item in calculation)
                {
                    col = 1;
                    row++;
                    workSheet.Cells[row, col] = item.Mfal;
                    col++;
                    workSheet.Cells[row, col] = item.TotalTakeRate;
                    col++;
                    workSheet.Cells[row, col] = item.HarnessBaseNumber;
                    col++;
                    workSheet.Cells[row, col] = item.CircuitCount;
                    col++;
                    workSheet.Cells[row, col] = item.WireName;
                    if (item.MfalDetail.Count > 0)
                    {
                        int rowStart = row + 1;
                        int rowEnd = 0;
                        foreach (var subitem in item.MfalDetail)
                        {
                            col = 1;
                            row++;
                            workSheet.Cells[row, col] = item.Mfal;
                            col++;
                            workSheet.Cells[row, col] = subitem.TotalTakeRate;
                            col++;
                            workSheet.Cells[row, col] = subitem.HarnessBaseNumber;
                            col++;
                            workSheet.Cells[row, col] = subitem.CircuitCount;
                            col++;

                            workSheet.Cells[row, col] = subitem.WireName;
                        }
                        rowEnd = row;
                        string rangeRows = rowStart + ":" + rowEnd;
                        range = workSheet.Rows[rangeRows] as ExcelInt.Range;
                        range.Group();
                        workSheet.Outline.SummaryRow = ExcelInt.XlSummaryRow.xlSummaryAbove;
                        workSheet.Outline.ShowLevels(1);
                    }
                }
            }
            catch (Exception e)
            {
                excelApp.Quit();
                throw;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = oldCI;
            }
        }

        public static void GenerateExcelReportByHarness(List<AnalyzeCalculation> calculation, string regionName)
        {
            int row = 3;
            int col = 1;
            int maxCol = 0;
            CultureInfo oldCI = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var excelApp = new ExcelInt.Application();

            try
            {
                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                ExcelInt.Worksheet workSheet = (ExcelInt.Worksheet)excelApp.ActiveSheet;

                //Title
                workSheet.Cells[1, 1] = "Test Report:";
                workSheet.Cells[1, 2] = regionName ?? "No name";

                //Headers
                workSheet.Cells[row, col] = "Harness Base Number";
                col++;
                workSheet.Cells[row, col] = "MFal";
                col++;
                workSheet.Cells[row, col] = "Total Take Rate";
                col++;

                workSheet.Cells[row, col] = "Circuit Count";
                col++;
                workSheet.Cells[row, col] = "Wire Name";
                maxCol = col;

                foreach (var item in calculation)
                {
                    col = 1;
                    row++;
                    workSheet.Cells[row, col] = item.HarnessBaseNumber;
                    col++;
                    workSheet.Cells[row, col] = item.Mfal;
                    col++;
                    workSheet.Cells[row, col] = item.TotalTakeRate;
                    col++;                    
                    workSheet.Cells[row, col] = item.CircuitCount;
                    col++;
                    workSheet.Cells[row, col] = item.WireName;
                    if (item.MfalDetail.Count > 0)
                    {
                        int rowStart = row + 1;
                        int rowEnd = 0;
                        foreach (var subitem in item.MfalDetail)
                        {
                            col = 1;
                            row++;
                            workSheet.Cells[row, col] = subitem.HarnessBaseNumber;
                            col++;
                            workSheet.Cells[row, col] = item.Mfal;
                            col++;
                            workSheet.Cells[row, col] = subitem.TotalTakeRate;
                            col++;
                            
                            workSheet.Cells[row, col] = subitem.CircuitCount;
                            col++;

                            workSheet.Cells[row, col] = subitem.WireName;
                        }
                        rowEnd = row;
                        string rangeRows = rowStart + ":" + rowEnd;
                        range = workSheet.Rows[rangeRows] as ExcelInt.Range;
                        range.Group();
                        workSheet.Outline.SummaryRow = ExcelInt.XlSummaryRow.xlSummaryAbove;
                        workSheet.Outline.ShowLevels(1);
                    }
                }
            }
            catch (Exception e)
            {
                excelApp.Quit();
                throw;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = oldCI;
            }
        }

        #endregion Public Methods
    }
}