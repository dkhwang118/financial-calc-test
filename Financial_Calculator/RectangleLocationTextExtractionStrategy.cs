/* RectangleLocationTextExtractionStrategy.cs
 * Author: Chris Haas
 * Modified by: David K Hwang
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Financial_Calculator
{
    public class RectangleLocationTextExtractionStrategy : LocationTextExtractionStrategy
    {
        // hold each coordinate
        public List<PdfTextAndPos> textCoordinates = new List<PdfTextAndPos>();

        public override void RenderText(TextRenderInfo renderInfo)
        {
            base.RenderText(renderInfo);

            // Get bounding box for the chunk of text
            var bottomLeft = renderInfo.GetDescentLine().GetStartPoint();
            var topRight = renderInfo.GetAscentLine().GetEndPoint();

            // Create the rectangle
            var rectangle = new iTextSharp.text.Rectangle(
                                                           bottomLeft[Vector.I1],
                                                           bottomLeft[Vector.I2],
                                                           topRight[Vector.I1],
                                                           topRight[Vector.I2]
                                                           );

            // Add rectangle to collection
            textCoordinates.Add(new PdfTextAndPos(rectangle, renderInfo.GetText()));
        }
    }
    
    
}
