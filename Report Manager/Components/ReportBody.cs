///
/// Creates a report body which will be returned by the Body Content Builder. This report body will later be added to the report document.
/// 
using System.Collections.Generic;
using iTextSharp.text.pdf;

namespace Report_Manager.Components
{
    public class ReportBody : PdfPTable
    {
        // Private Members
        private List<PdfPHeaderCell> _headerCells = new List<PdfPHeaderCell>();
        private List<PdfPCell> _bodyContentCells = new List<PdfPCell>();            

        // Constructor
        public ReportBody(List<PdfPHeaderCell> headerCells, List<PdfPCell> bodyContentCells) : base()
        {
            _headerCells = headerCells;
            _bodyContentCells = bodyContentCells;

            // ReportBody Configuration
            ResetColumnCount(headerCells.Count);      // Sets the column count
            WidthPercentage = 100;                    // Width of body content (percentage)   
            HeaderRows = 1;                           // Number of header rows
            spacingAfter = 5;                         // Spacing after body content

            // Construction
            AddHeaderCells();
            AddReportBodyCells();
        }

        private void AddHeaderCells()
        {
            // Adds the header cells constructed by the BodyContentBuilder
            foreach (PdfPHeaderCell headerCell in _headerCells)
            {
                AddCell(headerCell);
            }
        }

        private void AddReportBodyCells()
        {
            // Adds the body content cells constructed by the BodyContentBuilder
            foreach (PdfPCell bodyContentCell in _bodyContentCells)
            {
                AddCell(bodyContentCell);
            }
        }

        
    }
}
