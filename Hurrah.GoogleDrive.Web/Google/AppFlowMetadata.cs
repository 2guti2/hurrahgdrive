﻿using System;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;

namespace Hurrah.GoogleDrive.Web.Google
{
    public class AppFlowMetadata: FlowMetadata
    {
        private static readonly IAuthorizationCodeFlow flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                // SET ENV VARS
                // https://bit.ly/36vmiSq
                ClientSecrets = new ClientSecrets
                {
                    ClientId = Environment.GetEnvironmentVariable("GOOGLE_DRIVE_CLIENT_ID", EnvironmentVariableTarget.Machine),
                    ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_DRIVE_CLIENT_SECRET", EnvironmentVariableTarget.Machine)
                },
                Scopes = new[] { DriveService.Scope.Drive },
                DataStore = new FileDataStore("Drive.Api.Auth.Store")
            });

        public override string GetUserId(Controller controller)
        {
            // In this sample we use the session to store the user identifiers.
            // That's not the best practice, because you should have a logic to identify
            // a user. You might want to use "OpenID Connect".
            // You can read more about the protocol in the following link:
            // https://developers.google.com/accounts/docs/OAuth2Login.
            object user = controller.Session["user"];
            if (user != null) return user.ToString();
            user = Guid.NewGuid();
            controller.Session["user"] = user;
            return user.ToString();
        }

        public override IAuthorizationCodeFlow Flow => flow;
    }
}