///
/// Creates a report body which will be returned by the Body Content Builder. This report body will later be added to the report document.
/// 
using iText.IO.Font.Constants;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.Generic;


namespace Report_Manager.Components
{
    public class ReportBody : Table
    {
        // Private Members
        private List<Cell> m_HeaderCells = new List<Cell>();
        private List<Cell> m_BodyContentCells = new List<Cell>();
        private int m_FontSize; 

        // Constructor
        public ReportBody(List<Cell> headerCells, List<Cell> bodyContentCells, int fontSize = 10) : base(headerCells.Count)
        {
            SetWidth(UnitValue.CreatePercentValue(100)); 
            m_HeaderCells = headerCells;
            m_BodyContentCells = bodyContentCells;
            m_FontSize = fontSize; 
            SetMargin(5); 

            // Construction
            AddHeaderCells();
            AddReportBodyCells();
        }

        private void AddHeaderCells()
        {
            // Adds the header cells constructed by the BodyContentBuilder
            foreach (Cell headerCell in m_HeaderCells)
            {
                headerCell.SetFontFamily(StandardFonts.COURIER_BOLD);
                headerCell.SetFontSize(m_FontSize); 
                AddHeaderCell(headerCell);
            }
        }

        private void AddReportBodyCells()
        {
            // Adds the body content cells constructed by the BodyContentBuilder
            foreach (Cell bodyContentCell in m_BodyContentCells)
            {
                bodyContentCell.SetFontSize(m_FontSize); 
                AddCell(bodyContentCell);
            }
        }

        
    }
}
