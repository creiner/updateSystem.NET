﻿#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspGeneral : settingSubBasePage {
		public sspGeneral() {
			InitializeComponent();
		}
		public override void initializeData() {
			chkNativeImage.Checked = Session.currentProject.generateNativeImages;
			chkServicePackIsDefault.Checked = Session.currentProject.setServicePackAsDefault;
		}
		private void chkNativeImage_CheckedChanged(object sender, System.EventArgs e) {
			Session.currentProject.generateNativeImages = chkNativeImage.Checked;
		}

		private void chkServicePackIsDefault_CheckedChanged(object sender, System.EventArgs e) {
			Session.currentProject.setServicePackAsDefault = chkServicePackIsDefault.Checked;
		}
	}
}