﻿/*
CRM PowerShell Library
Copyright (C) 2017 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;

namespace AMSoftware.Crm.PowerShell.Common
{
    public enum CrmAuthenticationType
    {
        None = 0,
        IFD,
        Windows
    }

    public enum CrmRelationshipType
    {
        All = 0,
        OneToMany,
        ManyToMany
    }

    public enum CrmEntityOwner
    {
        Unknown = 0,
        User,
        Organization
    }

    public enum CrmRequiredLevel
    {
        Unknown = 0,
        Required,
        Recommended,
        Optional
    }

    public enum CrmCascadeType
    {
        None = 0,
        Cascade,
        Active,
        UserOwned,
        RemoveLink,
        Restrict
    }

    public enum CrmStringAttributeFormat
    {
        Text = 0,
        Email,
        Phone,
        PhoneticGuide,
        TextArea,
        TickerSymbol,
        Url,
        VersionNumber
    }

    public enum CrmIntegerAttributeFormat
    {
        None = 0,
        Duration,
        Language,
        Locale,
        TimeZone
    }

    public enum CrmDateTimeAttributeFormat
    {
        DateOnly = 0,
        DateAndTime
    }

    public enum CrmImeType
    {
        Auto = 0,
        Active,
        Disabled,
        Inactive
    }

    public enum CrmDateTimeBehavior
    {
        UserSettings = 0,
        DateOnly,
        TimeZoneIndependent
    }

    public enum CrmMoneyPrecisionType
    {
        Attribute = 0,
        OrganizationPricing,
        Currency
    }

    public enum CrmProcessType
    {
        All = -1,
        Workflow = 0,
        Dialog = 1,
        BusinessRule = 2,
        Action = 3,
        BusinessProcessFlow = 4
    }

    public enum CrmWebresourceType
    {
        All = 0,
        HTML = 1,
        CSS = 2,
        JS = 3,
        XML = 4,
        PNG = 5,
        JPG = 6,
        GIF = 7,
        XAP = 8,
        XSL = 9,
        ICO = 10
    }

    public enum CrmUserAccessMode
    {
        ReadWrite = 0,
        Admin = 1,
        Read = 2,
        Support = 3,
        NonInteractive = 4,
        DelegatedAdmin = 5
    }

    public enum CrmUserClientLicense
    {
        Pro = 0,
        Admin = 1,
        Basic = 2,
        DevicePro = 3,
        DeviceBasic = 4,
        Essential = 5,
        DeviceEssential = 6,
        Enterprise = 7,
        DeviceEnterprise = 8,
        Sales = 9,
        Service = 10,
        FieldService = 11,
        ProjectService = 12
    }

    public enum CrmPrincipalType
    {
        User,
        Team
    }

    public enum CrmTeamType
    {
        Owner = 0,
        Access,
        AADSecurityGroup,
        AADOfficeGroup
    }

    public enum CrmTeamMembershipType
    {
        MembersGuests = 0,
        Members = 1,
        Owners = 2,
        Guests = 3
    }

    public enum CrmPluginStepMode
    {
        Synchronous = 0,
        Asynchronous = 1
    }

    public enum CrmPluginStepStage
    {
        PreValidation = 10,
        PreOperation = 20,
        PostOperation = 40
    }

    public enum CrmPluginImageType
    {
        PreImage = 0,
        PostImage = 1
    }

    public enum CrmAssemblySourceType
    {
        Database,
        Disk,
        GAC
    }

    public enum CrmAssemblyIsolationMode
    {
        None = 1,
        Sandbox
    }

    public enum CrmPluginType
    {
        Plugin,
        WorkflowActivity
    }

    public enum CrmPluginStepDeployment
    {
        ServerOnly = 0,
        OfflineOnly = 1,
        Both = 2
    }

    public enum CrmPluginStepImageType
    {
        PreImage,
        PostImage,
        Both
    }

    public enum CrmServiceEndpointUserClaim
    {
        None = 1,
        UserId,
        UserInfo
    }

    public enum CrmServiceEndpointContract
    {
        OneWay = 1,
        Queue,
        Rest,
        TwoWay,
        Topic,
        PersistentQueue,
        EventHub,
        Webhook
    }

    public enum CrmServiceEndpointConnectionMode
    {
        Normal = 1,
        Federated
    }

    public enum CrmServiceEndpointAuthType
    {
        ACS = 1,
        SASKey,
        SASToken,
        WebhookKey,
        HttpHeader,
        HttpQueryString
    }

    public enum CrmServiceEndpointMessageFormat
    {
        DOTNETBinary = 1,
        JSON,
        XML
    }

    public enum CrmEnvironmentVariableType
    {
        All = 0,
        String = 100000000,
        Number = 100000001,
        Boolean = 100000002,
        JSON = 100000003,
        DataSource = 100000004
    }

    [Flags]
    public enum CrmAccessRight
    {
        None = 0,
        Read = 1,
        Write = 2,
        Append = 4,
        AppendTo = 16,
        Create = 32,
        Assign = 524288,
        Delete = 65536,
        Share = 262144
    }

    public enum CrmAccessScope
    {
        None = -1,
        User = 0,
        BusinessUnit = 1,
        ChildBusinessUnit = 2,
        Organization = 3
    }

    public enum CrmRoleInheritance
    {
        TeamOnly = 0,
        DirectUser = 1
    }
}
