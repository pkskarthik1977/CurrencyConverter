using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Abstracts.Configuration
{
    /// <summary>
    /// Class SessionContext. This class cannot be inherited.
    /// </summary>    
    public sealed class SessionContext : ObjectIdentifier, ISessionContext
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static Func<string, ISessionContext> CreateEmpty = (appId) => new SessionContext { Identifier = appId };

        /// <summary>
        /// 
        /// </summary>
        public readonly static ISessionContext Empty = new SessionContext();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, object> _extraProperties;

        /// <summary>
        /// 
        /// </summary>
        public SessionContext()
            : this(Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appIdentifier"></param>
        public SessionContext(string appIdentifier)
            : base(appIdentifier)
        {
        }
        /// <summary>
        ///
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? UserUuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///
        /// </summary>
        int? ISessionContext.UserId => this.UserId;

        /// <summary>
        /// 
        /// </summary>
        Guid? ISessionContext.UserUuid => this.UserUuid;

        /// <summary>
        ///
        /// </summary>
        string ISessionContext.UserName => this.UserName;

        /// <summary>
        ///
        /// </summary>
        int? ISessionContext.RoleId => this.RoleId;

        /// <summary>
        ///
        /// </summary>
        string ISessionContext.Role => this.Role;
    }

    /// <summary>
    ///
    /// </summary>
    public interface ISessionContext : IObjectIdentifier
    {
        /// <summary>
        ///
        /// </summary>
        int? UserId { get; }

        /// <summary>
        /// 
        /// </summary>
        Guid? UserUuid { get; }

        /// <summary>
        ///
        /// </summary>
        string UserName { get; }

        /// <summary>
        ///
        /// </summary>
        int? RoleId { get; }

        /// <summary>
        ///
        /// </summary>
        string Role { get; }        
    }
}
