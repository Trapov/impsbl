using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Impsbl.Infrastructure.Screens
{
    public sealed class DefaultTransitioner : ITransitioner
    {
        private readonly IDictionary<string, Type> _screenRegistrations = new Dictionary<string, Type>();
        private readonly IServiceProvider _serviceProvider;

        public DefaultTransitioner(IDictionary<string, Type> screenRegistrations, IServiceProvider serviceProvider)
        {
            _screenRegistrations = screenRegistrations;
            _serviceProvider = serviceProvider;
        }

        private Screen _current;
        public Screen Current
        {
            get
            {
                return _current
                    ??
                    (Screen)(_currentScope ??= _serviceProvider.CreateScope())
                        .ServiceProvider
                        .GetRequiredService(_screenRegistrations.Values.First());
            }
            private set => _current = value;
        }
        private IServiceScope _currentScope;

        public void To(string path)
        {
            _currentScope?.Dispose();

            _currentScope = _serviceProvider.CreateScope();
            var type = _screenRegistrations[path];
            Current = (Screen)_currentScope.ServiceProvider.GetRequiredService(type);
        }
    }
}
