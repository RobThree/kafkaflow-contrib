/* Table */
CREATE TABLE [kafkaflowtest].[dbo].[processes](
	[sequence_id] [bigint] IDENTITY(1,1) NOT NULL,
	[process_type] [nvarchar](255) NOT NULL,
	[process_id] [uniqueidentifier] NOT NULL,
	[process_state] [nvarchar](max) NOT NULL,
    [date_added_utc] [datetime2] NOT NULL DEFAULT(SYSUTCDATETIME()),
    [date_updated_utc] [datetime2] NOT NULL DEFAULT(SYSUTCDATETIME()),
    [rowversion] [int] NOT NULL DEFAULT(1),
	CONSTRAINT [PK_processes] PRIMARY KEY CLUSTERED ([sequence_id] ASC),
	CONSTRAINT [CK_process_state_not_blank_or_empty] CHECK ((TRIM([process_state])<>N''))
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_processes] ON [kafkaflowtest].[dbo].[processes] ([process_type] ASC,[process_id] ASC) WITH (FILLFACTOR = 90)
GO
