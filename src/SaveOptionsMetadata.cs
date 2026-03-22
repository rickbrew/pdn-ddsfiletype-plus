////////////////////////////////////////////////////////////////////////
//
// This file is part of pdn-ddsfiletype-plus, a DDS FileType plugin
// for Paint.NET that adds support for the DX10 and later formats.
//
// Copyright (c) 2017-2026 Nicholas Hayes
//
// This file is licensed under the MIT License.
// See LICENSE.txt for complete licensing and attribution information.
//
////////////////////////////////////////////////////////////////////////

using PaintDotNet.FileTypes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DdsFileTypePlus
{
    public sealed class SaveOptionsMetadata
    {
        private const string FormatName = $"{nameof(DdsFileType)}.{nameof(Format)}";

        public DdsFileFormat Format
        {
            get;
            init;
        }

        public SaveOptionsMetadata()
        {
        }

        public void Save(IFileTypePropertyBag propertyBag)
        {
            propertyBag.SetItem(FormatName, Format);
        }

        public static bool TryLoad(IReadOnlyFileTypePropertyBag propertyBag, [NotNullWhen(true)] out SaveOptionsMetadata? metadata)
        {
            if (!propertyBag.TryGetValue(FormatName, out DdsFileFormat format))
            {
                metadata = null;
                return false;
            }

            metadata = new SaveOptionsMetadata()
            {
                Format = format
            };

            return true;
        }
    }
}
