﻿// <copyright file="BatchObjectAction.cs" company="Glenn Watson">
//    Copyright (C) 2017. Glenn Watson
// </copyright>

namespace GitLfs.Core.BatchResponse
{
    using System;
    using System.Collections.Generic;

    public class BatchObjectAction
    {
        public DateTime? ExpiresAt { get; set; }

        public int? ExpiresIn { get; set; }

        public List<BatchHeader> Headers { get; set; }

        public string HRef { get; set; }

        public BatchActionMode Mode { get; set; }
    }
}