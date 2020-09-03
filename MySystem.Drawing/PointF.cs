using System;

namespace MySystem.Drawing
{
    /// <summary>
    ///    Represents an ordered pair of x and y coordinates that
    ///    define a point in a two-dimensional plane.
    /// </summary>
    public struct PointF : IEquatable<PointF>
    {
        /// <summary>
        ///    <para>
        ///       Creates a new instance of the <see cref='MySystem.Drawing.PointF'/> class
        ///       with member data left uninitialized.
        ///    </para>
        /// </summary>
        public static readonly PointF Empty = new PointF();
        private float x; // Do not rename (binary serialization) 
        private float y; // Do not rename (binary serialization) 

        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='MySystem.Drawing.PointF'/> class
        ///       with the specified coordinates.
        ///    </para>
        /// </summary>
        public PointF(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        ///    <para>
        ///       Gets a value indicating whether this <see cref='MySystem.Drawing.PointF'/> is empty.
        ///    </para>
        /// </summary>
        public bool IsEmpty { get { return x == 0f && y == 0f; } }

        /// <summary>
        ///    <para>
        ///       Gets the x-coordinate of this <see cref='MySystem.Drawing.PointF'/>.
        ///    </para>
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        ///    <para>
        ///       Gets the y-coordinate of this <see cref='MySystem.Drawing.PointF'/>.
        ///    </para>
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by a given <see cref='MySystem.Drawing.Size'/> .
        ///    </para>
        /// </summary>
        public static PointF operator +(PointF pt, Size sz) { return Add(pt, sz); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by the negative of a given <see cref='MySystem.Drawing.Size'/> .
        ///    </para>
        /// </summary>
        public static PointF operator -(PointF pt, Size sz) { return Subtract(pt, sz); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by a given <see cref='MySystem.Drawing.SizeF'/> .
        ///    </para>
        /// </summary>
        public static PointF operator +(PointF pt, SizeF sz) { return Add(pt, sz); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by the negative of a given <see cref='MySystem.Drawing.SizeF'/> .
        ///    </para>
        /// </summary>
        public static PointF operator -(PointF pt, SizeF sz) { return Subtract(pt, sz); }

        /// <summary>
        ///    <para>
        ///       Compares two <see cref='MySystem.Drawing.PointF'/> objects. The result specifies
        ///       whether the values of the <see cref='MySystem.Drawing.PointF.X'/> and <see cref='MySystem.Drawing.PointF.Y'/> properties of the two <see cref='MySystem.Drawing.PointF'/>
        ///       objects are equal.
        ///    </para>
        /// </summary>
        public static bool operator ==(PointF left, PointF right) { return left.X == right.X && left.Y == right.Y; }

        /// <summary>
        ///    <para>
        ///       Compares two <see cref='MySystem.Drawing.PointF'/> objects. The result specifies whether the values
        ///       of the <see cref='MySystem.Drawing.PointF.X'/> or <see cref='MySystem.Drawing.PointF.Y'/> properties of the two
        ///    <see cref='MySystem.Drawing.PointF'/> 
        ///    objects are unequal.
        /// </para>
        /// </summary>
        public static bool operator !=(PointF left, PointF right) { return !(left == right); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by a given <see cref='MySystem.Drawing.Size'/> .
        ///    </para>
        /// </summary>
        public static PointF Add(PointF pt, Size sz) { return new PointF(pt.X + sz.Width, pt.Y + sz.Height); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by the negative of a given <see cref='MySystem.Drawing.Size'/> .
        ///    </para>
        /// </summary>
        public static PointF Subtract(PointF pt, Size sz) { return new PointF(pt.X - sz.Width, pt.Y - sz.Height); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by a given <see cref='MySystem.Drawing.SizeF'/> .
        ///    </para>
        /// </summary>
        public static PointF Add(PointF pt, SizeF sz) { return new PointF(pt.X + sz.Width, pt.Y + sz.Height); }

        /// <summary>
        ///    <para>
        ///       Translates a <see cref='MySystem.Drawing.PointF'/> by the negative of a given <see cref='MySystem.Drawing.SizeF'/> .
        ///    </para>
        /// </summary>
        public static PointF Subtract(PointF pt, SizeF sz) { return new PointF(pt.X - sz.Width, pt.Y - sz.Height); }

        public override bool Equals(object obj) { return obj is PointF && Equals((PointF)obj); }

        public bool Equals(PointF other) { return this == other; }

        public override int GetHashCode() { return HashHelpers.Combine(X.GetHashCode(), Y.GetHashCode()); }

        public override string ToString() { return "{X=" + x.ToString() + ", Y=" + y.ToString() + "}"; }
    }
}