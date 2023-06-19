//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System;
using System.Collections.Generic;
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

namespace CashOverFlow.Infrastructure.Build
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var githubPipeline = new GithubPipeline
            {
                Name = "Build & Test CashOverFlow",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },
                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Jobs
                {
                    Build=new BuildJob
                    {
                        RunsOn=BuildMachines.WindowsLatest,

                        Steps=new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name="Checkikng Out"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name="Installing .NET",

                                TargetDotNetVersion=new TargetDotNetVersion
                                {
                                    DotNetVersion="7.0.302"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Project"
                            },

                            new TestTask
                            {
                                Name="Running Tests"
                            }
                        }
                    }
                }
            };

            var adonetClient = new ADotNetClient();

            adonetClient.SerializeAndWriteToFile(
                githubPipeline,
                path: "../../../../.github/workflows/build.yml");
        }
    }
}