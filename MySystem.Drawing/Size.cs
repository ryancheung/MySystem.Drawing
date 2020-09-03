using System;

namespace MySystem.Drawing
{
    /**
     * Represents a dimension in 2D coordinate space
     */
    /// <summary>
    ///    Represents the size of a rectangular region
    ///    with an ordered pair of width and height.
    /// </summary>
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref='MySystem.Drawing.Size'/> class.
        /// </summary>
        public static readonly Size Empty = new Size();

        private int width; // Do not rename (binary serialization) 
        private int height; // Do not rename (binary serialization) 

        /**
         * Create a new Size object from a point
         */
        /// <summary>
        ///    <para>
        ///       Initializes a new instance of the <see cref='MySystem.Drawing.Size'/> class from
        ///       the specified <see cref='MySystem.Drawing.Point'/>.
        ///    </para>
        /// </summary>
        public Size(Point pt)
        {
            width = pt.X;
            height = pt.Y;
        }

        /**
         * Create a new Size object of the specified dimension
         */
        /// <summary>
        ///    Initializes a new instance of the <see cref='MySystem.Drawing.Size'/> class from
        ///    the specified dimensions.
        /// </summary>
        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        ///    Converts the specified <see cref='MySystem.Drawing.Size'/> to a
        /// <see cref='MySystem.Drawing.SizeF'/>.
        /// </summary>
        public static implicit operator SizeF(Size p) { return new SizeF(p.Width, p.Height); }

        /// <summary>
        ///    <para>
        ///       Performs vector addition of two <see cref='MySystem.Drawing.Size'/> objects.
        ///    </para>
        /// </summary>
        public static Size operator +(Size sz1, Size sz2) { return Add(sz1, sz2); }

        /// <summary>
        ///    <para>
        ///       Contracts a <see cref='MySystem.Drawing.Size'/> by another <see cref='MySystem.Drawing.Size'/>
        ///    </para>
        /// </summary>
        public static Size operator -(Size sz1, Size sz2) { return Subtract(sz1, sz2); }

        /// <summary>
        /// Multiplies a <see cref="Size"/> by an <see cref="int"/> producing <see cref="Size"/>.
        /// </summary>
        /// <param name="left">Multiplier of type <see cref="int"/>.</param>
        /// <param name="right">Multiplicand of type <see cref="Size"/>.</param>
        /// <returns>Product of type <see cref="Size"/>.</returns>
        public static Size operator *(int left, Size right) { return Multiply(right, left); }

        /// <summary>
        /// Multiplies <see cref="Size"/> by an <see cref="int"/> producing <see cref="Size"/>.
        /// </summary>
        /// <param name="left">Multiplicand of type <see cref="Size"/>.</param>
        /// <param name="right">Multiplier of type <see cref="int"/>.</param>
        /// <returns>Product of type <see cref="Size"/>.</returns>
        public static Size operator *(Size left, int right) { return Multiply(left, right); }

        /// <summary>
        /// Divides <see cref="Size"/> by an <see cref="int"/> producing <see cref="Size"/>.
        /// </summary>
        /// <param name="left">Dividend of type <see cref="Size"/>.</param>
        /// <param name="right">Divisor of type <see cref="int"/>.</param>
        /// <returns>Result of type <see cref="Size"/>.</returns>
        public static Size operator /(Size left, int right) { return new Size(unchecked(left.width / right), unchecked(left.height / right)); }

        /// <summary>
        /// Multiplies <see cref="Size"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="left">Multiplier of type <see cref="float"/>.</param>
        /// <param name="right">Multiplicand of type <see cref="Size"/>.</param>
        /// <returns>Product of type <see cref="SizeF"/>.</returns>
        public static SizeF operator *(float left, Size right) { return Multiply(right, left); }

        /// <summary>
        /// Multiplies <see cref="Size"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="left">Multiplicand of type <see cref="Size"/>.</param>
        /// <param name="right">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type <see cref="SizeF"/>.</returns>
        public static SizeF operator *(Size left, float right) { return Multiply(left, right); }

        /// <summary>
        /// Divides <see cref="Size"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="left">Dividend of type <see cref="Size"/>.</param>
        /// <param name="right">Divisor of type <see cref="int"/>.</param>
        /// <returns>Result of type <see cref="SizeF"/>.</returns>
        public static SizeF operator /(Size left, float right)
        { return new SizeF(left.width / right, left.height / right); }

        /// <summary>
        ///    Tests whether two <see cref='MySystem.Drawing.Size'/> objects
        ///    are identical.
        /// </summary>
        public static bool operator ==(Size sz1, Size sz2) { return sz1.Width == sz2.Width && sz1.Height == sz2.Height; }

