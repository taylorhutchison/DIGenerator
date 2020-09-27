using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace App
{
    public static class DIManager
    {
        private static readonly Dictionary<Type, Type> _registry;
        static DIManager()
        {
            _registry = new Dictionary<Type, Type>();
        }

        public static List<Type> Controllers
        {
            get
            {
                return _registry.Select((pair) => pair.Key)
                .Where(type => type.Name.Contains("Controller"))
                .ToList();
            }
        }
        public static void RegisterControllers()
        {
            Assembly.GetExecutingAssembly()
            .GetTypes().Where(type => type.Name.Contains("Controller")).ToList()
            .ForEach(type => _registry.Add(type, type));
        }
        public static void Register<T, U>() where U : class, T
        {
            _registry.Add(typeof(T), typeof(U));
        }

        public static T CreateInstance<T>()
        {
            var implementingType = _registry[typeof(T)];
            return (T)CreateImplementingInstance(implementingType);
        }

        public static object CreateInstance(Type type)
        {
            var implementingType = _registry[type];
            return CreateImplementingInstance(implementingType);
        }

        private static object CreateImplementingInstance(Type implementingType)
        {
            var constructors = implementingType.GetConstructors();
            foreach (var constructor in constructors)
            {
                var constructorParameters = GetConstructorParameters(constructor);
                if (constructorParameters != null)
                {
                    return constructor.Invoke(constructorParameters);
                }
            }
            throw new Exception("Could not find constructor.");
        }

        private static object[] GetConstructorParameters(ConstructorInfo constructor)
        {
            var parameterTypes = constructor.GetParameters();
            object[] paramaterInstances = new object[parameterTypes.Length];
            var parameterPosition = 0;
            foreach (var parameter in parameterTypes)
            {
                if (_registry.ContainsKey(parameter.ParameterType))
                {
                    paramaterInstances[parameterPosition] = DIManager.CreateInstance(parameter.ParameterType);
                    parameterPosition++;
                }
                else
                {
                    return null;
                }
            }
            return paramaterInstances;
        }
    }
}