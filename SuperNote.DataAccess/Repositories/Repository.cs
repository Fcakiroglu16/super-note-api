﻿using Microsoft.EntityFrameworkCore;
using SuperNote.DataAccess.Database;
using SuperNote.Domain.SharedKernel.AggregateRoot;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.DataAccess.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> 
    where TEntity : AggregateRoot
{
    protected readonly SuperNoteContext DbContext;

    protected Repository(SuperNoteContext dbContext) => DbContext = dbContext;
    public async Task<IReadOnlyList<TEntity>> GetALl()
        => await DbContext.Set<TEntity>().ToListAsync();
    public void Add(TEntity entity) 
        => DbContext.Set<TEntity>().Add(entity);
    
    public void Update(TEntity entity) 
        => DbContext.Set<TEntity>().Update(entity);
    
    public void Remove(TEntity entity) 
        => DbContext.Set<TEntity>().Remove(entity);
}