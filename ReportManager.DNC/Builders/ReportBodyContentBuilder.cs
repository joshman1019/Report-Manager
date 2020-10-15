using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Borders;
using iText.Layout.Element;
using Report_Manager.Components;
using System;
using System.Collections.Generic;
using System.Data;

namespace Report_Manager.Builders
{
    public class ReportBodyContentBuilder
    {
        // Private Fields
        private DataTable m_ReportData;
        List<int> m_ColumnsAsDates;

        // Constructor
        public ReportBodyContentBuilder(DataTable reportData, List<int> columnsAsDates)
        {
            m_ReportData = reportData;
            m_ColumnsAsDates = columnsAsDates;
        }

        public ReportBody ReportBody()
        {            
            return new ReportBody(ColumnHeaderGenerator(), BodyContentGenerator());
        }

        private List<Cell> ColumnHeaderGenerator()
        {
            // Temporary list of Header Cells that will be returned
            List<Cell> innerHeaderCellsList = new List<Cell>();
            // For each column in report data table, create a new PdfPHeader cell that will contain it's name
            foreach (DataColumn column in m_ReportData.Columns)
            {
                Cell NewHeaderCell = new Cell();
                NewHeaderCell.SetBorder(Border.NO_BORDER);
                NewHeaderCell.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                NewHeaderCell.Add(new Paragraph(column.ColumnName)); 
                innerHeaderCellsList.Add(NewHeaderCell);
            }
            // Returns temporary list
            return innerHeaderCellsList;
        }

        private List<Cell> BodyContentGenerator()
        {
            // Temporary list of body content items (will be placed into final table as a stream)
            List<Cell> innerBodyContentCellList = new List<Cell>();
            foreach (DataRow dr in m_ReportData.Rows)
            {                
                // uses the column count to draw data out of _reportData table
                for (int i = 0; i <= m_ReportData.Columns.Count - 1; i++)
                {
                    if(m_ColumnsAsDates.Contains(i))
                    {
                        // Attempts to parse into a date - if date can be parsed, converts to short date string and adds cell
                        if (DateTime.TryParse(dr[i].ToString(), out DateTime TempTestDate))
                        {
                            Cell CellContent = new Cell();
                            CellContent.Add(new Paragraph(TempTestDate.ToShortDateString()));
                            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.COURIER); 
                            innerBodyContentCellList.Add(CellContent);
                        }
                        else
                        {
                            // If data does not parse, adds cell content as is
                            Cell CellContent = new Cell();
                            CellContent.Add(new Paragraph(dr[i].ToString()));
                            CellContent.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER)); 
                            innerBodyContentCellList.Add(CellContent);
                        }
                    }
                    else
                    {
                        Cell CellContent = new Cell();
                        CellContent.Add(new Paragraph(dr[i].ToString()));
                        CellContent.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER)); 
                        innerBodyContentCellList.Add(CellContent);
                    }
                }
            }
            // Returns the temporary list of body content cells to be passed to the report Body Content
            return innerBodyContentCellList;
        }
    }

}
