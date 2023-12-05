﻿using WorldOfBooks.Service.Commons.Helpers;

namespace Revision.WebApi.Extensions;

public static class HttpContextExtensions
{
    public static void InitAccessor(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            HttpContextHelper.Accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
        }
    }
}
