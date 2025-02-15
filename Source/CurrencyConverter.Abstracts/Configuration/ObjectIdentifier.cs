using System.Diagnostics.CodeAnalysis;

namespace CurrencyConverter.Abstracts.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectIdentifier: IObjectIdentifier, IEquatable<ObjectIdentifier>, IComparable<ObjectIdentifier>
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectIdentifier()
        {
            Identifier = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        public ObjectIdentifier(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        ///
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string IObjectIdentifier.Identifier => this.Identifier;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ObjectIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Identifier;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CompareTo([AllowNull] ObjectIdentifier other)
        {
            if (other == null)
                return -1;

            return Identifier.CompareTo(other.Identifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Equals([AllowNull] ObjectIdentifier other)
        {
            if (null == other)
                return false;

            return string.Equals(Identifier, other.Identifier);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IObjectIdentifier
    {
        /// <summary>
        ///
        /// </summary>
        string Identifier { get; }
    }
}
