﻿// <copyright file="RequestSerialiserTests.cs" company="Glenn Watson">
//    Copyright (C) 2017. Glenn Watson
// </copyright>

namespace GitLfs.Core.Tests
{
    using GitLfs.Core.BatchRequest;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Xunit;

    public class RequestSerialiserTests
    {
        [Fact]
        public void RequestDeserialiseTest()
        {
            const string jsonText =
                "{\r\n  \"operation\": \"download\",\r\n  \"transfers\": [ \"basic\" ],\r\n  \"objects\": [\r\n    {\r\n      \"oid\": \"12345678\",\r\n      \"size\": 123,\r\n    }\r\n  ]\r\n}";

            var serialiser = new JsonBatchRequestSerialiser();

            BatchRequest request = serialiser.FromString(jsonText);

            Assert.Equal(request.Objects.Count, 1);
            Assert.Equal(request.Transfers.Count, 1);
            Assert.Equal(request.Operation, BatchRequestMode.Download);

            Assert.Equal(request.Objects[0].Hash, "12345678");
            Assert.Equal(request.Objects[0].Size, 123);

            Assert.Equal(request.Transfers[0], TransferMode.Basic);
        }

        [Fact]
        public void RequestSerialiseTest()
        {
            const string jsonText =
                "{\r\n  \"operation\": \"download\",\r\n  \"transfers\": [ \"basic\" ],\r\n  \"objects\": [\r\n    {\r\n      \"oid\": \"12345678\",\r\n      \"size\": 123,\r\n    }\r\n  ]\r\n}";

            var serialiser = new JsonBatchRequestSerialiser();

            BatchRequest objectValue = serialiser.FromString(jsonText);

            string jsonObjectText = JObject.Parse(jsonText).ToString(Formatting.Indented);

            string objectText = serialiser.ToString(objectValue);

            Assert.Equal(objectText, jsonObjectText);
        }
    }
}