﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.NET.Sdk.WorkloadManifestReader
{
    /// <summary>
    /// This abstracts out the process of locating and loading a set of manifests to be loaded into a
    /// workload manifest resolver and resolved into a single coherent model.
    /// </summary>
    public interface IWorkloadManifestProvider
    {
        void RefreshWorkloadManifests();
        IEnumerable<ReadableWorkloadManifest> GetManifests();

        string GetSdkFeatureBand();

        WorkloadVersionInfo GetWorkloadVersion();

        Dictionary<string, WorkloadSet> GetAvailableWorkloadSets();

        public readonly record struct WorkloadVersionInfo(string Version, string? VersionNotInstalledMessage = null, string? UpdateModeMessage = null);
    }

    public record WorkloadVersion
    {
        public enum Type
        {
            WorkloadSet,
            LooseManifest
        }

        public string? Version;
        public Type WorkloadInstallType;
    }
}
