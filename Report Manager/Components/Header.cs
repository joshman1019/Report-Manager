/// 
/// Generates a header to be used by the HeaderContentBuilder which will later be added to the report document. 
/// 
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Report_Manager.Components
{
    public class Header : PdfPTable
    {
        // Private Members
        private Fonts.Fonts FontPackage = new Fonts.Fonts();

        // Constructor
        public Header(StringBuilder headerContent, string fontFamily) : base()
        {
            // Sets column count to 1, width percentage (of base document) to 90%, and spacing after header to 20pts. 
            ResetColumnCount(1);
            WidthPercentage = 90;
            spacingAfter = 20;

            // Defaults the cell border color to white if other cells are added with a specific border color
            DefaultCell.BorderColor = BaseColor.WHITE;

            // Adds the content cell, filling header content and setting font family
            AddCell(ContentCell(headerContent, fontFamily));
        }

        // Cell that contains the content of the header table
        private PdfPCell ContentCell(StringBuilder headerContent, string fontFamily)
        {
            return new PdfPCell(new Paragraph(headerContent.ToString(), FontPackage.StandardSizeFont(fontFamily)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BorderColor = BaseColor.WHITE
            };
        }
    }
}
