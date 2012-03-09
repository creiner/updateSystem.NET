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
using System.Xml.Serialization;
using updateSystemDotNet.Administration.Core.Publishing;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Administration.Core.updateLog;

namespace updateSystemDotNet.Administration.Core.Updates {
	
	[Serializable]
	[XmlRoot("updateProject")]
	public class updateProject : ICloneable {

		public updateProject() {
			publishProvider = new List<IPublishProvider>();
			updatePackages = new List<updatePackage>();
			linkedPublishProvider = new serializableDictionary<string, List<string>>();
			updateLogUser = new userAccount();
			viewFilter = new updatePackageViewFilter();
		}

		/// <summary>Gibt das Schlüsselpaar zurück welches für die Signatur der Updatepakete verwendet wird oder legt dieses fest.</summary>
		public rsaKeyPair keyPair { get; set; }

		/// <summary>Bietet Zugriff auf alle vom Benutzer angelegten Einstellungen der PublishProvider.</summary>
		public List<publishSettings> publishProviderSettings { get; set; }

		/// <summary>Bietet Zugriff auf die PublishProvider des Projektes.</summary>
		[XmlIgnore]
		internal List<IPublishProvider> publishProvider { get; set; }

		/// <summary>Gibt den Namen des Projektes bzw. der Anwendung zurück oder legt diesen fest.</summary>
		public string projectName { get; set; }

		/// <summary>Eine eindeutige ID die das Projekt identifiziert.</summary>
		/// <remarks>Da diese die Statistiken mit dem Programm verknüpft, darf Sie für den Benutzer nicht veränderbar sein.</remarks>
		[encryptProperty]
		public string projectId { get; set; }

		/// <summary>Auflistung aller im Projekt verfügbaren Updatepakete.</summary>
		public List<updatePackage> updatePackages { get; set; }

		/// <summary>Eine Verlinkung zwischen Updatepaketen und Veröffentlichungsschnittstellen.</summary>
		public serializableDictionary<string, List<string>> linkedPublishProvider { get; set; }

		/// <summary>Gibt an ob der Dialog mit der Auswertung der publishProvider nur bei Fehlern angezeigt werden soll.</summary>
		public bool hidePublishResult { get; set; }

		/// <summary>Gibt den updateLog Benutzeraccount zurück oder legt diesen fest.</summary>
		public userAccount updateLogUser { get; set; }

		/// <summary>Gibt zurück oder legt fest, ob die Erfassung von Statistiken für dieses Projekt aktiviert ist.</summary>
		public bool updateLogEnabled { get; set; }

		/// <summary>Gibt an, ob bei der Updateinstallation von .NET Assemblies native Abbilder erzeugt werden können</summary>
		public bool generateNativeImages { get; set; }

		/// <summary>Gibt den Parameter an, der vom updateInstaller an die Clientanwendung bei einem erfolgreichen Update übermittelt werden soll.</summary>
		public string updateParameterSuccess { get; set; }

		/// <summary>Gibt den Parameter an, der vom updateInstaller an die Clientanwendung bei einem fehlgeschlagenen Update übermittelt werden soll.</summary>
		public string updateParameterFailed { get; set; }

		/// <summary>Legt die Setup-Id fest welche beötigt wird, um die Anwendungsversion über die Registry aktualisieren zu können.</summary>
		public string updateSetupId { get; set; }

		/// <summary>Gibt an ob die Version neuer Updatepakete aus einem Assembly ermittelt werdens soll.</summary>
		public bool linkAssemblyToVersion { get; set; }

		/// <summary>Der Pfad zu dem Assembly von welchem die Version ermittelt werden soll.</summary>
		public string linkedAssemblyPath { get; set; }

		/// <summary>Filtereinstellungen für die Updatepaketauflistung in der GUI.</summary>
		public updatePackageViewFilter viewFilter { get; set; }

		/// <summary>If set, new Updatepackages will be an Service Pack by default.</summary>
		public bool setServicePackAsDefault { get; set; }

		/// <summary>Returns the last Path of the imported Changelog.</summary>
		public string changelogPath { get; set; }

		/// <summary>Fügt dem Updateprojekt einen neuen PublshProvider hinzu.</summary>
		/// <param name="provider">Der Provider der hinzugefügt werden soll.</param>
		internal void addPublishProvider(IPublishProvider provider) {
			//Provider der Liste der vorhandenen PublishProvider hinzufügen
			publishProvider.Add(provider);

			//Einstellungen seperat speichern
			publishProviderSettings.Add(provider.Settings);
		}

		/// <summary>Entfernt einen PublishProvider vollständig aus dem Updateprojekt.</summary>
		/// <param name="provider">Der Provider der entfernt werden soll.</param>
		internal void removePublishProvider(IPublishProvider provider) {
			//Einstellungen entfernen
			publishProviderSettings.Remove(provider.Settings);

			//Provider entfernen
			publishProvider.Remove(provider);
		}

		#region ICloneable Member

		public object Clone() {
			var result = new updateProject {
			                               	keyPair = keyPair,
			                               	projectName = projectName,
			                               	projectId = projectId,
			                               	publishProviderSettings = new List<publishSettings>(),
											hidePublishResult = hidePublishResult,
											updateLogUser = (userAccount)updateLogUser.Clone(),
											generateNativeImages = generateNativeImages,
											updateParameterSuccess = updateParameterSuccess,
											updateParameterFailed = updateParameterFailed,
											updateLogEnabled = updateLogEnabled,
											updateSetupId = updateSetupId,
											linkAssemblyToVersion = linkAssemblyToVersion,
											linkedAssemblyPath = linkedAssemblyPath,
											viewFilter = (updatePackageViewFilter)viewFilter.Clone(),
											setServicePackAsDefault = setServicePackAsDefault,
											changelogPath = changelogPath
			                               };
			
			//Provider kopieren
			foreach(var setting in publishProviderSettings)
				result.publishProviderSettings.Add((publishSettings)setting.Clone());

			//Updatepakete kopieren
			foreach(var update in updatePackages)
				result.updatePackages.Add((updatePackage)update.Clone());

			//Verknüpfungen kopieren
			foreach (var link in linkedPublishProvider)
				result.linkedPublishProvider.Add(link.Key, new List<string>(link.Value.ToArray()));

			return result;
		}

		#endregion
	}
}