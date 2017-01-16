using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nepumuk
{
    public class Line
    {

        #region Vars
        private Vector zeroVector;
        private Vector directionalVector;
        #endregion

        #region constructors

        public Line(int dim)
        {
            zeroVector = new Vector(dim);
            directionalVector = new Vector(dim);
        }
        /// <summary>
        /// Declare a line based on a zero vector and an directional vector
        /// </summary>
        /// <param name="zeroVector"></param>
        /// <param name="directionalVector"></param>
        public Line(Vector zeroVector, Vector directionalVector)
        {
            this.zeroVector = zeroVector;
            this.directionalVector = directionalVector;
        }

        public Line(Point point1, Point point2)
        {
            zeroVector = point1.Coordinates;
            directionalVector = Point.GetVectorToPoint(point1, point2);
        }

        /// <summary>
        /// Defines a line through origin
        /// </summary>
        /// <param name="directionalVector"></param>
        public Line(Vector directionalVector)
        {
            this.zeroVector = Vector.vOrigin;
            this.directionalVector = directionalVector;
        }

        #endregion

        #region get/set
        public Vector ZeroVector
        {//TODO rename -> similar to (0,0,0) (origin)
            set { zeroVector = value; }
            get { return zeroVector; }
        }
        public Vector DirectionalVector
        {
            set { directionalVector = value; }
            get { return directionalVector; }
        }
        #endregion

        #region calc

        // TODO rotate around, calc distance, schneiden sich, windschief, parallel, 
        // schnittpunktberechnung

        #endregion


    }
 
}
