using System;

namespace EndToEndTests;

public sealed class CustomWebApplicationFactoryFixture : IDisposable
{
    public CustomWebApplicationFactory CustomWebApplicationFactory { get; set; }
    public CustomWebApplicationFactoryFixture() => CustomWebApplicationFactory = new CustomWebApplicationFactory();
    public void Dispose() => CustomWebApplicationFactory.Dispose();
}