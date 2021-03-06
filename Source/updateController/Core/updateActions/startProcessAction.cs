﻿/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System;

namespace updateSystemDotNet.Core.updateActions {
	/// <summary>
	/// Updateaction welche zum Starten eines Prozesses verwendet wird.
	/// </summary>
	[Serializable]
	[administrationEditor("catProcesses", "start_process", "Führt einen Prozess aus.",
		"updateSystemDotNet.Administration.UI.updateActionEditor.startProcessActionEditor")]
	public sealed class startProcessAction : actionBase {
		private string m_arguments = string.Empty;
		private bool m_dontRunIfExists;
		private string m_path = string.Empty;
		private bool m_waitForExit;

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="startProcessAction"/>.
		/// </summary>
		public startProcessAction() {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="startProcessAction"/>.
		/// </summary>
		/// <param name="Path"></param>
		public startProcessAction(string Path)
			: this(Path, string.Empty, false) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="startProcessAction"/>.
		/// </summary>
		/// <param name="Path">Der Pfad der auszuführenden Datei.</param>
		/// <param name="Args">Befehlszeilenargumente die an die Datei weitergegeben werden sollen.</param>
		public startProcessAction(string Path, string Args)
			: this(Path, Args, false) {
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="startProcessAction"/>.
		/// </summary>
		/// <param name="Path">Der Pfad der auszuführenden Datei.</param>
		/// <param name="Args">Befehlszeilenargumente die an die Datei weitergegeben sollen.</param>
		/// <param name="WaitForExit">Gibt an ob der Updater auf das beenden dieses Prozesses warten soll.</param>
		public startProcessAction(string Path, string Args, bool WaitForExit) {
			m_path = Path;
			m_arguments = Args;
			m_waitForExit = WaitForExit;
		}

		/// <summary>
		/// Gibt den Pfad zu der Datei zurück die ausgeführt werden soll oder legt diesen fest.
		/// </summary>
		public string Path {
			get { return m_path; }
			set { m_path = value; }
		}

		/// <summary>
		/// Gibt die Befehlszeilenargumente für die Auszuführende Datei zurück oder legt diese fest.
		/// </summary>
		public string Arguments {
			get { return m_arguments; }
			set { m_arguments = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest, ob der Updater auf das beenden der Datei warten soll.
		/// </summary>
		public bool waitForExit {
			get { return m_waitForExit; }
			set { m_waitForExit = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest, ob der Prozess nicht gestartet werden soll, wenn bereits ein anderer Prozess mit dem gleichen Namen läuft.
		/// </summary>
		public bool dontRunIfExists {
			get { return m_dontRunIfExists; }
			set { m_dontRunIfExists = value; }
		}

		/// <summary>
		/// Gibt an oder legt fest, ob der Prozess erhöhte Rechte benötigt.
		/// </summary>
		public bool needElevatedRights { get; set; }

		/// <summary>
		/// Gibt den Namen der Aktion zurück
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return "Prozess starten";
		}

		/// <summary>
		/// Überprüft in der Updateaction ob alle benötigen Parameter einen Wert besitzen.
		/// </summary>
		/// <returns>Gibt True zurück wenn die Überprüfung erfolgreich war, andernfalls false.</returns>
		public override bool Validate() {
			return !string.IsNullOrEmpty(Path);
		}
	}
}