        /// <summary>
        ///    <para>
        ///       Tests whether two <see cref='MySystem.Drawing.Size'/> objects are different.
        ///    </para>
        /// </summary>
        public static bool operator !=(Size sz1, Size sz2) { return !(sz1 == sz2); }

        /// <summary>
        ///    Converts the specified <see cref='MySystem.Drawing.Size'/> to a
        /// <see cref='MySystem.Drawing.Point'/>.
        /// </summary>
        public static explicit operator Point(Size size) { return new Point(size.Width, size.Height); }

        /// <summary>
        ///    Tests whether this <see cref='MySystem.Drawing.Size'/> has zero
        ///    width and height.
        /// </summary>
        public bool IsEmpty { get { return width == 0 && height == 0; } }

        /**
         * Horizontal dimension
         */

        /// <summary>
        ///    <para>
        ///       Represents the horizontal component of this
        ///    <see cref='MySystem.Drawing.Size'/>.
        ///    </para>
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /**
         * Vertical dimension
         */

        /// <summary>
        ///    Represents the vertical component of this
        /// <see cref='MySystem.Drawing.Size'/>.
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        ///    <para>
        ///       Performs vector addition of two <see cref='MySystem.Drawing.Size'/> objects.
        ///    </para>
        /// </summary>
        public static Size Add(Size sz1, Size sz2) { return
           new Size(unchecked(sz1.Width + sz2.Width), unchecked(sz1.Height + sz2.Height)); }

        /// <summary>
        ///   Converts a SizeF to a Size by performing a ceiling operation on
        ///   all the coordinates.
        /// </summary>
        public static Size Ceiling(SizeF value) { return
           new Size(unchecked((int)Math.Ceiling(value.Width)), unchecked((int)Math.Ceiling(value.Height))); }

        /// <summary>
        ///    <para>
        ///       Contracts a <see cref='MySystem.Drawing.Size'/> by another <see cref='MySystem.Drawing.Size'/> .
        ///    </para>
        /// </summary>
        public static Size Subtract(Size sz1, Size sz2) { return
           new Size(unchecked(sz1.Width - sz2.Width), unchecked(sz1.Height - sz2.Height)); }

        /// <summary>
        ///   Converts a SizeF to a Size by performing a truncate operation on
        ///   all the coordinates.
        /// </summary>
        public static Size Truncate(SizeF value) { return new Size(unchecked((int)value.Width), unchecked((int)value.Height)); }

        /// <summary>
        ///   Converts a SizeF to a Size by performing a round operation on
        ///   all the coordinates.
        /// </summary>
        public static Size Round(SizeF value) { return
           new Size(unchecked((int)Math.Round(value.Width)), unchecked((int)Math.Round(value.Height))); }

        /// <summary>
        ///    <para>
        ///       Tests to see whether the specified object is a
        ///    <see cref='MySystem.Drawing.Size'/> 
        ///    with the same dimensions as this <see cref='MySystem.Drawing.Size'/>.
        /// </para>
        /// </summary>
        public override bool Equals(object obj) { return obj is Size && Equals((Size)obj); }

        public bool Equals(Size other) { return this == other; }

        /// <summary>
        ///    <para>
        ///       Returns a hash code.
        ///    </para>
        /// </summary>
        public override int GetHashCode() { return HashHelpers.Combine(Width, Height); }

        /// <summary>
        ///    <para>
        ///       Creates a human-readable string that represents this
        ///    <see cref='MySystem.Drawing.Size'/>.
        ///    </para>
        /// </summary>
        public override string ToString() { return "{Width=" + width.ToString() + ", Height=" + height.ToString() + "}"; }

        /// <summary>
        /// Multiplies <see cref="Size"/> by an <see cref="int"/> producing <see cref="Size"/>.
        /// </summary>
        /// <param name="size">Multiplicand of type <see cref="Size"/>.</param>
        /// <param name="multiplier">Multiplier of type <see cref='int'/>.</param>
        /// <returns>Product of type <see cref="Size"/>.</returns>
        private static Size Multiply(Size size, int multiplier) { return
           new Size(unchecked(size.width * multiplier), unchecked(size.height * multiplier)); }

        /// <summary>
        /// Multiplies <see cref="Size"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="size">Multiplicand of type <see cref="Size"/>.</param>
        /// <param name="multiplier">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type SizeF.</returns>
        private static SizeF Multiply(Size size, float multiplier)
        {
            return new SizeF(size.width * multiplier, size.height * multiplier);
        }
    }
}
