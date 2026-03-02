namespace Frames.Extensions;

public static class Converters
{
    extension(FrameTypeDto dto)
    {
        public FrameType ToEntity()
            => new FrameType()
            {
                Id = dto.Id,
                Name = dto.Name!,
                MasterFrameRate = dto.MasterRate ?? 0m,
                WorkerFrameRate = dto.WorkerRate ?? 0m
            };
    }

    extension(FrameType frameType)
    {
        public FrameTypeDto ToDto()
            => new FrameTypeDto()
            {
                Id = frameType.Id,
                Name = frameType.Name,
                MasterRate = frameType.MasterFrameRate,
                WorkerRate = frameType.WorkerFrameRate
            };
    }

    extension(WorkerDto dto)
    {
        public Worker ToEntity()
            => new Worker()
            {
                Id = dto.Id,
                Name = dto.Name!
            };
    }

    extension(Worker worker)
    {
        public WorkerDto ToDto()
            => new WorkerDto()
            {
                Id = worker.Id,
                Name = worker.Name
            };
    }

    extension(FrameInDto dto)
    {
        public List<MasterFrameIn> ToEntity()
        {
            List<MasterFrameIn> result = [];
            result.AddRange(
                dto.InItems.Select(x =>
                    new MasterFrameIn()
                    {
                        Id = x.Id,
                        FrameCount = x.Count,
                        DateTime = new DateTime(dto.Date, x.Time)
                    }));
            return result;
        }
    }

    extension(List<MasterFrameIn> frameIn)
    {
        public FrameInDto ToDto()
        {
            FrameInDto result = new()
            {
                Date = DateOnly.FromDateTime(frameIn.First().DateTime)
            };
            result.InItems.AddRange(
                frameIn.Select(x =>
                    new FrameInTimeAndCount()
                    {
                        Id = x.Id,
                        Time = TimeOnly.FromDateTime(x.DateTime),
                        Count = x.FrameCount
                    }).OrderBy(x => x.Time)
            );
            return result;
        }
    }

    extension(FrameOutDto dto)
    {
        public List<MasterFrameOut> ToEntity()
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
                        FrameTypeId = typeDto.FrameTypeId,
                        MasterFrameOutId = masterFrameOut.Id
                    };

                    masterFrameOut.MasterFrameOutTypes.Add(type);
                }

                result.Add(masterFrameOut);
            }

            return result;
        }
    }

    extension(List<MasterFrameOut> frameOuts)
    {
        public FrameOutDto ToDto()
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
    }

    extension(Payments payment)
    {
        public PaymentDto ToDto()
            => new PaymentDto()
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Date = payment.Date,
            };
    }

    extension(PaymentDto dto)
    {
        public Payments ToEntity()
            => new Payments()
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Date = dto.Date
            };
    }

    extension(Billing entity)
    {
        public BillingSummaryDto ToBillingSummaryDto()
            => new BillingSummaryDto()
            {
                Id = entity.Id,
                Month = entity.Month,
                Year = entity.Year,
                Total = entity.Summary?.Total ?? 0m,
                LastMonth = entity.Summary?.LastMonth ?? 0m,
                TotalPaid = entity.Summary?.TotalPaid ?? 0m,
                Items = entity.BillingItems.ToDictionary(x => x.ItemName!,
                    x => (x.Rate, x.BillingItemDetails.Sum(y => y.Count)))
            };
    }

    extension(Billing entity)
    {
        public BillingDto ToDto()
            => new BillingDto()
            {
                Id = entity.Id,
                Month = entity.Month,
                Year = entity.Year,
                LastMonth = entity.Summary!.LastMonth,
                Paid = entity.Paid.OrderBy(x => x.Date).Select(x => new BillingPaidDto(x.Date, x.Amount)).ToList(),
                BillingItems = entity.BillingItems.Select(x =>
                    new BillingItemDto(x.ItemName!, x.Rate,
                        x.BillingItemDetails.OrderBy(y => y.Date).Select(y =>
                            new BillingItemDetailDto(y.Date, y.Count)).ToList())).ToList()
            };
    }
}