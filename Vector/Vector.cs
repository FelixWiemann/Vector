using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nepumuk
{
    /// <summary>
    /// 
    /// </summary>
    public struct Vector
    {
        #region vardeclaration
        /// <summary>
        /// contains all values of the vector
        /// </summary>
        private double[] dValues; // 0: x, 1:y, 2:z, ...
        private const double EqualityTolerence = Double.Epsilon;
        public static readonly Vector vX_Axis = new Vector(1, 0, 0);
        public static readonly Vector vY_Axis = new Vector(0, 1, 0);
        public static readonly Vector vZ_Axis = new Vector(0, 0, 1);
        public static readonly Vector vOrigin = new Vector(0, 0, 0);


        /// <summary>
        /// contains the dimension of an vector
        /// </summary>
        private int nDimension;

        #region Errormessages
        public const string DIMENSION_ERROR = "The dimensions of both vectors are not the same, but need to be";
        public const string ROTATE_ERROR_TOMUCHDIMENSIONS = "can't roatate because too much dimensions";
        public const string DIMENSION_NOT_THREE = "the dimensions of the vector should be three or two to use this";
        #endregion
        #endregion

        #region Getter/Setter
        /// <summary>
        /// set/get all values of the vector
        /// </summary>
        public double[] nComponents
        {
            get
            {
                return dValues;
            }
            set
            {
                dValues = new double[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    dValues[i] = value[i];
                }
            }

        }

        /// <summary>
        /// set/get values of the vector at the given index
        /// </summary>
        /// <param name="index">index of the value you want to get in the vector, starting with 0 </param>
        /// <returns>value at the specific index</returns>
        public double this[int index]
        {
            get
            {
                return dValues[index];
            }

            set
            {
                dValues[index] = value;
            }
        }

        /// <summary>
        /// set/get the dimension of a vector
        /// </summary>
        public int Dimension
        {
            // TODO create new array, init vals to 0
            set { this.nDimension = value; }
            get { return this.nDimension;}
        }

        /// <summary>
        /// get/set X value of a 3 or 2 dimensional vector
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double X
        {
            get
            {
                if (nDimension <= 3 && nDimension > 0)
                {
                    return this.dValues[0];
                }
                else
                {
                    throw new ArgumentException(DIMENSION_NOT_THREE);
                }
            }
            set 
            { 
                if (nDimension <= 3 && nDimension >0)
                {
                    this.dValues[0] = value;
                }
                else
                {
                    throw new ArgumentException(DIMENSION_NOT_THREE);
                }
            }
        }
        /// <summary>
        /// get/set Y value of a 3 or 2 dimensional vector
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double Y
        {
            get
            {
                if (nDimension <= 3 && nDimension > 1)
                {
                    return this.dValues[1];
                }
                else
                {
                    throw new ArgumentException(DIMENSION_NOT_THREE);
                }
            }
            set
            {
                if (nDimension <= 3 && nDimension > 1)
                {
                    this.dValues[2] = value;
                }
                else
                {
                    throw new ArgumentException(DIMENSION_NOT_THREE);
                }
            }
        }
        /// <summary>
        /// get/set Z value of a 3 or 2 dimensional vector
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public double Z
        {
            get
            {
                if (nDimension <= 3 && nDimension > 2)
                {
                    return this.dValues[2];
                }
                else
                {
                    throw new ArgumentException(DIMENSION_NOT_THREE);
                }
            }
            set
            {
                if (nDimension <= 3 && nDimension > 2)
                {
                    this.dValues[2] = value;
                }
                else
                {
                    throw new ArgumentException(DIMENSION_NOT_THREE);
                }
            }
        }


        #endregion

        #region Constructors
        /// <summary>
        ///  constructor with an array of values
        /// </summary>
        /// <param name="values">array of values</param>
        public Vector(double[] values)
        {
            this.dValues = values;
            this.nDimension = values.Length;
        }

        /// <summary>
        /// constructor of an vector with three dimensions x,y,z
        /// </summary>
        /// <param name="x">x-value</param>
        /// <param name="y">y-value</param>
        /// <param name="z">z-value</param>
        public Vector(double x, double y, double z)
        {
            this.dValues = new double[3];
            dValues[0] = x;
            dValues[1] = y;
            dValues[2] = z;
            this.nDimension = 3;
        }

        /// <summary>
        /// constructor of an vector with two dimensions x,y
        /// </summary>
        /// <param name="x">x-value</param>
        /// <param name="y">y-value</param>
        public Vector(double x, double y)
        {
            dValues = new double[2];
            dValues[0] = x;
            dValues[1] = y;
            this.nDimension = 2;
        }

        /// <summary>
        /// constructor of an vector based on another one
        /// </summary>
        /// <param name="v">vector the new vector should be based on</param>
        public Vector(Vector v)
        {
            dValues = v.nComponents;
            this.nDimension = v.Dimension;
        }

        /// <summary>
        /// constructor of an vector based on a dimension
        /// </summary>
        /// <param name="dim">dimension the new vector should have</param>
        public Vector(int dim)
        {
            dValues = new double[dim];
            nDimension = dim;
        }

        #endregion

        #region Vectoroperators
        // Vectorcalculation

        // add
        public static Vector operator +(Vector v1, Vector v2)
        {

            if (v1.Dimension == v2.Dimension)
            {
                Vector result = new Vector(v1.nDimension);

                for (int i = 0; i < v1.Dimension; i++)
                {
                    result.nComponents[i] = v1.nComponents[i] + v2.nComponents[i];
                }

                return result;
            }
            else
            {
                throw new ArgumentException(DIMENSION_ERROR);
            }
        }
        /*public static Vector operator +(Vector v)
        *{
        *   Vector result = new Vector(v);
        *   
        *   return result;
        *}
        */

        //subtract
        public static Vector operator -(Vector v1, Vector v2)
        {

            if (v1.Dimension == v2.Dimension)
            {
                Vector result = new Vector(v1.Dimension);

                for (int i = 0; i < v1.Dimension; i++)
                {
                    result.nComponents[i] = v1.nComponents[i] - v2.nComponents[i];
                }

                return result;
            }
            else
            {
                throw new ArgumentException(DIMENSION_ERROR);
            }
        }
        public static Vector operator -(Vector v)
        {
            return new Vector(new Vector(v - v) - v);
        }
        // multiply
        public static Vector operator *(Vector v, double d)
        {
            Vector result = new Vector(v.Dimension);

            for (int i = 0; i < v.Dimension; i++)
            {
                result.nComponents[i] = v.nComponents[i] * d;
            }

            return result;

        }
        public static Vector operator *(double d, Vector v)
        {
            return v * d;
        }

        // divide
        public static Vector operator /(Vector v, double d)
        {
            Vector result = new Vector(v.Dimension);
            for (int i = 0; i < v.Dimension; i++)
            {
                result.nComponents[i] = v.nComponents[i] / d;
            }
            return result;
        }

        // equals =/ba.equals()
        public static bool operator ==(Vector v1, Vector v2)
        {
           if (v1.Dimension == v2.Dimension)
            {
                bool same = true;
                int i = 0;
                foreach (double val in v1.nComponents)
                {
                    if (Math.Abs(val - v2[i]) >= EqualityTolerence)
                    {
                        same = false;
                    }
                    i++;
                }
                return same;
            }
            else
            {
                return false;
            }
            
        }
        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return (Vector)obj == this;
            }
            else
            {
                return false;
            }
        } 
        // increment/decrement
        /// <summary>
        /// increments the vector with length 1
        /// </summary>
        /// <param name="v"> vector</param>
        /// <returns></returns>
        public static Vector operator ++(Vector v)
        {
            return new Vector(v + Vector.Normalize(v));

        }
        /// <summary>
        /// decrements vector with length 1
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator --(Vector v)
        {
            return new Vector(v-Vector.Normalize(v));

        }

        // is greather

        // is smaller

        // is greather or equals

        // is smaller or equals

        // does not equal
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Calcutilities
        // length
        /// <summary>
        /// returns the length of a vector
        /// </summary>
        /// <param name="vector">vector</param>
        /// <returns>double: length of vector</returns>
        public static double getLength(Vector vector)
        {
            return Math.Sqrt(SumSquaredComponents(vector));
        }
        /// <summary>
        /// returns the length of the current vector
        /// </summary>
        /// <returns>double: length of vector</returns>
        public double Length
        {
            get { return Vector.getLength(this); }
            set { this = new Vector((Vector.Normalize(this)) * value); }  
        }

        // cross-product

        // skalar-product
        

        // unitVector (is(static bool[vector]); is(), normalize(static vector[vector];normalize()
        /// <summary>
        /// returns the unitvector of an vector, with length 1
        /// </summary>
        /// <param name="vector">vector</param>
        /// <returns>vector: unitvector</returns>
        public static Vector unitVector(Vector vector)
        {
            Vector unitVector = new Vector(vector.Dimension);

            int i = 0;
            foreach (double val in vector.nComponents)
            {
                unitVector[i] = val / vector.Length;
                i++;
            }
            
            return unitVector;
        }
        /// <summary>
        /// returns an unitvector of the current vector
        /// </summary>
        /// <returns>unitvector</returns>
        public Vector unitVector()
        {
            return Vector.unitVector(this);
        }
        /// <summary>
        /// returns the unitvector of an vector (length=1)
        /// </summary>
        /// <param name="vector">vector</param>
        /// <returns>unitvector</returns>
        public static Vector Normalize(Vector vector)
        {
            double length = vector.Length;
            if (length == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                double[] vals = new double[vector.Dimension];
                for (int i = 0; i < vector.Dimension; i++)
                {
                    vals[i] = vector.nComponents[i] / length;
                }
                return new Vector(vals);                
            }
        }
        /// <summary>
        /// length of the vector will be made 1
        /// </summary>
        public void Normalize()
        {
            this = Vector.Normalize(this);
        }
        /// <summary>
        /// determines whether the vector is unitvector or not
        /// </summary>
        /// <param name="v">vector to check</param>
        /// <returns>bool: true -> unitvector; false -> no unitvector</returns>
        public static bool IsUnitVector(Vector v)
        {
            return (Math.Abs(v.Length - 1)<=EqualityTolerence);
        }
     
        /// <summary>
        /// determines wheter the current vector ist an unitvector or not
        /// with setting it true, the vector gets unified, falsing it again won't change the values of the unitvector. reasking the value will return true again
        /// </summary>
        public bool Unified
        {
            get
            {
                return Vector.IsUnitVector(this);
            }
            set
            {
                if (value)
                {
                    this = Vector.Normalize(this);
                }

            }
        }

        // who is bigger/smaller

        // sumcomponents

        public static double SumComponents(Vector vector)
        {
            double sum = 0;
            foreach (double val in vector.nComponents)
            {
                sum += val;
            }
            return sum;

        }
        public double SumComponents()
        {
            return Vector.SumComponents(this);
        }

        // sumsquared components
        /// <summary>
        /// squares all components of the vector and sums them up
        /// </summary>
        /// <param name="vector">vector</param>
        /// <returns>double: squaresum of components</returns>
        public static double SumSquaredComponents(Vector vector)
        {
            double squaredsum = 0;
            foreach (double val in vector.nComponents)
            {
                squaredsum += val*val;          
            }
            return squaredsum;
        }
        public double SumSquaredComponents()
        {
            return Vector.SumSquaredComponents(this);
        }
        #endregion

        #region Rotation
        // rotate a Vector
        public static Vector rotateAroundX(Vector vector, double degrees)
        {
            if (vector.Dimension == 3)
            {
                Vector solution = new Vector(0,0,0);
                solution[0] = vector[0];
                solution[1] = Math.Cos(degrees) * vector[1] - Math.Sin(degrees)*vector[2];
                solution[2] = Math.Cos(degrees) * vector[2] + Math.Sin(degrees)*vector[1];
                return new Vector(solution);
            }
            else
            {
                throw new ArgumentException(ROTATE_ERROR_TOMUCHDIMENSIONS);
            }            
        }
        public void rotateAroundX(double degrees)
        {
            this = Vector.rotateAroundX(this, degrees);
        }
        public static Vector[] rotateAroundX(Vector[] vs, double degrees)
        {
            for (int i = 0; i < vs.Length; )
            {
                vs[i] = Vector.rotateAroundX(vs[i],degrees);
                i++;
            }
            return vs;
        }
        public static Vector rotateAroundY(Vector vector, double degrees)
        {
            if (vector.Dimension == 3)
            {
                Vector solution = new Vector(0,0,0);
                solution[0] = Math.Sin(degrees) * vector[2] + Math.Cos(degrees) * vector[0];
                solution[1] = vector[1];
                solution[2] = Math.Cos(degrees) * vector[2] - Math.Sin(degrees) * vector[0];
                return new Vector(solution);
            }
            else
            {
                throw new ArgumentException(ROTATE_ERROR_TOMUCHDIMENSIONS);
            }
        }
        public void rotateAroundY(double degrees)
        {
            this = Vector.rotateAroundY(this, degrees);
        }
        public static Vector[] rotateAroundY(Vector[] vs, double degrees)
        {
            for (int i = 0; i < vs.Length; )
            {
                vs[i] = Vector.rotateAroundY(vs[i], degrees);
                i++;
            }
            return vs;
        }
        public static Vector rotateAroundZ(Vector vector, double degrees)
        {
            if (vector.Dimension == 3)
            {
                Vector solution = new Vector(0,0,0);
                solution[0] = Math.Cos(degrees) * vector[0] - Math.Sin(degrees) * vector[1];
                solution[1] = Math.Sin(degrees) * vector[0] + Math.Cos(degrees) * vector[1];
                solution[2] = vector[2];
                return new Vector(solution);
            }
            else
            {
                if (vector.Dimension == 2)
                {
                    Vector solution = new Vector(0,0);
                    solution[0] = Math.Cos(degrees) * vector[0] - Math.Sin(degrees) * vector[1];
                    solution[1] = Math.Sin(degrees) * vector[0] + Math.Cos(degrees) * vector[1];
                    return solution;
                }

                else
                {
                    throw new ArgumentException(ROTATE_ERROR_TOMUCHDIMENSIONS);
                }
            }
        }
        public void rotateAroundZ(double degrees)
        {
            this = Vector.rotateAroundZ(this, degrees);
        }
        public static Vector[] rotateAroundZ(Vector[] vs, double degrees)
        {
            for (int i = 0; i < vs.Length; )
            {
                vs[i] = Vector.rotateAroundZ(vs[i], degrees);
                i++;
            }
            return vs;
        }

        /// <summary>
        /// rotates a Vector around an axis described by another vector with a number of degrees
        /// </summary>
        /// <param name="VectorToRotate"></param>
        /// <param name="AxisVector"></param>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static Vector rotateAroundVector(Vector VectorToRotate, Vector AxisVector, double degrees)
        {
            // goal: axisvector has to match one of the axis. we choose y-axis because reasons
            // first: rotate around y - axis, so that x component becomes zero
            // second: rotate around x - axis, so that z component becomes zero -> the vector we rotate around becomes y
            double degreesaroundy=0,  degreesaroundx=0;
            degreesaroundy = Math.Atan(AxisVector[0] / (AxisVector[2]+Double.Epsilon));
            if (Double.IsNaN(degreesaroundy))
            {
                degreesaroundy = 0;
            }
            degreesaroundy *= -1;
            AxisVector.rotateAroundY(degreesaroundy);
            degreesaroundx = Math.Atan(AxisVector[2] / AxisVector[1] + Double.Epsilon);
            if (Double.IsNaN(degreesaroundx))
            {
                degreesaroundx = 0;
            }
            degreesaroundx *= -1;
            //Console.WriteLine("degrees around y: " + degreesaroundy / Math.PI * 180 + " degrees around x: " + degreesaroundx / Math.PI * 180);
            
            AxisVector.rotateAroundX(degreesaroundx);
            // now that the system has a new layout, we have to match our vector to that new layout. it should stay the same vector
            VectorToRotate.rotateAroundY(degreesaroundy);
            VectorToRotate.rotateAroundX(degreesaroundx);
            // now we can rotate it around the vector 
            VectorToRotate.rotateAroundY(degrees);
            // we have to calculate the system back to the original one
            
            VectorToRotate.rotateAroundX(-degreesaroundx);
            VectorToRotate.rotateAroundY(-degreesaroundy);
            // last but not least we can return this shit
            return VectorToRotate;
        }
        
        /// <summary>
        /// rotates the vector around the axisvector
        /// </summary>
        /// <param name="AxisVector"></param>
        /// <param name="degrees"></param>
        public void rotateAroundVector(Vector AxisVector, double degrees)
        {
            this = rotateAroundVector(this, AxisVector, degrees);
        }


        #endregion

        #region Calculation with Dots
        // Calc with dots
        // distance between two points (two vectors, one to this)
        /// <summary>
        /// calculates the distance between two points
        /// </summary>
        /// <param name="v1">coordinates of point one</param>
        /// <param name="v2">coordinates of point two</param>
        /// <returns>double: distance</returns>
        public static double GetDistance(Vector v1, Vector v2)
        {
            double[] vals = new double[v1.nDimension];
            for (int i = 0; i < v1.nComponents.Length; i++)
            {
                vals[i] = v1[i] - v2[i];
            }
            return Math.Abs(new Vector(vals).Length);
        }
        #endregion

        #region Vectordescription
        /// <summary>
        /// returns a string-value of the vector 
        /// </summary>
        /// <param name="form">openingvalue, eg. "(", "{",...</param>
        /// <param name="seperator">seperatorvalue, e.g. ";"</param>
        /// <returns>string</returns>
        public string ToString(string form, string seperator)
        {
            string formback;
            switch (form)
            {
                case "(":
                    formback = ")";
                    break;
                case "[":
                    formback = "]";
                    break;
                case "{":
                    formback = "}";
                    break;
                case "/":
                    formback = "\\";
                    break;
                case "\\":
                    formback = "/";
                    break;
                case "\"":
                    formback = "\"";
                    break;
                case null:
                    form = "(";
                    formback = ")";
                    break;
                default:
                    form = "(";
                    formback = ")";
                    break;
            }
            if (seperator == null)
            {
                seperator = ";";
            }

            string tostring = form;
            foreach (double val in this.nComponents)
            {
                tostring += val.ToString() + seperator;
            }
            tostring = tostring.Substring(0, tostring.Length - seperator.Length);
            tostring += formback;
            return tostring;
        }
        /// <summary>
        /// returns a string-value of the vector
        /// </summary>
        /// <returns>string: format: "(value 1;value 2;...;value n)</returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

        #endregion
    }

    
    

}
