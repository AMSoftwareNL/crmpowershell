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
using System.Management.Automation;
using AMSoftware.Crm.PowerShell.Commands.Models;
using AMSoftware.Crm.PowerShell.Common;
using AMSoftware.Crm.PowerShell.Common.ArgumentCompleters;
using AMSoftware.Crm.PowerShell.Common.Repositories;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace AMSoftware.Crm.PowerShell.Commands.Metadata
{
    [Cmdlet(VerbsCommon.Set, "CrmAttribute", HelpUri = HelpUrlConstants.SetAttributeHelpUrl)]
    [OutputType(typeof(AttributeMetadata))]
    public sealed class SetAttributeCommand : CrmOrganizationCmdlet
    {
        private readonly MetadataRepository _repository = new MetadataRepository();

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true)]
        [Alias("Attribute")]
        [ValidateNotNull]
        public AttributeMetadata InputObject { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            _repository.UpdateAttribute(Entity, InputObject);
            if(PassThru)
            {
                WriteObject(_repository.GetAttribute(InputObject.MetadataId.Value));
            }
        }
    }

    public abstract class SetAttributeCommandBase : CrmOrganizationCmdlet, IDynamicParameters
    {
        private readonly MetadataRepository _repository = new MetadataRepository();
        private SetAttributeDynamicParameters _context;

        protected AttributeMetadata _attribute;

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("EntityLogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(EntityArgumentCompleter))]
        public string Entity { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalName")]
        [ValidateNotNullOrEmpty]
        [ArgumentCompleter(typeof(AttributeArgumentCompleter))]
        public string Name { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter]
        [ValidateNotNull]
        public string Description { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? CanModifyAdditionalSettings { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsAuditEnabled { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsCustomizable { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsRenameable { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsSecured { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsValidForAdvancedFind { get; set; }

        [Parameter]
        [PSDefaultValue(Value = CrmRequiredLevel.Required)]
        public CrmRequiredLevel? Required { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }

        public object GetDynamicParameters()
        {
            if (CrmVersionManager.IsSupported(CrmVersion.CRM2016_RTM))
            {
                _context = new SetAttributeDynamicParameters2016();
            }
            else
            {
                _context = null;
            }
            return _context;
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            _attribute = _repository.GetAttribute(Entity, Name);
        }

        protected void WriteAttribute(AttributeMetadata attribute)
        {
            attribute.LogicalName = Name;
            if (!string.IsNullOrWhiteSpace(DisplayName)) attribute.DisplayName = new Label(DisplayName, CrmContext.Session.Language);
            if (Description != null) attribute.Description = new Label(Description, CrmContext.Session.Language);

            if (Required.HasValue)
            {
                AttributeRequiredLevel requiredLevel = AttributeRequiredLevel.ApplicationRequired;
                if (Required == CrmRequiredLevel.Required) requiredLevel = AttributeRequiredLevel.ApplicationRequired;
                if (Required == CrmRequiredLevel.Recommended) requiredLevel = AttributeRequiredLevel.Recommended;
                if (Required == CrmRequiredLevel.Optional) requiredLevel = AttributeRequiredLevel.None;
                attribute.RequiredLevel = new AttributeRequiredLevelManagedProperty(requiredLevel);
            }

            if (CanModifyAdditionalSettings.HasValue) attribute.CanModifyAdditionalSettings = new BooleanManagedProperty(CanModifyAdditionalSettings.Value);
            if (IsAuditEnabled.HasValue) attribute.IsAuditEnabled = new BooleanManagedProperty(IsAuditEnabled.Value);
            if (IsCustomizable.HasValue) attribute.IsCustomizable = new BooleanManagedProperty(IsCustomizable.Value);
            if (IsRenameable.HasValue) attribute.IsRenameable = new BooleanManagedProperty(IsRenameable.Value);
            if (IsSecured.HasValue) attribute.IsSecured = IsSecured.Value;
            if (IsValidForAdvancedFind.HasValue) attribute.IsValidForAdvancedFind = new BooleanManagedProperty(IsValidForAdvancedFind.Value);

            if (_context != null)
            {
                _context.SetParametersOnAttribute(attribute);
            }

            _repository.UpdateAttribute(Entity, attribute);
            if (PassThru)
            {
                WriteObject(_repository.GetAttribute(_attribute.MetadataId.Value));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmStringAttribute", HelpUri = HelpUrlConstants.SetStringAttributeHelpUrl)]
    [OutputType(typeof(StringAttributeMetadata))]
    public sealed class SetStringAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmStringAttributeFormat.Text)]
        public CrmStringAttributeFormat? Format { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType? ImeType { get; set; }

        [Parameter]
        [ValidateRange(StringAttributeMetadata.MinSupportedLength, StringAttributeMetadata.MaxSupportedLength)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 100)]
        public int? Length { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            StringAttributeMetadata attribute = _attribute as StringAttributeMetadata;

            if (ImeType.HasValue)
            {
                attribute.ImeMode = ImeMode.Auto;
                if (ImeType == CrmImeType.Active) attribute.ImeMode = ImeMode.Active;
                if (ImeType == CrmImeType.Disabled) attribute.ImeMode = ImeMode.Disabled;
                if (ImeType == CrmImeType.Inactive) attribute.ImeMode = ImeMode.Inactive;
            }

            if (Format.HasValue)
            {
                if (CrmVersionManager.IsSupported(CrmVersion.CRM2013_RTM))
                {
                    attribute.FormatName = StringFormatName.Text;
                    if (Format == CrmStringAttributeFormat.Email) attribute.FormatName = StringFormatName.Email;
                    if (Format == CrmStringAttributeFormat.Phone) attribute.FormatName = StringFormatName.Phone;
                    if (Format == CrmStringAttributeFormat.PhoneticGuide) attribute.FormatName = StringFormatName.PhoneticGuide;
                    if (Format == CrmStringAttributeFormat.TextArea) attribute.FormatName = StringFormatName.TextArea;
                    if (Format == CrmStringAttributeFormat.TickerSymbol) attribute.FormatName = StringFormatName.TickerSymbol;
                    if (Format == CrmStringAttributeFormat.Url) attribute.FormatName = StringFormatName.Url;
                    if (Format == CrmStringAttributeFormat.VersionNumber) attribute.FormatName = StringFormatName.VersionNumber;
                }
                else
                {
                    attribute.Format = StringFormat.Text;
                    if (Format == CrmStringAttributeFormat.Email) attribute.Format = StringFormat.Email;
                    if (Format == CrmStringAttributeFormat.Phone) attribute.Format = StringFormat.Phone;
                    if (Format == CrmStringAttributeFormat.PhoneticGuide) attribute.Format = StringFormat.PhoneticGuide;
                    if (Format == CrmStringAttributeFormat.TextArea) attribute.Format = StringFormat.TextArea;
                    if (Format == CrmStringAttributeFormat.TickerSymbol) attribute.Format = StringFormat.TickerSymbol;
                    if (Format == CrmStringAttributeFormat.Url) attribute.Format = StringFormat.Url;
                    if (Format == CrmStringAttributeFormat.VersionNumber) attribute.Format = StringFormat.VersionNumber;
                }
            }

            if (Length.HasValue) attribute.MaxLength = Length.Value;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmMemoAttribute", HelpUri = HelpUrlConstants.SetMemoAttributeHelpUrl)]
    [OutputType(typeof(MemoAttributeMetadata))]
    public sealed class SetMemoAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType? ImeType { get; set; }

        [Parameter]
        [ValidateRange(MemoAttributeMetadata.MinSupportedLength, MemoAttributeMetadata.MaxSupportedLength)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 100)]
        public int? Length { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            MemoAttributeMetadata attribute = _attribute as MemoAttributeMetadata;

            if (ImeType.HasValue)
            {
                attribute.ImeMode = ImeMode.Auto;
                if (ImeType == CrmImeType.Active) attribute.ImeMode = ImeMode.Active;
                if (ImeType == CrmImeType.Disabled) attribute.ImeMode = ImeMode.Disabled;
                if (ImeType == CrmImeType.Inactive) attribute.ImeMode = ImeMode.Inactive;
            }

            if (Length.HasValue) attribute.MaxLength = Length.Value;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmIntegerAttribute", HelpUri = HelpUrlConstants.SetIntegerAttributeHelpUrl)]
    [OutputType(typeof(IntegerAttributeMetadata))]
    public sealed class SetIntegerAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmIntegerAttributeFormat.None)]
        public CrmIntegerAttributeFormat? Format { get; set; }

        [Parameter]
        [ValidateRange(int.MinValue, int.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = int.MaxValue)]
        public int? MaxValue { get; set; }

        [Parameter]
        [ValidateRange(int.MinValue, int.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = int.MinValue)]
        public int? MinValue { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            IntegerAttributeMetadata attribute = _attribute as IntegerAttributeMetadata;

            if (Format.HasValue)
            {
                attribute.Format = IntegerFormat.None;
                if (Format == CrmIntegerAttributeFormat.Duration) attribute.Format = IntegerFormat.Duration;
                if (Format == CrmIntegerAttributeFormat.Language) attribute.Format = IntegerFormat.Language;
                if (Format == CrmIntegerAttributeFormat.Locale) attribute.Format = IntegerFormat.Locale;
                if (Format == CrmIntegerAttributeFormat.TimeZone) attribute.Format = IntegerFormat.TimeZone;
            }

            if (MaxValue.HasValue) attribute.MaxValue = MaxValue.Value;
            if (MinValue.HasValue) attribute.MinValue = MinValue.Value;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmBigIntAttribute", HelpUri = HelpUrlConstants.SetBigIntAttributeHelpUrl)]
    [OutputType(typeof(BigIntAttributeMetadata))]
    public sealed class SetBigIntAttributeCommand : SetAttributeCommandBase
    {
        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            BigIntAttributeMetadata attribute = _attribute as BigIntAttributeMetadata;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmDecimalAttribute", HelpUri = HelpUrlConstants.SetDecimalAttributeHelpUrl)]
    [OutputType(typeof(DecimalAttributeMetadata))]
    public sealed class SetDecimalAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType? ImeType { get; set; }

        [Parameter]
        [ValidateNotNull]
        public decimal? MaxValue { get; set; }

        [Parameter]
        [ValidateNotNull]
        public decimal? MinValue { get; set; }

        [Parameter]
        [ValidateRange(1, 10)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 2)]
        public int? Precision { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            DecimalAttributeMetadata attribute = _attribute as DecimalAttributeMetadata;

            if (ImeType.HasValue)
            {
                attribute.ImeMode = ImeMode.Auto;
                if (ImeType == CrmImeType.Active) attribute.ImeMode = ImeMode.Active;
                if (ImeType == CrmImeType.Disabled) attribute.ImeMode = ImeMode.Disabled;
                if (ImeType == CrmImeType.Inactive) attribute.ImeMode = ImeMode.Inactive;
            }
            if (MaxValue.HasValue) attribute.MaxValue = MaxValue.Value;
            if (MinValue.HasValue) attribute.MinValue = MinValue.Value;
            if (Precision.HasValue) attribute.Precision = Precision.Value;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmDoubleAttribute", HelpUri = HelpUrlConstants.SetDoubleAttributeHelpUrl)]
    [OutputType(typeof(DoubleAttributeMetadata))]
    public sealed class SetDoubleAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType? ImeType { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = double.MaxValue)]
        public double? MaxValue { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = double.MinValue)]
        public double? MinValue { get; set; }

        [Parameter]
        [ValidateRange(1, 10)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 2)]
        public int? Precision { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            DoubleAttributeMetadata attribute = _attribute as DoubleAttributeMetadata;

            if (ImeType.HasValue)
            {
                attribute.ImeMode = ImeMode.Auto;
                if (ImeType == CrmImeType.Active) attribute.ImeMode = ImeMode.Active;
                if (ImeType == CrmImeType.Disabled) attribute.ImeMode = ImeMode.Disabled;
                if (ImeType == CrmImeType.Inactive) attribute.ImeMode = ImeMode.Inactive;
            }

            if (MaxValue.HasValue) attribute.MaxValue = MaxValue.Value;
            if (MinValue.HasValue) attribute.MinValue = MinValue.Value;
            if (Precision.HasValue) attribute.Precision = Precision.Value;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmMoneyAttribute", HelpUri = HelpUrlConstants.SetMoneyAttributeHelpUrl)]
    [OutputType(typeof(MoneyAttributeMetadata))]
    public sealed class SetMoneyAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType? ImeType { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 1000000000)]
        public double? MaxValue { get; set; }

        [Parameter]
        [ValidateRange(double.MinValue, double.MaxValue)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 0)]
        public double? MinValue { get; set; }

        [Parameter]
        [ValidateRange(1, 10)]
        [ValidateNotNull]
        [PSDefaultValue(Value = 2)]
        public int? Precision { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmMoneyPrecisionType.Attribute)]
        public CrmMoneyPrecisionType? PrecisionType { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            MoneyAttributeMetadata attribute = _attribute as MoneyAttributeMetadata;

            if (ImeType.HasValue)
            {
                attribute.ImeMode = ImeMode.Auto;
                if (ImeType == CrmImeType.Active) attribute.ImeMode = ImeMode.Active;
                if (ImeType == CrmImeType.Disabled) attribute.ImeMode = ImeMode.Disabled;
                if (ImeType == CrmImeType.Inactive) attribute.ImeMode = ImeMode.Inactive;
            }

            if (MaxValue.HasValue) attribute.MaxValue = MaxValue.Value;
            if (MinValue.HasValue) attribute.MinValue = MinValue.Value;
            if (Precision.HasValue) attribute.Precision = Precision.Value;

            if (PrecisionType.HasValue)
            {
                attribute.PrecisionSource = 0;
                if (PrecisionType == CrmMoneyPrecisionType.OrganizationPricing) attribute.PrecisionSource = 1;
                if (PrecisionType == CrmMoneyPrecisionType.Currency) attribute.PrecisionSource = 2;
            }

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmDateTimeAttribute", HelpUri = HelpUrlConstants.SetDateTimeAttributeHelpUrl)]
    [OutputType(typeof(DateTimeAttributeMetadata))]
    public sealed class SetDateTimeAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmDateTimeAttributeFormat.DateOnly)]
        public CrmDateTimeAttributeFormat? Format { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmImeType.Auto)]
        public CrmImeType? ImeType { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? CanChangeBehavior { get; set; }

        [Parameter]
        [ValidateNotNull]
        [PSDefaultValue(Value = CrmDateTimeBehavior.UserSettings)]
        public CrmDateTimeBehavior? Behavior { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            DateTimeAttributeMetadata attribute = _attribute as DateTimeAttributeMetadata;
            if (CanChangeBehavior.HasValue) attribute.CanChangeDateTimeBehavior = new BooleanManagedProperty(CanChangeBehavior.Value);

            if (ImeType.HasValue)
            {
                attribute.ImeMode = ImeMode.Auto;
                if (ImeType == CrmImeType.Active) attribute.ImeMode = ImeMode.Active;
                if (ImeType == CrmImeType.Disabled) attribute.ImeMode = ImeMode.Disabled;
                if (ImeType == CrmImeType.Inactive) attribute.ImeMode = ImeMode.Inactive;
            }

            if (Format.HasValue)
            {
                attribute.Format = DateTimeFormat.DateAndTime;
                if (Format == CrmDateTimeAttributeFormat.DateOnly) attribute.Format = DateTimeFormat.DateOnly;
            }

            if (Behavior.HasValue)
            {
                attribute.DateTimeBehavior = DateTimeBehavior.UserLocal;
                if (Behavior == CrmDateTimeBehavior.DateOnly) attribute.DateTimeBehavior = DateTimeBehavior.DateOnly;
                if (Behavior == CrmDateTimeBehavior.TimeZoneIndependent) attribute.DateTimeBehavior = DateTimeBehavior.TimeZoneIndependent;
            }

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmBooleanAttribute", HelpUri = HelpUrlConstants.SetBooleanAttributeHelpUrl)]
    [OutputType(typeof(BooleanAttributeMetadata))]
    public sealed class SetBooleanAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        public bool? DefaultValue { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            BooleanAttributeMetadata attribute = _attribute as BooleanAttributeMetadata;
            
            if (DefaultValue.HasValue) attribute.DefaultValue = DefaultValue.Value;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmOptionSetAttribute", HelpUri = HelpUrlConstants.SetOptionSetAttributeHelpUrl)]
    [OutputType(typeof(PicklistAttributeMetadata))]
    public sealed class SetOptionSetAttributeCommand : SetAttributeCommandBase
    {
        [Parameter]
        [ValidateNotNull]
        public int? DefaultValue { get; set; }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PicklistAttributeMetadata attribute = _attribute as PicklistAttributeMetadata;
            if (DefaultValue.HasValue) attribute.DefaultFormValue = DefaultValue;

            WriteAttribute(attribute);
        }
    }

    [Cmdlet(VerbsCommon.Set, "CrmImageAttribute", HelpUri = HelpUrlConstants.SetImageAttributeHelpUrl)]
    [OutputType(typeof(ImageAttributeMetadata))]
    public sealed class SetImageAttributeCommand : SetAttributeCommandBase
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (!CrmVersionManager.IsSupported(CrmVersion.CRM2013_RTM))
            {
                throw new NotSupportedException();
            }
        }

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ImageAttributeMetadata attribute = _attribute as ImageAttributeMetadata;
            WriteAttribute(attribute);
        }
    }

    public abstract class SetAttributeDynamicParameters
    {
        internal protected virtual void SetParametersOnAttribute(AttributeMetadata attribute)
        {
        }
    }

    public sealed class SetAttributeDynamicParameters2016 : SetAttributeDynamicParameters
    {
        [Parameter]
        [ValidateNotNull]
        public bool? IsGlobalFilterEnabled { get; set; }

        [Parameter]
        [ValidateNotNull]
        public bool? IsSortableEnabled { get; set; }

        protected internal override void SetParametersOnAttribute(AttributeMetadata attribute)
        {
            base.SetParametersOnAttribute(attribute);

            if (IsGlobalFilterEnabled.HasValue) attribute.IsGlobalFilterEnabled = new BooleanManagedProperty(IsGlobalFilterEnabled.Value);
            if (IsSortableEnabled.HasValue) attribute.IsSortableEnabled = new BooleanManagedProperty(IsSortableEnabled.Value);
        }
    }
}
