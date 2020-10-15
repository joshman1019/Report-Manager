/// Creates an end of record indicator which will lie at the end of a report document if desired. 
using iTextSharp.text;

namespace Report_Manager.Components
{
    public class EndOfRecordIndicator : Paragraph
    {
        // Private Members
        private Fonts.Fonts fontPackage = new Fonts.Fonts();        

        // Constructor
        public EndOfRecordIndicator(string fontFamily)
        {           
            Add(new Paragraph("*** END OF RECORD ***", fontPackage.BoldStandardSizeFont(fontFamily))
            {
                Alignment = Element.ALIGN_CENTER        // Element alignment configuration
            });
        }
    }
}
