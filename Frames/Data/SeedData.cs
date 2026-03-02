using Microsoft.EntityFrameworkCore;

namespace Frames.Data;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (appDbContext.Database.GetPendingMigrations().Any())
        {
            appDbContext.Database.Migrate();
        }

        if (!appDbContext.FrameTypes.Any())
        {
            List<FrameType> frameTypes =
            [
                new() { Name = "Item1", MasterFrameRate = 10.5m, WorkerFrameRate = 7.5m },
                new() { Name = "Item2", MasterFrameRate = 17m, WorkerFrameRate = 11m },
                new() { Name = "Item3", MasterFrameRate = 25m, WorkerFrameRate = 15m },
                new() { Name = "Item4", MasterFrameRate = 30m, WorkerFrameRate = 20m },
            ];

            appDbContext.FrameTypes.AddRange(frameTypes);
        }

        if (!appDbContext.Workers.Any())
        {
            List<Worker> workers =
            [
                new() { Name = "Worker1" },
                new() { Name = "Worker2" },
                new() { Name = "Worker3" },
                new() { Name = "Worker4" },
            ];

            appDbContext.Workers.AddRange(workers);
        }

        var month = DateTime.Now.Month - 1;
        var year = DateTime.Now.Year;
        var random = new Random();

        if (!appDbContext.MasterFrameIns.Any())
        {
            List<MasterFrameIn> masterFrameIns = [];

            for (var i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                var randomNo = random.Next(1, 6);
                for (var j = 1; j <= randomNo; j++)
                {
                    masterFrameIns.Add(new MasterFrameIn
                    {
                        DateTime = new DateTime(year, month, i, random.Next(8, 17), random.Next(0, 60),
                            random.Next(0, 60)),
                        FrameCount = random.Next(50, 120)
                    });
                }
            }

            appDbContext.MasterFrameIns.AddRange(masterFrameIns);
        }

        appDbContext.SaveChanges();
        appDbContext.ChangeTracker.Clear();

        // var workersFromDb = appDbContext.Workers.AsNoTracking().ToList();
        var frameTypesFromDb = appDbContext.FrameTypes.AsNoTracking().ToList();

        if (!appDbContext.MasterFrameOuts.Any())
        {
            List<MasterFrameOut> masterFrameOuts = [];

            for (var i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                var randomNo = random.Next(1, 6);
                for (var j = 1; j <= randomNo; j++)
                {
                    var masterOut = new MasterFrameOut()
                    {
                        DateTime = new DateTime(year, month, i, random.Next(8, 17), random.Next(0, 60),
                            random.Next(0, 60)),
                        MasterFrameOutTypes = []
                    };

                    foreach (var frameType in frameTypesFromDb)
                    {
                        var randFrameNo = random.Next(0, 50);
                        if (randFrameNo > 0)
                        {
                            masterOut.MasterFrameOutTypes.Add(new MasterFrameOutType
                            {
                                FrameTypeId = frameType.Id,
                                FrameRate = frameType.MasterFrameRate,
                                Count = randFrameNo
                            });
                        }
                    }

                    masterFrameOuts.Add(masterOut);
                }
            }

            appDbContext.MasterFrameOuts.AddRange(masterFrameOuts);
        }

        appDbContext.SaveChanges();
        appDbContext.ChangeTracker.Clear();
    }
}