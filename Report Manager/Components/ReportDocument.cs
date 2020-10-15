///
/// Returns a document to be used by the report generator which will hold all of the data inserted into it
/// 
using iTextSharp.text;

namespace Report_Manager.Components
{
    public class ReportDocument : Document
    {
        public ReportDocument(float leftMargin, float rightMargin, float topMargin, float bottomMargin, int pageSize) : base()
        {
            /// Sets page size based on the following integer values
            /// 1 - Letter Standard
            /// 2 - Letter Landscape
            /// 3 - Legal Standard
            /// 4 - Legal Landscape            
            switch (pageSize)
            {                
                case 1:
                    SetPageSize(iTextSharp.text.PageSize.LETTER);
                    break;
                case 2:
                    SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());                    
                    break;
                case 3:
                    SetPageSize(iTextSharp.text.PageSize.LEGAL);
                    break;
                case 4:
                    SetPageSize(iTextSharp.text.PageSize.LEGAL.Rotate());
                    break;
                default:
                    SetPageSize(iTextSharp.text.PageSize.LETTER);
                    break;
            }

            // Sets page margins
            SetMargins(leftMargin, rightMargin, topMargin, bottomMargin);
        }
    }
}
