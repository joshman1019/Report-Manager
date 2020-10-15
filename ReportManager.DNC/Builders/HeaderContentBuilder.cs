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
        private StringBuilder m_HeaderContent;
        private bool m_IncludeReportDate;

        // Constructor
        public HeaderContentBuilder(StringBuilder headerContent, bool includeReportDate)
        {
            m_HeaderContent = headerContent;
            m_IncludeReportDate = includeReportDate;
        }

        // Returns a new header for placement into the ReportDocument
        public Header ReportHeader()
        {
            return new Header(HeaderAssembler());
        }

        // Determines how header content is constructed (includes date if indicated)
        private StringBuilder HeaderAssembler()
        {
            if (m_IncludeReportDate == true)
            {
                m_HeaderContent.AppendLine("");
                m_HeaderContent.AppendLine($"Date of Report: {DateTime.Today.ToShortDateString()}");
                return m_HeaderContent;
            }
            else return m_HeaderContent;
        }
    }
}
