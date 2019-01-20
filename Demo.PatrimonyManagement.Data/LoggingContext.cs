using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using JsonDiffPatchDotNet;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PatrimonyManagement.Data
{
    public static class LoggingContext
    {
        private static readonly List<EntityState> entityStates = new List<EntityState>() { EntityState.Added, EntityState.Modified, EntityState.Deleted };

        public static async Task LogChanges(this AppDbContext context)
        {
            var logTime = DateTime.Now;
            const string emptyJson = "{}";
            const string pkColumn = "Id";

            Guid? user = null;
            if (!string.IsNullOrEmpty(Thread.CurrentPrincipal?.Identity?.Name))
                user = new Guid(Thread.CurrentPrincipal?.Identity?.Name);

            var changes = context.ChangeTracker.Entries()
                .Where(x => entityStates.Contains(x.State) && x.Entity.GetType().IsSubclassOf(typeof(BaseEntity)))
                .ToList();

            var jdp = new JsonDiffPatch();

            foreach (var item in changes)
            {
                var originalJson = emptyJson;
                var modifiedJson = JsonConvert.SerializeObject(item.CurrentValues.Properties.ToDictionary(pn => pn.Name, pn => item.CurrentValues[pn]));
                var creationDate = DateTime.Now;

                if (item.State == EntityState.Modified)
                {
                    var dbValues = await item.GetDatabaseValuesAsync();
                    originalJson = JsonConvert.SerializeObject(dbValues.Properties.ToDictionary(pn => pn.Name, pn => dbValues[pn]));

                    creationDate = dbValues.GetValue<DateTime>("CreationDate");
                }

                item.Property("CreationDate").CurrentValue = creationDate;

                string jsonDiff = jdp.Diff(originalJson, modifiedJson);

                if (string.IsNullOrWhiteSpace(jsonDiff) == false)
                {
                    var EntityDiff = JToken.Parse(jsonDiff).ToString(Formatting.None);

                    var logEntry = new LogEntry()
                    {
                        EntityName = item.Entity.GetType().Name,
                        EntityId = new Guid(item.CurrentValues[pkColumn].ToString()),
                        LogDateTime = logTime,
                        Operation = item.State.ToString(),
                        UserId = user,
                        ValuesChanges = EntityDiff,
                    };

                    context.LogEntry.Add(logEntry);
                }

            }
        }
    }
}
