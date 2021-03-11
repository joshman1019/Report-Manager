using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Text;

namespace Report_Manager.Components
{
    public class Header : Table
    {
        // Constructor
        public Header(StringBuilder headerContent) : base(1)
        {
            SetWidth(UnitValue.CreatePercentValue(90));
            SetMarginBottom(20);

            AddCell(ContentCell(headerContent));
        }

        // Cell that contains the content of the header table
        private Cell ContentCell(StringBuilder headerContent)
        {
            Cell cell = new Cell();
            cell.Add(new Paragraph(headerContent.ToString()));
            cell.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD));
            cell.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            return cell; 
        }
    }
}
