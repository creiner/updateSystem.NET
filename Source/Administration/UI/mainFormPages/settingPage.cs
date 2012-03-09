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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal partial class settingPage : basePage {

		private const int vertScrollbarWidthAddition = 20;

		public settingPage() {
			InitializeComponent();
			Id = Guid.NewGuid().ToString();
			pageSymbol = Core.resourceHelper.getImage("settings.png");
			displayOrder = 200;
		}

		/// <summary>Lädt alle Einstellungsblöcke für das Updateprojekt.</summary>
		private void initializeContentSubPages() {

			var settingSubBasePages = new SortedList<int, settingSubPages.settingSubBasePage>();
			flpSettings.Controls.Clear();
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {

				if (type.BaseType == null || type.BaseType != typeof (settingSubPages.settingSubBasePage))
					continue;

				var instance = (settingSubPages.settingSubBasePage) Activator.CreateInstance(type);
				instance.Session = Session;
				instance.initializeData();
				settingSubBasePages.Add(instance.displayOrder, instance);
			}

			//Einstellungsblöcke hinzufügen
			foreach (var kv in settingSubBasePages) {
				var settingsGroup = new groupBoxEx {
				                                   	Size = kv.Value.Size,
				                                   	Width =
				                                   		flpSettings.Width -
				                                   		(SystemInformation.VerticalScrollBarWidth + vertScrollbarWidthAddition),
				                                   	Text = kv.Value.Title
				                                   };
				kv.Value.Location = new Point(12,18);
				kv.Value.Width = settingsGroup.ClientSize.Width - 12;
				kv.Value.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				settingsGroup.Height = kv.Value.Height + 18;
				settingsGroup.Controls.Add(kv.Value);
				flpSettings.Controls.Add(settingsGroup);
			}

		}

		protected override void OnSizeChanged(EventArgs e) {
			base.OnSizeChanged(e);

			if (flpSettings != null)
				foreach (Control control in flpSettings.Controls)
					control.Width = flpSettings.Width - (SystemInformation.VerticalScrollBarWidth + vertScrollbarWidthAddition);

		}

		public override void initializeData() {
			initializeContentSubPages();
		}

	}
}