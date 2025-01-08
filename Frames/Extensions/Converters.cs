namespace Frames.Extensions;

public static class Converters
{
    public static FrameType ToEntity(this FrameTypeDto dto)
        => new FrameType()
        {
            Id = dto.Id, Name = dto.Name!, MasterFrameRate = dto.MasterRate ?? 0m,
            WorkerFrameRate = dto.WorkerRate ?? 0m
        };

    public static FrameTypeDto ToDto(this FrameType frameType)
        => new FrameTypeDto()
        {
            Id = frameType.Id, Name = frameType.Name, MasterRate = frameType.MasterFrameRate,
            WorkerRate = frameType.WorkerFrameRate
        };

    public static Worker ToEntity(this WorkerDto dto)
        => new Worker()
        {
            Id = dto.Id,
            Name = dto.Name!
        };

    public static WorkerDto ToDto(this Worker worker)
        => new WorkerDto()
        {
            Id = worker.Id,
            Name = worker.Name
        };

    public static List<MasterFrameIn> ToEntity(this FrameInDto dto)
    {
        List<MasterFrameIn> result = [];
        result.AddRange(dto.InItems.Select(x => new MasterFrameIn()
            { Id = x.Id, FrameCount = x.Count, DateTime = new DateTime(dto.Date, x.Time) }));
        return result;
    }

    public static FrameInDto ToDto(this List<MasterFrameIn> frameIn)
    {
        FrameInDto result = new()
        {
            Date = DateOnly.FromDateTime(frameIn.First().DateTime)
        };
        result.InItems.AddRange(frameIn.Select(x => new FrameInTimeAndCount()
            { Id = x.Id, Time = TimeOnly.FromDateTime(x.DateTime), Count = x.FrameCount }).OrderBy(x => x.Time));
        return result;
    }

    public static List<MasterFrameOut> ToEntity(this FrameOutDto dto)
    {
        List<MasterFrameOut> result = [];

        foreach (var timeDto in dto.FrameOutTimeDtos)
        {
            MasterFrameOut masterFrameOut = new()
            {
                Id = timeDto.Id,
                DateTime = new DateTime(dto.Date, timeDto.Time),
                MasterFrameOutTypes = []
            };

            foreach (var typeDto in timeDto.FrameOutTypes)
            {
                if (typeDto is { Count: <= 0, Id: 0 })
                    continue;

                MasterFrameOutType type = new()
                {
                    Id = typeDto.Id,
                    Count = typeDto.Count,
                    FrameRate = typeDto.FrameRate,
                    FrameTypeId = typeDto.FrameTypeId
                };

                masterFrameOut.MasterFrameOutTypes.Add(type);
            }

            result.Add(masterFrameOut);
        }

        return result;
    }

    public static FrameOutDto ToDto(this List<MasterFrameOut> frameOuts)
    {
        FrameOutDto result = new()
        {
            Date = DateOnly.FromDateTime(frameOuts.First().DateTime)
        };
        foreach (var frameOut in frameOuts.OrderBy(x => x.DateTime))
        {
            FrameOutTimeDto timeDto = new()
            {
                Id = frameOut.Id,
                Time = TimeOnly.FromDateTime(frameOut.DateTime)
            };

            timeDto.FrameOutTypes.AddRange(frameOut.MasterFrameOutTypes
                .Select(x => new FrameOutTypeDto()
                {
                    Id = x.Id,
                    Count = x.Count,
                    FrameTypeId = x.FrameType?.Id ?? 0,
                    FrameType = x.FrameType?.ToDto(),
                    FrameName = x.FrameType?.Name ?? "",
                    FrameRate = x.FrameRate
                }));

            result.FrameOutTimeDtos.Add(timeDto);
        }

        return result;
    }

    public static PaymentDto ToDto(this Payments payment)
        => new PaymentDto()
        {
            Id = payment.Id,
            Amount = payment.Amount,
            Date = payment.Date,
        };

    public static Payments ToEntity(this PaymentDto dto)
        => new Payments()
        {
            Id = dto.Id,
            Amount = dto.Amount,
            Date = dto.Date
        };
}