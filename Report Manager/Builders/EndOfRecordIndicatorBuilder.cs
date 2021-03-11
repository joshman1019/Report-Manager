///
/// The purpose of the end of record indicator builder is to create and return a small string indicating that a report has ended. 
/// This is especially helpful for multiple page reports where a reader must be assured that they have every page of the document. 
/// 
using Report_Manager.Components;

namespace Report_Manager.Builders
{
    public class EndOfRecordIndicatorBuilder
    {
        // Returns end of record indicator to be added to the end of every report if desired
        public EndOfRecordIndicator EndOfRecordIndicator()
        {
            return new EndOfRecordIndicator();
        }
    }
}
