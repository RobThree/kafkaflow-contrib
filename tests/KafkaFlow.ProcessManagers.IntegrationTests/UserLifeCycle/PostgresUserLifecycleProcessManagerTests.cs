using KafkaFlow.ProcessManagers.IntegrationTests.Fixture;

namespace KafkaFlow.ProcessManagers.IntegrationTests.UserLifeCycle;

public sealed class PostgresUserLifecycleProcessManagerTests(PostgresKafkaFlowFixture fixture) : UserLifecycleProcessManagerTests<PostgresKafkaFlowFixture>(fixture)
{ }
