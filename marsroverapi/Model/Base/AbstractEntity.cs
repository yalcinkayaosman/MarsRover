using System;
using MongoDB.Bson;

public abstract class AbstractEntity
{
    public ObjectId Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public ObjectId CreateUserId { get; set; }

    public ObjectId UpdateUserId { get; set; }
}