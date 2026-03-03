using Microsoft.EntityFrameworkCore;

namespace Frames.Data;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        EnsureMigrated(appDbContext);
        EnsureFramesPopulated(appDbContext);
        EnsureWorkersPopulated(appDbContext);

        EnsureFramesInPopulated(appDbContext, DateTime.Now.Year, DateTime.Now.Month - 1);
        EnsureFramesInPopulated(appDbContext, DateTime.Now.Year, DateTime.Now.Month - 2);

        SaveChangesAndUntrack(appDbContext);

        EnsureFramesOutPopulated(appDbContext, DateTime.Now.Year, DateTime.Now.Month - 1);
        EnsureFramesOutPopulated(appDbContext, DateTime.Now.Year, DateTime.Now.Month - 2);

        EnsurePaymentsPopulated(appDbContext, DateTime.Now.Year, DateTime.Now.Month - 1);
        
        SaveChangesAndUntrack(appDbContext);
    }

    private static void SaveChangesAndUntrack(AppDbContext appDbContext)
    {
        appDbContext.SaveChanges();
        appDbContext.ChangeTracker.Clear();
    }
    
    private static void EnsurePaymentsPopulated(AppDbContext appDbContext, int year, int month)
    {
        if (appDbContext.Payments.Any())
            return;
        
        var random = new Random();
        List<Payment> payments = [
            new Payment()
            {
                Date = new DateOnly(year, month, 5),
                Amount = GetRandomAmount(random)
            },
            new Payment()
            {
                Date = new DateOnly(year, month, 10),
                Amount = GetRandomAmount(random)
            },
            new Payment()
            {
                Date = new DateOnly(year, month, 15),
                Amount = GetRandomAmount(random)
            },
            new Payment()
            {
                Date = new DateOnly(year, month, 20),
                Amount = GetRandomAmount(random)
            },
            new Payment()
            {
                Date = new DateOnly(year, month, 25),
                Amount = GetRandomAmount(random)
            },
        ];
        
        appDbContext.Payments.AddRange(payments);
    }

    private static decimal GetRandomAmount(Random random)
    {
        return Convert.ToDecimal(random.Next(1, 10) * 1000);
    }

    private static void EnsureFramesOutPopulated(AppDbContext appDbContext, int year, int month)
    {
        if (appDbContext.MasterFrameOuts.Any())
            return;
        
        var frameTypesFromDb = appDbContext.FrameTypes.AsNoTracking().ToList();
        var random = new Random();
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

    private static void EnsureFramesInPopulated(AppDbContext appDbContext, int year, int month)
    {
        if (appDbContext.MasterFrameIns.Any()) return;

        var random = new Random();
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

    private static void EnsureWorkersPopulated(AppDbContext appDbContext)
    {
        if (appDbContext.Workers.Any()) return;
        List<Worker> workers =
        [
            new() { Name = "Worker1" },
            new() { Name = "Worker2" },
            new() { Name = "Worker3" },
            new() { Name = "Worker4" },
        ];

        appDbContext.Workers.AddRange(workers);
    }

    private static void EnsureFramesPopulated(AppDbContext appDbContext)
    {
        if (appDbContext.FrameTypes.Any()) return;
        List<FrameType> frameTypes =
        [
            new() { Name = "Item1", MasterFrameRate = 10.5m, WorkerFrameRate = 7.5m },
            new() { Name = "Item2", MasterFrameRate = 17m, WorkerFrameRate = 11m },
            new() { Name = "Item3", MasterFrameRate = 25m, WorkerFrameRate = 15m },
            new() { Name = "Item4", MasterFrameRate = 30m, WorkerFrameRate = 20m },
        ];

        appDbContext.FrameTypes.AddRange(frameTypes);
    }

    private static void EnsureMigrated(AppDbContext appDbContext)
    {
        if (appDbContext.Database.GetPendingMigrations().Any())
        {
            appDbContext.Database.Migrate();
        }
    }
}