﻿namespace MyTest.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
