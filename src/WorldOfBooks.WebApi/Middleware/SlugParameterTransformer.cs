﻿using System.Text.RegularExpressions;

namespace WorldOfBooks.WebApi.Middleware;

public class SlugParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
       => value is null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
}