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
}