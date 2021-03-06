﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
//
// Copyright (c) 2010-2012 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace SiliconStudio.Paradox.Graphics
{
    /// <summary>
    /// Features supported by a <see cref="GraphicsDevice"/>.
    /// </summary>
    /// <remarks>
    /// This class gives also features for a particular format, using the operator this[dxgiFormat] on this structure.
    /// </remarks>
    public partial struct GraphicsDeviceFeatures
    {
        private readonly FeaturesPerFormat[] mapFeaturesPerFormat;

        /// <summary>
        /// Features level of the current device.
        /// </summary>
        public GraphicsProfile Profile;

        /// <summary>
        /// Boolean indicating if this device supports compute shaders, unordered access on structured buffers and raw structured buffers.
        /// </summary>
        public readonly bool HasComputeShaders;

        /// <summary>
        /// Boolean indicating if this device supports shaders double precision calculations.
        /// </summary>
        public readonly bool HasDoublePrecision;

        /// <summary>
        /// Boolean indicating if this device supports concurrent resources in multithreading scenarios.
        /// </summary>
        public readonly bool HasMultiThreadingConcurrentResources;

        /// <summary>
        /// Boolean indicating if this device supports command lists in multithreading scenarios.
        /// </summary>
        public readonly bool HasDriverCommandLists;

        /// <summary>
        /// Is the device being profiled.
        /// </summary>
        public readonly bool IsProfiled;

        /// <summary>
        /// Gets the <see cref="FeaturesPerFormat" /> for the specified <see cref="SharpDX.DXGI.Format" />.
        /// </summary>
        /// <param name="dxgiFormat">The dxgi format.</param>
        /// <returns>Features for the specific format.</returns>
        public FeaturesPerFormat this[PixelFormat dxgiFormat]
        {
            get { return this.mapFeaturesPerFormat[(int)dxgiFormat]; }
        }

        /// <summary>
        /// The features exposed for a particular format.
        /// </summary>
        public struct FeaturesPerFormat
        {
            //internal FeaturesPerFormat(PixelFormat format, MSAALevel maximumMSAALevel, ComputeShaderFormatSupport computeShaderFormatSupport, FormatSupport formatSupport)
            internal FeaturesPerFormat(PixelFormat format, MSAALevel maximumMSAALevel, FormatSupport formatSupport)
            {
                Format = format;
                this.MSAALevelMax = maximumMSAALevel;
                //ComputeShaderFormatSupport = computeShaderFormatSupport;
                FormatSupport = formatSupport;
            }

            /// <summary>
            /// The <see cref="SharpDX.DXGI.Format"/>.
            /// </summary>
            public readonly PixelFormat Format;

            /// <summary>
            /// Gets the maximum MSAA sample count for a particular <see cref="PixelFormat"/>.
            /// </summary>
            public readonly MSAALevel MSAALevelMax;

            /// <summary>	
            /// Gets the unordered resource support options for a compute shader resource.	
            /// </summary>	
            //public readonly ComputeShaderFormatSupport ComputeShaderFormatSupport;

            /// <summary>
            /// Support of a given format on the installed video device.
            /// </summary>
            public readonly FormatSupport FormatSupport;

            public override string ToString()
            {
                //return string.Format("Format: {0}, MSAALevelMax: {1}, ComputeShaderFormatSupport: {2}, FormatSupport: {3}", Format, this.MSAALevelMax, ComputeShaderFormatSupport, FormatSupport);
                return string.Format("Format: {0}, MSAALevelMax: {1}, FormatSupport: {2}", Format, this.MSAALevelMax, FormatSupport);
            }
        }

        public override string ToString()
        {
            return string.Format("Level: {0}, HasComputeShaders: {1}, HasDoublePrecision: {2}, HasMultiThreadingConcurrentResources: {3}, HasDriverCommandLists: {4}", Profile, HasComputeShaders, HasDoublePrecision, HasMultiThreadingConcurrentResources, this.HasDriverCommandLists);
        }
    }
}