﻿namespace NServiceBus.Azure.Tests.DataBus
{
    using NServiceBus.DataBus;
    using NUnit.Framework;

    [TestFixture]
    [Category("Azure")]
    public class When_using_azure_databus_guard
    {
        [Test]
        [ExpectedException]
        public void Should_not_allow_negative_maximum_retries()
        {
            AzureDataBusGuard.CheckMaxRetries(-1);
        }

        [Test]
        [ExpectedException]
        public void Should_not_allow_negative_backoff_interval()
        {
            AzureDataBusGuard.CheckBackOffInterval(-1);
        }

        [TestCase(0)]
        [TestCase(AzureDataBusDefaults.DefaultBlockSize + 1)]
        [ExpectedException]
        public void Should_not_allow_block_size_more_than_4MB_or_less_than_one_byte(int blockSize)
        {
            AzureDataBusGuard.CheckBlockSize(blockSize);
        }

        [Test]
        [ExpectedException]
        public void Should_not_allow_invalid_number_of_threads()
        {
            AzureDataBusGuard.CheckNumberOfIOThreads(0);
        }

        [TestCase("")]
        [TestCase(null)]
        [ExpectedException]
        public void Should_not_allow_invalid_connection_string(string connectionString)
        {
            AzureDataBusGuard.CheckConnectionString(connectionString);
        }

        [TestCase("")]
        [TestCase(null)]
        [ExpectedException]
        public void Should_not_allow_invalid_container_name(string containerName)
        {
            AzureDataBusGuard.CheckContainerName(containerName);
        }

        [Test]
        [ExpectedException]
        public void Should_not_allow_null_base_path()
        {
            AzureDataBusGuard.CheckBasePath(null);
        }

        [Test]
        [ExpectedException]
        public void Should_not_allow_negative_default_time_to_live()
        {
            AzureDataBusGuard.CheckDefaultTTL(-1);
        }
    }
}
