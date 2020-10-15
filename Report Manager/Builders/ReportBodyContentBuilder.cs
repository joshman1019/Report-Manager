///
/// The purpose of the Report Body Content Builder is to create and return the body content of the report which will be added to the 
/// report document
/// 
using System;
using System.Collections.Generic;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Report_Manager.Components;

namespace Report_Manager.Builders
{
    public class ReportBodyContentBuilder
    {
        // Private Fields
        private DataTable _reportData;
        private string _fontFamily;
        List<int> _columnsAsDates;

        // Private Members
        private Fonts.Fonts fontPackage = new Fonts.Fonts();

        // Constructor
        public ReportBodyContentBuilder(DataTable reportData, string fontFamily, List<int> columnsAsDates)
        {
            _reportData = reportData;
            _fontFamily = fontFamily;
            _columnsAsDates = columnsAsDates;
        }

        public ReportBody ReportBody()
        {            
            return new ReportBody(ColumnHeaderGenerator(), BodyContentGenerator());
        }

        // Gets column count from report data table to be used later to assemble the PdfPTable
        private int ColumnCounter()
        {
            return _reportData.Columns.Count;
        }

        private List<PdfPHeaderCell> ColumnHeaderGenerator()
        {
            // Temporary list of Header Cells that will be returned
            List<PdfPHeaderCell> innerHeaderCellsList = new List<PdfPHeaderCell>();
            // For each column in report data table, create a new PdfPHeader cell that will contain it's name
            foreach (DataColumn column in _reportData.Columns)
            {                
                PdfPHeaderCell NewHeaderCell = new PdfPHeaderCell
                {
                    BorderColor = BaseColor.WHITE,
                    // Sets the background color of the header row. Modify this line to change color as developer desires
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    // Takes name assigned to each column and adds as phrase to each cell
                    // Developer may wish to assign a human readable name to each column prior to passing table
                    Phrase = new Phrase(column.ColumnName.ToUpper(),fontPackage.BoldStandardSizeFont(_fontFamily))
                };
                // Adds NewHeaderCell to temporary list
                innerHeaderCellsList.Add(NewHeaderCell);
            }
            // Returns temporary list
            return innerHeaderCellsList;
        }

        private List<PdfPCell> BodyContentGenerator()
        {
            // Temporary list of body content items (will be placed into final table as a stream)
            List<PdfPCell> innerBodyContentCellList = new List<PdfPCell>();
            foreach (DataRow dr in _reportData.Rows)
            {                
                // uses the column count to draw data out of _reportData table
                for (int i = 0; i <= _reportData.Columns.Count - 1; i++)
                {
                    if(_columnsAsDates.Contains(i))
                    {
                        // Attempts to parse into a date - if date can be parsed, converts to short date string and adds cell
                        if (DateTime.TryParse(dr[i].ToString(), out DateTime TempTestDate))
                        {
                            PdfPCell CellContent = new PdfPCell(new Phrase(TempTestDate.ToShortDateString(), fontPackage.StandardSizeFont(_fontFamily)))
                            {
                                BorderColor = BaseColor.WHITE
                            };
                            innerBodyContentCellList.Add(CellContent);
                        }
                        else
                        {
                            // If data does not parse, adds cell content as is
                            PdfPCell CellContent = new PdfPCell(new Phrase(dr[i].ToString(), fontPackage.StandardSizeFont(_fontFamily)))
                            {
                                BorderColor = BaseColor.WHITE
                            };
                            innerBodyContentCellList.Add(CellContent);
                        }
                    }
                    else
                    {                        
                        PdfPCell CellContent = new PdfPCell(new Phrase(dr[i].ToString(), fontPackage.StandardSizeFont(_fontFamily)))
                        {
                            BorderColor = BaseColor.WHITE
                        };
                        innerBodyContentCellList.Add(CellContent);
                    }
                }
            }
            // Returns the temporary list of body content cells to be passed to the report Body Content
            return innerBodyContentCellList;
        }
    }

}
