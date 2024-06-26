﻿using Ankh.Handlers;
using Ankh.Models.Rework;
using Raven.Client.Documents;

namespace Ankh.Backend;

public sealed class Database(
    IDocumentStore documentStore,
    UserHandler userHandler,
    IConfiguration configuration) {
    public static IReadOnlyList<UserLogin> Logins;
    
    public static UserLogin RandomLogin
        => Logins[Random.Shared.Next(Logins.Count - 1)];
    
    public async ValueTask GetOrUpdateLoggedInUsersAsync() {
        using var session = documentStore.OpenAsyncSession();
        Logins = await session.Advanced.AsyncDocumentQuery<UserLogin>().ToListAsync();
        
        // TODO: Check if login expired and update it accordingly
        if (Logins.Count != 0) {
            return;
        }
        
        var tasks = configuration
            .GetSection("Accounts")
            .Get<string[]>()!
            .Select(x => userHandler.LoginAsync(x.Split(';')[0], x.Split(';')[1]));
        
        Logins = await Task.WhenAll(tasks);
        foreach (var account in Logins) {
            await session.StoreAsync(account);
            var userLogin = await session.LoadAsync<UserLogin>(account.Id);
            var metadata = session.Advanced.GetMetadataFor(userLogin);
            metadata.Add("LAST_UPDATE", $"{DateTimeOffset.Now}");
        }
        
        await session.SaveChangesAsync();
    }
    
    public async ValueTask<T> GetByIdAsync<T>(string id) {
        using var session = documentStore.OpenAsyncSession();
        return await session.LoadAsync<T>(id);
    }
    
    public async ValueTask<IReadOnlyCollection<T>> GetAllAsync<T>() {
        using var session = documentStore.OpenAsyncSession();
        return await session.Advanced.AsyncDocumentQuery<T>().ToListAsync();
    }
    
    public async Task SaveAsync<T>(T item) {
        using var session = documentStore.OpenAsyncSession();
        await session.StoreAsync(item);
        await session.SaveChangesAsync();
    }
    
    public async ValueTask<IReadOnlyCollection<T>> GetRevisionsAsync<T>(string id) {
        using var session = documentStore.OpenAsyncSession();
        return await session.Advanced.Revisions.GetForAsync<T>(id);
    }
}