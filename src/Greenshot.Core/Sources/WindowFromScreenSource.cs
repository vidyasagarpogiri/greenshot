﻿/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2015  Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on Sourceforge: http://sourceforge.net/projects/greenshot/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Greenshot.Plugin.Modules;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Greenshot.Plugin.Modules.Interfaces;

namespace Greenshot.Modules {
	/// <summary>
	/// This is the window from screen source, and makes it possible to capture the window directly from the screen
	/// </summary>
	[Source(Designation = "WindowFromScreenSource", LanguageKey = "")]
	public class WindowFromScreenSource : ScreenSource {
		[Import]
		private WindowsContainer _windowsContainer = null;

		/// <summary>
		/// Capture the screen
		/// </summary>
		/// <returns></returns>
		public override Task<bool> ImportAsync(CaptureContext captureContext, CancellationToken token = default(CancellationToken)) {
			Rect windowBounds = _windowsContainer.ActiveWindow.Bounds;
			captureContext.Capture = CaptureRectangle(windowBounds);
			captureContext.ClipArea = new RectangleGeometry(windowBounds);
			captureContext.CropRect = windowBounds;
			return Task.FromResult<bool>(true);
		}
	}
}