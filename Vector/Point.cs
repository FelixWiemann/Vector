using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nepumuk
{
    public struct Point
    {
        private Vector coordinates;
        public Point(Vector point)
        {
            coordinates = point;
        }
        public Point(double[] coordinates)
        {
            this.coordinates = new Vector(coordinates);
        }

        public Vector Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

        #region calc

        /// <summary>
        /// get the vector that describes the direction and length you have to go from point one to point two
        /// </summary>
        /// <param name="mp1">point one</param>
        /// <param name="mp2">point two</param>
        /// <returns></returns>
        public static Vector GetVectorToPoint(Point mp1, Point mp2)
        {
            return mp2.Coordinates - mp1.Coordinates;
        }

        /// <summary>
        /// get the vector that describes the direction and length you have to go to point two
        /// </summary>
        /// <param name="mp2"></param>
        public void GetVectorToPoint(Point mp2)
        {
            this = new Point(GetVectorToPoint(this, mp2));
        }

        /// <summary>
        /// Calculate the distance between points
        /// </summary>
        /// <param name="mp1">point one</param>
        /// <param name="mp2">point two</param>
        /// <returns>double distance</returns>
        public static double CalcDistanceTo(Point mp1, Point mp2)
        {
            //set the distance between both points as a vector and calculate the length of the vector
            return Vector.getLength(mp1.Coordinates - mp2.Coordinates);
        }
        #endregion
    }

}
