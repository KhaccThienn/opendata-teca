﻿namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var typeMapFroms = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in typeMapFroms)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, [this]);
            }

            var typeMapTos = assembly.GetExportedTypes()
               .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
               .ToList();

            foreach (var type in typeMapTos)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapTo`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, [this]);
            }
        }
    }
}
