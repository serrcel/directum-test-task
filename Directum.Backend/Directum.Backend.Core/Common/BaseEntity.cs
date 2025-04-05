﻿namespace Directum.Backend.Core.Common;

/// <summary>
/// Represents base entity class.
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
}