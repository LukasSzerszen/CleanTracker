using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentTests;

public sealed class CustomWebApplicationFactoryFixture : IDisposable
{
    public CustomWebApplicationFactory CustomWebApplicationFactory { get; set; }
    public CustomWebApplicationFactoryFixture()=> CustomWebApplicationFactory = new CustomWebApplicationFactory();
    public void Dispose() => CustomWebApplicationFactory.Dispose();
}
