///
/// The job of the header content builder is to take in a StringBuilder and add a report date if requested
/// Other elements can also be added to the header content by modifying the HeaderAssembler method
/// 
using System;
using System.Text;
using Report_Manager.Components;

namespace Report_Manager.Builders
{
    public class HeaderContentBuilder
    {
        // Private fields
        private StringBuilder _headerContent;
        private bool _includeReportDate;
        private string _fontFamily;

        // Constructor
        public HeaderContentBuilder(StringBuilder headerContent, bool includeReportDate, string fontFamily)
        {
            _headerContent = headerContent;
            _includeReportDate = includeReportDate;
            _fontFamily = fontFamily;
        }

        // Returns a new header for placement into the ReportDocument
        public Header ReportHeader()
        {
            return new Header(HeaderAssembler(), _fontFamily);
        }

        // Determines how header content is constructed (includes date if indicated)
        private StringBuilder HeaderAssembler()
        {
            if (_includeReportDate == true)
            {
                _headerContent.AppendLine("");
                _headerContent.AppendLine($"Date of Report: {DateTime.Today.ToShortDateString()}");
                return _headerContent;
            }
            else return _headerContent;
        }
    }
}
