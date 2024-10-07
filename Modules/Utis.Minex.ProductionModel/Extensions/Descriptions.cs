using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utis.Minex.Common;
using Utis.Minex.Common.Interfaces;

namespace Utis.Minex.ProductionModel.Extensions
{
    public static class Descriptions
    {
        public static string GetTechnicalDescription(this PriorityEventBase telemetryEvent, IReflectionCache reflectionCache)
        {
            var result = new StringBuilder();
            result.AppendLine($"{telemetryEvent.GetType().Name}:");

            reflectionCache.GetPropertiesInModelClass(telemetryEvent.GetType(), out var properties);
            foreach (var propertyInfo in properties)
            {
                if (typeof(ObjectBase).IsAssignableFrom(propertyInfo.PropertyInvoker.GetPropertyType()))
                {
                    result.AppendLine($"{propertyInfo.PropertyName}.Id:{((ObjectBase)propertyInfo.PropertyInvoker.Get(telemetryEvent)).Id};");
                    continue;
                }

                if (propertyInfo.PropertyInvoker.GetPropertyType() == typeof(IEnumerable<long>))
                {
                    var join = new StringBuilder();
                    foreach (var item in ((IEnumerable<long>)propertyInfo.PropertyInvoker.Get(telemetryEvent)))
                    {
                        join.Append($"{item};");
                    }

                    if (join.Length > 0)
                    {
                        result.AppendLine($"{propertyInfo.PropertyName}:{join};");
                    }

                    continue;
                }

                if (typeof(DateTime?).IsAssignableFrom(propertyInfo.PropertyInvoker.GetPropertyType()))
                {
                    result.AppendLine($"{propertyInfo.PropertyName}:{propertyInfo.PropertyInvoker.Get(telemetryEvent):MM/dd/yyyy HH:mm:ss};");
                    continue;
                }

                result.AppendLine($"{propertyInfo.PropertyName}:{propertyInfo.PropertyInvoker.Get(telemetryEvent)};");
            }

            return
                result.ToString();
        }

        private static string[] ExcludeInShortDescription = new[] { nameof(PriorityEventBase.Id), nameof(PriorityEventBase.Created), nameof(PriorityEventBase.Updated), nameof(PriorityEventBase.Deleted), nameof(PriorityEventBase.VersionObject) };
        public static string GetShortTechnicalDescription(this PriorityEventBase telemetryEvent, IReflectionCache reflectionCache)
        {
            var result = new StringBuilder();
            result.Append($"{telemetryEvent.GetType().Name}:");

            reflectionCache.GetPropertiesInModelClass(telemetryEvent.GetType(), out var properties);
            if (properties != null)
                foreach (var propertyInfo in properties)
                {
                    if (ExcludeInShortDescription.Contains(propertyInfo.PropertyName))
                        continue;

                    if (typeof(ObjectBase).IsAssignableFrom(propertyInfo.PropertyInvoker.GetPropertyType()))
                    {
                        result.Append($"{propertyInfo.PropertyName}.Id:{((ObjectBase)propertyInfo.PropertyInvoker.Get(telemetryEvent)).Id};\t");
                        continue;
                    }

                    if (propertyInfo.PropertyInvoker.GetPropertyType() == typeof(IEnumerable<long>))
                    {
                        var join = new StringBuilder();
                        foreach (var item in ((IEnumerable<long>)propertyInfo.PropertyInvoker.Get(telemetryEvent)))
                        {
                            join.Append($"{item};");
                        }

                        if (join.Length > 0)
                        {
                            result.Append($"{propertyInfo.PropertyName}:{join};\t");
                        }

                        continue;
                    }

                    if (typeof(DateTime?).IsAssignableFrom(propertyInfo.PropertyInvoker.GetPropertyType()))
                    {
                        result.Append($"{propertyInfo.PropertyName}:{propertyInfo.PropertyInvoker.Get(telemetryEvent):MM/dd/yyyy HH:mm:ss};\t");
                        continue;
                    }

                    result.Append($"{propertyInfo.PropertyName}:{propertyInfo.PropertyInvoker.Get(telemetryEvent)};\t");
                }

            return
                result.ToString();
        }
    }
}