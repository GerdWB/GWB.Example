#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion


namespace Web.Api.gRPC.Server.Functional.Tests.TestSetup;

using Microsoft.Extensions.Logging;

internal class ForwardingLoggerProvider : ILoggerProvider
{
    private readonly TestingWebAppFactory.LogMessage _logAction;

    public ForwardingLoggerProvider(TestingWebAppFactory.LogMessage logAction) => _logAction = logAction;

    public ILogger CreateLogger(string categoryName) => new ForwardingLogger(categoryName, _logAction);

    public void Dispose()
    {
    }

    internal class ForwardingLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly TestingWebAppFactory.LogMessage _logAction;

        public ForwardingLogger(string categoryName, TestingWebAppFactory.LogMessage logAction)
        {
            _categoryName = categoryName;
            _logAction = logAction;
        }

        public IDisposable BeginScope<TState>(TState state) => null!;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            _logAction(logLevel, _categoryName, eventId, formatter(state, exception), exception);
        }
    }
}