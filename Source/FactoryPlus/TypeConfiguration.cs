using System;
using System.Collections.Generic;

namespace FactoryPlus
{
    public class TypeConfiguration
    {
        #region Globals

        private readonly Dictionary<Type, object> defaultFactories = new Dictionary<Type, object>();
        private readonly Dictionary<TypeTemplate, object> templateFactories = new Dictionary<TypeTemplate, object>();
        
        #endregion

        #region Public Members

        public void Clear()
        {
            defaultFactories.Clear();
            templateFactories.Clear();
        }

        /// <summary>
        /// Adds a default factory for the specified type.
        /// </summary>
        /// <typeparam name="T">The type to add a factory for.</typeparam>
        /// <param name="factory">The default factory to add for the type.</param>
        public void AddDefaultFactory<T>(IObjectBuilder<T> factory)
        {
            defaultFactories[typeof (T)] = factory;
        }

        /// <summary>
        /// Adds a named template factory for the type.
        /// </summary>
        /// <typeparam name="T">The type to add a factory for.</typeparam>
        /// <param name="name">The name of the template.</param>
        /// <param name="factory">The factory to add for the type.</param>
        public void AddTemplateFactory<T>(string name, IObjectBuilder<T> factory)
        {
            templateFactories[new TypeTemplate { TemplateName = name, Type = typeof(T)}] = factory;
        }

        /// <summary>
        /// Gets the default factory for the specified type.
        /// </summary>
        /// <typeparam name="T">The type for which the factory is required.</typeparam>
        /// <returns>The factory for the type, if registered - else null.</returns>
        public IObjectBuilder<T> GetDefaultFactory<T>()
        {
            object factory;

            if (defaultFactories.TryGetValue(typeof(T), out factory))
            {
                return (IObjectBuilder<T>) factory;
            }

            return null;
        }

        /// <summary>
        /// Gets the factory with the template name for the specified type.
        /// </summary>
        /// <typeparam name="T">The type for which the factory is required.</typeparam>
        /// <param name="name">The name of the template builder.</param>
        /// <returns>
        /// The factory for the type and template name, if registered - else null.
        /// </returns>
        public IObjectBuilder<T> GetTemplateFactory<T>(string name)
        {
            object factory;

            if (templateFactories.TryGetValue(new TypeTemplate { TemplateName = name, Type = typeof(T) }, out factory))
            {
                return (IObjectBuilder<T>)factory;
            }

            return null;
        }

        #endregion

        #region TypeTemplate

        private class TypeTemplate
        {
            public Type Type { get; set; }
            public string TemplateName { get; set; }
            
            public bool Equals(TypeTemplate other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.Type, Type) && Equals(other.TemplateName, TemplateName);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (TypeTemplate)) return false;
                return Equals((TypeTemplate) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Type != null ? Type.GetHashCode() : 0)*397) ^ (TemplateName != null ? TemplateName.GetHashCode() : 0);
                }
            }
        }

        #endregion
    }
}
