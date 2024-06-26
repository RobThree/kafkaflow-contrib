﻿using FluentAssertions;
using KafkaFlow.ProcessManagers.IntegrationTests.Fixture;

namespace KafkaFlow.ProcessManagers.IntegrationTests.UserLifeCycle;

public abstract class UserLifecycleProcessManagerTests<T> : IAssemblyFixture<T>
    where T : class, IKafkaFlowFixture, new()
{
    private readonly T _fixture;

    protected UserLifecycleProcessManagerTests(T fixture)
    {
        _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        _fixture.ProcessStateStore.ClearChanges();
    }

    [Fact]
    public async Task Should_run_user_registration_simulation()
    {
        var message = new UserRegistered(Guid.NewGuid(), "test@test.com");
        await _fixture.Producer.ProduceAsync(message.UserId.ToString(), message);

        TestUtils.RetryFor(TimeSpan.FromSeconds(30), TimeSpan.FromMicroseconds(100), () =>
        {
            _fixture.ProcessStateStore
                .Changes
                .Select(x => x.Item1)
                .Should().BeEquivalentTo(new[]
                {
                    LoggingProcessStateStore.ActionType.Persisted,
                    LoggingProcessStateStore.ActionType.Persisted,
                    LoggingProcessStateStore.ActionType.Deleted
                }, x => x.WithStrictOrdering());
        });
    }
}
