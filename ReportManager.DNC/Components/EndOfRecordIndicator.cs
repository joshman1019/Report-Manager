/// Creates an end of record indicator which will lie at the end of a report document if desired. 

using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout.Element;

namespace Report_Manager.Components
{
    public class EndOfRecordIndicator : Paragraph
    {
        // Constructor
        public EndOfRecordIndicator()
        {
            Paragraph paragraph = new Paragraph("*** END OF RECORD ***");
            paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            paragraph.SetFont(PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD));
            SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            Add(paragraph); 
        }
    }
}
