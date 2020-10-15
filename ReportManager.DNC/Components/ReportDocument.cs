
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
///
/// Returns a document to be used by the report generator which will hold all of the data inserted into it
/// 
namespace Report_Manager.Components
{
    public class ReportDocument : PdfDocument
    {
        public ReportDocument(PdfWriter writer, int pageSize) : base(writer)
        {
            /// Sets page size based on the following integer values
            /// 1 - Letter Standard
            /// 2 - Letter Landscape
            /// 3 - Legal Standard
            /// 4 - Legal Landscape            
            switch (pageSize)
            {                
                case 1:
                    SetDefaultPageSize(PageSize.LETTER); 
                    break;
                case 2:
                    SetDefaultPageSize(PageSize.LETTER.Rotate());
                    break;
                case 3:
                    SetDefaultPageSize(PageSize.LEGAL);
                    break;
                case 4:
                    SetDefaultPageSize(PageSize.LEGAL.Rotate());
                    break;
                default:
                    SetDefaultPageSize(PageSize.LETTER);
                    break;
            }
        }
    }
}
