///
/// Fonts to be used by the Document Constructor - It is recommended to use Courier, as it is a single spaced character set. 
/// 
using iTextSharp.text;

namespace Report_Manager.Fonts
{
    public class Fonts
    {      
        public Font LargeFont(string fontFamily)        
        {
            return FontFactory.GetFont(fontFamily, 10);
        }

        public Font BoldLargeSizeFont(string fontFamily)
        {
            return FontFactory.GetFont(fontFamily, 10, Font.BOLD);
        }

        public Font ItalicLargeSizeFont(string fontFamily)
        {
            return FontFactory.GetFont(fontFamily, 10, Font.ITALIC);
        }

        public Font StandardSizeFont(string fontFamily)
        {
            return FontFactory.GetFont(fontFamily, 8);
        }

        public Font BoldStandardSizeFont(string fontFamily)
        {
            return FontFactory.GetFont(fontFamily, 8, Font.BOLD);
        }

        public Font ItalicStandardSizeFont(string fontFamily)
        {
            return FontFactory.GetFont(fontFamily, 8, Font.ITALIC);
        }
    }
}
