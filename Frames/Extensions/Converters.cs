namespace Frames.Extensions;

public static class Converters
{
    public static FrameType ToFrameTypeEntity(this FrameTypeDto dto)
        => new FrameType()
        {
            Id = dto.Id, Name = dto.Name!, MasterFrameRate = dto.MasterRate ?? 0m,
            WorkerFrameRate = dto.WorkerRate ?? 0m
        };

    public static FrameTypeDto ToFrameTypeDto(this FrameType frameType)
        => new FrameTypeDto()
        {
            Id = frameType.Id, Name = frameType.Name, MasterRate = frameType.MasterFrameRate,
            WorkerRate = frameType.WorkerFrameRate
        };

    public static Worker ToWorkerEntity(this WorkerDto dto)
        => new Worker()
        {
            Id = dto.Id,
            Name = dto.Name!
        };

    public static WorkerDto ToWorkerDto(this Worker worker)
        => new WorkerDto()
        {
            Id = worker.Id,
            Name = worker.Name
        };
}